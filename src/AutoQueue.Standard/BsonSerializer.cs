using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard
{
    public class BsonSerializer : ISerializer
    {
        public async Task<byte[]> SerializeAsync(object source, CancellationToken token)
        {
            using (var ms = new MemoryStream())
            using (var mw = new BsonDataWriter(ms))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(mw, source);

                await mw.FlushAsync(token);
                return ms.ToArray();
            }
        }

        public Task<T> DeserializeAsync<T>(byte[] source, CancellationToken token)
        {
            using (var ms = new MemoryStream(source))
            using (var mr = new BsonDataReader(ms))
            {
                var deserializer = new JsonSerializer();

                return Task.FromResult(deserializer.Deserialize<T>(mr));
            }
        }
    }
}