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
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Microsoft.ServiceBus.ServicebusHttpClient
{
    class HttpHelper
    {
        const string ApiVersion = "&api-version=2012-03"; // API version 2013-03 works with Azure Service Bus and all versions of Service Bus for Windows Server.

        // Get properties of an entity.
        public static byte[] GetEntity(string address, string token)
        {
            WebClient webClient = CreateWebClient(token);
            return webClient.DownloadData(address + "?timeout=60" + ApiVersion);
        }

        // Create an entity.
        public static void CreateEntity(string address, string token, byte[] entityDescription)
        {
            WebClient webClient = CreateWebClient(token, "application/atom+xml;type=entry;charset=utf-8");
            try
            {
                webClient.UploadData(address + "?timeout=60" + ApiVersion, "PUT", entityDescription);
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                        if ((int)response.StatusCode == 409)
                        {
                            Console.WriteLine("Entity " + address + " already exists.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CreateEntity failed: " + GetErrorFromException(ex));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateEntity failed: " + ex.Message);
            }
        }

        // Delete an entity.
        public static void DeleteEntity(string address, string token)
        {
            WebClient webClient = CreateWebClient(token);
            try
            {
                webClient.UploadData(address + "?timeout=60" + ApiVersion, "DELETE", new byte[0]);
            }
            catch (WebException ex)
            {
                Console.WriteLine("DeleteEntity failed: " + GetErrorFromException(ex));
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteEntity failed: " + ex.Message);
            }
        }

        // Send a message.
        public static void SendMessage(string address, string token, ServiceBusHttpMessage message)
        {
            WebClient webClient = CreateWebClient(token, "application/atom+xml;type=entry;charset=utf-8");

            // Serialize BrokerProperties.
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, message.brokerProperties);
            webClient.Headers.Add("BrokerProperties", Encoding.UTF8.GetString(ms.ToArray()));
            ms.Close();
            
            // Add custom properties.
            if (message.customProperties.Count != 0)
            {
                webClient.Headers.Add(message.customProperties);
            }

            // Send Message.
            try
            {
                webClient.UploadData(address + "/messages" + "?timeout=60", "POST", message.body);
            }
            catch (WebException ex)
            {
                Console.WriteLine("SendMessage failed: " + GetErrorFromException(ex));
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendMessage failed: " + ex.Message);
            }
        }

        // Send a batch of messages.
        public static void SendMessageBatch(string address, string token, ServiceBusHttpMessage message)
        {
            // Custom properties that are defined for the brokered message that contains the batch are ignored.
            // Throw exception to signal that these properties are ignored.
            if (message.customProperties.Count != 0)
            {
                throw new ArgumentException("Custom properties in BrokeredMessage are ignored.");
            }

            WebClient webClient = CreateWebClient(token, "application/vnd.microsoft.servicebus.json"); 
            try
            {
                webClient.UploadData(address + "/messages" + "?timeout=60", "POST", message.body);
            }
            catch (WebException ex)
            {
                Console.WriteLine("SendMessageBatch failed: " + GetErrorFromException(ex));
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendMessageBatch failed: " + ex.Message);
            }
        }

        // Peek and lock message. The parameter messageUri contains the URI of the message, which can be used to complete the message.
        public static ServiceBusHttpMessage ReceiveMessage(string address, string token, ref string messageUri)
        {
            return Receive("POST", address, token, ref messageUri);
        }

        // Receive and delete message.
        public static ServiceBusHttpMessage ReceiveAndDeleteMessage(string address, string token)
        {
            string dummy = null;
            return Receive("DELETE", address, token, ref dummy);
        }

        private static ServiceBusHttpMessage Receive(string httpVerb, string address, string token, ref string messageUri)
        {
            WebClient webClient = CreateWebClient(token);
            ServiceBusHttpMessage message = new ServiceBusHttpMessage();
            try
            {
                message.body = webClient.UploadData(address + "/messages/head?timeout=60", httpVerb, new byte[0]);
            }
            catch (WebException ex)
            {
                Console.WriteLine("Receive failed: " + GetErrorFromException(ex));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Receive failed: " + ex.Message);
                return null;
            }
            WebHeaderCollection responseHeaders = webClient.ResponseHeaders;

            // Check if a message was returned.
            if (responseHeaders.Get("BrokerProperties") == null)
            {
                return null;
            }

            // Deserialize BrokerProperties.
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(responseHeaders["BrokerProperties"])))
            {
                message.brokerProperties = (BrokerProperties)serializer.ReadObject(ms);
            }

            // Get custom propoerties.
            foreach( string key in responseHeaders.AllKeys)
            {
                if (!key.Equals("Transfer-Encoding") && !key.Equals("BrokerProperties") && !key.Equals("Content-Type") && !key.Equals("Location") && !key.Equals("Date") && !key.Equals("Server"))
                {
                    message.customProperties.Add(key, responseHeaders[key]);
                }
            }

            // Get message URI.
            if (responseHeaders.Get("Location") != null)
            {
                messageUri = responseHeaders["Location"];
            }

            return message;
        }

        // Delete message with the specified MessageId and LockToken.
        public static byte[] DeleteMessage(string address, string token, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            return DeleteMessage(messageUri, token);
        }

        // Delete message with the specified SequenceNumber and LockToken
        public static byte[] DeleteMessage(string address, string token, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            return DeleteMessage(messageUri, token);
        }

        // Delete message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public static byte[] DeleteMessage(string messageUri, string token)
        {
            WebClient webClient = CreateWebClient(token);
            try
            {
                return webClient.UploadData(messageUri + "?timeout=60", "DELETE", new byte[0]);
            }
            catch (WebException ex)
            {
                Console.WriteLine("DeleteMessage failed: " + GetErrorFromException(ex));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteMessage failed: " + ex.Message);
                return null;
            }
        }

        // Unlock message with the specified MessageId and LockToken.
        public static byte[] UnlockMessage(string address, string token, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            return UnlockMessage(messageUri, token);
        }

        // Unlock message with the specified SequenceNumber and LockToken
        public static byte[] UnlockMessage(string address, string token, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            return UnlockMessage(messageUri, token);
        }

        // Unlock message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public static byte[] UnlockMessage(string messageUri, string token)
        {
            WebClient webClient = CreateWebClient(token);
            try
            {
                return webClient.UploadData(messageUri + "?timeout=60", "PUT", new byte[0]);
            }
            catch (WebException ex)
            {
                Console.WriteLine("UnlockMessage failed: " + GetErrorFromException(ex));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UnlockMessage failed: " + ex.Message);
                return null;
            }
        }

        // Renew lock of the message with the specified MessageId and LockToken.
        public static byte[] RenewLock(string address, string token, string messageId, Guid LockId)
        {
            string messageUri = address + "/messages/" + messageId + "/" + LockId.ToString();
            return RenewLock(messageUri, token);
        }

        // Renew lock of the message with the specified SequenceNumber and LockToken
        public static byte[] RenewLock(string address, string token, long seqNum, Guid LockId)
        {
            string messageUri = address + "/messages/" + seqNum + "/" + LockId.ToString();
            return RenewLock(messageUri, token);
        }

        // Renew lock of the message with the specified URI. The URI is returned in the Location header of the response of the Peek request.
        public static byte[] RenewLock(string messageUri, string token)
        {
            WebClient webClient = CreateWebClient(token);
            try
            {
                return webClient.UploadData(messageUri + "?timeout=60", "POST", new byte[0]);
            }
            catch (WebException ex)
            {
                Console.WriteLine("RenewLock failed: " + GetErrorFromException(ex));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("RenewLock failed: " + ex.Message);
                return null;
            }
        }

        // Create a SAS token. SAS tokens are described in http://msdn.microsoft.com/en-us/library/windowsazure/dn170477.aspx.
        public static string GetSasToken(string uri, string keyName, string key)
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
        public static string GetAcsToken(string serviceNamespace, string issuerName, string issuerSecret)
        {
            var acsEndpoint = "https://" + serviceNamespace + "-sb.accesscontrol.windows.net/WRAPv0.9/";

            // Note that the realm used when requesting a token uses the HTTP scheme,
            // even though calls to the service are always issued over HTTPS.
            var realm = "http://" + serviceNamespace + ".servicebus.windows.net/";

            NameValueCollection values = new NameValueCollection();
            values.Add("wrap_name", issuerName);
            values.Add("wrap_password", issuerSecret);
            values.Add("wrap_scope", realm);

            WebClient webClient = new WebClient();
            byte[] response = null;
            try
            {
                response = webClient.UploadValues(acsEndpoint, values);
            }
            catch (WebException ex)
            {
                Console.WriteLine("GetAcsToken failed: " + GetErrorFromException(ex));
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAcsToken failed: " + ex.Message);
                return null;
            }

            string responseString = Encoding.UTF8.GetString(response);

            var responseProperties = responseString.Split('&');
            var tokenProperty = responseProperties[0].Split('=');
            var token = Uri.UnescapeDataString(tokenProperty[1]);

            Console.WriteLine("Token: " + token);
            return "WRAP access_token=\"" + token + "\"";
        }

        private static WebClient CreateWebClient(string token, string contentType = "")
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.Authorization] = token;
            if (!contentType.Equals(""))
            {
                webClient.Headers[HttpRequestHeader.ContentType] = contentType;
            }
            return webClient;
        }

        private static string GetErrorFromException(WebException webExcp)
        {
            string exceptionMessage = webExcp.Message;
            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                var stream = httpResponse.GetResponseStream();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                byte[] receivedBytes = memoryStream.ToArray();
                exceptionMessage = Encoding.UTF8.GetString(receivedBytes) + " (HttpStatusCode " + httpResponse.StatusCode.ToString() + ")";
            }
            catch (Exception)
            {
            }
            return exceptionMessage;
        }
    }
}
