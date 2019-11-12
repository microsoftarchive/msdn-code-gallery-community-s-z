//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;

    public class ActivityCollectionViewModel : ResourceViewModelBase
    {
        ScopeViewModel currentScope;
        ServiceContext context;
        ActivityViewModel currentActivity;
        string currentActivityName;

        public ActivityCollectionViewModel(ScopeViewModel currentScope, ServiceContext context)
            : base(currentScope)
        {
            this.currentScope = currentScope;
            this.context = context;

            this.Activities = new ObservableCollection<ActivityViewModel>();
        }

        public string CurrentActivityName
        {
            get
            {
                if (this.SelectedActivity != null)
                {
                    return this.SelectedActivity.Name;
                }

                return null;
            }
            set
            {
                if (this.currentActivityName != value)
                {
                    this.currentActivityName = value;
                    this.SelectedActivity = this.Activities.FirstOrDefault(a => string.Equals(a.Name, value, StringComparison.OrdinalIgnoreCase));
                }
            }
        }

        public ObservableCollection<ActivityViewModel> Activities
        {
            get;
            private set;
        }

        public ActivityViewModel SelectedActivity
        {
            get
            {
                if (this.currentActivity != null)
                {
                    return this.currentActivity;
                }

                return this.Activities.FirstOrDefault<ActivityViewModel>();
            }
            set
            {
                if (this.currentActivity != value)
                {
                    this.currentActivity = value;
                    this.RaisePropertyChanged("SelectedActivity");
                }
            }
        }
        
        public override Uri Uri
        {
            get 
            {
                if (this.currentScope != null)
                {
                    return this.currentScope.Uri;
                }

                return null;
            }
        }

        public void PopulateActivities()
        {
            this.Activities.Clear();

            WorkflowManagementClient client = new WorkflowManagementClient(this.Uri, this.context.ClientSettings);
            Task<Collection<ActivityDescription>> getActivitiesTask = client.Activities.GetAsync(0, 500, includeXaml: true);
            getActivitiesTask.OnSuccess(
                delegate(Collection<ActivityDescription> activities)
                {
                    foreach (ActivityDescription activity in activities)
                    {
                        this.Activities.Add(new ActivityViewModel(activity));
                    }
                });

            getActivitiesTask.OnFaulted(
                delegate(Exception exception)
                {
                    Trace.TraceError("Failed to get activities: {0}", exception);
                });

            getActivitiesTask.OnCanceled(
                delegate()
                {
                    Trace.TraceWarning("Activity fetching was canceled.");
                });
        }
    }
}
