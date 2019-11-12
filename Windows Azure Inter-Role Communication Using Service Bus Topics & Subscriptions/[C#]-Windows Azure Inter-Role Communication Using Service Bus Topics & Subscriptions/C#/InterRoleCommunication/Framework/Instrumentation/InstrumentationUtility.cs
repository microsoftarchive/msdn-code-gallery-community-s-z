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
	using System.Reflection;
	using System.Globalization;
	using System.Diagnostics;
	#endregion

	/// <summary>
	/// Providers helper methods for other classes that implement instrumentation logic.
	/// </summary>
	public static class InstrumentationUtility
	{
		#region Private members
		private const string UnknownMethodName = "UNKNOWN";
		private const string NullParameterValue = "NULL";
		private const int BaseTraceEventID = 9000;
		#endregion

		#region Public members
		/// <summary>
		/// Provides the standard format strings and resources utilized by tracing components.
		/// </summary>
		public struct Resources
		{
			/// <summary>
			/// Returns the standard text that appear in the trace log when a method doesn't have a return value.
			/// </summary>
			public const string NoReturnValue = "<void>";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a method entry event.
			/// </summary>
			public const string FormatStringTraceIn = "TRACEIN: {0}({1}) => [{2}]";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a method exit event.
			/// </summary>
			public const string FormatStringTraceOut = "TRACEOUT: {0}(...) = {1} <= [{2}]";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a method exit event that doesn't contain a call token.
			/// </summary>
			public const string FormatStringTraceOutNoToken = "TRACEOUT: {0}(...) = {1}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a method exit event that doesn't contain a call token or output parameters.
			/// </summary>
			public const string FormatStringTraceOutNoTokenAndParams = "TRACEOUT: {0}(...)";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing an informational event.
			/// </summary>
			public const string FormatStringTraceInfo = "INFO: {0}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a detailed informational event.
			/// </summary>
			public const string FormatStringTraceDetails = "DETAILS: {0}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing an error event.
			/// </summary>
			public const string FormatStringTraceError = "ERROR: {0} <= [{1}]";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing an error event that doesn't contain a call token.
			/// </summary>
			public const string FormatStringTraceErrorNoToken = "ERROR: {0}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a warning event.
			/// </summary>
			public const string FormatStringTraceWarning = "WARN: {0}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a scope entry event.
			/// </summary>
			public const string FormatStringTraceScopeStart = "SCOPE START: {0}({1})";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a scope entry event that doesn't contain any context parameters. 
			/// </summary>
			public const string FormatStringTraceScopeStartNoParams = "SCOPE START: {0}";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a scope exit event.
			/// </summary>
			public const string FormatStringTraceScopeEnd = "SCOPE END: {0}({1}): {2}ms";

			/// <summary>
			/// Returns the standard text that appear in the trace log when writing a scope exit event that doesn't contain any context parameters. 
			/// </summary>
			public const string FormatStringTraceScopeEndNoParams = "SCOPE END: {0}: {1}ms";

			/// <summary>
			/// Returns the standard property name that is used for keeping a GUID value that corresponds to the tracing provider ID.
			/// </summary>
			public const string TracingProviderGuidPropertyName = "Tracing Provider GUID";
		}

		/// <summary>
		/// Contains the default GUID values for standard trace providers.
		/// </summary>
		public struct TracingProviderGuid
		{
			/// <summary>
			/// Returns the provider GUID value for default tracing provider.
			/// </summary>
			public readonly static Guid Default = new Guid("6A223DEA-F806-4523-BAD0-312DCC4F63F9");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting pipeline components.
			/// </summary>
			public readonly static Guid PipelineComponent = new Guid("691CB4CB-D20C-408e-8CFF-FD8A01CD2F75");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting worflow components.
			/// </summary>
			public readonly static Guid WorkflowComponent = new Guid("D2316AFB-414B-42e4-BB7F-3AA92B96A98A");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting data access components.
			/// </summary>
			public readonly static Guid DataAccessComponent = new Guid("2E5D65D8-71F9-43e9-B477-733EF6212895");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting transformation components.
			/// </summary>
			public readonly static Guid TransformComponent = new Guid("226445A8-5AF3-4dbe-86D2-73E9B965378E");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting service components.
			/// </summary>
			public readonly static Guid ServiceComponent = new Guid("E67E8346-90F1-408b-AF40-222B6E3C5ED6");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting Rules Engine components.
			/// </summary>
			public readonly static Guid RulesComponent = new Guid("78E2D466-590F-4991-9287-3F00BA62793D");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting BAM tracking components.
			/// </summary>
			public readonly static Guid TrackingComponent  = new Guid("5CBD8BA0-60F8-401b-8FF5-C7F3D5FABE41");
			
			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting Windows Azure web and worker roles.
			/// </summary>
			public readonly static Guid WorkerRoleComponent = new Guid("DC32D001-79C0-4B08-A240-3CFA525FC3F6");

			/// <summary>
			/// Returns the provider GUID value for a tracing provider dedicated to supporting cloud storage components.
			/// </summary>
			public readonly static Guid CloudStorageComponent = new Guid("C49588AF-C795-4891-B907-78A271EE746E");
		}

		/// <summary>
		/// Provides the standard event ID values.
		/// </summary>
		public struct SystemEventId
		{
			private const int BaseTraceEventID = 9000;

			/// <summary>
			/// Returns the information event ID.
			/// </summary>
			public const int Info = BaseTraceEventID + 1;

			/// <summary>
			/// Returns the detailed information event ID.
			/// </summary>
			public const int DetailedInfo = BaseTraceEventID + 2;

			/// <summary>
			/// Returns the warning event ID.
			/// </summary>
			public const int Warning = BaseTraceEventID + 3;

			/// <summary>
			/// Returns the error event ID.
			/// </summary>
			public const int Error = BaseTraceEventID + 4;

			/// <summary>
			/// Returns the method entry event ID.
			/// </summary>
			public const int MethodEntry = BaseTraceEventID + 5;

			/// <summary>
			/// Returns the method exit event ID.
			/// </summary>
			public const int MethodExit = BaseTraceEventID + 6;

			/// <summary>
			/// Returns the start scope event ID.
			/// </summary>
			public const int StartScope = BaseTraceEventID + 7;

			/// <summary>
			/// Returns the end scope event ID.
			/// </summary>
			public const int EndScope = BaseTraceEventID + 8;

			/// <summary>
			/// Returns the heartbeat event ID.
			/// </summary>
			public const int Heartbeat = BaseTraceEventID + 9;
		}
		#endregion

		#region Public methods
		/// <summary>
		/// Determines if the specified method is part of the tracing library.
		/// </summary>
		/// <param name="methodToCheck">MethodBase describing the method to check.</param>
		/// <returns>True if the method is a member of the tracing library, false if not.</returns>
		public static bool IsTracingMethod(MethodBase methodToCheck)
		{
			Type declaringType = methodToCheck.DeclaringType;

			return declaringType != null ? declaringType == typeof(InstrumentationUtility) || typeof(ITraceEventProvider).IsAssignableFrom(declaringType) : false;
		}

		/// <summary>
		/// Walks the call stack to find the name of the method which invoked this class.
		/// </summary>
		/// <returns>MethodBase representing the most recent method in the stack which is not a member of this class.</returns>
		public static MethodBase GetCallingMethod()
		{
			StackTrace stack = new StackTrace();

			foreach (StackFrame frame in stack.GetFrames())
			{
				MethodBase frameMethod = frame.GetMethod();
				if (!IsTracingMethod(frameMethod))
				{
					return frameMethod;
				}
			}

			return null;
		}

		/// <summary>
		/// Returns a fully qualified method name including the containing type name.
		/// </summary>
		/// <param name="callingMethod">The instance of <see cref="System.Reflection.MethodBase"/> reflection object containing method metadada.</param>
		/// <returns>A string containing the full method name.</returns>
		public static string GetFullMethodName(MethodBase callingMethod)
		{
			// Compose and return fully qualified method name.
			return callingMethod != null ? String.Format(CultureInfo.InvariantCulture, "{0}.{1}", callingMethod.DeclaringType.FullName, callingMethod.Name) : UnknownMethodName;
		}

		/// <summary>
		/// Returns a string representing a list of parameters to be written into trace log.
		/// </summary>
		/// <param name="parameters">Parameters to be included in the trace log entry.</param>
		/// <returns>A comma-separated list of formatted parameters.</returns>
		public static string GetParameterList(object[] parameters)
		{
			// Make sure we have a parameter array which is safe to pass to Array.ConvertAll.
			if (null == parameters)
			{
				parameters = new object[] { null };
			}

			// Get a string representation of each parameter that we have been passed.
			string[] paramStrings = Array.ConvertAll<object, string>(parameters, ParameterObjectToString);

			// Create a string containing details of each parameter.
			return String.Join(", ", paramStrings);
		}
		#endregion

		#region Private methods
		private static string ParameterObjectToString(object parameter)
		{
			if (null == parameter)
			{
				return NullParameterValue;
			}

			// Surround string values with quotes.
			if (parameter.GetType() == typeof(string))
			{
				return "\"" + (string)parameter + "\"";
			}

			return parameter.ToString();
		} 
		#endregion
	}
}
