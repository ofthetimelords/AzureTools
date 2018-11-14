using System;
using System.Collections.Generic;
using System.Text;

namespace TheQ.Libraries.AzureTools.Common.Exceptions
{
    /// <summary>
    /// Represents a non-retryable exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class FatalException : Exception
    {
        public FatalException(string message) : base(message)
        {
        }

        public FatalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
