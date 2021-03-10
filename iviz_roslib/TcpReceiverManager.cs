﻿


using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Iviz.Msgs;
using Iviz.Roslib.XmlRpc;
using Iviz.XmlRpc;
using Nito.AsyncEx;

namespace Iviz.Roslib
{
    internal sealed class TcpReceiverManager<T> where T : IMessage
    {
        const int DefaultTimeoutInMs = 5000;

        readonly AsyncLock mutex = new();
        readonly ConcurrentDictionary<Uri, TcpReceiverAsync<T>> connectionsByUri = new();
        readonly RosClient client;
        readonly RosSubscriber<T> subscriber;
        readonly TopicInfo<T> topicInfo;

        bool isPaused;

        public bool IsPaused
        {
            get => isPaused;
            set
            {
                isPaused = value;
                foreach (var receiver in connectionsByUri.Values)
                {
                    receiver.IsPaused = value;
                }
            }
        }

        public TcpReceiverManager(RosSubscriber<T> subscriber, RosClient client, TopicInfo<T> topicInfo,
            bool requestNoDelay)
        {
            this.subscriber = subscriber;
            this.client = client;
            this.topicInfo = topicInfo;
            RequestNoDelay = requestNoDelay;
        }

        public string Topic => topicInfo.Topic;
        public string TopicType => topicInfo.Type;

        HashSet<Uri> allPublisherUris = new();

        public int NumConnections => connectionsByUri.Count;

        public int NumActiveConnections => connectionsByUri.Count(pair => pair.Value.IsConnected);

        public int GetTotalActiveConnections(int timeoutInMs)
        {
            using CancellationTokenSource tokenSource = new(timeoutInMs);
            return Task.Run(() => GetTotalActiveConnectionsAsync(tokenSource.Token).AsTask(), tokenSource.Token)
                .WaitNoThrow(this);
        }

        public async ValueTask<int> GetTotalActiveConnectionsAsync(CancellationToken token)
        {
            int numActiveConnections = NumActiveConnections;
            if (!NeedsCleanup())
            {
                return numActiveConnections;
            }

            try
            {
                bool numConnectionsChanged;

                using (await mutex.LockAsync(token))
                {
                    numConnectionsChanged = await CleanupAsync();
                }

                if (numConnectionsChanged)
                {
                    subscriber.RaiseNumPublishersChanged();
                }
            }
            catch (OperationCanceledException)
            {
            }

            return numActiveConnections;
        }

        public bool RequestNoDelay { get; }
        public int TimeoutInMs { get; set; } = DefaultTimeoutInMs;

        internal async ValueTask<Endpoint?> RequestConnectionFromPublisherAsync(Uri remoteUri, CancellationToken token)
        {
            NodeClient.RequestTopicResponse response;
            try
            {
                response = await client.CreateTalker(remoteUri).RequestTopicAsync(Topic, token).Caf();
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case OperationCanceledException:
                        return null;
                    case TimeoutException:
                    case XmlRpcException:
                    case SocketException:
                    case IOException:
                        Logger.LogDebugFormat("{0}: Connection request to publisher {1} failed: {2}",
                            this, remoteUri, e);
                        return null;
                    default:
                        Logger.LogErrorFormat("{0}: Connection request to publisher {1} failed: {2}",
                            this, remoteUri, e);
                        return null;
                }
            }

            if (!response.IsValid || response.Protocol == null)
            {
                Logger.LogDebugFormat("{0}: Connection request to publisher {1} failed: {2}",
                    this, remoteUri, response.StatusMessage);
                return null;
            }

            if (response.Protocol.Port == 0)
            {
                Logger.LogErrorFormat("{0}: Connection request to publisher {1} returned an uninitialized address!",
                    this, remoteUri);
                return null;
            }

            return new Endpoint(response.Protocol.Hostname, response.Protocol.Port);
        }

        internal void MessageCallback(in T msg, IRosTcpReceiver receiver)
        {
            subscriber.MessageCallback(msg, receiver);
        }

        async ValueTask<bool> AddPublisherAsync(Uri remoteUri, CancellationToken token)
        {
            try
            {
                Endpoint? remoteEndpoint = await RequestConnectionFromPublisherAsync(remoteUri, token).Caf();
                CreateConnection(remoteEndpoint, remoteUri);
                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception e)
            {
                Logger.LogErrorFormat("{0}: Connection request to publisher {1} returned an unexpected exception: {2}",
                    this, remoteUri, e);
                return false;
            }
        }

        void CreateConnection(Endpoint? remoteEndpoint, Uri remoteUri)
        {
            TcpReceiverAsync<T> connection =
                new(this, remoteUri, remoteEndpoint, topicInfo, RequestNoDelay) {IsPaused = IsPaused};

            connectionsByUri[remoteUri] = connection;
            connection.Start(TimeoutInMs);
        }

        public async Task PublisherUpdateRpcAsync(IEnumerable<Uri> publisherUris, CancellationToken token)
        {
            bool numConnectionsChanged;

            using (await mutex.LockAsync(token))
            {
                HashSet<Uri> newPublishers = new(publisherUris);
                allPublisherUris = newPublishers;

                IEnumerable<Uri> toAdd = newPublishers.Where(uri => uri != null && !connectionsByUri.ContainsKey(uri));

                TcpReceiverAsync<T>[] toDelete = connectionsByUri
                    .Where(pair => !newPublishers.Contains(pair.Key))
                    .Select(pair => pair.Value)
                    .ToArray();

                var deleteTasks = toDelete.Select(receiver => receiver.DisposeAsync());
                await deleteTasks.WhenAll().AwaitNoThrow(this).Caf();

                var addTasks = toAdd.Select(uri => AddPublisherAsync(uri, token).AsTask());
                bool[]? results = await addTasks.WhenAll().AwaitNoThrow(this).Caf();
                numConnectionsChanged = (results != null && results.Any(b => b)) | await CleanupAsync();
            }

            if (numConnectionsChanged)
            {
                subscriber.RaiseNumPublishersChanged();
            }
        }

        bool NeedsCleanup()
        {
            return connectionsByUri.Values.Any(receiver => !receiver.IsAlive);
        }

        async ValueTask<bool> CleanupAsync()
        {
            TcpReceiverAsync<T>[] toDelete = connectionsByUri.Values.Where(receiver => !receiver.IsAlive).ToArray();
            if (toDelete.Length == 0)
            {
                return false;
            }

            var tasks = toDelete.Select(receiver =>
            {
                connectionsByUri.TryRemove(receiver.RemoteUri, out _);
                Logger.LogDebugFormat("{0}: Removing connection with '{1}' - dead x_x", this, receiver.RemoteUri);
                return receiver.DisposeAsync();
            });

            await tasks.WhenAll().AwaitNoThrow(this).Caf();

            return true;
        }

        public void Stop()
        {
            Task.Run(StopAsync).WaitNoThrow(this);
        }

        public async Task StopAsync()
        {
            using (await mutex.LockAsync())
            {
                await connectionsByUri.Values.Select(receiver => receiver.DisposeAsync()).WhenAll();
                connectionsByUri.Clear();
                subscriber.RaiseNumPublishersChanged();
            }
        }

        public ReadOnlyCollection<SubscriberReceiverState> GetStates()
        {
            var publisherUris = allPublisherUris;
            var alivePublishers = connectionsByUri.Values.Select(receiver => receiver.State);
            var missingPublishers = publisherUris
                .Where(uri => !connectionsByUri.ContainsKey(uri))
                .Select(uri => new SubscriberReceiverState(uri));

            return alivePublishers.Concat(missingPublishers).ToList().AsReadOnly();
        }

        public override string ToString()
        {
            return $"[TcpReceiverManager '{Topic}']";
        }
    }
}