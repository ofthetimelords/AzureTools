#region

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue
    {
        public Task SendAsync(object message) => this.SerializeAndSendAsync(message, null, CancellationToken.None);

        public Task SendAsync(object message, SendOptions options) => this.SerializeAndSendAsync(message, options, CancellationToken.None);


        public Task SendAsync(object message, CancellationToken token) => this.SerializeAndSendAsync(message, null, token);

        public Task SendAsync(object message, SendOptions options, CancellationToken token) => this.SerializeAndSendAsync(message, options, token);


        public Task SendAsync(Stream message) => this.SendAsync(message, null, CancellationToken.None);

        public Task SendAsync(Stream message, SendOptions options) => this.SendAsync(message, options, CancellationToken.None);

        public Task SendAsync(Stream message, CancellationToken token) => this.SendAsync(message, null, token);

        private async Task SerializeAndSendAsync(object message, SendOptions options, CancellationToken token)
        {
            await this.SendAsync(await this.StreamConverter.ToStreamAsync(message, token).ConfigureAwait(false), options, token).ConfigureAwait(false);
        }

        public async Task SendAsync(Stream message, SendOptions options, CancellationToken token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message), "Cannot send an empty message");

            var processed = await this.MessageContentProcessor.ProcessContentAsync(message, token).ConfigureAwait(false);
            var wrapper = await this.MessageFactory.CreateAsync(processed, token).ConfigureAwait(false);

            await this.OriginalQueue.AddMessageAsync(wrapper.OriginalMessage, options, token).ConfigureAwait(false);
        }
    }
}