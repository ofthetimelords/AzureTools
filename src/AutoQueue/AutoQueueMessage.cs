#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueMessage : IAutoQueueMessage
    {
        private string _offloadMarker = null;
        private bool _offloadMarkerHasBeenInitialized;

        public AutoQueueMessage(ICloudQueueMessage originalMessage)
        {
            if (originalMessage == null)
                throw new ArgumentNullException(nameof(originalMessage), $"Parameter {nameof(originalMessage)} was null");
            this.OriginalMessage = originalMessage;
        }

        public string MessageId => this.OriginalMessage.Id;

        public string OffloadMarker { get; }

        public ICloudQueueMessage OriginalMessage { get; }

        public T ReadMessage<T>() where T : class => throw new NotImplementedException();

        public Task<T> ReadMessageAsync<T>(CancellationToken token) where T : class => throw new NotImplementedException();

        public Task<T> ReadMessageAsync<T>() where T : class => throw new NotImplementedException();


        private void TryCheckIfOffloadMarkerExistsAndSet()
        {

        }
    }
}