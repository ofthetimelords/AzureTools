using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public interface ICloudQueue
    {
        int? ApproximateMessageCount { get; }
        bool EncodeMessage { get; set; }
        IDictionary<string, string> Metadata { get; }
        string Name { get; }
        StorageUri StorageUri { get; }
        Uri Uri { get; }

        void AddMessage(ICloudQueueMessage message, TimeSpan? timeToLive = null, TimeSpan? initialVisibilityDelay = null, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task AddMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken);
        Task AddMessageAsync(ICloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void Clear(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task ClearAsync(CancellationToken cancellationToken);
        Task ClearAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void Create(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task CreateAsync(CancellationToken cancellationToken);
        Task CreateAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        bool CreateIfNotExists(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<bool> CreateIfNotExistsAsync(CancellationToken cancellationToken);
        Task<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void Delete(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task DeleteAsync(CancellationToken cancellationToken);
        Task DeleteAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        bool DeleteIfExists(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken);
        Task<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void DeleteMessage(ICloudQueueMessage message, QueueRequestOptions options = null, OperationContext operationContext = null);
        void DeleteMessage(string messageId, string popReceipt, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task DeleteMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken);
        Task DeleteMessageAsync(ICloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        Task DeleteMessageAsync(string messageId, string popReceipt, CancellationToken cancellationToken);
        Task DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        bool Exists(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<bool> ExistsAsync(CancellationToken cancellationToken);
        Task<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void FetchAttributes(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task FetchAttributesAsync(CancellationToken cancellationToken);
        Task FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        ICloudQueueMessage GetMessage(TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<ICloudQueueMessage> GetMessageAsync(CancellationToken cancellationToken);
        Task<ICloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        IEnumerable<ICloudQueueMessage> GetMessages(int messageCount, TimeSpan? visibilityTimeout = null, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, CancellationToken cancellationToken);
        Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        QueuePermissions GetPermissions(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<QueuePermissions> GetPermissionsAsync(CancellationToken cancellationToken);
        Task<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        string GetSharedAccessSignature(SharedAccessQueuePolicy policy);
        string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier);
        string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange);
        ICloudQueueMessage PeekMessage(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<ICloudQueueMessage> PeekMessageAsync(CancellationToken cancellationToken);
        Task<ICloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        IEnumerable<ICloudQueueMessage> PeekMessages(int messageCount, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, CancellationToken cancellationToken);
        Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void SetMetadata(QueueRequestOptions options = null, OperationContext operationContext = null);
        Task SetMetadataAsync(CancellationToken cancellationToken);
        Task SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void SetPermissions(QueuePermissions permissions, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task SetPermissionsAsync(QueuePermissions permissions, CancellationToken cancellationToken);
        Task SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
        void UpdateMessage(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options = null, OperationContext operationContext = null);
        Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, CancellationToken cancellationToken);
        Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);
    }
}