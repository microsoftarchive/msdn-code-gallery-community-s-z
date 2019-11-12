//-----------------------------------------------------------------------
// <copyright file="ContextEventWrapper.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
// This file contains the internal classes used to track the synchronization
// context and events handling.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.Kinect.Toolkit
{
    using System;
    using System.Threading;

    /// <summary>
    /// The possible methods for sending data to the synchronization context.
    /// </summary>
    public enum ContextSynchronizationMethod
    {
        /// <summary>
        /// The send method is used to pass synchronous message to the context.
        /// </summary>
        Send,

        /// <summary>
        /// The post method is used to pass an asynchronous message to the context.
        /// </summary>
        Post
    }

    /// <summary>
    /// Wrapper that holds a collection of event handlers for a specific type and associates
    /// a context with them.
    /// </summary>
    /// <typeparam name="T">EventArgs for the specific event.</typeparam>
    /// <remarks>
    /// Note that this has the implementation of IDisposable but not the interface.
    /// You may call Dispose on it if you need to.  Otherwise you can let the GC handle
    /// things.
    /// </remarks>
    public class ContextEventWrapper<T> where T : EventArgs 
    {
        /// <summary>
        /// This holds the list of context to handler mappings.
        /// </summary>
        private readonly ThreadSafeCollection<ContextHandlerPair> actualHandlers;

        /// <summary>
        /// This is the method used process the message by the synchronization context.
        /// </summary>
        private readonly ContextSynchronizationMethod method;

        /// <summary>
        /// This keeps track of the disposed state of the object.
        /// </summary>
        private bool isDisposed;
        
        /// <summary>
        /// Initializes a new instance of the ContextEventWrapper class.
        /// </summary>
        /// <param name="method">Determines whether the context will use Post or Send. Default is Post.</param>
        public ContextEventWrapper(ContextSynchronizationMethod method)
        {
            isDisposed = false;
            this.method = method;
            actualHandlers = new ThreadSafeCollection<ContextHandlerPair>();
        }

        /// <summary>
        /// Initializes a new instance of the ContextEventWrapper class.
        /// </summary>
        public ContextEventWrapper() : this(ContextSynchronizationMethod.Post)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this wrapper has any actual handlers registered.
        /// </summary>
        public bool HasHandlers
        {
            get { return actualHandlers.Count > 0; }
        }

        /// <summary>
        /// Adds an event handler and associates it with the current context.
        /// </summary>
        /// <param name="originalHandler">The new event to add to the list of handlers.</param>
        public void AddHandler(EventHandler<T> originalHandler)
        {
            if (originalHandler != null)
            {
                actualHandlers.Add(new ContextHandlerPair(originalHandler, SynchronizationContext.Current));
            }
        }

        /// <summary>
        /// Removes the event handler associated with the current context.
        /// </summary>
        /// <param name="originalHandler">The event to remove from the list of handlers.</param>
        public void RemoveHandler(EventHandler<T> originalHandler)
        {
            SynchronizationContext currentContext = SynchronizationContext.Current;
            ContextHandlerPair pairToRemove = null;

            // Find the first matching pair
            foreach (ContextHandlerPair pair in actualHandlers)
            {
                EventHandler<T> handler = pair.Handler;
                SynchronizationContext context = pair.Context;

                if (currentContext == context && handler == originalHandler)
                {
                    // Stop on first find
                    pairToRemove = pair;
                    break;
                }
            }

            // remove if found
            if (pairToRemove != null)
            {
                actualHandlers.Remove(pairToRemove);
            }
        }

        /// <summary>
        /// Invokes all registered event handlers.
        /// </summary>
        /// <param name="sender">The sender of the message.</param>
        /// <param name="eventArgs">The event arguments to be passed to the handler.</param>
        public void Invoke(object sender, T eventArgs)
        {
            if (HasHandlers)
            {
                // Invoke each handler on the list
                // Note:  Enumerator is a snapshotting enumerator, so this is thread-safe and reentrency safe.
                foreach (ContextHandlerPair pair in actualHandlers)
                {
                    EventHandler<T> handler = pair.Handler;
                    SynchronizationContext context = pair.Context;

                    if (context == null)
                    {
                        handler(sender, eventArgs);
                    }
                    else if (method == ContextSynchronizationMethod.Post)
                    {
                        context.Post(SendOrPostDelegate, new ContextEventHandlerArgsWrapper(handler, sender, eventArgs));
                    }
                    else if (method == ContextSynchronizationMethod.Send)
                    {
                        context.Send(SendOrPostDelegate, new ContextEventHandlerArgsWrapper(handler, sender, eventArgs));
                    }
                }
            }
        }

        /// <summary>
        /// This method marks the object as disposed.
        /// </summary>
        public void Dispose()
        {
            isDisposed = true;
            actualHandlers.Clear();
        }

        /// <summary>
        /// Internal handler that matches the delegates for SynchronizationContext.Post/Send.
        /// </summary>
        /// <param name="state">State packed as ContextEventHandlerArgsWrapper ( handler + sender + args ).</param>
        private void SendOrPostDelegate(object state)
        {
            // This can get disposed before the marshalling is done
            if (isDisposed)
            {
                return;
            }

            var currentState = (ContextEventHandlerArgsWrapper)state;
            currentState.Handler(currentState.Sender, currentState.Args);
        }

        /// <summary>
        /// Container class to hold event handler, sender and args so that it can be
        /// marshalled using the Synchronization context.
        /// </summary>
        private class ContextEventHandlerArgsWrapper
        {
            /// <summary>
            /// Initializes a new instance of the ContextEventHandlerArgsWrapper class.
            /// </summary>
            /// <param name="handler">The event handler.</param>
            /// <param name="sender">The sending object.</param>
            /// <param name="args">The argument object.</param>
            public ContextEventHandlerArgsWrapper(EventHandler<T> handler, object sender, T args)
            {
                Handler = handler;
                Sender = sender;
                Args = args;
            }

            /// <summary>
            /// Gets the associated event handler.
            /// </summary>
            public EventHandler<T> Handler { get; private set; }
            
            /// <summary>
            /// Gets the sending object.
            /// </summary>
            public object Sender { get; private set; }

            /// <summary>
            /// Gets the event arguments object.
            /// </summary>
            public T Args { get; private set; }
        }

        /// <summary>
        /// Container class to associate an event handler with a context so that they
        /// act as a single key in a list.
        /// </summary>
        private class ContextHandlerPair
        {
            /// <summary>
            /// Initializes a new instance of the ContextHandlerPair class.
            /// </summary>
            /// <param name="handler">The target handler.</param>
            /// <param name="context">The target context.</param>
            public ContextHandlerPair(EventHandler<T> handler, SynchronizationContext context)
            {
                Handler = handler;
                Context = context;
            }

            /// <summary>
            /// Gets the associated synchronization context.
            /// </summary>
            public SynchronizationContext Context { get; private set; }

            /// <summary>
            /// Gets the associated event handler.
            /// </summary>
            public EventHandler<T> Handler { get; private set; }
        }
    }
}
