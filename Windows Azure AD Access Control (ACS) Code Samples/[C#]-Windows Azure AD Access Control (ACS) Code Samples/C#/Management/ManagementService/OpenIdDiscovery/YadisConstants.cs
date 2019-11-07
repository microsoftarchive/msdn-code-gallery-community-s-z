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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ACS.Management
{
    public class YadisConstants
    {
        public const string YadisMimeType                           = "application/xrds+xml";
        public const string XrdsLocationHeader                      = "X-XRDS-Location";

        //
        // XRDS elements
        //
        public const string XrdsNamespace                           = "xri://$xrds";
        public const string XrdsPrefix                              = "xrds";
        public const string XrdsElement                             = "XRDS";

        //
        // HTML elements
        //
        public const string HeadElement                             = "head";
        public const string MetaElement                             = "meta";
        public const string HttpEquivAttribute                      = "http-equiv";

        //
        // XRI elements
        //
        public const string XriNamespace                            = "xri://$xrd*($v*2.0)";
        public const string XriPrefix                               = "xri";
        public const string XrdElement                              = "XRD";
        public const string ServiceElement                          = "Service";
        public const string TypeElement                             = "Type";
        public const string UriElement                              = "URI";

        //
        // URIs
        //
        public const string OpenId20ProviderType                    = "http://specs.openid.net/auth/2.0/server";
        public const string AttributeExchange10Type                 = "http://openid.net/srv/ax/1.0";
    }
}