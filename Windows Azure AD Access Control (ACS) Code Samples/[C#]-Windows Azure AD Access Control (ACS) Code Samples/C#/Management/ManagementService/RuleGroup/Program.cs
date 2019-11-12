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
    using System.Data.Services.Client;
    using System.Linq;
    using Common.ACS.Management;

    /// <summary>
    /// Manipulate rule groups.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Sample rule group name";

            DeleteRuleGroupByNameIfExists(name);

            AddRuleGroup(name);
            DisplayRuleGroup(name);

            string newName = "*updated* rule group name";
            UpdateRuleGroupName(name, newName);
            DisplayRuleGroup(newName);

            DeleteRuleGroupByNameIfExists(newName);

            Console.WriteLine("Done. Press ENTER to continue....");
            Console.ReadLine(); 
        }



        /// <summary>
        /// Display a rule group given a name.
        /// </summary>
        private static void DisplayRuleGroup(string name)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Where(g => g.Name == name).FirstOrDefault();

            if (rg != null)
            {
                Console.WriteLine("\tId = {0}\n", rg.Id);
                Console.WriteLine("\tName = {0}\n", rg.Name);
            }

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
        /// Update the name of a rule group.
        /// </summary>
        private static void UpdateRuleGroupName(string name, string newName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            RuleGroup rg = svc.RuleGroups.Where(g => g.Name == name).FirstOrDefault();

            if (rg != null)
            {
                rg.Name = newName;
                svc.UpdateObject(rg);
                svc.SaveChangesBatch();
            }
        }
    }
}
