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
    public class BsonStreamConverter : IStreamConverter
    {
        public async Task<Stream> ToStreamAsync(object source, CancellationToken token)
        {
            // TODO: MemoryStream here is an assumption. Investigate how it could be removed
            using (var ms = new MemoryStream())
            using (var mw = new BsonDataWriter(ms))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(mw, source);

                await mw.FlushAsync(token);
                ms.Seek(0, SeekOrigin.Begin);
                return ms;
            }
        }

        public Task<T> FromStreamAsync<T>(Stream source, CancellationToken token)
        {
            using (var mr = new BsonDataReader(source))
            {
                var deserializer = new JsonSerializer();

                return Task.FromResult(deserializer.Deserialize<T>(mr));
            }
        }
    }
}