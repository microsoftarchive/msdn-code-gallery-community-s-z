//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Navigation;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Controllers;
    using Microsoft.Workflow.Explorer.ViewModels;

    public class ServiceContext : ViewModelBase
    {
        Uri baseUri;
        WorkflowManagementClient client;
        SimpleActionCommand refreshCommand;
        ScopeViewModel selectedScope;

        public ServiceContext(Uri baseUri, ClientSettings settings, ScopeDescription rootScope)
        {
            this.baseUri = baseUri;
            this.ClientSettings = settings;
            this.RootScope = new ScopeViewModel(rootScope, null, this);
            this.SelectedScope = this.RootScope;

            this.refreshCommand = new SimpleActionCommand(source => this.Refresh());
        }

        public Uri BaseUri
        {
            get { return this.baseUri; }
            set
            {
                if (this.baseUri != value)
                {
                    this.baseUri = value;
                    this.RaisePropertyChanged("BaseUri");
                }
            }
        }

        public ClientSettings ClientSettings
        {
            get;
            private set;
        }

        public ScopeViewModel RootScope
        {
            get;
            private set;
        }

        public ObservableCollection<ScopeViewModel> RootScopeAsCollection
        {
            get { return new ObservableCollection<ScopeViewModel> { this.RootScope }; }
        }

        public WorkflowManagementClient Client
        {
            get
            {
                if (this.client == null)
                {
                    this.client = new WorkflowManagementClient(this.BaseUri, this.ClientSettings);
                }

                return this.client;
            }
        }

        public ScopeViewModel SelectedScope
        {
            get { return this.selectedScope; }
            set
            {
                if (this.selectedScope != value)
                {
                    this.selectedScope = value;
                    this.RaisePropertyChanged("SelectedScope");
                    ScopeNavigationController.Default.NavigateToScope(value);
                }
            }
        }

        public ICommand RefreshCommand
        {
            get { return this.refreshCommand; }
        }

        internal Uri CreateUri(string resourcePath)
        {
            string baseUri = this.BaseUri.OriginalString;
            if (!baseUri.EndsWith("/"))
            {
                baseUri += "/";
            }

            return new Uri(baseUri + resourcePath.TrimStart('/'));
        }

        internal WorkflowManagementClient CreateClient(ScopeDescription scope)
        {
            return new WorkflowManagementClient(this.CreateUri(scope.Path), this.ClientSettings);
        }

        internal static Task<ServiceContext> ConnectAsync(Uri serviceUri, ClientSettings settings)
        {
            Trace.TraceInformation("Attempting to fetch the scope from {0}...", serviceUri);
            WorkflowManagementClient client = new WorkflowManagementClient(serviceUri, settings);
            TaskCompletionSource<ServiceContext> completionSource = new TaskCompletionSource<ServiceContext>();
            Task<ScopeDescription> getScopeTask = client.CurrentScope.GetAsync();
            getScopeTask.OnSuccess(rootScope => completionSource.SetResult(new ServiceContext(serviceUri, settings, rootScope)));
            getScopeTask.OnFaulted(exception => completionSource.SetException(exception));
            getScopeTask.OnCanceled(() => completionSource.SetCanceled());
            return completionSource.Task;
        }

        void Refresh()
        {
            // requery the root scope
            ScopeDescription rootScope = this.Client.CurrentScope.Get();
            this.RootScope = new ScopeViewModel(rootScope, null, this);
            this.SelectedScope.IsSelected = false;
            this.SelectedScope = this.RootScope;
            this.RootScope.IsSelected = true;
            this.RaisePropertyChanged("RootScopeAsCollection");

            ScopeNavigationController.Default.NavigateToScope(this.RootScope);
            ScopeNavigationController.Default.ClearHistory();
        }
    }
}
