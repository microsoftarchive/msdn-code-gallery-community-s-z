# SignalR 快速入门
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET SignalR
## Topics
- SignalR
## Updated
- 04/02/2016
## Description

<h1>介绍</h1>
<p>Asp.net SignalR是微软为实现实时通信的一个类库。一般情况下，SignalR会使用JavaScript的长轮询(long polling)的方式来实现客户端和服务器通信，随着Html5中WebSockets出现，SignalR也支持WebSockets通信。另外SignalR开发的程序不仅仅限制于宿主在IIS中，也可以宿主在任何应用程序，包括控制台，客户端程序和Windows服务等，另外还支持Mono，这意味着它可以实现跨平台部署在Linux环境下。</p>
<p>SignalR内部有两类对象：</p>
<ol>
<li>Http持久连接(Persisten Connection)对象：用来解决长时间连接的功能。还可以由客户端主动向服务器要求数据，而服务器端不需要实现太多细节，只需要处理PersistentConnection 内所提供的五个事件：OnConnected, OnReconnected, OnReceived, OnError 和 OnDisconnect 即可。
</li><li>Hub（集线器）对象：用来解决实时(realtime)信息交换的功能，服务端可以利用URL来注册一个或多个Hub，只要连接到这个Hub，就能与所有的客户端共享发送到服务器上的信息，同时服务端可以调用客户端的脚本。
</li></ol>
<p>SignalR将整个信息的交换封装起来，客户端和服务器都是使用JSON来沟通的，在服务端声明的所有Hub信息，都会生成JavaScript输出到客户端，.NET则依赖Proxy来生成代理对象，而Proxy的内部则是将JSON转换成对象。</p>
<p>本示例主要介绍了SignalR的快速入门，其中包括SignalR在Asp.net MVC 和WPF中的应用，更多介绍参考博文：<a href="http://www.cnblogs.com/zhili/p/SignalRQuickStart.html">http://www.cnblogs.com/zhili/p/SignalRQuickStart.html</a></p>
<h1>运行示例</h1>
<p><span>&nbsp;</span>直接通过右键项目，选择调试，启动一个新实例来运行项目</p>
<p><span><strong>描述</strong></span></p>
<p>&nbsp;</p>
<p>通过第二部分的介绍，相信大家对Asp.net SignalR有了一个初步的了解，接下来通过两个例子来让大家加深对SignalR运行机制的理解。第一个例子就是在Web端如何使用SignalR来实现广播消息。</p>
<ol>
<li>使用Visual Studio 2013，创建一个MVC工程 </li><li>通过Nuget安装SignalR包。右键引用-》选择管理Nuget程序包-》在出现的窗口中输入SignalR来找到SignalR包进行安装。 </li><li>安装SignalR成功后，SignalR库的脚本将被添加进Scripts文件夹下。具体如下图所示： </li></ol>
<p><img src="-383187-20160330231731988-1853447818.png" alt=""></p>
<p>4. 向项目中添加一个SignalR集线器(v2)并命名为ServerHub。</p>
<p><img src="-383187-20160330232023582-590617526.png" alt=""></p>
<p>5. 将下面代码填充到刚刚创建的ServerHub类中。</p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Microsoft.AspNet.SignalR; 
using Microsoft.AspNet.SignalR.Hubs; 
using System; 
 
namespace SignalRQuickStart 
{public class ServerHub : Hub 
    { 
        private static readonly char[] Constant = 
        { 
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
            'w', 'x', 'y', 'z', 
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 
            'W', 'X', 'Y', 'Z' 
        }; 
 
        /// &lt;summary&gt; 
        /// 供客户端调用的服务器端代码 
        /// &lt;/summary&gt; 
        /// &lt;param name=&quot;message&quot;&gt;&lt;/param&gt; 
        public void Send(string message) 
        { 
            var name = GenerateRandomName(4); 
 
            // 调用所有客户端的sendMessage方法 
            Clients.All.sendMessage(name, message); 
        } 
 
        /// &lt;summary&gt; 
        /// 产生随机用户名函数 
        /// &lt;/summary&gt; 
        /// &lt;param name=&quot;length&quot;&gt;用户名长度&lt;/param&gt; 
        /// &lt;returns&gt;&lt;/returns&gt; 
        public static string GenerateRandomName(int length) 
        { 
            var newRandom = new System.Text.StringBuilder(62); 
            var rd = new Random(); 
            for (var i = 0; i &lt; length; i&#43;&#43;) 
            { 
                newRandom.Append(Constant[rd.Next(62)]); 
            } 
            return newRandom.ToString(); 
        } 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR.Hubs;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRQuickStart&nbsp;&nbsp;
{<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ServerHub&nbsp;:&nbsp;Hub&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;<span class="cs__keyword">char</span>[]&nbsp;Constant&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">'0'</span>,&nbsp;<span class="cs__string">'1'</span>,&nbsp;<span class="cs__string">'2'</span>,&nbsp;<span class="cs__string">'3'</span>,&nbsp;<span class="cs__string">'4'</span>,&nbsp;<span class="cs__string">'5'</span>,&nbsp;<span class="cs__string">'6'</span>,&nbsp;<span class="cs__string">'7'</span>,&nbsp;<span class="cs__string">'8'</span>,&nbsp;<span class="cs__string">'9'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">'a'</span>,&nbsp;<span class="cs__string">'b'</span>,&nbsp;<span class="cs__string">'c'</span>,&nbsp;<span class="cs__string">'d'</span>,&nbsp;<span class="cs__string">'e'</span>,&nbsp;<span class="cs__string">'f'</span>,&nbsp;<span class="cs__string">'g'</span>,&nbsp;<span class="cs__string">'h'</span>,&nbsp;<span class="cs__string">'i'</span>,&nbsp;<span class="cs__string">'j'</span>,&nbsp;<span class="cs__string">'k'</span>,&nbsp;<span class="cs__string">'l'</span>,&nbsp;<span class="cs__string">'m'</span>,&nbsp;<span class="cs__string">'n'</span>,&nbsp;<span class="cs__string">'o'</span>,&nbsp;<span class="cs__string">'p'</span>,&nbsp;<span class="cs__string">'q'</span>,&nbsp;<span class="cs__string">'r'</span>,&nbsp;<span class="cs__string">'s'</span>,&nbsp;<span class="cs__string">'t'</span>,&nbsp;<span class="cs__string">'u'</span>,&nbsp;<span class="cs__string">'v'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">'w'</span>,&nbsp;<span class="cs__string">'x'</span>,&nbsp;<span class="cs__string">'y'</span>,&nbsp;<span class="cs__string">'z'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">'A'</span>,&nbsp;<span class="cs__string">'B'</span>,&nbsp;<span class="cs__string">'C'</span>,&nbsp;<span class="cs__string">'D'</span>,&nbsp;<span class="cs__string">'E'</span>,&nbsp;<span class="cs__string">'F'</span>,&nbsp;<span class="cs__string">'G'</span>,&nbsp;<span class="cs__string">'H'</span>,&nbsp;<span class="cs__string">'I'</span>,&nbsp;<span class="cs__string">'J'</span>,&nbsp;<span class="cs__string">'K'</span>,&nbsp;<span class="cs__string">'L'</span>,&nbsp;<span class="cs__string">'M'</span>,&nbsp;<span class="cs__string">'N'</span>,&nbsp;<span class="cs__string">'O'</span>,&nbsp;<span class="cs__string">'P'</span>,&nbsp;<span class="cs__string">'Q'</span>,&nbsp;<span class="cs__string">'R'</span>,&nbsp;<span class="cs__string">'S'</span>,&nbsp;<span class="cs__string">'T'</span>,&nbsp;<span class="cs__string">'U'</span>,&nbsp;<span class="cs__string">'V'</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">'W'</span>,&nbsp;<span class="cs__string">'X'</span>,&nbsp;<span class="cs__string">'Y'</span>,&nbsp;<span class="cs__string">'Z'</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;供客户端调用的服务器端代码&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;message&quot;&gt;&lt;/param&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;name&nbsp;=&nbsp;GenerateRandomName(<span class="cs__number">4</span>);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;调用所有客户端的sendMessage方法&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.sendMessage(name,&nbsp;message);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;产生随机用户名函数&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;length&quot;&gt;用户名长度&lt;/param&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GenerateRandomName(<span class="cs__keyword">int</span>&nbsp;length)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;newRandom&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;System.Text.StringBuilder(<span class="cs__number">62</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;rd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(var&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;length;&nbsp;i&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newRandom.Append(Constant[rd.Next(<span class="cs__number">62</span>)]);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;newRandom.ToString();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;
<p>6. 创建一个<strong>Startup</strong>类，如果开始创建MVC项目的时候没有更改身份验证的话，这个类会默认添加的，如果已有就不需要重复添加了。按照如下代码更新Startup类。</p>
<p>7. 在Home控制器中创建一个Home Action方法</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class HomeController : Controller 
    { 
        public ActionResult Index() 
        { 
            return View(); 
        } 
 
        public ActionResult About() 
        { 
            ViewBag.Message = &quot;Your application description page.&quot;; 
 
            return View(); 
        } 
 
        public ActionResult Contact() 
        { 
            ViewBag.Message = &quot;Your contact page.&quot;; 
 
            return View(); 
        } 
 
        public ActionResult Chat() 
        { 
            return View(); 
        } 
    }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;About()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Message&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;application&nbsp;description&nbsp;page.&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Contact()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Message&nbsp;=&nbsp;<span class="cs__string">&quot;Your&nbsp;contact&nbsp;page.&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Chat()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>更多信息</h1>
<p><em><a href="https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.client.hubs.hubconnection%28v=vs.111%29.aspx?f=255&MSPPError=-2147217396">HubConnection 类:&nbsp;https://msdn.microsoft.com/zh-cn/library/microsoft.aspnet.signalr.client.hubs.hubconnection%28v=vs.111%29.aspx?f=255&amp;MSPPError=-2147217396&nbsp;</a>&nbsp;</em></p>
</div>
