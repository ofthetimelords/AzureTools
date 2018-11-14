using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies
{
    public class StaticRetryStrategy : IRetryStrategy
    {
        public TimeSpan TimeBetweenRetries { get; }

        public StaticRetryStrategy(TimeSpan timeBetweenRetries) => this.TimeBetweenRetries = timeBetweenRetries;

        public Task AwaitRetry(int retriesSoFar, CancellationToken token) => Task.Delay(this.TimeBetweenRetries, token);
    }
}
