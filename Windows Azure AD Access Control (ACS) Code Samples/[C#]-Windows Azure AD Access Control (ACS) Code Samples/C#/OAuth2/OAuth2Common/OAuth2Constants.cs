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

namespace OAuth2Common
{
    public static class OAuth2Constants
    {
        //
        // Constants from OAuth 2.0 draft v2-13 - http://www.ietf.org/internet-drafts/draft-ietf-oauth-v2-13.txt
        //
        public const string AccessToken = "access_token";
        public const string Assertion = "assertion";
        public const string GrantType = "grant_type";
        public const string BearerAuthenticationType = "Bearer";
        public const string Scope = "scope";

        public static class ContentTypes
        {
            public const string Json = "application/json";
            public const string UrlEncoded = "application/x-www-form-urlencoded";
        }
    }
}