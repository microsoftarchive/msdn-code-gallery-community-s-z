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
    #region Using statements
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    using Microsoft.WindowsAzure.Diagnostics;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Properties;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Internal;
    #endregion

    /// <summary>
    /// Implements a tracing provider that emits trace events into the Wind32 Debug API.
    /// </summary>
    internal class DebugTraceEventProvider : ITraceEventProvider
    {
        #region Private members
        private readonly TraceListener traceWriter;
        private readonly TraceEventCache eventCache;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of a <see cref="DebugTraceEventProvider"/> object configured with default settings.
        /// </summary>
        public DebugTraceEventProvider()
        {
            if (CloudEnvironment.IsAvailable)
            {
                this.traceWriter = new DiagnosticMonitorTraceListener();
            }
            else
            {
                this.traceWriter = new DefaultTraceListener();
            }

            this.eventCache = new TraceEventCache();
        }
        #endregion

        #region ITraceEventProvider implementation
        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceInfo(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, format, parameters);
        }

        /// <summary>
        /// Writes an information message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceInfo(string message)
        {
            TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, InstrumentationUtility.Resources.FormatStringTraceInfo, message);
        }

        /// <summary>
        /// Writes an information message to the trace. This method is intended to be used when the data that needs to be
        /// written to the trace is expensive to be fetched. The method represented by the Func(T) delegate will only be invoked if
        /// tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        [DebuggerStepThrough]
        public void TraceInfo(Func<string> expensiveDataProvider)
        {
            TraceEvent(TraceEventType.Information, WellKnownTraceCategory.TraceInfo, InstrumentationUtility.SystemEventId.Info, InstrumentationUtility.Resources.FormatStringTraceInfo, expensiveDataProvider());
        }

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceDetails(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceDetails, InstrumentationUtility.SystemEventId.DetailedInfo, format, parameters);
        }

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases. The method represented by the Func(T) 
        /// delegate will only be invoked if tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        [DebuggerStepThrough]
        public void TraceDetails(Func<string> expensiveDataProvider)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceDetails, InstrumentationUtility.SystemEventId.DetailedInfo, InstrumentationUtility.Resources.FormatStringTraceDetails, expensiveDataProvider());
        }

        /// <summary>
        /// Writes a warning message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceWarning(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Warning, WellKnownTraceCategory.TraceWarning, InstrumentationUtility.SystemEventId.Warning, format, parameters);
        }

        /// <summary>
        /// Writes a warning message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceWarning(string message)
        {
            TraceEvent(TraceEventType.Warning, WellKnownTraceCategory.TraceWarning, InstrumentationUtility.SystemEventId.Warning, InstrumentationUtility.Resources.FormatStringTraceWarning, message);
        }

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        [DebuggerStepThrough]
        public void TraceError(string format, params object[] parameters)
        {
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, format, parameters);
        }

        /// <summary>
        /// Writes an error message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the error message to be traced.</param>
        [DebuggerStepThrough]
        public void TraceError(string message)
        {
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceErrorNoToken, message);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex)
        {
            TraceError(ex, true);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, Guid callToken)
        {
            TraceError(ex, true, callToken);
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, bool includeStackTrace)
        {
            ExceptionTextFormatter exceptionFormatter = new ExceptionTextFormatter();
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceErrorNoToken, exceptionFormatter.FormatException(ex, includeStackTrace));
        }

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        [DebuggerStepThrough]
        public void TraceError(Exception ex, bool includeStackTrace, Guid callToken)
        {
            ExceptionTextFormatter exceptionFormatter = new ExceptionTextFormatter();
            TraceEvent(TraceEventType.Error, WellKnownTraceCategory.TraceError, InstrumentationUtility.SystemEventId.Error, InstrumentationUtility.Resources.FormatStringTraceError, exceptionFormatter.FormatException(ex, includeStackTrace), callToken);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="parameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        [DebuggerStepThrough]
        public Guid TraceIn(params object[] parameters)
        {
            Guid callToken = Guid.NewGuid();
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), InstrumentationUtility.GetParameterList(parameters), callToken);

            return callToken;
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        [DebuggerStepThrough]
        public Guid TraceIn()
        {
            Guid callToken = Guid.NewGuid();
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), null, callToken);

            return callToken;
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This overload should be used when correlation token (callToken) is defined by the calling code.
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        [DebuggerStepThrough]
        public void TraceIn(Guid callToken)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceIn, InstrumentationUtility.SystemEventId.MethodEntry, InstrumentationUtility.Resources.FormatStringTraceIn, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), null, callToken);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        [DebuggerStepThrough]
        public void TraceOut(params object[] outParameters)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOutNoToken, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), outParameters != null & outParameters.Length > 0 ? InstrumentationUtility.GetParameterList(outParameters) : InstrumentationUtility.Resources.NoReturnValue);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        [DebuggerStepThrough]
        public void TraceOut()
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOutNoTokenAndParams, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()));
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceOut method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        [DebuggerStepThrough]
        public void TraceOut(Guid callToken, params object[] outParameters)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceOut, InstrumentationUtility.SystemEventId.MethodExit, InstrumentationUtility.Resources.FormatStringTraceOut, InstrumentationUtility.GetFullMethodName(InstrumentationUtility.GetCallingMethod()), outParameters != null & outParameters.Length > 0 ? InstrumentationUtility.GetParameterList(outParameters) : InstrumentationUtility.Resources.NoReturnValue, callToken);
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating a start of a scope for which duration will be measured.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="parameters">A list containing zero or more data items to be included into scope details.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public IDisposable TraceScope(string scope, params object[] parameters)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStart, scope, InstrumentationUtility.GetParameterList(parameters));
            var startTicks = HighResolutionTimer.CurrentTickCount;

            return new AnonymousDisposable(() =>
            {
                long duration = HighResolutionTimer.Current.GetElapsedMilliseconds(startTicks);
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceEndScope, InstrumentationUtility.SystemEventId.EndScope, InstrumentationUtility.Resources.FormatStringTraceScopeEndNoParams, scope, duration);
            });
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when no parameters are available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public IDisposable TraceScope(string scope)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStartNoParams, scope);
            var startTicks = HighResolutionTimer.CurrentTickCount;

            return new AnonymousDisposable(() =>
            {
                long duration = HighResolutionTimer.Current.GetElapsedMilliseconds(startTicks);
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceEndScope, InstrumentationUtility.SystemEventId.EndScope, InstrumentationUtility.Resources.FormatStringTraceScopeEndNoParams, scope, duration);
            });
        }

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when only 1 parameter of type Guid is available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceStartScope and TraceEndScope calls.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        [DebuggerStepThrough]
        public IDisposable TraceScope(string scope, Guid callToken)
        {
            TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceStartScope, InstrumentationUtility.SystemEventId.StartScope, InstrumentationUtility.Resources.FormatStringTraceScopeStart, scope, callToken);
            var startTicks = HighResolutionTimer.CurrentTickCount;

            return new AnonymousDisposable(() =>
            {
                long duration = HighResolutionTimer.Current.GetElapsedMilliseconds(startTicks);
                TraceEvent(TraceEventType.Verbose, WellKnownTraceCategory.TraceEndScope, InstrumentationUtility.SystemEventId.EndScope, InstrumentationUtility.Resources.FormatStringTraceScopeEnd, scope, callToken, duration);
            });
        }
        #endregion

        #region Private methods
        private void TraceEvent(TraceEventType eventType, string eventCategory, int eventId, string format, params object[] args)
        {
            this.traceWriter.TraceEvent(this.eventCache, eventCategory, eventType, eventId, format, args);
        }
        #endregion
    }
}
