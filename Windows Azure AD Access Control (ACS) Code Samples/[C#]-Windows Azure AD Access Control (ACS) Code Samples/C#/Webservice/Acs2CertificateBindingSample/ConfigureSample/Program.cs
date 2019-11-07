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
            const string rpName = "Certificate Binding Sample RP";
            const string rpRealm = "http://localhost:7000/Service/Default.aspx";
            const string serviceIdentityName = "Certificate Binding Sample Service Identity";
            const string ruleGroupName = "Default rule group for Certificate Binding Sample RP";

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteRelyingPartyByRealmIfExists(rpRealm);
            svc.DeleteServiceIdentityIfExists(serviceIdentityName);
            svc.DeleteRuleGroupByNameIfExists(ruleGroupName);
            svc.SaveChangesBatch();

            RelyingParty relyingParty = svc.CreateRelyingParty(rpName, rpRealm, null, RelyingPartyTokenType.SAML_2_0, true);

            //
            // Create the necessary signing and encrypting keys.
            //
            byte[] signingCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(@"..\..\..\Certificates\ACS2SigningCertificate.pfx", "password");
            byte[] encryptionCertificate = new X509Certificate2(@"..\..\..\Certificates\WcfServiceCertificate.cer").RawData;

            svc.CreateRelyingPartyKey(relyingParty, signingCertificate, "password", RelyingPartyKeyType.X509Certificate, RelyingPartyKeyUsage.Signing, true);
            svc.CreateRelyingPartyKey(relyingParty, encryptionCertificate, null, RelyingPartyKeyType.X509Certificate, RelyingPartyKeyUsage.Encrypting, true);

            byte[] clientCertificate = new X509Certificate2(@"..\..\..\Certificates\ACS2ClientCertificate.cer").RawData;

            svc.CreateServiceIdentity(serviceIdentityName, clientCertificate, ServiceIdentityKeyType.X509Certificate, ServiceIdentityKeyUsage.Signing);

            RuleGroup ruleGroup = svc.CreateRuleGroup(ruleGroupName);
            svc.AssignRuleGroupToRelyingParty(ruleGroup, relyingParty);

            //
            // Add a rule to pass through all ACS-issued claims.  These are represented by an issuer called "LOCAL AUTHORITY"
            // Null input and output claim types and values mean to pass-through all.
            //
            svc.CreateRule(svc.GetIssuerByName("LOCAL AUTHORITY"), null, null, null, null, ruleGroup, "Pass through all claims issued by ACS.");
            svc.SaveChangesBatch();

            Console.WriteLine("Sample successfully configured. Press ENTER to continue ...");
            Console.ReadLine();
        }
    }
}
