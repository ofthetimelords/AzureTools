#region

using System.Threading;
using System.Threading.Tasks;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IAutoQueueMessage
    {
        ICloudQueueMessage OriginalMessage { get; }

        string MessageId { get; }

        byte[] OffloadMarker { get; }

        T ReadMessage<T>() where T : class;

        Task<T> ReadMessageAsync<T>(CancellationToken token) where T : class;

        Task<T> ReadMessageAsync<T>() where T : class;
    }
}