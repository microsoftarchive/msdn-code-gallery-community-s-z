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

namespace Microsoft.ServiceBus.Samples.EventHubHttpClient
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using Microsoft.ServiceBus.Messaging;
    
    public class Program
    {
        public const string EventHubName = "SampleEventHub";
        public const int NumberOfPartitions = 8;

        static void Main(string[] args)
        {
            string serviceBusConnectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            if (string.IsNullOrWhiteSpace(serviceBusConnectionString))
            {
                Console.WriteLine("Please provide ServiceBus Connection string in App.Config.");
            }

            ServiceBusConnectionStringBuilder connectionString = new ServiceBusConnectionStringBuilder(serviceBusConnectionString);

            string ServiceBusNamespace = connectionString.Endpoints.First().Host;
            string namespaceKeyName = connectionString.SharedAccessKeyName;
            string namespaceKey = connectionString.SharedAccessKey;
            string baseAddressHttp = "https://" + ServiceBusNamespace + "/";
            string eventHubAddress = baseAddressHttp + EventHubName;

            // Generate device key. The Key is a Base64-encoded key with a length of 256 bits.
            string devicesSendKeyName = "MyDeviceKeyName";
            string primaryDeviceKey = SharedAccessAuthorizationRule.GenerateRandomKey();  // E.g., "8z9teTzoxORWQNz7yx76MsiajXS9ZgdFs7AxY4DDXuo=".
            string secondaryDeviceKey = SharedAccessAuthorizationRule.GenerateRandomKey(); // E.g., "8z9teTzoxORWQNz7yx76MsiajXS9ZgdFs7AxY4DDXuo=".

            // Create an HttpClientHelper to issue management operations. Use a token that carries namespace-wide Manage rights. You can either use ACS or a SAS key.
            // For ACS: string token = GetAcsToken(ServiceBusNamespace, NamespaceKeyName, NamespaceKey).Result;
            string token = SharedAccessSignatureTokenProvider.GetSharedAccessSignature(namespaceKeyName, namespaceKey, ServiceBusNamespace, TimeSpan.FromMinutes(45));

            HttpClientHelper eventHubHttpClientHelper = new HttpClientHelper(eventHubAddress, token);

            // Create event hub.
            // EventHub creation is demonstrated here just for the ease of running the sample.. 
            // Creation of EventHub is not a light-weight operation. Consider isolation of Management Operations to Runtime operations in your real-world scenarios.
            Console.WriteLine("Creating event hub ...");
            byte[] eventHubDescription = Encoding.UTF8.GetBytes("<entry xmlns='http://www.w3.org/2005/Atom'><content type='application/xml'>"
                + "<EventHubDescription xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/netservices/2010/10/servicebus/connect\">"
                +   "<AuthorizationRules>"
                +     "<AuthorizationRule i:type=\"SharedAccessAuthorizationRule\">"
                +       "<ClaimType>SharedAccessKey</ClaimType>"
                +       "<ClaimValue>None</ClaimValue>"
                +       "<Rights>"
                +         "<AccessRights>Send</AccessRights>"
                +       "</Rights>"
                +       "<KeyName>" + devicesSendKeyName + "</KeyName>"
                +       "<PrimaryKey>" + primaryDeviceKey + "</PrimaryKey>"
                +       "<SecondaryKey>" + secondaryDeviceKey + "</SecondaryKey>"
                +     "</AuthorizationRule>"
                +   "</AuthorizationRules>"
                +   "<MessageRetentionInDays>3</MessageRetentionInDays>"
                +   "<PartitionCount>" + NumberOfPartitions + "</PartitionCount>"
                + "</EventHubDescription></content></entry>");
            int result = eventHubHttpClientHelper.CreateEntity(eventHubDescription).Result;

            if (result < 0)
            {
                Console.WriteLine("\nPress ENTER to exit...\n");
                Console.ReadLine();
            }

            if (result > 0)
            {
                // Event hub exists. Update keys.
                Console.WriteLine("Updating event hub ...");
                eventHubDescription = Encoding.UTF8.GetBytes("<entry xmlns='http://www.w3.org/2005/Atom'><content type='application/xml'>"
                    + "<EventHubDescription xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.microsoft.com/netservices/2010/10/servicebus/connect\">"
                    + "<AuthorizationRules>"
                    + "<AuthorizationRule i:type=\"SharedAccessAuthorizationRule\">"
                    + "<ClaimType>SharedAccessKey</ClaimType>"
                    + "<ClaimValue>None</ClaimValue>"
                    + "<Rights>"
                    + "<AccessRights>Send</AccessRights>"
                    + "</Rights>"
                    + "<KeyName>" + devicesSendKeyName + "</KeyName>"
                    + "<PrimaryKey>" + primaryDeviceKey + "</PrimaryKey>"
                    + "<SecondaryKey>" + secondaryDeviceKey + "</SecondaryKey>"
                    + "</AuthorizationRule>"
                    + "</AuthorizationRules>"
                    + "</EventHubDescription></content></entry>");
                eventHubHttpClientHelper.UpdateEntity(eventHubDescription).Wait();
            }

            // Query event hub.
            Console.WriteLine("Querying event hub ...");
            byte[] queryEventHubResponse = eventHubHttpClientHelper.GetEntity().Result;
            Console.WriteLine("Event Hub:\n" + Encoding.UTF8.GetString(queryEventHubResponse) + "\n");

            // Create one token per device. The token is specific to the device's publisher.
            // Both tokens either use the primary or the secondary device key.
            string token1 = SharedAccessSignatureTokenProvider.GetPublisherSharedAccessSignature(
                connectionString.Endpoints.First(), EventHubName, "dev-01", devicesSendKeyName, primaryDeviceKey, TimeSpan.FromMinutes(2));

            string token2 = SharedAccessSignatureTokenProvider.GetPublisherSharedAccessSignature(
                connectionString.Endpoints.First(), EventHubName, "dev-02", devicesSendKeyName, primaryDeviceKey, TimeSpan.FromMinutes(2));
            
            Console.WriteLine("SAS Token 1: " + token1 + "\n");
            Console.WriteLine("SAS Token 2: " + token2 + "\n");

            // Send the first message to the event hub publisher for device dev-01. Payload is JSON-encoded.
            // Message does not contain custom properties. Use token1, which is valid to send to publishers/dev-01. 
            Console.WriteLine("Device dev-01 is sending telemetry message 1 ...");
            HttpClientHelper deviceHttpClientHelper1 = new HttpClientHelper(eventHubAddress + "/publishers/dev-01", token1);
            string messageBody1 = "{\"Temperature\":\"37.0\",\"Humidity\":\"0.4\"}";
            deviceHttpClientHelper1.SendMessage(messageBody1).Wait();

            // Send the second message to the event hub publisher for device dev-02. Payload is JSON-encoded.
            // Message contain a custom property. Use token2, which is valid to send to publishers/dev-02. 
            Console.WriteLine("Device dev-02 is sending telemetry message 2 ...");
            HttpClientHelper deviceHttpClientHelper2 = new HttpClientHelper(eventHubAddress + "/publishers/dev-02", token2);
            string messageBody2 = "{\"Temperature\":\"38.0\",\"Humidity\":\"0.5\"}";

            NameValueCollection customProperties = new NameValueCollection();
            customProperties.Add("WindAlert", "Strong Winds"); // Header name should not contain whitespace.
            customProperties.Add("GeneralAlert", "Thunderstorms"); // Header name should not contain whitespace.
            deviceHttpClientHelper2.SendMessage(messageBody2, customProperties).Wait();

            // Attempt to send the third message to the event hub publisher for device-01.
            // This request fails because we are using token2, which is only valid to send to publishers/dev-02. 
            Console.WriteLine("Device dev-02 trying to impersonate dev-01 - using its token. This fails ...");
            HttpClientHelper deviceHttpClientHelper1WithWrongToken = new HttpClientHelper(eventHubAddress + "/publishers/dev-01", token2);
            string messageBody3 = "{\"Temperature\":\"39.0\",\"Humidity\":\"0.6\"}";
            deviceHttpClientHelper1WithWrongToken.SendMessage(messageBody3).Wait();

            // Revoke - device-02
            // http://blogs.msdn.com/b/servicebus/archive/2015/02/02/event-hub-publisher-policy-in-action.aspx
            Console.WriteLine("Revoked Access to device-02.");
            var namespaceManager = NamespaceManager.CreateFromConnectionString(serviceBusConnectionString);
            namespaceManager.RevokePublisher(EventHubName, "dev-02");

            Console.WriteLine("The subsequent send, even with the correct token fails...");
            deviceHttpClientHelper2.SendMessage(messageBody2, customProperties).Wait();

            // ReInstate device-02. Observe here - that we are using the same token - which was previously issued to this device. 
            // PublisherId, which is 'dev-02' - is the only key to revoke or restore access to Event Hub.
            Console.WriteLine("Restore device-02 to send messages to EventHub.");
            namespaceManager.RestorePublisher(EventHubName, "dev-02");

            Console.WriteLine("Now the subsequent sends will succeed.");
            deviceHttpClientHelper2.SendMessage(messageBody2, customProperties).Wait();
            Console.WriteLine("dev-02 sent message to Event Hub.");

            // Start a worker that consumes messages from the event hub.
            EventHubClient eventHubReceiveClient = EventHubClient.CreateFromConnectionString(serviceBusConnectionString, EventHubName);
            var consumerGroup = eventHubReceiveClient.GetDefaultConsumerGroup();
            EventHubDescription eventHub = namespaceManager.GetEventHub(EventHubName);

            // Register event processor with each shard to start consuming messages
            foreach (var partitionId in eventHub.PartitionIds)
            {
                consumerGroup.RegisterProcessor<DeviceEventProcessor>(new Lease()
                {
                    PartitionId = partitionId
                }, new DeviceProcessorCheckpointManager());
            }

            // Wait for the user to exit this application.
            Console.WriteLine("\nPress ENTER to exit...\n");
            Console.ReadLine();
        }
    }
}