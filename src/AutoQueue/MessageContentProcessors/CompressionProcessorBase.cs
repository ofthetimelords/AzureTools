using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace TheQ.Libraries.AzureTools.AutoQueue.MessageContentProcessors
{
    public class CompressionProcessorBase : MessageContentProcessorBase
    {
        public Stream ProcessContent(Stream source)
        {
            if (source == null)
                return null;

            using (var ds = new DeflateStream(source, CompressionLevel.Optimal, true))
                return ds;
        }

        public Stream UnprocessContent(Stream source)
        {
            using (var ds = new DeflateStream(source, CompressionMode.Decompress, true))
                return ds;
        }
    }
}
