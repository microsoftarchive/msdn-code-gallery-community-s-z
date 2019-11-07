//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controllers
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Microsoft.Workflow.Explorer.ViewModels;
    using Microsoft.Workflow.Explorer.Views;

    class CredentialSelectionController : NavigationControllerBase
    {
        static CredentialSelectionController defaultInstance;

        ObservableCollection<AuthenticationViewModelBase> authenticationViewModels;

        // callers are expected to use the default static instance
        CredentialSelectionController()
        {
        }

        public static CredentialSelectionController Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new CredentialSelectionController();
                }

                return defaultInstance;
            }
        }

        public ObservableCollection<AuthenticationViewModelBase> AuthenticationTypes
        {
            get
            {
                if (this.authenticationViewModels == null)
                {
                    this.authenticationViewModels = new ObservableCollection<AuthenticationViewModelBase>();
                }

                return this.authenticationViewModels;
            }
        }

        internal void NavigateToWindowsAuthPage(WindowsAuthenticationViewModel windowsAuthenticationViewModel)
        {
            Debug.Assert(this.NavigationService != null, "The navigationService should be initialized before attempting to navigate.");
            WindowsAuthCredentialPage windowsAuthCredentialsPage = new WindowsAuthCredentialPage();
            windowsAuthCredentialsPage.DataContext = windowsAuthenticationViewModel;
            this.NavigationService.Navigate(windowsAuthCredentialsPage);
        }

        internal void NavigateToOAuthS2SPage(OAuthS2SAuthenticationViewModel oAuthS2SAuthenticationViewModel)
        {
            Debug.Assert(this.NavigationService != null, "The navigationService should be initialized before attempting to navigate.");
            OAuthS2SCredentialsPage oAuthS2SCredentialsPage = new OAuthS2SCredentialsPage();
            oAuthS2SCredentialsPage.DataContext = oAuthS2SAuthenticationViewModel;
            this.NavigationService.Navigate(oAuthS2SCredentialsPage);
        }
    }
}
