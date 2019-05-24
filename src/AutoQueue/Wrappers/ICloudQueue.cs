#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public interface ICloudQueue
    {
        int? ApproximateMessageCount { get; }

        bool EncodeMessage { get; set; }

        IDictionary<string, string> Metadata { get; }

        string Name { get; }

        CloudQueue Original { get; }

        StorageUri StorageUri { get; }

        Uri Uri { get; }
        
        Task AddMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken);

        Task AddMessageAsync(ICloudQueueMessage message, SendOptions options, CancellationToken cancellationToken);

        Task ClearAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task CreateAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<bool> CreateIfNotExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task DeleteAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<bool> DeleteIfExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task DeleteMessageAsync(ICloudQueueMessage message, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task DeleteMessageAsync(string messageId, string popReceipt, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<bool> ExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task FetchAttributesAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<ICloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<QueuePermissions> GetPermissionsAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        string GetSharedAccessSignature(SharedAccessQueuePolicy policy);

        string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier);

        string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange);

        Task<ICloudQueueMessage> PeekMessageAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task SetMetadataAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        Task SetPermissionsAsync(QueuePermissions permissions, RequestOptions requestOptions, CancellationToken cancellationToken);

        Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, RequestOptions requestOptions, CancellationToken cancellationToken);
    }
}