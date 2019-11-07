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
    using System.Diagnostics;
    #endregion

    /// <summary>
    /// Provides the standard names of well-known trace message categories for reusability purposes.
    /// </summary>
    public struct WellKnownTraceCategory
    {
        #region Public members
        /// <summary>
        /// Returns the standard name of the TraceInfo trace event category.
        /// </summary>
        public const string TraceInfo = "TraceInfo";

        /// <summary>
        /// Returns the standard name of the TraceDetails trace event category.
        /// </summary>
        public const string TraceDetails = "TraceDetails";

        /// <summary>
        /// Returns the standard name of the TraceWarning trace event category.
        /// </summary>
        public const string TraceWarning = "TraceWarning";

        /// <summary>
        /// Returns the standard name of the TraceError trace event category.
        /// </summary>
        public const string TraceError = "TraceError";

        /// <summary>
        /// Returns the standard name of the TraceIn trace event category.
        /// </summary>
        public const string TraceIn = "TraceIn";

        /// <summary>
        /// Returns the standard name of the TraceOut trace event category.
        /// </summary>
        public const string TraceOut = "TraceOut";

        /// <summary>
        /// Returns the standard name of the TraceStartScope trace event category.
        /// </summary>
        public const string TraceStartScope = "TraceStartScope";

        /// <summary>
        /// Returns the standard name of the TraceEndScope trace event category.
        /// </summary>
        public const string TraceEndScope = "TraceEndScope"; 
        #endregion
    }
}
