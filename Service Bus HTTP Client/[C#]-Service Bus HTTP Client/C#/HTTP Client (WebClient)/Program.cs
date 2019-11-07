//---------------------------------------------------------------------------------
// Copyright (c) 2014, Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.ServiceBus.Messaging;

namespace Microsoft.ServiceBus.ServicebusHttpClient
{
    public class Program
    {
        // Addressing and credential info of your Azure Service Bus. Get your namespace key from the Azure portal.
        // Define SAS credentials when using SAS keys (recommended). Define ACS credentials when using ACS.
        // BE AWARE THAT HARDCODING YOUR NAMESPACE KEY IS A SECURITY RISK IF YOU SHARE THIS CODE.
        const string ServiceBusNamespace = "YOUR-NAMESPACE";
        const string SasKeyName = "RootManageSharedAccessKey";
        const string SasKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX=";
        const string AcsIdentity = "owner";
        const string AcsKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX=";
        
        public const string TopicName = "HttpClientSampleTopic";
        public const string SubscriptionName = "Sub1";

        static void Main(string[] args)
        {
			string baseAddressHttp = "https://" + ServiceBusNamespace + ".servicebus.windows.net/";
            string topicAddress = baseAddressHttp + TopicName;
            string subscriptionAddress = topicAddress + "/Subscriptions/" + SubscriptionName;

            // Create SAS token or get token from ACS.
            string token = HttpHelper.GetSasToken(ServiceBusNamespace, SasKeyName, SasKey);
            //string token = HttpHelper.GetAcsToken(ServiceBusNamespace, AcsIdentity, AcsKey);
 

            /*** Create topic and subscription. ***/

            // Create topic of size 2GB. Specify a default TTL of 2 minutes. Time durations
            // are formatted according to ISO 8610 (see http://en.wikipedia.org/wiki/ISO_8601#Durations).
            // IMPORTANT: TopicDescription properties must be specified in a specific order. Please see sample description for details.
            Console.WriteLine("Creating topic ...");
            byte[] topicDescription = Encoding.UTF8.GetBytes("<entry xmlns='http://www.w3.org/2005/Atom'><content type='application/xml'>"
                + "<TopicDescription xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/netservices/2010/10/servicebus/connect\">"
                + "<DefaultMessageTimeToLive>PT2M</DefaultMessageTimeToLive>"
                + "<MaxSizeInMegabytes>2048</MaxSizeInMegabytes>"
                + "</TopicDescription></content></entry>");
            HttpHelper.CreateEntity(topicAddress, token, topicDescription);

            // Query topic.
            Console.WriteLine("Query Topic ...");
            byte[] queryTopicResponse = HttpHelper.GetEntity(topicAddress, token);
            Console.WriteLine("Topic:\n" + Encoding.UTF8.GetString(queryTopicResponse));

            // Create subscription with default settings.
            Console.WriteLine("Creating subscription ...");
            byte[] subscriptionDescription = Encoding.UTF8.GetBytes("<entry xmlns='http://www.w3.org/2005/Atom'><content type='application/xml'>"
                + "<SubscriptionDescription xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/netservices/2010/10/servicebus/connect\">"
                + "</SubscriptionDescription></content></entry>");
            HttpHelper.CreateEntity(subscriptionAddress, token, subscriptionDescription);

            // Query subscription.
            Console.WriteLine("Query Subscription ...");
            byte[] querySubscriptionResponse = HttpHelper.GetEntity(subscriptionAddress, token);
            Console.WriteLine("Subscription:\n" + Encoding.UTF8.GetString(querySubscriptionResponse));


            /*** Send and receive+delete first message. ***/

            // Send message M1 to the topic.
            Console.WriteLine("Sending message 1 ...");
            ServiceBusHttpMessage sendMessage1 = new ServiceBusHttpMessage();
            sendMessage1.body = Encoding.UTF8.GetBytes("This is the first message."); // Convert string into byte array.
            sendMessage1.brokerProperties.Label = "M1";
            sendMessage1.brokerProperties.TimeToLive = 10.0;
            sendMessage1.customProperties.Add("Priority", "High");
            sendMessage1.customProperties.Add("Customer", "12345");
            sendMessage1.customProperties.Add("Customer", "ABC");
            HttpHelper.SendMessage(topicAddress, token, sendMessage1);

            // Receive + delete message M1 from the subscription.
            Console.WriteLine("Receiving message 1 ...");
            ServiceBusHttpMessage receiveMessage1 = HttpHelper.ReceiveAndDeleteMessage(subscriptionAddress, token);
            ProcessMessage(receiveMessage1);


            /*** Send scheduled message. Receive the scheduled message, then abandon the message, receive it again, extend the lock, and then delete it. ***/

            // Send a scheduled message M2.
            ServiceBusHttpMessage sendMessage2 = new ServiceBusHttpMessage();
            sendMessage2.body = Encoding.UTF8.GetBytes("This is the second message.");
            sendMessage2.brokerProperties.Label = "M2";
            DateTime scheduledTime = DateTime.Now + TimeSpan.FromSeconds(10);
            DateTime scheduledTimeUtc = scheduledTime.ToUniversalTime();
            sendMessage2.brokerProperties.ScheduledEnqueueTimeUtc = scheduledTimeUtc.ToString("R");
            Console.WriteLine("Sending message 2 to be scheduled at {0} ...", sendMessage2.brokerProperties.ScheduledEnqueueTimeUtc);
            HttpHelper.SendMessage(topicAddress, token, sendMessage2);

            // Receive message M2.
            string messageUri2 = null;
            Console.WriteLine("Receiving message 2 ...");
            ServiceBusHttpMessage receiveMessage2 = HttpHelper.ReceiveMessage(subscriptionAddress, token, ref messageUri2);
            ProcessMessage(receiveMessage2);

            // Abandon message M2. Use any of the three UnlockMessage methods.
            Console.WriteLine("Unlocking message {0} ...", receiveMessage2.brokerProperties.MessageId);
            HttpHelper.UnlockMessage(messageUri2, token);
            //HttpHelper.UnlockMessage(subscriptionAddress, token, receiveMessage2.brokerProperties.MessageId, (Guid)receiveMessage2.brokerProperties.LockToken);
            //HttpHelper.UnlockMessage(subscriptionAddress, token, (long)receiveMessage2.brokerProperties.SequenceNumber, (Guid)receiveMessage2.brokerProperties.LockToken);
            
            // Receive message M2 again.
            Console.WriteLine("Receiving message 2 again ...");
            receiveMessage2 = HttpHelper.ReceiveMessage(subscriptionAddress, token, ref messageUri2);
            ProcessMessage(receiveMessage2);
            
            // Extend message lock. Use any of the three RenewLock methods.
            Console.WriteLine("Renew lock of message {0} ...", receiveMessage2.brokerProperties.MessageId);
            //HttpHelper.RenewLock(messageUri2, token);
            HttpHelper.RenewLock(subscriptionAddress, token, receiveMessage2.brokerProperties.MessageId, (Guid)receiveMessage2.brokerProperties.LockToken);
            //HttpHelper.RenewLock(subscriptionAddress, token, (long)receiveMessage2.brokerProperties.SequenceNumber, (Guid)receiveMessage2.brokerProperties.LockToken);
            
            // Delete message M2. Use any of the three DeleteMessage methods.
            Console.WriteLine("Deleting message {0} ...", receiveMessage2.brokerProperties.MessageId);
            //HttpHelper.DeleteMessage(messageUri2, token);
            //HttpHelper.DeleteMessage(subscriptionAddress, token, receiveMessage2.brokerProperties.MessageId, (Guid)receiveMessage2.brokerProperties.LockToken);
            HttpHelper.DeleteMessage(subscriptionAddress, token, (long)receiveMessage2.brokerProperties.SequenceNumber, (Guid)receiveMessage2.brokerProperties.LockToken);


            /*** Send a batch of three messages. Then receive the 3 messages. ***/

            // Send a batch of three messages M3, M4 and M5. Broker and custom properties have to be part of the
            // JSON-encoded body of the BrokeredMessage. Broker and custom properties of the Brokeredmessage are ignored.
            Console.WriteLine("Sending batch of three messages 3, 4, and 5 ...");
            string msg1 = "{\"Body\":\"This is the third message.\",\"BrokerProperties\":{\"Label\":\"M3\",\"TimeToLiveTimeSpan\":\"0.00:00:40\"}}";
            string msg2 = "{\"Body\":\"This is the fourth message.\",\"BrokerProperties\":{\"Label\":\"M4\"},\"UserProperties\":{\"Priority\":\"Low\"}}";
            string msg3 = "{\"Body\":\"This is the fifth message.\",\"BrokerProperties\":{\"Label\":\"M5\"},\"UserProperties\":{\"Priority\":\"Medium\",\"Customer\":\"ABC\"}}";
            ServiceBusHttpMessage sendMessage3 = new ServiceBusHttpMessage();
            sendMessage3.body = Encoding.UTF8.GetBytes("[" + msg1 + "," + msg2 + "," + msg3 + "]");
            HttpHelper.SendMessageBatch(topicAddress, token, sendMessage3);

            // Receive and delete messages M3, M4 and M5.
            for (int i = 3; i <= 5; i++)
            {
                Console.WriteLine("Receiving message {0} ...", i);
                ServiceBusHttpMessage receiveMessage = HttpHelper.ReceiveAndDeleteMessage(subscriptionAddress, token);
                ProcessMessage(receiveMessage);
            }


            /*** Send message via SMBP and receive it via HTTP. ***/

            // Send message M6 via SMBP so that it can be received via HTTP.
            Uri namespaceUri = ServiceBusEnvironment.CreateServiceUri("sb", ServiceBusNamespace, string.Empty);
            TokenProvider sasTokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(SasKeyName, SasKey);
            MessagingFactory mf = MessagingFactory.Create(namespaceUri, sasTokenProvider);
            TopicClient topicClient = mf.CreateTopicClient(TopicName);
            Console.WriteLine("Sending message 6 via SBMP ...");
            DataContractSerializer serializer6 = new DataContractSerializer(typeof(string));
            MemoryStream ms6 = new MemoryStream();
            serializer6.WriteObject(ms6, "This is the sixth message."); // Serialize string.
            ms6.Flush();
            ms6.Seek(0, SeekOrigin.Begin);
            BrokeredMessage sendMessage6 = new BrokeredMessage(ms6, false); // The second parameter is required to ensure that the first parameter is correctly interpreted as a stream. It can be omitted when using later versions of the Service Bus client library.
            sendMessage6.Label = "M6";
            sendMessage6.TimeToLive = new TimeSpan(0, 0, 15);
            sendMessage6.Properties.Add("Priority", "Urgent");
            sendMessage6.Properties.Add("Customer", "678");
            topicClient.Send(sendMessage6);
            ms6.Close();

            // Use HTTP to receive message M6 that was sent via SBMP.
            Console.WriteLine("Receiving message 6 via HTTP ...");
            ServiceBusHttpMessage receiveMessage6 = HttpHelper.ReceiveAndDeleteMessage(subscriptionAddress, token);
            ProcessMessage(receiveMessage6, true);


            /*** Send message via HTTP and receive it via SBMP. ***/

            // Send message M7 via HTTP so that it can be received via SBMP.
            Console.WriteLine("Sending message 7 via HTTP...");
            ServiceBusHttpMessage sendMessage7 = new ServiceBusHttpMessage();
            MemoryStream ms7 = new MemoryStream();
            DataContractSerializer serializer7 = new DataContractSerializer(typeof(string));
            serializer7.WriteObject(ms7, "This is the seventh message."); // Serialize string.
            sendMessage7.body = ms7.ToArray();
            sendMessage7.brokerProperties.Label = "M7";
            sendMessage7.brokerProperties.TimeToLive = 25.0;
            sendMessage7.customProperties.Add("Priority", "Important");
            sendMessage7.customProperties.Add("Customer", "900");
            sendMessage7.customProperties.Add("Customer", "XYZ");
            HttpHelper.SendMessage(topicAddress, token, sendMessage7);
            ms7.Close();

            // Use SBMP to receive message M7 that was sent via HTTP.
            Console.WriteLine("Receiving message 7 via SBMP ...");
            SubscriptionClient subscriptionClient = mf.CreateSubscriptionClient(TopicName, SubscriptionName);
            BrokeredMessage receiveMessage7 = subscriptionClient.Receive();
            ProcessBrokeredMessage(receiveMessage7);


            /*** Clean-up. ***/

            // Wait for the user to exit this application.
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();

            // Delete topic.
            Console.WriteLine("Deleting topic ...");
            HttpHelper.DeleteEntity(topicAddress, token);
        }

        static void ProcessMessage(ServiceBusHttpMessage message, bool IsBodySerialized = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (message == null)
            {
                Console.WriteLine("(No message)");
            }
            else
            {
                if (IsBodySerialized)
                {
                    DataContractSerializer deserializer = new DataContractSerializer(typeof(string));
                    using (MemoryStream ms = new MemoryStream(message.body))
                    {
                        string body = (string)deserializer.ReadObject(ms); // Deserialize byte stream into string.
                        Console.WriteLine("Body           : " + body);
                    }
                }
                else
                {
                    Console.WriteLine("Body           : " + Encoding.UTF8.GetString(message.body)); // Convert byte array into string.
                }
                Console.WriteLine("Message ID     : " + message.brokerProperties.MessageId);
                Console.WriteLine("Label          : " + message.brokerProperties.Label);
                Console.WriteLine("SeqNum         : " + message.brokerProperties.SequenceNumber);
                Console.WriteLine("TTL            : " + message.brokerProperties.TimeToLive + " seconds");
                Console.WriteLine("Locked until   : " + ((message.brokerProperties.LockedUntilUtcDateTime == null) ? "unlocked" : (message.brokerProperties.LockedUntilUtcDateTime + " UTC")));
                foreach (string key in message.customProperties.AllKeys)
                {
                    Console.WriteLine("Custom property: " + key + " = " + message.customProperties[key]);
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void ProcessBrokeredMessage(BrokeredMessage message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (message == null)
            {
                Console.WriteLine("(No message)");
            }
            else
            {
                Console.WriteLine("Body           : " + message.GetBody<string>(new DataContractSerializer(typeof(string))));
                Console.WriteLine("Message ID     : " + message.MessageId);
                Console.WriteLine("Label          : " + message.Label);
                Console.WriteLine("SeqNum         : " + message.SequenceNumber);
                Console.WriteLine("TTL            : " + message.TimeToLive + " seconds");
                Console.WriteLine("Locked until   : " + ((message.LockedUntilUtc == null) ? "unlocked" : (message.LockedUntilUtc + " UTC")));
                foreach (KeyValuePair<string, object> p in message.Properties) 
                {
                    Console.WriteLine("Custom property: " + p.Key.ToString() + " = " + p.Value.ToString()); 
                }    
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
