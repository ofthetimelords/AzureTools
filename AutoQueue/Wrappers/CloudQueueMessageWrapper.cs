#region

using Microsoft.WindowsAzure.Storage.Queue;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public class CloudQueueMessageWrapper : ICloudQueueMessage
    {
        public CloudQueueMessageWrapper(CloudQueueMessage original) => this.Original = original;

        public CloudQueueMessage Original { get; }


        public static implicit operator CloudQueueMessage(CloudQueueMessageWrapper wrapper) => wrapper.Original;

        public static implicit operator CloudQueueMessageWrapper(CloudQueueMessage original) => new CloudQueueMessageWrapper(original);
    }
}