using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using TheQ.Libraries.AzureTools.AutoQueue.Options;

namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public partial class AutoQueue : IAutoQueue
    {
        /// <exception cref="NotImplementedException">In progress.</exception>
        public Task ListenAsync(ListenOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
