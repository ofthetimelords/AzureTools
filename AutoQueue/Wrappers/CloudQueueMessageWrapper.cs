#region

using System;
using Microsoft.WindowsAzure.Storage.Queue;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public class CloudQueueMessageWrapper : ICloudQueueMessage
    {
        public CloudQueueMessageWrapper(CloudQueueMessage original) => this.Original = original;

        public byte[] AsBytes => this.Original.AsBytes;

        public string AsString => this.Original.AsString;

        public int DequeueCount => this.Original.DequeueCount;

        public DateTimeOffset? ExpirationTime => this.Original.ExpirationTime;

        public string Id => this.Original.Id;

        public DateTimeOffset? InsertionTime => this.Original.InsertionTime;

        public DateTimeOffset? NextVisibleTime => this.Original.NextVisibleTime;

        public CloudQueueMessage Original { get; }

        public string PopReceipt => this.Original.PopReceipt;

        public void SetMessageContent(byte[] content)
        {
            this.Original.SetMessageContent(content);
        }

        public void SetMessageContent(string content)
        {
            this.Original.SetMessageContent(content);
        }

        public static implicit operator CloudQueueMessage(CloudQueueMessageWrapper message) => message.Original;

        public static implicit operator CloudQueueMessageWrapper(CloudQueueMessage message) => new CloudQueueMessageWrapper(message);
    }
}