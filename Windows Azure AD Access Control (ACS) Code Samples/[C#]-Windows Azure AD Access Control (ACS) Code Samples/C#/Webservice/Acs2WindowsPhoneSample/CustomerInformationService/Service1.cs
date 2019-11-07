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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Microsoft.Samples.DPE.OAuth;

namespace CustomerInformationService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]

    public class Service1
    {
        private SimpleDirectory sd = new SimpleDirectory();

        [WebGet(UriTemplate = "", ResponseFormat=WebMessageFormat.Json)]
        public List<SimpleDirectoryEntry> GetCollection()
        {
            ThrowIfNotAuthenticated();
            return sd.GetEntries();
        }

        private static void ThrowIfNotAuthenticated()
        {
            var identity = HttpContext.Current.User.Identity;
            if (identity == null || !identity.IsAuthenticated)
            {
                OAuthHelper.SendUnauthorizedResponse(new OAuthError{ Error = OAuthErrorCodes.UnauthorizedClient} , HttpContext.Current);
            }
        }
    }
}
