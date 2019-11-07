// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;

using EFProviderWrapperToolkit;

namespace EFTracingProvider
{
    /// <summary>
    /// Implementation of <see cref="DbCommand"/> which traces all commands executed.
    /// </summary>
    internal class EFTracingCommand : DbCommandWrapper
    {
        private static int globalCommandID;

        /// <summary>
        /// Initializes a new instance of the EFTracingCommand class.
        /// </summary>
        /// <param name="wrappedCommand">The wrapped command.</param>
        /// <param name="commandDefinition">The command definition.</param>
        public EFTracingCommand(DbCommand wrappedCommand, DbCommandDefinitionWrapper commandDefinition)
            : base(wrappedCommand, commandDefinition)
        {
            this.CommandID = Interlocked.Increment(ref globalCommandID);
        }

        /// <summary>
        /// Gets the unique command ID.
        /// </summary>
        /// <value>The command ID.</value>
        public int CommandID { get; private set; }

        /// <summary>
        /// Gets the <see cref="EFTracingConnection"/> used by this <see cref="T:System.Data.Common.DbCommand"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The connection to the data source.
        /// </returns>
        private new EFTracingConnection Connection
        {
            get { return (EFTracingConnection)base.Connection; }
        }

        /// <summary>
        /// Executes the query and returns the first column of the first row in the result set returned by the query. All other columns and rows are ignored.
        /// </summary>
        /// <returns>
        /// The first column of the first row in the result set.
        /// </returns>
        public override object ExecuteScalar()
        {
            CommandExecutionEventArgs e = new CommandExecutionEventArgs(this, "ExecuteScalar");
            e.Status = CommandExecutionStatus.Executing;
            this.Connection.RaiseExecuting(e);
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                object result = base.ExecuteScalar();
                sw.Stop();
                e.Result = result;
                e.Duration = sw.Elapsed;
                e.Status = CommandExecutionStatus.Finished;
                this.Connection.RaiseFinished(e);
                return result;
            }
            catch (Exception ex)
            {
                e.Result = ex;
                e.Status = CommandExecutionStatus.Failed;
                this.Connection.RaiseFailed(e);
                throw;
            }
        }

        /// <summary>
        /// Executes a SQL statement against a connection object.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public override int ExecuteNonQuery()
        {
            CommandExecutionEventArgs e = new CommandExecutionEventArgs(this, "ExecuteNonQuery");
            e.Status = CommandExecutionStatus.Executing;
            Stopwatch sw = new Stopwatch();
            this.Connection.RaiseExecuting(e);
            try
            {
                sw.Start();
                int result = base.ExecuteNonQuery();
                sw.Stop();
                e.Result = result;
                e.Duration = sw.Elapsed;
                e.Status = CommandExecutionStatus.Finished;
                this.Connection.RaiseFinished(e);
                return result;
            }
            catch (Exception ex)
            {
                e.Result = ex;
                e.Status = CommandExecutionStatus.Failed;
                this.Connection.RaiseFailed(e);
                throw;
            }
        }

        /// <summary>
        /// Executes the command text against the connection.
        /// </summary>
        /// <param name="behavior">An instance of <see cref="T:System.Data.CommandBehavior"/>.</param>
        /// <returns>
        /// A <see cref="T:System.Data.Common.DbDataReader"/>.
        /// </returns>
        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            CommandExecutionEventArgs e = new CommandExecutionEventArgs(this, "ExecuteReader");
            e.Status = CommandExecutionStatus.Executing;
            this.Connection.RaiseExecuting(e);
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                DbDataReader result = base.ExecuteDbDataReader(behavior);
                sw.Stop();
                e.Result = result;
                e.Status = CommandExecutionStatus.Finished;
                e.Duration = sw.Elapsed;
                this.Connection.RaiseFinished(e);
                return result;
            }
            catch (Exception ex)
            {
                e.Result = ex;
                e.Status = CommandExecutionStatus.Failed;
                this.Connection.RaiseFailed(e);
                throw;
            }
        }
    }
}
