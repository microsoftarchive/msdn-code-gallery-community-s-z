//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.ViewModels;
    
    public class WorkflowCollectionViewModel : ResourceViewModelBase
    {
        ScopeViewModel currentScope;
        ServiceContext context;
        WorkflowViewModel currentWorkflow;
        
        public WorkflowCollectionViewModel(ScopeViewModel currentScope, ServiceContext context)
            : base(currentScope)
        {
            this.currentScope = currentScope;
            this.context = context;

            this.Workflows = new ObservableCollection<WorkflowViewModel>();
        }

        public override Uri Uri
        {
            get { return this.currentScope != null ? this.currentScope.Uri : null; }
        }

        public ObservableCollection<WorkflowViewModel> Workflows
        {
            get;
            private set;
        }

        public WorkflowViewModel SelectedWorkflow
        {
            get { return this.currentWorkflow ?? this.Workflows.FirstOrDefault<WorkflowViewModel>(); }
            set
            {
                if (this.currentWorkflow != value)
                {
                    this.currentWorkflow = value;
                    this.RaisePropertyChanged("SelectedWorkflow");
                }
            }
        }

        public void PopulateWorkflows()
        {
            Collection<WorkflowDescription> workflowsCollection = null;
            try
            {
                if (this.Uri != null)
                {
                    WorkflowManagementClient client = new WorkflowManagementClient(this.Uri, this.context.ClientSettings);
                    workflowsCollection = client.Workflows.Get(0, 100, null);
                }
            }
            catch (WorkflowManagementException e)
            {
                Trace.TraceError("Exception occured while fetching workflows: {0}", e);
            }

            if (workflowsCollection != null)
            {
                foreach (WorkflowDescription workflow in workflowsCollection.OrderBy(workflow => -workflow.LastModified.Ticks))
                {
                    this.Workflows.Add(new WorkflowViewModel(this.ParentScope, workflow, this.context));
                }
            }
        }
    }
}
