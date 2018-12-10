#region

using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard
{
    /// <summary>
    /// An implementation of <see cref="IAutoQueueFactory"/> that allows working with AutoQueues without any configuration.
    /// </summary>
    /// <seealso cref="TheQ.Libraries.AzureTools.AutoQueue.IAutoQueueFactory" />
    public class SimpleAutoQueueFactory : StandardAutoQueueFactory
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SimpleAutoQueueFactory" /> class.
        /// </summary>
        public SimpleAutoQueueFactory() : base(new SimpleRetryPolicy(10, true, new LinearRetryStrategy(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(0.9))), new NullLoggerFactory())
        {
        }
    }
}