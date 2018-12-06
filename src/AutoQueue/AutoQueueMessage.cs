#region

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Wrappers;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public class AutoQueueMessage : IAutoQueueMessage
    {
        private byte[] _offloadMarker = null;
        private bool _offloadMarkerHasBeenInitialized;

        public AutoQueueMessage(ICloudQueueMessage originalMessage)
        {
            if (originalMessage == null)
                throw new ArgumentNullException(nameof(originalMessage), $"Parameter {nameof(originalMessage)} was null");
            this.OriginalMessage = originalMessage;
        }

        public string MessageId => this.OriginalMessage.Id;

        public byte[] OffloadMarker
        {
            get
            {
                if (!this._offloadMarkerHasBeenInitialized)
                    this.TryCheckIfOffloadMarkerExistsAndSet();

                return this._offloadMarker;
            }
        }

        public ICloudQueueMessage OriginalMessage { get; }

        public T ReadMessage<T>() where T : class => throw new NotImplementedException();

        public Task<T> ReadMessageAsync<T>(CancellationToken token) where T : class => throw new NotImplementedException();

        public Task<T> ReadMessageAsync<T>() where T : class => throw new NotImplementedException();


        private void TryCheckIfOffloadMarkerExistsAndSet()
        {
            try
            {
                // Format: 32bytes - Random Character - 32 bytes (hash). 65 bytes in total
                var bytes = this.OriginalMessage.AsBytes;
                var marker = new ArraySegment<byte>(bytes, 0, 32);
                var segment = new ArraySegment<byte>(bytes, 33, 32);

                if (bytes.Length != 65)
                    return;

                using (var hash = SHA512.Create())
                {
                    var computed = hash.ComputeHash(bytes, 0, 32);

                    if (segment.SequenceEqual(computed))
                        this._offloadMarker = marker.ToArray();
                }
            }
            catch
            {
                // Ignore exceptions here; if the marker can't be passed, then it's not a marker.
            }
            finally
            {
                this._offloadMarkerHasBeenInitialized = true;
            }
        }
    }
}