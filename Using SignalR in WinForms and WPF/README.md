# Using SignalR in WinForms and WPF
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- WPF
- WinForms
- ASP.NET SignalR
## Topics
- SignalR clients and servers in WinForms and WPF
## Updated
- 07/11/2014
## Description

<h1>Introduction</h1>
<p><em>This sample shows how to create a SignalR server and client in WinForms and WPF. A Web client is also included. The application shows how to start and connect to the SignalR service without blocking the UI thread, and how to update the UI in response
 to messages and connection events.</em></p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em>Build the application (Ctrl&#43;Shift&#43;B). The package manager will add the SignalR self-host package to the server projects, the SignalR JavaScript client package (in the Scripts directory) to the web client project, and the SignalR .NET client package
 to the WinForms and WPF client projects. The solution may prompt you to download the missing NuGet packages.</em>
</li></ul>
<ul>
<li><em>Run the application. In either the WinForms or WPF server, click <strong>
Start</strong>&nbsp;to start the SignalR service (Starting both servers will throw an error). After the server starts (in about 10 seconds), enter a username in the WinForms and WPF clients and click Connect, and refresh the page in the JavaScript client (and
 provide a user name when prompted) to connect.&nbsp;</em> </li><li><em>Once servers are started and clients are connected, messages sent from one client will appear in all connected clients.</em>
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:20px; font-weight:bold">&nbsp;</span><em>This sample contains five projects: Two server projects (WinForms and WPF), and three client projects (WinForms, WPF, and a JavaScript web client.)</em></p>
<p><em>The following code sample shows how to start a server asynchronously in WinForms and WPF: &nbsp;&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;<span class="cs__com">///&nbsp;Calls&nbsp;the&nbsp;StartServer&nbsp;method&nbsp;with&nbsp;Task.Run&nbsp;to&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;not&nbsp;block&nbsp;the&nbsp;UI&nbsp;thread.&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ButtonStart_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WriteToConsole(<span class="cs__string">&quot;Starting&nbsp;server...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ButtonStart.Enabled&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Task.Run(()&nbsp;=&gt;&nbsp;StartServer());&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Starts&nbsp;the&nbsp;server&nbsp;and&nbsp;checks&nbsp;for&nbsp;error&nbsp;thrown&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;when&nbsp;another&nbsp;server&nbsp;is&nbsp;already&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;running.&nbsp;This&nbsp;method&nbsp;is&nbsp;called&nbsp;asynchronously&nbsp;</span>&nbsp;
<span class="cs__com">///&nbsp;from&nbsp;Button_Start.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;StartServer()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SignalR&nbsp;=&nbsp;WebApp.Start(ServerURI);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(TargetInvocationException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteToConsole(<span class="cs__string">&quot;Server&nbsp;failed&nbsp;to&nbsp;start.&nbsp;A&nbsp;server&nbsp;is&nbsp;already&nbsp;running&nbsp;on&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ServerURI);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Re-enable&nbsp;button&nbsp;to&nbsp;let&nbsp;user&nbsp;try&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//to&nbsp;start&nbsp;server&nbsp;again</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Invoke((Action)(()&nbsp;=&gt;&nbsp;ButtonStart.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Invoke((Action)(()&nbsp;=&gt;&nbsp;ButtonStop.Enabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WriteToConsole(<span class="cs__string">&quot;Server&nbsp;started&nbsp;at&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ServerURI);&nbsp;
}</pre>
</div>
</div>
</div>
<p><em>The following code sample shows how to handle server events in WinForms:</em><em>&nbsp;</em><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Echoes&nbsp;messages&nbsp;sent&nbsp;using&nbsp;the&nbsp;Send&nbsp;message&nbsp;by&nbsp;calling&nbsp;the</span>&nbsp;
<span class="cs__com">///&nbsp;addMessage&nbsp;method&nbsp;on&nbsp;the&nbsp;client.&nbsp;Also&nbsp;reports&nbsp;to&nbsp;the&nbsp;console</span>&nbsp;
<span class="cs__com">///&nbsp;when&nbsp;clients&nbsp;connect&nbsp;and&nbsp;disconnect.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyHub&nbsp;:&nbsp;Hub&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.addMessage(name,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnConnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Program.MainForm.WriteToConsole(<span class="cs__string">&quot;Client&nbsp;connected:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Context.ConnectionId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnConnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnDisconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Program.MainForm.WriteToConsole(<span class="cs__string">&quot;Client&nbsp;disconnected:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Context.ConnectionId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><em>&nbsp;</em><em>The following code sample shows how to handle server events in WPF:</em><em>&nbsp;</em><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Echoes&nbsp;messages&nbsp;sent&nbsp;using&nbsp;the&nbsp;Send&nbsp;message&nbsp;by&nbsp;calling&nbsp;the</span>&nbsp;
<span class="cs__com">///&nbsp;addMessage&nbsp;method&nbsp;on&nbsp;the&nbsp;client.&nbsp;Also&nbsp;reports&nbsp;to&nbsp;the&nbsp;console</span>&nbsp;
<span class="cs__com">///&nbsp;when&nbsp;clients&nbsp;connect&nbsp;and&nbsp;disconnect.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyHub&nbsp;:&nbsp;Hub&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.addMessage(name,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnConnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;Application.Current.Dispatcher&nbsp;to&nbsp;access&nbsp;UI&nbsp;thread&nbsp;from&nbsp;outside&nbsp;the&nbsp;MainWindow&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Current.Dispatcher.Invoke(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((MainWindow)Application.Current.MainWindow).WriteToConsole(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Client&nbsp;connected:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Context.ConnectionId));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnConnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&nbsp;OnDisconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Use&nbsp;Application.Current.Dispatcher&nbsp;to&nbsp;access&nbsp;UI&nbsp;thread&nbsp;from&nbsp;outside&nbsp;the&nbsp;MainWindow&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Current.Dispatcher.Invoke(()&nbsp;=&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((MainWindow)Application.Current.MainWindow).WriteToConsole(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Client&nbsp;disconnected:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;Context.ConnectionId));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><em>&nbsp;</em><em>The following code sample shows how to handle incoming messages in a SignalR client in WinForms:</em></p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Handle&nbsp;incoming&nbsp;event&nbsp;from&nbsp;server:&nbsp;use&nbsp;Invoke&nbsp;to&nbsp;write&nbsp;to&nbsp;console&nbsp;from&nbsp;SignalR's&nbsp;thread</span>&nbsp;
HubProxy.On&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;(<span class="cs__string">&quot;AddMessage&quot;</span>,&nbsp;(name,&nbsp;message)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Invoke((Action)(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RichTextBoxConsole.AppendText(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format({<span class="cs__number">0</span>}:&nbsp;{<span class="cs__number">1</span>}&quot;&nbsp;&#43;&nbsp;Environment.NewLine,&nbsp;name,&nbsp;message))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;))&nbsp;
);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>The following code sample shows how to handle incoming messages&nbsp;in a SignalR client&nbsp; in WPF</em>:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Handle&nbsp;incoming&nbsp;event&nbsp;from&nbsp;server:&nbsp;use&nbsp;Invoke&nbsp;to&nbsp;write&nbsp;to&nbsp;console&nbsp;from&nbsp;SignalR's&nbsp;thread</span>&nbsp;
HubProxy.On&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;(<span class="cs__string">&quot;AddMessage&quot;</span>,&nbsp;(name,&nbsp;message)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Dispatcher.Invoke(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RichTextBoxConsole.AppendText(String.Format(<span class="cs__string">&quot;{0}:&nbsp;{1}\r&quot;</span>,&nbsp;name,&nbsp;message))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
);</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="endscriptcode"></div>
</div>
<em>
<div class="endscriptcode">
<div class="endscriptcode"><span style="font-size:2em">Source Code Files</span></div>
</div>
</em></div>
<ul>
<li><em>WebClient/Default.html: The web client (this is the same client as is used in the Getting Started tutorial).&nbsp;</em>
</li><li><em>WinFormsClient/WinFormsClient.cs: The WinForms client, showing how to connect to a SignalR service asynchronously, and how to access UI controls from SignalR events.</em>
</li><li><em>WinFormsServer/WinFormsServer.cs: The WinForms server, showing how to start a SignalR service asynchronously, and how to access UI controls when SignalR messages arrive.</em>
</li><li><em>WPFClient/MainWindow.xaml.cs: The WPF client,&nbsp;<em>showing how to connect to a SignalR service asynchronously, and how to access UI controls from SignalR events.</em></em>
</li><li><em><em>WPFServer/MainWindow.xaml.cs:&nbsp;<em>The WPF server, showing how to start a SignalR service asynchronously, and how to access UI controls when SignalR messages arrive.</em></em></em>
</li></ul>
