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

namespace ACSv2.SDK.ManagementService.ServiceKey
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using ACS.Management;
    using Common.ACS.Management;

    /// <summary>
    /// Manipulate service keys.
    /// </summary>
    class Program
    {
        static DateTime defaultStartTime = DateTime.UtcNow;
        static DateTime defaultEndTime = DateTime.UtcNow.AddYears(1);     

        static void Main(string[] args)
        {
            // CRUD for service key of 'X509Certificate' key type. 
            CertificateServiceKeyCRUD();

            // CRUD for service key of 'Symmetric' key type. 
            SymmetricSigningServiceKeyCRUD();

            Console.WriteLine("Done. Press ENTER to continue ...");
            Console.ReadLine();
        }

        /// <summary>
        /// CRUD for service key of 'X509Certificate' key type. 
        /// </summary>
        private static void CertificateServiceKeyCRUD()
        {
            string displayName = "Certificate for signing tokens to RPs";

            // Add a signing certificate. 
            {
                string pfxFileName = "SampleCert.pfx";
                string protectionPassword = @"pass@word1";

                byte[] signingCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(pfxFileName, protectionPassword);

                EnumerateServiceKeys();

                DeleteServiceKeyByDisplayNameIfExists(displayName);
                EnumerateServiceKeys();

                AddServiceKey(displayName, signingCertificate, protectionPassword, ServiceKeyType.X509Certificate, ServiceKeyUsage.Signing);
                EnumerateServiceKeys();
            }

            // Update and delete the signing certificate. 
            {
                string pfxFileName2 = "TenantSigningCert.pfx";
                string protectionPassword2 = @"TenantSigningCert";

                byte[] updatedSigningCertificate = ManagementServiceHelper.ReadBytesFromPfxFile(pfxFileName2, protectionPassword2);

                UpdateServiceKey(displayName, updatedSigningCertificate, protectionPassword2, ServiceKeyType.X509Certificate);
                EnumerateServiceKeys();

                DeleteServiceKeyByDisplayNameIfExists(displayName);
                EnumerateServiceKeys();
            }
        }

        /// <summary>
        /// CRUD for service key of 'Symmetric' key type. 
        /// </summary>      
        private static void SymmetricSigningServiceKeyCRUD()
        {
            Console.WriteLine("\n============ SymmetricSigningKeyCRUD ============\n");

            string displayName = "Symmetric key for signing tokens to RPs";

            //
            // Generate a 32-byte symmetric key.
            //
            byte[] signingKey = new byte[32];
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            rngCryptoServiceProvider.GetBytes(signingKey);           

            EnumerateServiceKeys();

            DeleteServiceKeyByDisplayNameIfExists(displayName);
            EnumerateServiceKeys();

            AddServiceKey(displayName, signingKey, null, ServiceKeyType.Symmetric, ServiceKeyUsage.Signing);
            EnumerateServiceKeys();

            byte[] updatedkey = Convert.FromBase64String("UXFUvbfJnDtgL3SD19hxuCvpMYy7Vla6s50n0GQkFAg=");
            UpdateServiceKey(displayName, updatedkey, null, ServiceKeyType.Symmetric);
            EnumerateServiceKeys();

            DeleteServiceKeyByDisplayNameIfExists(displayName);
            EnumerateServiceKeys();
        }


        /// <summary>
        /// Enumerate all service keys.
        /// </summary>
        private static void EnumerateServiceKeys()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            Console.WriteLine("Service Keys:\n");

            foreach (ServiceKey key in svc.ServiceKeys)
            {
                Console.WriteLine("Name     : " + key.DisplayName);
                Console.WriteLine("Type     : " + key.Type);
                Console.WriteLine("Password : " + (key.Password == null ? "" : Encoding.UTF8.GetString(key.Password)));
                Console.WriteLine("Usage    : " + key.Usage);
                Console.WriteLine("Key      : " + Convert.ToBase64String(key.Value) + "\n");
            }
        }

        /// <summary>
        /// Delete a service key by its display name. 
        /// </summary>
        private static void DeleteServiceKeyByDisplayNameIfExists(string displayName)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            IQueryable<ServiceKey> serviceKeys = svc.ServiceKeys.Where(e => e.DisplayName == displayName);

            if (serviceKeys.Count() != 0)
            {
                foreach (ServiceKey sk in serviceKeys)
                {
                    svc.DeleteObject(sk);
                }

                svc.SaveChangesBatch();
            }
        }

        /// <summary>
        /// Add a service key.
        /// </summary>
        private static void AddServiceKey(string displayName, byte[] keyValue, string protectionPassword, ServiceKeyType keyType, ServiceKeyUsage keyUsage)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            UTF8Encoding enc = new UTF8Encoding();

            ServiceKey serviceKey = new ServiceKey()
            {
                DisplayName = displayName,
                Type = keyType.ToString(),
                Usage = keyUsage.ToString(),
                Value = keyValue,
                Password = string.IsNullOrEmpty(protectionPassword) ? null : enc.GetBytes(protectionPassword),
                StartDate = defaultStartTime,
                EndDate = defaultEndTime
            };

            svc.AddToServiceKeys(serviceKey);
            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Update the service key value and the protection password.
        /// </summary>
        private static void UpdateServiceKey(string displayName, byte[] keyValue, string protectionPassword, ServiceKeyType keyType)
        {
            UTF8Encoding enc = new UTF8Encoding();
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            ServiceKey serviceKey = svc.ServiceKeys.Where(sk => sk.DisplayName == displayName && sk.Type == keyType.ToString()).First();

            serviceKey.Value = keyValue;
            serviceKey.Password = string.IsNullOrEmpty(protectionPassword) ? null : enc.GetBytes(protectionPassword);

            svc.UpdateObject(serviceKey);
            svc.SaveChangesBatch();
        }
    }

}
