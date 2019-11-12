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
using System.Data.Services.Client;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using ACS.Management;
using Common.ACS.Management;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using EntityDescriptor = Microsoft.IdentityModel.Protocols.WSFederation.Metadata.EntityDescriptor;

namespace ACS.KeyManagement
{
    class Program
    {
        // This sample contains four sample metadata documents, differentiated as follows:
        // Metadata for an identity provider.
        const string IDPMetadataForImport = "IDPMetadata-SigningCertA.xml";

        // Metadata for the same identity provider signed with a different certificate.
        const string IDPMetadataForUpdate = "IDPMetadata-SigningCertB.xml";

        // Metadata for a relying party which contains a encryption certificate.
        const string RPMetadataForImport = "RPMetadata-EncryptionCertA.xml";

        // Metadata for the same relying party which contains a different encryption certificate.
        const string RPMetadataForUpdate = "RPMetadata-EncryptionCertB.xml";

        static void Main(string[] args)
        {
            // This sample will demonstrate how to:
            // Import IDP and RP metadata to Access Control Service using the management service.
            // Emulating a metadata change on the IDP or RP, update Access Control Service using the management service and 
            // Windows Identity Foundation to parse and extract the keys to be updated.
            // Note: This sample requires Windows Identity Foundation to be installed.

            ImportIdentityProviderMetadata();
            UpdateIdentityProviderMetadata();

            ImportRelyingPartyMetadata();
            UpdateRelyingPartyMetadata();

            Console.WriteLine("Done. Press ENTER to continue...\n");
            Console.ReadLine();
        }

        #region Metadata serialization helpers
        /// <summary>
        /// Use WIF to read an EntityDescriptor from a metadata stream.
        /// </summary>
        /// <param name="metadataStream">Stream to read.</param>
        /// <returns>EntityDescriptor representing the metadata for the entity.</returns>
        static EntityDescriptor ReadMetadata(Stream metadataStream)
        {
            MetadataSerializer metadataSerializer = new MetadataSerializer();
            return metadataSerializer.ReadMetadata(metadataStream) as EntityDescriptor;
        }

        /// <summary>
        /// Extract the entity id from an entity descriptor.
        /// </summary>
        /// <param name="metadata">EntityDescriptor representing the entity.</param>
        /// <returns>Name of the entity.</returns>
        static string GetEntityName(EntityDescriptor metadata)
        {
            return metadata.EntityId.Id;
        }
        
        /// <summary>
        /// Extract the certificates for a specific role and use.
        /// </summary>
        /// <typeparam name="T">The derived type from RoleDescriptor which represents the role this entity is using to participate in the federation.</typeparam>
        /// <param name="metadata">EntityDescriptor representing the entity.</param>
        /// <param name="keyType">Usage for the certificate.</param>
        /// <returns>The list of certificates associated with the role and usage the entity is using to participate in the federation.</returns>
        static List<X509Certificate2> ExtractX509CertificatesFromMetadata<T>(EntityDescriptor metadata, KeyType keyType) where T : RoleDescriptor
        {
            List<X509Certificate2> certs = new List<X509Certificate2>();

            foreach (RoleDescriptor roleDescriptor in metadata.RoleDescriptors)
            {
                if (roleDescriptor.GetType() == typeof(T))
                {
                    foreach (KeyDescriptor keyDescriptor in roleDescriptor.Keys)
                    {
                        if (keyDescriptor.Use == keyType)
                        {
                            certs.AddRange(GetCertificatesFromKeyInfo(keyDescriptor.KeyInfo));
                        }
                    }
                }
            }

            return certs;
        }

        /// <summary>
        /// Converts a SKI into one or more certificates for further processing.
        /// </summary>
        /// <param name="ski">SecurityKeyIdentifier to convert.</param>
        /// <returns>List of X509Certificate2 objects converted from the SKI.</returns>
        static List<X509Certificate2> GetCertificatesFromKeyInfo(SecurityKeyIdentifier ski)
        {
            List<X509Certificate2> certificates = new List<X509Certificate2>();

            foreach (SecurityKeyIdentifierClause keyClause in ski)
            {
                //
                // Only X509RawData clauses are supported. If any other clause is present, custom code
                // would be required to resolve the clause against some certificate store, such as the Windows
                // certificate store or a database. WIF exposes security token resolver classes which can
                // help with this resolution if needed.
                //
                X509RawDataKeyIdentifierClause x509KeyClause = keyClause as X509RawDataKeyIdentifierClause;
                if (x509KeyClause != null)
                {
                    byte[] certificateBytes = x509KeyClause.GetX509RawData();
                    certificates.Add(new X509Certificate2(certificateBytes));
                }
            }

            return certificates;
        }

        #endregion

        /// <summary>
        /// Extract the subject name from a certificate.
        /// </summary>
        /// <param name="certBytes">Byte array representation of a certificate.</param>
        /// <returns>Certificate subject name.</returns>
        static string GetSubjectFromCertificate(byte[] certBytes)
        {
            return new X509Certificate2(certBytes).Subject;
        }

        /// <summary>
        /// Import the identity provider from metadata using a call to the management service.
        /// </summary>
        static void ImportIdentityProviderMetadata()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            Console.WriteLine(String.Format("Reading metadata from file '{0}'...\n", IDPMetadataForImport));
            using (FileStream fileStream = new FileStream(IDPMetadataForImport, FileMode.Open))
            {
                EntityDescriptor metadata   = ReadMetadata(fileStream);
                string issuerName           = GetEntityName(metadata);
                svc.DeleteIdentityProviderIfExists(issuerName);
                svc.SaveChangesBatch();

                // Import the identity provider from metadata.
                Console.WriteLine(String.Format("Importing metadata for issuer '{0}'...\n", issuerName));
                fileStream.Seek(0, SeekOrigin.Begin);
                svc.ImportIdentityProviderFromStream(fileStream);
            }
        }

        /// <summary>
        /// Replace the IdentityProvider signing keys with a new set of keys from a metadata update.
        /// </summary>
        static void UpdateIdentityProviderMetadata()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            Console.WriteLine(String.Format("Reading metadata from file '{0}'...\n", IDPMetadataForUpdate));
            using (FileStream fileStream = new FileStream(IDPMetadataForUpdate, FileMode.Open))
            {
                //
                // Note that this sample uses EntityID to correlate between the identity provider originally imported
                // and the identity provider to update.
                //
                EntityDescriptor metadata           = ReadMetadata(fileStream);
                List<X509Certificate2> idpKeys      = ExtractX509CertificatesFromMetadata<SecurityTokenServiceDescriptor>(metadata, KeyType.Signing);
                string issuerName                   = GetEntityName(metadata);
                IdentityProvider identityProvider   = svc.GetIdentityProviderByName(issuerName, true);

                Console.WriteLine(String.Format("Updating metadata for issuer '{0}'...\n", issuerName));

                //
                // For the sake of simplicity, the existing keys are simply deleted and new ones added.
                // Metadata contains more information such as endpoint addresses, claim types issued, etc.
                // Updating the remainder of these attributes is left as an exercise to the reader.
                //
                DeleteExistingIdentityProviderSigningKeys(svc, identityProvider);
                InsertIdentityProviderSigningKeysFromMetadata(svc, idpKeys, identityProvider);

                //
                // SaveChangesOptions.Batch guarantees a transaction across all operations prior to this call. This
                // is important because on a running service, the update must happen atomically or service calls may fail.
                //
                svc.SaveChangesBatch();
            }
        }

        /// <summary>
        /// Insert keys for an identity provider.
        /// </summary>
        /// <param name="svc">ManagementService instance.</param>
        /// <param name="idpKeys">List of keys to insert.</param>
        /// <param name="identityProvider">Identity Provider associated with the keys.</param>
        private static void InsertIdentityProviderSigningKeysFromMetadata(ManagementService svc, List<X509Certificate2> idpKeys, IdentityProvider identityProvider)
        {
            foreach(X509Certificate2 certificate in idpKeys)
            {
                IdentityProviderKey keyFromMetadata = new IdentityProviderKey()
                {
                    Usage = IdentityProviderKeyUsage.Signing.ToString(),
                    DisplayName = string.Format(CultureInfo.InvariantCulture, "{0} Signing Key", identityProvider.DisplayName),
                    //
                    // As a security best practice, set the start and end dates on the data entry
                    // to be the same value as the dates on the certificate.
                    //
                    StartDate = certificate.NotBefore.ToUniversalTime(),
                    EndDate = certificate.NotAfter.ToUniversalTime(),
                    Type = IdentityProviderKeyType.X509Certificate.ToString(),
                    Value = certificate.GetRawCertData()
                };

                Console.WriteLine(String.Format("Adding new identity provider key with subject: '{0}'.", GetSubjectFromCertificate(keyFromMetadata.Value)));
                svc.AddRelatedObject(identityProvider, "IdentityProviderKeys", keyFromMetadata);
            }
        }

        /// <summary>
        /// Delete existing identity provider signing keys.
        /// </summary>
        /// <param name="svc">ManagementService instance.</param>
        /// <param name="identityProvider">Identity Provider to delete keys for.</param>
        private static void DeleteExistingIdentityProviderSigningKeys(ManagementService svc, IdentityProvider identityProvider)
        {
            foreach (IdentityProviderKey existingKey in identityProvider.IdentityProviderKeys)
            {
                if (existingKey.Usage == IdentityProviderKeyUsage.Signing.ToString())
                {
                    Console.WriteLine(String.Format("Deleting existing identity provider key with subject: '{0}'.\n", GetSubjectFromCertificate(existingKey.Value)));
                    svc.DeleteObject(existingKey);
                }
            }
        }

        /// <summary>
        /// Import the relying party from metadata using a call to the management service.
        /// </summary>
        static void ImportRelyingPartyMetadata()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            Console.WriteLine(String.Format("Reading metadata from file '{0}'...\n", RPMetadataForImport));
            using (FileStream fileStream = new FileStream(RPMetadataForImport, FileMode.Open))
            {
                EntityDescriptor metadata = ReadMetadata(fileStream);
                string relyingPartyName = GetEntityName(metadata);
                svc.DeleteRelyingPartyByNameIfExists(relyingPartyName);
                svc.SaveChangesBatch();

                // Import the relying party from metadata.
                Console.WriteLine(String.Format("Importing metadata for relying party '{0}'...\n", relyingPartyName));
                fileStream.Seek(0, SeekOrigin.Begin);
                svc.ImportRelyingPartyFromStream(fileStream);
            }
        }

        /// <summary>
        /// Replace the RelyingParty encryption keys with a new set of keys from a metadata update.
        /// </summary>
        static void UpdateRelyingPartyMetadata()
        {
            ManagementService svc = ManagementServiceHelper.CreateManagementServiceClient();

            Console.WriteLine(String.Format("Reading metadata from file '{0}'...\n", RPMetadataForUpdate));
            using (FileStream fileStream = new FileStream(RPMetadataForUpdate, FileMode.Open))
            {
                //
                // Note that this sample uses EntityID to correlate between the relying party originally imported
                // and the relying party to update.
                //
                EntityDescriptor metadata       = ReadMetadata(fileStream);
                List<X509Certificate2> rpKeys   = ExtractX509CertificatesFromMetadata<ApplicationServiceDescriptor>(metadata, KeyType.Encryption);
                string relyingPartyName         = GetEntityName(metadata);
                RelyingParty relyingParty       = svc.GetRelyingPartyByName(relyingPartyName, true);

                Console.WriteLine(String.Format("Updating metadata for relying party '{0}'...\n", relyingPartyName));

                //
                // For the purposes of this sample, the existing keys are simply deleted and new ones added.
                // Metadata contains more information such as endpoint addresses.
                // Updating the remainder of these attributes is left as an exercise to the reader.
                //
                DeleteExistingRelyingPartyEncryptingKeys(svc, relyingParty);
                InsertRelyingPartyEncryptingKeysFromMetadata(svc, rpKeys, relyingParty);

                //
                // SaveChangesOptions.Batch guarantees a transaction across all operations prior to this call. This
                // is important because on a running service, the update must happen atomically or service calls may fail.
                //
                svc.SaveChangesBatch();
            }
        }

        /// <summary>
        /// Insert relying party encrypting keys.
        /// </summary>
        /// <param name="svc">Management service instance.</param>
        /// <param name="rpKeys">List of keys to insert.</param>
        /// <param name="relyingParty">Relying Party associated with the keys.</param>
        private static void InsertRelyingPartyEncryptingKeysFromMetadata(ManagementService svc, List<X509Certificate2> rpKeys, RelyingParty relyingParty)
        {
            foreach (X509Certificate2 certificate in rpKeys)
            {
                RelyingPartyKey keyFromMetadata = new RelyingPartyKey()
                {
                    Usage = RelyingPartyKeyUsage.Encrypting.ToString(),
                    DisplayName = string.Format(CultureInfo.InvariantCulture, "{0} Encrypting Key", relyingParty.Name),
                    //
                    // As a security best practice, set the start and end dates on the data entry
                    // to be the same value as the dates on the certificate.
                    //
                    StartDate = certificate.NotBefore.ToUniversalTime(),
                    EndDate = certificate.NotAfter.ToUniversalTime(),
                    Type = RelyingPartyKeyType.X509Certificate.ToString(),
                    Value = certificate.GetRawCertData()
                };

                Console.WriteLine(String.Format("Adding new relying party key with subject: '{0}'.\n", GetSubjectFromCertificate(keyFromMetadata.Value)));
                svc.AddRelatedObject(relyingParty, "RelyingPartyKeys", keyFromMetadata);
            }
        }

        /// <summary>
        /// Deletes existing relying party encrypting keys.
        /// </summary>
        /// <param name="svc">ManagementService instance.</param>
        /// <param name="relyingParty">Relying Party to delete keys from.</param>
        private static void DeleteExistingRelyingPartyEncryptingKeys(ManagementService svc, RelyingParty relyingParty)
        {
            foreach (RelyingPartyKey existingKey in relyingParty.RelyingPartyKeys)
            {
                if (existingKey.Usage == RelyingPartyKeyUsage.Encrypting.ToString())
                {
                    Console.WriteLine(String.Format("Deleting existing relying party key with subject: '{0}'.\n", GetSubjectFromCertificate(existingKey.Value)));
                    svc.DeleteObject(existingKey);
                }
            }
        }
    }
}
