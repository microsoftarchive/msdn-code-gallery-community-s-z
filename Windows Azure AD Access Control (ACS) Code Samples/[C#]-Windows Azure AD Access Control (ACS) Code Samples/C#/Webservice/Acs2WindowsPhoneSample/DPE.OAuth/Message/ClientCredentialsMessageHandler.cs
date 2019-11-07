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

    public class ClientCredentialsMessageHandler : OAuthMessageHandler
    {                
        public override bool CanValidateMessage(TokenRequestMessage message)
        {
            if (message.Type == RequestGrantType.None)
            {
                return true;
            }

            return false;
        }

        public override NameValueCollection Validate(TokenRequestMessage message)
        {
            string clientId = message.Parameters[OAuthConstants.ClientId];
            string clientSecret = message.Parameters[OAuthConstants.ClientSecret];

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                throw new InvalidOperationException("client_id and client_secret must be present for this profile");
            }

            bool valid = this.ClientStore.ValidateClient(clientId, clientSecret);
            if (!valid)
            {
                throw new InvalidOperationException("client_id is not registered or client_secret is invalid");
            }

            message.Parameters.Remove(OAuthConstants.ClientSecret);
            
            return message.Parameters;
        }
    }
}