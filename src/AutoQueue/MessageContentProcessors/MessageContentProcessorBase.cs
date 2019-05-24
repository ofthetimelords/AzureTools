using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheQ.Libraries.AzureTools.AutoQueue.MessageContentProcessors
{
    public class MessageContentProcessorBase : IMessageContentProcessor
    {
        public virtual Task<Stream> ProcessContentAsync(Stream source, CancellationToken token) => Task.FromResult(source);

        public virtual Task<Stream> UnprocessContentAsync(Stream source, CancellationToken token) => Task.FromResult(source);
    }
}
