using System;
using System.Threading;
using System.Threading.Tasks;
using Iviz.Msgs;
using JetBrains.Annotations;

namespace Iviz.Displays
{
    public interface IExternalServiceProvider
    {
        Task<bool> CallServiceAsync<T>([NotNull] string service, [NotNull] T srv, CancellationToken token) where T : IService;
     }
}