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
using System.Activities.Persistence;
using Microsoft.PowerShell.Workflow;
using System.Xml.Linq;

namespace SQLStoreExtensibilitySample
{
    // The sql instance store that ships with .Net 4.0 is responsible for storing the 
    // workflow context information into the database. It is hoster's responsiblity to 
    // provide storage methods for other data entities such as streams, metadata, and definition.
    // This class stores all other data entities.
    public class SampleSqlIOParticipant : PersistenceIOParticipant
    {
        private readonly PSWorkflowInstanceStore _stores;

        // Constructor
        public SampleSqlIOParticipant(PSWorkflowInstanceStore stores)
            : base(false, false)
        {
            _stores = stores;
        }

        // This method is called when the Abort call is being issued to the workflowApplication instance, which will happen when the job is forcefully suspended.
        protected override void Abort()
        {
            // make sure the integrity of data is ensured.
        }

        // This method contains additional data entities.
        protected override IAsyncResult BeginOnSave(IDictionary<XName, object> readWriteValues, IDictionary<XName, object> writeOnlyValues, TimeSpan timeout, AsyncCallback callback, object state)
        {
            _stores.Save(WorkflowStoreComponents.Definition
                        | WorkflowStoreComponents.Metadata
                        | WorkflowStoreComponents.Streams
                        | WorkflowStoreComponents.TerminatingError
                        | WorkflowStoreComponents.Timer
                        | WorkflowStoreComponents.JobState
                    );

            return base.BeginOnSave(readWriteValues, writeOnlyValues, timeout, callback, state);
        }
    }
}
