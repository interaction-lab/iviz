﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Iviz.Msgs;
using Iviz.XmlRpc;

namespace Iviz.Roslib
{
    /// <summary>
    /// Manager for a subscription to a ROS topic.
    /// </summary>
    public class RosSubscriber<T> : IRosSubscriber<T> where T : IMessage
    {
        readonly Dictionary<string, Action<T>> callbacksById = new Dictionary<string, Action<T>>();
        readonly CancellationTokenSource runningTs = new CancellationTokenSource();
        readonly RosClient client;
        readonly TcpReceiverManager<T> manager;

        Action<T>[] callbacks = Array.Empty<Action<T>>(); // cache to iterate through callbacks quickly
        int totalSubscribers;
        bool disposed;

        public CancellationToken CancellationToken => runningTs.Token; 

        /// <summary>
        /// Whether this subscriber is valid.
        /// </summary>
        public bool IsAlive => !CancellationToken.IsCancellationRequested;
        
        public string Topic => manager.Topic;
        public string TopicType => manager.TopicType;
        public int NumPublishers => manager.NumConnections;

        /// <summary>
        /// The number of ids generated by this subscriber.
        /// </summary>
        public int NumIds => callbacksById.Count;

        /// <summary>
        /// Whether the TCP_NODELAY flag was requested.
        /// </summary>
        public bool RequestNoDelay => manager.RequestNoDelay;

        /// <summary>
        /// Event triggered when a new publisher appears.
        /// </summary>
        public event Action<RosSubscriber<T>>? NumPublishersChanged;

        public int TimeoutInMs
        {
            get => manager.TimeoutInMs;
            set => manager.TimeoutInMs = value;
        }

        internal RosSubscriber(RosClient client, TopicInfo<T> topicInfo, bool requestNoDelay, int timeoutInMs)
        {
            this.client = client;
            manager = new TcpReceiverManager<T>(this, client, topicInfo, requestNoDelay)
                {TimeoutInMs = timeoutInMs};
        }

        internal void MessageCallback(in T msg)
        {
            foreach (Action<T> callback in callbacks)
            {
                try
                {
                    callback(msg);
                }
                catch (Exception e)
                {
                    Logger.LogErrorFormat("{0}: Exception from callback : {1}", this, e);
                }
            }
        }

        internal void RaiseNumPublishersChanged()
        {
            try
            {
                NumPublishersChanged?.Invoke(this);
            }
            catch (Exception e)
            {
                Logger.Log(e);
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

        public SubscriberTopicState GetState()
        {
            AssertIsAlive();
            return new SubscriberTopicState(Topic, TopicType, callbacksById.Keys.ToArray(), manager.GetStates());
        }

        async Task IRosSubscriber.PublisherUpdateRcpAsync(IEnumerable<Uri> publisherUris, CancellationToken token)
        {
            await PublisherUpdateRcpAsync(publisherUris, token).Caf();
        }

        /// <summary>
        /// Disposes this subscriber. This should only be called by RosClient.
        /// </summary>
        void IDisposable.Dispose()
        {
            Dispose();
        }

        void Dispose()
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            runningTs.Cancel();
            callbacksById.Clear();
            manager.Stop();
            callbacks = Array.Empty<Action<T>>();
            NumPublishersChanged = null;
        }

        public async Task DisposeAsync()
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            runningTs.Cancel();
            callbacksById.Clear();
            await manager.StopAsync();
            callbacks = Array.Empty<Action<T>>();
            NumPublishersChanged = null;
        }

        public bool MessageTypeMatches(Type type)
        {
            return type == typeof(T);
        }

        string IRosSubscriber.Subscribe(Action<IMessage> callback)
        {
            if (callback is null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            AssertIsAlive();

            string id = GenerateId();
            callbacksById.Add(id, t => callback(t));
            callbacks = callbacksById.Values.ToArray();
            return id;
        }

        /// <summary>
        /// Generates a new subscriber id with the given callback function.
        /// </summary>
        /// <param name="callback">The function to call when a message arrives.</param>
        /// <typeparam name="T">The message type</typeparam>
        /// <returns>The subscribed id.</returns>
        /// <exception cref="ArgumentNullException">The callback is null.</exception>
        public string Subscribe(Action<T> callback)
        {
            if (callback is null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            
            AssertIsAlive();

            string id = GenerateId();
            callbacksById.Add(id, callback);
            callbacks = callbacksById.Values.ToArray();
            return id;
        }

        public bool ContainsId(string id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return callbacksById.ContainsKey(id);
        }

        public bool Unsubscribe(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (!IsAlive)
            {
                return true;
            }

            bool removed = callbacksById.Remove(id);
            callbacks = callbacksById.Values.ToArray();

            if (callbacksById.Count == 0)
            {
                Dispose();
                client.RemoveSubscriber(this);
            }

            return removed;
        }

        public async Task<bool> UnsubscribeAsync(string id, CancellationToken token = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (!IsAlive)
            {
                return true;
            }
            
            bool removed = callbacksById.Remove(id);
            callbacks = callbacksById.Values.ToArray();

            if (callbacksById.Count == 0)
            {
                await DisposeAsync().AwaitNoThrow(this);
                await client.RemoveSubscriberAsync(this, token).AwaitNoThrow(this);
            }

            return removed;
        }

        internal async Task PublisherUpdateRcpAsync(IEnumerable<Uri> publisherUris, CancellationToken token = default)
        {
            token.ThrowIfCancellationRequested();
            await manager.PublisherUpdateRpcAsync(publisherUris).Caf(); // todo: get token in here
        }
        
        internal void PublisherUpdateRcp(IEnumerable<Uri> publisherUris)
        {
            Task.Run(async () => await PublisherUpdateRcpAsync(publisherUris).Caf()).Wait();
        }

        public override string ToString()
        {
            return $"[Subscriber {Topic} [{TopicType}] ]";
        }
    }
}