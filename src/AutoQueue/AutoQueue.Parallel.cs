﻿#region

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue
    {
        public Task ListenParallelAsync(ListenParallelOptions options) => throw new NotImplementedException();
    }
}