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

    public class AssertionProfileOAuthClient : OAuthClientBase
    {
        private string clientId;
        private string clientSecret;
        private AssertionClientCredentials clientCredentials;

        public AssertionProfileOAuthClient(Uri authorizationServerUrl, string clientId, string clientSecret)
            : base(authorizationServerUrl)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.clientCredentials = new AssertionClientCredentials();
        }

        public override string Profile
        {
            get 
            {
                return OAuthProfiles.AssertionProfile;
            }
        }        

        public AssertionClientCredentials ClientCredentials
        {
            get
            {
                return this.clientCredentials;
            }
        }        
        
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.ClientCredentials.Assertion))
            {
                throw new ArgumentNullException("Assertion cannot be null. ClientCredentials must be set.");
            }

            if (string.IsNullOrEmpty(this.ClientCredentials.AssertionFormat))
            {
                throw new ArgumentNullException("Assertion format cannot be null. ClientCredentials must be set.");
            }
        }

        protected override void FillRequestParameters(NameValueCollection parameters)
        {
            parameters.Add(OAuthConstants.ClientId, this.clientId);
            parameters.Add(OAuthConstants.Assertion, this.ClientCredentials.Assertion);
            parameters.Add(OAuthConstants.AssertionType, this.ClientCredentials.AssertionFormat);
        
            if (!string.IsNullOrEmpty(this.clientSecret))
            {
                parameters.Add(OAuthConstants.ClientSecret, this.clientSecret);
            }         
        }        
    }
}