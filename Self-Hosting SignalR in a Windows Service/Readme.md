# Self-Hosting SignalR in a Windows Service
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Windows Service
- OWIN self-hosting
- SignalR 2.0
## Topics
- Self-hosting SignalR in a Windows service
## Updated
- 07/07/2014
## Description

<h1>Introduction</h1>
<p><em>This application shows how to use a self-hosted SignalR server in a Windows Service rather than a console application. See
<a title="Tutorial: SignalR Self-Host" href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-signalr-20-self-host" target="_blank">
SignalR Self-Host</a>&nbsp;for the original application. To create your own application based on this sample, add your application's functionality as methods of the MyHub class. You can change the startup identity and service name of the Windows service in
 the &nbsp;ProjectInstaller.cs file.</em></p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em>Build the application (Ctrl&#43;Shift&#43;B). The package manager will add the SignalR self-host package to the service project, and the SignalR JavaScript client package (in the Scripts directory) to the web client project. The solution may prompt you to download
 the missing NuGet packages.</em> </li><li><em>Install the Windows Service from an elevated Visual Studio developer command prompt, in SignalRWindowsService\bin\debug:&nbsp;<br>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>
<pre class="hidden">installutil signalrwindowsservice.exe</pre>
<div class="preview">
<pre class="windowsshell">installutil&nbsp;signalrwindowsservice.exe</pre>
</div>
</div>
</div>
</em></li><li>
<div class="endscriptcode"><em>Enter the credentials for the user account you want the service to run under (to run under a service account such as LocalService instead of a user account, open
<strong>ProjectInstaller.cs</strong> in the designer, select <strong>serviceProcessInstaller1</strong>, open the
<strong>Properties</strong> window, change the <strong>Account</strong>&nbsp;property to the account you wish to use, and rebuild the solution.) This account will need to be a member of the Adminsitrator group in order to call MapSignalR() to map the route
 to the application.</em></div>
</li><li>
<div class="endscriptcode"><em>Open the <strong>Services</strong> snapin (run <strong>
services.msc</strong>). Find the <strong>SignalRChat</strong>&nbsp;service. Start the service.</em></div>
</li><li>
<div class="endscriptcode"><em>Run the web application (<strong>Client</strong>) from Visual Studio (F5)</em>.</div>
</li><li>
<div class="endscriptcode"><em>The application will open a web page showing the SignalR chat window.&nbsp;</em></div>
</li><li>
<div class="endscriptcode"><em>A prompt will appear for your user name</em></div>
</li><li>
<div class="endscriptcode"><em>Enter a name in the prompt to be used for your chat messages</em></div>
</li><li>
<div class="endscriptcode"><em>Copy the window URL into another browser window.</em></div>
</li><li>
<div class="endscriptcode"><em>Enter a name in the new prompt.</em></div>
</li><li>
<div class="endscriptcode"><em>Messages entered into one window will appear in the other.</em></div>
</li><li>
<div class="endscriptcode"><em>To remove the service, enter the following in an elevated Visual Studio Developer command prompt:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>
<pre class="hidden">installutil -u signalrwindowsservice.exe</pre>
<div class="preview">
<pre class="windowsshell">installutil&nbsp;<span class="windowsshell__commandext">-u</span>&nbsp;signalrwindowsservice.exe</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
&nbsp;</em></div>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample consists of the following classes and pages:</em></p>
<ul>
<li><em>The Windows service and startup program (SignalRChat.cs and Program.cs). The Windows Service duplicates the functionality of the hub in the Getting Started tutorials (echoing sent messages to all clients); the startup program contains the logic for
 starting the service.</em> </li><li><em>The OWIN startup class (Startup). The Configuration method is called by the OWIN middleware to configure the service (to use Cross-Origin Resource Sharing), and to map incoming HTTP requests to the running SignalR application. Add any additional OWIN
 configuration for your application here, such as additional startup tasks, configuring OWIN error handling, etc. See
<a href="http://www.asp.net/signalr/overview/signalr-20/hubs-api/hubs-api-guide-server#handleErrors">
How to Handle Errors in the Hub Class</a>&nbsp;for more information.</em> </li><li><em>The SignalR hub (MyHub). The hub contains a single method, which broadcasts any incoming message to all connected clients. &nbsp;To build a SignalR service application based on this sample, replace the Send method with methods that provide your application's
 functionality.</em> </li><li><em>The service installer (ProjectInstaller.cs). The installer is created by Visual Studio. This installer uses a named user account to run the service; to change the account used, open the Properties page for the &nbsp;serviceProcessInstaller1 component,
 and change the Account property to LocalService, NetworkService, or LocalSystem. To change the name of the service as it appears in the Services snap-in, change the ServiceName property of serviceInstaller1.</em>
</li><li><em>The web client (Default.htm, Web.config). This is the same web client as is used in the Getting Started tutorials.</em>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.ServiceProcess;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRWindowsService.Startup))]
namespace SignalRWindowsService
{
    public partial class SignalRChat : ServiceBase
    {
        IDisposable SignalR;

        public SignalRChat()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            if (!System.Diagnostics.EventLog.SourceExists(&quot;SignalRChat&quot;))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    &quot;SignalRChat&quot;, &quot;Application&quot;);
            }
            eventLog1.Source = &quot;SignalRChat&quot;;
            eventLog1.Log = &quot;Application&quot;;

            eventLog1.WriteEntry(&quot;In OnStart&quot;);
            string url = &quot;http://localhost:8080&quot;;
            SignalR = WebApp.Start(url);
            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry(&quot;In OnStop&quot;);
            SignalR.Dispose();
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ServiceProcess;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Owin.Hosting;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Owin.Cors;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Owin;&nbsp;
&nbsp;
[assembly:&nbsp;OwinStartup(<span class="cs__keyword">typeof</span>(SignalRWindowsService.Startup))]&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRWindowsService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;SignalRChat&nbsp;:&nbsp;ServiceBase&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IDisposable&nbsp;SignalR;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SignalRChat()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnStart(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!System.Diagnostics.EventLog.SourceExists(<span class="cs__string">&quot;SignalRChat&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.EventLog.CreateEventSource(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;SignalRChat&quot;</span>,&nbsp;<span class="cs__string">&quot;Application&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;eventLog1.Source&nbsp;=&nbsp;<span class="cs__string">&quot;SignalRChat&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;eventLog1.Log&nbsp;=&nbsp;<span class="cs__string">&quot;Application&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;eventLog1.WriteEntry(<span class="cs__string">&quot;In&nbsp;OnStart&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;<span class="cs__string">&quot;http://localhost:8080&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SignalR&nbsp;=&nbsp;WebApp.Start(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnStop()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;eventLog1.WriteEntry(<span class="cs__string">&quot;In&nbsp;OnStop&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SignalR.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
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
<li><em>SignalRChat.cs: The service, OWIN startup, and hub classes.</em> </li><li><em><em>SignalRChat.Designer.cs: The event log and service application installer</em></em>
</li><li><em><em>Default.htm: The Web client.&nbsp;</em></em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on creating a self-hosted SignalR application, see&nbsp;<a title="Tutorial: SignalR Self-Host" href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-signalr-20-self-host" target="_blank">Tutorial:
 SignalR Self-Host</a>.</em></p>
<p><em>For more information on creating a Windows service, see&nbsp;<a title="Walkthrough: Creating a Windows Service in the component designer" href="http://msdn.microsoft.com/en-us/library/zt39148a(v=vs.110).aspx" target="_blank">Walkthrough: Creating a Windows
 Service Application in the Component Designer</a>.</em></p>
