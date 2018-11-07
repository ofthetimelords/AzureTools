#region

using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IAutoQueueFactory
    {
        IAutoQueue Create(CloudQueue original);
    }
}