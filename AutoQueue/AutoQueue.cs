#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue : IAutoQueue
    {
        public AutoQueue(CloudQueue sourceQueue) => this.OriginalQueue = sourceQueue ?? throw new ArgumentNullException(nameof(sourceQueue), $"Parameter {nameof(sourceQueue)} is required");


        public CloudQueue OriginalQueue { get; }
    }
}