#region

using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class SendOptions : RequestOptions
    {
        protected SendOptions(
            TimeSpan? timeToLive,
            TimeSpan? initialVisibilityDelay,
            QueueRequestOptions requestOptions,
            OperationContext context)
            : base(requestOptions, context)
        {
            this.TimeToLive = timeToLive;
            this.InitialVisibilityDelay = initialVisibilityDelay;
        }


        protected SendOptions(TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions requestOptions)
            : base(requestOptions)
        {
            this.TimeToLive = timeToLive;
            this.InitialVisibilityDelay = initialVisibilityDelay;
        }


        protected SendOptions(TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, OperationContext context)
            : base(context)
        {
            this.TimeToLive = timeToLive;
            this.InitialVisibilityDelay = initialVisibilityDelay;
        }


        protected SendOptions(TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay)
        {
            this.TimeToLive = timeToLive;
            this.InitialVisibilityDelay = initialVisibilityDelay;
        }


        protected SendOptions(QueueRequestOptions requestOptions, OperationContext context) : base(requestOptions, context)
        {
        }


        protected SendOptions(OperationContext context) : base(context)
        {
        }


        protected SendOptions(QueueRequestOptions requestOptions) : base(requestOptions)
        {
        }


        public TimeSpan? InitialVisibilityDelay { get; }

        public TimeSpan? TimeToLive { get; }
    }
}