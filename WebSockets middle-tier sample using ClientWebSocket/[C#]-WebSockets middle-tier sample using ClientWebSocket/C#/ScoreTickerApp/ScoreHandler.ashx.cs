using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace ScoreTickerApp
{
    /// <summary>
    /// Summary description for ScoreHandler
    /// </summary>
    public class ScoreHandler : IHttpHandler
    {
        // Receive buffer size
        private const int receiveBufferSize = 256;

        // Keep a record of the scores received from Score services
        static Hashtable scoreRecords = new Hashtable();
        
        // Collection to keep the WebSocket connections to the Score services
        private List<ClientWebSocket> scoreServiceWebSocketCollection = new List<ClientWebSocket>(); 
        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(HandleWebSocketRequest);
            }
            else
            {
                context.Response.StatusCode = 400; 
            }
        }

        private async Task HandleWebSocketRequest(AspNetWebSocketContext wsContext)
        {
            WebSocket browserWebSocket = wsContext.WebSocket;
            scoreServiceWebSocketCollection.Clear(); 

            while (browserWebSocket.State == WebSocketState.Open)
            {
                if (scoreServiceWebSocketCollection.Count > 0)
                {
                    foreach (ClientWebSocket clientWebSocket in scoreServiceWebSocketCollection)
                    {
                        await Receive(clientWebSocket);
                    }
                    ArraySegment<byte> outputBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(GetCurrentScores()));
                    await browserWebSocket.SendAsync(outputBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    await ConnectToScoreServices(); 
                }
            }
        }

        public async Task ConnectToScoreServices()
        {
            List<Uri> ScoreServiceRepoUris = new List<Uri>(); 
            ScoreSvcRepo.ScoreSvcRepoClient proxy = new ScoreSvcRepo.ScoreSvcRepoClient();
            string[] localScoreServiceRepoUris = proxy.GetScoreServicesRepoInfo();

            foreach (string uri in localScoreServiceRepoUris)
            {
                Uri localUri = new Uri((uri.Replace("http:", "ws:")).Replace("https:", "wss:"));
                if (!ScoreServiceRepoUris.Contains(localUri))
                {
                    ScoreServiceRepoUris.Add(localUri);
                }
            }
            
            try
            {
                foreach (Uri scoreServiceUri in ScoreServiceRepoUris)
                {
                    ClientWebSocket scoreServiceWebSocket = new ClientWebSocket();
                    await scoreServiceWebSocket.ConnectAsync(scoreServiceUri, CancellationToken.None);
                    scoreServiceWebSocketCollection.Add(scoreServiceWebSocket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception = {0}", ex.Message);
            }
        }

        private async Task Receive(ClientWebSocket scoreServiceWebSocket)
        { 
            byte[] buffer = new byte[receiveBufferSize];

            try
            {
                var result = await scoreServiceWebSocket.ReceiveAsync
                    (new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await scoreServiceWebSocket.CloseAsync
                        (WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    AddToScoreTable((new UTF8Encoding()).GetString(buffer));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception = {0}", ex.Message);
            }
        }

        private void AddToScoreTable(string result)
        {
            // Place the score received in our stored data structure 
            if (result != null)
            {
                string[] GameScore = result.Split(':');
                if (GameScore.Length >= 2)
                {
                    string game = GameScore[0]; string score = GameScore[1];
                    if (scoreRecords.ContainsKey(game))
                    {
                        scoreRecords[game] = score;
                    }
                    else
                    {
                        scoreRecords.Add(game, score);
                    }
                }
            }
        }

        private static string GetCurrentScores()
        {
            // Form the combined string from the scores received 
            //  from all the score services to send back to the browser
            StringBuilder scoreRecordsToReturn = new StringBuilder(); 
            foreach (DictionaryEntry entry in scoreRecords)
            {
                scoreRecordsToReturn.Append(entry.Key + ":" + entry.Value + ";"); 
            }
            return scoreRecordsToReturn.ToString(); 
        }
    }
}