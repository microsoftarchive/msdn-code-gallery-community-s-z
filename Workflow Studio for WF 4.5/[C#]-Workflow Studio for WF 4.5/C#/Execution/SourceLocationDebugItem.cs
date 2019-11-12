//-----------------------------------------------------------------------
// <copyright file="SourceLocationDebugItem.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;

    public class SourceLocationDebugItem
    {
        public int StepCount { get; set; }

        public string ActivityName { get; set; }

        public string Id { get; set; }

        public string State { get; set; }

        public Guid InstanceId { get; set; }
    }
}
