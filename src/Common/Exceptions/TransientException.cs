using System;
using System.Collections.Generic;
using System.Text;

namespace TheQ.Libraries.AzureTools.Common.Exceptions
{
    /// <summary>
    /// Represents a retryable exception.
    /// </summary>
    public class TransientException : Exception
    {
        public TransientException(string message) : base(message)
        {
        }

        public TransientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
