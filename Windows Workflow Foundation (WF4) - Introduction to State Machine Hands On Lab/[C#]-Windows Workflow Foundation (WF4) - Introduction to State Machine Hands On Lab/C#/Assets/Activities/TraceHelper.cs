// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TraceHelper.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Helper for writing debug messages
    /// </summary>
    public static class TraceHelper
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes static members of the <see cref = "TraceHelper" /> class.
        /// </summary>
        static TraceHelper()
        {
            Level = TraceLevel.Info;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets Level.
        /// </summary>
        public static TraceLevel Level { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Outputs a debug message with the thread
        /// </summary>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// optional args.
        /// </param>
        public static void Write(TraceLevel level, string format, params object[] args)
        {
            if (level <= Level)
            {
                Trace.WriteLine(
                    string.Format("{0,3:0} {1}", Thread.CurrentThread.ManagedThreadId, string.Format(format, args)));
            }
        }

        #endregion
    }
}