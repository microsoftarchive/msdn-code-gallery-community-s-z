// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace Microsoft.Samples.DPE.OAuth.Message
{
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.IO;
    using System.Xml;
    using Microsoft.IdentityModel.Claims;

    public class AssertionMessageHandler : OAuthMessageHandler
    {
        public AssertionMessageHandler()
            : base()
        {
        }

        public override bool CanValidateMessage(TokenRequestMessage message)
        {
            if (message.Type == RequestGrantType.Assertion)
            {
                return true;
            }

            return false;
        }

        public override NameValueCollection Validate(TokenRequestMessage message)
        {
            if (!this.CanValidateMessage(message))
            {
                throw new OAuthException(OAuthErrorCodes.UnsupportedGrantType, "This handler cannot validate this message.");
            }

            if (!message.Parameters[OAuthConstants.AssertionType].Equals("saml", StringComparison.OrdinalIgnoreCase))
            {
                throw new OAuthException(OAuthErrorCodes.InvalidRequest, string.Format("Assertion format '{0}' not supported. Only Saml Supported", message.Parameters[OAuthConstants.AssertionType]));
            }

            string assertion = message.Parameters[OAuthConstants.Assertion];
            if (assertion == null)
            {
                throw new OAuthException(OAuthErrorCodes.InvalidRequest, "Parameter 'assertion' is mandatory");
            }

            this.EnsureClientExists(message);

            SecurityToken token = null;
            SecurityToken xtoken = null;

            using (var stringReader = new StringReader(assertion))
            {
                var reader = XmlReader.Create(stringReader);
                if (!ServiceConfiguration.SecurityTokenHandlers.CanReadToken(reader))
                {
                    throw new OAuthException(OAuthErrorCodes.UnsupportedGrantType, "No Token handler defined can read this assertion");
                }

                // TODO: this should be changed to be in config
                // CHANGE: matias: read decryption cert from servicecertificate instead of hardcoding localhost
                using (var xprovider = new X509SecurityTokenProvider(ServiceConfiguration.ServiceCertificate))
                {
                    xtoken = xprovider.GetToken(new TimeSpan(10, 1, 1));
                }

                var outOfBandTokens = new Collection<SecurityToken>();
                outOfBandTokens.Add(xtoken);

                // CHANGED: matias, don't validate certificate (should be read from service config)
                ServiceConfiguration.CertificateValidator = X509CertificateValidator.None;

                // encryptedtoken handler is 6 . Add the X509TOken which has the key to decrypt this token
                ServiceConfiguration.SecurityTokenHandlers[6].Configuration.ServiceTokenResolver =
                    SecurityTokenResolver.CreateDefaultSecurityTokenResolver(new ReadOnlyCollection<SecurityToken>(outOfBandTokens), false);

                token = ServiceConfiguration.SecurityTokenHandlers.ReadToken(reader);
            }

            ClaimsIdentityCollection cc;
            try
            {
                cc = ServiceConfiguration.SecurityTokenHandlers.ValidateToken(token);
            }
            catch (SecurityTokenException ex)
            {
                throw new OAuthException(OAuthErrorCodes.InvalidGrant, ex.Message, ex);
            }

            // CHANGE: matias: add CAM in order to be able to tranform claims
            IClaimsPrincipal principal = new ClaimsPrincipal(cc);
            if (ServiceConfiguration.ClaimsAuthenticationManager != null)
            {
                principal = ServiceConfiguration.ClaimsAuthenticationManager.Authenticate("replace", principal);
            }

            var collection = new NameValueCollection();
            foreach (Claim claim in cc[0].Claims)
            {
                collection.Add(claim.ClaimType, claim.Value);
            }

            return collection;
        }
    }
}