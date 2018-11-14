using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies
{
    public interface IRetryStrategy
    {
        Task AwaitRetry(int retriesSoFar, CancellationToken token);
    }
}
