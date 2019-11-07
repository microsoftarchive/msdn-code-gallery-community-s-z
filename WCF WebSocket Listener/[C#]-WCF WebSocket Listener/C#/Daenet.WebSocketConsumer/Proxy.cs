using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.WebSocketConsumer
{
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "Daenet.WebSocketConsumer.IWebSocket",
        CallbackContract = typeof(Daenet.WebSocketConsumer.IWebSocketCallback))]
    public interface IWebSocket
    {        
       
         [System.ServiceModel.OperationContractAttribute(IsOneWay = true, 
             Action = " http://schemas.microsoft.com/2011/02/websockets/onmessage")]
          void OnMessage(string message);

         [System.ServiceModel.OperationContractAttribute(IsOneWay = true, 
             Action = " http://schemas.microsoft.com/2011/02/websockets/onopen")]
         void OnOpen();     
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWebSocketCallback
    {

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, 
            Action = "*")]
        void Send(Message message);
    }
}
