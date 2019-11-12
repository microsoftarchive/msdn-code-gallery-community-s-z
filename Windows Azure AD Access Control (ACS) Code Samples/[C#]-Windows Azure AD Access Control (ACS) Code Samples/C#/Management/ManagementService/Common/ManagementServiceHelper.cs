//---------------------------------------------------------------------------------
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
//---------------------------------------------------------------------------------

namespace ACS.Management
{
    using System;
    using System.Collections.Specialized;
    using System.Data.Services.Client;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Security.Cryptography.X509Certificates;
    using Common.ACS.Management;

    /// <summary>
    /// This class obtains a SWT token and adds it to the HTTP authorize header 
    /// for every request to the management service.
    /// </summary>
    public class ManagementServiceHelper
    {
        static string cachedSwtToken;

        /// <summary>
        /// Creates and returns a ManagementService object. This is the only 'interface' used by other classes.
        /// </summary>
        /// <returns>An instance of the ManagementService.</returns>
        public static ManagementService CreateManagementServiceClient()
        {
            string managementServiceEndpoint = String.Format(CultureInfo.InvariantCulture, "https://{0}.{1}/{2}", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl, SamplesConfiguration.AcsManagementServicesRelativeUrl);
            ManagementService managementService = new ManagementService(new Uri(managementServiceEndpoint));

            managementService.SendingRequest += GetTokenWithWritePermission;

            return managementService;
        }

        /// <summary>
        /// Event handler for getting a token from ACS.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="args">Event arguments.</param>
        public static void GetTokenWithWritePermission(object sender, SendingRequestEventArgs args)
        {
            GetTokenWithWritePermission((HttpWebRequest) args.Request);
        }

        /// <summary>
        /// Helper function for the event handler above, adding the SWT token to the HTTP 'Authorization' header. 
        /// The SWT token is cached so that we don't need to obtain a token on every request.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        public static void GetTokenWithWritePermission(HttpWebRequest args)
        {
            if (cachedSwtToken == null)
            {
                cachedSwtToken = GetTokenFromACS();
            }

            args.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + cachedSwtToken);
        }

        /// <summary>
        /// Obtains a SWT token from ACSv2. 
        /// </summary>
        /// <returns>A token  from ACS.</returns>
        static string GetTokenFromACS()
        {
            //
            // Request a token from ACS
            //
            WebClient client = new WebClient();
            client.BaseAddress = string.Format(CultureInfo.CurrentCulture, "https://{0}.{1}", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            NameValueCollection values = new NameValueCollection();
            values.Add("grant_type", "client_credentials");
            values.Add("client_id", SamplesConfiguration.ManagementServiceIdentityName);
            values.Add("client_secret", SamplesConfiguration.ManagementServiceIdentityKey);
            values.Add("scope", client.BaseAddress + SamplesConfiguration.AcsManagementServicesRelativeUrl);

            byte[] responseBytes = client.UploadValues("/v2/OAuth2-13", "POST", values);

            //
            // Extract the access token and return it.
            //
            using( MemoryStream responseStream = new MemoryStream(responseBytes))
            {
                OAuth2TokenResponse tokenResponse = (OAuth2TokenResponse) new DataContractJsonSerializer(typeof(OAuth2TokenResponse)).ReadObject(responseStream);
                return tokenResponse.access_token;
            }
        }

        /// <summary>
        /// Helper function to read the content of a .pfx file to a byte array. 
        /// </summary>
        public static byte[] ReadBytesFromPfxFile(string pfxFileName, string protectionPassword)
        {
            //
            // Read the bytes from the .pfx file.
            //
            byte[] signingCertificate;
            using (FileStream stream = File.OpenRead(pfxFileName))
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    signingCertificate = br.ReadBytes((int) stream.Length);
                }
            }

            //
            // Double check on the read byte array by creating a X509Certificate2 object which should not throw.
            //
            X509Certificate2 cert = new X509Certificate2(signingCertificate, protectionPassword);

            if (!cert.HasPrivateKey)
            {
                throw new InvalidDataException(pfxFileName + "doesn't have a private key.");
            }

            return signingCertificate;
        }

        [DataContract]
        private class OAuth2TokenResponse
        {
            [DataMember]
            public string access_token;
        }
    }
}

