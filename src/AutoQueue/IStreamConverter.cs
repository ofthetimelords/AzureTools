using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface IStreamConverter
    {
        Task<Stream> ToStreamAsync(object source, CancellationToken token);

        Task<T> FromStreamAsync<T>(Stream source, CancellationToken token);
    }
}
