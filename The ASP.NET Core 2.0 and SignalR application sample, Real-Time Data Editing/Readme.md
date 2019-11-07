# The ASP.NET Core 2.0 and SignalR application sample, Real-Time Data Editing
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- SignalR
- ASP.NET SignalR
- AngularJS
- ASP.NET Core
- Angular 2
- Angular 1
## Topics
- SignalR
- ASP.NET SignalR
- AngularJS
- ASP.NET Core
- Angular 2
- Angular 1
## Updated
- 03/22/2018
## Description

<p>&nbsp;</p>
<p><span style="font-size:large"><a href="https://onedrive.live.com/?id=736F580A25E940F5%21286387&cid=736F580A25E940F5" target="_blank">Use this link for the short video demo</a>.</span></p>
<p>&nbsp;</p>
<h1><span style="color:#ff0000">The project updated to use ASP.NET Core 2.0 RTM and Angualr 4.2 with Visual Studio 2017 (Version 15.3.5 or higher)</span></h1>
<h1><span style="color:#ff0000">SignalR (alpha) for ASP.NET Core 2.0 is used.</span><span style="color:#ff0000"><br>
</span></h1>
<p><span style="font-size:small; text-decoration:underline"><strong>Please see this MSDN article for the additional information.</strong></span></p>
<p>&nbsp;</p>
<p><span style="color:#ff0000; font-size:medium; background-color:#ffffff"><strong>Also there is the ASP.NET Core project with SignalR 2.2.2 (The old version).</strong></span><span style="font-size:small; text-decoration:underline"><strong><br>
</strong></span></p>
<h1>Introduction</h1>
<p>This example demonstrates how you can&nbsp;use Visual Studio 2017&nbsp;for build ASP.NET Core 1.x/2.x web application. For&nbsp;additional information about ASP.NET Core and Visual Studio 2017 see
<a href="http://www.asp.net/vnext/overview/aspnet-vnext/getting-started-with-aspnet-vnext-and-visual-studio" target="_blank">
</a><a href="http://www.asp.net/vnext/overview/aspnet-vnext">ASP.NET Future Release</a> (Getting Started with ASP.NET vNext and Visual Studio &quot;14&quot;).</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p style="text-align:justify"><em>Wherein editing is done in real time. That is, users can instantly see the changes implemented by others. It is completely based on and meets the OWIN specification (Open Web Server Interface for. NET). This application created
 with using Visual Studio <em>2017</em> as ASP.NET Core application and uses SignalR and Angular 1/Angular 2 libraries. As far as the platform is related it uses Microsoft .NET Framework 4.6.x or .NET Core 2.0. It is designed to showcase the latest technology
 designed for building modern web applications. In this case, each component of the application is managed by users. This puts great flexibility and freedom of action.</em></p>
<h1><span>Building the Sample</span></h1>
<p><strong>There are special requirements and instructions for building the sample.</strong></p>
<p><strong>1. Download source code. </strong></p>
<p><strong>2. Install the <a href="https://www.microsoft.com/net/core#windowsvs2017" target="_blank">
latest version of .NET Core 2.0 SDK</a> (Visual Studio 2017 RTW Version 15.3.5 or newer).</strong></p>
<p><strong>&nbsp;<img id="180401" src="180401-2017-10-05_19-01-05.png" alt="" width="1552" height="1040"></strong></p>
<p><strong>3. Open project by Visual Studio 2017 and run it.</strong></p>
<p><img id="180247" src="180247-2017-10-03_13-23-54.png" alt=""></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RealTimeDataEditor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =&gt;
            {
                routes.MapHub&lt;ProductMessageHub&gt;(&quot;ProductMessageHub&quot;);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler(&quot;/Home/Error&quot;);
            }

            app.UseStaticFiles();

            app.UseMvc(routes =&gt;
            {
                routes.MapRoute(
                    name: &quot;default&quot;,
                    template: &quot;{controller=Home}/{action=Index}/{id?}&quot;);

                routes.MapSpaFallbackRoute(
                    name: &quot;spa-fallback&quot;,
                    defaults: new { controller = &quot;Home&quot;, action = &quot;Index&quot; });
            });
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Builder;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Hosting;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.Http;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNetCore.SpaServices.Webpack;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Extensions.Configuration;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Extensions.DependencyInjection;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RealTimeDataEditor&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Startup(IConfiguration&nbsp;configuration)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Configuration&nbsp;=&nbsp;configuration;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IConfiguration&nbsp;Configuration&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;add&nbsp;services&nbsp;to&nbsp;the&nbsp;container.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddSignalR();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;configure&nbsp;the&nbsp;HTTP&nbsp;request&nbsp;pipeline.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configure(IApplicationBuilder&nbsp;app,&nbsp;IHostingEnvironment&nbsp;env)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseSignalR(routes&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapHub&lt;ProductMessageHub&gt;(<span class="cs__string">&quot;ProductMessageHub&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(env.IsDevelopment())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseDeveloperExceptionPage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseWebpackDevMiddleware(<span class="cs__keyword">new</span>&nbsp;WebpackDevMiddlewareOptions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HotModuleReplacement&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseExceptionHandler(<span class="cs__string">&quot;/Home/Error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseStaticFiles();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseMvc(routes&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="cs__string">&quot;default&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;template:&nbsp;<span class="cs__string">&quot;{controller=Home}/{action=Index}/{id?}&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.MapSpaFallbackRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="cs__string">&quot;spa-fallback&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;controller&nbsp;=&nbsp;<span class="cs__string">&quot;Home&quot;</span>,&nbsp;action&nbsp;=&nbsp;<span class="cs__string">&quot;Index&quot;</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>For more information on Real Time Data Editor, see...<br>
</em></p>
