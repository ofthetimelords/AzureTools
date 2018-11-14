using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies
{
    public class LinearRetryStrategy : IRetryStrategy
    {
        public TimeSpan InitialRetryWait { get; }
        public TimeSpan RetryDelta { get; }
        
        public LinearRetryStrategy(TimeSpan initialRetryWait, TimeSpan retryDelta)
        {
            this.InitialRetryWait = initialRetryWait;
            this.RetryDelta = retryDelta;
        }

        public Task AwaitRetry(int retriesSoFar, CancellationToken token) => Task.Delay(this.InitialRetryWait.Add(TimeSpan.FromSeconds(RetryDelta.TotalSeconds * retriesSoFar)), token);
    }
}
