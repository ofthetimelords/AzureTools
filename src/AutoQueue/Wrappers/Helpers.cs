using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Queue;

namespace TheQ.Libraries.AzureTools.AutoQueue.Wrappers
{
    public static class Helpers
    {
        public static ICloudQueue Wrap(this CloudQueue queue) => (CloudQueueWrapper)queue;
        public static ICloudQueueMessage Wrap(this CloudQueueMessage queue) => (CloudQueueMessageWrapper)queue;
    }
}
