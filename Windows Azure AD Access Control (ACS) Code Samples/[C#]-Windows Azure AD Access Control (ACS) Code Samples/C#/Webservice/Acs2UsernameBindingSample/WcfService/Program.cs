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
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using ACS.Management;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml2;

namespace WcfService
{
    class Program
    {
        static string AccessControlSigningCertificateFilePath  = ConfigurationManager.AppSettings.Get("AccessControlSigningCertificateFilePath");

        static string ServiceAddress                           = ConfigurationManager.AppSettings.Get("ServiceAddress");
        static string ServiceCertificateFilePath               = ConfigurationManager.AppSettings.Get("ServiceCertificateFilePath");
        static string ServiceCertificatePassword               = ConfigurationManager.AppSettings.Get("ServiceCertificatePassword");

        static void Main(string[] args)
        {
            ServiceHost rpHost = CreateWcfServiceHost();

            try
            {
                rpHost.Open();

                Console.WriteLine("StringService has been started.");
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to exit");
                Console.WriteLine();
                Console.ReadLine();

                rpHost.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown during execution: " + e.ToString());
                rpHost.Abort();
            }
        }

        private static X509Certificate2 GetAcsSigningCertificate()
        {
            return new X509Certificate2(AccessControlSigningCertificateFilePath);
        }

        private static X509Certificate2 GetServiceCertificateWithPrivateKey()
        {
            return new X509Certificate2(ServiceCertificateFilePath, ServiceCertificatePassword);
        }

        private static ServiceHost CreateWcfServiceHost()
        {
            string acsUsernameEndpoint = String.Format("https://{0}.{1}/v2/wstrust/13/username", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            ServiceHost rpHost = new ServiceHost(typeof(StringService));

            rpHost.Credentials.ServiceCertificate.Certificate = GetServiceCertificateWithPrivateKey();

            rpHost.AddServiceEndpoint(typeof(IStringService),
                                       Bindings.CreateServiceBinding(acsUsernameEndpoint),
                                       ServiceAddress);

            //
            // This must be called after all WCF settings are set on the service host so the
            // Windows Identity Foundation token handlers can pick up the relevant settings.
            //
            ServiceConfiguration serviceConfiguration = new ServiceConfiguration();
            // Disable certificate validation to work with sample certificates
            serviceConfiguration.CertificateValidationMode = X509CertificateValidationMode.None;

            // Accept ACS signing certificate as Issuer.
            serviceConfiguration.IssuerNameRegistry = new X509IssuerNameRegistry(GetAcsSigningCertificate().SubjectName.Name);

            // Add the SAML 2.0 token handler.
            serviceConfiguration.SecurityTokenHandlers.AddOrReplace(new Saml2SecurityTokenHandler());

            // Add the address of this service to the allowed audiences.
            serviceConfiguration.SecurityTokenHandlers.Configuration.AudienceRestriction.AllowedAudienceUris.Add(new Uri(ServiceAddress));

            FederatedServiceCredentials.ConfigureServiceHost(rpHost, serviceConfiguration);

            return rpHost;
        }
    }
}
