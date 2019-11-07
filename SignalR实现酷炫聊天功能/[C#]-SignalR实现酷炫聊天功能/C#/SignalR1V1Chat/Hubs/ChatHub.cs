using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalR1V1Chat.Models;

namespace SignalR1V1Chat.Hubs
{
    public class ChatHub : Hub
    {
        // 静态属性
        public static List<UserInfo> OnlineUsers =  new List<UserInfo>(); // 在线用户列表

        /// <summary>
        /// 登录连线
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名</param>
        public void Connect(string userId, string userName)
        {
            var connnectId = Context.ConnectionId;

            if (OnlineUsers.Count(x => x.ConnectionId == connnectId) == 0)
            {
                if (OnlineUsers.Any(x => x.UserId == userId))
                {
                    var items = OnlineUsers.Where(x => x.UserId == userId).ToList();
                    foreach (var item in items)
                    {
                        Clients.AllExcept(connnectId).onUserDisconnected(item.ConnectionId, item.UserName);
                    }
                    OnlineUsers.RemoveAll(x => x.UserId == userId);
                }

                //添加在线人员
                OnlineUsers.Add(new UserInfo
                {
                    ConnectionId = connnectId,
                    UserId = userId,
                    UserName = userName,
                    LastLoginTime = DateTime.Now
                });
            }

            // 所有客户端同步在线用户
            Clients.All.onConnected(connnectId, userName, OnlineUsers);
        }


        /// <summary>
        /// 发送私聊
        /// </summary>
        /// <param name="toUserId">接收方用户连接ID</param>
        /// <param name="message">内容</param>
        public void SendPrivateMessage(string toUserId, string message)
        {
            var fromUserId = Context.ConnectionId;

            var toUser = OnlineUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = OnlineUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {   
                // send to 
                Clients.Client(toUserId).receivePrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                // Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }
            else
            {
                //表示对方不在线
                Clients.Caller.absentSubscriber();
            }
        }

        /// <summary>
        /// 断线时调用
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = OnlineUsers.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);

            // 判断用户是否存在,存在则删除
            if (user == null) return base.OnDisconnected(stopCalled);

            Clients.All.onUserDisconnected(user.ConnectionId, user.UserName);   //调用客户端用户离线通知
            // 删除用户
            OnlineUsers.Remove(user);


            return base.OnDisconnected(stopCalled);
        }
    }
}