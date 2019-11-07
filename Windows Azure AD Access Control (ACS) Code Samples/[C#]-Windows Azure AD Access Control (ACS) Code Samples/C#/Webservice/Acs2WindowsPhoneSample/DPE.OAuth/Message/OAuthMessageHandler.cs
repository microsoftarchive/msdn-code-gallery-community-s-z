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
    using System.Collections.Specialized;
    using System.IO;
    using System.Web;
    using Microsoft.Samples.DPE.OAuth.AuthorizationServer;

    public abstract class OAuthMessageHandler
    {
        public OAuthMessageHandler()
        {
            this.ServiceConfiguration = new OAuthServiceConfiguration();
            if (!this.ServiceConfiguration.IsInitialized)
            {
                this.ServiceConfiguration.Initialize();
            }
        }

        protected OAuthServiceConfiguration ServiceConfiguration { get; set; }

        public virtual TokenRequestMessage ReadMessage(StreamReader reader)
        {
            NameValueCollection requestParameters;
            string requestString;
            requestString = reader.ReadToEnd();
            reader.Close();            
            requestParameters = HttpUtility.ParseQueryString(requestString);

            var message = new TokenRequestMessage();
            foreach (string key in requestParameters.AllKeys)
            {
                if (key == OAuthConstants.GrantType)
                {
                    message.Type = requestParameters[key];
                    requestParameters.Remove(key);
                }

                message.Parameters = requestParameters;
            }

            return message;
        }

        public virtual bool CanValidateMessage(TokenRequestMessage message)
        {
            return false;
        }

        public abstract NameValueCollection Validate(TokenRequestMessage message);

        protected virtual void EnsureClientExists(TokenRequestMessage message)
        {
            var clientId = message.Parameters[OAuthConstants.ClientId];
            if (!this.ClientStore.ClientExists(clientId))
            {
                throw new OAuthException(OAuthErrorCodes.InvalidClient, string.Format("The client_id '{0}' is not registered", clientId));
            }
        }
    }
}