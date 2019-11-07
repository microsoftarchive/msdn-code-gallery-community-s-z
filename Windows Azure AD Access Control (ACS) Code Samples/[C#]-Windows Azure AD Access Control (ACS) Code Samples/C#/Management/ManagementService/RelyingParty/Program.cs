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

namespace ACS.Management
{
    using System;
    using System.Linq;
    using System.Text;
    using Common.ACS.Management;

    class Program
    {
        private static string TestRelyingPartyNameString = "TestRelyingParty";

        static void Main(string[] args)
        {
            DeleteRelyingPartyByNameIfExists(TestRelyingPartyNameString);

            CreateSampleRelyingParty();

            DisplayRelyingParty(TestRelyingPartyNameString);

            UpdateSampleRelyingParty(TestRelyingPartyNameString);

            DisplayRelyingParty(TestRelyingPartyNameString);

            DeleteRelyingPartyByNameIfExists(TestRelyingPartyNameString);

            Console.WriteLine("Done. Press ENTER to continue....\n");
            Console.ReadLine();
        }

        /// <summary>
        /// Helper function which deletes the relying party and commits the change immediately.
        /// </summary>
        /// <param name="name"></param>
        static void DeleteRelyingPartyByNameIfExists(string name)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.DeleteRelyingPartyByNameIfExists(name);
            svc.SaveChangesBatch();
        }

        static void CreateSampleRelyingParty()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = startDate.AddYears(1);

            // Create Relying Party
            RelyingParty relyingParty = svc.CreateRelyingParty(TestRelyingPartyNameString, "http://TestRelyingParty.com/Realm", "http://TestRelyingParty.com/Reply", RelyingPartyTokenType.SAML_2_0, false);

            string pfxFileName = "SampleCert.pfx";
            string pfxPassword = @"pass@word1";

            byte[] signingCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(pfxFileName, pfxPassword);

            svc.CreateRelyingPartyKey(relyingParty, signingCertificate, pfxPassword, RelyingPartyKeyType.X509Certificate, RelyingPartyKeyUsage.Signing, true);

            // Create a rule group and you can follow the 'Rule' sample code to add rules to it as needed. 
            string sampleRuleGroupName = "Sample Rule Group for " + relyingParty.Name;
            RuleGroup ruleGroup = svc.RuleGroups.Where(rg => rg.Name == sampleRuleGroupName).FirstOrDefault();
            if (ruleGroup == null)
            {
                ruleGroup = new RuleGroup()
                {
                    Name = sampleRuleGroupName
                };
                svc.AddToRuleGroups(ruleGroup);
            }

            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            svc.SaveChangesBatch();
        }

        static void DisplayRelyingParty(string relyingPartyName)
        {
            Console.WriteLine("\nRetrieve Relying Party (Name = {0})\n", relyingPartyName);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            // Retrieve Relying Party
            RelyingParty relyingParty = svc.GetRelyingPartyByName(relyingPartyName, true);

            // Display the values of returned Relying Party
            if (relyingParty != null)
            {
                Console.WriteLine("\tId = {0}\n", relyingParty.Id);
                Console.WriteLine("\tName = {0}\n", relyingParty.Name);
                Console.WriteLine("\tDisplayName = {0}\n", relyingParty.DisplayName);
                Console.WriteLine("\tAsymmetricTokenEncryptionRequired = {0}\n", relyingParty.AsymmetricTokenEncryptionRequired);
                Console.WriteLine("\tTokenType = {0}\n", relyingParty.TokenType);
                Console.WriteLine("\tTokenLifetime = {0}\n", relyingParty.TokenLifetime);

                // display keys associated to the Relying Party
                foreach (RelyingPartyKey relyingPartyKey in relyingParty.RelyingPartyKeys.Where(m => m.Type == "X509Certificate"))
                {
                    DisplayRelyingPartyKey(relyingPartyKey);
                }

                // display addresses associated to the Relying Party
                foreach (RelyingPartyAddress relyingPartyAddress in relyingParty.RelyingPartyAddresses.ToList())
                {
                    DisplayRelyingPartyAddress(relyingPartyAddress);
                }

                Console.WriteLine("\tRule Groups:\n");
 
                foreach(RelyingPartyRuleGroup relyingPartyRuleGroup in svc
                    .RelyingPartyRuleGroups.Expand("RuleGroup")
                    .Where(r => r.RelyingPartyId == relyingParty.Id))
                {
                    Console.WriteLine("\t\tName: {0}\n", relyingPartyRuleGroup.RuleGroup.Name);
                }
            }
        }

        static void DisplayRelyingPartyKey(RelyingPartyKey relyingPartyKey)
        {
            // Display the values of returned Relying Party
            if (relyingPartyKey != null)
            {
                Console.WriteLine("\tRelying Party Key (Id = {0})\n", relyingPartyKey.Id);
                Console.WriteLine("\t\tId = {0}\n", relyingPartyKey.Id);
                Console.WriteLine("\t\tDisplayName = {0}\n", relyingPartyKey.DisplayName);
                Console.WriteLine("\t\tPassword = {0}\n", relyingPartyKey.Password == null ? "" : Encoding.UTF8.GetString(relyingPartyKey.Password));
                Console.WriteLine("\t\tType = {0}\n", relyingPartyKey.Type);
                Console.WriteLine("\t\tUsage = {0}\n", relyingPartyKey.Usage);
                Console.WriteLine("\t\tStartDate = {0}\n", relyingPartyKey.StartDate);
                Console.WriteLine("\t\tEndDate = {0}\n", relyingPartyKey.EndDate);
                Console.WriteLine("\t\tValue = {0}\n", Convert.ToBase64String(relyingPartyKey.Value));
            }
        }

        static void DisplayRelyingPartyAddress(RelyingPartyAddress relyingPartyAddress)
        {
            if (relyingPartyAddress != null)
            {
                Console.WriteLine("\tRelying Party Address (Id = {0})\n", relyingPartyAddress.Id);
                Console.WriteLine("\t\tId = {0}\n", relyingPartyAddress.Id);
                Console.WriteLine("\t\tAddress = {0}\n", relyingPartyAddress.Address);
                Console.WriteLine("\t\tEndpointType = {0}\n", relyingPartyAddress.EndpointType);
            }
        }

        static void UpdateSampleRelyingParty(string relyingPartyName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            // Retrieve Relying Party and then delete it
            RelyingParty relyingParty = svc.RelyingParties.Expand("RelyingPartyAddresses").Where(m => m.Name == relyingPartyName).FirstOrDefault();
            if (relyingParty != null)
            {
                // update DisplayName
                relyingParty.DisplayName = "TestRelyingPartyNewDisplayName";
                //update Realm
                RelyingPartyAddress realm = relyingParty.RelyingPartyAddresses.Where(m => m.EndpointType == "Realm").FirstOrDefault();
                if (realm != null)
                {
                    realm.Address = "http://TestRelyingParty/NewRealm";
                    svc.UpdateObject(realm);
                }

                svc.UpdateObject(relyingParty);
                svc.SaveChangesBatch();
            }
        }
    }
}
