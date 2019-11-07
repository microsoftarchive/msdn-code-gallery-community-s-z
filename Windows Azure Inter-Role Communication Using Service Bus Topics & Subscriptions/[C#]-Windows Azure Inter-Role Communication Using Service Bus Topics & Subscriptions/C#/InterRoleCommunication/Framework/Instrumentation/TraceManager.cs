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
    using System.Threading;
    using System.Reflection;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// The main tracing component which is intended to be invoked from user code.
    /// </summary>
    public static class TraceManager
    {
        #region Private members
        private const int InitialCacheSize = 10;

        private static readonly ITraceEventProvider pipelineComponentTracer;
        private static readonly ITraceEventProvider workflowComponentTracer;
        private static readonly ITraceEventProvider dataAccessComponentTracer;
        private static readonly ITraceEventProvider transformComponentTracer;
        private static readonly ITraceEventProvider serviceComponentTracer;
        private static readonly ITraceEventProvider customComponentTracer;
        private static readonly ITraceEventProvider rulesComponentTracer;
        private static readonly ITraceEventProvider trackingComponentTracer;
        private static readonly ITraceEventProvider workerRoleComponentTracer;
        private static readonly ITraceEventProvider webRoleComponentTracer;
        private static readonly ITraceEventProvider debugComponentTracer;
        private static readonly ITraceEventProvider cloudStorageComponent;

        private static readonly IDictionary<Guid, ITraceEventProvider> traceProviderCache = new Dictionary<Guid, ITraceEventProvider>(InitialCacheSize);
        private static readonly IDictionary<string, Guid> traceProviderGuidToSourceMap = new Dictionary<string, Guid>(InitialCacheSize);
        private static readonly object traceProviderCacheLock = new object();
        #endregion

        #region Constructor
        static TraceManager()
        {
            customComponentTracer = new DebugTraceEventProvider();
            pipelineComponentTracer = new DebugTraceEventProvider();
            workflowComponentTracer = new DebugTraceEventProvider();
            dataAccessComponentTracer = new DebugTraceEventProvider();
            transformComponentTracer = new DebugTraceEventProvider();
            serviceComponentTracer = new DebugTraceEventProvider();
            rulesComponentTracer = new DebugTraceEventProvider();
            trackingComponentTracer = new DebugTraceEventProvider();
            workerRoleComponentTracer = new DebugTraceEventProvider();
            cloudStorageComponent = new DebugTraceEventProvider();
            debugComponentTracer = new DebugTraceEventProvider();
            webRoleComponentTracer = new DebugTraceEventProvider();
        }
        #endregion

        #region Public properties
        /// <summary>
        /// The trace provider for user code in the custom pipeline components.
        /// </summary>
        public static ITraceEventProvider PipelineComponent
        {
            get { return pipelineComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in workflows (such as expression shapes in the BizTalk orchestrations).
        /// </summary>
        public static ITraceEventProvider WorkflowComponent
        {
            get { return workflowComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the custom components responsible for data access operations.
        /// </summary>
        public static ITraceEventProvider DataAccessComponent
        {
            get { return dataAccessComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the transformation components (such as scripting functoids in the BizTalk maps).
        /// </summary>
        public static ITraceEventProvider TransformComponent
        {
            get { return transformComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the service components (such as Web Service, WCF Service or service proxy components).
        /// </summary>
        public static ITraceEventProvider ServiceComponent
        {
            get { return serviceComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the Business Rules components (such as custom fact retrievers, policy executors).
        /// </summary>
        public static ITraceEventProvider RulesComponent
        {
            get { return rulesComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the business activity tracking components (such as BAM activities).
        /// </summary>
        public static ITraceEventProvider TrackingComponent
        {
            get { return trackingComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in any other custom components which don't fall into any of the standard categories such as Pipeline, Workflow, DataAccess, Transform.
        /// </summary>
        public static ITraceEventProvider CustomComponent
        {
            get { return customComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the Azure worker roles.
        /// </summary>
        public static ITraceEventProvider WorkerRoleComponent
        {
            get { return workerRoleComponentTracer; }
        }

        /// <summary>
        /// The trace provider for user code in the Azure web roles.
        /// </summary>
        public static ITraceEventProvider WebRoleComponent
        {
            get { return webRoleComponentTracer; }
        }

        /// <summary>
        /// The trace provider reserved for the Azure components responsible for storage-related operations.
        /// </summary>
        public static ITraceEventProvider CloudStorageComponent
        {
            get { return cloudStorageComponent; }
        }

        /// <summary>
        /// The trace provider reserved for DEBUG mode.
        /// </summary>
        public static ITraceEventProvider DebugComponent
        {
            get { return debugComponentTracer; }
        }
        #endregion
    }
}