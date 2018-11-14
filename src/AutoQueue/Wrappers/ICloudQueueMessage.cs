using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public interface ICloudQueueMessage
    {
        /// <summary>Sets the content of this message.</summary>
        /// <param name="content">The content of the message as a byte array.</param>
        void SetMessageContent(byte[] content);

        /// <summary>Gets the content of the message as a byte array.</summary>
        /// <value>The content of the message as a byte array.</value>
        byte[] AsBytes { get; }

        /// <summary>Gets the message ID.</summary>
        /// <value>A string containing the message ID.</value>
        string Id { get; }

        /// <summary>Gets the message's pop receipt.</summary>
        /// <value>A string containing the pop receipt value.</value>
        string PopReceipt { get; }

        /// <summary>
        /// Gets the time that the message was added to the queue.
        /// </summary>
        /// <value>A <see cref="T:System.DateTimeOffset" /> indicating the time that the message was added to the queue.</value>
        DateTimeOffset? InsertionTime { get; }

        /// <summary>Gets the time that the message expires.</summary>
        /// <value>A <see cref="T:System.DateTimeOffset" /> indicating the time that the message expires.</value>
        DateTimeOffset? ExpirationTime { get; }

        /// <summary>Gets the time that the message will next be visible.</summary>
        /// <value>A <see cref="T:System.DateTimeOffset" /> indicating the time that the message will next be visible.</value>
        DateTimeOffset? NextVisibleTime { get; }

        /// <summary>Gets the content of the message, as a string.</summary>
        /// <value>A string containing the message content.</value>
        string AsString { get; }

        /// <summary>
        /// Gets the number of times this message has been dequeued.
        /// </summary>
        /// <value>The number of times this message has been dequeued.</value>
        int DequeueCount { get; }

        /// <summary>Sets the content of this message.</summary>
        /// <param name="content">A string containing the new message content.</param>
        void SetMessageContent(string content);
    }
}