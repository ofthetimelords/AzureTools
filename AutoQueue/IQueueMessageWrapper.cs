#region

using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IQueueMessageWrapper
    {
        CloudQueueMessage OriginalMessage { get; }

        T ParseMessage<T>() where T : class;

        Task<T> ParseMessageAsync<T>(CancellationToken token) where T : class;

        Task<T> ParseMessageAsync<T>() where T : class;
    }
}