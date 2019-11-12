//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework
{
    #region Using references
    using System;
    using System.Threading;
    #endregion

    /// <summary>
    /// Defines a callback delegate which will be invoked whenever a retry condition is encountered.
    /// </summary>
    /// <param name="currentRetryCount">The current retry attempt count.</param>
    /// <param name="lastException">The exception which caused the retry conditions to occur.</param>
    /// <param name="delay">The delay indicating how long the current thread will be suspended for before the next iteration will be invoked.</param>
    public delegate void RetryCallbackDelegate(int currentRetryCount, Exception lastException, TimeSpan delay);

    /// <summary>
    /// Implements a policy defining and implementing the retry mechanism for unreliable actions.
    /// </summary>
    public abstract class RetryPolicy
    {
        #region Public members
        /// <summary>
        /// The default number of retry attempts.
        /// </summary>
        public static readonly int DefaultClientRetryCount = 10;

        /// <summary>
        /// The default amount of time used when calculating a random delta in the exponential delay between retries.
        /// </summary>
        public static readonly TimeSpan DefaultClientBackoff = TimeSpan.FromSeconds(10.0);

        /// <summary>
        /// The default maximum amount of time used when calculating the exponential delay between retries.
        /// </summary>
        public static readonly TimeSpan DefaultMaxBackoff = TimeSpan.FromSeconds(30.0);

        /// <summary>
        /// The default minimum amount of time used when calculating the exponential delay between retries.
        /// </summary>
        public static readonly TimeSpan DefaultMinBackoff = TimeSpan.FromSeconds(1.0);

        /// <summary>
        /// The default amount of time defining an interval between retries.
        /// </summary>
        public static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromSeconds(1.0);

        /// <summary>
        /// Policy that does no retries, it just invokes action exactly once.
        /// </summary>
        public static readonly RetryPolicy NoRetry = new RetryPolicy<TransientErrorIgnoreStrategy>(0);
        #endregion

        #region Public properties
        /// <summary>
        /// An instance of a callback delegate which will be invoked whenever a retry condition is encountered.
        /// </summary>
        public event RetryCallbackDelegate RetryOccurred;

        /// <summary>
        /// A boolean flag indicating whether or not the very first retry attempt will be made immediately
        /// whereas the subsequent retries will remain subject to retry interval.
        /// </summary>
        public bool FastFirstRetry { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <param name="action">A delegate representing the executable action which doesn't return any results.</param>
        public abstract void ExecuteAction(Action action);

        /// <summary>
        /// Repetitively executes the specified asynchronous action while it satisfies the current retry policy.
        /// </summary>
        /// <param name="action">A delegate representing the executable action that must invoke an asynchronous operation and return its <see cref="IAsyncResult"/>.</param>
        /// <param name="callback">The callback delegate that will be triggered when the main asynchronous operation completes.</param>
        /// <param name="faultHandler">The fault handler delegate that will be triggered if the operation cannot be successfully invoked despite retry attempts.</param>
        public abstract void ExecuteAction(Action<AsyncCallback> action, Action<IAsyncResult> callback, Action<Exception> faultHandler);

        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <typeparam name="T">The type of result expected from the executable action.</typeparam>
        /// <param name="func">A delegate representing the executable action which returns the result of type T.</param>
        /// <returns>The result from the action.</returns>
        public abstract T ExecuteAction<T>(Func<T> func);
        #endregion

        #region Protected members
        /// <summary>
        /// Notifies the subscribers whenever a retry condition is encountered.
        /// </summary>
        /// <param name="retryCount">The current retry attempt count.</param>
        /// <param name="lastError">The exception which caused the retry conditions to occur.</param>
        /// <param name="delay">The delay indicating how long the current thread will be suspended for before the next iteration will be invoked.</param>
        protected virtual void OnRetryOccurred(int retryCount, Exception lastError, TimeSpan delay)
        {
            if (RetryOccurred != null)
            {
                RetryOccurred(retryCount, lastError, delay);
            }
        }
        #endregion

        #region Private classes
        /// <summary>
        /// Implements a strategy that ignores any transient errors.
        /// </summary>
        private sealed class TransientErrorIgnoreStrategy : ITransientErrorDetectionStrategy
        {
            public bool IsTransient(Exception ex)
            {
                return false;
            }
        }
        #endregion
    }

    public class RetryPolicy<T> : RetryPolicy where T : ITransientErrorDetectionStrategy, new()
    {
        #region Private members
        private readonly T errorDetectionStrategy = new T();
        private readonly ShouldRetry shouldRetry;

        protected delegate bool ShouldRetry(int retryCount, Exception lastException, out TimeSpan delay);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the RetryPolicy class with default settings.
        /// </summary>
        private RetryPolicy()
        {
            FastFirstRetry = true;
        }

        /// <summary>
        /// Initializes a new instance of the RetryPolicy class with the specified number of retry attempts and default fixed time interval between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        public RetryPolicy(int retryCount) : this(retryCount, DefaultRetryInterval)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RetryPolicy class with the specified number of retry attempts and time interval between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="intervalBetweenRetries">The interval between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan intervalBetweenRetries) : this()
        {
            if (0 == retryCount)
            {
                this.shouldRetry = delegate(int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
                {
                    retryInterval = TimeSpan.Zero;
                    return false;
                };
            }
            else
            {
                this.shouldRetry = delegate(int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
                {
                    if (this.errorDetectionStrategy.IsTransient(lastException))
                    {
                        retryInterval = intervalBetweenRetries;
                        return (currentRetryCount < retryCount);
                    }
                    else
                    {
                        retryInterval = TimeSpan.Zero;
                        return false;
                    }
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the RetryPolicy class with the specified number of retry attempts and backoff parameters for calculating the exponential delay between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="minBackoff">The minimum backoff time.</param>
        /// <param name="maxBackoff">The maximum backoff time.</param>
        /// <param name="deltaBackoff">The time value which will be used for calculating a random delta in the exponential delay between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan minBackoff, TimeSpan maxBackoff, TimeSpan deltaBackoff) : this()
        {
            this.shouldRetry = delegate(int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
            {
                if (this.errorDetectionStrategy.IsTransient(lastException) && currentRetryCount < retryCount)
                {
                    Random random = new Random();

                    int delta = (int)((Math.Pow(2.0, (double)currentRetryCount) - 1.0) * random.Next((int)(deltaBackoff.TotalMilliseconds * 0.8), (int)(deltaBackoff.TotalMilliseconds * 1.2)));
                    int interval = (int)Math.Min(minBackoff.TotalMilliseconds + delta, maxBackoff.TotalMilliseconds);

                    retryInterval = TimeSpan.FromMilliseconds((double)interval);

                    return true;
                }

                retryInterval = TimeSpan.Zero;
                return false;
            };
        }

        /// <summary>
        /// Initializes a new instance of the RetryPolicy class with the specified number of retry attempts and parameters defining the progressive delay between retries.
        /// </summary>
        /// <param name="retryCount">The number of retry attempts.</param>
        /// <param name="initialInterval">The initial interval which will apply for the first retry.</param>
        /// <param name="increment">The incremental time value which will be used for calculating the progressive delay between retries.</param>
        public RetryPolicy(int retryCount, TimeSpan initialInterval, TimeSpan increment) : this()
        {
            this.shouldRetry = delegate(int currentRetryCount, Exception lastException, out TimeSpan retryInterval)
            {
                if (this.errorDetectionStrategy.IsTransient(lastException) && currentRetryCount < retryCount)
                {
                    retryInterval = TimeSpan.FromMilliseconds(initialInterval.TotalMilliseconds + increment.TotalMilliseconds * currentRetryCount);

                    return true;
                }

                retryInterval = TimeSpan.Zero;
                return false;
            };
        }
        #endregion

        #region RetryPolicy implementation
        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <param name="action">A delegate representing the executable action which doesn't return any results.</param>
        public override void ExecuteAction(Action action)
        {
            int retryCount = 0;
            TimeSpan delay = TimeSpan.Zero;
            Exception lastError = null;

            for (; ; )
            {
                lastError = null;

                try
                {
                    action();
                    return;
                }
                catch (RetryLimitExceededException limitExceededEx)
                {
                    // The user code can throw a RetryLimitExceededException to force the exit from the retry loop.
                    // The RetryLimitExceeded exception can have an inner exception attached to it. This is the exception
                    // which we will have to throw up the stack so that callers can handle it.
                    if (limitExceededEx.InnerException != null)
                    {
                        throw limitExceededEx.InnerException;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lastError = ex;

                    if (!this.shouldRetry(retryCount++, lastError, out delay))
                    {
                        throw;
                    }
                }

                OnRetryOccurred(retryCount, lastError, delay);

                if (retryCount > 1 || !FastFirstRetry)
                {
                    Thread.Sleep(delay);
                }
            }
        }

        /// <summary>
        /// Repetitively executes the specified action while it satisfies the current retry policy.
        /// </summary>
        /// <typeparam name="R">The type of result expected from the executable action.</typeparam>
        /// <param name="func">A delegate representing the executable action which returns the result of type R.</param>
        /// <returns>The result from the action.</returns>
        public override R ExecuteAction<R>(Func<R> func)
        {
            int retryCount = 0;
            TimeSpan delay = TimeSpan.Zero;
            Exception lastError = null;

            for (; ; )
            {
                lastError = null;

                try
                {
                    return func();
                }
                catch (RetryLimitExceededException limitExceededEx)
                {
                    // The user code can throw a RetryLimitExceededException to force the exit from the retry loop.
                    // The RetryLimitExceeded exception can have an inner exception attached to it. This is the exception
                    // which we will have to throw up the stack so that callers can handle it.
                    if (limitExceededEx.InnerException != null)
                    {
                        throw limitExceededEx.InnerException;
                    }
                    else
                    {
                        return default(R);
                    }
                }
                catch (Exception ex)
                {
                    lastError = ex;

                    if (!this.shouldRetry(retryCount++, lastError, out delay))
                    {
                        throw;
                    }
                }

                OnRetryOccurred(retryCount, lastError, delay);

                if (retryCount > 1 || !FastFirstRetry)
                {
                    Thread.Sleep(delay);
                }
            }
        }

        /// <summary>
        /// Repetitively executes the specified asynchronous action while it satisfies the current retry policy.
        /// </summary>
        /// <param name="action">A delegate representing the executable action that must invoke an asynchronous operation and return its <see cref="IAsyncResult"/>.</param>
        /// <param name="callback">The callback delegate that will be triggered when the main asynchronous operation completes.</param>
        /// <param name="faultHandler">The fault handler delegate that will be triggered if the operation cannot be successfully invoked despite retry attempts.</param>
        public override void ExecuteAction(Action<AsyncCallback> action, Action<IAsyncResult> callback, Action<Exception> faultHandler)
        {
            int retryCount = 0;
            AsyncCallback endInvoke = null;

            // Configure a custom callback delegate that implements the core retry logic.
            endInvoke = ((ar) =>
            {
                Exception lastError = null;
                TimeSpan delay = TimeSpan.Zero;

                try
                {
                    // Invoke the callback delegate which can throw an exception if the main async operation has completed with a fault.
                    callback(ar);
                    return;
                }
                catch (Exception ex)
                {
                    // Capture the original exception for analysis.
                    lastError = ex;
                }

                // Check if the main async operation has been unsuccessful.
                if (lastError != null)
                {
                    // Handling of RetryLimitExceededException needs to be done separately. This exception type indicates the application's intent to exit from the retry loop.
                    if (lastError is RetryLimitExceededException)
                    {
                        if (lastError.InnerException != null)
                        {
                            faultHandler(lastError.InnerException);
                        }
                        return;
                    }
                    
                    // Check if we should continue retrying on this exception. If not, invoke the fault handler so that user code can take control.
                    if (!this.shouldRetry(retryCount++, lastError, out delay))
                    {
                        faultHandler(lastError);
                        return;
                    }

                    // Notify the respective subscribers about this exception.
                    OnRetryOccurred(retryCount, lastError, delay);

                    // Sleep for the defined interval before repetitively executing the main async operation.
                    if (retryCount > 1 || !FastFirstRetry)
                    {
                        Thread.Sleep(delay);
                    }

                    action(endInvoke);
                }
            });

            // Invoke the the main async operation for the first time which should return control to the caller immediately.
            action(endInvoke);
        }
        #endregion
    }
}
