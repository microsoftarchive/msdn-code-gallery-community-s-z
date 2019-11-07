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
using System.IO;
using System.Net;
using System.Xml;
using mshtml;


namespace ACS.Management
{
    public class OpenIdDiscovery
    {
        /// <summary>
        /// Performs OpenID discovery according to the YADIS protocol and returns details about the returned provider.
        /// </summary>
        public static IdentityProviderYadisDocument DiscoverIdentityProvider(string identifier)
        {
            Uri identifierUri = NormalizeIdentifier(identifier);

            IdentityProviderYadisDocument openIdEndpoint = null;
            XmlReader yadisReader = null;

            HttpWebRequest webRequest = (HttpWebRequest) HttpWebRequest.Create(identifierUri);
            webRequest.Accept = YadisConstants.YadisMimeType;

            using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
            {
                //
                // The MIME type may contain encoding information after a semicolon, we are only interested in the actual content type.
                //
                string contentType = webResponse.ContentType.Split(';')[0];

                //
                // YADIS 1.0: The response MUST be one of: 
                //
                if (contentType.Equals(YadisConstants.YadisMimeType, StringComparison.OrdinalIgnoreCase))
                {
                    //
                    // A document of MIME media type, application/xrds+xml. 
                    //
                    yadisReader = XmlReader.Create(webResponse.GetResponseStream());
                }
                else if (!string.IsNullOrEmpty(webResponse.GetResponseHeader(YadisConstants.XrdsLocationHeader)))
                {
                    //
                    // HTTP response-headers (with or without a document) that include an X-XRDS-Location response-header.
                    //
                    yadisReader = XmlReader.Create(webResponse.GetResponseHeader(YadisConstants.XrdsLocationHeader));
                }
                else
                {
                    //
                    // An HTML document with a <head> element that includes a <meta> element with http-equiv attribute, X-XRDS-Location
                    //
                    using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                    {
                        string yadisUrl = GetYadisUrlFromHtml(sr.ReadToEnd());
                        if (!string.IsNullOrEmpty(yadisUrl))
                        {
                            yadisReader = XmlReader.Create(yadisUrl);
                        }
                    }
                }

                if (yadisReader != null)
                {
                    openIdEndpoint = new IdentityProviderYadisDocument(yadisReader);
                }
            }

            return openIdEndpoint;
        }

        /// <summary>
        /// Normalizes the identifier. Per the OpenId spec 7.2, this means adding "http://" if the scheme isn't specified and removing the fragment, if present.
        /// </summary>
        private static Uri NormalizeIdentifier(string identifier)
        {
            Uri identifierUri;
            if (!Uri.TryCreate(identifier, UriKind.Absolute, out identifierUri))
            {
                //
                // The URI isn't absolute, try adding "http://"
                //
                string normalizedIdentifier = Uri.UriSchemeHttp + Uri.SchemeDelimiter + identifier;
                if (!Uri.TryCreate(normalizedIdentifier, UriKind.Absolute, out identifierUri))
                {
                    throw new ArgumentException("Identifier value is not valid.");
                }
            }
            else
            {
                //
                // The scheme was provided already. If not http or https, fail.
                //
                if (identifierUri.Scheme != Uri.UriSchemeHttp && identifierUri.Scheme != Uri.UriSchemeHttps)
                {
                    throw new ArgumentException("Identifier value does not contain a valid scheme.");
                }
            }

            //
            // If the URL contains a fragment part, it MUST be stripped off together with the fragment delimiter character "#"
            //
            if (String.IsNullOrEmpty(identifierUri.Fragment))
            {
                return identifierUri;
            }
            else
            {
                UriBuilder identifierBuilder = new UriBuilder(identifierUri);
                identifierBuilder.Fragment = "";
                return identifierBuilder.Uri;
            }
        }

        /// <summary>
        /// Returns a YADIS URL from an HTML head's meta XRDS tag, or null if there isn't one.
        /// </summary>
        private static string GetYadisUrlFromHtml(string htmlString)
        {
            IHTMLDocument2 htmlDocument = new HTMLDocumentClass();
            htmlDocument.write(htmlString);

            foreach (IHTMLElement documentChildElement in htmlDocument.all)
            {
                //
                // Look for <head>
                //
                if (documentChildElement.tagName.Equals(YadisConstants.HeadElement, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (IHTMLElement headChildElement in (IHTMLElementCollection) documentChildElement.children)
                    {
                        //
                        // Look for <meta http-equiv="X-XRDS-Location">
                        //
                        if (headChildElement.tagName.ToLowerInvariant() == YadisConstants.MetaElement)
                        {
                            //
                            // The 0 flag value on getAttribute means case insensitive.
                            //
                            string httpEquivAttribute = headChildElement.getAttribute(YadisConstants.HttpEquivAttribute, 0) as string;
                            if (httpEquivAttribute == YadisConstants.XrdsLocationHeader)
                            {
                                return headChildElement.innerText;
                            }
                        }
                    }

                    break;
                }
            }

            return null;
        }
    }
}
