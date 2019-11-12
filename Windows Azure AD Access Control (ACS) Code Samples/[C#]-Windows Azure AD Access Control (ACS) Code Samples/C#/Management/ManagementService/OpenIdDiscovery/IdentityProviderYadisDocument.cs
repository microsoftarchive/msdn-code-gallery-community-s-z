//---------------------------------------------------------------------------------
// Copyright 2010 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------

using System;
using System.Xml;

namespace ACS.Management
{
    public class IdentityProviderYadisDocument
    {
        public IdentityProviderYadisDocument(XmlReader reader)
        {
            reader.MoveToContent();

            reader.ReadStartElement(YadisConstants.XrdsElement, YadisConstants.XrdsNamespace);

            //
            // The XRDS element can contain any number of elements.  Ignore anything that is not an XRD element.
            //
            while (reader.IsStartElement())
            {
                if (reader.IsStartElement(YadisConstants.XrdElement, YadisConstants.XriNamespace))
                {
                    //
                    // The spec mandates that only the LAST XRD element counts as the YADIS resource descriptor.
                    // Ensure that any previously read data is tossed out.
                    //
                    Reset();

                    reader.ReadStartElement(YadisConstants.XrdElement, YadisConstants.XriNamespace);

                    //
                    // Loop through all "service" elements, looking for type http://specs.openid.net/auth/2.0/server
                    // and http://openid.net/srv/ax/1.0 (if present)
                    //
                    while (reader.IsStartElement())
                    {
                        if (reader.IsStartElement(YadisConstants.ServiceElement, YadisConstants.XriNamespace))
                        {
                            ReadService(reader);
                        }
                        else
                        {
                            reader.Skip();
                        }
                    }

                    reader.ReadEndElement(); // </XRD>
                }
                else
                {
                    reader.Skip();
                }
            }

            reader.ReadEndElement(); // </XRDS>
        }

        /// <summary>
        /// Read the service element.  
        /// </summary>
        private void ReadService(XmlReader reader)
        {
            string uri = null;
            bool isOpenId20 = false;
            bool supportsAttributeExchange = false;

            reader.ReadStartElement(YadisConstants.ServiceElement, YadisConstants.XriNamespace);

            while (reader.IsStartElement())
            {
                if (reader.IsStartElement(YadisConstants.TypeElement, YadisConstants.XriNamespace))
                {
                    string type = reader.ReadElementContentAsString();
                    if (type.Equals(YadisConstants.OpenId20ProviderType, StringComparison.OrdinalIgnoreCase))
                    {
                        isOpenId20 = true;
                    }
                    else if (type.Equals(YadisConstants.AttributeExchange10Type, StringComparison.OrdinalIgnoreCase))
                    {
                        supportsAttributeExchange = true;
                    }
                }
                else if (reader.IsStartElement(YadisConstants.UriElement, YadisConstants.XriNamespace))
                {
                    uri = reader.ReadElementContentAsString();
                }
                else
                {
                    reader.Skip();
                }
            }

            if (isOpenId20 && !string.IsNullOrEmpty(uri))
            {
                OpenIdEndpoint = uri;
                SupportsAttributeExchange = supportsAttributeExchange;
            }

            reader.ReadEndElement(); // </Service>
        }

        private void Reset()
        {
            OpenIdEndpoint = null;
            SupportsAttributeExchange = false;
        }

        /// <summary>
        /// The OpenId 2.0 endpoint
        /// </summary>
        public string OpenIdEndpoint
        {
            get;
            set;
        }

        public bool SupportsAttributeExchange
        {
            get;
            set;
        }


    }
}