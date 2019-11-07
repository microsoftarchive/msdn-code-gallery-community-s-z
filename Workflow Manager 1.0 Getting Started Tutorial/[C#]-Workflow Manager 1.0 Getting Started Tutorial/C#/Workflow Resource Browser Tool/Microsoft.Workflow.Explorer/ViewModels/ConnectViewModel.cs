//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer;
    using Microsoft.Workflow.Explorer.Controllers;
    using Microsoft.Workflow.Explorer.Properties;
    using Microsoft.Workflow.Explorer.Views;

    public class ConnectViewModel : ViewModelBase
    {
        TaskCompletionSource<ServiceContext> serviceConnectionCompletionSource;
        ConnectWindow connectDialog;
        SimpleActionCommand connectCommand;

        string serviceUriInput = Settings.Default.WorkflowServiceUri;
        bool isReadyForInput;
        string errorMessage;

        public ConnectViewModel()
        {
            this.isReadyForInput = true;
            this.connectCommand = new SimpleActionCommand(this.OnConnect);

            if (string.IsNullOrWhiteSpace(this.ServiceUriInput))
            {
                // start with the default URI for a server install on the local machine
                this.serviceUriInput = new UriBuilder(Uri.UriSchemeHttps, Dns.GetHostEntry(string.Empty).HostName, 12290).Uri.AbsoluteUri;
            }
        }

        public ICommand ConnectCommand
        {
            get { return this.connectCommand; }
        }

        public string ServiceUriInput
        {
            get { return this.serviceUriInput; }
            set
            {
                if (this.serviceUriInput != value)
                {
                    this.serviceUriInput = value;
                    Settings.Default.WorkflowServiceUri = value;
                    this.RaisePropertyChanged("ServiceUriInput");
                }
            }
        }

        public bool IsReadyForInput
        {
            get { return this.isReadyForInput; }
            set
            {
                if (this.isReadyForInput != value)
                {
                    this.isReadyForInput = value;
                    this.RaisePropertyChanged("IsReadyForInput");
                }
            }
        }

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set
            {
                if (this.errorMessage != value)
                {
                    this.errorMessage = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }

        public ServiceContext ServiceContext
        {
            get;
            private set;
        }

        void OnConnect(object arg)
        {
            ClientSettings settings = new ClientSettings
            {
                Credentials = CredentialCache.DefaultNetworkCredentials,
                RequestTimeout = TimeSpan.FromSeconds(60)
            };

            Uri serviceUri;
            if (!Uri.TryCreate(this.ServiceUriInput.Trim(), UriKind.Absolute, out serviceUri))
            {
                this.ErrorMessage = "Invalid URI";
                this.IsReadyForInput = true;
                return;
            }

            this.IsReadyForInput = false;
            this.ServiceContext = null;
            this.ErrorMessage = null;

            this.PingServiceForUnauthorizedChallenge(serviceUri, settings);
        }

        internal Task<ServiceContext> ConnectToServiceAsync()
        {
            this.serviceConnectionCompletionSource = new TaskCompletionSource<ServiceContext>();

            Task.Factory.StartNew(this.DisplayConnectionDialog, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.FromCurrentSynchronizationContext());

            return this.serviceConnectionCompletionSource.Task;
        }

        void PingServiceForUnauthorizedChallenge(Uri serviceUri, ClientSettings settings)
        {
            Trace.TraceInformation("Attempting to connect to {0}...", serviceUri);
            HttpClient client = new HttpClient(
                new HttpClientHandler
                {
                    // use default network credentials to enable the simple windows login case
                    Credentials = CredentialCache.DefaultCredentials
                });

            CancellationToken cancellationToken = new CancellationToken();
            Task<HttpResponseMessage> pingResponse = client.GetAsync(serviceUri, cancellationToken);

            // configure a 10 second timeout
            Utils.ScheduleDelayedCallback(
                TimeSpan.FromSeconds(10),
                delegate()
                {
                    lock (client)
                    {
                        if (!this.IsReadyForInput)
                        {
                            client.CancelPendingRequests();
                        }
                    }
                });

            pingResponse.OnSuccess(
                delegate(HttpResponseMessage response)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Trace.TraceInformation("Connected to service successfully.");
                        this.GetRootScopeAndCompleteConnection(serviceUri, settings);
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        Trace.TraceInformation("Got {0} response. Prompting user for credentials...", (int)response.StatusCode);
                        this.RequestCredentialsAndRetry(serviceUri, response, settings);
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadGateway)
                    {
                        Trace.TraceWarning("Failed to connect to the service because the endpoint was not found.");
                        this.ErrorMessage = "Endpoint was not found.";
                    }
                    else
                    {
                        Trace.TraceWarning("Failed to connect to the service due to an unexpected connection error: {0}.", response);
                        this.ErrorMessage = "Received an unexpected response: " + response;
                    }

                    lock (client)
                    {
                        this.IsReadyForInput = true;
                        client.Dispose();
                    }
                });

            pingResponse.OnFaulted(
                delegate(Exception e)
                {
                    Trace.TraceWarning("The HTTP request faulted: {0}", e);

                    AggregateException aggregateException = e as AggregateException;
                    if (aggregateException != null && e.InnerException != null)
                    {
                        e = aggregateException.InnerException;
                    }

                    HttpRequestException requestException = e as HttpRequestException;
                    if (requestException != null && requestException.InnerException != null)
                    {
                        e = requestException.InnerException;
                    }

                    this.ErrorMessage = "Failed to connect to the service: " + e.Message;

                    lock (client)
                    {
                        this.IsReadyForInput = true;
                        client.Dispose();
                    }
                });

            pingResponse.OnCanceled(
                delegate()
                {
                    this.ErrorMessage = "Timed-out while waiting for a response from the server.";

                    lock (client)
                    {
                        this.IsReadyForInput = true;
                        client.Dispose();
                    }
                });
        }

        void RequestCredentialsAndRetry(Uri serviceUri, HttpResponseMessage response, ClientSettings settings)
        {
            ICollection<AuthenticationViewModelBase> authTypes = CredentialSelectionController.Default.AuthenticationTypes;
            authTypes.Clear();
            CredentialsWindow credentialsWindow = new CredentialsWindow();
            credentialsWindow.DataContext = this;

            Action<ServiceContext> onGotCredentialsAction = delegate(ServiceContext serviceContext)
            {
                // save the context and close all the dialogs
                this.ServiceContext = serviceContext;
                credentialsWindow.DialogResult = true;
                this.connectDialog.DialogResult = true;
            };
            
            foreach (AuthenticationHeaderValue value in response.Headers.WwwAuthenticate)
            {
                switch (value.Scheme.ToUpperInvariant())
                {
                    case "BEARER":
                        Trace.TraceInformation("Found Bearer challenge");
                        if (!authTypes.OfType<OAuthS2SAuthenticationViewModel>().Any())
                        {
                            authTypes.Add(new OAuthS2SAuthenticationViewModel(serviceUri, onGotCredentialsAction));
                        }
                        break;
                    case "NTLM":
                    case "NEGOTIATE":
                        Trace.TraceInformation("Found Windows Auth challenge");
                        if (!authTypes.OfType<WindowsAuthenticationViewModel>().Any())
                        {
                            authTypes.Add(new WindowsAuthenticationViewModel(serviceUri, onGotCredentialsAction));
                        }
                        break;
                }
            }

            if (credentialsWindow.ShowDialog() != true)
            {
                Trace.TraceInformation("User canceled from the authorization step.");
            }
        }

        void GetRootScopeAndCompleteConnection(Uri serviceUri, ClientSettings settings)
        {
            Task<ServiceContext> connectTask = ServiceContext.ConnectAsync(serviceUri, settings);
            connectTask.OnSuccess(
                delegate(ServiceContext serviceContext)
                {
                    this.ServiceContext = serviceContext;
                    this.IsReadyForInput = true;
                    this.connectDialog.DialogResult = true;
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
                    this.IsReadyForInput = true;
                });
            connectTask.OnCanceled(
                delegate()
                {
                    this.IsReadyForInput = true;
                    this.connectDialog.DialogResult = false;
                });
        }

        void DisplayConnectionDialog()
        {
            this.connectDialog = new ConnectWindow();
            this.connectDialog.DataContext = this;
            if (this.connectDialog.ShowDialog() == true)
            {
                this.serviceConnectionCompletionSource.SetResult(this.ServiceContext);
            }
            else
            {
                this.serviceConnectionCompletionSource.SetCanceled();
            }
         }
    }
}
