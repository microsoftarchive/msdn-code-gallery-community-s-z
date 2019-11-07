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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens;
    using System.Xml;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Samples.DPE.OAuth.Tokens;

    public class SimpleWebTokenTrustedIssuersRegistry : IssuerNameRegistry
    {
        private Dictionary<string, string> configuredTrustedIssuers;

        public SimpleWebTokenTrustedIssuersRegistry()
        {
            this.configuredTrustedIssuers = new Dictionary<string, string>();
        }

        public SimpleWebTokenTrustedIssuersRegistry(XmlNodeList customConfiguration)
        {
            this.configuredTrustedIssuers = new Dictionary<string, string>();
            if (customConfiguration == null)
            {
                throw new ArgumentNullException("customConfiguration");
            }

            List<XmlElement> xmlElements = GetXmlElements(customConfiguration);
            if (xmlElements.Count != 1)
            {
                throw new InvalidOperationException("There should be only one xml element as the configuration of this class");
            }

            XmlElement element = xmlElements[0];
            if (!StringComparer.Ordinal.Equals(element.LocalName, "trustedIssuers"))
            {
                throw new InvalidOperationException("The top element of the configuration should be named 'trustedIssuers'");
            }

            foreach (XmlNode node in element.ChildNodes)
            {
                XmlElement addRemoveNode = node as XmlElement;
                if (addRemoveNode != null)
                {
                    if (StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "add"))
                    {
                        XmlNode issuerIdentifierNode = addRemoveNode.Attributes.GetNamedItem("issuerIdentifier");
                        XmlNode nameNode = addRemoveNode.Attributes.GetNamedItem("name");
                        if (((addRemoveNode.Attributes.Count != 2) || (issuerIdentifierNode == null)) || ((nameNode == null) || string.IsNullOrEmpty(nameNode.Value)))
                        {
                            throw new InvalidOperationException("The <add> element is malformed. The right format is: <add issuerIdentifier=\"issuer identifier\" name=\"issuer friendly name\"");
                        }

                        string issuerIdentifier = issuerIdentifierNode.Value.ToLowerInvariant();
                        string name = string.Intern(nameNode.Value);
                        this.configuredTrustedIssuers.Add(issuerIdentifier, name);
                    }
                    else if (StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "remove"))
                    {
                        if ((addRemoveNode.Attributes.Count != 1) || !StringComparer.Ordinal.Equals(addRemoveNode.Attributes[0].LocalName, "issuerIdentifier"))
                        {
                            throw new InvalidOperationException("The <remove> node should have a issuerIdentifier attribute");
                        }

                        string issuerIdentifier = addRemoveNode.Attributes.GetNamedItem("issuerIdentifier").Value;
                        this.configuredTrustedIssuers.Remove(issuerIdentifier);
                    }
                    else
                    {
                        if (!StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "clear"))
                        {
                            throw new InvalidOperationException(string.Format("Invalid element: {0}", addRemoveNode.LocalName));
                        }

                        this.configuredTrustedIssuers.Clear();
                    }
                }
            }
        }

        public IDictionary<string, string> ConfiguredTrustedIssuers
        {
            get
            {
                return this.configuredTrustedIssuers;
            }
        }

        public void AddTrustedIssuer(string issuerIdentifier, string name)
        {
            if (string.IsNullOrEmpty(issuerIdentifier))
            {
                throw new ArgumentNullException("issuerIdentifier");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (this.configuredTrustedIssuers.ContainsKey(issuerIdentifier))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Issuer '{0}' already exists", issuerIdentifier));
            }

            this.configuredTrustedIssuers.Add(issuerIdentifier, name);
        }

        public override string GetIssuerName(SecurityToken securityToken)
        {
            if (securityToken == null)
            {
                throw new ArgumentNullException("securityToken");
            }

            SimpleWebToken token = securityToken as SimpleWebToken;
            if (token != null)
            {
                string issuer = token.Issuer.ToLowerInvariant();
                if (this.configuredTrustedIssuers.ContainsKey(issuer))
                {
                    return this.configuredTrustedIssuers[issuer];
                }
            }

            return null;
        }        

        private static List<XmlElement> GetXmlElements(XmlNodeList nodeList)
        {
            List<XmlElement> list = new List<XmlElement>();
            foreach (XmlNode node in nodeList)
            {
                XmlElement item = node as XmlElement;
                if (item != null)
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
