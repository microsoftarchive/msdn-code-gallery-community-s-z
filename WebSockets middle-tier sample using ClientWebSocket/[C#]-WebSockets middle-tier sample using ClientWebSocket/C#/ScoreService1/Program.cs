using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ScoreService1.ScoreSvcRepo;

namespace ScoreService1
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceId = "1"; 

            // Uri where service will be listening.
            string uri = String.Format("http://{0}:80/ScoreService{1}/", Environment.MachineName, serviceId);
            
            // Start the server to listen on the above Uri
            var server = new Server(); server.Start(uri);

            // Send a notification to the ScoreServiceRepo that this score service has 
            //  come up and the ScoreTickerApp can connect to it over websockets and get score updates
            ScoreSvcRepoClient proxy = new ScoreSvcRepoClient();
            proxy.AddToServiceRepoAsync(uri);
                        
            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
            
            // Send a notification to the ScoreServiceRepo that this score service has now gone offline. 
            proxy.RemoveFromServiceRepo(uri); 

            // Close the proxy instance. 
            proxy.Close(); 
        }
    }

    # region HttpListener based server
    class Server
    {
        public async void Start(string listenerPrefix)
        {
            // Start up the HttpListener on the passes Uri. 
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(listenerPrefix);
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                // Accept the HttpListenerContext
                HttpListenerContext listenerContext = await listener.GetContextAsync();

                // Check if this is for a websocket request
                if (listenerContext.Request.IsWebSocketRequest)
                {
                    ProcessRequest(listenerContext);
                }
                else
                {
                    // Since we are expecting WebSocket requests and this is not - send HTTP 400
                    listenerContext.Response.StatusCode = 400;
                    listenerContext.Response.Close();
                }
            }
        }

        private async void ProcessRequest(HttpListenerContext listenerContext)
        {
            WebSocketContext webSocketContext = null;

            try
            {
                // Accept the WebSocket request
                webSocketContext = await listenerContext.AcceptWebSocketAsync(subProtocol: null);
            }
            catch (Exception ex)
            {
                // If any error occurs then send HTTP Status 500
                listenerContext.Response.StatusCode = 500;
                listenerContext.Response.Close();
                Console.WriteLine("Exception : {0}", ex.Message);
                return;
            }

            // Accept the WebSocket connect. 
            WebSocket webSocket = webSocketContext.WebSocket;

            try
            {
                Random rand = new Random(1);
                while (webSocket.State == WebSocketState.Open)
                {
                    // As long as the WebSocket connection is open - continue sending the random score updates. 
                    string scoreUpdate = "Match A" + ":" + rand.Next(1, 50);
                    Console.WriteLine("Sending Score :" + scoreUpdate);
                    ArraySegment<byte> outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(scoreUpdate));
                    await webSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);

                    // Wait for some, before sending the next update
                    await Task.Delay(new TimeSpan(0, 0, 3));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : {0}", ex.Message);
            }

            finally
            {
                if (webSocket != null)
                {
                    webSocket.Dispose();
                }
            }
        }
    }
    # endregion 
}
