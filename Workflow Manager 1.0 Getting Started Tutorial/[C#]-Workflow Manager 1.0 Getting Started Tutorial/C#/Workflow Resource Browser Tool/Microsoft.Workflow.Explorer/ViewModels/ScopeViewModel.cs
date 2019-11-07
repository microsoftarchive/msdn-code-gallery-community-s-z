//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Controllers;

    public class ScopeViewModel : ResourceViewModelBase
    {
        ScopeDescription scope;
        ScopeViewModel parentScope;
        ServiceContext context;
        ObservableCollection<ScopeViewModel> childScopes;
        string title;
        bool isSelected;
        ActivityViewModel selectedActivity;
        ActivityCollectionViewModel activityCollection;
        WorkflowCollectionViewModel workflowCollection;
        SecuritySettingsViewModel securitySettingsViewModel;
        WorkflowConfigurationViewModel configurationViewModel;

        public ScopeViewModel(ScopeDescription scope, ScopeViewModel parentScope, ServiceContext context)
            : base(parentScope)
        {
            this.scope = scope;
            this.parentScope = parentScope;
            this.context = context;

            this.title = this.scope.Name();
            this.ShowActivitiesCommand = new SimpleActionCommand(this.OnShowActivities);
            this.ShowWorkflowsCommand = new SimpleActionCommand(this.OnShowWorkflows);
            this.ShowSecuritySettingsCommand = new SimpleActionCommand(this.OnShowSecuritySettings);

            if (this.scope.DefaultWorkflowConfiguration != null)
            {
                this.configurationViewModel = new WorkflowConfigurationViewModel(this.scope.DefaultWorkflowConfiguration);
                this.ShowConfigurationCommand = new SimpleActionCommand(this.OnShowConfiguration);
            }
        }

        public virtual string Title
        {
            get { return this.title; }
            protected set { this.title = value; }
        }

        public string Description
        {
            get { return this.scope.UserComments; }
        }

        public int ActivityCount
        {
            get { return this.scope.ActivityCount; }
        }

        public int WorkflowCount
        {
            get { return this.scope.WorkflowCount; }
        }

        public int ChildScopeCount
        {
            get { return this.scope.ChildScopeCount; }
        }

        public string Path
        {
            get { return this.scope.Path; }
        }

        public ActivityViewModel SelectedActivity
        {
            get { return this.selectedActivity; }
            set
            {
                if (this.selectedActivity != value)
                {
                    this.selectedActivity = value;
                    this.RaisePropertyChanged("SelectedActivity");
                }
            }
        }

        public ActivityCollectionViewModel ActivityCollection
        {
            get
            {
                if (this.activityCollection == null)
                {
                    this.activityCollection = new ActivityCollectionViewModel(this, this.context);
                    this.activityCollection.PopulateActivities();
                    this.RaisePropertyChanged("ActivityCollection");
                }

                return this.activityCollection;
            }
        }

        public WorkflowCollectionViewModel WorkflowCollection
        {
            get
            {
                if (this.workflowCollection == null)
                {
                    this.workflowCollection = new WorkflowCollectionViewModel(this, this.context);
                    this.workflowCollection.PopulateWorkflows();
                    this.RaisePropertyChanged("WorkflowCollection");
                }

                return this.workflowCollection;
            }
        }

        public SecuritySettingsViewModel SecuritySettings
        {
            get 
            {
                if (this.securitySettingsViewModel == null)
                {
                    this.securitySettingsViewModel = new SecuritySettingsViewModel(this.scope.SecurityConfigurations);
                    this.RaisePropertyChanged("SecuritySettings");
                }

                return this.securitySettingsViewModel;
            }
        }

        public DateTime LastModified
        {
            get { return this.scope.LastModified; }
        }

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    this.RaisePropertyChanged("IsSelected");

                    if (this.isSelected)
                    {
                        this.context.SelectedScope = this;
                    }
                }
            }
        }

        public ObservableCollection<ScopeViewModel> ChildScopes
        {
            get
            {
                if (this.childScopes == null)
                {
                    this.childScopes = new ObservableCollection<ScopeViewModel>();
                    this.childScopes.Add(new ChildScopesProxy(this));
                }

                return this.childScopes;
            }
        }

        public override Uri Uri
        {
            get { return this.context.CreateUri(this.scope.Path); }
        }

        public ICommand ShowActivitiesCommand
        {
            get;
            private set;
        }

        public ICommand ShowWorkflowsCommand
        {
            get;
            private set;
        }

        public ICommand ShowSecuritySettingsCommand
        {
            get;
            private set;
        }

        public ICommand ShowConfigurationCommand
        {
            get;
            private set;
        }

        void OnShowActivities(object sender)
        {
            if (this.ActivityCount > 0)
            {
                ScopeNavigationController.Default.NavigateToActivitiesSummaryPage(this);
            }
        }

        void OnShowWorkflows(object sender)
        {
            if (this.WorkflowCount > 0)
            {
                ScopeNavigationController.Default.NavigateToWorkflowsSummaryPage(this);
            }
        }

        void OnShowConfiguration(object sender)
        {
            if (this.configurationViewModel != null)
            {
                ScopeNavigationController.Default.NavigateToWorkflowConfigurationPage(this.configurationViewModel);
            }
        }

        void OnShowSecuritySettings(object sender)
        {
            if (this.SecuritySettings.PolicyCount > 0)
            {
                ScopeNavigationController.Default.NavigateToSecuritySettingsPage(this.SecuritySettings);
            }
        }

        class ChildScopesProxy : ScopeViewModel
        {
            bool startedLoading;

            public ChildScopesProxy(ScopeViewModel parent)
                : base(parent.scope, parent, parent.context)
            {
                this.title = "Downloading child scopes...";
            }

            public override string Title
            {
                get
                {
                    if (!this.startedLoading)
                    {
                        this.startedLoading = true;
                        this.ReplaceWithChildScopes();
                    }

                    return this.title;
                }
            }

            void ReplaceWithChildScopes()
            {
                Task getChildrenTask = Task.Factory.StartNewFromDispatcher(
                    delegate()
                    {
                        this.parentScope.ChildScopes.Clear();
                        foreach (ScopeDescription childScope in this.parentScope.context.CreateClient(this.scope).CurrentScope.GetChildScopes(0, 500)
                            .OrderBy(scope => -(scope.ChildScopeCount * 100 + scope.WorkflowCount * 10)))
                        {
                            this.parentScope.ChildScopes.Add(new ScopeViewModel(childScope, this.parentScope, this.parentScope.context));
                        }
                    });

                getChildrenTask.OnFaulted(
                    delegate(Exception error)
                    {
                        // ensure this item is the only item
                        this.parentScope.ChildScopes.Clear();
                        this.parentScope.ChildScopes.Add(this);

                        // change the item title to be the error message
                        AggregateException aggregateException = error as AggregateException;
                        if (aggregateException != null)
                        {
                            error = aggregateException.GetBaseException();
                        }

                        this.Title = "Error getting child scopes: " + error.Message;
                    });
            }
        }
    }
}
