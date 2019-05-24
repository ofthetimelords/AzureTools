#region

using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueFactory : IAutoQueueFactory
    {
        public AutoQueueFactory(IRetryPolicy retryPolicy, IAutoQueueMessageFactory messageFactory, IMessageContentProcessor messageContentProcessor, IStreamConverter converter, ILoggerFactory loggerFactory)
        {
            this.RetryPolicy = retryPolicy;
            this.StreamConverter = converter;
            this.MessageFactory = messageFactory;
            this.MessageContentProcessor = messageContentProcessor;
            this.LoggerFactory = loggerFactory;
        }

        public IRetryPolicy RetryPolicy { get; }

        private IStreamConverter StreamConverter { get; }

        private IAutoQueueMessageFactory MessageFactory { get; }

        private IMessageContentProcessor MessageContentProcessor { get; }

        private ILoggerFactory LoggerFactory { get; }

        /// <summary>
        /// Creates an IAutoQueue implementation.
        /// </summary>
        /// <param name="sourceQueue">The source <see cref="ICloudQueue" />. Use the <see cref="Helpers.Wrap(CloudQueue)" /> extension method to wrap a <see cref="CloudQueue" /> instance.</param>
        /// <returns>
        /// An <see cref="IAutoQueue" /> implementation.
        /// </returns>
        public IAutoQueue Create(ICloudQueue sourceQueue) => new AutoQueue(sourceQueue, this.StreamConverter, this.MessageFactory, this.MessageContentProcessor, this.RetryPolicy, this.LoggerFactory.CreateLogger<AutoQueue>());
    }
}