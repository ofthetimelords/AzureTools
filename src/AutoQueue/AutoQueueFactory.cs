#region

using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueFactory : IAutoQueueFactory
    {
        public AutoQueueFactory(IRetryPolicy retryPolicy, ISerializer serializer, ILoggerFactory loggerFactory)
        {
            this.RetryPolicy = retryPolicy;
            this.Serializer = serializer;
            this.LoggerFactory = loggerFactory;
        }

        public IRetryPolicy RetryPolicy { get; }

        private ISerializer Serializer { get; }

        private ILoggerFactory LoggerFactory { get; }

        /// <summary>
        /// Creates an IAutoQueue implementation.
        /// </summary>
        /// <param name="sourceQueue">The source <see cref="ICloudQueue" />. Use the <see cref="Helpers.Wrap(CloudQueue)" /> extension method to wrap a <see cref="CloudQueue" /> instance.</param>
        /// <returns>
        /// An <see cref="IAutoQueue" /> implementation.
        /// </returns>
        public IAutoQueue Create(ICloudQueue sourceQueue) => new AutoQueue(sourceQueue, this.Serializer, this.RetryPolicy, this.LoggerFactory.CreateLogger<AutoQueue>());
    }
}