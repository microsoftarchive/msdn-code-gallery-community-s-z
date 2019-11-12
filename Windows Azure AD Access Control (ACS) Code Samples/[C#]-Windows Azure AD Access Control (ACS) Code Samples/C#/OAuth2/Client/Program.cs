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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Xml;
using ACS.Management;
using Microsoft.IdentityModel.Tokens.Saml2;
using OAuth2Common;
using WifTokenTypes = Microsoft.IdentityModel.Tokens.SecurityTokenTypes;

namespace Client
{
    class Program
    {
        public const string ClientName = "OAuth2SampleX509Identity";
        private static string ClientCertificateFilePath = @"..\..\..\Certificates\ACS2ClientCertificate.pfx";
        private static string ClientCertificatePassword = "password";

        static void Main(string[] args)
        {
            //
            // Create a SAML token signed with the given certificate
            //
            byte[] clientCertificateBytes = ManagementServiceHelper.ReadBytesFromPfxFile(ClientCertificateFilePath, ClientCertificatePassword);
            Saml2SecurityToken token = SelfSignedSaml2TokenGenerator.GetSamlAssertionSignedWithCertificate(ClientName, clientCertificateBytes, ClientCertificatePassword);

            //
            // Encode the SAML token into an OAuth request to ACS.
            //
            Dictionary<string, string> requestParameters = new Dictionary<string, string>();
            requestParameters[OAuth2Constants.Scope] = ConfigurationManager.AppSettings.Get("RelyingPartyScope");
            requestParameters[OAuth2Constants.GrantType] = WifTokenTypes.Saml2TokenProfile11;
            requestParameters[OAuth2Constants.Assertion] = GetSaml2TokenString(token);

            Dictionary<string, string> acsResponse = GetOAuth2ResponseFromAcs(requestParameters);

            //
            // Pass the access token returned by ACS to the protected resource.
            //
            Console.WriteLine(GetProtectedResource(acsResponse[OAuth2Constants.AccessToken]));

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static string GetSaml2TokenString(Saml2SecurityToken token)
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            StringBuilder sb = new StringBuilder();

            writerSettings.OmitXmlDeclaration = true;

            using (XmlWriter xw = XmlWriter.Create(sb, writerSettings))
            {
                new Saml2SecurityTokenHandler().WriteToken(xw, token);

                return sb.ToString();
            }
        }

        private static Dictionary<string, string> GetOAuth2ResponseFromAcs(Dictionary<string, string> requestParameters)
        {
            string acsOAuth2Endpoint = String.Format(CultureInfo.InvariantCulture, "https://{0}.{1}/v2/OAuth2-13", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            WebRequest acsRequest = WebRequest.Create(acsOAuth2Endpoint);

            acsRequest.AuthenticationLevel = AuthenticationLevel.None;
            acsRequest.ContentType = OAuth2Constants.ContentTypes.UrlEncoded;
            acsRequest.Method = "POST";

            string requestData = requestParameters.Encode();

            acsRequest.ContentLength = requestData.Length;

            StreamWriter requestWriter = new StreamWriter(acsRequest.GetRequestStream(), Encoding.ASCII);

            requestWriter.Write(requestData);
            requestWriter.Close();

            HttpWebResponse acsResponse = acsRequest.GetResponse() as HttpWebResponse;

            Dictionary<string, string> acsResponseParameters = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(acsResponse.GetResponseStream());

            acsResponseParameters.DecodeFromJson(sr.ReadToEnd());

            return acsResponseParameters;
        }

        private static string GetProtectedResource(string accessToken)
        {
            string rpUrl = ConfigurationManager.AppSettings.Get("ProtectedResourceUrl");

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(rpUrl);
            request.Headers.Add("Authorization", OAuth2Constants.BearerAuthenticationType + " " + accessToken);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
