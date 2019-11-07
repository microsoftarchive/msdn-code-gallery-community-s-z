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

    public class TokenRequestMessage
    {
        private string grantType;
        private NameValueCollection parameters;

        public TokenRequestMessage()
        {
            this.parameters = new NameValueCollection();
        }

        public string Type
        {
            get { return this.grantType; }
            set { this.grantType = value; }
        }

        public NameValueCollection Parameters
        {
            get { return this.parameters; }
            set { this.parameters = value; }
        }
    }
}