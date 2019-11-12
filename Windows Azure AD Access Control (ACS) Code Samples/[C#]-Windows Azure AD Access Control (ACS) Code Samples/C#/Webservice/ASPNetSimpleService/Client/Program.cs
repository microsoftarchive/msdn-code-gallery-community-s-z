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

namespace Microsoft.AccessControl2.SDK.ASPNetSimpleWebsiteClient
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using ACS.Management;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter a string to reverse, then press <ENTER>");
            string valueToReverse = Console.ReadLine();

            string token = GetTokenFromACS( "http://localhost:8000/Service/" );
            Console.WriteLine( "\nReceived token from ACS: {0}\n", token );

            string serviceResponse = SendMessageToService(token, valueToReverse);

            Console.WriteLine("Service responded with: {0}\n", serviceResponse);
            Console.WriteLine("Press <ENTER> to exit");
            Console.ReadLine();
        }

        static string GetTokenFromACS( string scope )
        {
            string oauthUserName = ConfigurationManager.AppSettings.Get( "OAuthUserName" );
            string oauthPassword = ConfigurationManager.AppSettings.Get( "OAuthPassword" );

            WebClient client = new WebClient();
            client.BaseAddress = string.Format(
                CultureInfo.InvariantCulture, "https://{0}.{1}", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            NameValueCollection values = new NameValueCollection();
            values.Add("grant_type", "client_credentials");
            values.Add("client_id", oauthUserName);
            values.Add("client_secret", oauthPassword);
            values.Add("scope", scope);

            byte[] responseBytes = client.UploadValues("/v2/OAuth2-13", "POST", values);

            //
            // Extract the access token and return it.
            //
            using ( MemoryStream responseStream = new MemoryStream( responseBytes ) )
            {
                OAuth2TokenResponse tokenResponse =
                    (OAuth2TokenResponse)new DataContractJsonSerializer( typeof( OAuth2TokenResponse ) ).ReadObject( responseStream );
                return tokenResponse.access_token;
            }
        }

        private static string SendMessageToService(string token, string valueToReverse)
        {
            WebClient client = new WebClient();
            client.BaseAddress = ConfigurationManager.AppSettings.Get("ServiceAddress");

            string headerValue = string.Format("OAuth2 access_token=\"{0}\"", token);

            client.Headers.Add("Authorization", headerValue);

            NameValueCollection values = new NameValueCollection();
            values = new NameValueCollection();
            values.Add("string_to_reverse", valueToReverse);

            byte[] serviceResponseBytes = client.UploadValues(string.Empty, values);

            return Encoding.UTF8.GetString(serviceResponseBytes);
        }
    }
}

