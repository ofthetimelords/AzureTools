#region

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    /// <summary>
    /// An AutoQueue implementation.
    /// </summary>
    public interface IAutoQueue
    {
        /// <summary>
        /// Gets the original <see cref="ICloudQueue"/> that backs this instance.
        /// </summary>
        ICloudQueue OriginalQueue { get; }

        Task ListenAsync(ListenOptions options);

        Task ListenBatchAsync(ListenBatchOptions options);

        Task ListenParallelAsync(ListenParallelOptions options);

        Task SendAsync(object message);

        Task SendAsync(object message, SendOptions options);

        Task SendAsync(object message, CancellationToken token);

        Task SendAsync(object message, SendOptions options, CancellationToken token);

        Task SendAsync(Stream message);

        Task SendAsync(Stream message, SendOptions options);

        Task SendAsync(Stream message, CancellationToken token);

        Task SendAsync(Stream message, SendOptions options, CancellationToken token);
    }
}