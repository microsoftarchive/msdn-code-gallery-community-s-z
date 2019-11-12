using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SimpleUsersOnLine
{
    public class UsersOnLine : Hub
    {
        static List<string> users=new List<string>();

        public override System.Threading.Tasks.Task OnConnected()
        {
            string clientId = GetClientId();
            
            if (users.IndexOf(clientId)==-1) {
                users.Add(clientId);
            }

            ShowUsersOnLine();
            
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            string clientId = GetClientId();
            if (users.IndexOf(clientId) == -1)
            {
                users.Add(clientId);
            }

            ShowUsersOnLine();
        
            return base.OnReconnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            string clientId = GetClientId();
            
            if (users.IndexOf(clientId) > -1)
            {
                users.Remove(clientId);
            }

            ShowUsersOnLine();

            return base.OnDisconnected();
        }


        private string GetClientId() {
            string clientId = "";
            if (!(Context.QueryString["clientId"] == null))
            {
                //clientId passed from application
                clientId = Context.QueryString["clientId"].ToString();
            }

            if (clientId.Trim() == "")
            {
                //default clientId: connectionId
                clientId = Context.ConnectionId;
            }
            return clientId;
        
        }
        public void Log(string message) {
            Clients.All.log(message);
        }
        public void ShowUsersOnLine()
        {
            Clients.All.showUsersOnLine(users.Count);
        }
    }
}