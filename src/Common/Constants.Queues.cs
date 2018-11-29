using System;
using System.Collections.Generic;
using System.Text;

namespace TheQ.Libraries.AzureTools.Common
{
    /// <summary>
    /// Strongly typed constants.
    /// </summary>
    public static partial class Constants
    {
        /// <summary>
        /// Constants that apply to Queues.
        /// </summary>
        public static class Queues
        {
            /// <summary>
            /// The expected length of the message descriptor, which is used to identify whether a message has been offloaded or not.
            /// </summary>
            public static int MessageDescriptorLength => 35;

            /// <summary>
            /// The template that will be used to add the message descriptor, which is used to identify whether a message has been offloaded or not.
            /// </summary>
            public static string MessageDescriptorTemplate => "{0}|";
        }
    }
}
