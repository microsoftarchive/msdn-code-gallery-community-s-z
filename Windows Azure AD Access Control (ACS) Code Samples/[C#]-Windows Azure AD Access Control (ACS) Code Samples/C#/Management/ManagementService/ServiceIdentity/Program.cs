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
    using System.IO;
    using System.Data.Services.Client;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Common.ACS.Management;

    /// <summary>
    /// Manipulate service identity and service identity keys.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // CRUD for service identity & service identity 'Password'. 
            NamePasswordServiceIdentityCRUD();

            // CRUD for service identity & service identity symmetric 'Signing' key. 
            SymmetricSigningServiceIdentityCRUD();

            // pause the program
            Console.WriteLine("Done. Press ENTER to continue....\n");
            Console.ReadLine();
        }

        /// <summary>
        /// Helper function which deletes the service identity and commits immediately.
        /// </summary>
        /// <param name="name"></param>
        private static void DeleteServiceIdentityIfExists(string name)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.DeleteServiceIdentityIfExists(name);
            svc.SaveChangesBatch();
        }

        /// <summary>
        /// CRUD for service identity & service identity 'Password'. 
        /// </summary>
        private static void NamePasswordServiceIdentityCRUD()
        {
            string name = "SampleServiceIdentityName";
            string password = "SampleServiceIdentityPassword";

            DeleteServiceIdentityIfExists(name);

            CreatePasswordServiceIdentity(name, password);
            
            DisplayServiceIdentity(name);

            string updatedPassword = "*modified* " + password;
            UpdateServiceIdentityKey(name, Encoding.UTF8.GetBytes(updatedPassword), ServiceIdentityKeyType.Password);

            DisplayServiceIdentity(name);

            DeleteServiceIdentityIfExists(name);
        }

        private static void CreatePasswordServiceIdentity(string name, string password)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.CreateServiceIdentity(name, Encoding.UTF8.GetBytes(password), ServiceIdentityKeyType.Password, ServiceIdentityKeyUsage.Password);
            svc.SaveChangesBatch();
        }

        private static void CreateSymmetricServiceIdentity(string name, byte[] key)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();
            svc.CreateServiceIdentity(name, key, ServiceIdentityKeyType.Symmetric, ServiceIdentityKeyUsage.Signing);
            svc.SaveChangesBatch();
        }

        /// <summary>
        /// Enumerate Service Identities.
        /// </summary>
        private static void DisplayServiceIdentity(string name)
        {
            Console.WriteLine("\nRetrieve Service Identity (Name = {0})\n", name);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            ServiceIdentity sid = svc.GetServiceIdentityByName(name);

            if (sid != null)
            {
                Console.WriteLine("\tId = {0}\n", sid.Id);
                Console.WriteLine("\tName = {0}\n", sid.Name);

                foreach (ServiceIdentityKey key in sid.ServiceIdentityKeys)
                {
                    string keyValue = null;

                    if (key.Type == ServiceIdentityKeyType.Password.ToString())
                    {
                        keyValue = Encoding.ASCII.GetString(key.Value);
                    }
                    else
                    {
                        keyValue = Convert.ToBase64String(key.Value);
                    }

                    Console.WriteLine("\tService identity key (Id = {0})\n", key.Id);
                    Console.WriteLine("\t\tId = {0}\n", key.Id);
                    Console.WriteLine("\t\tDisplayName = {0}\n", key.DisplayName);
                    Console.WriteLine("\t\tType = {0}\n", key.Type);
                    Console.WriteLine("\t\tUsage = {0}\n", key.Usage);
                    Console.WriteLine("\t\tStartDate = {0}\n", key.StartDate);
                    Console.WriteLine("\t\tEndDate = {0}\n", key.EndDate);
                    Console.WriteLine("\t\tValue = {0}\n", keyValue);
                }

            }

        }

        /// <summary>
        /// CRUD for service identity & service identity symmetric 'Signing' key. 
        /// </summary>
        private static void SymmetricSigningServiceIdentityCRUD()
        {
            string name = "SymmetricSigningIdentity";

            //
            // Generate a 32-byte symmetric key.
            //
            byte[] signingKey = new byte[32];
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            rngCryptoServiceProvider.GetBytes(signingKey);

            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            DeleteServiceIdentityIfExists(name);

            CreateSymmetricServiceIdentity(name, signingKey);

            DisplayServiceIdentity(name);

            byte[] updatedkey = Convert.FromBase64String("UXFUvbfJnDtgL3SD19hxuCvpMYy7Vla6s50n0GQkFAg=");
            UpdateServiceIdentityKey(name, updatedkey, ServiceIdentityKeyType.Symmetric);
            DisplayServiceIdentity(name);

            DeleteServiceIdentityIfExists(name);
        }

        /// <summary>
        /// Update the service identity key value.
        /// </summary>
        private static void UpdateServiceIdentityKey(string name, byte[] keyValue, ServiceIdentityKeyType keyType)
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            ServiceIdentity serviceIdentity = svc.GetServiceIdentityByName(name);

            if (serviceIdentity != null)
            {
                foreach (ServiceIdentityKey key in serviceIdentity.ServiceIdentityKeys)
                {
                    if (key.Type == keyType.ToString())
                    {
                        key.Value = keyValue;
                        svc.UpdateObject(key);
                    }
                }
            }

            svc.SaveChangesBatch();
        }
    }
}

