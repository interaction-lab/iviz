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
    public sealed class RosSubscriber<T> : IRosSubscriber<T> where T : IMessage
    {
        static readonly Action<T, IRosTcpReceiver>[] EmptyCallback = Array.Empty<Action<T, IRosTcpReceiver>>();

        readonly Dictionary<string, Action<T, IRosTcpReceiver>> callbacksById = new();
        readonly CancellationTokenSource runningTs = new();
        readonly RosClient client;
        readonly TcpReceiverManager<T> manager;

        Action<T, IRosTcpReceiver>[] callbacks = EmptyCallback; // cache to iterate through callbacks quickly
        int totalSubscribers;
        bool disposed;

        public bool IsPaused
        {
            get => manager.IsPaused;
            set => manager.IsPaused = value;
        }
        
        public CancellationToken CancellationToken => runningTs.Token;

        /// <summary>
        /// Whether this subscriber is valid.
        /// </summary>
        public bool IsAlive => !CancellationToken.IsCancellationRequested;

        public string Topic => manager.Topic;
        public string TopicType => manager.TopicType;
        public int NumPublishers => manager.NumConnections;
        public int NumActivePublishers => manager.NumActiveConnections;

        public int GetTotalActivePublishers(int timeoutInMs = 500)
        {
            return manager.GetTotalActiveConnections(timeoutInMs);
        }

        public ValueTask<int> GetTotalActivePublishersAsync(CancellationToken token = default)
        {
            return manager.GetTotalActiveConnectionsAsync(token);
        }

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

        internal void MessageCallback(in T msg, IRosTcpReceiver receiver)
        {
            foreach (var callback in callbacks)
            {
                try
                {
                    callback(msg, receiver);
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
                Logger.LogErrorFormat("{0}: Exception from RaiseNumPublishersChanged : {1}", this, e);
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
                throw new ObjectDisposedException("this", "This is not a valid subscriber");
            }
        }

        public SubscriberTopicState GetState()
        {
            AssertIsAlive();
            return new SubscriberTopicState(Topic, TopicType, callbacksById.Keys.ToArray(), manager.GetStates());
        }

        Task IRosSubscriber.PublisherUpdateRcpAsync(IEnumerable<Uri> publisherUris, CancellationToken token)
        {
            return PublisherUpdateRcpAsync(publisherUris, token);
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
            callbacks = EmptyCallback;
            NumPublishersChanged = null;
            manager.Stop();
            runningTs.Dispose();
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
            callbacks = EmptyCallback;
            NumPublishersChanged = null;
            await manager.StopAsync();
            runningTs.Dispose();
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
            callbacksById.Add(id, (t, _) => callback(t));
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
            callbacksById.Add(id, (t, _) => callback(t));
            callbacks = callbacksById.Values.ToArray();
            return id;
        }
        
        public string Subscribe(Action<T, IRosTcpReceiver> callback)
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

        public async ValueTask<bool> UnsubscribeAsync(string id, CancellationToken token = default)
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
            if (callbacksById.Count != 0)
            {
                callbacks = callbacksById.Values.ToArray();
            }
            else
            {
                callbacks = EmptyCallback;
                Task disposeTask = DisposeAsync().AwaitNoThrow(this);
                Task unsubscribeTask = client.RemoveSubscriberAsync(this, token).AwaitNoThrow(this);
                await (disposeTask, unsubscribeTask).WhenAll().Caf();
            }

            return removed;
        }

        internal async Task PublisherUpdateRcpAsync(IEnumerable<Uri> publisherUris, CancellationToken token)
        {
            if (token.IsCancellationRequested || runningTs.IsCancellationRequested)
            {
                return;
            }

            using CancellationTokenSource tokenSource = CancellationTokenSource.CreateLinkedTokenSource(token, runningTs.Token);
            await manager.PublisherUpdateRpcAsync(publisherUris, tokenSource.Token).AwaitNoThrow(this);
        }

        internal void PublisherUpdateRcp(IEnumerable<Uri> publisherUris, CancellationToken token)
        {
            Task.Run( () => PublisherUpdateRcpAsync(publisherUris, token), token).WaitNoThrow(this);
        }

        public override string ToString()
        {
            return $"[Subscriber {Topic} [{TopicType}] ]";
        }
    }
}