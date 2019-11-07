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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SASAuthTokenProvider
    {
        public static void SendMessageToQ(string serviceNamespace, string qPath, string keyName, string key)
        {
            Uri runtimeUri = ServiceBusEnvironment.CreateServiceUri("sb", serviceNamespace, string.Empty);
            MessagingFactory mf = MessagingFactory.Create(runtimeUri, 
                TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key));
            QueueClient sendClient = mf.CreateQueueClient(qPath);

            //Sending message to queue.
            Console.WriteLine("Sending Hello message to queue.");
            BrokeredMessage sentMessage = CreateHelloMessage();
            sendClient.Send(sentMessage);
        }

        public static void ReceiveMessageFromQ(string serviceNamespace, string qPath, string keyName, string key)
        {
            Uri runtimeUri = ServiceBusEnvironment.CreateServiceUri("sb", serviceNamespace, string.Empty);
            MessagingFactory mf = MessagingFactory.Create(runtimeUri,
                    TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, key));
            QueueClient receiveClient = mf.CreateQueueClient(qPath);

            BrokeredMessage receivedMessage = receiveClient.Receive(TimeSpan.FromSeconds(10));
            Console.WriteLine("Received message from queue: ID = {0}, Body = {1}.", receivedMessage.MessageId, receivedMessage.GetBody<string>());
        }

        private static BrokeredMessage CreateHelloMessage()
        {
            BrokeredMessage helloMessage = new BrokeredMessage("Hello, Service Bus!");
            helloMessage.MessageId = "SAS-Sample-Message";
            return helloMessage;
        }

    }
}
