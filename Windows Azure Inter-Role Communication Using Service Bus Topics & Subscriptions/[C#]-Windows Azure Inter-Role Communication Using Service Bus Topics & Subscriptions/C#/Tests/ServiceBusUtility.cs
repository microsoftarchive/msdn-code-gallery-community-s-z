using System;
using System.Linq;
using System.Configuration;

using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration;

using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Description;

namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Tests
{
    public static class ServiceBusUtility
    {
        public static void RemoveEndpoint(string endpointName)
        {
            var serviceBusSettings = ConfigurationManager.GetSection(ServiceBusConfigurationSettings.SectionName) as ServiceBusConfigurationSettings;
            var serviceBusEndpoint = serviceBusSettings.Endpoints.Get(endpointName);

            if (serviceBusEndpoint != null)
            {
                var credentials = TokenProvider.CreateSharedSecretTokenProvider(serviceBusEndpoint.IssuerName, serviceBusEndpoint.IssuerSecret);
                var address = ServiceBusEnvironment.CreateServiceUri("sb", serviceBusEndpoint.ServiceNamespace, String.Empty);
                var managementClient = new NamespaceManager(address, credentials);

                if (!String.IsNullOrEmpty(serviceBusEndpoint.TopicName) && !String.IsNullOrEmpty(serviceBusEndpoint.SubscriptionName))
                {
                    if (managementClient.GetTopics().Where(t => String.Compare(t.Path, serviceBusEndpoint.TopicName, true) == 0).Count() > 0)
                    {
                        if (managementClient.GetSubscriptions(serviceBusEndpoint.TopicName).Where(s => String.Compare(s.Name, serviceBusEndpoint.SubscriptionName, true) == 0).Count() > 0)
                        {
                            managementClient.DeleteSubscription(serviceBusEndpoint.TopicName, serviceBusEndpoint.SubscriptionName);
                            return;
                        }
                    }
                }

               if (!String.IsNullOrEmpty(serviceBusEndpoint.TopicName))
                {
                    if (managementClient.GetTopics().Where(t => String.Compare(t.Path, serviceBusEndpoint.TopicName, true) == 0).Count() > 0)
                    {
                        managementClient.DeleteTopic(serviceBusEndpoint.TopicName);
                        return;
                    }
                }

               if (!String.IsNullOrEmpty(serviceBusEndpoint.QueueName))
               {
                   if (managementClient.GetQueues().Where(q => String.Compare(q.Path, serviceBusEndpoint.QueueName, true) == 0).Count() > 0)
                   {
                       managementClient.DeleteQueue(serviceBusEndpoint.QueueName);
                       return;
                   }
               }
            }
        }
    }
}
