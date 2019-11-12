# WCF WebSocket Listener
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WCF WebSockets
## Topics
- WebSockets
## Updated
- 10/28/2012
## Description

<h1>Introduction</h1>
<p><em>Demonstrates how to implement native WebSocket based on WCF.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Websocket is protocol described as a party of HTML5 specification.</em> <em>
<a href="http://tools.ietf.org/html/rfc6455">http://tools.ietf.org/html/rfc6455</a>
<br>
<br>
It is mainly designed to be used in web. However, implementation of WebSocket<br>
requires always a server side implementation. If you are required to implement<br>
the server side you will have two choices (if you are using Microsoft<br>
technologies): </em></p>
<p><em>1. Implement WebSocket Server as </em><em><a href="http://developers.de/blogs/damir_dobric/archive/2012/01/29/websockets-in-asp-net-and-javascript.aspx">WebSocketHanlder
</a></em><em>in ASP.NET <br>
<br>
2. Implement WebSocketServer as a WCF WebService.</em><em><br>
<em><br>
This example demonstrates the second option. </em><br>
<br>
<em>That means if you have WebSocket consumers<br>
which are implemented on any kind of technology (For example JavaScript) they<br>
will be able to talk to your WebSocket server. <br>
<br>
If you are asking yourself which option you should implement, it is unfortunately<br>
not easy to answer this question. The general answer is &ldquo;it depends&rdquo;. If you want<br>
to provide service oriented architecture in your solution your choice should be<br>
WCF. However you should know that WCF based WebSocket listener is already an<br>
implementation of WebScoket which you can customize by implementing your own<br>
simple protocol on top of it.<br>
<br>
That means, you will never ever change the WCF contract of WebSocket, because this<br>
one is implicitly defined by WebSocket specification.<br>
<br>
All you will tune in the future is your own protocol implementation. That means<br>
there is not too much what you can reuse in WCF and SOA world. This is a reason<br>
why you could also implement the communication based on ASP.NET handler (option<br>
1).<br>
<br>
I will personally try always to implement WCF, because it is the best communication<br>
platform. Unfortunately if you have to extend your protocol highly based on<br>
HTTP features, ASP.NET handler might be easier option.</em></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Implementation&nbsp;of&nbsp;WCF&nbsp;host&nbsp;</span>&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ServiceModel.aspx" target="_blank" title="Auto generated link to System.ServiceModel">System.ServiceModel</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.ServiceModel.WebSockets;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Daenet.WcfWebSocketListener&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Demonstrate&nbsp;how&nbsp;to&nbsp;create&nbsp;the&nbsp;WebSocket&nbsp;in&nbsp;WCF.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;args&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;host&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebSocketHost&lt;MyWebSocketService&gt;(<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;ws://localhost:8080/daenetsocket&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;endpoint&nbsp;=&nbsp;host.AddWebSocketEndpoint();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Open();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Socket&nbsp;has&nbsp;been&nbsp;initialized.&nbsp;Press&nbsp;any&nbsp;key&nbsp;to&nbsp;exit.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;host.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Implementation&nbsp;of&nbsp;Service</span>&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.ServiceModel.WebSockets;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Web.WebSockets;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.WebSockets.aspx" target="_blank" title="Auto generated link to System.Net.WebSockets">System.Net.WebSockets</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Runtime.Serialization.aspx" target="_blank" title="Auto generated link to System.Runtime.Serialization">System.Runtime.Serialization</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ServiceModel.aspx" target="_blank" title="Auto generated link to System.ServiceModel">System.ServiceModel</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Script.Serialization.aspx" target="_blank" title="Auto generated link to System.Web.Script.Serialization">System.Web.Script.Serialization</a>;&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Daenet.WcfWebSocketListener&nbsp;
{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyWebSocketService&nbsp;:&nbsp;&nbsp;&nbsp;WebSocketService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;JavaScriptSerializer&nbsp;m_Ser&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JavaScriptSerializer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocketCollection&nbsp;x&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;WebSocketCollection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;WebSocketCollection&lt;MyWebSocketService&gt;&nbsp;m_Sessions&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;WebSocketCollection&lt;MyWebSocketService&gt;();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnMessage(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnMessage(message);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;msg&nbsp;=&nbsp;m_Ser.Deserialize&lt;Message&gt;(message);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_Sessions.Broadcast(String.Format(<span class="cs__string">&quot;{{\&quot;from\&quot;:\&quot;{0}\&quot;,\&quot;value\&quot;:\&quot;{1}\&quot;}}&quot;</span>,&nbsp;msg.Nick,&nbsp;msg.Value));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Message&nbsp;received:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnOpen()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_Sessions.Add(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnOpen();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Send(<span class="cs__string">&quot;\&quot;{value:'Hello'\&quot;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;New&nbsp;user&nbsp;joined.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Definition&nbsp;of&nbsp;Entity&nbsp;passed&nbsp;between&nbsp;client&nbsp;and&nbsp;server</span>&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Daenet.WcfWebSocketListener&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">enum</span>&nbsp;MessageType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Send,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Broadcast,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Join,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Leave&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MessageType&nbsp;Type&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Nick&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files<em>source </em></span></h1>
<ul>
<a href="http://code.msdn.microsoft.com/WCF-WebSocket-Listener-3adf403d/file/69907/2/WCF%20WebSocket%20Listener.zip">http://code.msdn.microsoft.com/WCF-WebSocket-Listener-3adf403d/file/69907/2/WCF%20WebSocket%20Listener.zip</a>
</ul>
<h1>More Information</h1>
<p><em><a href="http://developers.de/blogs/damir_dobric/archive/2012/01/29/websockets-in-asp-net-and-javascript.aspx">http://developers.de/blogs/damir_dobric/archive/2012/01/29/websockets-in-asp-net-and-javascript.aspx</a></em></p>
