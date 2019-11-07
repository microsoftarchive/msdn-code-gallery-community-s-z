# SignalR实现酷炫聊天功能
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET SignalR
## Topics
- ASP.NET SignalR
- 即时通信
## Updated
- 04/04/2016
## Description

<h1>介绍</h1>
<p><span style="white-space:pre"></span>使用Asp.net SignalR实现酷炫端对端聊天功能</p>
<h1>编译示例</h1>
<p>直接编译运行即可</p>
<p><span style="font-size:20px"><strong>描述</strong></span><strong style="font-size:20px"></strong></p>
<p><span style="white-space:pre"></span>Asp.net SignalR是微软为实现实时通信的一个类库。一般情况下，SignalR会使用JavaScript的长轮询(long polling)的方式来实现客户端和服务器通信，随着Html5中WebSockets出现，SignalR也支持WebSockets通信。另外SignalR开发的程序不仅仅限制于宿主在IIS中，也可以宿主在任何应用程序，包括控制台，客户端程序和Windows服务等，另外还支持Mono，这意味着它可以实现跨平台部署在Linux环境下。</p>
<p><span><span style="white-space:pre"></span>在SignalR中，每一个客户端为标记其唯一性，SignalR都会分配它一个ConnnectionId，这样我们就可以通过ConnnectionId来找到特定的客户端了。这样，我们在向某个客户端发送消息的时候，除了要将消息传入，也需要将发送给对方的ConnectionId输入，这样服务端就能根据传入的ConnectionId来转发对应的消息给对应的客户端了。这样也就完成了端对端聊天的功能。另外，如果用户如果不在线的话，服务端可以把消息保存到数据库中，等对应的客户端上线的时候，再从数据库中查看该客户端是否有消息需要推送，有的话，从数据库取出数据，将该数据推送给该客户端。（不过这点，服务端缓存数据的功能本篇博文没有实现，在这里介绍就是让大家明白QQ一个实现原理）。</span></p>
<p><span>下面我们来梳理下端对端聊天功能的实现思路：</span></p>
<ol>
<li><span>客户端登入的时候记录下客户端的ConnnectionId，并将用户加入到一个静态数组中，该数据为了记录所有在线用户。</span> </li><li><span>用户可以点击在线用户中的用户聊天，在发送消息的时候，需要将ConnectionId一并传入到服务端。</span> </li><li><span>服务端根据传入的消息内容和ConnectionId调用Clients.Client(connnection).sendMessage方法来进行转发到对应的客户端。</span>
</li></ol>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ChatHub : Hub
    {
        // 静态属性
        public static List&lt;UserInfo&gt; OnlineUsers =  new List&lt;UserInfo&gt;(); // 在线用户列表

        /// &lt;summary&gt;
        /// 登录连线
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;userId&quot;&gt;用户Id&lt;/param&gt;
        /// &lt;param name=&quot;userName&quot;&gt;用户名&lt;/param&gt;
        public void Connect(string userId, string userName)
        {
            var connnectId = Context.ConnectionId;

            if (OnlineUsers.Count(x =&gt; x.ConnectionId == connnectId) == 0)
            {
                if (OnlineUsers.Any(x =&gt; x.UserId == userId))
                {
                    var items = OnlineUsers.Where(x =&gt; x.UserId == userId).ToList();
                    foreach (var item in items)
                    {
                        Clients.AllExcept(connnectId).onUserDisconnected(item.ConnectionId, item.UserName);
                    }
                    OnlineUsers.RemoveAll(x =&gt; x.UserId == userId);
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


        /// &lt;summary&gt;
        /// 发送私聊
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;toUserId&quot;&gt;接收方用户连接ID&lt;/param&gt;
        /// &lt;param name=&quot;message&quot;&gt;内容&lt;/param&gt;
        public void SendPrivateMessage(string toUserId, string message)
        {
            var fromUserId = Context.ConnectionId;

            var toUser = OnlineUsers.FirstOrDefault(x =&gt; x.ConnectionId == toUserId);
            var fromUser = OnlineUsers.FirstOrDefault(x =&gt; x.ConnectionId == fromUserId);

            if (toUser != null &amp;&amp; fromUser != null)
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

        /// &lt;summary&gt;
        /// 断线时调用
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;stopCalled&quot;&gt;&lt;/param&gt;
        /// &lt;returns&gt;&lt;/returns&gt;
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = OnlineUsers.FirstOrDefault(u =&gt; u.ConnectionId == Context.ConnectionId);

            // 判断用户是否存在,存在则删除
            if (user == null) return base.OnDisconnected(stopCalled);

            Clients.All.onUserDisconnected(user.ConnectionId, user.UserName);   //调用客户端用户离线通知
            // 删除用户
            OnlineUsers.Remove(user);


            return base.OnDisconnected(stopCalled);
        }
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ChatHub&nbsp;:&nbsp;Hub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;静态属性</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;UserInfo&gt;&nbsp;OnlineUsers&nbsp;=&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;UserInfo&gt;();&nbsp;<span class="cs__com">//&nbsp;在线用户列表</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;登录连线</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;userId&quot;&gt;用户Id&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;userName&quot;&gt;用户名&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Connect(<span class="cs__keyword">string</span>&nbsp;userId,&nbsp;<span class="cs__keyword">string</span>&nbsp;userName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;connnectId&nbsp;=&nbsp;Context.ConnectionId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(OnlineUsers.Count(x&nbsp;=&gt;&nbsp;x.ConnectionId&nbsp;==&nbsp;connnectId)&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(OnlineUsers.Any(x&nbsp;=&gt;&nbsp;x.UserId&nbsp;==&nbsp;userId))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;items&nbsp;=&nbsp;OnlineUsers.Where(x&nbsp;=&gt;&nbsp;x.UserId&nbsp;==&nbsp;userId).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;items)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.AllExcept(connnectId).onUserDisconnected(item.ConnectionId,&nbsp;item.UserName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnlineUsers.RemoveAll(x&nbsp;=&gt;&nbsp;x.UserId&nbsp;==&nbsp;userId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//添加在线人员</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnlineUsers.Add(<span class="cs__keyword">new</span>&nbsp;UserInfo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConnectionId&nbsp;=&nbsp;connnectId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserId&nbsp;=&nbsp;userId,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserName&nbsp;=&nbsp;userName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastLoginTime&nbsp;=&nbsp;DateTime.Now&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;所有客户端同步在线用户</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.onConnected(connnectId,&nbsp;userName,&nbsp;OnlineUsers);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;发送私聊</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;toUserId&quot;&gt;接收方用户连接ID&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;message&quot;&gt;内容&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SendPrivateMessage(<span class="cs__keyword">string</span>&nbsp;toUserId,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fromUserId&nbsp;=&nbsp;Context.ConnectionId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;toUser&nbsp;=&nbsp;OnlineUsers.FirstOrDefault(x&nbsp;=&gt;&nbsp;x.ConnectionId&nbsp;==&nbsp;toUserId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fromUser&nbsp;=&nbsp;OnlineUsers.FirstOrDefault(x&nbsp;=&gt;&nbsp;x.ConnectionId&nbsp;==&nbsp;fromUserId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(toUser&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;fromUser&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;send&nbsp;to&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.Client(toUserId).receivePrivateMessage(fromUserId,&nbsp;fromUser.UserName,&nbsp;message);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;send&nbsp;to&nbsp;caller&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Clients.Caller.sendPrivateMessage(toUserId,&nbsp;fromUser.UserName,&nbsp;message);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//表示对方不在线</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.Caller.absentSubscriber();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;断线时调用</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;stopCalled&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnDisconnected(<span class="cs__keyword">bool</span>&nbsp;stopCalled)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;OnlineUsers.FirstOrDefault(u&nbsp;=&gt;&nbsp;u.ConnectionId&nbsp;==&nbsp;Context.ConnectionId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;判断用户是否存在,存在则删除</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(user&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected(stopCalled);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.onUserDisconnected(user.ConnectionId,&nbsp;user.UserName);&nbsp;&nbsp;&nbsp;<span class="cs__com">//调用客户端用户离线通知</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;删除用户</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnlineUsers.Remove(user);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected(stopCalled);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>更多信息</h1>
<p>Hub.Clients 属性：<a href="https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hub.clients(v=vs.111).aspx">https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hub.clients(v=vs.111).aspx</a></p>
<p>HubCallerContext 类：<a href="https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hubs.hubcallercontext(v=vs.111).aspx">https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hubs.hubcallercontext(v=vs.111).aspx</a></p>
<p>HubConnectionContext 类：<a href="https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hubs.hubconnectioncontext(v=vs.111).aspx">https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.hubs.hubconnectioncontext(v=vs.111).aspx</a></p>
