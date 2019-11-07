//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Xaml;
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Controllers;

    public class WorkflowViewModel : ResourceViewModelBase
    {
        WorkflowDescription description;
        ServiceContext context;
        InstanceCollectionViewModel instanceCollection;
        ExternalVariablesViewModel externalVariables;
        WorkflowConfigurationViewModel configurationViewModel;

        public WorkflowViewModel(ScopeViewModel currentScope, WorkflowDescription description, ServiceContext context)
            : base(currentScope)
        {
            this.description = description;
            this.context = context;
            this.ShowExternalVariablesCommand = new SimpleActionCommand(this.OnShowExternalVariables);
            this.ShowInstancesCommand = new SimpleActionCommand(this.OnShowInstances);
            this.ShowMetadataCommand = new SimpleActionCommand(this.OnShowMetadata);
            this.ShowConfigurationCommand = new SimpleActionCommand(this.OnShowConfiguration);
            this.ShowRootActivityCommand = new SimpleActionCommand(this.OnShowRootActivityXaml);

            if (this.description.Configuration != null)
            {
                this.configurationViewModel = new WorkflowConfigurationViewModel(this.description.Configuration);
                this.ShowConfigurationCommand = new SimpleActionCommand(this.OnShowConfiguration);
            }
        }

        public override Uri Uri
        {
            // TODO: Return the URI of this workflow resource
            get { return this.ParentScope.Uri; }
        }

        public string Name
        {
            get { return this.description.Name; }
        }

        public string ActivityPath
        {
            get { return this.description.ActivityPath; }
        }

        public DateTime LastModified
        {
            get { return this.description.LastModified.ToLocalTime(); }
        }

        public int ExternalVariableCount
        {
            get { return this.description.ExternalVariables.Count; }
        }

        public int MetadataCount
        {
            get { return this.description.Metadata.Count; }
        }

        public InstanceCollectionViewModel InstanceCollection
        {
            get
            {
                if (this.instanceCollection == null)
                {
                    this.instanceCollection = new InstanceCollectionViewModel(this.ParentScope, this, this.context);
                }

                return this.instanceCollection;
            }
        }

        public ExternalVariablesViewModel ExternalVariables
        {
            get
            {
                if (this.externalVariables == null)
                {
                    this.externalVariables = new ExternalVariablesViewModel(this.description.ExternalVariables);
                }

                return this.externalVariables;
            }
        }

        public ICommand ShowExternalVariablesCommand
        {
            get;
            private set;
        }

        public ICommand ShowInstancesCommand
        {
            get;
            private set;
        }

        public ICommand ShowMetadataCommand
        {
            get;
            private set;
        }

        public ICommand ShowConfigurationCommand
        {
            get;
            private set;
        }

        public ICommand ShowRootActivityCommand
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Name;
        }

        void OnShowExternalVariables(object sender)
        {
            if (this.description.ExternalVariables.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToExternalVariablesPage(this.ExternalVariables);
            }
        }

        void OnShowInstances(object sender)
        {
            if (this.InstanceCollection.Instances.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToInstancesPage(this.InstanceCollection);
            }
        }

        void OnShowMetadata(object sender)
        {
            if (this.description.Metadata.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToDictionaryPage((IDictionary)this.description.Metadata);
            }
        }

        void OnShowConfiguration(object sender)
        {
            if (this.configurationViewModel != null)
            {
                ScopeNavigationController.Default.NavigateToWorkflowConfigurationPage(this.configurationViewModel);
            }
        }

        void OnShowRootActivityXaml(object sender)
        {
            // TODO: Support for activity references from another scope
            if (!string.IsNullOrEmpty(this.description.ActivityPath) && !this.description.ActivityPath.Contains('/'))
            {
                ActivityViewModel rootActivityViewModel = this.ParentScope.ActivityCollection.Activities.FirstOrDefault(
                    activityViewModel => string.Equals(activityViewModel.Name, this.description.ActivityPath, StringComparison.OrdinalIgnoreCase));
                if (rootActivityViewModel != null)
                {
                    ScopeNavigationController.Default.NavigateToActivityXamlPage(rootActivityViewModel);
                }
            }
        }
    }
}
