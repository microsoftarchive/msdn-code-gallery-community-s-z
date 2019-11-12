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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.ServiceBus.ServicebusHttpClient
{
    class HttpClientHelper
    {
        const string ApiVersion = "&api-version=2012-03"; // API version 2013-03 works with Azure Service Bus and all versions of Service Bus for Windows Server.

        HttpClient httpClient;
        string token;

        // Create HttpClient object, get ACS token, attach token to HttpClient Authorization header.
        public HttpClientHelper(string serviceNamespace, bool useSas, string keyName, string key)
        {
            this.httpClient = new HttpClient();
            if (useSas)
            {
                this.token = GetSasToken(serviceNamespace, keyName, key);
            }
            else
            {
                this.token = GetAcsToken(serviceNamespace, keyName, key).Result;
            }
            httpClient.DefaultRequestHeaders.Add("Authorization", this.token);
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/atom+xml;type=entry;charset=utf-8");
        }

        // Create a SAS token. SAS tokens are described in http://msdn.microsoft.com/en-us/library/windowsazure/dn170477.aspx.
        public string GetSasToken(string uri, string keyName, string key)
        {
            // Set token lifetime to 20 minutes.
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = DateTime.Now.ToUniversalTime() - origin;
            uint tokenExpirationTime = Convert.ToUInt32(diff.TotalSeconds) + 20 * 60;

            string stringToSign = HttpUtility.UrlEncode(uri) + "\n" + tokenExpirationTime;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));

            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            string token = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                HttpUtility.UrlEncode(uri), HttpUtility.UrlEncode(signature), tokenExpirationTime, keyName);
            Console.WriteLine("Token: " + token);
            return token;
        }

        // Call ACS to get a token.
        async Task<string> GetAcsToken(string serviceNamespace, string issuerName, string issuerSecret)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("wrap_name", issuerName));
            postData.Add(new KeyValuePair<string, string>("wrap_password", issuerSecret));
            postData.Add(new KeyValuePair<string, string>("wrap_scope", "http://" + serviceNamespace + ".servicebus.windows.net/"));
            HttpContent postContent = new FormUrlEncodedContent(postData);
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.PostAsync("https://" + serviceNamespace + "-sb.accesscontrol.windows.net/WRAPv0.9/", postContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("GetAcsToken failed: " + ex.Message);
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            var responseProperties = responseBody.Split('&');
            var tokenProperty = responseProperties[0].Split('=');
            var token = Uri.UnescapeDataString(tokenProperty[1]);

            Console.WriteLine("Token: " + token);
            return "WRAP access_token=\"" + token + "\"";
        }

        // Get properties of an entity.
        public async Task<byte[]> GetEntity(string address)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.GetAsync(address + "?timeout=60" + ApiVersion);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("GetEntity failed: " + ex.Message);
            }
            byte[] entityDescription = await response.Content.ReadAsByteArrayAsync();
            return entityDescription;
        }

        // Create an entity.
        public async Task CreateEntity(string address, byte[] entityDescription)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PutAsync(address + "?timeout=60" + ApiVersion, new ByteArrayContent(entityDescription));
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                if (response != null)
                {
                    Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    if ((int)response.StatusCode == 409)
                    {
                        Console.WriteLine("Entity " + address + " already exists.");
                        return;
                    }
                }
                Console.WriteLine("CreateEntity failed: " + ex.Message);
            }
        }

        // Delete an entity.
        public async Task DeleteEntity(string address)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.DeleteAsync(address + "?timeout=60" + ApiVersion);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("DeleteEntity failed: " + ex.Message);
            }
        }

        // Send a message.
        public async Task SendMessage(string address, ServiceBusHttpMessage message)
        {
            HttpContent postContent = new ByteArrayContent(message.body);

            // Serialize BrokerProperties.
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, message.brokerProperties);
            postContent.Headers.Add("BrokerProperties", Encoding.UTF8.GetString(ms.ToArray()));
            ms.Close();

           // Add custom properties.
           foreach (string key in message.customProperties)
           {
               postContent.Headers.Add(key, message.customProperties.GetValues(key));
           }

            // Send message.
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PostAsync(address + "/messages" + "?timeout=60", postContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("SendMessage failed: " + ex.Message);
            }
        }

        // Send a batch of messages.
        public async Task SendMessageBatch(string address, ServiceBusHttpMessage message)
        {
            // Custom properties that are defined for the brokered message that contains the batch are ignored.
            // Throw exception to signal that these properties are ignored.
            if (message.customProperties.Count != 0)
            {
                throw new ArgumentException("Custom properties in BrokeredMessage are ignored.");
            }

            HttpContent postContent = new ByteArrayContent(message.body);
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.microsoft.servicebus.json");
            
            // Send message.
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PostAsync(address + "/messages" + "?timeout=60", postContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("SendMessageBatch failed: " + ex.Message);
            }
        }

        // Peek and lock message. The parameter messageUri contains the URI of the message, which can be used to complete the message.
        public async Task<ServiceBusHttpMessage> ReceiveMessage(string address)
        {
            return await Receive(address, false);
        }

        // Receive and delete message.
        public async Task<ServiceBusHttpMessage> ReceiveAndDeleteMessage(string address)
        {
            return await Receive(address, true);
        }

        public async Task<ServiceBusHttpMessage> Receive(string address, bool deleteMessage)
        {
            // Retrieve message from Service Bus.
            HttpResponseMessage response = null;
            try
            {
                if (deleteMessage)
                {
                    response = await this.httpClient.DeleteAsync(address + "/messages/head?timeout=60");
                }
                else
                {
                    response = await this.httpClient.PostAsync(address + "/messages/head?timeout=60", new ByteArrayContent(new Byte[0]));
                }
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                if (deleteMessage)
                {
                    Console.WriteLine("ReceiveAndDeleteMessage failed: " + ex.Message);
                }
                else
                {
                    Console.WriteLine("ReceiveMessage failed: " + ex.Message);
                }
            }

            // Check if a message was returned.
            HttpResponseHeaders headers = response.Headers;
            if (!headers.Contains("BrokerProperties"))
            {
                return null;
            }

            // Get message body.
            ServiceBusHttpMessage message = new ServiceBusHttpMessage();
            message.body = await response.Content.ReadAsByteArrayAsync();

            // Deserialize BrokerProperties.
            IEnumerable<string> brokerProperties = headers.GetValues("BrokerProperties");
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            foreach (string key in brokerProperties )
            {
                using (MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(key)))
                {
                    message.brokerProperties = (BrokerProperties)serializer.ReadObject(ms);
                }
            }

            // Get custom propoerties.
            foreach (var header in headers)
            {
                string key = header.Key;
                if (!key.Equals("Transfer-Encoding") && !key.Equals("BrokerProperties") && !key.Equals("ContentType") && !key.Equals("Location") && !key.Equals("Date") && !key.Equals("Server"))
                {
                    foreach (string value in header.Value)
                    {
                        message.customProperties.Add(key, value);
                    }
                }
            }

            // Get message URI.
            if (headers.Contains("Location"))
            {
                IEnumerable<string> locationProperties = headers.GetValues("Location");
                message.location = locationProperties.FirstOrDefault();
            }
            return message;
        }

        // Delete message with the specified MessageId and LockToken.
        public async Task DeleteMessage(string address, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            await DeleteMessage(messageUri);
        }

        // Delete message with the specified SequenceNumber and LockToken
        public async Task DeleteMessage(string address, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            await DeleteMessage(messageUri);
        }

        // Delete message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public async Task DeleteMessage(string messageUri)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.DeleteAsync(messageUri + "?timeout=60");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("DeleteMessage failed: " + ex.Message);
            }
        }

        // Unlock message with the specified MessageId and LockToken.
        public async Task UnlockMessage(string address, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            await UnlockMessage(messageUri);
        }

        // Unlock message with the specified SequenceNumber and LockToken
        public async Task UnlockMessage(string address, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            await UnlockMessage(messageUri);
        }

        // Unlock message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public async Task UnlockMessage(string messageUri)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PutAsync(messageUri + "?timeout=60", null);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("UnlockMessage failed: " + ex.Message);
            }
        }

        // Renew lock of the message with the specified MessageId and LockToken.
        public async Task RenewLock(string address, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            await RenewLock(messageUri);
        }

        // Renew lock of the message with the specified SequenceNumber and LockToken
        public async Task RenewLock(string address, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            await RenewLock(messageUri);
        }

        // Renew lock of the message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public async Task RenewLock(string messageUri)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PostAsync(messageUri + "?timeout=60", null);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("RenewLock failed: " + ex.Message);
            }
        }
    }
}
