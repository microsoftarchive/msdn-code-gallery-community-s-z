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
using System.Text;
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
            const string rpName = "ASPNET Simple Service";
            const string rpRealm = "http://localhost:8000/Service/";
            const string serviceIdentityName = "acssample";
            const string serviceIdentityPassword = "pass@word1";
            const string ruleGroupName = "Default rule group for ASPNET Simple Service";

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteRelyingPartyByRealmIfExists(rpRealm);
            svc.DeleteServiceIdentityIfExists(serviceIdentityName);
            svc.DeleteRuleGroupByNameIfExists(ruleGroupName);
            svc.SaveChangesBatch();

            RelyingParty relyingParty = svc.CreateRelyingParty(rpName, rpRealm, rpRealm, RelyingPartyTokenType.SWT, false);

            RelyingPartyKey relyingPartyKey = svc.GenerateRelyingPartySymmetricKey(relyingParty, DateTime.UtcNow, DateTime.UtcNow.AddYears(1), true);

            Console.WriteLine("Generated symmetric key value: {0}", Convert.ToBase64String(relyingPartyKey.Value));

            svc.CreateServiceIdentity(serviceIdentityName, Encoding.UTF8.GetBytes(serviceIdentityPassword), ServiceIdentityKeyType.Password, ServiceIdentityKeyUsage.Password);

            RuleGroup ruleGroup = svc.CreateRuleGroup(ruleGroupName);
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            //
            // Add a rule to issue the "action=reverse" claim.
            //
            svc.CreateRule(svc.GetIssuerByName("LOCAL AUTHORITY"), null, null, "action", "reverse", ruleGroup, "Issue action=reverse claim.");
            svc.SaveChangesBatch();

            Console.WriteLine("Sample successfully configured. Press ENTER to continue ...");
            Console.ReadLine();
        }
    }
}
