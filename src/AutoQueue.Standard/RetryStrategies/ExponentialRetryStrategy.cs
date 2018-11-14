using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies
{
    public class ExponentialRetryStrategy : IRetryStrategy
    {
        public TimeSpan InitialRetryWait { get; }
        public double DeltaBase { get; }
        public double DeltaExponent { get; }
        public TimeSpan RetryDelta { get; }

        public ExponentialRetryStrategy(TimeSpan initialRetryWait, double deltaBase, double deltaExponent)
        {
            this.InitialRetryWait = initialRetryWait;
            this.DeltaBase = deltaBase;
            this.DeltaExponent = deltaExponent;
        }

        public Task AwaitRetry(int retriesSoFar, CancellationToken token) => Task.Delay(this.InitialRetryWait.Add(TimeSpan.FromSeconds(RetryDelta.TotalSeconds * Math.Pow(this.DeltaBase, this.DeltaExponent))), token);
    }
}
