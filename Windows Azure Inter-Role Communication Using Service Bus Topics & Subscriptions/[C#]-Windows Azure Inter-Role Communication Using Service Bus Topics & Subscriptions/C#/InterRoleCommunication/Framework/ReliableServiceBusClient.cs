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
    using System.ServiceModel;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    #endregion

    public sealed class ReliableServiceBusClient<T> : ICommunicationObject, IDisposable where T : IClientChannel
    {
        #region Private members
        private const int DefaultOpenTimeoutSec = 60 * 5;

        private readonly RetryPolicy retryPolicy;
        private readonly ChannelFactory<T> channelFactory;
        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        
        private bool disposed;
        private T clientChannel;
        #endregion

        #region Constructors
        public ReliableServiceBusClient(ServiceBusEndpointInfo sbEndpointInfo)
            : this(sbEndpointInfo, RetryPolicy.NoRetry)
        {
        }

        public ReliableServiceBusClient(ServiceBusEndpointInfo sbEndpointInfo, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.sbEndpointInfo = sbEndpointInfo;
            this.channelFactory = ServiceBusClientFactory.CreateServiceBusClientChannelFactory<T>(sbEndpointInfo);
            
            this.clientChannel = this.channelFactory.CreateChannel();
            this.clientChannel.Opening += new EventHandler(HandleOpeningEvent);
            this.clientChannel.Opened += new EventHandler(HandleOpenedEvent);
            this.clientChannel.Faulted += new EventHandler(HandleFaultedEvent);
            this.clientChannel.Closing += new EventHandler(HandleClosingEvent);
            this.clientChannel.Closed += new EventHandler(HandleClosedEvent);
            
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;
        }
        #endregion

        #region Public properties
        public T Client
        {
            get 
            {
                if (!(this.clientChannel != null && this.clientChannel.State == CommunicationState.Opened))
                {
                    Open();
                }

                return this.clientChannel;  
            }
        }

        public RetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Finalises the object instance.
        /// </summary>
        ~ReliableServiceBusClient()
        {
            this.Dispose(false);
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Terminating the WCF service client channel.
                    try
                    {
                        if (this.clientChannel != null)
                        {
                            if (this.clientChannel.State == CommunicationState.Opened)
                            {
                                this.clientChannel.Close();
                            }
                            else
                            {
                                this.clientChannel.Abort();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Abort();
                    }

                    // Terminating the WCF service channel factory.
                    try
                    {
                        if (this.channelFactory.State == CommunicationState.Opened)
                        {
                            this.channelFactory.Close();
                        }
                        else
                        {
                            this.channelFactory.Abort();
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            this.channelFactory.Abort();
                        }
                        catch
                        {
                            // It is acceptable to ignore any exceptions within this context.
                        }

                    }

                    this.retryPolicy.RetryOccurred -= HandleRetryState;
                    this.disposed = true;
                }
            }
        }  
        #endregion

        #region ICommunicationObject implementation
        public void Abort()
        {
            try
            {
                if (this.clientChannel != null)
                {
                    this.clientChannel.Abort();
                }
            }
            catch
            {
                // It is acceptable to ignore any exceptions within this context.
            }
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginClose(timeout, callback, state);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginClose(callback, state);
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginOpen(timeout, callback, state);
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return this.clientChannel.BeginOpen(callback, state);
        }

        public void Close(TimeSpan timeout)
        {
            this.clientChannel.Close(timeout);
        }

        public void Close()
        {
            this.clientChannel.Close();
        }

        public void EndClose(IAsyncResult result)
        {
            this.clientChannel.EndClose(result);
        }

        public void EndOpen(IAsyncResult result)
        {
            this.clientChannel.EndOpen(result);
        }

        public void Open(TimeSpan timeout)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                EnsureValidChannel();
                this.clientChannel.Open(timeout);
            });
        }

        public void Open()
        {
            Open(TimeSpan.FromSeconds(DefaultOpenTimeoutSec));
        }

        public CommunicationState State
        {
            get { return this.clientChannel.State; }
        }

        public event EventHandler Opened;
        public event EventHandler Opening;
        public event EventHandler Faulted;
        public event EventHandler Closed;
        public event EventHandler Closing;
        #endregion

        #region Private methods
        private void HandleRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
        }

        private void EnsureValidChannel()
        {
            if (!(this.clientChannel != null && this.clientChannel.State == CommunicationState.Opened))
            {
                if (this.clientChannel.State == CommunicationState.Faulted || this.clientChannel.State == CommunicationState.Closed || this.clientChannel.State == CommunicationState.Closing)
                {
                    Abort();

                    // Recreate a client channel if it was previously marked as Faulted.
                    this.clientChannel = this.channelFactory.CreateChannel();
                }
            }
        }

        private void HandleOpeningEvent(object sender, EventArgs e)
        {
            if (Opening != null)
            {
                Opening(sender, e);
            }
        }

        private void HandleOpenedEvent(object sender, EventArgs e)
        {
            if (Opened != null)
            {
                Opened(sender, e);
            }
        }

        private void HandleFaultedEvent(object sender, EventArgs e)
        {
            if (Faulted != null)
            {
                Faulted(sender, e);
            }
        }

        private void HandleClosingEvent(object sender, EventArgs e)
        {
            if (Closing != null)
            {
                Closing(sender, e);
            }
        }

        private void HandleClosedEvent(object sender, EventArgs e)
        {
            if (Closed != null)
            {
                Closed(sender, e);
            }
        }
        #endregion
    }
}