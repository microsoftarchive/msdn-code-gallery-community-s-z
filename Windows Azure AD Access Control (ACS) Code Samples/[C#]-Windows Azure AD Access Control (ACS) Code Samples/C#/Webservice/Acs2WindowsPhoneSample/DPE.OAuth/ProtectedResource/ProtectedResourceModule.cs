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

namespace Microsoft.Samples.DPE.OAuth.ProtectedResource
{
    using System;
    using System.IdentityModel.Tokens;
    using System.IO;
    using System.Threading;
    using System.Web;
    using System.Xml;
    using Microsoft.IdentityModel.Claims;
    using Microsoft.IdentityModel.Configuration;

    public class ProtectedResourceModule : IHttpModule
    {
        private const string OAuthErrorKey = "OAuthErrorKey";

        private ServiceConfiguration serviceConfiguration;

        /// <summary>
        /// Gets or sets the <see cref="ServiceConfiguration"/> in effect for this module.
        /// </summary>
        public ServiceConfiguration ServiceConfiguration
        {
            get
            {
                if (this.serviceConfiguration == null)
                {
                    this.serviceConfiguration = new OAuthServiceConfiguration();
                    if (!this.serviceConfiguration.IsInitialized)
                    {
                        this.serviceConfiguration.Initialize();
                    }
                }

                return this.serviceConfiguration;
            }
        }

        public virtual void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            this.InitializeModule(context);
        }

        public virtual void OnPostAuthenticateRequest(object sender, EventArgs args)
        {
            // TODO add the claimsPrincipal creation logic here
            var principal = HttpContext.Current.User as IClaimsPrincipal;
            if (principal == null)
            {
                principal = ClaimsPrincipal.CreateFromHttpContext(HttpContext.Current);

                ClaimsAuthenticationManager authenticationManager = ServiceConfiguration.ClaimsAuthenticationManager;
                if (authenticationManager != null && principal != null && principal.Identity != null)
                {
                    principal = authenticationManager.Authenticate(HttpContext.Current.Request.Url.AbsoluteUri, principal);
                }

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }

        public virtual void OnEndRequest(object sender, EventArgs args)
        {
            HttpContext context = HttpContext.Current;
            if (context.Items[OAuthErrorKey] != null)
            {
                var error = context.Items[OAuthErrorKey] as OAuthError;
                context.Items.Remove(OAuthErrorKey);
                OAuthHelper.SendUnauthorizedResponse(error, context);
            }
        }

        public virtual void OnAuthenticateRequest(object sender, EventArgs args)
        {
            HttpContext context = HttpContext.Current;

            if (OAuthHelper.IsOAuthAuthorization(context.Request))
            {
                OAuthError error;
                bool valid = this.ValidateRequest(context.Request, out error);

                if (!valid)
                {
                    context.Items[OAuthErrorKey] = error;
                }
            }
        }

        protected void InitializeModule(HttpApplication context)
        {
            context.AuthenticateRequest += this.OnAuthenticateRequest;
            context.EndRequest += this.OnEndRequest;
            context.PostAuthenticateRequest += this.OnPostAuthenticateRequest;
        }

        private bool ValidateRequest(HttpRequest request, out OAuthError error)
        {
            error = null;
            string accessToken = OAuthHelper.ExtractAcessTokenFromAuthenticateHeader(request);
            if (!string.IsNullOrEmpty(accessToken))
            {
                string xmlToken = string.Format("<stringToken>{0}</stringToken>", HttpUtility.HtmlEncode(accessToken));
                SecurityToken token = null;

                using (var stringReader = new StringReader(xmlToken))
                {
                    var reader = XmlReader.Create(stringReader);
                    if (!this.ServiceConfiguration.SecurityTokenHandlers.CanReadToken(reader))
                    {
                        error = new OAuthError
                        {
                            Error = OAuthErrorCodes.InvalidRequest,
                            ErrorDescription = string.Format("Cannot read token. If you are using SWT, make sure to configure SimpleWebTokenHandler. Token: {0}", accessToken)
                        };
                    }

                    token = this.ServiceConfiguration.SecurityTokenHandlers.ReadToken(reader);
                }

                var identities = this.ServiceConfiguration.SecurityTokenHandlers.ValidateToken(token);

                IClaimsPrincipal principal = ServiceConfiguration.ClaimsAuthenticationManager.Authenticate(
                                                                    HttpContext.Current.Request.Url.AbsoluteUri, new ClaimsPrincipal(identities));
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;

                bool access = ServiceConfiguration.ClaimsAuthorizationManager.CheckAccess(new AuthorizationContext(Thread.CurrentPrincipal as IClaimsPrincipal, request.Url.AbsoluteUri, request.HttpMethod));
                if (!access)
                {
                    error = new OAuthError
                    {
                        Error = OAuthErrorCodes.UnauthorizedClient,
                        ErrorDescription = "Unauthorized"
                    };
                }

                return access;
            }

            error = new OAuthError
            {
                Error = OAuthErrorCodes.UnauthorizedClient,
                ErrorDescription = "Unauthorized"
            };

            return false;
        }
    }
}