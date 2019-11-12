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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication
{
    #region Using references
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.ServiceModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Runtime.Remoting.Messaging;

    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Description;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.ServiceBus.Messaging.Filters;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Internal;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Properties;
    #endregion

    /// <summary>
    /// Implements a component which provides access to the publish/subscribe messaging infrastructure for exchanging messages between participants.
    /// </summary>
    public class InterRoleCommunicationExtension : IInterRoleCommunicationExtension
    {
        #region Private members
        private readonly ConcurrentDictionary<IObserver<InterRoleCommunicationEvent>, int> subscribers = new ConcurrentDictionary<IObserver<InterRoleCommunicationEvent>, int>();
        private readonly ConcurrentDictionary<IObserver<Tuple<Exception, InterRoleCommunicationEvent>>, int> faultHandlers = new ConcurrentDictionary<IObserver<Tuple<Exception, InterRoleCommunicationEvent>>, int>();
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        private readonly EventObjectSerializer serializer = new EventObjectSerializer(typeof(InterRoleCommunicationEvent));
        private readonly ServiceBusEndpointInfo serviceBusEndpoint;
        private readonly RetryPolicy retryPolicy;
        private readonly string senderRoleID, senderInstanceID, ircSubscriptionName;
        private readonly NamespaceManager nsManager;
        private readonly Action receiveAction;
        private readonly Action<BrokeredMessage> dispatchAction;
        private readonly Action<BrokeredMessage, Exception> receiveFaultAction;
        private readonly AsyncCallback endReceive, endDispatch;
        private readonly InterRoleCommunicationSettings settings;
        private readonly bool useStaticSubscription;

        // All CommunicationObject instances are not declared as read-only since they may be re-instantiated if they become faulted.
        private MessagingFactory messagingFactory;
        private TopicClient topicClient;
        private SubscriptionClient subscriptionClient;
        private IAsyncResult receiveHandle;

        private const string MsgCtxPropNameFrom = "IRC_From";
        private const string MsgCtxPropNameTo = "IRC_To";
        private const string MsgCtxPropValueAny = "*";
        private const string SubscriptionNamePrefix = "IRC-";

        private bool disposed;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of a <see cref="InterRoleCommunicationExtension"/> object with the specified Service Bus topic endpoint and defaults settings.
        /// </summary>
        /// <param name="serviceBusEndpoint">The Service Bus topic endpoint using which the IRC component will be providing inter-role communication.</param>
        public InterRoleCommunicationExtension(ServiceBusEndpointInfo serviceBusEndpoint)
            : this(serviceBusEndpoint, InterRoleCommunicationSettings.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="InterRoleCommunicationExtension"/> object with the specified Service Bus topic endpoint and custom settings.
        /// </summary>
        /// <param name="serviceBusEndpoint">The Service Bus topic endpoint using which this component will be providing inter-role communication.</param>
        /// <param name="settings">The <see cref="InterRoleCommunicationSettings"/> object containing behavioral and runtime settings for the inter-role communication component.</param>
        public InterRoleCommunicationExtension(ServiceBusEndpointInfo serviceBusEndpoint, InterRoleCommunicationSettings settings)
        {
            Guard.ArgumentNotNull(serviceBusEndpoint, "serviceBusEndpoint");
            Guard.ArgumentNotNull(settings, "settings");
            Guard.ArgumentNotNullOrEmptyString(serviceBusEndpoint.TopicName, "serviceBusEndpoint.TopicName");

            // Initialize internal fields.
            this.settings = settings;
            this.serviceBusEndpoint = serviceBusEndpoint;
            this.retryPolicy = this.settings.RetryPolicy ?? RetryPolicy.NoRetry;
            this.senderRoleID = FrameworkUtility.GetHashedValue(CloudEnvironment.DeploymentId, CloudEnvironment.CurrentRoleName);
            this.senderInstanceID = FrameworkUtility.GetHashedValue(CloudEnvironment.DeploymentId, CloudEnvironment.CurrentRoleInstanceId);

            // Configure Service Bus credentials and service namespace URI.
            var credentials = TokenProvider.CreateSharedSecretTokenProvider(serviceBusEndpoint.IssuerName, serviceBusEndpoint.IssuerSecret);
            var address = ServiceBusEnvironment.CreateServiceUri("sb", serviceBusEndpoint.ServiceNamespace, String.Empty);

            // Configure Service Bus messaging factory and namespace client which is required for subscription management.
            this.messagingFactory = MessagingFactory.Create(address, credentials);
            this.nsManager = new NamespaceManager(address, credentials);

            // Figure out the name of the subscription. If subscription name was specified in the endpoint definition, treat it as static.
            // If no subscription name was specified, assign a globally unique name based on hashed deployment ID and role instance ID values.
            this.useStaticSubscription = !String.IsNullOrEmpty(serviceBusEndpoint.SubscriptionName);
            this.ircSubscriptionName = this.useStaticSubscription ? serviceBusEndpoint.SubscriptionName : (this.settings.UseCompetingConsumers ? String.Concat(SubscriptionNamePrefix, this.senderRoleID) : String.Concat(SubscriptionNamePrefix, this.senderInstanceID));

            // Configure the underlying messaging entities such as topic and subscription.
            ConfigureTopicClient(this.serviceBusEndpoint.TopicName);
            ConfigureSubscriptionClient(this.ircSubscriptionName);

            // Configure a fault handler for the receive action.
            this.receiveFaultAction = ((msg, ex) =>
            {
                // Log an error.
                TraceManager.ServiceComponent.TraceError(ex);

                try
                {
                    if (msg != null)
                    {
                        // Abandons a brokered message. This will cause Service Bus to unlock the message and make it available to be received again, 
                        // either by the same consumer or by another completing consumer.
                        msg.Abandon(this.retryPolicy);
                    }
                }
                catch (MessageLockLostException)
                {
                    // It's too late to compensate the loss of a message lock. Should just ignore it so that it does not break the receive loop.
                }
                catch (CommunicationObjectAbortedException)
                {
                    // There is nothing we can do as connection might have been lost or underlying topic/subscription might have been removed.
                }
                catch (CommunicationObjectFaultedException)
                {
                    // If Abandon fail with this exception, the only recourse is to Receive another message (possibly the same one).
                }
            });

            // Configure event receive action.
            this.receiveAction = (() =>
            {
                BrokeredMessage msg = null;
                bool completedAsync = false;

                this.retryPolicy.ExecuteAction(() =>
                {
                    // Make sure we are not told to stop receiving while we are retrying.
                    if (!cts.IsCancellationRequested)
                    {
#if PERF_TEST
                        Stopwatch watch = Stopwatch.StartNew();
#endif
                        if ((msg = this.subscriptionClient.Receive(this.settings.EventWaitTimeout)) != null)
                        {
#if PERF_TEST
                            watch.Stop();
                            TraceManager.ServiceComponent.TraceDetails("Waited for a new event for {0}ms", watch.ElapsedMilliseconds);
#endif
                            try
                            {
                                // Make sure we are not told to stop receiving while we were waiting for a new message.
                                if (!this.cts.IsCancellationRequested)
                                {
                                    if (this.settings.EnableAsyncDispatch)
                                    {
                                        // Invoke the dispatch action asynchronously.
                                        this.dispatchAction.BeginInvoke(msg, this.endDispatch, msg);

                                        completedAsync = true;
                                    }
                                    else
                                    {
                                        // Invoke the dispatch action synchronously.
                                        this.dispatchAction(msg);

                                        // Mark brokered message as complete.
                                        msg.Complete(this.retryPolicy);
                                    }
                                }
                                else
                                {
                                    // If we were told to stop processing, the current message needs to be unlocked and return back to the queue.
                                    msg.Abandon(this.retryPolicy);
                                }
                            }
                            catch (Exception ex)
                            {
                                this.receiveFaultAction(msg, ex);
                            }
                            finally
                            {
                                // Do not attempt to dispose a BrokeredMessage instance if it was dispatched for processing asynchronously.
                                if (msg != null && !completedAsync)
                                {
                                    // Ensure that any resources allocated by a BrokeredMessage instance are released.
                                    msg.Dispose();
                                }
                            }
                        }
                    }
                });
            });

            // Configure event receive complete action.
            this.endReceive = ((ar) =>
            {
                try
                {
                    this.receiveAction.EndInvoke(ar);
                }
                catch (Exception ex)
                {
                    // Log this error. Do not allow an unhandled exception to kill the current process.
                    TraceManager.ServiceComponent.TraceError(ex);
                }

                if (!cts.IsCancellationRequested)
                {
                    this.receiveHandle = this.receiveAction.BeginInvoke(this.endReceive, null);
                }
            });

            // Configure event dispatch action. This action is performed when notifying subscribers about a new IRC event.
            this.dispatchAction = ((msg) =>
            {
                // Extract the event data from brokered message.
                InterRoleCommunicationEvent e = msg.GetBody<InterRoleCommunicationEvent>(this.serializer);

                // Notify all registered subscribers.
                NotifySubscribers(e);
            });

            this.endDispatch = ((ar) =>
            {
                BrokeredMessage msg = null;

                try
                {
                    msg = ar.AsyncState as BrokeredMessage;
                    this.dispatchAction.EndInvoke(ar);

                    if (msg != null)
                    {
                        // Mark brokered message as complete.
                        msg.Complete(this.retryPolicy);
                    }
                }
                catch (Exception ex)
                {
                    this.receiveFaultAction(msg, ex);
                }
                finally
                {
                    if (msg != null)
                    {
                        // Ensure that any resources allocated by a BrokeredMessage instance are released.
                        msg.Dispose();
                    }
                }
            });
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Returns runtime settings for the <see cref="InterRoleCommunicationExtension"/> component.
        /// </summary>
        public InterRoleCommunicationSettings Settings
        {
            get { return this.settings; }
        }
        #endregion

        #region IInterRoleCommunicationServiceContract implementation
        /// <summary>
        /// Publishes the specified inter-role communication event into publish/subscribe messaging infrastructure.
        /// </summary>
        /// <param name="e">The inter-role communication event to be published.</param>
        public void Publish(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

            var from = e.From = (this.settings.UseCompetingConsumers ? this.senderRoleID : this.senderInstanceID);
            var to = String.IsNullOrEmpty(e.To) ? MsgCtxPropValueAny : e.To;

            Func<BrokeredMessage> createMessage = () =>
            {
                var msg = new BrokeredMessage(e, this.serializer);

                // Configure event routing properties.
                msg.Properties[MsgCtxPropNameFrom] = from;
                msg.Properties[MsgCtxPropNameTo] = to;

                // Configure other message properties and settings.
                msg.TimeToLive = this.settings.EventTimeToLive;

                return msg;
            };

            // Check if we should perform the send operation asynchronously.
            if (this.settings.EnableAsyncPublish)
            {
                // Declare a BrokeredMessage instance outside the consuming actions so that it can be reused across all 3 delegates below.
                BrokeredMessage msg = null;
#if PERF_TEST
                Stopwatch watch = Stopwatch.StartNew();
#endif
                // Use a retry policy to execute the Send action in an asynchronous and reliable fashion.
                this.retryPolicy.ExecuteAction
                (
                    (cb) =>
                    {
                        // A new BrokeredMessage instance must be created each time we send it. Reusing the original BrokeredMessage instance may not work as 
                        // the state of its BodyStream cannot be guaranteed to be readable from the beginning.
                        msg = createMessage();

                        // Send the event asynchronously.
                        this.topicClient.BeginSend(msg, cb, null);
                    },
                    (ar) =>
                    {
                        try
                        {
                            // Complete the asynchronous operation. This may throw an exception that will be handled internally by the retry policy.
                            this.topicClient.EndSend(ar);
#if PERF_TEST
                            watch.Stop();
                            TraceManager.ServiceComponent.TraceDetails("Publishing message into a topic took {0}ms", watch.ElapsedMilliseconds);
#endif
                        }
                        finally
                        {
                            // Ensure that any resources allocated by a BrokeredMessage instance are released.
                            if (msg != null)
                            {
                                msg.Dispose();
                                msg = null;
                            }
                        }
                    },
                    (ex) =>
                    {
                        // Always dispose the BrokeredMessage instance even if the send operation has completed unsuccessfully.
                        if (msg != null)
                        {
                            msg.Dispose();
                            msg = null;
                        }

                        // Always log exceptions regardless what fault subscribers are doing with the exceptions.
                        TraceManager.ServiceComponent.TraceError(ex);

                        // Notify all registered fault handlers about this exception.
                        foreach (var handler in this.faultHandlers)
                        {
                            try
                            {
                                // Provide the fault observer with exception and original event.
                                handler.Key.OnNext(Tuple.Create<Exception, InterRoleCommunicationEvent>(ex, e));
                            }
                            catch (Exception fault)
                            {
                                // Notify the fault observer that we experienced an error condition.
                                handler.Key.OnError(fault);
                            }
                        }
                    }
                );
            }
            else
            {
#if PERF_TEST
                using (TraceManager.ServiceComponent.TraceScope("Publishing message into a topic", e.From, e.To))
#endif
                {
                    // Send the event synchronously, use retry logic to ensure a reliable operation.
                    this.retryPolicy.ExecuteAction(() => 
                    {
                        var msg = createMessage();

                        try
                        {
                            this.topicClient.Send(msg);
                        }
                        finally
                        {
                            // Ensure that any resources allocated by a BrokeredMessage instance are released.
                            if (msg != null)
                            {
                                msg.Dispose();
                            }
                        }
                    });
                }
            }
        }
        #endregion

        #region IObservable<InterRoleCommunicationEvent> implementation
        /// <summary>
        /// Registers the specified subscriber to receive inter-role communication events.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <returns>The instance of an object that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<InterRoleCommunicationEvent> observer)
        {
            Guard.ArgumentNotNull(observer, "observer");

            bool firstSubscriber = (this.subscribers.Count == 0);

            this.subscribers.AddOrUpdate(observer, 0, (key, oldValue) => { return oldValue + 1; });

            if (firstSubscriber)
            {
                // Start receiving events asynchronously.
                this.receiveHandle = this.receiveAction.BeginInvoke(this.endReceive, null);
            }

            // Return a special object that provides the ability to cancel this subscription.
            return new AnonymousDisposable(() =>
            {
                int count;
                this.subscribers.TryRemove(observer, out count);

                // When the very last subscriber has been deactivated, it's a good time to stop
                // receiving events from the IRC topic.
                if (this.subscribers.Count == 0)
                {
                    this.cts.Cancel();
                }
            });
        }

        /// <summary>
        /// Registers the specified subscriber to receive notifications when inter-role communication events fail to have been processed asynchronously.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <returns>The instance of an object that enables a subscription to be cancelled by the subscriber.</returns>
        public IDisposable Subscribe(IObserver<Tuple<Exception, InterRoleCommunicationEvent>> observer)
        {
            Guard.ArgumentNotNull(observer, "observer");

            this.faultHandlers.AddOrUpdate(observer, 0, (key, oldValue) => { return oldValue + 1; });

            // Return a special object that provides the ability to cancel this subscription.
            return new AnonymousDisposable(() =>
            {
                int count;
                this.faultHandlers.TryRemove(observer, out count);
            });
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">A flag indicating that managed resources must be released.</param>
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.cts != null)
                    {
                        try
                        {
                            this.cts.Cancel();

                            // Wait for receive operation to complete gracefully.
                            if (this.receiveHandle != null)
                            {
                                this.receiveHandle.AsyncWaitHandle.WaitOne(this.settings.EventWaitTimeout);
                            }
                        }
                        catch
                        {
                            // We should not fail while disposing.
                        }
                        finally
                        {
                            this.cts.Dispose();
                        }
                    }

                    if (this.topicClient != null)
                    {
                        this.topicClient.SafeClose();
                        this.topicClient = null;
                    }

                    if (this.subscriptionClient != null)
                    {
                        this.subscriptionClient.SafeClose();
                        this.subscriptionClient = null;
                    }

                    if (this.messagingFactory != null)
                    {
                        this.messagingFactory.SafeClose();
                        this.messagingFactory = null;
                    }

                    try
                    {
                        // Only remove the subscription if it's not static. We don't own static subscriptions (those that are defined in the endpoint definition with a specific name).
                        // We should also not remove subscriptions if competing consumers pattern is enforced.
                        if (!useStaticSubscription && !this.settings.UseCompetingConsumers)
                        {
                            RemoveSubscription(this.ircSubscriptionName);
                        }
                    }
                    catch
                    {
                        // We should not fail while disposing.
                    }

                    // Clean up internal collections.
                    this.subscribers.Clear();
                    this.faultHandlers.Clear();

                    this.disposed = true;
                }
            }
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~InterRoleCommunicationExtension()
        {
            this.Dispose(false);
        }
        #endregion

        #region Private methods
        private void ConfigureTopicClient(string topicName)
        {
            Guard.ArgumentNotNullOrEmptyString(topicName, "topicName");
            Guard.ArgumentNotNull(this.nsManager, "nsManager");
            Guard.ArgumentNotNull(this.messagingFactory, "messagingFactory");
            Guard.ArgumentNotNull(this.retryPolicy, "retryPolicy");

            TopicDescription ircTopic = null;
            
#if PERF_TEST
            using (TraceManager.WorkerRoleComponent.TraceScope("Configuring IRC topic", topicName))
#endif
            {
                bool createNew = false;

                try
                {
                    // First, let's see if the specified topic name already exists.
                    ircTopic = this.retryPolicy.ExecuteAction<TopicDescription>(() =>
                    {
                        return this.nsManager.GetTopic(topicName);
                    });

                    createNew = (ircTopic == null);
                }
                catch (MessagingEntityNotFoundException)
                {
                    createNew = true;
                }

                // If a topic with the specified name doesn't exist, it will be auto-created.
                if (createNew)
                {
                    try
                    {
                        var newTopic = new TopicDescription(topicName) { DefaultMessageTimeToLive = Settings.EventTimeToLive, EnableBatchedOperations = true };

                        ircTopic = this.retryPolicy.ExecuteAction<TopicDescription>(() =>
                        {
                            return this.nsManager.CreateTopic(newTopic);
                        });
                    }
                    catch (MessagingEntityAlreadyExistsException)
                    {
                        // A topic under the same name was already created by someone else - not a problem, we will reuse the existing topic.
                        ircTopic = this.retryPolicy.ExecuteAction<TopicDescription>(() =>
                        {
                            return this.nsManager.GetTopic(topicName);
                        });
                    }
                }
            }

            if (null == ircTopic)
            {
                throw new ApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.TopicCannotBeCreatedOrFound, topicName));
            }

#if PERF_TEST
            using (TraceManager.WorkerRoleComponent.TraceScope("Configuring IRC topic client", topicName))
#endif
            {
                this.retryPolicy.ExecuteAction(() =>
                {
                    try
                    {
                        // These actions must be performed atomically inside a retry loop for additional resilience.
                        // We should not retry each individual action as state of the underlying communication objects may not be guaranteed.
                        this.topicClient = this.messagingFactory.CreateTopicClient(ircTopic.Path);
                    }
                    catch
                    {
                        // We should not handle any exceptions here as these will be handled by the retry policy logic.
                        // The main purpose of this catch block is to ensure the state of the underlying communication objects is reset if an error occurs.
                        if (this.topicClient != null)
                        {
                            this.topicClient.SafeClose();
                        }

                        // Re-throw the original exception so that it can be handled by the retry policy.
                        throw;
                    }
                });
            }
        }

        private void ConfigureSubscriptionClient(string subscriptionName)
        {
            Guard.ArgumentNotNullOrEmptyString(subscriptionName, "subscriptionName");
            Guard.ArgumentNotNull(this.serviceBusEndpoint, "serviceBusEndpoint");
            Guard.ArgumentNotNull(this.nsManager, "nsManager");

            SubscriptionDescription ircSubscription = null;
            
#if PERF_TEST
            using (TraceManager.WorkerRoleComponent.TraceScope("Configuring IRC subscription", subscriptionName))
#endif
            {
                bool createNew = false;

                try
                {
                    // // First, let's see if the specified subscription name already exists in the given topic.
                    ircSubscription = this.retryPolicy.ExecuteAction<SubscriptionDescription>(() =>
                    {
                        return this.nsManager.GetSubscription(this.serviceBusEndpoint.TopicName, subscriptionName);
                    });

                    createNew = (ircSubscription == null);
                }
                catch (MessagingEntityNotFoundException)
                {
                    createNew = true;
                }

                // If a topic with the specified name doesn't exist, it will be auto-created.
                if (createNew)
                {
                    try
                    {
                        var newSubscription = new SubscriptionDescription(this.serviceBusEndpoint.TopicName, subscriptionName)
                        { 
                            LockDuration = this.Settings.EventLockDuration, 
                            EnableBatchedOperations = true, 
                            EnableDeadLetteringOnMessageExpiration = true, 
                        };
                        
                        var expressionBuilder = new StringBuilder();

                        // Check whether we deal with static or dynamic subscriptions.
                        if (this.useStaticSubscription)
                        {
                            // If a static subscription doesn't exist, it will be created with a filter expression matching all messages and messages for a given role.
                            expressionBuilder.AppendFormat("{0}='{1}' OR {0}='{2}'", MsgCtxPropNameTo, MsgCtxPropValueAny, this.senderRoleID);
                        }
                        else
                        {
                            if (this.settings.UseCompetingConsumers)
                            {
                                expressionBuilder.AppendFormat("{0}='{1}' OR {0}='{2}'", MsgCtxPropNameTo, MsgCtxPropValueAny, this.senderRoleID);
                            }
                            else
                            {
                                if (!this.settings.EnableCarbonCopy)
                                {
                                    expressionBuilder.AppendFormat("{0}<>'{1}'", MsgCtxPropNameFrom, this.senderInstanceID);
                                    expressionBuilder.Append(" AND ");
                                }

                                expressionBuilder.AppendFormat("({0}='{1}' OR {0}='{2}' OR {0}='{3}')", MsgCtxPropNameTo, MsgCtxPropValueAny, this.senderRoleID, this.senderInstanceID);
                            }
                        }

                        ircSubscription = this.retryPolicy.ExecuteAction<SubscriptionDescription>(() =>
                        {
                            return this.nsManager.CreateSubscription(newSubscription, new SqlFilter(expressionBuilder.ToString()));
                        });
                    }
                    catch (MessagingEntityAlreadyExistsException)
                    {
                        // A subscription under the same name was already created - not a problem, we will reuse the existing subscription.
                        ircSubscription = this.retryPolicy.ExecuteAction<SubscriptionDescription>(() =>
                        {
                            return this.nsManager.GetSubscription(this.serviceBusEndpoint.TopicName, subscriptionName);
                        });
                    }
                }
            }

            if (null == ircSubscription)
            {
                throw new ApplicationException(String.Format(CultureInfo.CurrentCulture, ExceptionMessages.SubscriptionCannotBeCreatedOrFound, subscriptionName));
            }

#if PERF_TEST
            using (TraceManager.ServiceComponent.TraceScope("Configuring SB subscription client", ircSubscription.Name))
#endif
            {
                this.retryPolicy.ExecuteAction(() =>
                {
                    try
                    {
                        // These actions must be performed atomically inside a retry loop for additional resilience.
                        // We should not retry each individual action as state of the underlying communication objects may not be guaranteed.
                        this.subscriptionClient = this.messagingFactory.CreateSubscriptionClient(ircSubscription.TopicPath, ircSubscription.Name, ReceiveMode.PeekLock);
                    }
                    catch
                    {
                        // We should not handle any exceptions here as these will be handled by the retry policy logic.
                        // The main purpose of this catch block is to ensure the state of the underlying communication objects is reset if an error occurs.
                        if (this.subscriptionClient != null)
                        {
                            this.subscriptionClient.SafeClose();
                        }

                        // Re-throw the original exception so that it can be handled by the retry policy.
                        throw;
                    }
                });
            }
        }

        private void RemoveSubscription(string subscriptionName)
        {
            Guard.ArgumentNotNullOrEmptyString(subscriptionName, "subscriptionName");
            Guard.ArgumentNotNull(this.nsManager, "nsManager");

#if PERF_TEST
            using (TraceManager.ServiceComponent.TraceScope("Removing IRC subscription", subscriptionName))
#endif
            {
                this.retryPolicy.ExecuteAction(() =>
                {
                    if (this.nsManager.SubscriptionExists(this.serviceBusEndpoint.TopicName, subscriptionName))
                    {
                        try
                        {
                            this.nsManager.DeleteSubscription(this.serviceBusEndpoint.TopicName, subscriptionName);
                        }
                        catch (Exception ex)
                        {
                            TraceManager.ServiceComponent.TraceError(ex);
                        }
                    }
                });
            }
        }

        private void NotifySubscribers(InterRoleCommunicationEvent e)
        {
            Guard.ArgumentNotNull(e, "e");

#if PERF_TEST
            using (TraceManager.ServiceComponent.TraceScope("Notifying all subscribers", e.From, e.To))
#endif
            {
                Action<IObserver<InterRoleCommunicationEvent>> notifyAction = ((subscriber) =>
                {
                    try
                    {
                        // Notify the subscriber.
                        subscriber.OnNext(e);
                    }
                    catch (Exception ex)
                    {
                        // Do not allow any subscriber to generate a fault and affect other subscribers.
                        try
                        {
                            // Notifies the subscriber that the event provider has experienced an error condition.
                            subscriber.OnError(ex);
                        }
                        catch (Exception fault)
                        {
                            // Log an error.
                            TraceManager.ServiceComponent.TraceError(fault);
                        }
                    }
                });

                // Only parallelize when enabled and there is more than 1 active subscribers.
                if (this.Settings.EnableParallelDispatch && this.subscribers.Count > 1)
                {
                    // Invokes the specified action for each subscriber in parallel.
                    Parallel.ForEach(this.subscribers, ((s) => notifyAction(s.Key)));
                }
                else
                {
                    foreach (var s in this.subscribers)
                    {
                        notifyAction(s.Key);
                    }
                }
            }
        }
        #endregion
    }
}
