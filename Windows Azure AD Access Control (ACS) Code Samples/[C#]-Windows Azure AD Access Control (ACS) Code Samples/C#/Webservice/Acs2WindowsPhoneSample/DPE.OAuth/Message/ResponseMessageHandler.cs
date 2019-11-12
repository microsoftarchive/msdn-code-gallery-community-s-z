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
    using System.Collections.Specialized;
    using System.IO;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Samples.DPE.OAuth.Tokens;

    public class ResponseMessageHandler
    {
        private OAuthServiceConfiguration serviceConfig;

        public ResponseMessageHandler(OAuthServiceConfiguration serviceConfig)
        {
            this.serviceConfig = serviceConfig;
        }

        public TokenResponseMessage CreateResponse(TokenRequestMessage message, NameValueCollection additionalInfo)
        {
            TokenResponseMessage response = new TokenResponseMessage();
            response.AccessToken = this.CreateAccessToken(message, additionalInfo);
            response.RefreshToken = this.CreateRefreshToken();
            response.AccessTokenExpiresIn = TimeSpan.FromSeconds(this.serviceConfig.SimpleWebTokenHandlerConfiguration.Issuer.TokenExpirationInSeconds);
            
            return response;
        }

        public void SendResponse(TokenResponseMessage message)
        {
            HttpResponse response = HttpContext.Current.Response;
            string body;
            body = OAuthConstants.AccessToken + '=' + HttpUtility.UrlEncode(message.AccessToken);
            body += '&' + OAuthConstants.TokenExpiresIn + '=' + ((int)message.AccessTokenExpiresIn.TotalSeconds).ToString();
            body += '&' + OAuthConstants.RefreshToken + '=' + message.RefreshToken;
            response.Write(body);
            response.End();
        }

        private static SimpleWebToken CreateSimpleWebToken(string issuer, string scope, TimeSpan validity, NameValueCollection additionalInfo)
        {
            var swt = new SimpleWebToken(issuer) { Audience = scope, TokenValidity = validity };

            if (additionalInfo != null)
            {
                foreach (string key in additionalInfo.AllKeys)
                {
                    swt.Parameters.Add(key, additionalInfo[key]);
                }
            }

            return swt;
        }

        private static string SerializeToken(SimpleWebToken accessToken, SecurityTokenHandlerCollection handlers)
        {
            if (handlers.CanWriteToken(accessToken))
            {
                string token = String.Empty;
                using (var sw = new StringWriter())
                {
                    var writer = new XmlTextWriter(sw);
                    handlers.WriteToken(writer, accessToken);

                    // remove the envelope <stringToken>
                    var envelope = sw.ToString();
                    token = XElement.Parse(envelope).Value;
                }

                return token;
            }

            return null;
        }

        private string CreateRefreshToken()
        {
            // TODO: implement refresh token
            return "PlaceHolderRefreshToken";
        }

        private string CreateAccessToken(TokenRequestMessage message, NameValueCollection additionalInfo)
        {
            var scope = message.Parameters["scope"];
            var validity = TimeSpan.FromSeconds(this.serviceConfig.SimpleWebTokenHandlerConfiguration.Issuer.TokenExpirationInSeconds);
            var swt = CreateSimpleWebToken(this.serviceConfig.SimpleWebTokenHandlerConfiguration.Issuer.IssuerIdentifier, scope, validity, additionalInfo);
            var accessToken = SerializeToken(swt, this.serviceConfig.SecurityTokenHandlers);

            return accessToken;
        }
    }
}