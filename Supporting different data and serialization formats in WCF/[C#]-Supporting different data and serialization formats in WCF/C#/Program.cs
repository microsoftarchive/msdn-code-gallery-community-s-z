using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace JsonNetMessageFormatter
{
    class Program
    {
        public static string SendRequest(string uri, string method, string contentType, string body)
        {
            string responseBody = null;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = method;
            if (!String.IsNullOrEmpty(contentType))
            {
                req.ContentType = contentType;
            }
            if (body != null)
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
                req.GetRequestStream().Close();
            }

            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }
            Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (string headerName in resp.Headers.AllKeys)
            {
                Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
            }
            Console.WriteLine();
            Stream respStream = resp.GetResponseStream();
            if (respStream != null)
            {
                responseBody = new StreamReader(respStream).ReadToEnd();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
            }
            Console.WriteLine();
            Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
            Console.WriteLine();

            return responseBody;
        }

        class MyRawMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
                return WebContentFormat.Raw;
            }
        }

        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITestService), new BasicHttpBinding(), "soap");
            WebHttpBinding webBinding = new WebHttpBinding();
            webBinding.ContentTypeMapper = new MyRawMapper();
            host.AddServiceEndpoint(typeof(ITestService), webBinding, "json").Behaviors.Add(new NewtonsoftJsonBehavior());
            Console.WriteLine("Opening the host");
            host.Open();

            ChannelFactory<ITestService> factory = new ChannelFactory<ITestService>(new BasicHttpBinding(), new EndpointAddress(baseAddress + "/soap"));
            ITestService proxy = factory.CreateChannel();
            Console.WriteLine(proxy.GetPerson());

            SendRequest(baseAddress + "/json/GetPerson", "GET", null, null);
            SendRequest(baseAddress + "/json/EchoPet", "POST", "application/json", "{\"Name\":\"Fido\",\"Color\":\"Black and white\",\"Markings\":\"None\",\"Id\":1}");
            SendRequest(baseAddress + "/json/Add", "POST", "application/json", "{\"x\":111,\"z\":null,\"w\":[1,2],\"v\":{\"a\":1},\"y\":222}");

            Console.WriteLine("Now using the client formatter");
            ChannelFactory<ITestService> newFactory = new ChannelFactory<ITestService>(webBinding, new EndpointAddress(baseAddress + "/json"));
            newFactory.Endpoint.Behaviors.Add(new NewtonsoftJsonBehavior());
            ITestService newProxy = newFactory.CreateChannel();
            Console.WriteLine(newProxy.Add(444, 555));
            Console.WriteLine(newProxy.EchoPet(new Pet { Color = "gold", Id = 2, Markings = "Collie", Name = "Lassie" }));
            Console.WriteLine(newProxy.GetPerson());

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();
            host.Close();
            Console.WriteLine("Host closed");
        }
    }
}
