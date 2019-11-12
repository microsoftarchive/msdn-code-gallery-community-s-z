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

namespace Microsoft.Samples.SubscriptionsWithSAS
{
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        #region Fields

        internal static string nsConnectionString;
        internal const string topicPath = "sampleTopics/contosoT";
        internal const string subscriptionName = "sasSubscription";
        internal static SharedAccessAuthorizationRule contosoTListenRule;

        #endregion

        static void Main(string[] args)
        {
            // The connection string for the RootManageSharedAccessKey can be accessed from the Azure portal 
            // by selecting the SB namespace and clicking on "Connection Information"
            Console.Write("Enter your connection string for the RootManageSharedAccessKey for your Service Bus namespace: ");
            nsConnectionString = Console.ReadLine();

            ///////////////////////////////////////////////////////////////////////////////////////
            // Create a topic with a SAS Listen rule and an associated subscription
            ///////////////////////////////////////////////////////////////////////////////////////
            NamespaceManager nm = NamespaceManager.CreateFromConnectionString(nsConnectionString);
            contosoTListenRule = new SharedAccessAuthorizationRule("contosoTListenKey",
                SharedAccessAuthorizationRule.GenerateRandomKey(),
                new[] { AccessRights.Listen });
            TopicDescription td = new TopicDescription(topicPath);
            td.Authorization.Add(contosoTListenRule);
            nm.CreateTopic(td);
            nm.CreateSubscription(topicPath, subscriptionName);

            ///////////////////////////////////////////////////////////////////////////////////////
            // Send a message to the topic
            // Note that this uses the connection string for RootManageSharedAccessKey 
            // configured on the namespace root
            ///////////////////////////////////////////////////////////////////////////////////////
            MessagingFactory sendMF = MessagingFactory.CreateFromConnectionString(nsConnectionString);
            TopicClient tc = sendMF.CreateTopicClient(topicPath);
            BrokeredMessage sentMessage = CreateHelloMessage();
            tc.Send(sentMessage);
            Console.WriteLine("Sent Hello message to topic: ID={0}, Body={1}.", sentMessage.MessageId, sentMessage.GetBody<string>());

            ///////////////////////////////////////////////////////////////////////////////////////
            // Generate a SAS token scoped to a subscription using the SAS rule with 
            // a Listen right configured on the Topic & TTL of 1 day
            ///////////////////////////////////////////////////////////////////////////////////////
            ServiceBusConnectionStringBuilder csBuilder = new ServiceBusConnectionStringBuilder(nsConnectionString);
            IEnumerable<Uri> endpoints = csBuilder.Endpoints;
            string subscriptionUri = endpoints.First<Uri>().ToString() + topicPath + "/subscriptions/" + subscriptionName;
            string subscriptionToken = SASTokenGenerator.GetSASToken(subscriptionUri,
                contosoTListenRule.KeyName, contosoTListenRule.PrimaryKey, TimeSpan.FromDays(1));

            ///////////////////////////////////////////////////////////////////////////////////////
            // Use the SAS token scoped to a subscription to receive the messages
            ///////////////////////////////////////////////////////////////////////////////////////
            MessagingFactory listenMF = MessagingFactory.Create(endpoints, new StaticSASTokenProvider(subscriptionToken));
            SubscriptionClient sc = listenMF.CreateSubscriptionClient(topicPath, subscriptionName);
            BrokeredMessage receivedMessage = sc.Receive(TimeSpan.FromSeconds(10));
            Console.WriteLine("Received message from subscription: ID = {0}, Body = {1}.", receivedMessage.MessageId, receivedMessage.GetBody<string>());

            ///////////////////////////////////////////////////////////////////////////////////////
            // Clean-up
            ///////////////////////////////////////////////////////////////////////////////////////
            nm.DeleteTopic(topicPath);
        }

        private static BrokeredMessage CreateHelloMessage()
        {
            BrokeredMessage helloMessage = new BrokeredMessage("Hello, Service Bus!");
            helloMessage.MessageId = "SAS-Sample-Message";
            return helloMessage;
        }
    }
}
