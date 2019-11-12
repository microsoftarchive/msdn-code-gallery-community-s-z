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

using System.Collections.Generic;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace WcfService
{
    /// <summary>
    /// Implements an IssuerNameRegistry that only recognizes a specific
    /// set of issuer subject names.
    /// </summary>
    class X509IssuerNameRegistry : IssuerNameRegistry
    {
        List<string> _trustedSubjectNames = new List<string>();

        /// <summary>
        /// Constructs an instance of X509IssuerNameRegistry.
        /// </summary>
        /// <param name="trustedSubjectNames">The subject names that can be recognized.</param>
        public X509IssuerNameRegistry(params string[] trustedSubjectNames)
        {
            _trustedSubjectNames = new List<string>(trustedSubjectNames);
        }

        /// <summary>
        /// Determines what the issuer name will be on claims contained in tokens.
        /// </summary>
        /// <param name="securityToken">
        /// The security token to extract the issuer name from. This token typically signed the
        /// token containing claims and represents the issuer.
        /// </param>
        /// <returns>The issuer name to be put on claims.</returns>
        public override string GetIssuerName(SecurityToken securityToken)
        {
            X509SecurityToken x509Token = securityToken as X509SecurityToken;
            if (x509Token != null)
            {
                //
                // Check the list of trusted/permissible issuers
                //
                if (_trustedSubjectNames.Contains(x509Token.Certificate.SubjectName.Name))
                {
                    return x509Token.Certificate.SubjectName.Name;
                }
            }

            //
            // Complain in all other situations.
            //
            throw new SecurityTokenException("Untrusted issuer.");
        }
    }
}
