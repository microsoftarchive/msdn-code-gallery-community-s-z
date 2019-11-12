using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.WebSocketConsumer
{
    public class WebSocketCallback : IWebSocketCallback
    {
        public void Send(System.ServiceModel.Channels.Message message)
        {
            Console.WriteLine();
        }
    }
}
