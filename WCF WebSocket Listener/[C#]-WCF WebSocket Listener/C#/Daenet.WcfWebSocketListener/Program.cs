using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceModel.WebSockets;

namespace Daenet.WcfWebSocketListener
{
    class Program
    {
        /// <summary>
        /// Demonstrate how to create the WebSocket in WCF.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var host = new WebSocketHost<MyWebSocketService>(new Uri("ws://localhost:8080/daenetsocket"));
            var endpoint = host.AddWebSocketEndpoint();
            
            host.Open();

            Console.WriteLine("Socket has been initialized. Press any key to exit.");

            Console.ReadLine();

            host.Close();
        }
    }
}



//var host = new WebSocketHost<MyWebSocketService>();
//host.AddServiceEndpoint(typeof(), new BasicHttpBinding(), 
//    new HttpClientCredentialType://localhost:8080/echo);
