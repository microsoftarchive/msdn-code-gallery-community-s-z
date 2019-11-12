using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace OptimizedSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(OrderProcessingService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IOrderProcessing), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Host opened");

            ChannelFactory<IOrderProcessing> factory = new ChannelFactory<IOrderProcessing>(new BasicHttpBinding(), new EndpointAddress(baseAddress));
            IOrderProcessing proxy = factory.CreateChannel();
            Order order = proxy.GetOrder(1);
            proxy.ProcessOrder(order);

            ((IClientChannel)proxy).Close();
            factory.Close();
            host.Close();
        }
    }
}
