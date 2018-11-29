#region

using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueFactory : IAutoQueueFactory
    {
        public AutoQueueFactory(IRetryPolicy retryPolicy, ISerializer serializer)
        {
            this.RetryPolicy = retryPolicy;
            this.Serializer = serializer;
        }

        public IRetryPolicy RetryPolicy { get; }

        public ISerializer Serializer { get; }

        /// <summary>
        /// Creates an IAutoQueue implementation.
        /// </summary>
        /// <param name="sourceQueue">The source <see cref="ICloudQueue" />. Use the <see cref="Helpers.Wrap(CloudQueue)" /> extension method to wrap a <see cref="CloudQueue" /> instance.</param>
        /// <returns>
        /// An <see cref="IAutoQueue" /> implementation.
        /// </returns>
        public IAutoQueue Create(ICloudQueue sourceQueue) => new AutoQueue(sourceQueue, this.Serializer, this.RetryPolicy);
    }
}