using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.WebSocketConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            DuplexChannelFactory<IWebSocket> factory =
                new DuplexChannelFactory<IWebSocket>(new InstanceContext(new WebSocketCallback()),
                    "socket");
          
            IWebSocket ws = factory.CreateChannel();

            ws.OnOpen();
            
            ws.OnMessage("Hello");
            
        }
    }
}
