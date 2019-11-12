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
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class SASAuthREST
    {
        private const string sbHostSuffix = ".servicebus.windows.net/";
        private const string acsHostSuffix = ".accesscontrol.windows.net/";
        private const string acsWrapEndpoint = "WRAPv0.9/";


        public static void SendMessageToQ(string serviceNamespace, string qPath, string keyName, string key)
        {
            string baseAddress = "https://" + serviceNamespace + sbHostSuffix;
            string qAddress = baseAddress + qPath + "/";
            
            var sasToken = GetSASToken(qAddress, keyName, key);
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(qAddress)
            };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", sasToken);
            var postResult = httpClient.PostAsJsonAsync("messages", "Hello, Service Bus!").Result;
        }

        public static void ReceiveMessageFromQ(string serviceNamespace, string qPath, string keyName, string key)
        {
            string baseAddress = "https://" + serviceNamespace + sbHostSuffix;
            string qAddress = baseAddress + qPath + "/";

            var sasToken = GetSASToken(qAddress, keyName, key);
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(qAddress)
            };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", sasToken);
            var deleteResult = httpClient.DeleteAsync("messages/head").Result;
            string message = deleteResult.Content.ReadAsAsync<string>().Result;
        }

        private static string GetSASToken(string resourceUri, string keyName, string key)
        {
            var expiry = GetExpiry();
            string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));

            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", 
                HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
            return sasToken;
        }

        private static string GetExpiry()
        {
            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return Convert.ToString((int)sinceEpoch.TotalSeconds + 3600);
        }
    }
}
