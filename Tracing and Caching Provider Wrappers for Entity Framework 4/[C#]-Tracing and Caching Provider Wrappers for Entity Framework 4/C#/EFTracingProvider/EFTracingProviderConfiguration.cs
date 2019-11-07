// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Configuration;
using System.Data;
using EFProviderWrapperToolkit;

namespace EFTracingProvider
{
    /// <summary>
    /// Configuration of EFTracingProvider.
    /// </summary>
    /// <remarks>
    /// Default values for properties of this class are obtained by reading configuration file:
    /// <para>'EFTracingProvider.logToConsole' parameter supplies default value for <see cref="LogToConsole"/>.</para>
    /// <para>'EFTracingProvider.logToFile' parameter supplies default value for <see cref="LogToConsole"/>.</para>
    /// </remarks>
    public static class EFTracingProviderConfiguration
    {
        /// <summary>
        /// Initializes static members of the EFTracingProviderConfiguration class.
        /// </summary>
        static EFTracingProviderConfiguration()
        {
            DefaultWrappedProvider = ConfigurationManager.AppSettings["EFTracingProvider.wrappedProvider"];
            LogToConsole = ConfigurationManager.AppSettings["EFTracingProvider.logToConsole"] == "true";
            LogToFile = ConfigurationManager.AppSettings["EFTracingProvider.logToFile"];
            if (string.IsNullOrEmpty(LogToFile))
            {
                LogToFile = null;
            }
        }

        /// <summary>
        /// Gets or sets the default wrapped provider.
        /// </summary>
        /// <value>The default wrapped provider.</value>
        public static string DefaultWrappedProvider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to log to console for all new connections.
        /// </summary>
        /// <value>A value of <c>true</c> if new connections should log all statements to the console; otherwise, <c>false</c>.</value>
        public static bool LogToConsole { get; set; }

        /// <summary>
        /// Gets or sets the name of the log file for newly created connections.
        /// </summary>
        /// <value>The log to file.</value>
        public static string LogToFile { get; set; }

        /// <summary>
        /// Gets or sets the action to be executed before and after every command.
        /// </summary>
        /// <value>The log action.</value>
        public static Action<CommandExecutionEventArgs> LogAction { get; set; }

        /// <summary>
        /// Registers the provider factory 
        /// </summary>
        public static void RegisterProvider()
        {
            DbProviderFactoryBase.RegisterProvider("EF Tracing Data Provider", "EFTracingProvider", typeof(EFTracingProviderFactory));
        }
    }
}
