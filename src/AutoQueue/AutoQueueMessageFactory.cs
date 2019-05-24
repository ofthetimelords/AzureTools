using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueMessageFactory : IAutoQueueMessageFactory
    {
        public async Task<IAutoQueueMessage> CreateAsync(Stream messageContent, CancellationToken token)
        {
            byte[] buffer;

            if (messageContent is MemoryStream ms)
                buffer = ms.ToArray();
            else
            {
                buffer = new byte[messageContent.Length];

                await messageContent.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
            }

            return new AutoQueueMessage(new CloudQueueMessageWrapper(new CloudQueueMessage(buffer)));
        }
    }
}
