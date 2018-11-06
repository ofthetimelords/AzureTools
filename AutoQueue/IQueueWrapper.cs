#region

using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IQueueWrapper
    {
        CloudQueue OriginalQueue { get; }

        Task ListenAsync(ListenOptions options);

        Task ListenBatchAsync(ListenBatchOptions options);

        Task ListenParallelAsync(ListenParallelOptions options);

        void SendMessage<T>(T message) where T : class;

        Task SendMessageAsync<T>(T message) where T : class;

        Task SendMessageAsync<T>(T message, CancellationToken token) where T : class;
    }
}