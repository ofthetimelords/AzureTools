#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public class CloudQueueWrapper : ICloudQueue
    {
        public CloudQueueWrapper(CloudQueue original) => this.Original = original;

        public int? ApproximateMessageCount => this.Original.ApproximateMessageCount;

        public bool EncodeMessage
        {
            get => this.Original.EncodeMessage;
            set => this.Original.EncodeMessage = value;
        }

        public IDictionary<string, string> Metadata => this.Original.Metadata;

        public string Name => this.Original.Name;

        public CloudQueue Original { get; }

        public StorageUri StorageUri => this.Original.StorageUri;

        public Uri Uri => this.Original.Uri;


        public static implicit operator CloudQueue(CloudQueueWrapper wrapper) => wrapper.Original;

        public static implicit operator CloudQueueWrapper(CloudQueue original) => new CloudQueueWrapper(original);

        public void AddMessage(ICloudQueueMessage message, TimeSpan? timeToLive = null, TimeSpan? initialVisibilityDelay = null, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            this.Original.AddMessage(message, timeToLive, initialVisibilityDelay, options, operationContext);
        }

        public Task AddMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken) => this.Original.AddMessageAsync(message, cancellationToken);

        public Task AddMessageAsync(ICloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) =>
            this.Original.AddMessageAsync(message, timeToLive, initialVisibilityDelay, options, operationContext, cancellationToken);

        public void Clear(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task ClearAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void Create(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
        }

        public Task CreateAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public bool CreateIfNotExists(QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void Delete(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public bool DeleteIfExists(QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void DeleteMessage(ICloudQueueMessage message, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(string messageId, string popReceipt, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteMessageAsync(ICloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public bool Exists(QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<bool> ExistsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void FetchAttributes(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task FetchAttributesAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public ICloudQueueMessage GetMessage(TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> GetMessageAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public IEnumerable<ICloudQueueMessage> GetMessages(int messageCount, TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) =>
            throw new NotImplementedException();

        public QueuePermissions GetPermissions(QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<QueuePermissions> GetPermissionsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange) => throw new NotImplementedException();

        public ICloudQueueMessage PeekMessage(QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> PeekMessageAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public IEnumerable<ICloudQueueMessage> PeekMessages(int messageCount, QueueRequestOptions options = null, OperationContext operationContext = null) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void SetMetadata(QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task SetMetadataAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void SetPermissions(QueuePermissions permissions, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task SetPermissionsAsync(QueuePermissions permissions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken) => throw new NotImplementedException();

        public void UpdateMessage(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options = null, OperationContext operationContext = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext,
            CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}