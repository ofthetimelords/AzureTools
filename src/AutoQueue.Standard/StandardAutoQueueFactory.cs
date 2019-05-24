#region

using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.MessageContentProcessors;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard
{
    /// <summary>
    /// An implementation of <see cref="IAutoQueueFactory"/> that allows working with AutoQueues using popular dependencies.
    /// </summary>
    /// <seealso cref="TheQ.Libraries.AzureTools.AutoQueue.IAutoQueueFactory" />
    public class StandardAutoQueueFactory : AutoQueueFactory
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StandardAutoQueueFactory" /> class.
        /// </summary>
        public StandardAutoQueueFactory(IRetryPolicy retryPolicy, ILoggerFactory loggerFactory) 
            : base(retryPolicy, new AutoQueueMessageFactory(), new MessageContentProcessorBase(), new BsonStreamConverter(), loggerFactory)
        {
        }
    }
}