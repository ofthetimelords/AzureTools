#region

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

        public IAutoQueue Create(ICloudQueue sourceQueue) => new AutoQueue(sourceQueue, this.Serializer, this.RetryPolicy);
    }
}