//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Properties;
    using Microsoft.Workflow.Explorer.Controllers;

    public abstract class AuthenticationViewModelBase : ViewModelBase
    {
        Uri serviceUri;
        Action<ServiceContext> onConnected;
        string errorMessage;
        bool isNotConnecting;

        public AuthenticationViewModelBase(Uri serviceUri, Action<ServiceContext> onConnected)
        {
            this.serviceUri = serviceUri;
            this.onConnected = onConnected;
            this.SelectedCommand = new SimpleActionCommand(this.OnSelectedInternal);
            this.LoginCommand = new SimpleActionCommand(this.OnLogin);
            this.CancelCommand = new SimpleActionCommand(this.OnCancel);
        }

        public abstract ImageSource Icon
        {
            get;
        }

        public abstract string Description
        {
            get;
        }

        public ICommand SelectedCommand
        {
            get;
            private set;
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            protected set
            {
                if (this.errorMessage != value)
                {
                    this.errorMessage = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }

        public bool IsNotConnecting
        {
            get { return this.isNotConnecting; }
            protected set
            {
                if (this.isNotConnecting != value)
                {
                    this.isNotConnecting = value;
                    this.RaisePropertyChanged("IsNotConnecting");
                }
            }
        }

        protected abstract void OnSelected();

        protected void Authenticate()
        {
            // virtual method call to get the client credentials
            ICredentials clientCredentials;
            if (!this.TryCreateCredentials(this.serviceUri, out clientCredentials))
            {
                return;
            }
            
            ClientSettings settings = new ClientSettings
            {
                Credentials = clientCredentials,
                RequestTimeout = Settings.Default.ClientRequestTimeout
            };

            Task<ServiceContext> connectTask = ServiceContext.ConnectAsync(this.serviceUri, settings);
            connectTask.OnSuccess(
                delegate(ServiceContext serviceContext)
                {
                    this.onConnected.Invoke(serviceContext);
                    this.IsNotConnecting = true;
                });
            connectTask.OnFaulted(
                delegate(Exception error)
                {
                    AggregateException aggregateException = error as AggregateException;
                    if (aggregateException != null)
                    {
                        error = aggregateException.GetBaseException();
                    }

                    this.ErrorMessage = error.Message;
                    this.IsNotConnecting = true;
                });
            connectTask.OnCanceled(
                delegate()
                {
                    this.IsNotConnecting = true;
                });
        }

        protected abstract bool TryCreateCredentials(Uri serviceUri, out ICredentials clientCredentials);

        protected virtual void OnCancel()
        {
            CredentialSelectionController.Default.GoBack();
        }

        void OnLogin(object arg)
        {
            this.ErrorMessage = string.Empty;
            this.Authenticate();
        }

        void OnCancel(object arg)
        {
            // virtual method call
            this.OnCancel();
        }

        void OnSelectedInternal(object arg)
        {
            // virtual method call
            this.OnSelected();
        }
    }
}
