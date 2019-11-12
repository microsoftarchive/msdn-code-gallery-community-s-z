// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace EFTracingProvider
{
    /// <summary>
    /// Command Execution Status
    /// </summary>
    public enum CommandExecutionStatus
    {
        /// <summary>
        /// The command is executing.
        /// </summary>
        Executing,

        /// <summary>
        /// The command has finished.
        /// </summary>
        Finished,

        /// <summary>
        /// The command has failed.
        /// </summary>
        Failed,
    }
}
