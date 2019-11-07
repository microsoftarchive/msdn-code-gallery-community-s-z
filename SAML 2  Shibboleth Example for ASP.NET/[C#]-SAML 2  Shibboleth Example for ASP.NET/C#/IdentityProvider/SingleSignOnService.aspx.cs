using System;
using System.Web.Security;
using ComponentPro.Saml2;

namespace SamlShibboleth.IdentityProvider
{   
    public partial class SingleSignOnService : System.Web.UI.Page
    {
        private const string SsoAuthnStateSessionKey = "SsoAuthnStateSessionKey";

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                // Load the Single Sign On state from the Session state.
                // If the saved authentication state is a null reference, receive the authentication request from the query string and form data.
                SsoAuthnState ssoState = (SsoAuthnState)Session[SsoAuthnStateSessionKey];

                if (ssoState == null || !User.Identity.IsAuthenticated)
                {
                    AuthnRequest authnRequest;
                    string relayState;

                    // Receive the authentication request and relay state.
                    Util.ProcessAuthnRequest(this, out authnRequest, out relayState);

                    // Check whether the provider MUST authenticate the presenter directly rather than rely on a previous security context.
                    bool forceAuthn = authnRequest.ForceAuthn;
                    bool allowCreate = false;

                    if (authnRequest.NameIdPolicy != null)
                    {
                        // Check whether the identity provider is allowed.
                        allowCreate = authnRequest.NameIdPolicy.AllowCreate;
                    }

                    ssoState = new SsoAuthnState();
                    ssoState.AuthnRequest = authnRequest;
                    ssoState.State = relayState;

                    // A boolean flag determining whether or not a local login is required.
                    bool requireLocalLogin = false;

                    if (forceAuthn)
                    {
                        requireLocalLogin = true;
                    }
                    else
                    {
                        if (!User.Identity.IsAuthenticated && allowCreate)
                        {
                            requireLocalLogin = true;
                        }
                    }

                    // Local login is required?
                    if (requireLocalLogin)
                    {
                        // Then save the session state.
                        Session[SsoAuthnStateSessionKey] = ssoState;
                        // And redirect to the login page.
                        FormsAuthentication.RedirectToLoginPage();

                        return;
                    }
                }

                // Create a new SAML 2 Response.
                ComponentPro.Saml2.Response samlResponse = Util.BuildResponse(this, ssoState.AuthnRequest);

                // Send the SAML response to the service provider.
                Util.SendResponse(this, samlResponse, ssoState.State);
            }

            catch (Exception exception)
            {
                Trace.Write("IdentityProvider", "An Error occurred", exception);
            }
        }
    }
}