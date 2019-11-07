//---------------------------------------------------------------------------------
// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using SL.Phone.Federation.Utilities;

namespace SL.Phone.Federation.Controls
{
    /// <summary>
    /// This control is used to aquire a token from ACS using passive protocals between ACS and the Identity Provider.
    /// </summary>
    public partial class AccessControlServiceSignIn : UserControl
    {
        private Uri _identityProviderDiscoveryService = null;
        private bool _navigatingToIdentityProvider = false;
        private object _navigatingToIdentityProviderLock = new object();
        private string _realm = null;
        private string _serviceNamespace = null;
        private string _acsHostUrl = null;
        private RequestSecurityTokenResponseStore _rstrStore;
        private IdentityProviderInformation _selectedIdentityProvider = null;
        private bool _setBrowserVisible = false;
        private object _setBrowserVisibleLock = new object();
        
        /// <summary>
        /// Occurs when a security token that issued by ACS and ready to be presented to the application
        /// </summary>
        public event EventHandler<RequestSecurityTokenResponseCompletedEventArgs> RequestSecurityTokenResponseCompleted;

        /// <summary>
        /// Initializes a new instance of the AccessControlServiceSignInControl class. 
        /// </summary>
        public AccessControlServiceSignIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets whether there is at least one state that the control can navigate back from.
        /// <value>True if a least one state can be undone, or false otherwise.</value>
        /// </summary>
        public bool CanGoBack { get { return _navigatingToIdentityProvider; } }

        /// <summary>
        /// Gets and Sets the RequestSecurityTokenResponseStore which is used to store
        /// the RequestSecurityTokenResponse returned from ACS
        /// </summary>
        public RequestSecurityTokenResponseStore RequestSecurityTokenResponseStore
        {
            get { return _rstrStore; }
            set { _rstrStore = value; }
        }

        /// <summary>
        /// Gets and Sets the Realm info
        /// </summary>
        public string Realm
        {
            get { return _realm; }
            set { _realm = value; }
        }

        /// <summary>
        /// Gets and sets the ACS tenant namespace which has been configured for this application
        /// </summary>
        public string ServiceNamespace
        {
            get { return _serviceNamespace; }
            set { _serviceNamespace = value; }
        }

        /// <summary>
        /// Gets and sets the host URL of ACS
        /// </summary>
        public string AcsHostUrl
        {
            get { return _acsHostUrl; }
            set { _acsHostUrl = value; }
        }

        /// <summary>
        /// Initiates an asynchronous request which prompts user to sign into an identity provider, from the list returned by the
        /// call to the discover service returns a security token via the RequestSecurityTokenResponseCompleted event handler. 
        /// </summary>
        /// 
        /// <remarks>
        /// Initiates a token request from ACS following these steps:
        /// 1) Get the list of configured Identity Providers from ACS by calling the discovery service
        /// 2) Once the user selects their identity provider, navigate to the sign in page of the provider
        /// 3) Using the WebBrowser control to complete the passive token request complete
        /// 4) Get the token
        /// 5) If a RequestSecurityTokenResponseStore is specified, set the token.
        /// 6) return the token using the RequestSecurityTokenResponseCompleted callback
        /// </remarks>
        /// <param name="identityProviderDiscoveryService">The Identity provider discovery service from the ACS managment portal.</param>
        public void GetSecurityToken(Uri identityProviderDiscoveryService)
        {
            _identityProviderDiscoveryService = identityProviderDiscoveryService;

            IdentityProviderList_Refresh(_identityProviderDiscoveryService);
        }

        /// <summary>
        /// Constructs the url for the protocol Javascriptnotify for direct handling of the JSON data
        /// </summary>
        public void GetSecurityToken()
        {
            if (null == _realm)
            {
                throw new InvalidOperationException("Realm was not set");
            }

            if (null == _serviceNamespace)
            {
                throw new InvalidOperationException("ServiceNamespace was not set");
            }

            Uri identityProviderDiscovery = new Uri(
                string.Format(CultureInfo.InvariantCulture,
                    "https://{0}.{1}/v2/metadata/IdentityProviders.js?protocol=javascriptnotify&realm={2}&version=1.0",
                    _serviceNamespace,
                    _acsHostUrl,
                    HttpUtility.UrlEncode(_realm)),
                UriKind.Absolute
                );

            GetSecurityToken(identityProviderDiscovery);
        }

        /// <summary>
        /// Performs a backward navigation action, transitioning the control to a previous state. 
        /// <remarks>
        /// If the control is in a state that it cannot go backwards, no action is taken.
        /// </remarks>
        /// </summary>
        public void GoBack()
        {
            lock (_navigatingToIdentityProviderLock)
            {
                if (_navigatingToIdentityProvider)
                {
                    ShowProgressBar(String.Empty);
                    IdentityProviderList_Refresh(_identityProviderDiscoveryService);
                    _navigatingToIdentityProvider = false;
                }
            }
        }

        private void IdentityProviderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdentityProviderInformation identityProvider = IdentityProviderList.SelectedItem as IdentityProviderInformation;

            NavigateToIdentityProvider(identityProvider);

            //
            // Reset to default value
            //
            IdentityProviderList.SelectedIndex = -1;
        }

        private void NavigateToIdentityProvider(IdentityProviderInformation identityProvider)
        {
            if (null != identityProvider)
            {
                ShowProgressBar(String.Format(String.Format("Contacting {0}", identityProvider.Name)));

                lock (_navigatingToIdentityProviderLock)
                {
                    _navigatingToIdentityProvider = true;
                    BrowserSigninControl.Navigated += new EventHandler<NavigationEventArgs>(SignInWebBrowserControl_Navigated);
                    BrowserSigninControl.Navigating += new EventHandler<NavigatingEventArgs>(SignInWebBrowserControl_Navigating);
                    BrowserSigninControl.ScriptNotify += new EventHandler<NotifyEventArgs>(SignInWebBrowserControl_ScriptNotify);
                    _selectedIdentityProvider = identityProvider;
                    BrowserSigninControl.NavigateToString("<html><head><title></title></head><body></body></html>");
                }
            }
        }

        private void IdentityProviderList_Refresh(Uri identityProviderDiscoveryService)
        {
            JSONIdentityProviderDiscoveryClient jsonClient = new JSONIdentityProviderDiscoveryClient();
            jsonClient.GetIdentityProviderListCompleted += new EventHandler<GetIdentityProviderListEventArgs>(IdentityProviderList_RefreshCompleted);
            jsonClient.GetIdentityProviderListAsync(identityProviderDiscoveryService);
        }

        private void IdentityProviderList_RefreshCompleted(object sender, GetIdentityProviderListEventArgs e)
        {
            if (null == e.Error)
            {
                IdentityProviderList.ItemsSource = e.Result;
                ShowIdentityProviderSelection();
            }
            else
            {
                DisplayErrorMessageFromException(e.Error);
            }
        }

        private void SignInWebBrowserControl_ScriptNotify(object sender, NotifyEventArgs e)
        {
            RequestSecurityTokenResponse rstr = null;
            Exception exception = null;
            try
            {
                ShowProgressBar("Signing In");
                                
                rstr = RequestSecurityTokenResponse.FromJSON(e.Value);

                if (null == rstr)
                {
                    DisplayErrorMessage("Failed reading RSTR");
                    exception = new InvalidOperationException("Failed to get a valid RequestSecurityTokenResponse");
                }

                if (null != _rstrStore)
                {
                    _rstrStore.RequestSecurityTokenResponse = rstr;
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessageFromException(ex);
                exception = ex;
            }

            if (null != RequestSecurityTokenResponseCompleted)
            {
                RequestSecurityTokenResponseCompleted(this, new RequestSecurityTokenResponseCompletedEventArgs(rstr, exception));
            }

        }
        
        private void SignInWebBrowserControl_Navigated(object sender, NavigationEventArgs e)
        { // navigate if at empty page, and a idp hrd url is available
            if (null == e.Uri && null != _selectedIdentityProvider)
            {
                BrowserSigninControl.Navigate(new Uri(_selectedIdentityProvider.LoginUrl));
            }
            else
            {
                if (_navigatingToIdentityProvider)
                {
                    lock (_setBrowserVisibleLock)
                    {
                        _setBrowserVisible = true;
                    }

                    Thread show = new Thread(() =>
                    {
                        System.Threading.Thread.CurrentThread.Join(250);

                        lock (_setBrowserVisibleLock)
                        {
                            if (_setBrowserVisible && _navigatingToIdentityProvider)
                            {
                                Dispatcher.BeginInvoke(() => { ShowBrowser(); });
                            }
                        }
                    });

                    show.Start();
                }
            }
        }

        private void SignInWebBrowserControl_Navigating(object sender, NavigatingEventArgs e)
        {
            lock (_setBrowserVisibleLock)
            {
                _setBrowserVisible = false;
                ShowProgressBar(null);
            }
        }

        private void DisplayErrorMessageFromException(Exception e)
        {
            if (null != e)
            {
                DisplayErrorMessage(e.Message);
            }
        }

        private void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void HideAll()
        {
            identityProviderDiscovery.Visibility = Visibility.Collapsed;
            BrowserSigninControl.Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void ShowBrowser()
        {
            HideAll();
            BrowserSigninControl.Visibility = Visibility.Visible;
          
        }

        private void ShowIdentityProviderSelection()
        {
            HideAll();
            identityProviderDiscovery.Visibility = Visibility.Visible;
        }

        private void ShowProgressBar(string message)
        {
            HideAll();
            if (null != message)
            {
                progressBarLabel.Text = message;
            }

            progressBar.Visibility = Visibility.Visible;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (sender as TextBlock).Opacity = .5;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (sender as TextBlock).Opacity = 1;
        }


        private void TextBlock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as TextBlock).Opacity = 1;
        }

    }
}

