# The web application with use of OWIN, IIS, Web API, SignalR and AngularJS
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C#
- ASP.NET
- IIS
- jQuery
- .NET Framework
- Javascript
- ASP.NET Web API
- ASP.NET 4.5
- SignalR
## Topics
- ASP.NET
- ASP.NET Web API
- Web API
- SignalR
- ASP.NET SignalR
- AngularJS
- OWIN
## Updated
- 10/17/2017
## Description

<h1>Introduction</h1>
<p><em>This application (SignalROwinIISApplication) allows multiple users to edit data table simultaneously. It is built of the latest technology such as Web API, SignalR, AngularJS. All components of the application are controlled by the user. This feature
 provides great space for flexibility.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>There aren't special requirements or instructions for building the sample. But this application use
<a href="http://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970" target="_blank">
Microsoft Code Contracts </a>library&nbsp; for .NET.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Wherein editing is done in real time. That is, users can instantly see the changes implemented by others. It is completely based on and meets the OWIN specification (Open Web Server Interface for. NET).&nbsp; This application uses such&nbsp;&nbsp; ready-made
 libraries from Microsoft as Web API, SignalR as well as AngularJS library. This application uses IIS as OWIN based host. All the backend work is executed&nbsp; in an IIS. As far as the platform is related it uses Microsoft .NET Framework 4.5.1. It is designed
 to showcase the latest technology designed for building modern web applications. In this case, each component of the application is managed by users. This puts great flexibility and freedom of action.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.Formatting.aspx" target="_blank" title="Auto generated link to System.Net.Http.Formatting">System.Net.Http.Formatting</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Http.aspx" target="_blank" title="Auto generated link to System.Web.Http">System.Web.Http</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json.Serialization;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SignalROwinIISApplication;&nbsp;
&nbsp;
[assembly:&nbsp;Microsoft.Owin.OwinStartup(<span class="cs__keyword">typeof</span>(Startup))]&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalROwinIISApplication&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;appBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appBuilder.MapSignalR();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;httpConfiguration&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpConfiguration();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpConfiguration.Formatters.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpConfiguration.Formatters.Add(<span class="cs__keyword">new</span>&nbsp;JsonMediaTypeFormatter());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpConfiguration.Formatters.JsonFormatter.SerializerSettings&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;JsonSerializerSettings&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContractResolver&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CamelCasePropertyNamesContractResolver()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;httpConfiguration.Routes.MapHttpRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="cs__string">&quot;DefaultApi&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routeTemplate:&nbsp;<span class="cs__string">&quot;api/{controller}/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id&nbsp;=&nbsp;RouteParameter.Optional&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appBuilder.UseWebApi(httpConfiguration);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em><em>For more information on application, <a href="http://www.msdr.ru/57/" target="_blank">
see my blog</a>.</em></em></p>
