#region

using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class ListenParallelOptions : ListenOptions
    {
        public ListenParallelOptions(
            TimeSpan invisibilityPeriod,
            TimeSpan messageLeaseTime,
            TimeSpan pollFrequency,
            int poisonMessageThreshold,
            int maximumCurrentMessages,
            CancellationToken cancelToken,
            [NotNull] Func<IAutoQueueMessage, Task<bool>> messageHandler,
            [CanBeNull] Func<IAutoQueueMessage, Task<bool>> poisonHandler = null,
            [CanBeNull] Action<Exception> exceptionHandler = null)
            : base(invisibilityPeriod, messageLeaseTime, pollFrequency, poisonMessageThreshold, cancelToken, messageHandler, poisonHandler, exceptionHandler) => this.MaximumCurrentMessages = maximumCurrentMessages;

        public int MaximumCurrentMessages { get; }
    }
}