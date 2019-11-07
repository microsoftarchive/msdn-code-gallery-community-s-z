//---------------------------------------------------------------------------------
// Microsoft (R)  Windows Azure SDK
// Software Development Kit
// 
// Copyright (c) Microsoft Corporation. All rights reserved.  
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------

namespace Microsoft.Samples.SharedAccessSignatureAuthentication
{
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    class EntityAuthRulesCRUD
    {
        
        // This method will create a queue "sampleQueues/contosoQ" with 2 shared access authorization rules
        // for the Listen & Send rights. It uses SharedAccessSignature auth to create the queue and manage the 
        // authorization rules for the queue.
        public static void CreateSASRuleOnEntity(string serviceNamespace, string qPath, string keyName, string key)
        {
            // Create an instance of NamespaceManager for the operation
            Uri managementUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, string.Empty);
            TokenProvider sasTP = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key);
            NamespaceManager nsm = new NamespaceManager(managementUri, sasTP);
            QueueDescription qd = new QueueDescription(qPath);

            // Setup a rule with send rights with keyName as "contosoQSendKey"
            // and add it to the queue description.
            Program.contosoQSendRule = new SharedAccessAuthorizationRule("contosoQSendKey", 
                SharedAccessAuthorizationRule.GenerateRandomKey(), 
                new[] { AccessRights.Send });
            qd.Authorization.Add(Program.contosoQSendRule);

            // Setup a rule with listen rights with keyName as "contosoQListenKey"
            // and add it to the queue description.
            Program.contosoQListenRule = new SharedAccessAuthorizationRule("contosoQListenKey",
                SharedAccessAuthorizationRule.GenerateRandomKey(),
                new[] { AccessRights.Listen });
            qd.Authorization.Add(Program.contosoQListenRule);

            // Setup a rule with manage rights with keyName as "contosoQManageKey"
            // and add it to the queue description.
            // A rule with the Manage right MUST also have the Send & Receive rights.
            Program.contosoQManageRule = new SharedAccessAuthorizationRule("contosoQManageKey",
                SharedAccessAuthorizationRule.GenerateRandomKey(),
                new[] { AccessRights.Manage, AccessRights.Listen, AccessRights.Send });
            qd.Authorization.Add(Program.contosoQManageRule);

            // Create the queue.
            nsm.CreateQueue(qd);
        }


        // This method rolls the primary key on a auth rule.
        public static void RollSharedAccessKeysOnEntity(string serviceNamespace, string qPath, string keyName, string key)
        {
            // Create an instance of NamespaceManager for the operation.
            Uri managementUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, string.Empty);
            TokenProvider sasTP = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key);
            NamespaceManager nsm = new NamespaceManager(managementUri, sasTP);

            // Get the queue description.
            QueueDescription qd = nsm.GetQueue(qPath);

            IEnumerator<AuthorizationRule> rulesEnumerator = qd.Authorization.GetEnumerator();
            while (rulesEnumerator.MoveNext())
            {
                SharedAccessAuthorizationRule typedRule = rulesEnumerator.Current as SharedAccessAuthorizationRule;
                if (typedRule != null) // Confirm that this is a 'SharedAccessAuthorizationRule'
                {
                    // Roll the keys.
                    // Note that this will also roll the keys on the 'contosoQManageRule' which is being used to 
                    // authenticate this request, but since it won't take effect until we call NamespaceManager.UpdateQueue()
                    // that will still work.
                    typedRule.SecondaryKey = typedRule.PrimaryKey;
                    typedRule.PrimaryKey = SharedAccessAuthorizationRule.GenerateRandomKey();
                }
            }
            // Apply the updated rules
            nsm.UpdateQueue(qd);
        }


        // This method removes the auth rules with KeyName "contosoQSendKey" and "contosoQListenKey" 
        // from the queue.
        public static void RemoveSASRulesFromEntity(string serviceNamespace, string qPath, string keyName, string key)
        {
            // Create an instance of NamespaceManager for the operation.
            Uri managementUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, string.Empty);
            TokenProvider sasTP = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key);
            NamespaceManager nsm = new NamespaceManager(managementUri, sasTP);

            // Get the queue description.
            QueueDescription qd = nsm.GetQueue(qPath);

            List<AuthorizationRule> rulesToRemove = new List<AuthorizationRule>();
            rulesToRemove = qd.Authorization.GetRules(rule =>
                {
                    SharedAccessAuthorizationRule typedRule = rule as SharedAccessAuthorizationRule;
                    if (typedRule != null && 
                        (String.Equals(typedRule.KeyName, "contosoQSendKey", StringComparison.Ordinal) || 
                        String.Equals(typedRule.KeyName, "contosoQListenKey", StringComparison.Ordinal)))
                    {
                        return true;
                    }

                    return false;
                });
            rulesToRemove.ForEach(delegate(AuthorizationRule rule)
            {
                qd.Authorization.Remove(rule);
            });
            nsm.UpdateQueue(qd);
        }

        public static void DeleteQueue(string serviceNamespace, string qPath, string keyName, string key)
        {
            // Create an instance of NamespaceManager for the operation.
            Uri managementUri = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, string.Empty);
            TokenProvider sasTP = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key);
            NamespaceManager nsm = new NamespaceManager(managementUri, sasTP);

            // Delete the queue.
            nsm.DeleteQueue(qPath);
        }

    }
}
