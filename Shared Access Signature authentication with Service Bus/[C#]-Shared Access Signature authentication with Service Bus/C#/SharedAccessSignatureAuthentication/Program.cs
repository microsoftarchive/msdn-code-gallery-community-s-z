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
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        #region Fields

        internal static string subscriptionID;
        internal static string managementCertSN;
        internal static string serviceNamespace;
        internal static SharedAccessAuthorizationRule rootManageRule;
        internal static SharedAccessAuthorizationRule contosoQSendRule;
        internal static SharedAccessAuthorizationRule contosoQListenRule;
        internal static SharedAccessAuthorizationRule contosoQManageRule;
        internal const string qPath = "sampleQueues/contosoQ";

        #endregion

        static void Main(string[] args)
        {
            // This sample demonstrates how to create SAS authorization rules in Service Bus.
            // It also shows how to then use SAS authentication with Service Bus entities.
            Console.Write("Enter your Windows Azure subscription ID: ");
            subscriptionID = Console.ReadLine();

            Console.Write("Enter the SubjectName of the Management certificate for your subscription: ");
            managementCertSN = Console.ReadLine();

            Console.Write("Enter your Service Bus namespace: ");
            serviceNamespace = Console.ReadLine();

            
            //////////////////////////////////////////////////////////////////////////
            // Shared access authorization rule operations on a Namespace.
            // Note: operations on a namespace require certificate authentication.
            //////////////////////////////////////////////////////////////////////////
            // Configure a Shared Access authorization rule on the namespace root.
            Console.WriteLine("Creating authorization rule for SAS with Send rights at namespace root.");
            NamespaceAuthRulesCRUD.CreateSASRuleOnNamespaceRoot(subscriptionID, managementCertSN, serviceNamespace);

            // Get the Shared Access authorization rules from the namespace root
            Console.WriteLine("Reading authorization rules for SAS configured on the namespace root.");
            List<SharedAccessAuthorizationRule> nsSasRules = NamespaceAuthRulesCRUD.ReadSASRulesOnNamespaceRoot(subscriptionID, managementCertSN, serviceNamespace);

            NamespaceAuthRulesCRUD.RollSharedAccessKeyOnNamespaceRoot(subscriptionID, managementCertSN, serviceNamespace, nsSasRules);

            // Delete all Shared Access authorization rules for the namespace,
            // except the "RootManageSharedAccessKey" rule, which cannot be deleted.
            Console.WriteLine("Deleting all non-default authorization rules for SAS from the namespace root.");
            nsSasRules.ForEach(delegate(SharedAccessAuthorizationRule rule)
            {
                if (rule.KeyName == "RootManageSharedAccessKey")
                {
                    rootManageRule = rule;
                }
                else
                {
                    NamespaceAuthRulesCRUD.DeleteSASRuleOnNamespaceRootByKeyName(subscriptionID, managementCertSN, serviceNamespace, rule.KeyName);
                }
            });

            ///////////////////////////////////////////////////////////////////
            // Shared access authorization rule operations on an Entity.
            // Note: all the below operations use SAS authentication.
            ///////////////////////////////////////////////////////////////////
            // Create a queue with Shared Access authorization rules.
            // This operation requires the Manage right on the namespace.
            Console.WriteLine("Creating a queue with authorization rules for SAS with Send/Listen/Manage rights.");
            EntityAuthRulesCRUD.CreateSASRuleOnEntity(serviceNamespace, qPath, rootManageRule.KeyName, rootManageRule.PrimaryKey);

            // Send message to queue, using the rule with Send rights configured on the queue.
            // This method illustrates the use of a SharedAccessSignatureTokenProvider for authentication.
            // An entity-specific rule is used here, but a rule with keys configured on the namespace can also be used.
            SASAuthTokenProvider.SendMessageToQ(serviceNamespace, qPath, contosoQSendRule.KeyName, contosoQSendRule.PrimaryKey);

            // Receive message from queue, using the rule with Listen rights configured on the queue.
            // This method illustrates the use of a SharedAccessSignatureTokenProvider for authentication.
            // An entity-specific rule is used here, but a rule with keys configured on the namespace can also be used.
            SASAuthTokenProvider.ReceiveMessageFromQ(serviceNamespace, qPath, contosoQListenRule.KeyName, contosoQListenRule.PrimaryKey);

            // Send message to queue, using the rule with Send rights configured on the queue.
            // This method illustrates the use of SAS with REST.
            SASAuthREST.SendMessageToQ(serviceNamespace, qPath, contosoQSendRule.KeyName, contosoQSendRule.PrimaryKey);

            // Receive message from queue, using the rule with Listen rights configured on the queue.
            // This method illustrates the use of SAS with REST.
            SASAuthREST.ReceiveMessageFromQ(serviceNamespace, qPath, contosoQListenRule.KeyName, contosoQListenRule.PrimaryKey);

            // Roll the keys for auth rules on the queue.
            EntityAuthRulesCRUD.RollSharedAccessKeysOnEntity(serviceNamespace, qPath, contosoQManageRule.KeyName, contosoQManageRule.PrimaryKey);

            // Updating the Shared Access authorization rules on an entity.
            // This operation requires a Manage right on the entity.
            Console.WriteLine("Updating a queue by removing authorization rules for SAS with Send & Listen rights.");
            EntityAuthRulesCRUD.RemoveSASRulesFromEntity(serviceNamespace, qPath, rootManageRule.KeyName, rootManageRule.PrimaryKey);

            // Deleting a queue with SAS auth rules.
            // This operation requires a Manage right on the entity.
            Console.WriteLine("Deleting the queue using an auth rule with Manage rights configured on the queue itself.");
            EntityAuthRulesCRUD.DeleteQueue(serviceNamespace, qPath, contosoQManageRule.KeyName, contosoQManageRule.PrimaryKey);
        }
    }
}
