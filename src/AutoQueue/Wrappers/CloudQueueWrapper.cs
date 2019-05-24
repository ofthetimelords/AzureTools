﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
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
        public CloudQueueWrapper(CloudQueue original) => this.Original = original ?? throw new ArgumentNullException(nameof(original), $"Parameter ${nameof(original)} is required");

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

        public Task AddMessageAsync(ICloudQueueMessage message, SendOptions options, CancellationToken cancellationToken) =>
            this.Original.AddMessageAsync((CloudQueueMessageWrapper) message, options?.TimeToLive, options?.InitialVisibilityDelay, options?.QueueRequestOptions, options.Context, cancellationToken);

        public Task ClearAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => this.Original.ClearAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task CreateAsync(RequestOptions requestOptions, CancellationToken cancellationToken) => this.Original.CreateAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task<bool> CreateIfNotExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.CreateIfNotExistsAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task DeleteAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.DeleteAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task<bool> DeleteIfExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.DeleteIfExistsAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task DeleteMessageAsync(ICloudQueueMessage message, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.DeleteMessageAsync((CloudQueueMessageWrapper) message, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task DeleteMessageAsync(string messageId, string popReceipt, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.DeleteMessageAsync(messageId, popReceipt, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task<bool> ExistsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.ExistsAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task FetchAttributesAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.FetchAttributesAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public async Task<ICloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            (CloudQueueMessageWrapper) await this.Original.GetMessageAsync(visibilityTimeout, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken).ConfigureAwait(false);

        public async Task<IEnumerable<ICloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            (await this.Original.GetMessagesAsync(messageCount, visibilityTimeout, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken).ConfigureAwait(false))?.Select(q => (CloudQueueMessageWrapper) q);

        public Task<QueuePermissions> GetPermissionsAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.GetPermissionsAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy) =>
            this.Original.GetSharedAccessSignature(policy);

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier) =>
            this.Original.GetSharedAccessSignature(policy, accessPolicyIdentifier);

        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange) =>
            this.Original.GetSharedAccessSignature(policy, accessPolicyIdentifier, protocols, ipAddressOrRange);

        public async Task<ICloudQueueMessage> PeekMessageAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            (CloudQueueMessageWrapper) await this.Original.PeekMessageAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken).ConfigureAwait(false);

        public async Task<IEnumerable<ICloudQueueMessage>> PeekMessagesAsync(int messageCount, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            (await this.Original.PeekMessagesAsync(messageCount, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken).ConfigureAwait(false))?.Select(q => (CloudQueueMessageWrapper) q);

        public Task SetMetadataAsync(RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.SetMetadataAsync(requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task SetPermissionsAsync(QueuePermissions permissions, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.SetPermissionsAsync(permissions, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);

        public Task UpdateMessageAsync(ICloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, RequestOptions requestOptions, CancellationToken cancellationToken) =>
            this.Original.UpdateMessageAsync((CloudQueueMessageWrapper) message, visibilityTimeout, updateFields, requestOptions.QueueRequestOptions, requestOptions.Context, cancellationToken);
    }
}