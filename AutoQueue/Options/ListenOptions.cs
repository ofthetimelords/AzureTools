#region

using System;
using System.Threading;
using JetBrains.Annotations;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class ListenOptions : ListenOptionsBase
    {
        public ListenOptions(TimeSpan timeWindow, TimeSpan messageLeaseTime, TimeSpan pollFrequency, int poisonMessageThreshold, CancellationToken cancelToken, [CanBeNull] Action<Exception> exceptionHandler = null) : base(
            timeWindow, messageLeaseTime, pollFrequency, poisonMessageThreshold, cancelToken, exceptionHandler)
        {
        }
    }
}