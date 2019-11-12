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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation
{
    #region Using references
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Globalization;
    using System.Security.Principal;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Properties;
    #endregion

    /// <summary>
    /// Provides exception formatting capability to construct a detailed message about an exception for logging and tracing purposes.
    /// </summary>
    public sealed class ExceptionTextFormatter
    {
        #region Private members
        /// <summary>
        /// Name of the additional information entry that holds the header.
        /// </summary>
        private static string Header = Resources.ExceptionFormatterHeader;

        private static readonly ExceptionTextFormatter Singleton = new ExceptionTextFormatter(AppDomain.CurrentDomain.SetupInformation.ApplicationName);
        private static readonly Regex PropertyNameParserRegex = new Regex("(?<lc>[a-z])(?<uc>[A-Z])", RegexOptions.Compiled | RegexOptions.Singleline);
        
        private const char NewLine = '\n';
        private const string LineSeparator = "======================================";
        private const string EventTimestampFormatString = "dd/MM/yyyy HH:mm:ss.fff";

        private readonly NameValueCollection additionalInfo;
        private readonly string applicationName;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new instance of the <see cref="ExceptionTextFormatter"/> class.
        /// </summary>
        public ExceptionTextFormatter()
            : this(AppDomain.CurrentDomain.SetupInformation.ApplicationName)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="ExceptionTextFormatter"/> class with the application name.
        /// </summary>
        /// <param name="applicationName">The application name.</param>
        public ExceptionTextFormatter(string applicationName) : this(applicationName, new NameValueCollection(10))
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="ExceptionTextFormatter"/> class with the additional information and the application name.
        /// </summary>
        /// <param name="additionalInfo">The additional information to log.</param>
        /// <param name="applicationName">The application name.</param>
        public ExceptionTextFormatter(string applicationName, NameValueCollection additionalInfo)
        {
            this.applicationName = applicationName;
            this.additionalInfo = additionalInfo;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the formatted message to be logged.
        /// </summary>
        /// <param name="exception">The exception object whose information should be written to log file.</param>
        /// <returns>The formatted message.</returns>
        public static string Format(Exception exception)
        {
            return Singleton.FormatException(exception);
        }

        /// <summary>
        /// Gets the formatted message to be logged.
        /// </summary>
        /// <param name="exception">The exception object whose information should be written to log file.</param>
        /// <returns>The formatted message.</returns>
        public string FormatException(Exception exception)
        {
            return FormatException(exception, true);
        }

        /// <summary>
        /// Gets the formatted message to be logged.
        /// </summary>
        /// <param name="exception">The exception object whose information should be written to log file.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        /// <returns>The formatted message.</returns>
        public string FormatException(Exception exception, bool includeStackTrace)
        {
            StringBuilder eventInformation = new StringBuilder();
            CollectAdditionalInfo();

            // Record the contents of the AdditionalInfo collection.
            if (this.additionalInfo.Get(Header) != null)
            {
                eventInformation.AppendFormat("{0}{1}{1}", this.additionalInfo.Get(Header), NewLine);
            }

            eventInformation.AppendFormat("{1} {0}:{3}{2}", Resources.ExceptionSummary, this.applicationName, LineSeparator, NewLine);

            foreach (string info in this.additionalInfo)
            {
                if (info != Header)
                {
                    eventInformation.AppendFormat("{1}{0}", this.additionalInfo.Get(info), NewLine);
                }
            }

            if (exception != null)
            {
                Exception currException = exception;

                do
                {
                    // Dump the current exception's details.
                    ProcessException(currException, eventInformation, includeStackTrace);

                    // Jump to the next exception object.
                    currException = currException.InnerException;
                }
                while (currException != null);
            }

            return eventInformation.ToString();
        }
        #endregion

        #region Private methods
        private static void ProcessException(Exception ex, StringBuilder eventInfoBuilder, bool includeStackTrace)
        {
            eventInfoBuilder.AppendFormat("{2}{2}{0}{2}{1}", Resources.ExceptionDetails, LineSeparator, NewLine);
            eventInfoBuilder.AppendFormat("{2}{0}: {1}", Resources.ExceptionType, ex.GetType().FullName, NewLine);

            ProcessExceptionDetails(ex, eventInfoBuilder, includeStackTrace);

            // Record the StackTrace with separate label.
            if (includeStackTrace && ex.StackTrace != null)
            {
                eventInfoBuilder.AppendFormat("{2}{2}{0} {2}{1}", Resources.ExceptionStackTraceDetails, LineSeparator, NewLine);
                eventInfoBuilder.AppendFormat("{1}{0}", ex.StackTrace, NewLine);
            }
        }

        private static void ProcessExceptionDetails(Exception currException, StringBuilder eventInfoBuilder, bool includeStackTrace)
        {
            PropertyInfo[] publicProperties = currException.GetType().GetProperties();
            ICollection errors = null;

            foreach (PropertyInfo propInfo in publicProperties)
            {
                // Detect the presence of a collection of errors, this will go through a special handling.
                if (propInfo.Name == "Errors")
                {
                    object propValue = propInfo.GetValue(currException, null);

                    if (propValue != null)
                    {
                        errors = propValue as ICollection;
                    }
                }
                // Do not log information for the InnerException or StackTrace. This information is 
                // captured later in the process.
                else if (propInfo.Name != "InnerException" && propInfo.Name != "StackTrace")
                {
                    if (propInfo.GetValue(currException, null) != null)
                    {
                        ProcessAdditionalInfo(propInfo, currException, eventInfoBuilder);
                    }
                }
            }

            // Find out if we should include the collection of errors into exception details.
            if (errors != null && errors.Count > 0)
            {
                foreach (object error in errors)
                {
                    // Make sure that collection item is an exception.
                    Exception ex = error as Exception;

                    // Extra check to avoid troubles with exceptions referencing each other (if occurs).
                    if (ex != null && ex != currException)
                    {
                        ProcessException(ex, eventInfoBuilder, includeStackTrace);
                    }
                }
            }
        }

        private static void ProcessAdditionalInfo(PropertyInfo propInfo, Exception currException, StringBuilder stringBuilder)
        {
            // Loop through the collection of AdditionalInformation if the exception type is a BaseApplicationException.
            if (propInfo.Name == "AdditionalInformation")
            {
                object propValue = propInfo.GetValue(currException, null);

                if (propValue != null)
                {
                    // Cast the collection into a local variable.
                    NameValueCollection currAdditionalInfo = propValue as NameValueCollection;

                    // Check if the collection contains values.
                    if (currAdditionalInfo != null && currAdditionalInfo.Count > 0)
                    {
                        stringBuilder.AppendFormat("{0}Additional Information:", NewLine);

                        // Loop through the collection adding the information to the string builder.
                        for (int i = 0; i < currAdditionalInfo.Count; i++)
                        {
                            stringBuilder.AppendFormat("{2}--> {0}: {1}", currAdditionalInfo.GetKey(i), currAdditionalInfo[i], NewLine);
                        }
                    }
                }
            }
            else if (propInfo.Name == "Data")
            {
                object propValue = propInfo.GetValue(currException, null);

                if (propValue != null)
                {
                    IDictionary additionalData = propValue as IDictionary;

                    // Check if the collection contains values.
                    if (additionalData != null && additionalData.Count > 0)
                    {
                        stringBuilder.AppendFormat("{0}Additional Data:", NewLine);

                        // Loop through the collection adding the information to the string builder.
                        IDictionaryEnumerator dataEnumerator = additionalData.GetEnumerator();

                        while (dataEnumerator.MoveNext())
                        {
                            stringBuilder.AppendFormat("{2}--> {0}: {1}", dataEnumerator.Key, dataEnumerator.Value, NewLine);
                        }
                    }
                }
            }
            else
            {
                // Otherwise just write the ToString() value of the property.
                stringBuilder.AppendFormat("{2}{0}: {1}", GetFriendlyPropertyName(propInfo.Name), propInfo.GetValue(currException, null), NewLine);
            }
        }

        /// <devdoc>
        /// Add additional environmental information. 
        /// </devdoc>
        private void CollectAdditionalInfo()
        {
            if (this.additionalInfo["MachineName"] != null)
            {
                return;
            }

            this.additionalInfo.Add("Timestamp", "UTC Timestamp: " + DateTime.UtcNow.ToString(EventTimestampFormatString, CultureInfo.CurrentCulture));
            this.additionalInfo.Add("MachineName", "Machine Name: " + Environment.MachineName);
            this.additionalInfo.Add("AssemblyFullName", "Assembly Full Name: " + Assembly.GetExecutingAssembly().FullName);
            this.additionalInfo.Add("AssemblyVersion", "Assembly Version: " + Assembly.GetExecutingAssembly().GetName().Version);
            this.additionalInfo.Add("AppDomainName", "App Domain Name: " + AppDomain.CurrentDomain.FriendlyName);
            this.additionalInfo.Add("ApplicationBase", "Application Base Path: " + AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            this.additionalInfo.Add("WindowsIdentity", "Windows Identity: " + WindowsIdentity.GetCurrent().Name);
            this.additionalInfo.Add("DeploymentID", "Deployment ID: " + CloudEnvironment.DeploymentId);
            this.additionalInfo.Add("RoleName", "Role Name: " + CloudEnvironment.CurrentRoleName);
            this.additionalInfo.Add("RoleInstanceID", "Role Instance ID: " + CloudEnvironment.CurrentRoleInstanceId);
        }

        private static string GetFriendlyPropertyName(string originalName)
        {
            return PropertyNameParserRegex.Replace(originalName, (match) =>
            {
                return String.Concat(match.Groups["lc"], " ", match.Groups["uc"]);
            });
        }
        #endregion
    }
}
