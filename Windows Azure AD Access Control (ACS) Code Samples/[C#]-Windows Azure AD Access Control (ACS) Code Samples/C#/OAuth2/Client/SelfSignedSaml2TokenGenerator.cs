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
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using ACS.Management;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Protocols.WSTrust;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.IdentityModel.Tokens.Saml2;

namespace Client
{
    class SelfSignedSaml2TokenGenerator
    {
        /// <summary>
        /// Creates a SAML assertion signed with the given certificate.
        /// </summary>
        public static Saml2SecurityToken GetSamlAssertionSignedWithCertificate(String nameIdentifierClaim, byte[] certificateWithPrivateKeyRawBytes, string password)
        {
            string acsUrl = string.Format(CultureInfo.InvariantCulture, "https://{0}.{1}", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            Saml2Assertion assertion = new Saml2Assertion(new Saml2NameIdentifier(nameIdentifierClaim));

            Saml2Conditions conditions = new Saml2Conditions();
            conditions.NotBefore = DateTime.UtcNow;
            conditions.NotOnOrAfter = DateTime.MaxValue;
            conditions.AudienceRestrictions.Add(new Saml2AudienceRestriction(new Uri(acsUrl, UriKind.RelativeOrAbsolute)));
            assertion.Conditions = conditions;

            Saml2Subject subject = new Saml2Subject();
            subject.SubjectConfirmations.Add(new Saml2SubjectConfirmation(Saml2Constants.ConfirmationMethods.Bearer));
            subject.NameId = new Saml2NameIdentifier(nameIdentifierClaim);
            assertion.Subject = subject;

            X509SigningCredentials clientSigningCredentials = new X509SigningCredentials(
                    new X509Certificate2(certificateWithPrivateKeyRawBytes, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable));

            assertion.SigningCredentials = clientSigningCredentials;

            return new Saml2SecurityToken(assertion);
        }
    }
}
