#region

using System;
using System.Threading;
using System.Threading.Tasks;
using TheQ.Libraries.AzureTools.AutoQueue.Standard.RetryStrategies;
using TheQ.Libraries.AzureTools.Common.Exceptions;

#endregion

namespace TheQ.Libraries.AzureTools.AutoQueue.Standard
{
    public class SimpleRetryPolicy : IRetryPolicy
    {
        public SimpleRetryPolicy(int numberOfRetries, bool throwOnExhaustedRetries, IRetryStrategy retryStrategy)
        {
            if (numberOfRetries <= 0)
                throw new ArgumentException("Parameter numberOfRetries cannot be lower than 1");

            this.NumberOfRetries = numberOfRetries;
            this.ThrowOnExhaustedRetries = throwOnExhaustedRetries;
            this.RetryStrategy = retryStrategy ?? throw new ArgumentNullException(nameof(retryStrategy), "Parameter retryStrategy cannot be null");
        }

        public int NumberOfRetries { get; }
        public IRetryStrategy RetryStrategy { get; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="RetriesExhaustedException"/> will be thrown when the maximum amount of retries has been attempted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw on exhausted retries]; otherwise, <c>false</c>.
        /// </value>
        public bool ThrowOnExhaustedRetries { get; }

        public async Task Do(Func<CancellationToken, Task> action, CancellationToken token)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), "Parameter action is required");

            for (var retry = 0; retry < this.NumberOfRetries; retry++)
                try
                {
                    await action(token);
                }
                catch (TransientException)
                {
                    await this.RetryStrategy.AwaitRetry(retry, token);
                }

            if (this.ThrowOnExhaustedRetries)
                throw new RetriesExhaustedException($"Amount of retries was exhausted and {this.ThrowOnExhaustedRetries} was set.");
        }

        public async Task<T> Do<T>(Func<CancellationToken, Task<T>> action, CancellationToken token)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), "Parameter action is required");

            for (var retry = 0; retry < this.NumberOfRetries; retry++)
                try
                {
                    return await action(token);
                }
                catch (TransientException)
                {
                    await this.RetryStrategy.AwaitRetry(retry, token);
                }

            return this.ThrowOnExhaustedRetries
                ? throw new RetriesExhaustedException($"Amount of retries was exhausted and {this.ThrowOnExhaustedRetries} was set.")
                : default(T);
        }
    }
}