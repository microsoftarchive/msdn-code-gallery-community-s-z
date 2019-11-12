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
using System.Security.Cryptography.X509Certificates;
using ACS.Management;
using Common.ACS.Management;

namespace ConfigureSample
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ClientName = "OAuth2SampleX509Identity";
            const string RPRealm = "https://oauth2RelyingParty/";
            const string RPName = "OAuth2 RP";
            const string RuleGroupName = "Default rule group for OAuth2 RP";

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteServiceIdentityIfExists(ClientName);
            svc.DeleteRelyingPartyByRealmIfExists(RPRealm);
            svc.DeleteRuleGroupByNameIfExists(RuleGroupName);

            svc.SaveChangesBatch();

            X509Certificate2 clientCertificate = new X509Certificate2(@"..\..\..\Certificates\ACS2ClientCertificate.cer");

            svc.CreateServiceIdentity(ClientName, clientCertificate.RawData, ServiceIdentityKeyType.X509Certificate, ServiceIdentityKeyUsage.Signing);

            RelyingParty relyingParty = svc.CreateRelyingParty(RPName, RPRealm, null, RelyingPartyTokenType.SWT, false);
            RelyingPartyKey relyingPartyKey = svc.GenerateRelyingPartySymmetricKey(relyingParty, DateTime.UtcNow, DateTime.MaxValue, true);

            Console.WriteLine("Generated symmetric key: {0}", Convert.ToBase64String(relyingPartyKey.Value));

            Issuer localAuthority = svc.GetIssuerByName("LOCAL AUTHORITY");
            RuleGroup ruleGroup = svc.CreateRuleGroup(RuleGroupName);
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            svc.CreateRule(localAuthority, null, null, null, null, ruleGroup, "Pass through claims issued by ACS");

            svc.SaveChangesBatch();

            Console.WriteLine("Sample configured successfully. Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}
