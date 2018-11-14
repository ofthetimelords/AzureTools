﻿#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class ListenBatchOptions : ListenOptionsBase
    {
        public ListenBatchOptions(
            TimeSpan invisibilityPeriod,
            TimeSpan messageLeaseTime,
            TimeSpan pollFrequency,
            int poisonMessageThreshold,
            int maximumCurrentMessages,
            CancellationToken cancelToken,
            [NotNull] Func<IList<IAutoQueueMessage>, Task<IList<IAutoQueueMessage>>> messageHandler,
            [CanBeNull] Func<IList<IAutoQueueMessage>, Task<IList<IAutoQueueMessage>>> poisonHandler = null,
            [CanBeNull] Action<Exception> exceptionHandler = null) : base(invisibilityPeriod, messageLeaseTime, pollFrequency, poisonMessageThreshold, cancelToken, exceptionHandler)

        {
            this.MessageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler), "The Message Handler delegate is required");
            this.MaximumCurrentMessages = maximumCurrentMessages;
            this.PoisonHandler = poisonHandler;
        }



        [NotNull]
        public Func<IList<IAutoQueueMessage>, Task<IList<IAutoQueueMessage>>> MessageHandler { get; }


        [CanBeNull]
        public Func<IList<IAutoQueueMessage>, Task<IList<IAutoQueueMessage>>> PoisonHandler { get; }


        public int MaximumCurrentMessages { get; }
    }
}