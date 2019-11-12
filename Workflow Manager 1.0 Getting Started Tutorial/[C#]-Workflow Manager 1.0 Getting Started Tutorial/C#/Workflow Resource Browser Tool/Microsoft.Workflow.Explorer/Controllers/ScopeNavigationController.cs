//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controllers
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Workflow.Explorer.ViewModels;
    using Microsoft.Workflow.Explorer.Views;

    class ScopeNavigationController : NavigationControllerBase
    {
        static ScopeNavigationController defaultInstance;

        // callers are expected to use the default static instance
        ScopeNavigationController()
        {
        }

        public static ScopeNavigationController Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new ScopeNavigationController();
                }

                return defaultInstance;
            }
        }

        public void NavigateToScope(ScopeViewModel scope)
        {
            this.NavigateToPage(new ScopeDetailsPage(), scope);
        }

        public void NavigateToActivitiesSummaryPage(ScopeViewModel selectedScope)
        {
            this.NavigateToPage(new ActivitiesSummaryPage(), selectedScope);
        }

        public void NavigateToActivityXamlPage(ActivityViewModel selectedActivity)
        {
            this.NavigateToPage(new ActivityXamlPage(), selectedActivity);
        }

        public void NavigateToWorkflowsSummaryPage(ScopeViewModel selectedScope)
        {
            this.NavigateToPage(new WorkflowsSummaryPage(), selectedScope);
        }

        public void NavigateToSecuritySettingsPage(SecuritySettingsViewModel securitySettings)
        {
            this.NavigateToPage(new SecuritySettingsPage(), securitySettings);
        }

        public void NavigateToExternalVariablesPage(ExternalVariablesViewModel externalVariablesViewModel)
        {
            this.NavigateToPage(new ExternalVariablesPage(), externalVariablesViewModel);
        }

        public void NavigateToInstancesPage(InstanceCollectionViewModel instanceCollectionViewModel)
        {
            this.NavigateToPage(new InstancesSummaryPage(), instanceCollectionViewModel);
        }

        public void NavigateToDictionaryPage(IDictionary dictionary)
        {
            this.NavigateToPage(new DictionaryPage(), dictionary);
        }

        public void NavigateToWorkflowConfigurationPage(WorkflowConfigurationViewModel configViewModel)
        {
            this.NavigateToPage(new WorkflowConfigurationPage(), configViewModel);
        }

        public void ClearHistory()
        {
            if (this.NavigationService != null)
            {
                JournalEntry entry = this.NavigationService.RemoveBackEntry();
                while (entry != null)
                {
                    entry = this.NavigationService.RemoveBackEntry();
                }
            }
        }

        void NavigateToPage(Page page, object dataContext)
        {
            if (this.NavigationService != null)
            {
                page.Loaded += (sender, args) => ((FrameworkElement)sender).DataContext = dataContext;
                this.NavigationService.Navigate(page);
            }
        }
    }
}
