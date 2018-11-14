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
    public partial class AutoQueue    {
        public Task SendMessageAsync(object message) => this.SendMessageAsync(message, null, CancellationToken.None);

        public Task SendMessageAsync(object message, RequestOptions options) => throw new NotImplementedException();

        public Task SendMessageAsync(object message, CancellationToken token) => this.SendMessageAsync(message, null, token);

        public Task SendMessageAsync(object message, RequestOptions options, CancellationToken token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message), "Cannot send an empty message");

            throw new NotImplementedException();
        }
    }
}