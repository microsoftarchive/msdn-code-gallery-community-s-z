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
using System.Linq;
using System.Data.Services.Client;
using System.Globalization;
using ACS.Management;
using Common.ACS.Management;

namespace ConfigureSample
{
    class Program
    {
        /// <summary>
        /// Configures the ACS service namespace with the proper objects for this sample.
        /// </summary>
        /// <remarks>
        /// Existing objects that are needed for this sample will be deleted and recreated.
        /// </remarks>
        static void Main(string[] args)
        {
            const string rpName = "ASPNET MVC3 Custom Sign-In Page Sample";
            const string rpRealm = "http://localhost:64000/";
            const string rpReplyTo = "http://localhost:64000/Account/SignIn";
            
            const string facebookName = "Facebook";
            const string yahooName = "Yahoo!";

            const string defaultRuleGroupName = "Default rule group for ASPNET MVC3 Custom Sign-In Page Sample";

            // Please update these with your own Facebook application information
            const string applicationId = "applicationid";
            const string applicationSecret = "applicationsecret";

            string facebookIdpName = String.Format(CultureInfo.InvariantCulture, "Facebook-{0}", applicationId);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
                        
            //
            // Clean up pre-existing configuration
            //
            svc.DeleteRelyingPartyByRealmIfExists(rpRealm);
            svc.DeleteRuleGroupByNameIfExists(defaultRuleGroupName);
            svc.DeleteIdentityProviderIfExists(facebookIdpName);
            svc.DeleteIdentityProviderIfExists(yahooName);
            svc.SaveChangesBatch();

            //
            // Create Identity Providers
            //
            IdentityProvider live = svc.GetIdentityProviderByName("uri:WindowsLiveID");;

            IdentityProvider facebook = svc.CreateFacebookIdentityProvider(applicationId, applicationSecret, "email,user_events");
            SetSignInInformation(svc, facebook, facebookName);

            IdentityProvider yahoo = svc.CreateOpenIdIdentityProvider(yahooName, "https://open.login.yahooapis.com/openid/op/auth");
            SetSignInInformation(svc, yahoo, yahooName);

            IdentityProvider[] associatedProviders = new[] { live, facebook, yahoo };

            //
            // Create Relying Party
            //
            RelyingParty relyingParty = svc.CreateRelyingParty(rpName, rpRealm, rpReplyTo, RelyingPartyTokenType.SAML_2_0, false);

            svc.AssociateIdentityProvidersWithRelyingParties(associatedProviders, new[] { relyingParty });

            RuleGroup ruleGroup = svc.CreateRuleGroup(defaultRuleGroupName);
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            //
            // Create simple rules to pass through all claims from each issuer.
            //
            foreach (IdentityProvider identityProvider in associatedProviders)
            {
                string ruleDescription = string.Format(CultureInfo.InvariantCulture, "Pass through all claims from '{0}'", identityProvider.Issuer.Name);
                svc.CreateRule(identityProvider.Issuer, null, null, null, null, ruleGroup, ruleDescription);
            }
            svc.SaveChangesBatch();

            Console.WriteLine("Sample successfully configured. Press ENTER to continue ...");
            Console.ReadLine();

        }

        /// <summary>
        /// Set the signin information for the identity provider.
        /// </summary>
        /// <remarks>
        /// The changes are not saved.
        /// </remarks>
        private static void SetSignInInformation(ManagementService svc, IdentityProvider identityProvider, string SignInName = null)
        {
            identityProvider.LoginLinkName = SignInName;
            svc.UpdateObject(identityProvider);
        }
    }
}
