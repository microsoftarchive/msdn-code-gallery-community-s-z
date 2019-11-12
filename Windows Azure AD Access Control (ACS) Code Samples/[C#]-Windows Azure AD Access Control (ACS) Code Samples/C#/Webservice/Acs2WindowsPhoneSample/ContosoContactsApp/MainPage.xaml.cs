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
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using Microsoft.Phone.Controls;
using SL.Phone.Federation.Utilities;

namespace ContosoContactsApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        RequestSecurityTokenResponseStore _rstrStore = App.Current.Resources["rstrStore"] as RequestSecurityTokenResponseStore;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_rstrStore.ContainsValidRequestSecurityTokenResponse())
            {
                PopulateContactList();
                ApplicationBar.IsVisible = true;
                SignInLink.Visibility = Visibility.Collapsed;
            }
            else
            {
                SignInLink.Visibility = Visibility.Visible;
            }
        }

        private void PopulateContactList()
        {
            WebClient client = new WebClient();
            client.Headers["Authorization"] = "OAuth " + _rstrStore.SecurityToken;
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri("http://localhost/contacts/Directory"));
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (null == e.Error)
            {
                string s = e.Result;

                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Contact[]));
                Contact[] contacts = serializer.ReadObject(ms) as Contact[];
                ms.Close();

                ContactsListBox.ItemsSource = contacts;
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void SignInLink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SignIn.xaml", UriKind.Relative));
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            _rstrStore.RequestSecurityTokenResponse = null;
            ContactsListBox.ItemsSource = null;

            ApplicationBar.IsVisible = false;
            SignInLink.Visibility = Visibility.Visible;
        }
    }
}