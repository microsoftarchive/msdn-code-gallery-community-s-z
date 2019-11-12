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

namespace OAuth2Common
{
    public static class SimpleWebTokenConstants
    {
        public const char   DefaultCompoundClaimDelimiter = ',';
        public const char   ParameterSeparator = '&';

        // per Simple Web Token draft specification
        public const string TokenAudience  = "Audience";
        public const string TokenExpiresOn = "ExpiresOn";
        public const string TokenIssuer    = "Issuer";
        public const string TokenDigest256 = "HMACSHA256";

        public static readonly DateTime BaseTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
    }
}
