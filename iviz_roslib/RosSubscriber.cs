﻿using System;
using System.Collections.Generic;
using Iviz.Msgs;

namespace Iviz.Roslib
{
    /// <summary>
    /// Class that manages a subscription to a ROS topic.
    /// </summary>
    public class RosSubscriber
    {
        readonly List<string> ids = new List<string>();
        readonly List<Action<IMessage>> callbackList = new List<Action<IMessage>>();
        readonly TcpReceiverManager manager;
        readonly RosClient client;
        readonly Type topicClassType;
        
        int totalSubscribers;

        /// <summary>
        /// Whether this subscriber is valid.
        /// </summary>
        public bool IsAlive { get; private set; }
        /// <summary>
        /// The name of the topic.
        /// </summary>
        public string Topic => manager.Topic;
        /// <summary>
        /// The ROS message type of the topic.
        /// </summary>
        public string TopicType => manager.TopicType;
        /// <summary>
        /// The number of publishers in the topic.
        /// </summary>
        public int NumPublishers => manager.NumConnections;
        /// <summary>
        /// The number of ids generated by this subscriber.
        /// </summary>
        public int NumIds => ids.Count;
        /// <summary>
        /// Whether the TCP_NODELAY flag was requested.
        /// </summary>
        public bool RequestNoDelay => manager.RequestNoDelay;

        /// <summary>
        /// Event triggered when a new publisher appears.
        /// </summary>
        public event Action<RosSubscriber> NumPublishersChanged;
        
        /// <summary>
        /// Timeout in milliseconds to wait for a publisher handshake.
        /// </summary>
        public int TimeoutInMs
        {
            get => manager.TimeoutInMs;
            set => manager.TimeoutInMs = value;
        }

        internal RosSubscriber(RosClient client, TcpReceiverManager manager)
        {
            this.client = client;
            this.manager = manager;
            topicClassType = manager.TopicInfo.Generator.GetType();
            IsAlive = true;

            manager.Subscriber = this;
        }

        internal void MessageCallback(IMessage msg)
        {
            lock (callbackList)
            {
                foreach (Action<IMessage> callback in callbackList)
                {
                    callback(msg);
                }
            }
        }

        string GenerateId()
        {
            string newId = totalSubscribers == 0 ? Topic : $"{Topic}-{totalSubscribers}";
            totalSubscribers++;
            return newId;
        }

        void AssertIsAlive()
        {
            if (!IsAlive)
            {
                throw new ObjectDisposedException("This is not a valid subscriber");
            }
        }

        public void Cleanup()
        {
            if (manager.Cleanup())
            {
                NumPublishersChanged?.Invoke(this);
            }
        }

        public SubscriberTopicState GetState()
        {
            AssertIsAlive();
            Cleanup();
            return new SubscriberTopicState(Topic, TopicType, ids, manager.GetStates());
        }

        internal void PublisherUpdateRcp(Uri[] publisherUris)
        {
            if (manager.PublisherUpdateRpc(client, publisherUris))
            {
                NumPublishersChanged?.Invoke(this);
            }
        }

        internal void Stop()
        {
            ids.Clear();
            manager.Stop();
            NumPublishersChanged = null;
            IsAlive = false;
        }

        public bool MessageTypeMatches(Type type)
        {
            return type == topicClassType;
        }

        public string Subscribe(Action<IMessage> callback)
        {
            if (callback is null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            AssertIsAlive();

#if DEBUG__
            Logger.LogDebug($"{this}: Subscribing to '{Topic}' with type '{TopicType}'");
#endif

            lock (callbackList)
            {
                string id = GenerateId();
                ids.Add(id);
                callbackList.Add(callback);
                return id;
            }
        }

        public bool ContainsId(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return ids.Contains(id);
        }

        public bool Unsubscribe(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            AssertIsAlive();
            lock (callbackList)
            {
                int index = ids.IndexOf(id);
                if (index < 0)
                {
                    return false;
                }
                ids.RemoveAt(index);
                callbackList.RemoveAt(index);
            }

#if DEBUG__
            Logger.LogDebug($"{this}: Unsubscribing to '{Topic}' with type '{TopicType}'");
#endif

            if (ids.Count == 0)
            {
                Stop();
                client.RemoveSubscriber(this);

#if DEBUG__
                Logger.LogDebug($"{this}: Removing subscription '{Topic}' with type '{TopicType}'");
#endif
            }
            return true;
        }
        
        public override string ToString()
        {
            return $"[Subscriber {Topic} [{TopicType}] ]";
        }        
        
    }
}
