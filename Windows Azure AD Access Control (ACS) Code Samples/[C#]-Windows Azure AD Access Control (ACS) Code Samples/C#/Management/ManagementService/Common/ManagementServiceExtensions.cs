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
    using System.Collections.Generic;
    using System.Data.Services.Client;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Common.ACS.Management;

    /// <summary>
    /// This class provides helper functions for common operations on the ACS Management Service.
    /// </summary>
    public static class ManagementServiceExtensions
    {
        /// <summary>
        /// Saves all changes in a single batch request. This wraps a transaction around
        /// all unsaved operations, allowing them to be committed atomically and rolled back
        /// if any of the operations fail.
        /// </summary>
        /// <param name="svc"></param>
        public static void SaveChangesBatch(this ManagementService svc)
        {
            svc.SaveChanges(SaveChangesOptions.Batch);
        }

        #region Identity provider extensions

        /// <summary>
        /// Import an identity provider from the given Federation Metadata URL
        /// </summary>
        /// <param name="metadataUrl"></param>
        public static void ImportIdentityProviderFromMetadataUrl(this ManagementService svc, Uri metadataUrl)
        {
            HttpWebRequest getRequest = (HttpWebRequest) WebRequest.Create(metadataUrl);
            getRequest.Method = "GET";
            HttpWebResponse getResponse = (HttpWebResponse) getRequest.GetResponse();

            using (Stream getStream = getResponse.GetResponseStream())
            {
                ImportIdentityProviderFromStream(svc, getStream, metadataUrl);
            }
        }

        /// <summary>
        /// Import an identity provider from a stream.
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="metadataStream">Stream containing the contents of the metadata.</param>
        public static void ImportIdentityProviderFromStream(this ManagementService svc, Stream metadataStream)
        {
            ImportIdentityProviderFromStream(svc, metadataStream, null);
        }

        /// <summary>
        /// Import an identity provider from a stream, specifying an optional metadata source.
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="metadataStream">Stream containing the contents of the metadata.</param>
        /// <param name="metadataSource">Optional: if metadata is from a URI, this will be recorded as an IdentityProviderAddress.</param>
        public static void ImportIdentityProviderFromStream(this ManagementService svc, Stream metadataStream, Uri metadataSource)
        {
            string metadataImportHead = "v2/mgmt/service/importFederationMetadata/importIdentityProvider";
            string metadataImporter = string.Format("https://{0}.{1}/{2}",
                SamplesConfiguration.ServiceNamespace,
                SamplesConfiguration.AcsHostUrl,
                metadataImportHead);

            HttpWebRequest postRequest = (HttpWebRequest)WebRequest.Create(metadataImporter);
            postRequest.Method = "POST";

            if (metadataSource != null)
            {
                postRequest.Headers["metadataUrl"] = metadataSource.OriginalString;
            }

            ExecuteMetadataImportOperation(postRequest, metadataStream);
        }

        /// <summary>
        /// Import a relying party from the given Federation Metadata URL.
        /// </summary>
        /// <param name="metadataUrl"></param>
        public static void ImportRelyingPartyFromMetadataUrl(this ManagementService svc, Uri metadataUrl)
        {
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(metadataUrl);
            getRequest.Method = "GET";
            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();

            using (Stream getStream = getResponse.GetResponseStream())
            {
                ImportRelyingPartyFromStream(svc, getStream);
            }
        }

        /// <summary>
        /// Import a relying party from a stream.
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="metadataStream">Stream containing the contents of the metadata.</param>
        public static void ImportRelyingPartyFromStream(this ManagementService svc, Stream metadataStream)
        {
            string metadataImportHead = "v2/mgmt/service/importFederationMetadata/importRelyingParty";
            string metadataImporter = string.Format("https://{0}.{1}/{2}",
                SamplesConfiguration.ServiceNamespace,
                SamplesConfiguration.AcsHostUrl,
                metadataImportHead);

            HttpWebRequest postRequest = (HttpWebRequest)WebRequest.Create(metadataImporter);
            postRequest.Method = "POST";

            ExecuteMetadataImportOperation(postRequest, metadataStream);
        }

        private static void ExecuteMetadataImportOperation(HttpWebRequest postRequest, Stream metadataStream)
        {
            ManagementServiceHelper.GetTokenWithWritePermission(postRequest);

            using (Stream postStream = postRequest.GetRequestStream())
            {
                int nextByte = metadataStream.ReadByte();
                while (nextByte != -1)
                {
                    postStream.WriteByte((byte)nextByte);
                    nextByte = metadataStream.ReadByte();
                }
            }

            HttpWebResponse resp = (HttpWebResponse)postRequest.GetResponse();
        }

        /// <summary>
        /// Create a WS-Federation identity provider with associated keys and addresses.
        /// </summary>
        public static IdentityProvider CreateWsFederationIdentityProvider(this ManagementService svc, string name, byte[] signingCertificateValue, DateTime keyStartDate, DateTime keyEndDate, string signInUrl)
        {
            Issuer issuer = new Issuer() { Name = name };
            svc.AddToIssuers(issuer);

            // 
            // Create the Identity Provider
            //
            IdentityProvider identityProvider = new IdentityProvider()
            {
                DisplayName = name,
                WebSSOProtocolType = IdentityProviderProtocolType.WsFederation.ToString(),
            };

            svc.AddObject("IdentityProviders", identityProvider);

            svc.SetLink(identityProvider, "Issuer", issuer);

            //
            // Create the Identity Provider key used to validate the signature of IDP-signed tokens.
            //

            IdentityProviderKey signingKey = new IdentityProviderKey()
            {
                DisplayName = "SampleIdentityProviderKeyDisplayName",
                Type = IdentityProviderKeyType.X509Certificate.ToString(),
                Usage = IdentityProviderKeyUsage.Signing.ToString(),
                Value = signingCertificateValue,
                StartDate = keyStartDate.ToUniversalTime(),
                EndDate = keyEndDate.ToUniversalTime()
            };

            svc.AddRelatedObject(identityProvider, "IdentityProviderKeys", signingKey);

            // Create the sign-in address for Identity Provider
            IdentityProviderAddress signInAddress = new IdentityProviderAddress()
            {
                Address = signInUrl,
                EndpointType = IdentityProviderEndpointType.SignIn.ToString(),
            };
            svc.AddRelatedObject(identityProvider, "IdentityProviderAddresses", signInAddress);

            identityProvider.Issuer = issuer;
            return identityProvider;
        }

        /// <summary>
        /// Create a Facebook identity provider with associated keys and permissions configured.
        /// </summary>
        /// <param name="applicationId">The Facebook Application ID</param>
        /// <param name="applicationSecret">The Facebook Application Secret</param>
        /// <param name="applicationPermissions">The permissions to request from Facebook</param>
        /// <returns></returns>
        public static IdentityProvider CreateFacebookIdentityProvider(this ManagementService svc, string applicationId, string applicationSecret, string applicationPermissions)
        {
            string name = String.Format(CultureInfo.InvariantCulture, "Facebook-{0}", applicationId);
            
            Issuer issuer = new Issuer() { Name = name };
            svc.AddToIssuers(issuer);

            // 
            // Create the Identity Provider
            //
            IdentityProvider identityProvider = new IdentityProvider()
            {
                DisplayName = name,
                LoginParameters = applicationPermissions,
                WebSSOProtocolType = IdentityProviderProtocolType.Facebook.ToString(),
            };

            svc.AddObject("IdentityProviders", identityProvider);
            svc.SetLink(identityProvider, "Issuer", issuer);

            //
            // Create the application Id and application secret keys for this facebook application.
            //
            IdentityProviderKey applicationIdKey = new IdentityProviderKey()
            {
                DisplayName = "Facebook application ID",
                Type = IdentityProviderKeyType.ApplicationKey.ToString(),
                Usage = IdentityProviderKeyUsage.ApplicationId.ToString(),
                Value = Encoding.UTF8.GetBytes(applicationId),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
            };

            svc.AddRelatedObject(identityProvider, "IdentityProviderKeys", applicationIdKey);

            IdentityProviderKey applicationSecretKey = new IdentityProviderKey()
            {
                DisplayName = "Facebook application Secret",
                Type = IdentityProviderKeyType.ApplicationKey.ToString(),
                Usage = IdentityProviderKeyUsage.ApplicationSecret.ToString(),
                Value = Encoding.UTF8.GetBytes(applicationSecret),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
            };

            svc.AddRelatedObject(identityProvider, "IdentityProviderKeys", applicationSecretKey);

            identityProvider.Issuer = issuer;
            return identityProvider;
        }

        /// <summary>
        /// Create an OpenID identity provider with the associated sign-in address
        /// </summary>
        /// <param name="name">The name of the issuer to create.</param>
        /// <param name="signInUrl">The post-discovery OpenID endpoint URL of the provider.</param>
        /// <returns>The created identity provider.</returns>
        public static IdentityProvider CreateOpenIdIdentityProvider(this ManagementService svc, string name, string signInUrl)
        {
            Issuer issuer = new Issuer() { Name = name };
            svc.AddToIssuers(issuer);

            // 
            // Create the Identity Provider
            //
            IdentityProvider identityProvider = new IdentityProvider()
            {
                DisplayName = name,
                WebSSOProtocolType = IdentityProviderProtocolType.OpenId.ToString(),
            };

            svc.AddObject("IdentityProviders", identityProvider);

            svc.SetLink(identityProvider, "Issuer", issuer);

            //
            // Create the sign-in address for Identity Provider
            //
            IdentityProviderAddress signInAddress = new IdentityProviderAddress()
            {
                Address = signInUrl,
                EndpointType = IdentityProviderEndpointType.SignIn.ToString(),
            };
            svc.AddRelatedObject(identityProvider, "IdentityProviderAddresses", signInAddress);

            identityProvider.Issuer = issuer;
            return identityProvider;
        }

        /// <summary>
        /// Associate the given identity provider with all relying parties.
        /// </summary>
        /// <param name="identityProviders">The identity providers to associate.</param>
        /// <param name="relyingParties">The relying parties to associate with</param>
        public static void AssociateIdentityProvidersWithRelyingParties(this ManagementService svc, IEnumerable<IdentityProvider> identityProviders, IEnumerable<RelyingParty> relyingParties)
        {
            foreach (RelyingParty rp in relyingParties)
            {
                foreach (IdentityProvider identityProvider in identityProviders)
                {
                    RelyingPartyIdentityProvider rpIdp = new RelyingPartyIdentityProvider();

                    svc.AddToRelyingPartyIdentityProviders(rpIdp);

                    svc.SetLink(rpIdp, "IdentityProvider", identityProvider);
                    svc.SetLink(rpIdp, "RelyingParty", rp);
                }
            }
        }

        /// <summary>
        /// Finds an <see cref="Issuer"/> with the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="Issuer"/>.</param>
        /// <returns>Returns the <see cref="Issuer"/> if found else returns null.</returns>
        public static Issuer GetIssuerByName(this ManagementService svc, string name)
        {
            Issuer issuer = svc.Issuers.Where(m => m.Name == name).FirstOrDefault();

            return issuer;
        }

        /// <summary>
        /// Finds an <see cref="IdentityProvider"/> with the given name. Keys and addresses are not retrieved.
        /// </summary>
        /// <param name="name">The name of the <see cref="IdentityProvider"/>.</param>
        /// <returns>Returns the <see cref=" IdentityProvider"/> if found else returns null.</returns>
        public static IdentityProvider GetIdentityProviderByName(this ManagementService svc, string name)
        {
            return svc.GetIdentityProviderByName(name, false);
        }

        /// <summary>
        /// Finds an <see cref="IdentityProvider"/> with the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="IdentityProvider"/>.</param>
        /// <param name="expandAddressesAndKeys">If true, the IdentityProviderKeys and IdentityProviderAddresses collections will also be expanded and returned.</param>
        /// <returns>Returns the <see cref=" IdentityProvider"/> if found else returns null.</returns>
        public static IdentityProvider GetIdentityProviderByName(this ManagementService svc, string name, bool expandAddressesAndKeys)
        {
            if (expandAddressesAndKeys)
            {
                return svc.IdentityProviders.Expand("IdentityProviderKeys,IdentityProviderAddresses,Issuer").Where(m => m.Issuer != null && m.Issuer.Name == name).FirstOrDefault();
            }
            else
            {
                return svc.IdentityProviders.Expand("Issuer").Where(m => m.Issuer != null && m.Issuer.Name == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// Deletes an <see cref="Issuer"/> having the given name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Issuer"/> to delete.</param>
        public static void DeleteIssuerIfExists(this ManagementService svc, string name)
        {
            // Retrieve issuer and delete it if it exists.
            Issuer issuer = svc.Issuers.Where(m => m.Name == name).FirstOrDefault();
            if (issuer != null)
            {
                svc.DeleteObject(issuer);
            }
        }

        /// <summary>
        /// If an issuer with this name exists, delete the issuer and the associated identity provider.
        /// </summary>
        public static void DeleteIdentityProviderIfExists(this ManagementService svc, string name)
        {
            //
            // Deleting the issuer will also cause the identity provider and its associated objects to be deleted.
            //
            svc.DeleteIssuerIfExists(name);
        }

        /// <summary>
        /// Gets the list of claim types for an identity provider
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="identityProvider">Indentity Provider with claim types</param>
        /// <returns>List of claim types</returns>
        public static IEnumerable<string> GetIdentityProviderClaimTypes(this ManagementService svc, IdentityProvider identityProvider)
        {
            List<IdentityProviderClaimType> idpClaimTypes = svc.IdentityProviderClaimTypes.Expand("ClaimType")
                .Where(ct => ct.IdentityProviderId == identityProvider.Id)
                .ToList();

            return idpClaimTypes.Select(ct => ct.ClaimType.Uri);
        }

        #endregion

        #region Relying Party extensions

        /// <summary>
        /// Creates  a new <see cref=" RelyingParty"/>.
        /// </summary>
        /// <param name="name">Name of this new <see cref=" RelyingParty"/>.</param>
        /// <param name="realm">Realm of the relying party.</param>
        /// <param name="reply">ReplyTo address for the relying party. May be null.</param>
        /// <param name="tokenType">The type of token that the relying party consumes.</param>
        /// <param name="requireEncryption">Whether to require asymmetric token encryption.</param>
        /// <returns>The new <see cref=" RelyingParty"/> created.</returns>
        public static RelyingParty CreateRelyingParty(this ManagementService svc, string name, string realm, string reply, RelyingPartyTokenType tokenType, bool requireEncryption)
        {
            svc.DeleteRelyingPartyByRealmIfExists(realm);

            RelyingParty relyingParty = new RelyingParty()
            {
                AsymmetricTokenEncryptionRequired = requireEncryption,
                Name = name,
                TokenType = tokenType.ToString(),
                TokenLifetime = 3600,
            };

            svc.AddToRelyingParties(relyingParty);

            //
            // Create the Realm address
            //
            RelyingPartyAddress realmAddress = new RelyingPartyAddress()
            {
                Address = realm,
                EndpointType = RelyingPartyAddressType.Realm.ToString(),
            };

            svc.AddRelatedObject(relyingParty, "RelyingPartyAddresses", realmAddress);

            if (!string.IsNullOrEmpty(reply))
            {
                //
                // Create the ReplyTo address
                //
                RelyingPartyAddress replyAddress = new RelyingPartyAddress()
                {
                    Address = reply,
                    EndpointType = RelyingPartyAddressType.Reply.ToString(),
                };

                svc.AddRelatedObject(relyingParty, "RelyingPartyAddresses", replyAddress);
            }

            return relyingParty;
        }

        /// <summary>
        /// Create a RelyingPartyKey with the given value, type, and usage, and associate it with the given relying party.
        /// </summary>
        public static RelyingPartyKey CreateRelyingPartyKey(this ManagementService svc, RelyingParty relyingParty, byte[] keyValue, string password, RelyingPartyKeyType keyType, RelyingPartyKeyUsage keyUsage, bool isPrimary)
        {
            DateTime startDate, endDate;


            if (keyType == RelyingPartyKeyType.X509Certificate)
            {
                //
                // ACS requires that the key start and end dates be within the certificate's validity period.
                //
                X509Certificate2 cert = new X509Certificate2(keyValue, password);

                startDate = cert.NotBefore.ToUniversalTime();
                endDate = cert.NotAfter.ToUniversalTime();
            }
            else
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.MaxValue;
            }

            RelyingPartyKey relyingPartyKey = new RelyingPartyKey()
            {
                DisplayName = String.Format(CultureInfo.InvariantCulture, "Default {0} key for {1}", keyType, relyingParty.Name),
                EndDate = endDate,
                IsPrimary = isPrimary,
                Password = string.IsNullOrEmpty(password) ? null : Encoding.UTF8.GetBytes(password),
                StartDate = startDate,
                Type = keyType.ToString(),
                Usage = keyUsage.ToString(),
                Value = keyValue,
            };

            svc.AddRelatedObject(relyingParty, "RelyingPartyKeys", relyingPartyKey);

            return relyingPartyKey;
        }

        /// <summary>
        /// Generate a symmetric RelyingPartyKey and associcate it with the given relying party.
        /// </summary>
        public static RelyingPartyKey GenerateRelyingPartySymmetricKey(this ManagementService svc, RelyingParty relyingParty, DateTime startDate, DateTime endDate, bool isPrimary)
        {
            //
            // Symmetric keys used by ACS are 256-bits, which equals 32 bytes.
            //
            byte[] keyValue = new byte[32];
            new RNGCryptoServiceProvider().GetBytes(keyValue);

            RelyingPartyKey relyingPartyKey = new RelyingPartyKey()
            {
                DisplayName = String.Format(CultureInfo.InvariantCulture, "Default signing key for {0}", relyingParty.Name),
                EndDate = endDate.ToUniversalTime(),
                IsPrimary = isPrimary,
                StartDate = startDate.ToUniversalTime(),
                Type = RelyingPartyKeyType.Symmetric.ToString(),
                Usage = RelyingPartyKeyUsage.Signing.ToString(),
                Value = keyValue
            };

            svc.AddRelatedObject(relyingParty, "RelyingPartyKeys", relyingPartyKey);

            return relyingPartyKey;
        }

        /// <summary>
        /// Returns a RelyingParty with the given name. Associated keys and addresses are not returned. 
        /// If the relying party does not exist, returns null.
        /// </summary>
        public static RelyingParty GetRelyingPartyByName(this ManagementService svc, string name)
        {
            return svc.GetRelyingPartyByName(name, false);
        }

        /// <summary>
        /// Returns a RelyingParty with the given name. If the relying party does not exist, returns null.
        /// </summary>
        /// <param name="name">The name of the RelyingParty.</param>
        /// <param name="expandKeysAndAddresses">Whether the RelyingPartyKey and RelyingPartyAddress collections should be expanded and returned.</param>
        public static RelyingParty GetRelyingPartyByName(this ManagementService svc, string name, bool expandKeysAndAddresses)
        {
            if (expandKeysAndAddresses)
            {
                return svc.RelyingParties.Expand("RelyingPartyKeys,RelyingPartyAddresses").Where(m => m.Name == name).FirstOrDefault();
            }
            else
            {
                return svc.RelyingParties.Where(m => m.Name == name).FirstOrDefault();
            }
        }

        /// <summary>
        /// Deletes a RelyingParty having the given name, if it exists.
        /// </summary>
        public static void DeleteRelyingPartyByNameIfExists(this ManagementService svc, string name)
        {
            // Retrieve Relying Party and then delete it if it exists.
            RelyingParty relyingParty = svc.RelyingParties.Where(m => m.Name == name).FirstOrDefault();
            if (relyingParty != null)
            {
                svc.DeleteObject(relyingParty);
            }
        }

        /// <summary>
        /// Deletes a RelyingParty having the given name, if it exists.
        /// </summary>
        public static void DeleteRelyingPartyByRealmIfExists(this ManagementService svc, string realm)
        {
            // Retrieve Relying Party and then delete it if it exists.
            RelyingPartyAddress rpAddress = svc.RelyingPartyAddresses.Expand("RelyingParty").Where(addr => addr.Address == realm && addr.EndpointType == RelyingPartyAddressType.Realm.ToString()).FirstOrDefault();

            if (rpAddress != null)
            {
                svc.DeleteObject(rpAddress.RelyingParty);
            }
        }

        /// <summary>
        /// Gets the Identity Providers which are associated with the <paramref name="relyingParty"/>
        /// </summary>
        /// <param name="relyingParty"></param>
        /// <returns>List of IdentityProviders</returns>
        public static IEnumerable<IdentityProvider> GetRelyingPartyIdentityProviders(this ManagementService svc,
            RelyingParty relyingParty)
        {
            List<RelyingPartyIdentityProvider> rpIdps = svc.RelyingPartyIdentityProviders
                .Expand("IdentityProvider,IdentityProvider/Issuer")
                .Where(a => a.RelyingPartyId == relyingParty.Id).ToList();

            return rpIdps.Select(rpIdp => rpIdp.IdentityProvider);
        }


        #endregion

        #region Service Identity extensions

        /// <summary>
        /// Creates  a new ServiceIdentity and an associated key of the value, type, and usage specified.
        /// </summary>
        public static ServiceIdentity CreateServiceIdentity(this ManagementService svc, string name, byte[] keyValue, ServiceIdentityKeyType keyType, ServiceIdentityKeyUsage keyUsage)
        {
            ServiceIdentity sid = new ServiceIdentity()
            {
                Name = name
            };

            DateTime startDate, endDate;

            if (keyType == ServiceIdentityKeyType.X509Certificate)
            {
                //
                // ACS requires that the key start and end dates be within the certificate's validity period.
                //
                X509Certificate2 cert = new X509Certificate2(keyValue);

                startDate = cert.NotBefore.ToUniversalTime();
                endDate = cert.NotAfter.ToUniversalTime();
            }
            else
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.MaxValue;
            }

            ServiceIdentityKey key = new ServiceIdentityKey()
            {
                EndDate = endDate.ToUniversalTime(),
                StartDate = startDate.ToUniversalTime(),
                Type = keyType.ToString(),
                Usage = keyUsage.ToString(),
                Value = keyValue,
                DisplayName = String.Format(CultureInfo.InvariantCulture, "{0} key for {1}", keyType.ToString(), name)
            };

            svc.AddToServiceIdentities(sid);
            svc.AddRelatedObject(
                sid,
                "ServiceIdentityKeys",
                key);

            return sid;
        }

        /// <summary>
        /// Finds a ServiceIdentity with the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref=" ServiceIdentity"/>.</param>
        /// <returns>Returns the <see cref=" ServiceIdentity"/> if found else returns null.</returns>
        public static ServiceIdentity GetServiceIdentityByName(this ManagementService svc, string name)
        {
            ServiceIdentity identity = svc.ServiceIdentities.Expand("ServiceIdentityKeys").Where(sk => sk.Name == name).FirstOrDefault();

            return identity;
        }

        /// <summary>
        /// Update the service identity key value.
        /// </summary>
        /// <param name="name">Name of the <see cref="ServiceIdentityKey"/>.</param>
        /// <param name="keyValue">The new key value.</param>
        /// <param name="keyType">The new Key type.</param>
        public static void UpdateServiceIdentityKey(this ManagementService svc, string name, byte[] keyValue, string keyType)
        {
            ServiceIdentity serviceIdentity = svc.GetServiceIdentityByName(name);

            if (serviceIdentity != null)
            {
                foreach (ServiceIdentityKey key in serviceIdentity.ServiceIdentityKeys)
                {
                    if (key.Type == keyType)
                    {
                        key.Value = keyValue;
                        svc.UpdateObject(key);
                    }
                }
            }
        }

        /// <summary>
        /// Delete service identity by name if it exists - child objects, keys in this case, are automatically deleted. 
        /// </summary>
        /// <param name="name">The name of the <see cref="ServiceIdentity"/> to delete.</param>
        public static void DeleteServiceIdentityIfExists(this ManagementService svc, string name)
        {
            IQueryable<ServiceIdentity> serviceIdentities = svc.ServiceIdentities.Where(si => si.Name == name);

            foreach (ServiceIdentity si in serviceIdentities)
            {
                svc.DeleteObject(si);
            }
        }

        #endregion

        #region RuleGroup extensions

        /// <summary>
        /// Creates a rule group with the given name.
        /// </summary>
        public static RuleGroup CreateRuleGroup(this ManagementService svc, string name)
        {
            svc.DeleteRuleGroupByNameIfExists(name);

            RuleGroup ruleGroup = new RuleGroup()
            {
                Name = name
            };

            svc.AddToRuleGroups(ruleGroup);

            return ruleGroup;
        }

        /// <summary>
        /// Creates a rule and adds it to the given RuleGroup.
        /// </summary>
        /// <param name="issuer">The input issuer for which to apply the rule.</param>
        /// <param name="inputClaimType">The input claim type. Null for "all claim types".</param>
        /// <param name="inputClaimValue">The input claim value. Null for "all claim values".</param>
        /// <param name="outputClaimType">The output claim type. Null for "pass through input type".</param>
        /// <param name="outputClaimValue">The output claim value. Null for "pass through input value".</param>
        /// <param name="ruleGroup">The rule group to which the rule should be added.</param>
        /// <param name="description">Optional human-readable rule description.</param>
        /// <returns></returns>
        public static Rule CreateRule(this ManagementService svc, Issuer issuer, string inputClaimType, string inputClaimValue,
                                      string outputClaimType, string outputClaimValue, RuleGroup ruleGroup, string description)
        {
            Rule rule = new Rule()
            {
                Description = description,
                InputClaimType = inputClaimType,
                InputClaimValue = inputClaimValue,
                OutputClaimType = outputClaimType,
                OutputClaimValue = outputClaimValue,
            };

            svc.AddToRules(rule);
            svc.SetLink(rule, "Issuer", issuer);
            svc.SetLink(rule, "RuleGroup", ruleGroup);
            
            return rule;
        }

        /// <summary>
        /// Generates under the <paramref name="ruleGroup"/> passthrough rules for the <paramref name="identityProders"/> claim types
        /// </summary>
        /// <remarks>
        /// The <paramref name="identityProviders"/> should have Issuer expanded.
        /// </remarks>
        /// <param name="svc"></param>
        /// <param name="ruleGroup">Rule group to add the rules</param>
        /// <param name="identityProviders">Identity Provides which provide the claim types</param>
        public static void GenerateRules(this ManagementService svc, RuleGroup ruleGroup, IEnumerable<IdentityProvider> identityProviders)
        {
            foreach (IdentityProvider identityProvider in identityProviders)
            {
                IEnumerable<string> claimTypes = svc.GetIdentityProviderClaimTypes(identityProvider);

                // For each claim type generate a passthrough rule
                foreach (string claimType in claimTypes)
                {
                    Rule rule = new Rule()
                    {
                        InputClaimType = claimType,
                    };

                    rule.Description = string.Format(CultureInfo.InvariantCulture,
                        "Passthrough claim from {0} with type: {1}, and any value",
                        identityProvider.DisplayName,
                        claimType);

                    svc.AddToRules(rule);
                    svc.SetLink(rule, "Issuer", identityProvider.Issuer);
                    svc.SetLink(rule, "RuleGroup", ruleGroup);
                }
            }
        }

        /// <summary>
        /// Copies the <paramref name="source"/> into a new rule group with name <paramref name="newRuleGroupName"/>
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="source">Source rule group</param>
        /// <param name="newRuleGroupName">Name of the new rule group</param>
        public static void CopyRuleGroup(this ManagementService svc, RuleGroup source, string newRuleGroupName)
        {
            RuleGroup newRuleGroup = new RuleGroup()
            {
                Name = newRuleGroupName,
            };

            svc.AddToRuleGroups(newRuleGroup);

            foreach (Rule rule in svc.Rules.Expand("Issuer").Where(r => r.RuleGroupId == source.Id))
            {
                Rule newRule = new Rule();
 
                newRule.Description = rule.Description;
                newRule.InputClaimType = rule.InputClaimType;
                newRule.InputClaimValue = rule.InputClaimValue;
                newRule.OutputClaimType = rule.OutputClaimType;
                newRule.OutputClaimValue = rule.OutputClaimValue;

                svc.AddToRules(newRule);
                svc.SetLink(newRule, "Issuer", rule.Issuer);
                svc.SetLink(newRule, "RuleGroup", newRuleGroup);
            }
        }

        /// <summary>
        /// Assigns the <paramref name="ruleGroup"/> to the <paramref name="relyingParty"/>
        /// </summary>
        /// <param name="svc"></param>
        /// <param name="ruleGroup">Relying party</param>
        /// <param name="relyingParty">Rule group</param>
        public static void AssignRuleGroupToRelyingParty(this ManagementService svc, RuleGroup ruleGroup, RelyingParty relyingParty)
        {
            RelyingPartyRuleGroup relyingPartyRuleGroup = new RelyingPartyRuleGroup();

            svc.AddToRelyingPartyRuleGroups(relyingPartyRuleGroup);
            svc.AddLink(relyingParty, "RelyingPartyRuleGroups", relyingPartyRuleGroup);
            svc.AddLink(ruleGroup, "RelyingPartyRuleGroups", relyingPartyRuleGroup);
        }

        /// <summary>
        /// Deletes a RuleGroup having the given name, if it exists.
        /// </summary>
        public static void DeleteRuleGroupByNameIfExists(this ManagementService svc, string name)
        {
            // Retrieve a Rule Group and then delete it if it exists.
            RuleGroup ruleGroup = svc.RuleGroups.Where(m => m.Name == name).FirstOrDefault();
            if (ruleGroup != null)
            {
                svc.DeleteObject(ruleGroup);
            }
        }

        #endregion

        #region ServiceKey extensions

        /// <summary>
        /// Gets Service Keys which are used for decrypting tokens sent from Identity Providers to ACS 
        /// </summary>
        public static IQueryable<ServiceKey> GetIdentityProviderDecryptionKeys(this ManagementService svc)
        {
            return svc.ServiceKeys.Where(k => k.Usage == ServiceKeyUsage.Encrypting.ToString() && k.Type == ServiceKeyType.X509Certificate.ToString());
        }


        /// <summary>
        /// Creates Service Key which will be used for decryption tokens sent from Identity Providers to ACS
        /// </summary>
        public static ServiceKey CreateIdentityProviderDecryptionKey(this ManagementService svc, string displayName, byte[] keyValue, string password, bool isPrimary)
        {
            X509Certificate2 cert = new X509Certificate2(keyValue, password);
            ServiceKey key = new ServiceKey
            {
                DisplayName = displayName,
                EndDate = cert.NotAfter.ToUniversalTime(),
                IsPrimary = isPrimary,
                Password = Encoding.UTF8.GetBytes(password),
                StartDate = cert.NotBefore.ToUniversalTime(),
                Type = ServiceKeyType.X509Certificate.ToString(),
                Usage = ServiceKeyUsage.Encrypting.ToString(),
                Value = keyValue
            };

            svc.AddToServiceKeys(key);

            return key;
        }
        #endregion
    }
}

