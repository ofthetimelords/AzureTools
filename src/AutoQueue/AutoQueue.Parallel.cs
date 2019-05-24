#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue
    {
        public async Task ListenParallelAsync(ListenParallelOptions options)
        {
            await this.EnsureQueueExists(options).ConfigureAwait(false);


            while (!options.CancelToken.IsCancellationRequested)
            {
                var originalMessage = await this.RetryPolicy.Do(token => this.OriginalQueue.GetMessageAsync(options.InvisibilityPeriod, options.RequestOptions, options.CancelToken), options.CancelToken).ConfigureAwait(false);
                long[] activeSlotsCounter = {0};

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
                catch (Exception ex)
                {
                    // Failures should not cause the loop to exit.
                }
            }
        }
    }
}