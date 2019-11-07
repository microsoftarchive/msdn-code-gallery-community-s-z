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
using System.Security.Cryptography.X509Certificates;
using ACS.Management;
using Common.ACS.Management;

namespace ConfigureSample
{
    class Program
    {
        /// <summary>
        /// Configures the ACS service namespace with the proper objects for this sample.
        /// </summary>
        /// <remarks>
        /// Existing objects that are needed for this sample will be deleted and recreated.
        /// </remarks>
        static void Main(string[] args)
        {
            const string rpName = "Federation Sample RP";
            const string rpRealm = "http://localhost:7200/Service/Default.aspx";
            const string ruleGroupName = "Default rule group for Federation Sample RP";
            const string decryptionKeyName = "Decryption key for Federation Sample";

            // Please update this Url from your own STS settings 
            const string IdentityProviderMetadataUrl = "The Federation Metadata URL, e.g. https://contoso.com/FederationMetadata/2007-06/FederationMetadata.xml";
            // Please update this for value from your federation metadata
            const string entityId = "The entityId of your STS, e.g. http://contoso.com/adfs/services/trust";

            // If you are using a self-signed certificate for your IdentityProvider, 
            // certificate validation needs to be disabled to import IdentityProvider from its metadata url
            TrustAllCertificates();

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteRelyingPartyByRealmIfExists(rpRealm);
            svc.DeleteRuleGroupByNameIfExists(ruleGroupName);
            svc.DeleteIdentityProviderIfExists(entityId);

            //
            // Delete all identity provider decryption keys
            //
            foreach (ServiceKey key in svc.GetIdentityProviderDecryptionKeys())
            {
                svc.DeleteObject(key);
            }

            svc.SaveChangesBatch();

            RelyingParty relyingParty = svc.CreateRelyingParty(rpName, rpRealm, null, RelyingPartyTokenType.SAML_2_0, true);

            //
            // Create the necessary signing, encrypting and decryption keys.
            //
            byte[] signingCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(@"..\..\..\Certificates\ACS2SigningCertificate.pfx", "password");
            byte[] decryptionCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(@"..\..\..\Certificates\ACS2DecryptionCert.pfx", "password");
            byte[] encryptionCertificate = new X509Certificate2(@"..\..\..\Certificates\WcfServiceCertificate.cer").RawData;

            svc.CreateRelyingPartyKey(relyingParty, signingCertificate, "password", RelyingPartyKeyType.X509Certificate, RelyingPartyKeyUsage.Signing, true);
            svc.CreateRelyingPartyKey(relyingParty, encryptionCertificate, null, RelyingPartyKeyType.X509Certificate, RelyingPartyKeyUsage.Encrypting, true);

            svc.CreateIdentityProviderDecryptionKey(decryptionKeyName, decryptionCertificate, "password", true);

            svc.ImportIdentityProviderFromMetadataUrl(new Uri(IdentityProviderMetadataUrl));

            svc.AssociateIdentityProvidersWithRelyingParties(new[] { svc.GetIdentityProviderByName(entityId) }, new[] { relyingParty });

            RuleGroup ruleGroup = svc.CreateRuleGroup(ruleGroupName);
            svc.GenerateRules(ruleGroup, new[] { svc.GetIdentityProviderByName(entityId) });
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            svc.SaveChangesBatch();

            Console.WriteLine("Sample successfully configured. Press ENTER to continue ...");
            Console.ReadLine();
        }

        private static void TrustAllCertificates()
        {
            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
        }
    }
}
