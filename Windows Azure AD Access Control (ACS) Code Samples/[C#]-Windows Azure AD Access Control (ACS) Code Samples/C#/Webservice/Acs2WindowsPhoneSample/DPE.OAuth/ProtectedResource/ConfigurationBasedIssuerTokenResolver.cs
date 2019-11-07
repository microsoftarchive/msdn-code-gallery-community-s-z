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
    using System.IdentityModel.Tokens;
    using System.Xml;
    using Microsoft.IdentityModel.Tokens;

    public class ConfigurationBasedIssuerTokenResolver : IssuerTokenResolver
    {
        private IDictionary<string, SecurityKey> keys;

        public ConfigurationBasedIssuerTokenResolver()
        {
            this.keys = new Dictionary<string, SecurityKey>();
        }

        public ConfigurationBasedIssuerTokenResolver(XmlNodeList customConfiguration)
        {
            this.keys = new Dictionary<string, SecurityKey>();
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
            if (!StringComparer.Ordinal.Equals(element.LocalName, "serviceKeys"))
            {
                throw new InvalidOperationException("The top element of the configuration should be named 'serviceKeys'");
            }

            foreach (XmlNode node in element.ChildNodes)
            {
                XmlElement addRemoveNode = node as XmlElement;
                if (addRemoveNode != null)
                {
                    if (StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "add"))
                    {
                        XmlNode serviceNameNode = addRemoveNode.Attributes.GetNamedItem("serviceName");
                        XmlNode serviceKeyNode = addRemoveNode.Attributes.GetNamedItem("serviceKey");
                        if (((addRemoveNode.Attributes.Count != 2) || (serviceNameNode == null)) || ((serviceKeyNode == null) || string.IsNullOrEmpty(serviceKeyNode.Value)))
                        {
                            throw new InvalidOperationException("The <add> element is malformed. The right format is: <add serviceName=\"name\" serviceKey=\"base64Key\"");
                        }

                        string serviceName = serviceNameNode.Value.ToLowerInvariant();
                        string serviceKey = string.Intern(serviceKeyNode.Value);
                        var serviceKeySecurityKey = new InMemorySymmetricSecurityKey(Convert.FromBase64String(serviceKey));
                        this.keys.Add(serviceName, serviceKeySecurityKey);
                    }
                    else if (StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "remove"))
                    {
                        if ((addRemoveNode.Attributes.Count != 1) || !StringComparer.Ordinal.Equals(addRemoveNode.Attributes[0].LocalName, "serviceName"))
                        {
                            throw new InvalidOperationException("The <remove> node should have a serviceName attribute");
                        }

                        string serviceName = addRemoveNode.Attributes.GetNamedItem("serviceName").Value;
                        this.keys.Remove(serviceName);
                    }
                    else
                    {
                        if (!StringComparer.Ordinal.Equals(addRemoveNode.LocalName, "clear"))
                        {
                            throw new InvalidOperationException(string.Format("Invalid element: {0}", addRemoveNode.LocalName));
                        }

                        this.keys.Clear();
                    }
                }
            }
        }
        
        protected override bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
        {
            key = null;
            var dictBasedClause = keyIdentifierClause as DictionaryBasedKeyIdentifierClause;

            if (dictBasedClause != null)
            {
                return this.keys.TryGetValue(dictBasedClause.Dictionary["Audience"].ToLowerInvariant(), out key);
            }

            return false;
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
