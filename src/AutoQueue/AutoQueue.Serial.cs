using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;
using TheQ.Libraries.AzureTools.Common.Exceptions;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue
    {
        /// <exception cref="NotImplementedException">In progress.</exception>
        public async Task ListenAsync(ListenOptions options)
        {
            await this.EnsureQueueExists(options).ConfigureAwait(false);


            while (!options.CancelToken.IsCancellationRequested)
            {
                var originalMessage = await this.RetryPolicy.Do(token => this.OriginalQueue.GetMessageAsync(options.InvisibilityPeriod, options.RequestOptions, options.CancelToken), options.CancelToken).ConfigureAwait(false);

                if (originalMessage == null)
                {
                    await Task.Delay(options.PollFrequency).ConfigureAwait(false);
                    continue;
                }

                try
                {
                    var message = new AutoQueueMessage(originalMessage);

                    await options.MessageHandler(message).ConfigureAwait(false);
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
