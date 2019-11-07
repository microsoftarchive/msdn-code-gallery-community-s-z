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
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASPNETSimpleMVC.Controllers
{
    public class ErrorController : Controller
    {
        // Errors can be mapped to custom strings here.
        static Dictionary<string, string> ErrorCodeMapping = new Dictionary<string, string>();

        static ErrorController()
        {
            ErrorCodeMapping["ACS50019"] = "You chose to cancel log-in to the identity provider.";
            ErrorCodeMapping["ACS60001"] = "No output claims were generated. You may be unauthorized to visit this site.";
        }

        //
        // POST: /Error/
        //
        // If an error occurs during sign-in, ACS will post JSON-encoded errors to this endpoint.
        // This function displays the error details, mapping specific error codes to custom strings.
        [AcceptVerbs( HttpVerbs.Post )]
        public ActionResult Index( string ErrorDetails )
        {
            // The error details contain an array of errors with unique error codes to indicate what went wrong.
            // Additionally, the error details contain a suggested HTTP return code, trace ID, and timestamp, which may be useful for logging purposes.

            ErrorDetails parsedErrorDetails = new JavaScriptSerializer().Deserialize<ErrorDetails>( ErrorDetails );

            ViewData["ErrorMessage"] = String.Format( "An error occurred during sign-in to {0}. ", parsedErrorDetails.identityProvider );

            // Loop through all ACS errors, looking for ones that are mapped to custom strings. 
            // When a mapped error is found, stop looking and append the custom string to the error message.
            foreach ( ErrorDetails.Error error in parsedErrorDetails.errors )
            {
                if ( ErrorCodeMapping.ContainsKey( error.errorCode ) )
                {
                    ViewData["ErrorMessage"] += ErrorCodeMapping[error.errorCode];
                    break;
                }
            }

            return View( "Error" );
        }

    }
}
