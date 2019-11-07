//-----------------------------------------------------------------------
// <copyright file="TrackingEventArgs.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;
    using System.Activities;
    using System.Activities.Tracking;

    public class TrackingEventArgs : EventArgs
    {
        public TrackingEventArgs(TrackingRecord trackingRecord, TimeSpan timeout, Activity activity)
        {
            this.Record = trackingRecord;
            this.Timeout = timeout;
            this.Activity = activity;
        }

        public TrackingRecord Record { get; set; }

        public TimeSpan Timeout { get; set; }

        public Activity Activity { get; set; }
    }
}
