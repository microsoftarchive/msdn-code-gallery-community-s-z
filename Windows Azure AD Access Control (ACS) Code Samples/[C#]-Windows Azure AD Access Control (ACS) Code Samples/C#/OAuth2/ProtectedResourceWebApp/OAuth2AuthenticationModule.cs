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
using System.Configuration;
using System.Web;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Tokens;
using OAuth2Common;

namespace ProtectedResourceWebApp
{
    public class OAuth2AuthenticationModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
        }

        #endregion

        protected virtual IClaimsPrincipal GetUserPrincipal()
        {
            //
            // Look for the authorization header. If present, extract the Simple Web Token.
            //
            string authorizationHeader = HttpContext.Current.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                string rawToken = GetTokenFromHeader(authorizationHeader);

                if (!String.IsNullOrEmpty(rawToken))
                {
                    SimpleWebToken swt = SimpleWebToken.FromString(rawToken);

                    if (!swt.SignVerify(Convert.FromBase64String(ConfigurationManager.AppSettings.Get("SigningKey"))))
                    {
                        throw new InvalidSecurityException("Token signature is invalid. Ensure that the correct signing key is configured in Web.config.");
                    }

                    if (!StringComparer.OrdinalIgnoreCase.Equals(swt.Audience, "https://oauth2RelyingParty/"))
                    {
                        throw new InvalidSecurityException("Token is not issued for this relying party.");
                    }

                    if (DateTime.Compare(swt.ExpiresOn, DateTime.Now) < 0)
                    {
                        throw new InvalidSecurityException("Token is expired.");
                    }

                    //
                    // Additional checks omitted for brevity.
                    // In a real-world application, the issuer and claims would likely be verified as well.
                    //

                    return ClaimsPrincipal.CreateFromIdentity(new ClaimsIdentity(swt.Claims));
                }
            }

            return null;
        }

        /// <summary>
        /// Parses an OAuth authorization header of the form "Bearer [Token]"
        /// </summary>
        private string GetTokenFromHeader(string headerValue)
        {
            string[] headerComponents = headerValue.Split(' ');

            if (headerComponents.Length == 2 &&
                headerComponents[0].Equals(OAuth2Constants.BearerAuthenticationType, StringComparison.OrdinalIgnoreCase))
            {
                return headerComponents[1];
            }

            return null;
        }

        public void OnAuthenticateRequest(Object source, EventArgs e)
        {
            HttpContext.Current.User = GetUserPrincipal();
        }
    }
}
