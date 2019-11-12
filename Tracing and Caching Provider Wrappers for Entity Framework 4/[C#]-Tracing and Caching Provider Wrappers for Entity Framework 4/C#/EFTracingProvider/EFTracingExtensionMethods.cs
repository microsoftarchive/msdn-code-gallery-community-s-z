// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Common;
using System.Data.Objects;
using System.IO;
using EFProviderWrapperToolkit;

namespace EFTracingProvider
{
    /// <summary>
    /// Extension methods for EFTracingProvider.
    /// </summary>
    public static class EFTracingExtensionMethods
    {
        /// <summary>
        /// Gets the instance of the wrapped <see cref="EFTracingConnection" /> from <see cref="ObjectContext"/>.
        /// </summary>
        /// <param name="context">The object context.</param>
        /// <returns>Instance of <see cref="EFTracingConnection"/>.</returns>
        public static EFTracingConnection GetTracingConnection(this ObjectContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            return GetTracingConnection(context.Connection);
        }

        /// <summary>
        /// Gets the instance of the wrapped <see cref="EFTracingConnection" /> from <see cref="DbConnection"/>.
        /// </summary>
        /// <param name="connection">The connection object.</param>
        /// <returns>Instance of <see cref="EFTracingConnection"/>.</returns>
        public static EFTracingConnection GetTracingConnection(this DbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            return connection.UnwrapConnection<EFTracingConnection>();
        }

        /// <summary>
        /// Sets the trace output.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="output">The output text writer.</param>
        public static void SetTraceOutput(this ObjectContext context, TextWriter output)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            SetTraceOutput(context.Connection, output);
        }

        /// <summary>
        /// Sets the trace output.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="output">The output text writer.</param>
        public static void SetTraceOutput(this DbConnection connection, TextWriter output)
        {
            connection.UnwrapConnection<EFTracingConnection>().CommandExecuting += (sender, e) => output.WriteLine(e.ToTraceString());
        }
    }
}
