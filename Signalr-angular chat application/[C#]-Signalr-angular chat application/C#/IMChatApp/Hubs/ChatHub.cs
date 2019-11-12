using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using IMChatApp.Models;
using Microsoft.AspNet.SignalR.Hubs;
using System.Diagnostics;
using Newtonsoft;

namespace IMChatApp.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        // ChatAppEntities db = new ChatAppEntities();

        static bool isFirstRequest = true;
        public void say(string message)
        {
            Clients.All.hello();
            Trace.WriteLine(message);
        }
        static readonly HashSet<string> Rooms = new HashSet<string>();
        static List<user> loggedInUsers = new List<user>();
        //static List<Room> roomsWiseUser = new List<Room>();
        public string Login(string name)
        {           
            var user = new user { name = name, ConnectionId = Context.ConnectionId, age = 20, avator = "", id = 1, sex = "Male", memberType = "Re+gistered", fontColor = "red", status = Status.Online.ToString() };
            Clients.Caller.rooms(Rooms.ToArray());
            Clients.Caller.setInitial(Context.ConnectionId, name);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(loggedInUsers);
            loggedInUsers.Add(user);
            Clients.Caller.getOnlineUsers(sJSON);
            Clients.Others.newOnlineUser(user);
            return name;
        } 

        public void SendPrivateMessage(string toUserId, string message)
        {
            string fromUserId = Context.ConnectionId;
            var toUser = loggedInUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = loggedInUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);
            if (toUser != null && fromUser != null)
            {              
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.name, message);
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.name, message);
            }
        }
        public void UpdateStatus(string status)
        {
            string userId = Context.ConnectionId;
            loggedInUsers.FirstOrDefault(x => x.ConnectionId == userId).status =status;
            //var fromUser = loggedInUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);                          
            Clients.Others.statusChanged(userId,status);
            
        }
        public void UserTyping(string connectionId, string msg)
        {
            var id = Context.ConnectionId;
            Clients.Client(connectionId).isTyping(id, msg);
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = loggedInUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                loggedInUsers.Remove(item); // list = 
                var id = Context.ConnectionId;            
                Clients.Others.newOfflineUser(item);
            }
            return base.OnDisconnected(true);
        }
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (loggedInUsers.Count(x => x.ConnectionId == id) == 0)
            {
                loggedInUsers.Add(new user { ConnectionId = id, name = userName });              
                Clients.Caller.onConnected(id, userName, loggedInUsers); 
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }       
    }
}