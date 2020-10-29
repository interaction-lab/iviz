﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Iviz.Msgs;
using Iviz.XmlRpc;

namespace Iviz.Roslib
{
    /// <summary>
    /// Interface for all ROS publishers.
    /// </summary>
    public interface IRosPublisher
    {
        /// <summary>
        /// The name of the topic.
        /// </summary>
        public string Topic { get; }
        
        /// <summary>
        /// The ROS message type of the topic.
        /// </summary>        
        public string TopicType { get; }
        
        /// <summary>
        /// Timeout in milliseconds to wait for a subscriber handshake.
        /// </summary>             
        public int TimeoutInMs { get; set; }
        
        /// <summary>
        /// The number of publishers in the topic.
        /// </summary>
        public int NumSubscribers { get; }
        
        /// <summary>
        /// Publishes the given message into the topic. 
        /// </summary>
        /// <param name="message">The message to be published.</param>
        /// <exception cref="ArgumentNullException">The message is null</exception>
        /// <exception cref="InvalidMessageTypeException">The message type does not match.</exception>          
        public void Publish(IMessage message);
        
        /// <summary>
        /// Unregisters the given id from the publisher. If the publisher has no ids left, the topic will be unadvertised from the master.
        /// </summary>
        /// <param name="id">The id to be unregistered.</param>
        /// <returns>Whether the id belonged to the publisher.</returns>        
        public bool Unadvertise(string id);
        
        /// <summary>
        /// Unregisters the given id from the publisher. If the publisher has no ids left, the topic will be unadvertised from the master.
        /// </summary>
        /// <param name="id">The id to be unregistered.</param>
        /// <returns>Whether the id belonged to the publisher.</returns>
        public Task<bool> UnadvertiseAsync(string id);
        
        /// <summary>
        /// Generates a new advertisement id. Use this string for Unadvertise().
        /// </summary>
        /// <returns>The advertisement id.</returns>
        public string Advertise();
        
        /// <summary>
        /// Checks whether this publisher has provided the given id from an Advertise() call.
        /// </summary>
        /// <param name="id">Identifier to check.</param>
        /// <returns>Whether the id was provided by this publisher.</returns>
        public bool ContainsId(string id);
        
        /// <summary>
        /// Checks whether this publisher's message type corresponds to the given type
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>Whether the class type matches.</returns>        
        public bool MessageTypeMatches(Type type);
        
        /// <summary>
        /// Returns a structure that represents the internal state of the publisher. 
        /// </summary>        
        public PublisherTopicState GetState();
        
        internal void Stop();
        internal Endpoint RequestTopicRpc(string remoteCallerId);
    }

    /// <summary>
    /// Manager for a ROS publisher.
    /// </summary>
    /// <typeparam name="T">Topic type</typeparam>
    public class RosPublisher<T> : IRosPublisher where T : IMessage
    {
        readonly TcpSenderManager<T> manager;
        readonly List<string> ids = new List<string>();
        readonly RosClient client;
        int totalPublishers;

        /// <summary>
        /// Whether this publisher is valid.
        /// </summary>
        bool IsAlive { get; set; }
        public string Topic => manager.Topic;
        public string TopicType => manager.TopicType;
        public int NumSubscribers => manager.NumConnections;

        /// <summary>
        /// The number of ids generated by this publisher.
        /// </summary>
        public int NumIds => ids.Count;

        /// <summary>
        /// Whether latching is enabled. When active, new subscribers will automatically receive a copy of the last message sent.
        /// </summary>
        public bool LatchingEnabled
        {
            get => manager.Latching;
            set => manager.Latching = value;
        }

        /// <summary>
        /// The queue size in bytes.
        /// If a message arrives that makes the queue larger than this, the oldest message will be discarded.
        /// </summary>
        public int MaxQueueSizeInBytes
        {
            get => manager.MaxQueueSizeInBytes;
            set => manager.MaxQueueSizeInBytes = value;
        }

   
        public int TimeoutInMs
        {
            get => manager.TimeoutInMs;
            set => manager.TimeoutInMs = value;
        }

        /// <summary>
        /// Called when the number of subscribers has changed.
        /// </summary>        
        public event Action<RosPublisher<T>> NumSubscribersChanged;

        internal RosPublisher(RosClient client, TcpSenderManager<T> manager)
        {
            this.client = client;
            this.manager = manager;
            IsAlive = true;

            manager.Publisher = this;
        }

        internal void RaiseNumConnectionsChanged()
        {
            NumSubscribersChanged?.Invoke(this);            
        }

        void AssertIsAlive()
        {
            if (!IsAlive)
            {
                throw new ObjectDisposedException("This is not a valid publisher");
            }
        }

        string GenerateId()
        {
            string newId = totalPublishers == 0 ? Topic : $"{Topic}-{totalPublishers}";
            totalPublishers++;
            return newId;
        }
        
        public PublisherTopicState GetState()
        {
            AssertIsAlive();
            return new PublisherTopicState(Topic, TopicType, ids, manager.GetStates());
        }
        
        void IRosPublisher.Publish(IMessage message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (!MessageTypeMatches(message.GetType()))
            {
                throw new InvalidMessageTypeException("Type does not match publisher.");
            }

            message.RosValidate();
            AssertIsAlive();
            manager.Publish((T) message);
        }

        /// <summary>
        /// Publishes the given message into the topic. 
        /// </summary>
        /// <param name="message">The message to be published.</param>
        /// <exception cref="ArgumentNullException">The message is null</exception>
        /// <exception cref="InvalidMessageTypeException">The message type does not match.</exception>        
        public void Publish(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            message.RosValidate();
            AssertIsAlive();
            manager.Publish(message);
        }

        Endpoint IRosPublisher.RequestTopicRpc(string remoteCallerId)
        {
            Endpoint localEndpoint = manager.CreateConnectionRpc(remoteCallerId);
            return new Endpoint(client.CallerUri.Host, localEndpoint.Port);
        }

        void IRosPublisher.Stop()
        {
            Stop();
        }

        void Stop()
        {
            ids.Clear();
            manager.Stop();
            NumSubscribersChanged = null;
            IsAlive = false;
        }
        
        public string Advertise()
        {
            AssertIsAlive();

            string id = GenerateId();
            ids.Add(id);

#if DEBUG__
            Logger.LogDebug($"{this}: Advertising '{Topic}' with type {TopicType} and id '{id}'");
#endif

            return id;
        }

        bool RemoveId(string topicId)
        {
            if (topicId is null)
            {
                throw new ArgumentNullException(nameof(topicId));
            }

            return ids.Remove(topicId);
        }

        public bool Unadvertise(string id)
        {
            bool removed = RemoveId(id);

            if (ids.Count == 0)
            {
                Stop();
                client.RemovePublisher(this);
            }

            return removed;
        }

        public async Task<bool> UnadvertiseAsync(string id)
        {
            bool removed = RemoveId(id);

            if (ids.Count == 0)
            {
                Stop();
                await client.RemovePublisherAsync(this).Caf();
            }

            return removed;
        }

        public bool ContainsId(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return ids.Contains(id);
        }

        public bool MessageTypeMatches(Type type)
        {
            return type == typeof(T);
        }

        public override string ToString()
        {
            return $"[Publisher {Topic} [{TopicType}] ]";
        }
    }
}