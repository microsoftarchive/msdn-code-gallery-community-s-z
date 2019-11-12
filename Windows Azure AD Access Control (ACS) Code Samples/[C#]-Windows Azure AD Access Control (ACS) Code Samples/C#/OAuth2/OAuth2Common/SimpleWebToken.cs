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
using System.Globalization;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Claims;

namespace OAuth2Common
{
    public class SimpleWebToken
    {
        /// <summary>
        /// Factory constructor - creates a SimpleWebToken by parsing the form-encoded
        /// string representation of the token.
        /// </summary>
        public static SimpleWebToken FromString(string encodedToken)
        {
            if (string.IsNullOrEmpty(encodedToken))
                throw new ArgumentNullException("encodedToken");

            SimpleWebToken token = new SimpleWebToken();

            token.Decode(encodedToken);

            return token;
        }

        string      _audience;
        List<Claim> _claims;
        string      _issuer;
        DateTime    _expiresOn;

        string      _signature;
        string      _unsignedString;

        /// <summary>
        /// Default constructor, used by the FromString factory method.
        /// </summary>
        SimpleWebToken()
        {
        }

        /// <summary>
        /// Constructor. Creates a SimpleWebToken with an issuer an audience, and an unlimited
        /// lifetime and no claims.
        /// </summary>
        public SimpleWebToken(string issuer, string audience)
            : this(issuer, audience, DateTime.MaxValue)
        {
        }

        /// <summary>
        /// Constructor. Creates a SimpleWebToken with an issuer, an all-applicable audience, an unlimited
        /// lifetime with the specified claims. ACS would skip audience validation if it is null.
        /// </summary>
        public SimpleWebToken(string issuer, IEnumerable<Claim> claims)
            : this(issuer, null, DateTime.MaxValue, claims)
        {
        }

        /// <summary>
        /// Constructor. Creates a SimpleWebToken with an issuer, an audience, an unlimited
        /// lifetime with the specified claims.
        /// </summary>
        public SimpleWebToken(string issuer, string audience, IEnumerable<Claim> claims)
            : this(issuer, audience, DateTime.MaxValue, claims)
        {
        }

        public SimpleWebToken(string issuer, string audience, DateTime expires)
            : this(issuer, audience, expires, null)
        {
        }

        public SimpleWebToken(string issuer, string audience, DateTime expires, IEnumerable<Claim> claims)
        {
            if (string.IsNullOrEmpty(issuer))
                throw new ArgumentNullException("issuer");

            _audience = audience;
            _expiresOn = expires;
            _issuer = issuer;
            _claims = new List<Claim>();

            if (claims != null)
            {
                foreach (Claim claim in claims)
                {
                    if (IsReservedClaimType(claim.ClaimType))
                        throw new ArgumentException("ClaimType " + claim.ClaimType + " is reserved for system use");

                    _claims.Add(claim);
                }
            }
        }

        /// <summary>
        /// The Audience for the token.
        /// </summary>
        public string Audience
        {
            get { return _audience; }
        }

        /// <summary>
        /// The Claims in the token.
        /// </summary>
        public IEnumerable<Claim> Claims
        {
            get { return _claims; }
        }

        /// <summary>
        /// The expiry datetime for the token.
        /// </summary>
        public DateTime ExpiresOn
        {
            get { return _expiresOn; }
        }

        /// <summary>
        /// Used to determine whether the parameter claim type is one of the reserved
        /// SimpleWebToken claim types: Audience, HMACSHA256, ExpiresOn or Issuer.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        protected virtual bool IsReservedClaimType(string claimType)
        {
            if (string.Compare(claimType, SimpleWebTokenConstants.TokenAudience, true) == 0)
                return true;

            if (string.Compare(claimType, SimpleWebTokenConstants.TokenDigest256, true) == 0)
                return true;

            if (string.Compare(claimType, SimpleWebTokenConstants.TokenExpiresOn, true) == 0)
                return true;

            if (string.Compare(claimType, SimpleWebTokenConstants.TokenIssuer, true) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// The issuer of the token.
        /// </summary>
        public string Issuer
        {
            get { return _issuer; }
        }

        /// <summary>
        /// The signature value of the token.
        /// </summary>
        public string Signature
        {
            get { return _signature; }
        }

        /// <summary>
        /// Parses a SWT token string.
        /// </summary>
        /// <param name="rawToken"></param>
        /// <returns></returns>
        protected virtual void Decode(string rawToken)
        {
            string audience = null, issuer = null, signature = null, unsignedString = null, expires = null;
            //
            // Find the last parameter. The signature must be last per SWT specification.
            //
            int lastSeparator = rawToken.LastIndexOf(SimpleWebTokenConstants.ParameterSeparator);
            //
            // Check whether the last parameter is an hmac.
            //
            if (lastSeparator > 0)
            {
                string lastParamStart = SimpleWebTokenConstants.ParameterSeparator + SimpleWebTokenConstants.TokenDigest256 + "=";
                string lastParam = rawToken.Substring(lastSeparator);
                //
                // Strip the trailing hmac to obtain the original unsigned string for later hmac verification.
                // e.g. name1=value1&name2=value2&HMACSHA256=XXX123 -> name1=value1&name2=value2
                //
                if (lastParam.StartsWith(lastParamStart, StringComparison.Ordinal))
                {
                    unsignedString = rawToken.Substring(0, lastSeparator);
                }
            }
            else if (lastSeparator < 0)
            {
                //
                // If there's no separator, then the last parameter is also the first parameter.
                //
                string lastParamStart = SimpleWebTokenConstants.TokenDigest256 + "=";

                if (rawToken.StartsWith(lastParamStart, StringComparison.Ordinal))
                {
                    //
                    // Strip everything, since there is nothing other than the hmac.
                    //
                    unsignedString = string.Empty;
                }
            }
            else
            {
                //
                // lastSeparator == 0 would mean the token begins with '&', which is invalid syntax
                //
                throw new InvalidDataException();
            }
            //
            // Signature is a mandatory parameter, and it must be the last one.
            // If there's no trailing hmac, Return error.
            //
            if (unsignedString == null)
            {
                throw new InvalidOperationException("Invalid SWT token. HMAC signature is misplaced.");
            }

            //
            // Create a dictionary of SWT claims, checking for duplicates.
            //
            Dictionary<string, string> inputDictionary = new Dictionary<string, string>(StringComparer.Ordinal);

            inputDictionary.Decode(rawToken);

            // TokenAudience is optional.
            if (inputDictionary.TryGetValue(SimpleWebTokenConstants.TokenAudience, out audience))
            {
                inputDictionary.Remove(SimpleWebTokenConstants.TokenAudience);
            }

            // TokenExpiresOn is optional.
            if (inputDictionary.TryGetValue(SimpleWebTokenConstants.TokenExpiresOn, out expires))
            {
                inputDictionary.Remove(SimpleWebTokenConstants.TokenExpiresOn);
            }

            if (inputDictionary.TryGetValue(SimpleWebTokenConstants.TokenIssuer, out issuer))
            {
                inputDictionary.Remove(SimpleWebTokenConstants.TokenIssuer);
            }
            else
            {
                throw new InvalidDataException();
            }


            if (inputDictionary.TryGetValue(SimpleWebTokenConstants.TokenDigest256, out signature))
            {
                inputDictionary.Remove(SimpleWebTokenConstants.TokenDigest256);
            }
            else
            {
                throw new InvalidDataException();
            }

            //
            // Audience, ExpiresOn, and Issuer should have been removed from the dictionary by now.
            // Ensure they are not present in any duplicate or alternate casing.
            //
            CheckForReservedClaimType(inputDictionary, SimpleWebTokenConstants.TokenAudience);
            CheckForReservedClaimType(inputDictionary, SimpleWebTokenConstants.TokenExpiresOn);
            CheckForReservedClaimType(inputDictionary, SimpleWebTokenConstants.TokenIssuer);

            List<Claim> claims = DecodeClaims(issuer, inputDictionary, SimpleWebTokenConstants.DefaultCompoundClaimDelimiter);

            _audience = audience;
            _claims = claims;
            _expiresOn = DecodeExpiry(expires);
            _issuer = issuer;
            _signature = signature;
            _unsignedString = unsignedString;
        }

        /// <summary>
        /// Enforces casing requirements on reserved claim types. If the claim type is present in any casing, an exception is thrown.
        /// </summary>
        /// <remarks>
        /// This function MUST be called after the reserved claim type has been checked and removed (if present).
        /// </remarks>
        private void CheckForReservedClaimType(Dictionary<string, string> inputDictionary, string claimType)
        {
            if (inputDictionary.Keys.Contains(claimType, StringComparer.OrdinalIgnoreCase))
            {
                string exceptionMessage = String.Format(CultureInfo.InvariantCulture,
                                                         "Invalid SWT token. The parameter name '{0}' is reserved and cannot be used in any other casing.",
                                                         claimType);

                throw new SecurityTokenValidationException(exceptionMessage);
            }
        }

        /// <summary>
        /// A=B,C,D should result in the claims A=B, A=C, and A=D.
        /// Duplicate values are allowed. Empty strings are not allowed.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        protected List<Claim> DecodeClaims(string issuer, IDictionary<string, string> claims, char delimiter)
        {
            List<Claim> decodedClaims = new List<Claim>();

            foreach (KeyValuePair<string, string> claim in claims)
            {
                if (string.IsNullOrEmpty(claim.Value))
                {
                    throw new SecurityTokenException("Invalid SWT token. All claims must have a value.");
                }

                if (claim.Value.IndexOf(delimiter) >= 0)
                {
                    string[] values = claim.Value.Split(delimiter);

                    foreach (string value in values)
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            throw new SecurityTokenException("Invalid SWT token. All claims must have a value.");
                        }
                        else
                        {
                            decodedClaims.Add(new Claim(claim.Key, value, ClaimValueTypes.String, issuer));
                        }
                    }
                }
                else
                {
                    decodedClaims.Add(new Claim(claim.Key, claim.Value, ClaimValueTypes.String, issuer));
                }
            }

            return decodedClaims;
        }

        protected DateTime DecodeExpiry(string expiry)
        {
            if (expiry == null)
                return DateTime.MaxValue;

            Int64 totalSeconds = 0;
            if (!Int64.TryParse(expiry, out totalSeconds))
            {
                throw new ArgumentException("Invalid request. Date format for expiry is unrecognized.", "expiry");
            }

            Int64 maxSeconds = (Int64) ((DateTime.MaxValue - SimpleWebTokenConstants.BaseTime).TotalSeconds) - 1;

            if (totalSeconds > maxSeconds)
            {
                totalSeconds = maxSeconds;
            }

            return SimpleWebTokenConstants.BaseTime + TimeSpan.FromSeconds(totalSeconds);
        }

        protected virtual string Encode()
        {
            IDictionary<string, string> claims = EncodeClaims(_claims, SimpleWebTokenConstants.DefaultCompoundClaimDelimiter);

            if (!string.IsNullOrEmpty(_audience))
                claims[SimpleWebTokenConstants.TokenAudience] = _audience;

            if (_expiresOn != DateTime.MaxValue)
                claims[SimpleWebTokenConstants.TokenExpiresOn] = EncodeExpiry(_expiresOn);

            if (!string.IsNullOrEmpty(_issuer))
                claims[SimpleWebTokenConstants.TokenIssuer] = _issuer;

            StringBuilder encodedClaims = new StringBuilder(claims.Encode());

            //
            // According to the SWT spec, the signature is always last.
            //
            if (!string.IsNullOrEmpty(_signature))
            {
                encodedClaims.AppendFormat("&{0}={1}", SimpleWebTokenConstants.TokenDigest256, HttpUtility.UrlEncode(_signature));
            }

            return encodedClaims.ToString();
        }

        // Claims can contain multiple claims with the same claim type.  This method takes
        // the values and combine them into a single output claim, so foo=bar and foo=blah will
        // be returned as a single claim in the output foo=bar,blah (if the delimiter is comma).
        protected IDictionary<string, string> EncodeClaims(IList<Claim> claims, char delimiter)
        {
            if (claims == null)
                throw new ArgumentNullException("claims");

            // SWT and Shared Secret claim names are case-sensitive
            Dictionary<string, string> outputClaims = new Dictionary<string, string>(StringComparer.Ordinal);

            foreach (Claim claim in claims)
            {
                //
                // aggregate duplicate claims types into a list
                //
                if (outputClaims.ContainsKey(claim.ClaimType))
                {
                    outputClaims[claim.ClaimType] = outputClaims[claim.ClaimType] + delimiter + claim.Value;
                }
                else
                {
                    outputClaims[claim.ClaimType] = claim.Value;
                }
            }

            return outputClaims;
        }

        protected string EncodeExpiry(DateTime expiry)
        {
            if (expiry < SimpleWebTokenConstants.BaseTime)
                throw new ArgumentException("expiry is before base time of 1970-01-01T00:00:00Z");

            TimeSpan expiryTime = expiry - SimpleWebTokenConstants.BaseTime;

            // the WRAP protocol is expecting an integer expiry time
            return ((Int64) expiryTime.TotalSeconds).ToString();
        }

        public void Sign(byte[] issuerSecret)
        {
            if (issuerSecret == null)
                throw new ArgumentNullException("issuerSecret");
            //
            // Remove existing signature data
            //
            _signature = null;
            _unsignedString = null;

            _unsignedString = Encode();

            using (HMACSHA256 sha256 = new HMACSHA256(issuerSecret))
            {
                _signature = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(_unsignedString)));
            }
        }

        public bool SignVerify(byte[] issuerSecret)
        {
            if (issuerSecret == null)
                throw new ArgumentNullException("issuerSecret");

            if (_signature == null || _unsignedString == null)
                throw new InvalidOperationException("Token has never been signed");

            string verifySignature;

            using (HMACSHA256 sha256 = new HMACSHA256(issuerSecret))
            {
                verifySignature = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(_unsignedString)));
            }

            if (string.CompareOrdinal(verifySignature, _signature) == 0)
                return true;

            return false;
        }

        public override string ToString()
        {
            return Encode();
        }
    }
}
