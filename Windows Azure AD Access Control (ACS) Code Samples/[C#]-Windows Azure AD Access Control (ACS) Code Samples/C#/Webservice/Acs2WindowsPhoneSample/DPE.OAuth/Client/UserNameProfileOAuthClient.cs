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

namespace Microsoft.Samples.DPE.OAuth.Client
{
    using System;
    using System.Collections.Specialized;

    public class UserNameProfileOAuthClient : OAuthClientBase
    {
        private Uri authorizationServerUrl;
        private string clientId;
        private string clientSecret;
        private UserNameClientCredentials clientCredentials;

        public UserNameProfileOAuthClient(Uri authorizationServerUrl, string clientId, string clientSecret)
            : base(authorizationServerUrl)
        {
            this.authorizationServerUrl = authorizationServerUrl;
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            this.clientCredentials = new UserNameClientCredentials();
        }

        public override string Profile
        {
            get { return OAuthProfiles.UsernameProfile; }
        }

        public UserNameClientCredentials ClientCredentials
        {
            get
            {
                return this.clientCredentials;
            }
        }

        protected override void FillRequestParameters(NameValueCollection parameters)
        {
            parameters.Add(OAuthConstants.ClientId, this.clientId);
            parameters.Add(OAuthConstants.UserName, this.ClientCredentials.UserName);
            parameters.Add(OAuthConstants.Password, this.ClientCredentials.Password);
            
            if (!string.IsNullOrEmpty(this.clientSecret))
            {
                parameters.Add(OAuthConstants.ClientSecret, this.clientSecret);
            }   
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.ClientCredentials.UserName))
            {
                throw new ArgumentNullException("Username cannot be null");
            }

            if (string.IsNullOrEmpty(this.ClientCredentials.Password))
            {
                throw new ArgumentNullException("Password cannot be null");
            }
        }
    }
}