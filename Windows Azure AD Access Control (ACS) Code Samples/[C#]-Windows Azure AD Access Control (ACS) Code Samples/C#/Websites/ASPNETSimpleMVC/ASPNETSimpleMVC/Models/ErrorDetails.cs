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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETSimpleMVC
{
    // This class and its properties map to the JSON error object returned by ACS in case of error.
    public class ErrorDetails
    {
        // The property names must exactly match the ACS JSON format, including case.
        public string context { get; set; }
        public string httpReturnCode { get; set; }
        public string identityProvider { get; set; }
        public string timeStamp { get; set; }
        public string traceId { get; set; }

        public Error[] errors { get; set; }

        public class Error
        {
            public string errorCode { get; set; }
            public string errorMessage { get; set; }
        }
    }
}