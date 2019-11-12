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

namespace Microsoft.Samples.DPE.OAuth.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using Microsoft.IdentityModel.Claims;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Samples.DPE.OAuth.ProtectedResource;

    public class SimpleWebTokenHandler : StringTokenHandler
    {
        public const string Namespace = "http://simple.web.token/{0}";

        public const string IssuerLabel = "Issuer";
        public const string SignatureLabel = "HMACSHA256";
        public const string AudienceLabel = "Audience";
        public const string ExpiresOnLabel = "ExpiresOn";
        public const string SignatureAlgorithmLabel = "signatureAlgorithm";
        public const string SignatureAlgorithm = "HMAC";
        public const string IdLabel = "Id";

        private SecurityTokenResolver securityTokenResolver;
        private IssuerNameRegistry issuerNameRegistry;
        private AudienceRestriction audienceRestriction;

        public SimpleWebTokenHandler()
        {            
        }

        public SecurityTokenResolver SecurityTokenResolver
        {
            get
            {
                if (this.securityTokenResolver == null && this.Configuration != null && this.Configuration.IssuerTokenResolver != null)
                {
                    this.securityTokenResolver = this.Configuration.IssuerTokenResolver;
                }

                return this.securityTokenResolver;
            }

            set
            {
                this.securityTokenResolver = value;
            }
        }

        public IssuerNameRegistry IssuerNameRegistry
        {
            get
            {
                if (this.issuerNameRegistry == null && this.Configuration != null && this.Configuration.IssuerNameRegistry != null)
                {
                    this.issuerNameRegistry = this.Configuration.IssuerNameRegistry;
                }

                return this.issuerNameRegistry;
            }

            set
            {
                this.issuerNameRegistry = value;
            }
        }

        public AudienceRestriction AudienceRestriction
        {
            get
            {
                if (this.audienceRestriction == null && this.Configuration != null && this.Configuration.AudienceRestriction != null)
                {
                    this.audienceRestriction = this.Configuration.AudienceRestriction;
                }

                return this.audienceRestriction;
            }

            set
            {
                this.audienceRestriction = value;
            }
        }

        public override Type TokenType
        {
            get
            {
                return typeof(SimpleWebToken);
            }
        }

        public override bool CanValidateToken
        {
            get { return true; }
        }

        public override string GetTokenAsString(SecurityToken token)
        {
            SimpleWebToken swt = token as SimpleWebToken;
            if (swt == null)
            {
                throw new Exception("Incorrect token type. Expected SimpleWebToken");
            }

            if (this.SecurityTokenResolver == null)
            {
                throw new InvalidOperationException("SecurityTokenResolver is not configured");
            }

            var swtSigned = SerializeToken(swt, this.SecurityTokenResolver);
            return swtSigned;
        }
        
        public override SecurityToken GetTokenFromString(string token)
        {
            // TODO: validate                        
            var items = HttpUtility.ParseQueryString(token);
            var issuer = items[IssuerLabel];
            items.Remove(IssuerLabel);
            var audience = items[AudienceLabel];
            items.Remove(AudienceLabel);
            var expiresOn = items[ExpiresOnLabel];
            items.Remove(ExpiresOnLabel);
            var id = items[IdLabel];
            items.Remove(IdLabel);
            var algorithm = items[SignatureAlgorithmLabel];
            items.Remove(SignatureAlgorithmLabel);
            
            // Treat signature differently to avoid loosing characters like '+' in the decoding
            var signature = ExtractSignature(HttpUtility.UrlDecode(token));
            items.Remove(SignatureLabel);
            
            byte[] signatureBytes = Convert.FromBase64String(signature);
            DateTime validTo = this.GetDateTimeFromExpiresOn((ulong)Convert.ToInt64(expiresOn));

            var swt = new SimpleWebToken(issuer)
            {
                Audience = audience,
                Signature = signatureBytes,
                TokenValidity = validTo - DateTime.UtcNow
            };

            if (id != null)
            {
                swt.SetId(id);
            }

            if (string.IsNullOrEmpty(algorithm))
            {
                swt.SignatureAlgorithm = algorithm;
            }

            foreach (string key in items.AllKeys)
            {
                swt.AddClaim(key, items[key]);
            }

            swt.RawToken = token;

            return swt;
        }

        public override string[] GetTokenTypeIdentifiers()
        {
            return new string[] { "http://schemas.microsoft.com/2009/11/identitymodel/tokens/swt" };
        }

        public override ClaimsIdentityCollection ValidateToken(SecurityToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token is null");
            }

            if (this.SecurityTokenResolver == null)
            {
                throw new InvalidOperationException("SecurityTokenResolver is not configured");
            }

            if (this.IssuerNameRegistry == null)
            {
                throw new InvalidOperationException("IssuerNameRegistry is not configured");
            }

            if (this.AudienceRestriction == null)
            {
                throw new InvalidOperationException("AudienceRestriction is not configured");
            }

            SimpleWebToken accessToken = token as SimpleWebToken;
            if (accessToken == null)
            {
                throw new ArgumentNullException("This handler expects a SimpleWebToken");
            }

            var keyIdentifierClause = new DictionaryBasedKeyIdentifierClause(ToDictionary(accessToken));
            InMemorySymmetricSecurityKey securityKey;
            try
            {
                securityKey = (InMemorySymmetricSecurityKey)this.SecurityTokenResolver.ResolveSecurityKey(keyIdentifierClause);
            }
            catch (InvalidOperationException)
            {
                throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture, "Simmetryc key was not found for the key identifier clause: Keys='{0}', Values='{1}'", string.Join(",", keyIdentifierClause.Dictionary.Keys.ToArray()), string.Join(",", keyIdentifierClause.Dictionary.Values.ToArray())));
            }

            if (!this.IsValidSignature(accessToken, securityKey.GetSymmetricKey()))
            {
                throw new SecurityTokenValidationException("Signature is invalid");
            }            

            if (this.IsExpired(accessToken))
            {
                throw new SecurityTokenException(string.Format("Token has been expired for {0} seconds already", (DateTime.UtcNow - accessToken.ValidTo).TotalSeconds));
            }

            string issuerName;
            if (!this.IsIssuerTrusted(accessToken, out issuerName))
            {
                throw new SecurityTokenException(string.Format("The Issuer {0} is not trusted", accessToken.Issuer));
            }

            if (!this.IsAudienceTrusted(accessToken))
            {
                throw new SecurityTokenException(string.Format("The audience {0} of the token is not trusted", accessToken.Audience));
            }

            var identity = this.CreateClaimsIdentity(accessToken.Parameters, issuerName);
            return new ClaimsIdentityCollection(new IClaimsIdentity[] { identity });
        }

        protected static ulong GetExpiresOn(TimeSpan secondsFromNow)
        {
            DateTime expiresDate = DateTime.UtcNow + secondsFromNow;
            TimeSpan ts = expiresDate - new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return Convert.ToUInt64(ts.TotalSeconds);
        }

        protected static string GenerateSignature(string unsignedToken, byte[] signingKey)
        {
            using (HMACSHA256 hmac = new HMACSHA256(signingKey))
            {
                byte[] signatureBytes = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));
                string signature = HttpUtility.UrlEncode(Convert.ToBase64String(signatureBytes));

                return signature;
            }
        }

        protected static string SerializeToken(SimpleWebToken swt, SecurityTokenResolver tokenResolver)
        {
            StringBuilder builder = new StringBuilder(64);
            builder.Append("Id=");
            builder.Append(swt.Id);
            builder.Append('&');

            builder.Append(IssuerLabel);
            builder.Append('=');
            builder.Append(swt.Issuer);

            if (swt.Parameters.Count > 0)
            {
                builder.Append('&');
                foreach (string key in swt.Parameters.AllKeys)
                {
                    builder.Append(key);
                    builder.Append('=');
                    builder.Append(swt.Parameters[key]);
                    builder.Append('&');
                }
            }
            else
            {
                builder.Append('&');
            }

            builder.Append(ExpiresOnLabel);
            builder.Append('=');
            builder.Append(GetExpiresOn(swt.TokenValidity));

            if (!string.IsNullOrEmpty(swt.Audience))
            {
                builder.Append('&');
                builder.Append(AudienceLabel);
                builder.Append('=');
                builder.Append(swt.Audience);
            }

            builder.Append('&');
            builder.Append(SignatureAlgorithmLabel);
            builder.Append('=');
            builder.Append(SignatureAlgorithm);

            var keyIdentifierClause = new DictionaryBasedKeyIdentifierClause(ToDictionary(swt));
            InMemorySymmetricSecurityKey securityKey;
            try
            {
                securityKey = (InMemorySymmetricSecurityKey)tokenResolver.ResolveSecurityKey(keyIdentifierClause);
            }
            catch (InvalidOperationException)
            {
                throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture, "Simmetryc key was not found for the key identifier clause: Keys='{0}', Values='{1}'", string.Join(",", keyIdentifierClause.Dictionary.Keys.ToArray()), string.Join(",", keyIdentifierClause.Dictionary.Values.ToArray())));
            }

            string signature = GenerateSignature(builder.ToString(), securityKey.GetSymmetricKey());
            builder.Append("&" + SignatureLabel + "=");
            builder.Append(signature);

            return builder.ToString();
        }

        protected bool IsAudienceTrusted(SimpleWebToken accessToken)
        {
            if (this.AudienceRestriction.AudienceMode == AudienceUriMode.Never)
            {
                return true;
            }

            if (!string.IsNullOrEmpty(accessToken.Audience))
            {
                return this.AudienceRestriction.AllowedAudienceUris.Contains(new Uri(accessToken.Audience));
            }

            return false;
        }

        protected bool IsExpired(SimpleWebToken accessToken)
        {
            if (accessToken.ValidTo > DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }

        protected IClaimsIdentity CreateClaimsIdentity(NameValueCollection values, string issuer)
        {
            var identity = new ClaimsIdentity("SimpleWebToken");

            foreach (var key in values.AllKeys)
            {
                Uri claimType;
                bool validUri = Uri.TryCreate(key, UriKind.Absolute, out claimType);
                if (!validUri)
                {
                    claimType = new Uri(String.Format(Namespace, key));
                }

                var multivalues = values[key].Split(',');
                foreach (var value in multivalues)
                {
                    identity.Claims.Add(
                        new Claim(
                            claimType.ToString(),
                            value,
                            ClaimValueTypes.String,
                            issuer));
                }
            }

            return identity;
        }

        protected bool IsValidSignature(SimpleWebToken token, byte[] signingKey)
        {
            var unsignedToken = this.GetUnsignedToken(token.RawToken);
            if (string.IsNullOrEmpty(unsignedToken))
            {
                return false;
            }

            var localSignature = GenerateSignature(unsignedToken, signingKey);
            var incomingSignature = HttpUtility.UrlEncode(Convert.ToBase64String(token.Signature));

            return localSignature.Equals(incomingSignature, StringComparison.Ordinal);
        }        

        private static string ExtractSignature(string swtSigned)
        {
            var parts = swtSigned.Split(new string[] { string.Format("&{0}=", SignatureLabel) }, StringSplitOptions.None);
            var signature = Uri.UnescapeDataString(parts[1]);

            return signature;
        }

        private static IDictionary<string, string> ToDictionary(SimpleWebToken token)
        {
            var dictionary = new Dictionary<string, string>
            {
                { "Issuer", token.Issuer },
                { "Audience", token.Audience }                
            };

            return dictionary;
        }
        
        private DateTime GetDateTimeFromExpiresOn(ulong seconds)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var expiresOn = start.AddSeconds(seconds);

            return expiresOn;
        }

        private bool IsIssuerTrusted(SimpleWebToken accessToken, out string issuerName)
        {
            issuerName = null;
            if (!string.IsNullOrEmpty(accessToken.Issuer))
            {
                if (this.IssuerNameRegistry != null)
                {
                    issuerName = this.IssuerNameRegistry.GetIssuerName(accessToken);
                    if (!string.IsNullOrEmpty(issuerName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private string GetUnsignedToken(string swtSigned)
        {
            // Assume signature is at the end of token
            var signaturePosition = swtSigned.IndexOf(string.Format("&{0}=", SignatureLabel));
            if (signaturePosition <= 0)
            {
                return null;
            }

            var unsigned = swtSigned.Substring(0, signaturePosition);

            return unsigned;
        }        
    }
}