using Microsoft.ServiceModel.WebSockets;
using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;


namespace Daenet.WcfWebSocketListener
{

    public class MyWebSocketService :   WebSocketService
    {
        private JavaScriptSerializer m_Ser = new JavaScriptSerializer();

        WebSocketCollection x = new WebSocketCollection();
        static WebSocketCollection<MyWebSocketService> m_Sessions = 
            new WebSocketCollection<MyWebSocketService>();


        
        public override void OnMessage(string message)
        {
            base.OnMessage(message);

            var msg = m_Ser.Deserialize<Message>(message);

            m_Sessions.Broadcast(String.Format("{{\"from\":\"{0}\",\"value\":\"{1}\"}}", msg.Nick, msg.Value));

            Console.WriteLine("Message received: " + message);
        }


        public override void OnOpen()
        {
            m_Sessions.Add(this);
            
            base.OnOpen();

            this.Send("\"{value:'Hello'\"");

            Console.WriteLine("New user joined.");

        }
    }
}
