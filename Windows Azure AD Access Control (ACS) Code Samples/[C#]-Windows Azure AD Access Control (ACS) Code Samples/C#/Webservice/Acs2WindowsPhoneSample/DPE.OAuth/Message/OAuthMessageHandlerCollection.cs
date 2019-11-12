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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IO;

    public class OAuthMessageHandlerCollection : Collection<OAuthMessageHandler>
    {
        private Dictionary<string, OAuthMessageHandler> listByType = new Dictionary<string, OAuthMessageHandler>();

        public OAuthMessageHandlerCollection(IEnumerable<OAuthMessageHandler> handlers)
        {
            foreach (OAuthMessageHandler handler in handlers)
            {
                Add(handler);
            }
        }

        public IEnumerable<string> RequestTypeIdentifiers
        {
            get
            {
                return this.listByType.Keys;
            }
        }

        public static OAuthMessageHandlerCollection CreateDefaultSecurityTokenHandlerCollection()
        {
            // TODO add other message Handlers as they are implemented
            OAuthMessageHandlerCollection collection = 
                new OAuthMessageHandlerCollection(
                    new OAuthMessageHandler[] 
                    {
                        new AssertionMessageHandler(),
                        new AuthorizationCodeMessageHandler(),
                        new ClientCredentialsMessageHandler()
                    });

            return collection;
        }        

        public TokenRequestMessage ReadMessage(StreamReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            foreach (OAuthMessageHandler handler in this)
            {
                return handler.ReadMessage(reader);
            }

            return null;
        }        

        public NameValueCollection Validate(TokenRequestMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            foreach (OAuthMessageHandler handler in this)
            {
                if (handler.CanValidateMessage(message))
                {
                    return handler.Validate(message);
                }
            }
            
            return null;
        }
    }
}