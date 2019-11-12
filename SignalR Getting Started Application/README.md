# SignalR Getting Started Application
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET SignalR
## Topics
- Getting Started
## Updated
- 10/22/2013
## Description

<h1>Introduction</h1>
<p><em>This is the application created in the Getting Started with SignalR 2.0 tutorial, found at&nbsp;<a href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-getting-started-with-signalr-20">http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-getting-started-with-signalr-20</a>.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>After opening the project in Visual Studio 2013, open the Package Manager Console and click
<strong>Restore</strong>&nbsp;to install the required SignalR components.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>This tutorial introduces SignalR development by showing how to build a simple browser-based chat application. You will add the SignalR library to an empty ASP.NET web application, create a hub class for sending messages to clients, and create an HTML
 page that lets users send and receive chat messages. For a similar tutorial that shows how to create a chat application in MVC 4 using an MVC view, see&nbsp;</span><a href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-getting-started-with-signalr-20-and-mvc-5">Getting
 Started with SignalR 2.0 and MVC 5</a><span>.</span></p>
<p><em>This sample includes a SignalR hub that provides server functionality, an OWIN startup class that configures the SignalR hub's route, and a Javascript client that connects to the hub. &nbsp;</em></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.AspNet.SignalR.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.SignalR">Microsoft.AspNet.SignalR</a>;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRChat&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ChatHub&nbsp;:&nbsp;Hub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;the&nbsp;broadcastMessage&nbsp;method&nbsp;to&nbsp;update&nbsp;clients.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.broadcastMessage(name,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
[assembly:&nbsp;OwinStartup(<span class="cs__keyword">typeof</span>(SignalRChat.Startup))]&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRChat&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Any&nbsp;connection&nbsp;or&nbsp;hub&nbsp;wire&nbsp;up&nbsp;and&nbsp;configuration&nbsp;should&nbsp;go&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.MapSignalR();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ChatHub.cs - This is a implementation of a SignalR hub, which provides the server functionality for the application.</em>
</li><li><em><em>Startup.cs - This is an implementation of an OWIN startup class, which configures the SignalR route when the application starts.</em></em>
</li><li><em><em>Default.html - This is the web page which hosts the SignalR JavaScript client, which interacts with the server.</em></em>
</li></ul>
<h1>More Information</h1>
<p>For more information on SignalR and the Getting Started tutorial, see http://www.asp.net/signalr.</p>
