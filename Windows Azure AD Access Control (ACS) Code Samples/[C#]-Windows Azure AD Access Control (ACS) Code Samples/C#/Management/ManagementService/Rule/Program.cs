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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Common.ACS.Management;

    class Program
    {
        static void Main(string[] args)
        {
            const string ruleGroupName = "Simple Rule Group";
            const string newGroupName = "Copy of Simple Rule Group";
 
            DeleteRuleGroupByNameIfExists(ruleGroupName);
            DeleteRuleGroupByNameIfExists(newGroupName);

            // create a rule group for us to start with.
            AddRuleGroup(ruleGroupName);

            // add rules
            AddRulesToRuleGroup(ruleGroupName);
            DisplayAllRulesInGroup(ruleGroupName);

            // delete all rules in the given group. 
            DeleteAllRulesInGroup(ruleGroupName);
            DisplayAllRulesInGroup(ruleGroupName);
            DeleteRuleGroupByNameIfExists(ruleGroupName);

            Console.WriteLine("Press ENTER to continue....");
            Console.ReadLine();

            const string fedMetadataFile = "FederationMetadata.xml";
            // Identity provider name is the entityID value in the metadata file
            const string identityProviderName = "http://example.org/adfs/services/trust";
            const string relyingPartyName = "simple relying party";

            // delete relying party and identity provider if they exist
            DeleteIdentityProviderIfExists(identityProviderName);
            DeleteRelyingPartyIfExist(relyingPartyName);

            // create an identity provider
            ImportIdentityProviderFromMetadata(fedMetadataFile);

            // create a relying party
            AddRelyingParty(relyingPartyName);

            // create a new rule group
            AddRuleGroup(ruleGroupName);

            // Generate rules for the relying party
            GenerateRules(ruleGroupName, relyingPartyName);
            DisplayAllRulesInGroup(ruleGroupName);


            CopyRuleGroup(ruleGroupName, newGroupName);
            DisplayAllRulesInGroup(newGroupName);

            DeleteRuleGroupByNameIfExists(ruleGroupName);
            DeleteRuleGroupByNameIfExists(newGroupName);

            DeleteIdentityProviderIfExists(identityProviderName);
            DeleteRelyingPartyIfExist(relyingPartyName);

            Console.WriteLine("Done. Press ENTER to continue....");
            Console.ReadLine();
        }

        /// <summary>
        /// Delete a rule group by its name.
        /// </summary>
        private static void DeleteRuleGroupByNameIfExists(string name)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Where(g => g.Name == name).FirstOrDefault();

            if (rg != null)
            {
                svc.DeleteObject(rg);
                svc.SaveChangesBatch();
            }
        }

        /// <summary>
        /// Add a rule group.
        /// </summary>
        private static void AddRuleGroup(string name)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = new RuleGroup()
            {
                Name = name
            };

            svc.AddToRuleGroups(rg);
            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Display all rules given a rule group name.
        /// </summary>
        private static void DisplayAllRulesInGroup(string ruleGroupName)
        {
            Console.WriteLine("\nRetrieve rules in rule group (Name = {0})\n", ruleGroupName);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Expand("Rules").Where(g => g.Name == ruleGroupName).FirstOrDefault();

            if (rg != null)
            {
                Console.WriteLine("\tId = {0}\n", rg.Id);
                Console.WriteLine("\tName = {0}\n", rg.Name);

                foreach (Rule rule in rg.Rules)
                {
                    Console.WriteLine("\tRule (Id = {0})\n", rule.Id);
                    Console.WriteLine("\t\tId = {0}\n", rule.Id);
                    Console.WriteLine("\t\tInputClaimIssuerId = {0}\n", rule.IssuerId);
                    Console.WriteLine("\t\tInputClaimType = {0}\n", rule.InputClaimType);
                    Console.WriteLine("\t\tInputClaimValue = {0}\n", rule.InputClaimValue);
                    Console.WriteLine("\t\tOutputClaimType = {0}\n", rule.OutputClaimType);
                    Console.WriteLine("\t\tOutputClaimValue = {0}\n", rule.OutputClaimValue);
                    Console.WriteLine("\t\tDescription = {0}\n", rule.Description);
                }
            }

        }

        /// <summary>
        /// Delete all rules within a rule group.
        /// </summary>
        private static void DeleteAllRulesInGroup(string ruleGroupName)
        {
            Console.WriteLine("\nDelete rules in rule group (Name = {0})\n", ruleGroupName);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Expand("Rules").Where(g => g.Name == ruleGroupName).FirstOrDefault();

            if (rg != null)
            {
                foreach (Rule r in rg.Rules)
                {
                    svc.DeleteObject(r);
                }
                svc.SaveChangesBatch();
            }
        }

        /// <summary>
        /// Add rules to a rule group.
        /// </summary>
        private static void AddRulesToRuleGroup(string ruleGroupName)
        {
            Console.WriteLine("\nAdding rules in rule group (Name = {0})\n", ruleGroupName);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Where(g => g.Name == ruleGroupName).FirstOrDefault();

            // "LOCAL AUTHORITY" is a built-in issuer name, representing the service namespace itself. 
            Issuer localAuthority = svc.GetIssuerByName("LOCAL AUTHORITY");

            Rule basicRule = new Rule()
            {
                InputClaimType = "https://acs/your-input-type",
                InputClaimValue = "inputValue",
                OutputClaimType = "https://acs/your-output-type",
                OutputClaimValue = "outputValue",
            };

            basicRule.Description = string.Format(CultureInfo.InvariantCulture,
                "Transforms claim from {0} with type: {1}, value: {2}, into a new claim with type: {3}, value:{4}",
                "ACS",
                basicRule.InputClaimType,
                basicRule.InputClaimValue,
                basicRule.OutputClaimType,
                basicRule.OutputClaimValue);

            svc.AddToRules(basicRule);
            svc.SetLink(basicRule, "RuleGroup", rg);
            svc.SetLink(basicRule, "Issuer", localAuthority);

            Rule passthroughSpecificClaimRule = new Rule()
            {
                InputClaimType = "https://acs/your-input-type2",
                InputClaimValue = "inputValue2",
            };

            passthroughSpecificClaimRule.Description = string.Format(CultureInfo.InvariantCulture,
                "Passthrough claim from {0} with type: {1}, value: {2}",
                "ACS",
                passthroughSpecificClaimRule.InputClaimType,
                passthroughSpecificClaimRule.InputClaimValue);

            svc.AddToRules(passthroughSpecificClaimRule);
            svc.SetLink(passthroughSpecificClaimRule, "RuleGroup", rg);
            svc.SetLink(passthroughSpecificClaimRule, "Issuer", localAuthority);

            Rule passthroughAnyClaimWithSpecificTypeRule = new Rule()
            {
                InputClaimType = "https://acs/your-input-type3",
            };

            passthroughAnyClaimWithSpecificTypeRule.Description = string.Format(CultureInfo.InvariantCulture,
                "Passthrough claim from {0} with type: {1}, and any value",
                "ACS",
                passthroughSpecificClaimRule.InputClaimType);

            svc.AddToRules(passthroughAnyClaimWithSpecificTypeRule);
            svc.SetLink(passthroughAnyClaimWithSpecificTypeRule, "RuleGroup", rg);
            svc.SetLink(passthroughAnyClaimWithSpecificTypeRule, "Issuer", localAuthority);

            Rule complexTransformationRule = new Rule()
            {
                InputClaimType = "https://acs/your-input-type4",
                OutputClaimType = "https://acs/your-output-type2",
            };

            complexTransformationRule.Description = string.Format(CultureInfo.InvariantCulture,
                "Transforms claim from {0} with type: {1}, and any value, into a new claim with type: {2}, keeping(passingthrough) old value",
                "ACS",
                complexTransformationRule.InputClaimType,
                complexTransformationRule.OutputClaimType);

            svc.AddToRules(complexTransformationRule);
            svc.SetLink(complexTransformationRule, "RuleGroup", rg);
            svc.SetLink(complexTransformationRule, "Issuer", localAuthority);

            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Imports the identity provider from a federation metadata file
        /// </summary>
        private static void ImportIdentityProviderFromMetadata(string fedMetadataFile)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            using (Stream fedMetadataFileStream = new FileStream(fedMetadataFile, FileMode.Open, FileAccess.Read))
            {
                svc.ImportIdentityProviderFromStream(fedMetadataFileStream);
            }
        }

        /// <summary>
        /// Adds a relying party
        /// </summary>
        private static void AddRelyingParty(string relyingPartyName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RelyingParty relyingParty = svc.CreateRelyingParty(relyingPartyName, 
                "http://localhost", 
                "http://localhost", 
                RelyingPartyTokenType.SAML_2_0, 
                false);

            // Associate this new relying party with all identity providers
            svc.AssociateIdentityProvidersWithRelyingParties(svc.IdentityProviders,
                new []{relyingParty});

            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Generates the rules for the relying party
        /// </summary>
        private static void GenerateRules(string ruleGroupName, string relyingPartyName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            // Get the identity providers for the relying party
            RelyingParty relyingParty = svc.GetRelyingPartyByName(relyingPartyName);
            IEnumerable<IdentityProvider> rpIdentityProviders = svc.GetRelyingPartyIdentityProviders(relyingParty);

            // Generate rules for the rule group
            RuleGroup ruleGroup = svc.RuleGroups.Where(rg => rg.Name == ruleGroupName).FirstOrDefault();
            svc.GenerateRules(ruleGroup, rpIdentityProviders);

            // Assign the rule group to relying party
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Deletes the relying party if it exists
        /// </summary>
        private static void DeleteRelyingPartyIfExist(string relyingPartyName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.DeleteRelyingPartyByNameIfExists(relyingPartyName);

            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Deletes the identity provider if it exists
        /// </summary>
        private static void DeleteIdentityProviderIfExists(string identityProviderName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.DeleteIdentityProviderIfExists(identityProviderName);

            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Copies the source rule group into a new rule group
        /// </summary>
        private static void CopyRuleGroup(string source, string newRuleGroupName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Where(g => g.Name == source).FirstOrDefault();

            svc.CopyRuleGroup(rg, newRuleGroupName);

            svc.SaveChangesBatch();
        }
    }
}