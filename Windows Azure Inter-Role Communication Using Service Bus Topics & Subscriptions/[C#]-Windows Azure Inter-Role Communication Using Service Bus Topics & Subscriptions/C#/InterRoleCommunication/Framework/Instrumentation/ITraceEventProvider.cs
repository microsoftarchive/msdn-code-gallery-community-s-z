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
    #endregion

    public interface ITraceEventProvider
    {
        /// <summary>
        /// Writes an information message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        void TraceInfo(string format, params object[] parameters);

        /// <summary>
        /// Writes an information message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        void TraceInfo(string message);

        /// <summary>
        /// Writes an information message to the trace. This method is intended to be used when the data that needs to be
        /// written to the trace is expensive to be fetched. The method represented by the Func(T) delegate will only be invoked if
        /// tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        void TraceInfo(Func<string> expensiveDataProvider);

        /// <summary>
        /// Writes a warning message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        void TraceWarning(string format, params object[] parameters);

        /// <summary>
        /// Writes a warning message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the message to be traced.</param>
        void TraceWarning(string message);

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        void TraceDetails(string format, params object[] parameters);

        /// <summary>
        /// Writes a message to the trace. This method can be used to trace detailed information
        /// which is only required in particular cases. The method represented by the Func(T) 
        /// delegate will only be invoked if tracing is enabled.
        /// </summary>
        /// <param name="expensiveDataProvider">A method that has no parameters and returns a value that needs to be traced.</param>
        void TraceDetails(Func<string> expensiveDataProvider);

        /// <summary>
        /// Writes an error message to the trace.
        /// </summary>
        /// <param name="format">A string containing zero or more format items.</param>
        /// <param name="parameters">A list containing zero or more data items to format.</param>
        void TraceError(string format, params object[] parameters);

        /// <summary>
        /// Writes an error message to the trace. This method is provided for optimal performance when
        /// tracing simple messages which don't require a format string.
        /// </summary>
        /// <param name="message">A string containing the error message to be traced.</param>
        void TraceError(string message);

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        void TraceError(Exception ex);

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        void TraceError(Exception ex, Guid callToken);

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        void TraceError(Exception ex, bool includeStackTrace);

        /// <summary>
        /// Writes the exception details to the trace.
        /// </summary>
        /// <param name="ex">An exception to be formatted and written to the trace.</param>
        /// <param name="includeStackTrace">A flag indicating whether or not call stack details should be included.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceError calls.</param>
        void TraceError(Exception ex, bool includeStackTrace, Guid callToken);

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// </summary>
        /// <param name="inParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        Guid TraceIn(params object[] inParameters);

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        /// <returns>An unique value which can be used as a correlation token to correlate TraceIn and TraceOut calls.</returns>
        Guid TraceIn();

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is invoked. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very beginning of an instrumented code.
        /// This overload should be used when correlation token (callToken) is defined by the calling code.
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        void TraceIn(Guid callToken);

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        void TraceOut(params object[] outParameters);

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// This method is provided to ensure optimal performance when no parameters are required to be traced.
        /// </summary>
        void TraceOut();

        /// <summary>
        /// Writes an informational event into the trace log indicating that a method is about to complete. This can be useful for tracing method calls to help analyze the 
        /// code execution flow. The method will also write the same event into default System.Diagnostics trace listener, however this will only occur in the DEBUG code.
        /// A call to the TraceIn method would typically be at the very end of an instrumented code, before the code returns its result (if any).
        /// </summary>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceIn and TraceOut calls.</param>
        /// <param name="outParameters">The method parameters which will be included into the traced event (make sure you do not supply any sensitive data).</param>
        void TraceOut(Guid callToken, params object[] outParameters);

        /// <summary>
        /// Writes an informational event into the trace log indicating a start of a scope for which duration will be measured.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="parameters">A list containing zero or more data items to be included into scope details.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        IDisposable TraceScope(string scope, params object[] parameters);

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when no parameters are available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="parameters">A list containing zero or more data items to be included into scope details.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        IDisposable TraceScope(string scope);

        /// <summary>
        /// Writes an informational event into the trace log indicating the start of a scope for which duration will be measured.
        /// This method is provided in order to ensure optimal performance when only 1 parameter of type Guid is available for tracing.
        /// </summary>
        /// <param name="scope">A textual identity of a scope for which duration will be traced.</param>
        /// <param name="callToken">An unique value which is used as a correlation token to correlate TraceStartScope and TraceEndScope calls.</param>
        /// <returns>The number of ticks that represent the date and time when it was invoked. This date/time will be used later when tracing the end of the scope.</returns>
        IDisposable TraceScope(string scope, Guid callToken);
    }
}
