# SignalR Self-Host Sample
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- SignalR
- OWIN self-hosting
## Topics
- SignalR Self-Host
## Updated
- 04/18/2014
## Description

<h1>Introduction</h1>
<p><em><em>This is the application created in the&nbsp;</em><a title="SignalR Self-Host" href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-signalr-20-self-host" target="_blank">SignalR Self-Host</a> tutorial.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>After opening the project in Visual Studio 2013, open the Package Manager Console and click&nbsp;<strong>Restore</strong>&nbsp;to install the required SignalR components.</em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span>A SignalR server is usually hosted in an ASP.NET application in IIS, but it can also be self-hosted (such as in a console application or Windows service) using the self-host library. This library, like all of SignalR 2.0, is built on OWIN (</span><a href="http://owin.org/">Open
 Web Interface for .NET</a><span>). OWIN defines an abstraction between .NET web servers and web applications. OWIN decouples the web application from the server, which makes OWIN ideal for self-hosting a web application in your own process, outside of IIS.</span>&nbsp;&nbsp;</em></p>
<p>Reasons for not hosting in IIS include:</p>
<ul>
<li>Environments where IIS is not available or desirable, such as an existing server farm without IIS.
</li><li>The performance overhead of IIS needs to be avoided. </li><li>SignalR functionality is to be added to an exising application that runs in a Windows Service, Azure worker role, or other process.
</li></ul>
<p>If a solution is being developed as self-host for performance reasons, it's recommended to also test the application hosted in IIS to determine the performance benefit.</p>
<p>This tutorial contains the following sections:</p>
<ul>
<li><a href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-signalr-20-self-host#server">Creating the server</a>
</li><li><a href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-signalr-20-self-host#js">Accessing the server with a JavaScript client</a>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.AspNet.SignalR.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.SignalR">Microsoft.AspNet.SignalR</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Owin.Hosting.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Hosting">Microsoft.Owin.Hosting</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Owin.Cors.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Cors">Microsoft.Owin.Cors</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRSelfHost&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;will&nbsp;*ONLY*&nbsp;bind&nbsp;to&nbsp;localhost,&nbsp;if&nbsp;you&nbsp;want&nbsp;to&nbsp;bind&nbsp;to&nbsp;all&nbsp;addresses</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;use&nbsp;http://*:8080&nbsp;to&nbsp;bind&nbsp;to&nbsp;all&nbsp;addresses.&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;See&nbsp;http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;for&nbsp;more&nbsp;information.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;<span class="cs__string">&quot;http://localhost:8080&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(WebApp.Start(url))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Server&nbsp;running&nbsp;on&nbsp;{0}&quot;</span>,&nbsp;url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseCors(CorsOptions.AllowAll);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.MapSignalR();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MyHub&nbsp;:&nbsp;Hub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.addMessage(name,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program.cs: Contains the Program, Startup, and MyHub classes.</em> </li><li><em><em>Default.html: The JavaScript client.</em></em> </li></ul>
<h1>More Information</h1>
<p><em><span>For more information on SignalR and the Getting Started tutorial, see http://www.asp.net/signalr.</span></em></p>
