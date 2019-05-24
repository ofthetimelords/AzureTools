#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    /// <summary>
    /// An AutoQueue, which supports automatic message lifetime handling and offloading capabilities.
    /// </summary>
    /// <seealso cref="TheQ.Libraries.AzureTools.AutoQueue.IAutoQueue" />
    public partial class AutoQueue : IAutoQueue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoQueue" /> class.
        /// </summary>
        /// <param name="sourceQueue">The source <see cref="ICloudQueue" /> method. Use <see cref="Helpers.Wrap(CloudQueue)" /> on an existing <see cref="CloudQueue" /> in order to pass it as a parameter.</param>
        /// <param name="messageSerializer">The <see cref="ISerializer"/> that will be used for message (de)serialization.</param>
        /// <exception cref="System.ArgumentNullException">sourceQueue - Parameter {nameof(sourceQueue)}</exception>
        /// <exception cref="ArgumentNullException">Parameter sourceQueue is required.</exception>
        public AutoQueue(ICloudQueue sourceQueue, IStreamConverter converter, IAutoQueueMessageFactory messageFactory, IMessageContentProcessor messageContentProcessor, IRetryPolicy retryPolicy, ILogger<AutoQueue> logger)
        {
            this.OriginalQueue = sourceQueue ?? throw new ArgumentNullException(nameof(sourceQueue), $"Parameter {nameof(sourceQueue)} is required");
            this.StreamConverter = converter;
            this.MessageFactory = messageFactory;
            this.MessageContentProcessor = messageContentProcessor;
            this.RetryPolicy = retryPolicy;
            this.Logger = logger;
        }


        /// <summary>
        /// Gets the original <see cref="ICloudQueue"/> that backs this instance.
        /// </summary>
        public ICloudQueue OriginalQueue { get; }

        private IStreamConverter StreamConverter { get; }

        private IAutoQueueMessageFactory MessageFactory { get; }

        private IMessageContentProcessor MessageContentProcessor { get; }

        private IRetryPolicy RetryPolicy { get; }

        private ILogger<AutoQueue> Logger { get; }


        private Task EnsureQueueExists(ListenOptionsBase options)
        {
            return this.RetryPolicy.Do(token => options.SkipQueueExistsCheck
                ? Task.CompletedTask
                : this.OriginalQueue.CreateIfNotExistsAsync(options.RequestOptions, options.CancelToken), options.CancelToken);
        }
    }
}