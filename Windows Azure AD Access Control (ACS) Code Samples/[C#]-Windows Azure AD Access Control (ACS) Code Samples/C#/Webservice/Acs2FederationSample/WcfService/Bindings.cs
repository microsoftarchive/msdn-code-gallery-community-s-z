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

using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;

namespace WcfService
{
    public static class Bindings
    {
        public static Binding CreateServiceBinding(string acsEndpoint, string idpEndpoint)
        {
            return new IssuedTokenWSTrustBinding()
            {
                KeyType = SecurityKeyType.AsymmetricKey,
                IssuerBinding = CreateAcsBinding(idpEndpoint),
                IssuerAddress = new EndpointAddress(acsEndpoint)
            };
        }

        public static Binding CreateAcsBinding(string idpEndpoint)
        {
            return new IssuedTokenWSTrustBinding()
            {
                SecurityMode = SecurityMode.TransportWithMessageCredential,
                IssuerBinding = CreateIdpBinding(),
                IssuerAddress = new EndpointAddress(idpEndpoint)
            };
        }

        public static Binding CreateIdpBinding()
        {
            // Update this based on the authentication done by the idp
            WindowsWSTrustBinding binding = new WindowsWSTrustBinding()
            {
                SecurityMode = SecurityMode.TransportWithMessageCredential
            };
            return binding;
        }
    }
}
