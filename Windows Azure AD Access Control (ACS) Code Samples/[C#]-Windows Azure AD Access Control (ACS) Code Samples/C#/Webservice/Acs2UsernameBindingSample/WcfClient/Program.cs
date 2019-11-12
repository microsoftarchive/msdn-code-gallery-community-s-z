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
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using ACS.Management;
using WcfService;

namespace WcfClient
{
    class Program
    {
        static string ServiceAddress              = ConfigurationManager.AppSettings.Get("ServiceAddress");
        static string ServiceCertificateFilePath  = ConfigurationManager.AppSettings.Get("ServiceCertificateFilePath");

        static string ClientUsername              = ConfigurationManager.AppSettings.Get("ClientUsername");
        static string ClientPassword              = ConfigurationManager.AppSettings.Get("ClientPassword");

        static void Main(string[] args)
        {
            TrustAllCertificates();

            Console.WriteLine("Enter a string to reverse, then press <ENTER>");
            string userInputString = Console.ReadLine();
            Console.WriteLine();

            string acsUsernameEndpoint = String.Format("https://{0}.{1}/v2/wstrust/13/username", SamplesConfiguration.ServiceNamespace, SamplesConfiguration.AcsHostUrl);

            ChannelFactory<IStringService> stringServiceFactory = CreateChannelFactory(acsUsernameEndpoint, ServiceAddress);
            IStringService stringService = stringServiceFactory.CreateChannel();
            ICommunicationObject channel = (ICommunicationObject)stringService;

            try
            {
                string outputString = stringService.Reverse(userInputString);

                Console.WriteLine("Service responded with: " + outputString);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to exit");
                Console.ReadLine();

                channel.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown during execution: " + e.ToString());
                channel.Abort();
            }
        }

        private static void TrustAllCertificates()
        {
            //Trust all certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        private static ChannelFactory<IStringService> CreateChannelFactory(string acsUsernameEndpoint, string serviceEndpoint)
        {
            //
            // The WCF service endpoint host name may not match the service certificate subject.
            // By default, the host name is 'localhost' and the certificate subject is 'WcfServiceCertificate'.
            // Create a DNS Endpoint identity to match WcfServiceCertificate.
            //
            EndpointAddress serviceEndpointAddress = new EndpointAddress(new Uri(serviceEndpoint),
                                                                          EndpointIdentity.CreateDnsIdentity(GetServiceCertificateSubjectName()));

            ChannelFactory<IStringService> stringServiceFactory = new ChannelFactory<IStringService>(Bindings.CreateServiceBinding(acsUsernameEndpoint), serviceEndpointAddress);

            // Set the service credentials and disable certificate validation to work with sample certificates
            stringServiceFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            stringServiceFactory.Credentials.ServiceCertificate.DefaultCertificate = GetServiceCertificate();

            // Set the client credentials.
            stringServiceFactory.Credentials.UserName.UserName = ClientUsername;
            stringServiceFactory.Credentials.UserName.Password = ClientPassword;

            return stringServiceFactory;
        }

        private static X509Certificate2 GetServiceCertificate()
        {
            return new X509Certificate2(ServiceCertificateFilePath);
        }

        private static string GetServiceCertificateSubjectName()
        {
            const string cnPrefix = "CN=";
            string subjectFullName = GetServiceCertificate().Subject;
            Debug.Assert(subjectFullName.StartsWith(cnPrefix));
            return subjectFullName.Substring(cnPrefix.Length);
        }
    }
}
