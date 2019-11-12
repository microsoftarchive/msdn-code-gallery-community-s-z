// Copyright 2013 Microsoft Corporation
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

using System;
using System.Configuration;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.Linq;

namespace ASPNETSimpleMVC4.Models
{
    public class LogoutHandler
    {
        public string Signout()
        {
            // Load Identity Configuration
            FederationConfiguration config = FederatedAuthentication.FederationConfiguration;

            // Get wtrealm from WsFederationConfiguation Section
            string wtrealm = config.WsFederationConfiguration.Realm;
            string wreply;

            // Construct wreply value from wtrealm
            if (wtrealm.Last().Equals('/'))
            {
                wreply = wtrealm + "Logout";
            }
            else
            {
                wreply = wtrealm + "/Logout";
            }

            // Read the ACS Ws-Federation endpoint from web.Config
            string wsFederationEndpoint = ConfigurationManager.AppSettings["ida:Issuer"];

            SignOutRequestMessage signoutRequestMessage = new SignOutRequestMessage(new Uri(wsFederationEndpoint));

            signoutRequestMessage.Parameters.Add("wreply", wreply);
            signoutRequestMessage.Parameters.Add("wtrealm", wtrealm);

            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            return signoutRequestMessage.WriteQueryString();            
        }
    }
}