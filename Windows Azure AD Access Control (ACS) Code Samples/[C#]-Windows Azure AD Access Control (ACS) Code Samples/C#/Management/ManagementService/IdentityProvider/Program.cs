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
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Common.ACS.Management;

    /// <summary>
    /// Manipulates a WS-Fed Identity Provider.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // create a WS-Fed identity provider by importing WS-Fed Metadata
            ProvisionIdpByFedmetadataImporter();

            // perform other operations on identity providers
            WSFederationIdentityProviderSample();

            FacebookIdentityProviderSample();

            Console.WriteLine("Done. Press ENTER to continue....\n");
            Console.ReadLine();
        }

        /// <summary>
        /// Helper function which deletes an identity provider and commits the change immediately.
        /// </summary>
        /// <param name="identityProviderName">Name of identity provider.</param>
        private static void DeleteIdentityProviderIfExists(string identityProviderName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            svc.DeleteIdentityProviderIfExists(identityProviderName);
            svc.SaveChangesBatch();
        }

        //
        // This is a convenient way to provision an IdP using Federation Metadata. 
        // Be aware that this mechanism doesn't allow you to control every IdP parameter.
        // You can, however, update the IdP once imported, and make the IdP available
        // to one or more RPs by adding associations. 
        private static void ProvisionIdpByFedmetadataImporter()
        {
            const string identityProviderName = "http://example.org/adfs/services/trust";
            const string fedMetadataFile = "FederationMetadata.xml";

            DeleteIdentityProviderIfExists(identityProviderName);

            ImportIdentityProviderFromMetadata(fedMetadataFile);

            DisplayIdentityProvider(identityProviderName);

            DeleteIdentityProviderIfExists(identityProviderName);
        }

        private static void ImportIdentityProviderFromMetadata(string fedMetadataFile)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            using (Stream metadataFileStream = new FileStream(fedMetadataFile, FileMode.Open, FileAccess.Read))
            {
                svc.ImportIdentityProviderFromStream(metadataFileStream);
            }
        }

        private static void WSFederationIdentityProviderSample()
        {
            const string identityProviderName = "WS-Federation Identity Provider";
            
            DeleteIdentityProviderIfExists(identityProviderName);

            CreateSampleWSFederationIdentityProvider(identityProviderName);

            DisplayIdentityProvider(identityProviderName);

            UpdateWSFederationIdentityProvider(identityProviderName);

            DisplayIdentityProvider(identityProviderName);

            DeleteIdentityProviderIfExists(identityProviderName);
        }

        private static void FacebookIdentityProviderSample()
        {
            const string applicationId = "appId";
            string name = string.Format(CultureInfo.InvariantCulture, "Facebook-{0}", applicationId);

            DeleteIdentityProviderIfExists(name);

            CreateFacebookIdentityProvider(applicationId);

            DisplayIdentityProvider(name);

            DeleteIdentityProviderIfExists(name);
        }

        private static void CreateFacebookIdentityProvider(string applicationId)
        {
            const string applicationSecret = "appSecret";
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.CreateFacebookIdentityProvider(applicationId, applicationSecret, "email,user_about_me");
            svc.SaveChangesBatch();
        }

        private static void CreateSampleWSFederationIdentityProvider(string identityProviderName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = startDate.AddYears(1);

            // Signing certificates can be found in a WSFederation IdP's fed-metadata.
            const string signingCertFileName = "identitykey.cer";

            IdentityProvider idp = svc.CreateWsFederationIdentityProvider(identityProviderName,
                X509Certificate.CreateFromCertFile(signingCertFileName).GetRawCertData(),
                startDate,
                endDate,
                "http://SampleIdentityProvider.com/sign-in/");

            // Do not include the ACS Management Relying Party
            svc.AssociateIdentityProvidersWithRelyingParties(new[] { idp }, svc.RelyingParties.Where(rp => rp.Name != "AccessControlManagement"));
            svc.SaveChangesBatch();
        }

        private static void UpdateWSFederationIdentityProvider(string identityProviderName)
        {
            Console.WriteLine("Updating identity provider properties...");
            Console.WriteLine();

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            // Retrieve Identity Provider
            IdentityProvider identityProvider = svc.GetIdentityProviderByName(identityProviderName, true);
            if (identityProvider != null)
            {
                // update DisplayName
                identityProvider.DisplayName = "*SampleIdentityProviderNewDisplayName*";

                //update sign-in address
                IdentityProviderAddress signInAddress = identityProvider.IdentityProviderAddresses.Where(m => m.EndpointType == IdentityProviderEndpointType.SignIn.ToString()).FirstOrDefault();
                if (signInAddress != null)
                {
                    signInAddress.Address = "http://SampleIdentityProvider/New-Sign-In";
                    svc.UpdateObject(signInAddress);
                }

                svc.UpdateObject(identityProvider);
                svc.SaveChangesBatch();
            }
        }

        private static void DisplayIdentityProvider(string identityProviderName)
        {
            Console.WriteLine("\nRetrieve Identity Provider (Name = {0})\n", identityProviderName);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            IdentityProvider identityProvider = svc.GetIdentityProviderByName(identityProviderName, true);

            // Display the values of returned Identity Provider
            if (identityProvider != null)
            {
                Console.WriteLine("\tId = {0}\n", identityProvider.Id);
                Console.WriteLine("\tDisplayName = {0}\n", identityProvider.DisplayName);
                Console.WriteLine("\tLoginParameters = {0}\n", identityProvider.LoginParameters);
                Console.WriteLine("\tWebSSOProtocolType = {0}\n", identityProvider.WebSSOProtocolType);

                // display keys associated to the Identity Provider
                foreach (IdentityProviderKey identityProviderKey in identityProvider.IdentityProviderKeys)
                {
                    DisplayIdentityProviderKey(identityProviderKey);
                }

                // display addresses associated to the Identity Provider
                foreach (IdentityProviderAddress identityProviderAddress in identityProvider.IdentityProviderAddresses)
                {
                    DisplayIdentityProviderAddress(identityProviderAddress);
                }
            }
        }

        private static void DisplayIdentityProviderKey(IdentityProviderKey identityProviderKey)
        {
            // Display the values of returned Identity Provider
            if (identityProviderKey != null)
            {
                //
                // Values for Application keys should be displayed as UTF-8. Symmetric keys and certificates are Base64.
                //

                string keyValue = identityProviderKey.Type == IdentityProviderKeyType.ApplicationKey.ToString() ? 
                    Encoding.ASCII.GetString(identityProviderKey.Value) : Convert.ToBase64String(identityProviderKey.Value);

                Console.WriteLine("\tIdentity Provider Key (Id = {0})\n", identityProviderKey.Id);
                Console.WriteLine("\t\tId = {0}\n", identityProviderKey.Id);
                Console.WriteLine("\t\tDisplayName = {0}\n", identityProviderKey.DisplayName);
                Console.WriteLine("\t\tType = {0}\n", identityProviderKey.Type);
                Console.WriteLine("\t\tUsage = {0}\n", identityProviderKey.Usage);
                Console.WriteLine("\t\tStartDate = {0}\n", identityProviderKey.StartDate);
                Console.WriteLine("\t\tEndDate = {0}\n", identityProviderKey.EndDate);
                Console.WriteLine("\t\tValue = {0}\n", keyValue);
            }
        }

        private static void DisplayIdentityProviderAddress(IdentityProviderAddress identityProviderAddress)
        {
            if (identityProviderAddress == null)
            {
                return;
            }

            Console.WriteLine("\tIdentity Provider Address (Id = {0})\n", identityProviderAddress.Id);
            Console.WriteLine("\t\tId = {0}\n", identityProviderAddress.Id);
            Console.WriteLine("\t\tAddress = {0}\n", identityProviderAddress.Address);
            Console.WriteLine("\t\tEndpointType = {0}\n", identityProviderAddress.EndpointType);
        }
    }
}