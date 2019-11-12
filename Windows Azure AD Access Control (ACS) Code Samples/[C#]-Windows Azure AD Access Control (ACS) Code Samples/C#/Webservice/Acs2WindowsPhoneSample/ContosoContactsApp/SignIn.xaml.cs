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
using System.Windows;
using Microsoft.Phone.Controls;

namespace ContosoContactsApp
{
    public partial class SignIn : PhoneApplicationPage
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SignInControl.RequestSecurityTokenResponseCompleted += new EventHandler<SL.Phone.Federation.Controls.RequestSecurityTokenResponseCompletedEventArgs>(SignInControl_RequestSecurityTokenResponseCompleted);
            SignInControl.GetSecurityToken();
        }

        void SignInControl_RequestSecurityTokenResponseCompleted(object sender, SL.Phone.Federation.Controls.RequestSecurityTokenResponseCompletedEventArgs e)
        {
            if (null == e.Error)
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SignInControl.CanGoBack)
            {
                SignInControl.GoBack();
                e.Cancel = true;
            }
        }
    }
}