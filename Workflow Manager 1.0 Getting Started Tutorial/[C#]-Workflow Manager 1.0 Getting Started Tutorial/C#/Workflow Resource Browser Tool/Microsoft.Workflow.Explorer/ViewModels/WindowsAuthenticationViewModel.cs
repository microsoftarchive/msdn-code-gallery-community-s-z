//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Security;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Workflow.Explorer.Controllers;
    using Microsoft.Workflow.Explorer.Properties;

    class WindowsAuthenticationViewModel : AuthenticationViewModelBase
    {
        static readonly ImageSource WindowsAuthImage = new BitmapImage(new Uri("/Images/Windows_Logo_Flag.png", UriKind.Relative));

        string username = Settings.Default.WindowsAuth_Username;
        string password;

        public WindowsAuthenticationViewModel(Uri serviceUri, Action<ServiceContext> onConnected)
            : base(serviceUri, onConnected)
        {
        }

        public override ImageSource Icon
        {
            get { return WindowsAuthImage; }
        }

        public override string Description
        {
            get { return "Windows Authentication"; }
        }

        public string CurrentUserDescription
        {
            get 
            {
                // TODO: Get this from a resource file
                return string.Format(
                    CultureInfo.CurrentUICulture,
                    @"Current User Credentials ({0}\{1})",
                    Environment.UserDomainName,
                    Environment.UserName);
            }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (this.username != value)
                {
                    this.username = value;
                    Settings.Default.WindowsAuth_Username = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }

        // TODO: Find a way to bind to the SecureString property of the PasswordBox control
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }

        protected override void OnSelected()
        {
            CredentialSelectionController.Default.NavigateToWindowsAuthPage(this);
        }

        protected override bool TryCreateCredentials(Uri serviceUri, out ICredentials clientCredentials)
        {
            clientCredentials = null;

            string username = this.Username.Trim();
            if (string.IsNullOrEmpty(username))
            {
                this.ErrorMessage = "Please specify a username.";
            }
            else
            {
                clientCredentials = new NetworkCredential(this.Username, this.Password);
            }

            return clientCredentials != null;
        }
    }
}
