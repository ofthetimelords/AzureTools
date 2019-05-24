using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IMessageContentProcessor
    {
        Task<Stream> ProcessContentAsync(Stream source, CancellationToken token);
        Task<Stream> UnprocessContentAsync(Stream source, CancellationToken token);
    }
}