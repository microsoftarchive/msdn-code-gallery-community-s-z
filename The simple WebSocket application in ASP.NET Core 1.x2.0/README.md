# The simple WebSocket application in ASP.NET Core 1.x/2.0
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- WebSockets
- ASP.NET Core
- ASP.NET Core WebSockets
## Topics
- ASP.NET Core
- WebSockets in ASP.NET Core
## Updated
- 03/22/2018
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p style="text-align:justify"><em>The project intends to show a simple example of using WebSockets in ASP.NET Core.
<a href="https://en.wikipedia.org/wiki/WebSocket">WebSocket</a> is a protocol that enables two-way persistent communication channels over TCP connections. It is used for applications such as chat, stock tickers, games, anywhere you want real-time functionality
 in a web application.<strong>&nbsp;</strong><em>&nbsp;</em> The project gives opportunity to have an idea about how to use the WebSockets in ASP.NET Core&nbsp;platform. As an example, we perform a web-based application that sends plain text on the client's
 browser using the WebSocket. This project demonstrates how &nbsp;to work with WebSockets at a low level. For that work you can use any modern browser. As for browsers from Microsoft, it requires a browser IE 10 or higher. IIS will need 8 or higher version
 (lower versions do not support the WebSockets) in order to be sure that the application will work on the server. Let me remind you that the protocol WebSocket is only available in Windows 8 and Windows Server 2012, as well as in newer versions (Windows 8.1/10
 and Windows Server 2012 R2/2016), as implemented in the form of low-level unmanaged IIS 8.x/10 module.&nbsp;<em>Or you should use &quot;Kestrel<strong>&nbsp;</strong>&quot; as a web server&nbsp;on Windows 7 or Windows 2008 R2.</em><strong>&nbsp;</strong><em>&nbsp;</em></em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span id="result_box" lang="en"><span class="hps"><em>To buid and</em></span><em>
</em><span class="hps"><em>run application we</em></span><em> </em><span class="hps"><em>need</em></span><em>
</em><span class="hps"><em>installed</em></span><em> </em><span class="hps"><em>Visual Studio</em></span><em>
</em><span class="hps"><em>2017 RTW (Version 15.3.5 or newer)</em></span><span class="hps"><em>.</em></span><em>
</em><span class="hps"><em>Also</em></span><em>, </em><span class="hps"><em>as the operating system</em></span><em>
</em><span class="hps"><em>must be</em></span><em> </em><span class="hps"><em>running</em></span><em>
</em><span class="hps"><em>at least Windows</em></span><em> </em><span class="hps"><em>8 or</em></span><em>
</em><span class="hps"><em>Windows Server 2012 if you are using IIS/WebListener.</em></span><em>
</em><span class="hps"><em>Earlier</em></span><em> </em><span class="hps"><em>versions do not support</em></span><em>
</em><span class="hps"><em>the <span class="hps"><em>Web</em></span><em>S</em><span class="hps"><em>ockets</em></span><strong>&nbsp;</strong><em>&nbsp;</em>&nbsp;protocol</em></span><span class="hps"><em>. Or you should use &quot;Kestrel<strong>&nbsp;</strong><em>&nbsp;</em>&quot;&nbsp;on
 Windows 7 or Windows 2008 R2.</em></span></span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>&nbsp;<img id="180994" src="https://i1.code.msdn.s-msft.com/the-simple-websocket-0dd65479/image/file/180994/1/2017-10-17_20-06-07.png" alt="" width="1574" height="1039"></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;MsdrRu.SimpleWebSocketApp.NETCore&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebSocketRequestHandlerMiddleware&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;RequestDelegate&nbsp;next;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;WebSocketRequestHandlerMiddleware(RequestDelegate&nbsp;next)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.next&nbsp;=&nbsp;next;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&nbsp;Invoke(HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context.WebSockets.IsWebSocketRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocket&nbsp;webSocket&nbsp;=&nbsp;await&nbsp;context.WebSockets.AcceptWebSocketAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;WebSocketRequestHandler.Handle(context,&nbsp;webSocket);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;the&nbsp;next&nbsp;delegate/middleware&nbsp;in&nbsp;the&nbsp;pipeline</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;<span class="cs__keyword">this</span>.next(context);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebSocketRequestHandlerMiddlewareExtensions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IApplicationBuilder&nbsp;UseWebSocketRequestHandlerMiddleware(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>&nbsp;IApplicationBuilder&nbsp;builder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;builder.UseMiddleware&lt;WebSocketRequestHandlerMiddleware&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
