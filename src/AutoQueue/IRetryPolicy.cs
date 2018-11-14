using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IRetryPolicy
    {
        Task Do(Func<CancellationToken, Task> action, CancellationToken token);

        Task<T> Do<T>(Func<CancellationToken, Task<T>> action, CancellationToken token);
    }
}
