//---------------------------------------------------------------------------------
// Microsoft (R)  Windows Azure SDK
// Software Development Kit
// 
// Copyright (c) Microsoft Corporation. All rights reserved.  
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------


namespace Microsoft.Samples.SharedAccessSignatureAuthentication
{
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    
    static class NamespaceAuthRulesCRUD
    {
        internal const string managementEndpoint = "management.core.windows.net/";

        public static void CreateSASRuleOnNamespaceRoot(string subscriptionID, string managementCertSN, string serviceNamespace)
        {
            // The endpoint for creating a SAS rule on a namespace is:
            //     "https://management.core.windows.net/{subscriptionId}/services/ServiceBus/namespaces/{namespace}/AuthorizationRules/"
            string baseAddress = @"https://" + managementEndpoint + subscriptionID + @"/services/ServiceBus/namespaces/" +
                    serviceNamespace + @"/AuthorizationRules/";

            // The SAS rule we'll create has keyName as "contosoSendAll, a base64 encoded 256-bit key and the Send right
            var sendRule = new SharedAccessAuthorizationRule("contosoSendAll",
                SharedAccessAuthorizationRule.GenerateRandomKey(),
                new[] { AccessRights.Send });

            // Operations on the Service Bus namespace root require certificate authentication.
            WebRequestHandler handler = new WebRequestHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            handler.ClientCertificates.Add(GetCertificate(managementCertSN));

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseAddress)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-ms-version", "2012-03-01");

            // Do a POST on the baseAddress above to create an auth rule
            var postResult = httpClient.PostAsJsonAsync("", sendRule).Result;
        }

        public static List<SharedAccessAuthorizationRule> ReadSASRulesOnNamespaceRoot(string subscriptionID, string managementCertSN, string serviceNamespace)
        {
            // The endpoint for retrieving the SAS rules on the namespace is:
            //     "https://management.core.windows.net/{subscriptionId}/services/ServiceBus/namespaces/{namespace}/AuthorizationRules/"
            string baseAddress = @"https://" + managementEndpoint + subscriptionID + @"/services/ServiceBus/namespaces/" +
                    serviceNamespace + @"/AuthorizationRules/";

            // Operations on the Service Bus namespace root require certificate authentication.
            WebRequestHandler handler = new WebRequestHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            handler.ClientCertificates.Add(GetCertificate(managementCertSN));

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseAddress)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-ms-version", "2012-03-01");

            // Doing a GET on the base address above returns all the auth rules configured.
            var getResult = httpClient.GetAsync("").Result;
            List<SharedAccessAuthorizationRule> rules = new List<SharedAccessAuthorizationRule>();
            rules = getResult.Content.ReadAsAsync<List<SharedAccessAuthorizationRule>>().Result;
            return rules;
        }

        public static void RollSharedAccessKeyOnNamespaceRoot(string subscriptionID, string managementCertSN, string serviceNamespace, List<SharedAccessAuthorizationRule> rules)
        {
            // The endpoint for a SAS rules on the namespace is:
            //     "https://management.core.windows.net/{subscriptionId}/services/ServiceBus/namespaces/{namespace}/AuthorizationRules/"
            string baseAddress = @"https://" + managementEndpoint + subscriptionID + @"/services/ServiceBus/namespaces/" +
                    serviceNamespace + @"/AuthorizationRules/";

            // Operations on the Service Bus namespace root require certificate authentication.
            WebRequestHandler handler = new WebRequestHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            handler.ClientCertificates.Add(GetCertificate(managementCertSN));

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseAddress)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-ms-version", "2012-03-01");

            rules.ForEach(delegate(SharedAccessAuthorizationRule rule)
            {
                // Roll keys on all rules except the "RootManageSharedAccessKey"
                if (!String.Equals(rule.KeyName, "RootManageSharedAccessKey", StringComparison.Ordinal))
                {
                    rule.SecondaryKey = rule.PrimaryKey;
                    rule.PrimaryKey = SharedAccessAuthorizationRule.GenerateRandomKey();

                    // Update the rule
                    var putResult = httpClient.PutAsJsonAsync(rule.KeyName, rule).Result;
                }
            });
        }

        public static void DeleteSASRuleOnNamespaceRootByKeyName(string subscriptionID, string managementCertSN, string serviceNamespace, string keyName)
        {
            // The endpoint for a SAS rules on the namespace is:
            //     "https://management.core.windows.net/{subscriptionId}/services/ServiceBus/namespaces/{namespace}/AuthorizationRules/"
            string baseAddress = @"https://" + managementEndpoint + subscriptionID + @"/services/ServiceBus/namespaces/" +
                    serviceNamespace + @"/AuthorizationRules/";

            // Operations on the Service Bus namespace root require certificate authentication.
            WebRequestHandler handler = new WebRequestHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual
            };
            handler.ClientCertificates.Add(GetCertificate(managementCertSN));

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseAddress)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-ms-version", "2012-03-01");

            // Do a DELETE on the "baseAddress/KeyName" to delete the auth rule
            var deleteResult = httpClient.DeleteAsync(keyName).Result;

        }

        private static X509Certificate2 GetCertificate(string subjectName)
        {
            X509Certificate2 certificate = null;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);
            store.Close();
            if (collection.Count > 0)
            {
                certificate = collection[0];
            }

            return certificate;
        }
    }
}
