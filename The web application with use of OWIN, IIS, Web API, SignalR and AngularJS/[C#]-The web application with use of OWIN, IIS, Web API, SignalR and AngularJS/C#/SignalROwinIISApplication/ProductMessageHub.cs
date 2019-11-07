using System.Threading;
using Microsoft.AspNet.SignalR;
using SignalROwinIISApplication.DomainModel;

namespace SignalROwinIISApplication
{
    public class ProductMessageHub : Hub
    {
        public void HandleProductMessage(string receivedString)
        {
            string responseString = string.Empty;

            bool dataProcessedSuccessfully = 
                ProductMessageHandler.HandleMessage(receivedString, ref responseString);

            Thread.Sleep(1000);

            if (dataProcessedSuccessfully)
            {
                Clients.All.handleProductMessage(responseString);
            }
            else
            {
                Clients.Caller.handleProductMessage(responseString);
            }
        }
    }
}
