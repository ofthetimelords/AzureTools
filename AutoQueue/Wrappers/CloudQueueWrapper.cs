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

        public Task AddMessageAsync(ICloudQueueMessage message, CancellationToken cancellationToken) => this.Original.AddMessageAsync((CloudQueueMessageWrapper) message, cancellationToken);

        public Task AddMessageAsync(ICloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.AddMessageAsync( new CloudQueueMessageWrapper(message), timeToLive, initialVisibilityDelay, requestOptions?.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task ClearAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => this.Original.ClearAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task CreateAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => this.Original.CreateAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task<bool> CreateIfNotExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> DeleteIfExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteMessageAsync(ICloudQueueMessage message, RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task DeleteMessageAsync(string messageId, string popReceipt, RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<bool> ExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task FetchAttributesAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            throw new NotImplementedException();

        public Task<QueuePermissions> GetPermissionsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier) => throw new NotImplementedException();

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange) => throw new NotImplementedException();

        public Task<ICloudQueueMessage> PeekMessageAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task SetMetadataAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task SetPermissionsAsync(QueuePermissions permissions, RequestOptions requestOptions, CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, RequestOptions requestOptions,
            CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}