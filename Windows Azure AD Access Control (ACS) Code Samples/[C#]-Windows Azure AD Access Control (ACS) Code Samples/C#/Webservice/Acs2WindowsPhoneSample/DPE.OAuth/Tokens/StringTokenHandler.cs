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

namespace Microsoft.Samples.DPE.OAuth.Tokens
{
    using System;
    using System.IdentityModel.Tokens;
    using System.Web;
    using System.Xml;
    using Microsoft.IdentityModel.Tokens;

    public abstract class StringTokenHandler : SecurityTokenHandler
    {
        public override bool CanWriteToken
        {
            get
            {
                return true;
            }
        }

        public override bool CanValidateToken
        {
            get { return false; }
        }

        public override bool CanReadToken(XmlReader reader)
        {
            if (reader == null)
            {
                // TODO throw reader null exception
            }

            return reader.IsStartElement("stringToken");
        }

        public override SecurityToken ReadToken(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (!this.CanReadToken(reader))
            {
                throw new Exception("cannot read token");
            }

            string token = reader.ReadElementContentAsString();            
            var securityToken = this.GetTokenFromString(token);

            return securityToken;
        }

        public override void WriteToken(XmlWriter writer, SecurityToken token)
        {
            writer.WriteStartElement("stringToken");
            string tokenString = this.GetTokenAsString(token);
            writer.WriteString(tokenString);
            writer.WriteEndElement();
        }

        public abstract SecurityToken GetTokenFromString(string token);

        public abstract string GetTokenAsString(SecurityToken token);
    }
}