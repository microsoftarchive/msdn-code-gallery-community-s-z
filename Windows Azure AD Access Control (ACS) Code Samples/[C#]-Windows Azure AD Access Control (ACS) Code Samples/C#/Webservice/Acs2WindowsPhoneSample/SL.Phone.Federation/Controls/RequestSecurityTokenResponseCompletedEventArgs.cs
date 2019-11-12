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
using SL.Phone.Federation.Utilities;

namespace SL.Phone.Federation.Controls
{
    /// <summary>
    /// Provides data for the AccessControlServiceSignIn control RequestSecurityTokenResponseCompleted event
    /// </summary>
    public class RequestSecurityTokenResponseCompletedEventArgs : EventArgs
    {
        Exception _error;
        RequestSecurityTokenResponse _rstr;

        internal RequestSecurityTokenResponseCompletedEventArgs(RequestSecurityTokenResponse requestSecurityTokenResponse, Exception error)
        {
            _error = error;
            _rstr = requestSecurityTokenResponse;
        }

        /// <summary>
        /// Gets any exception thrown during while requesting the security token.
        /// </summary>
        /// <remarks>If no error occur the null is returned.</remarks>
        public Exception Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        ///  Gets the RequestSecurityTokenResponse returned while requesting the security token.
        /// </summary>
        /// <remarks>If an error occur the null is returned.</remarks>
        public RequestSecurityTokenResponse RequestSecurityTokenResponse
        {
            get
            {
                return _rstr;
            }
        }
    }
}
