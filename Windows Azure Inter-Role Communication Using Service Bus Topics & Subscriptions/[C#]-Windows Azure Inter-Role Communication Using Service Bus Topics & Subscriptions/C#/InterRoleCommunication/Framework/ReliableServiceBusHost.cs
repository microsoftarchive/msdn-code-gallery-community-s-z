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

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    #endregion

    public sealed class ReliableServiceBusHost<T> : ICommunicationObject, IDisposable where T : class
    {
        #region Private members
        private const int DefaultOpenTimeoutSec = 60 * 5;

        private readonly ServiceHost serviceHost;
        private readonly RetryPolicy retryPolicy;
        private readonly ServiceBusEndpointInfo sbEndpointInfo;
        private ServiceHost failoverServiceHost;

        private bool disposed;
        #endregion

        #region Constructors
        public ReliableServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo)
            : this(sbEndpointInfo, RetryPolicy.NoRetry)
        {
        }

        public ReliableServiceBusHost(ServiceBusEndpointInfo sbEndpointInfo, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(sbEndpointInfo, "sbEndpointInfo");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.sbEndpointInfo = sbEndpointInfo;
            this.serviceHost = ServiceBusHostFactory.CreateServiceBusHost<T>(sbEndpointInfo);
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;

            AttachEventHandlers(this.serviceHost);
        }

        public ReliableServiceBusHost(ServiceHost serviceHost, RetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(serviceHost, "serviceHost");
            Guard.ArgumentNotNull(retryPolicy, "retryPolicy");

            this.serviceHost = serviceHost;
            this.retryPolicy = retryPolicy;
            this.retryPolicy.RetryOccurred += HandleRetryState;

            AttachEventHandlers(this.serviceHost);
        }
        #endregion

        #region Public properties
        public T ServiceInstance
        {
            get { return ServiceHost.SingletonInstance as T; }
        }

        public RetryPolicy RetryPolicy
        {
            get { return this.retryPolicy; }
        }
        #endregion

        #region Private properties
        public ServiceHost ServiceHost
        {
            get { return this.serviceHost.State != CommunicationState.Faulted ? this.serviceHost : (this.failoverServiceHost != null ? this.failoverServiceHost : this.serviceHost); }
        }
        #endregion

        #region ICommunicationObject implementation
        public void Abort()
        {
            try
            {
                ServiceHost.Abort();
            }
            catch
            {
                // It is acceptable to ignore any exceptions within this context.
            }
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return ServiceHost.BeginClose(timeout, callback, state);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return ServiceHost.BeginClose(callback, state);
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return ServiceHost.BeginOpen(timeout, callback, state);
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return ServiceHost.BeginOpen(callback, state);
        }

        public void Close(TimeSpan timeout)
        {
            ServiceHost.Close(timeout);
        }

        public void Close()
        {
            try
            {
                ServiceHost.Close();
            }
            catch
            {
                // It is acceptable to ignore any exceptions within this context.
            }
        }

        public void EndClose(IAsyncResult result)
        {
            ServiceHost.EndClose(result);
        }

        public void EndOpen(IAsyncResult result)
        {
            ServiceHost.EndOpen(result);
        }

        public void Open(TimeSpan timeout)
        {
            this.retryPolicy.ExecuteAction(() =>
            {
                ServiceHost.Open(timeout);
            });
        }

        public void Open()
        {
            Open(TimeSpan.FromSeconds(DefaultOpenTimeoutSec));
        }

        public CommunicationState State
        {
            get { return ServiceHost.State; }
        }

        public event EventHandler Opened;
        public event EventHandler Opening;
        public event EventHandler Faulted;
        public event EventHandler Closed;
        public event EventHandler Closing;
        #endregion

        #region IDisposable implementation
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
                    try
                    {
                        if (ServiceHost != null)
                        {
                            // Unbind from the all event handler.
                            DettachEventHandlers(ServiceHost);

                            if (ServiceHost.State == CommunicationState.Opened)
                            {
                                ServiceHost.Close();
                            }
                            else
                            {
                                ServiceHost.Abort();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Abort();
                    }

                    this.retryPolicy.RetryOccurred -= HandleRetryState;
                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// Finalises the object instance.
        /// </summary>
        ~ReliableServiceBusHost()
        {
            this.Dispose(false);
        }
        #endregion

        #region Private methods
        private void HandleRetryState(int currentRetryCount, Exception lastException, TimeSpan delay)
        {
        }

        private void HandleServiceHostFaultedState(object sender, EventArgs e)
        {
            // Unbind from the all event handler.
            DettachEventHandlers(ServiceHost);

            // Allow user-code to participate in the Faulted event handling.
            HandleFaultedEvent(sender, e);

            // Recycle and reopen the host.
            Abort();

            // Declare a failover host which we will be attempting to spin off.
            ServiceHost failoverHost = null;

            // Attempt to open the failover host.
            this.retryPolicy.ExecuteAction(() =>
            {
                try
                {
                    if (null == failoverHost)
                    {
                        // Create and initialize a failover host based on the original service host configuration.
                        failoverHost = CreateFailoverHost();
                    }

                    // Attempt to open the newly initialized service host.
                    failoverHost.Open(failoverHost.OpenTimeout);
                }
                finally
                {
                    if (failoverHost.State == CommunicationState.Faulted)
                    {
                        try
                        {
                            failoverHost.Abort();
                        }
                        catch
                        {
                            // It is acceptable to ignore any exceptions within this context.
                        }
                        finally
                        {
                            failoverHost = null;
                        }
                    }
                }
            });

            // Ensure that all standard event handlers are attached to the new service.
            AttachEventHandlers(failoverHost);

            // Activate the new service host as a failover host.
            this.failoverServiceHost = failoverHost;
        }

        private ServiceHost CreateFailoverHost()
        {
            // If a Service Bus endpoint is known, we can simply ask the factory object to create a new service host.
            if (this.sbEndpointInfo != null)
            {
                return ServiceBusHostFactory.CreateServiceBusHost<T>(this.sbEndpointInfo);
            }
            else
            {
                // Create a new service host depending on whether or not the original service host was hosting a singleton.
                ServiceHost newHost = ServiceHost.SingletonInstance != null ? new ServiceHost(ServiceHost.SingletonInstance) : new ServiceHost(typeof(T));

                // Clone the endpoint information into the new service host.
                foreach (var endpoint in ServiceHost.Description.Endpoints)
                {
                    if (!newHost.Description.Endpoints.Contains(endpoint))
                    {
                        newHost.Description.Endpoints.Add(endpoint);
                    }
                }

                // Clone the behavior information into the new service host.
                foreach (var behavior in ServiceHost.Description.Behaviors)
                {
                    if (!newHost.Description.Behaviors.Contains(behavior.GetType()))
                    {
                        newHost.Description.Behaviors.Add(behavior);
                    }
                }

                // Clone the extension information into the new service host.
                foreach (var extension in ServiceHost.Extensions)
                {
                    if (!newHost.Extensions.Contains(extension))
                    {
                        newHost.Extensions.Add(extension);
                    }
                }

                // Clone other service host settings and properties.
                newHost.Description.Name = ServiceHost.Description.Name;
                newHost.Description.Namespace = ServiceHost.Description.Namespace;
                newHost.Description.ConfigurationName = ServiceHost.Description.ConfigurationName;
                newHost.OpenTimeout = ServiceHost.OpenTimeout;
                newHost.CloseTimeout = ServiceHost.CloseTimeout;

                return newHost;
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

        private void AttachEventHandlers(ServiceHost host)
        {
            Guard.ArgumentNotNull(host, "host");

            host.Opening += HandleOpeningEvent;
            host.Opened += HandleOpenedEvent;
            host.Faulted += HandleServiceHostFaultedState;
            host.Closing += HandleClosingEvent;
            host.Closed += HandleClosedEvent;
        }

        private void DettachEventHandlers(ServiceHost host)
        {
            Guard.ArgumentNotNull(host, "host");

            host.Opening -= HandleOpeningEvent;
            host.Opened -= HandleOpenedEvent;
            host.Faulted -= HandleServiceHostFaultedState;
            host.Closing -= HandleClosingEvent;
            host.Closed -= HandleClosedEvent;
        }
        #endregion
    }
}
