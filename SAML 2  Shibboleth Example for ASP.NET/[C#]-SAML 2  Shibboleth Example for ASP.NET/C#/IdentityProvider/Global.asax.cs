using System;
using System.Web;
using System.Web.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Net;
using ComponentPro.Saml2;

namespace SamlShibboleth.IdentityProvider
{
    public class Global : HttpApplication
    {
        private const string IdPKeyFile = "IdpKey.pfx";
        private const string IdPKeyPassword = "password";

        private const string SPCertFile = "SPCertificate.cer";

        public const string IdPCertKey = "IdPCertKey";
        public const string SPCertKey = "SPCert";

        /// <summary>
        /// Verifies the remote Secure Sockets Layer (SSL) certificate used for authentication.
        /// </summary>
        /// <param name="sender">An object that contains state information for this validation.</param>
        /// <param name="certificate">The certificate used to authenticate the remote party.</param>
        /// <param name="chain">The chain of certificate authorities associated with the remote certificate.</param>
        /// <param name="sslPolicyErrors">One or more errors associated with the remote certificate.</param>
        /// <returns>A System.Boolean value that determines whether the specified certificate is accepted for authentication.</returns>
        private static bool ValidateRemoteServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // NOTE: This is a test application with self-signed certificates, so all certificates are trusted.
            return true;
        }

        /// <summary>
        /// Loads the certificate file.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="fileName">The certificate file name.</param>
        /// <param name="password">The password for this certificate file.</param>
        private void LoadCertificate(string cacheKey, string fileName, string password)
        {
            X509Certificate2 cert = new X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet);

            Application[cacheKey] = cert;
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Set server certificate validation callback.
            ServicePointManager.ServerCertificateValidationCallback = ValidateRemoteServerCertificate;

            // Load the IdP key file.
            LoadCertificate(IdPCertKey, Path.Combine(HttpRuntime.AppDomainAppPath, IdPKeyFile), IdPKeyPassword);

            // Load the IdP key file.
            LoadCertificate(SPCertKey, Path.Combine(HttpRuntime.AppDomainAppPath, SPCertFile), null);
        }

        #region Config

        private const string AssertionServiceSamlBindingKey = "AssertionServiceSamlBinding";
        private const string AssertionServiceUrlHttpPostKey = "AssertionServiceUrlHttpPost";
        private const string AssertionServiceUrlHttpArtifactKey = "AssertionServiceUrlHttpArtifact";
        private const string ArtifactResolutionUrlKey = "ArtifactResolutionUrl";

        public static SamlBinding AssertionServiceSamlBinding
        {
            get
            {
                return SamlBindingUri.UriToBinding(WebConfigurationManager.AppSettings[AssertionServiceSamlBindingKey]);
            }
        }

        public static string AssertionServiceUrl
        {
            get
            {
                switch (AssertionServiceSamlBinding)
                {
                    case SamlBinding.HttpPost:
                        return AssertionServiceUrlHttpPost;

                    case SamlBinding.HttpArtifact:
                        return AssertionServiceUrlHttpArtifact;

                    default:
                        throw new ArgumentException("Invalid assertion consumer service binding");
                }
            }
        }

        public static string AssertionServiceUrlHttpPost
        {
            get
            {
                return WebConfigurationManager.AppSettings[AssertionServiceUrlHttpPostKey];
            }
        }

        public static string AssertionServiceUrlHttpArtifact
        {
            get
            {
                return WebConfigurationManager.AppSettings[AssertionServiceUrlHttpArtifactKey];
            }
        }

        public static string ArtifactResolutionUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings[ArtifactResolutionUrlKey];
            }
        }

        #endregion
    }
}