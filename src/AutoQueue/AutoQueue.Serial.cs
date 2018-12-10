using System;
using System.Threading.Tasks;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

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
                catch (Exception ex)
                {
                }
            }
        }
    }
}
