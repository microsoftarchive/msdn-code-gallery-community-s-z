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

namespace Microsoft.AccessControl2.SDK.ASPNetSimpleWebsite
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using ACS.Management;

    public partial class _Default : System.Web.UI.Page
    {
        string serviceNamespace = SamplesConfiguration.ServiceNamespace;
        string acsHostName = SamplesConfiguration.AcsHostUrl;
        string trustedTokenPolicyKey = ConfigurationManager.AppSettings.Get("IssuerSigningKey");

        string trustedAudience = "http://localhost:8000/Service/";
        string requiredClaimType = "action";
        string requiredClaimValue = "reverse";

        protected void Page_Load(object sender, EventArgs e)
        {
            // get the authorization header
            string headerValue = Request.Headers.Get("Authorization");

            // check that a value is there
            if (string.IsNullOrEmpty(headerValue))
            {
                this.ReturnUnauthorized();
                return;
            }

            // check that it starts with 'OAuth2'
            if (!headerValue.StartsWith("OAuth2 "))
            {
                this.ReturnUnauthorized();
                return;
            }

            string[] nameValuePair = headerValue.Substring("OAuth2 ".Length).Split(new char[] { '=' }, 2);

            if (nameValuePair.Length != 2 ||
                nameValuePair[0] != "access_token" ||
                !nameValuePair[1].StartsWith("\"") ||
                !nameValuePair[1].EndsWith("\""))
            {
                this.ReturnUnauthorized();
                return;
            }

            // trim off the leading and trailing double-quotes
            string token = nameValuePair[1].Substring(1, nameValuePair[1].Length - 2);

            // create a token validator
            TokenValidator validator = new TokenValidator(
                this.acsHostName,
                this.serviceNamespace,
                this.trustedAudience,
                this.trustedTokenPolicyKey);

            // validate the token
            if (!validator.Validate(token))
            {
                this.ReturnUnauthorized();
                return;
            }

            // check for an action claim
            Dictionary<string, string> claims = validator.GetNameValues(token);

            string actionClaimValue;
            if (!claims.TryGetValue(this.requiredClaimType, out actionClaimValue))
            {
                this.ReturnUnauthorized();
                return;
            }

            // check for the correct action claim value
            if (!actionClaimValue.Equals(this.requiredClaimValue))
            {
                this.ReturnUnauthorized();
                return;
            }

            // reverse the string and return to caller
            string stringToReverse = Request.Form["string_to_reverse"];
            char[] chars = stringToReverse.ToCharArray();
            Array.Reverse(chars);

            Response.Write(new string(chars));
            Response.End();
        }

        private void ReturnUnauthorized()
        {
            Response.StatusCode = 401;
            Response.End();
        }
    }
}