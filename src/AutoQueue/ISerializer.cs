using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface ISerializer
    {
        Task<byte[]> SerializeAsync(object source, CancellationToken token);

        Task<T> DeserializeAsync<T>(byte[] source, CancellationToken token);
    }
}
