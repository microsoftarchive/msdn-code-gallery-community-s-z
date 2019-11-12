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

using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;

namespace WcfService
{
    public static class Bindings
    {
        public static Binding CreateServiceBinding(string acsUsernameEndpoint)
        {
            return new IssuedTokenWSTrustBinding(CreateAcsUsernameBinding(), new EndpointAddress(acsUsernameEndpoint));
        }

        public static Binding CreateAcsUsernameBinding()
        {
            return new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential);
        }
    }
}
