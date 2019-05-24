using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IAutoQueueMessageFactory
    {
        Task<IAutoQueueMessage> CreateAsync(Stream messageContent, CancellationToken token);
    }
}