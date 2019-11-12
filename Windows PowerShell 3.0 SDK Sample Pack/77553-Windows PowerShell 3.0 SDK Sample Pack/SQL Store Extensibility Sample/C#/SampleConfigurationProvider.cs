// <copyright file="AssemblyInfo.cs" company="Microsoft Corporation">
// Copyright (c) 2012 Microsoft Corporation. All rights reserved.
// </copyright>
// DISCLAIMER OF WARRANTY: The software is licensed “as-is.” You 
// bear the risk of using it. Microsoft gives no express warranties, 
// guarantees or conditions. You may have additional consumer rights 
// under your local laws which this agreement cannot change. To the extent 
// permitted under your local laws, Microsoft excludes the implied warranties 
// of merchantability, fitness for a particular purpose and non-infringement.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.PowerShell.Workflow;

namespace SQLStoreExtensibilitySample
{
    // This class defines the configuration of a complete PSWorkflowRuntime object.
    // Override the CreatePSWorkflowInstanceStore method.
    class SampleConfigurationProvider : PSWorkflowConfigurationProvider
    {
        private string _connectionString = null;

        // Constructor that receives a SQL connection string.
        public SampleConfigurationProvider(string connectionString)
        {
            this._connectionString = connectionString;
        }

        // Override this method so that the runtime uses this instance store rather than the default store.
        public override PSWorkflowInstanceStore CreatePSWorkflowInstanceStore(PSWorkflowInstance workflowInstance)
        {
            return new SampleSqlInstanceStore(this, workflowInstance, _connectionString);
        }
    }
}
