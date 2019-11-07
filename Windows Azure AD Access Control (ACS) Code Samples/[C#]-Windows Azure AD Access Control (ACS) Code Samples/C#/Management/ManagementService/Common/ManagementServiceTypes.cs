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


namespace ACS.Management
{
    #region Identity provider object types

    public enum IdentityProviderKeyType
    {
        ApplicationKey,
        Symmetric,
        X509Certificate
    }

    public enum IdentityProviderKeyUsage
    {
        ApplicationId,
        ApplicationSecret,
        Signing
    }

    public enum IdentityProviderProtocolType
    {
        Facebook,
        OpenId,
        WsFederation
    }

    public enum IdentityProviderEndpointType
    {
        EmailDomain,
        FedMetadataUrl,
        ImageUrl,
        SignIn,
        SignOut
    }

    #endregion

    #region Relying Party object types

    public enum RelyingPartyTokenType
    {
        SAML_1_1,
        SAML_2_0,
        SWT
    };

    public enum RelyingPartyKeyType
    {
        Symmetric,
        X509Certificate
    };

    public enum RelyingPartyKeyUsage
    {
        Encrypting,
        Signing
    };

    public enum RelyingPartyAddressType
    {
        Error,
        Realm,
        Reply
    }

    #endregion

    #region Service Identity object types

    public enum ServiceIdentityKeyType
    {
        Password,
        Symmetric,
        X509Certificate
    };

    /// <summary>
    /// The valid list of key usages
    /// </summary>
    public enum ServiceIdentityKeyUsage
    {
        Password,
        Signing
    };

    #endregion

    #region ServiceKey object types

    public enum ServiceKeyType
    {
        X509Certificate,
        Password,
        Symmetric
    }

    public enum ServiceKeyUsage
    {
        Signing,
        Management, 
        Encrypting,
    }
    #endregion

}
