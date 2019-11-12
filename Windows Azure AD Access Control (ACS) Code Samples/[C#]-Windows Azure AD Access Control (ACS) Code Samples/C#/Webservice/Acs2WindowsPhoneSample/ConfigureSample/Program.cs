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
using ACS.Management;
using Common.ACS.Management;

namespace ConfigureSample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string RPRealm = "http://ContosoContacts/";
            const string RPName = "ContosoContacts";
            const string RuleGroupName = "Default rule group for ContosoContacts";

            const string googleIdpName = "Google";
            const string yahooIdpName = "Yahoo!";

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteRelyingPartyByRealmIfExists(RPRealm);
            svc.DeleteRuleGroupByNameIfExists(RuleGroupName);
            svc.DeleteIdentityProviderIfExists(googleIdpName);
            svc.DeleteIdentityProviderIfExists(yahooIdpName);
            svc.SaveChangesBatch();

            //
            // Create Google and Yahoo! as identity providers. LiveID is already configured.
            //
            IdentityProvider live = svc.GetIdentityProviderByName("uri:WindowsLiveID");
            IdentityProvider google = svc.CreateOpenIdIdentityProvider(googleIdpName, "https://www.google.com/accounts/o8/ud");
            IdentityProvider yahoo = svc.CreateOpenIdIdentityProvider(yahooIdpName, "https://open.login.yahooapis.com/openid/op/auth");

            IdentityProvider[] associatedProviders = new[] { live, google, yahoo };

            //
            // Create the relying party and its associated key.
            //
            RelyingParty relyingParty = svc.CreateRelyingParty(RPName, RPRealm, null, RelyingPartyTokenType.SWT, false);
            svc.AssociateIdentityProvidersWithRelyingParties(associatedProviders, new[] { relyingParty });

            RelyingPartyKey relyingPartyKey = svc.GenerateRelyingPartySymmetricKey(relyingParty, DateTime.UtcNow, DateTime.MaxValue, true);

            Console.WriteLine("Generated symmetric key: {0}", Convert.ToBase64String(relyingPartyKey.Value));

            RuleGroup ruleGroup = svc.CreateRuleGroup(RuleGroupName);
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

            Console.WriteLine("Sample configured successfully. Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}
