﻿#region

using System;
using System.Threading;
using JetBrains.Annotations;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public abstract class ListenOptionsBase
    {
        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="ListenOptionsBase" /></para>
        ///     <para>class.</para>
        /// </summary>
        /// <param name="timeWindow">
        ///     <para>The time window within which a message is still valid for processing (older messages will be discarded). Use <see cref="System.TimeSpan.Zero" /></para>
        ///     <para>to ignore this check.</para>
        /// </param>
        /// <param name="messageLeaseTime">The amount of time between periodic refreshes on the lease of a message.</param>
        /// <param name="pollFrequency">The frequency with which the queue is being polled for new messages.</param>
        /// <param name="poisonMessageThreshold">The amount of times a message can be enqueued.</param>
        /// <param name="cancelToken">A cancellation token to allow cancellation of this process.</param>
        /// <param name="exceptionHandler">An action that specifies how an exception should be handled.</param>
        /// <exception cref="ArgumentException">
        ///     Message Lease Time cannot be lower than 30 seconds! or Poll Frequency cannot be lower than 1 second! or Poison Message Threshold cannot be lower than 1
        /// </exception>
        protected ListenOptionsBase(
            TimeSpan timeWindow,
            TimeSpan messageLeaseTime,
            TimeSpan pollFrequency,
            int poisonMessageThreshold,
            CancellationToken cancelToken,
            [CanBeNull] Action<Exception> exceptionHandler = null)
        {
            if (messageLeaseTime.TotalSeconds < TimeSpan.FromSeconds(30).TotalSeconds) throw new ArgumentException("Message Lease Time cannot be lower than 30 seconds!");

            if (pollFrequency.TotalSeconds < TimeSpan.FromSeconds(1).TotalSeconds) throw new ArgumentException("Poll Frequency cannot be lower than 1 second!");

            if (poisonMessageThreshold < 1) throw new ArgumentException("Poison Message Threshold cannot be lower than 1");

            this.TimeWindow = timeWindow;
            this.MessageLeaseTime = messageLeaseTime;
            this.PollFrequency = pollFrequency;
            this.PoisonMessageThreshold = poisonMessageThreshold;
            this.CancelToken = cancelToken;
            this.ExceptionHandler = exceptionHandler;
        }


        /// <summary>
        ///     A cancellation token to allow cancellation of this process.
        /// </summary>
        public CancellationToken CancelToken { get; }


        /// <summary>
        ///     An action that specifies how an exception should be handled.
        /// </summary>
        [CanBeNull]
        public Action<Exception> ExceptionHandler { get; }


        /// <summary>
        ///     The amount of time between periodic refreshes on the lease of a message.
        /// </summary>
        public TimeSpan MessageLeaseTime { get; }


        /// <summary>
        ///     The amount of times a message can be enqueued.
        /// </summary>
        public int PoisonMessageThreshold { get; }


        /// <summary>
        ///     The frequency with which the queue is being polled for new messages.
        /// </summary>
        public TimeSpan PollFrequency { get; }


        /// <summary>
        ///     The time window within which a message is still valid for processing (older messages will be discarded).
        /// </summary>
        public TimeSpan TimeWindow { get; }
    }
}