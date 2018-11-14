using System;
using System.Collections.Generic;
using System.Text;

namespace TheQ.Libraries.AzureTools.Common.Exceptions
{
    public class RetriesExhaustedException : Exception
    {
        public RetriesExhaustedException(string message) : base(message)
        {
        }

        public RetriesExhaustedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
