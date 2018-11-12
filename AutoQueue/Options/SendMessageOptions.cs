using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TheQ.Libraries.AzureTools.AutoQueue.Options
{
    public class RequestOptions
    {
        public RequestOptions()
        {
        }
        public RequestOptions(OperationContext context)
        {
            this.Context = context;
        }
        public RequestOptions(QueueRequestOptions requestOptions)
        {
            this.QueueRequestOptions = requestOptions;
        }
        public RequestOptions(QueueRequestOptions requestOptions, OperationContext context)
        {
            this.QueueRequestOptions = requestOptions;
            this.Context = context;
        }

        public QueueRequestOptions QueueRequestOptions { get; }

        public OperationContext Context { get; }

    }
}
