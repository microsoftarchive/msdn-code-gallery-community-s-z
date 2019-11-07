//---------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------

using System;
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
            const string rpName = "ASPNET Simple MVC4 Sample";
            const string rpRealm = "http://localhost:65000/";            
            const string ruleGroupName = "Default rule group for ASPNET Simple MVC4 Sample";

            const string googleIdpName = "Google";
            const string yahooIdpName = "Yahoo!";

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteRelyingPartyByRealmIfExists(rpRealm);
            svc.DeleteRuleGroupByNameIfExists(ruleGroupName);
            svc.DeleteIdentityProviderIfExists(googleIdpName);
            svc.DeleteIdentityProviderIfExists(yahooIdpName);
            svc.SaveChangesBatch();

            IdentityProvider live = svc.GetIdentityProviderByName("uri:WindowsLiveID");
            IdentityProvider google = svc.CreateOpenIdIdentityProvider(googleIdpName, "https://www.google.com/accounts/o8/ud");
            IdentityProvider yahoo = svc.CreateOpenIdIdentityProvider(yahooIdpName, "https://open.login.yahooapis.com/openid/op/auth");

            IdentityProvider[] associatedProviders = new[] { live, google, yahoo };

            //
            // Create the relying party. In this case, the Realm and the ReplyTo are the same address.
            //
            RelyingParty relyingParty = svc.CreateRelyingParty(rpName, rpRealm, rpRealm, RelyingPartyTokenType.SAML_2_0, false);
            svc.AssociateIdentityProvidersWithRelyingParties(associatedProviders, new[] { relyingParty });
                        
            RuleGroup ruleGroup = svc.CreateRuleGroup(ruleGroupName);
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            //
            // Create simple rules to pass through all claims from each issuer.
            //
            foreach (IdentityProvider identityProvider in associatedProviders)
            {
                string ruleDescription = String.Format(CultureInfo.InvariantCulture, "Pass through all claims from '{0}'", identityProvider.Issuer.Name);
                svc.CreateRule(identityProvider.Issuer, null, null, null, null, ruleGroup, ruleDescription);
            }
            svc.SaveChangesBatch();

            Console.WriteLine("Sample successfully configured. Press ENTER to continue ...");
            Console.ReadLine();
        }
    }
}
