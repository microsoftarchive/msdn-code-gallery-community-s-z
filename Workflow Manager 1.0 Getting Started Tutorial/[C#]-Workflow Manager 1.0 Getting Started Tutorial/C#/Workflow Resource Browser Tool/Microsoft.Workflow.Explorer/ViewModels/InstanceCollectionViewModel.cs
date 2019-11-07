//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Workflow.Client;

    public class InstanceCollectionViewModel : ResourceViewModelBase
    {
        WorkflowViewModel currentWorkflow;
        ServiceContext context;
        ObservableCollection<InstanceViewModel> instances;
        int instanceCount;
        InstanceViewModel selectedInstance;

        public InstanceCollectionViewModel(ScopeViewModel currentScope, WorkflowViewModel currentWorkflow, ServiceContext context)
            : base(currentScope)
        {
            this.currentWorkflow = currentWorkflow;
            this.context = context;
            this.instanceCount = -1;
        }

        public override Uri Uri
        {
            // TODO: Return the instance collection URI
            get { return this.ParentScope.Uri; }
        }

        public string InstanceCount
        {
            get
            {
                if (this.instanceCount == -1)
                {
                    this.PopulateInstances();
                    return "Counting...";
                }

                return this.instanceCount.ToString("N0", CultureInfo.CurrentUICulture);
            }
        }

        public ObservableCollection<InstanceViewModel> Instances
        {
            get
            {
                if (this.instances == null)
                {
                    this.PopulateInstances();
                }

                return this.instances;
            }
        }

        public InstanceViewModel SelectedInstance
        {
            get { return this.selectedInstance ?? this.Instances.FirstOrDefault(); }
            set
            {
                if (this.selectedInstance != value)
                {
                    this.selectedInstance = value;
                    this.RaisePropertyChanged("SelectedInstance");
                }
            }
        }

        public void PopulateInstances()
        {
            if (this.instances == null)
            {
                this.instances = new ObservableCollection<InstanceViewModel>();
            }
            else
            {
                this.instances.Clear();
            }

            this.instanceCount = 0;
            this.instances.Add(new InstanceFetchMessage("Loading..."));

            WorkflowManagementClient client = new WorkflowManagementClient(this.ParentScope.Uri, this.context.ClientSettings);
            Task<Collection<WorkflowInstanceInfo>> getInstancesTask = client.Instances.GetAsync(0, 500, this.currentWorkflow.Name);
            getInstancesTask.OnSuccess(
                delegate(Collection<WorkflowInstanceInfo> instances)
                {
                    this.instanceCount = instances.Count;
                    Trace.TraceInformation("Fetched {0} instances for workflow named '{1}'", this.instanceCount, this.currentWorkflow.Name);
                    this.instances.Clear();
                    foreach (WorkflowInstanceInfo instance in instances)
                    {
                        InstanceViewModel instanceViewModel = new InstanceViewModel(instance);
                        this.instances.Add(instanceViewModel);
                    }

                    this.RaisePropertyChanged("InstanceCount");
                });
            getInstancesTask.OnCanceled(
                delegate()
                {
                    Trace.TraceError("Failed to fetch instances for workflow named '{0}' due to a timeout.", this.currentWorkflow.Name);
                    this.instances.Clear();
                    this.instances.Add(new InstanceFetchMessage("Timed out while querying for instances."));
                });
            getInstancesTask.OnFaulted(
                delegate(Exception e)
                {
                    Trace.TraceError("Failed to fetch instances for workflow named '{0}'", this.currentWorkflow.Name);
                });
        }

        class InstanceFetchMessage : InstanceViewModel
        {
            string message;

            public InstanceFetchMessage(string message)
                : base(null)
            {
                this.message = message;
            }

            public override string ToString()
            {
                return this.message;
            }
        }
    }
}
