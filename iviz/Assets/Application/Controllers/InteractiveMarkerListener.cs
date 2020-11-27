﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Iviz.App;
using Iviz.Core;
using Iviz.Msgs;
using Iviz.Msgs.GeometryMsgs;
using Iviz.Msgs.VisualizationMsgs;
using Iviz.Resources;
using Iviz.Ros;
using Iviz.Roslib;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;
using Pose = UnityEngine.Pose;
using Vector3 = UnityEngine.Vector3;

namespace Iviz.Controllers
{
    [DataContract]
    public class InteractiveMarkerConfiguration : JsonToString, IConfiguration
    {
        [DataMember] public string Topic { get; set; } = "";
        [DataMember] public bool DescriptionsVisible { get; set; }
        [DataMember] public string Id { get; set; } = Guid.NewGuid().ToString();
        [DataMember] public Resource.ModuleType ModuleType => Resource.ModuleType.InteractiveMarker;
        [DataMember] public bool Visible { get; set; } = true;
    }

    public sealed class InteractiveMarkerListener : ListenerController, IMarkerDialogListener
    {
        readonly InteractiveMarkerConfiguration config = new InteractiveMarkerConfiguration();

        readonly Dictionary<string, InteractiveMarkerObject> interactiveMarkers =
            new Dictionary<string, InteractiveMarkerObject>();

        readonly FrameNode node;

        uint feedSeq;

        public InteractiveMarkerListener([NotNull] IModuleData moduleData)
        {
            ModuleData = moduleData ?? throw new ArgumentNullException(nameof(moduleData));
            node = FrameNode.Instantiate("[InteractiveMarkerListener]");
        }

        public Listener<InteractiveMarkerInit> FullListener { get; private set; }
        public Sender<InteractiveMarkerFeedback> Publisher { get; private set; }
        public override TfFrame Frame => TfListener.MapFrame;
        public override IModuleData ModuleData { get; }
        public string Topic => config.Topic;

        public InteractiveMarkerConfiguration Config
        {
            get => config;
            set
            {
                config.Topic = value.Topic;
                DescriptionsVisible = value.DescriptionsVisible;
            }
        }

        public bool DescriptionsVisible
        {
            get => config.DescriptionsVisible;
            set
            {
                if (config.DescriptionsVisible == value)
                {
                    return;
                }

                config.DescriptionsVisible = value;
                foreach (var interactiveMarker in interactiveMarkers.Values)
                {
                    interactiveMarker.DescriptionVisible = value;
                }
            }
        }

        public void GenerateLog(StringBuilder description)
        {
            if (description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }

            foreach (var interactiveMarker in interactiveMarkers.Values)
            {
                interactiveMarker.GenerateLog(description);
                description.AppendLine();
            }

            description.AppendLine().AppendLine();
        }

        public string BriefDescription
        {
            get
            {
                switch (interactiveMarkers.Count)
                {
                    case 0:
                        return "<b>No interactive markers →</b>";
                    case 1:
                        return "<b>1 interactive marker →</b>";
                    default:
                        return $"<b>{interactiveMarkers.Values.Count} interactive markers →</b>";
                }
            }
        }

        public void Reset()
        {
            DestroyAllMarkers();
            FullListener?.Unpause();
        }

        public override void StartListening()
        {
            Listener = new Listener<InteractiveMarkerUpdate>(config.Topic, HandlerUpdate);
            GameThread.EverySecond += CheckForExpiredMarkers;

            int lastSlash = config.Topic.LastIndexOf('/');
            string root = lastSlash == -1 ? config.Topic : config.Topic.Substring(0, lastSlash);

            string feedbackTopic = $"{root}/feedback";
            string fullTopic = $"{root}/update_full";

            Publisher = new Sender<InteractiveMarkerFeedback>(feedbackTopic);
            FullListener = new Listener<InteractiveMarkerInit>(fullTopic, HandlerUpdateFull);
        }

        public override void StopController()
        {
            base.StopController();
            GameThread.EverySecond -= CheckForExpiredMarkers;

            foreach (var markerObject in interactiveMarkers.Values)
            {
                DeleteMarkerObject(markerObject);
            }

            interactiveMarkers.Clear();
            Publisher.Stop();

            node.Stop();
            Object.Destroy(node.gameObject);
        }

        public override void ResetController()
        {
            base.ResetController();
            DestroyAllMarkers();
            FullListener?.Reset();
            Publisher?.Reset();
        }

        void HandlerUpdate([NotNull] InteractiveMarkerUpdate msg)
        {
            if (msg.Type == InteractiveMarkerUpdate.KEEP_ALIVE)
            {
                return;
            }

            msg.Markers.ForEach(CreateInteractiveMarker);
            msg.Poses.ForEach(UpdateInteractiveMarkerPose);
            msg.Erases.ForEach(DestroyInteractiveMarker);
        }

        void HandlerUpdateFull([NotNull] InteractiveMarkerInit msg)
        {
            msg.Markers.ForEach(CreateInteractiveMarker);
            FullListener.Pause();
        }

        void CreateInteractiveMarker([NotNull] InteractiveMarker msg)
        {
            string id = msg.Name;
            if (interactiveMarkers.TryGetValue(id, out InteractiveMarkerObject existingMarkerObject))
            {
                existingMarkerObject.Set(msg);
                return;
            }

            InteractiveMarkerObject newMarkerObject = CreateInteractiveMarkerObject();
            newMarkerObject.Initialize(this, id);
            newMarkerObject.Parent = TfListener.ListenersFrame;
            newMarkerObject.Visible = Visible;
            newMarkerObject.transform.SetParentLocal(node.transform);
            interactiveMarkers[id] = newMarkerObject;
            newMarkerObject.Set(msg);
        }

        static InteractiveMarkerObject CreateInteractiveMarkerObject()
        {
            GameObject gameObject = new GameObject("InteractiveMarkerObject");
            return gameObject.AddComponent<InteractiveMarkerObject>();
        }

        static void DeleteMarkerObject([NotNull] InteractiveMarkerObject marker)
        {
            marker.Stop();
            Object.Destroy(marker.gameObject);
        }

        void UpdateInteractiveMarkerPose([NotNull] InteractiveMarkerPose msg)
        {
            string id = msg.Name;
            if (!interactiveMarkers.TryGetValue(id, out InteractiveMarkerObject im))
            {
                return;
            }

            im.Set(msg.Pose);
            //im.UpdateExpirationTime();
        }

        void DestroyInteractiveMarker([NotNull] string id)
        {
            if (!interactiveMarkers.TryGetValue(id, out InteractiveMarkerObject interactiveMarker))
            {
                return;
            }

            interactiveMarker.Stop();
            Object.Destroy(interactiveMarker.gameObject);
            interactiveMarkers.Remove(id);
        }

        internal void OnInteractiveControlObjectMouseEvent(
            string interactiveMarkerId, string controlId,
            in Pose controlPose, in Vector3? position,
            MouseEventType eventType)
        {
            InteractiveMarkerFeedback msg = new InteractiveMarkerFeedback
            (
                RosUtils.CreateHeader(feedSeq++, "e2/world"),
                ConnectionManager.MyId ?? "",
                interactiveMarkerId,
                controlId,
                (byte) eventType,
                TfListener.RelativePoseToOrigin(controlPose).Unity2RosPose(),
                0,
                position?.Unity2RosPoint() ?? Point.Zero,
                position != null
            );
            Publisher.Publish(msg);
        }

        internal void OnInteractiveControlObjectMoved(
            [NotNull] string interactiveMarkerId, [NotNull] string controlId,
            in Pose controlPose)
        {
            InteractiveMarkerFeedback msg = new InteractiveMarkerFeedback
            (
                RosUtils.CreateHeader(feedSeq++, "map"),
                ConnectionManager.MyId ?? "",
                interactiveMarkerId,
                controlId,
                InteractiveMarkerFeedback.POSE_UPDATE,
                //TfListener.RelativePoseToOrigin(controlPose).Unity2RosPose(),
                controlPose.Unity2RosPose(),
                0,
                Vector3.zero.Unity2RosPoint(),
                false
            );
            Publisher.Publish(msg);
        }

        void CheckForExpiredMarkers()
        {
            /*
            if (!EnableAutoExpiration)
            {
                return;
            }

            DateTime now = DateTime.Now;
            string[] deadMarkers = imarkers
                .Where(entry => entry.Value.ExpirationTime < now)
                .Select(entry => entry.Key)
                .ToArray();

            foreach (string key in deadMarkers) DestroyInteractiveMarker(key);
            */
        }

        public bool Visible
        {
            get => config.Visible;
            set
            {
                config.Visible = value;

                foreach (var marker in interactiveMarkers.Values)
                {
                    marker.Visible = value;
                }
            }
        }


        void DestroyAllMarkers()
        {
            foreach (var markerObject in interactiveMarkers.Values)
            {
                DeleteMarkerObject(markerObject);
            }

            interactiveMarkers.Clear();
        }
    }
}