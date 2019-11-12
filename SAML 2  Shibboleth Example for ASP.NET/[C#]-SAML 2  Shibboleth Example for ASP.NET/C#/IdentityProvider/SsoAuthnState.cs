using ComponentPro.Saml2;

namespace SamlShibboleth.IdentityProvider
{
    /// <summary>
    /// Represents the state saved during a local login.
    /// </summary>
    public class SsoAuthnState
    {
        private AuthnRequest authnRequest;
        private string state;

        public AuthnRequest AuthnRequest
        {
            get
            {
                return authnRequest;
            }
            set
            {
                authnRequest = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
    }
}