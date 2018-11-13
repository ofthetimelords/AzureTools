#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue : IAutoQueue
    {
        /// <exception cref="NotImplementedException">In progress.</exception>
        public void SendMessage<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public void SendMessage<T>(T message, RequestOptions options) where T : class
        {
            throw new NotImplementedException();
        }

        /// <exception cref="NotImplementedException">In progress.</exception>
        public Task SendMessageAsync<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync<T>(T message, RequestOptions options) where T : class => throw new NotImplementedException();

        /// <exception cref="NotImplementedException">In progress.</exception>
        public Task SendMessageAsync<T>(T message, CancellationToken token) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync<T>(T message, RequestOptions options, CancellationToken token) where T : class => throw new NotImplementedException();
    }
}