#region

using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IAutoQueueMessage
    {
        CloudQueueMessage OriginalMessage { get; }

        string MessageId { get; }

        string OffloadMarker { get; }

        T ParseMessage<T>() where T : class;

        Task<T> ParseMessageAsync<T>(CancellationToken token) where T : class;

        Task<T> ParseMessageAsync<T>() where T : class;
    }
}