#region

using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class ListenOptions : ListenOptionsBase
    {
        public ListenOptions(
            TimeSpan timeWindow,
            TimeSpan messageLeaseTime,
            TimeSpan pollFrequency,
            int poisonMessageThreshold,
            CancellationToken cancelToken,
            [NotNull] Func<IAutoQueueMessage, Task<bool>> messageHandler,
            [CanBeNull] Func<IAutoQueueMessage, Task<bool>> poisonHandler = null,
            [CanBeNull] Action<Exception> exceptionHandler = null)
            : base(timeWindow, messageLeaseTime, pollFrequency, poisonMessageThreshold, cancelToken, exceptionHandler)

        {
            this.MessageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler), "The Message Handler delegate is required");
            this.PoisonHandler = poisonHandler;
        }



        [NotNull]
        public Func<IAutoQueueMessage, Task<bool>> MessageHandler { get; }


        [CanBeNull]
        public Func<IAutoQueueMessage, Task<bool>> PoisonHandler { get; }
    }
}