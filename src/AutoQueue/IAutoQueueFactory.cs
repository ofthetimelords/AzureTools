#region

using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    /// <summary>
    /// Allows for easy creation of <see cref="IAutoQueue"/> implementations in IoC scenarios.
    /// </summary>
    public interface IAutoQueueFactory
    {
        /// <summary>
        /// Creates an IAutoQueue implementation.
        /// </summary>
        /// <param name="sourceQueue">The source <see cref="ICloudQueue"/>. Use the <see cref="Helpers.Wrap(CloudQueue)"/> extension method to wrap a <see cref="CloudQueue"/> instance.</param>
        /// <returns>An <see cref="IAutoQueue"/> implementation.</returns>
        IAutoQueue Create(ICloudQueue sourceQueue);
    }
}