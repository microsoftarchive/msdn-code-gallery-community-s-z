using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace Saml2IdpInitiatedMvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            // Set server certificate validation callback.
            ServicePointManager.ServerCertificateValidationCallback = ValidateRemoteServerCertificate;

            // Load the certificate.
            string fileName = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "Key.pfx");
            LoadCertificate(fileName, "password");
        }

        // SAML
        public const string CertKeyName = "Cert";

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
        /// <param name="fileName">The certificate file name.</param>
        /// <param name="password">The password for this certificate file.</param>
        private void LoadCertificate(string fileName, string password)
        {
            X509Certificate2 cert = new X509Certificate2(fileName, password, X509KeyStorageFlags.MachineKeySet);

            Application[CertKeyName] = cert;
        }
    }
}