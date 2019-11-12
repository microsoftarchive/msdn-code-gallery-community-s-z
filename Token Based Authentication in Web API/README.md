# Token Based Authentication in Web API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET Web API
- ASP.NET Web API 2
## Topics
- Security
## Updated
- 01/21/2018
## Description

<h1>Introduction</h1>
<p><strong>Authentication&nbsp;</strong>is a vital process in system programming. Authentication means verifying the user who is accessing the system. Today we are using modern devices that have different types of Apps or software and sometimes we directly
 access the website from browser. To access this application, we probably need to pass our credentials and these systems verify it. If you are valid user then it will allow accessing the system otherwise not.</p>
<p>We have available different types of authentication in .Net programming like Windows Authentication, Forms Authentication, Claim Based Authentication, Token Based Authentication etc. Today we will discuss about Token Based Authentication in detail.</p>
<p>Token Based Authentication is not very different from other authentication mechanism but yes, it is more secure, more reliable and makes your system loosely coupled. It will be a better choice to create REST API using token-based authentication, if your
 API reached to broad range of devices like mobiles, tablets and traditional desktops.</p>
<p>In token-based authentication, you pass your credentials [user name and password], which go to authentication server. Server verifies your credentials and if it is a valid user then it will return a signed token to client system, which has expiration time.
 Client can store this token to locally using any mechanism like local storage, session storage etc and if client makes any other call to server for data then it does not need to pass its credentials every time. Client can directly pass token to server, which
 will be validated by server and if token is valid then you will able to access your data.</p>
<h2>Using the code</h2>
<p>In this demonstration, we will use&nbsp;<strong>Web API</strong>&nbsp;as a service and&nbsp;<strong>Angular JS</strong>&nbsp;as a client. So, let me create dummy database &ldquo;Test&rdquo; and two tables &ldquo;Users&rdquo; and &ldquo;Employee&rdquo; respectively.
 Users table will store the user related information like name, username and password. Employee table is basically for dummy data. You can use following SQL scripts to generate this database and tables.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">CREATE&nbsp;DATABASE&nbsp;TEST&nbsp;
GO&nbsp;
&nbsp;
USE&nbsp;TEST&nbsp;
GO&nbsp;
&nbsp;
CREATE&nbsp;TABLE&nbsp;Users(Id&nbsp;INT&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;PRIMARY&nbsp;KEY,&nbsp;Name&nbsp;varchar(<span class="js__num">255</span>)&nbsp;NOT&nbsp;NULL,&nbsp;UserName&nbsp;varchar(<span class="js__num">50</span>),&nbsp;Password&nbsp;varchar(<span class="js__num">50</span>))&nbsp;
INSERT&nbsp;INTO&nbsp;[TEST].[dbo].[Users](Name,&nbsp;UserName,&nbsp;Password)&nbsp;VALUES(<span class="js__string">'Mukesh&nbsp;Kumar'</span>,&nbsp;<span class="js__string">'Mukesh'</span>,&nbsp;<span class="js__string">'Mukesh@123'</span>);&nbsp;
&nbsp;
CREATE&nbsp;TABLE&nbsp;Employees(Id&nbsp;INT&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;PRIMARY&nbsp;KEY,&nbsp;Name&nbsp;varchar(<span class="js__num">255</span>)&nbsp;NOT&nbsp;NULL,&nbsp;Address&nbsp;varchar(<span class="js__num">500</span>))&nbsp;
INSERT&nbsp;INTO&nbsp;Employees&nbsp;(Name,&nbsp;Address)&nbsp;VALUES(<span class="js__string">'Mukesh&nbsp;Kumar'</span>,&nbsp;<span class="js__string">'New&nbsp;Delhi'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;Employees&nbsp;(Name,&nbsp;Address)&nbsp;VALUES(<span class="js__string">'John&nbsp;Right'</span>,&nbsp;<span class="js__string">'England'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;Employees&nbsp;(Name,&nbsp;Address)&nbsp;VALUES(<span class="js__string">'Chris&nbsp;Roy'</span>,&nbsp;<span class="js__string">'France'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;Employees&nbsp;(Name,&nbsp;Address)&nbsp;VALUES(<span class="js__string">'Anand&nbsp;Mahajan'</span>,&nbsp;<span class="js__string">'Canada'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;Employees&nbsp;(Name,&nbsp;Address)&nbsp;VALUES(<span class="js__string">'Prince&nbsp;Singh'</span>,&nbsp;<span class="js__string">'India'</span>)</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Move to next and create a service that will implement token-based authentication. So, going to create a Web API project and for client application we will use Angular JS&nbsp;from where we will pass user credentials.</p>
<p>To create Web API project, first open&nbsp;<strong>Visual Studio 2015&nbsp;</strong>and go to File menu and select&nbsp;<strong>New&nbsp;</strong>and then&nbsp;<strong>Project</strong>. It will open a New Project windows, select Web from Installed Template
 and then from right pane, choose &ldquo;<strong>Asp.Net Web Application</strong>&rdquo;. Provide the name like &ldquo;<strong>EmployeeService</strong>&rdquo; and click to&nbsp;<strong>OK</strong>.</p>
<p>Next windows will provide you options to choose web application template. Here you need to choose Web API with No Authentication and click to OK. Therefore, your application is ready to run.</p>
<p>Before moving next, to implement token-based authentication, we have to add following packages as a references from&nbsp;<strong>NuGet Package Manager</strong>. So, just right click on references in solution and select Manage NuGet Packages. It will open
 a NuGet Package Manager windows, you can search these packages one by one from search box in Browse tab. Once these packages are able to find out in NuGet click to Install. After Installtion, these packages will be available in references.</p>
<ol>
<li><strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.aspx" target="_blank" title="Auto generated link to Microsoft.Owin">Microsoft.Owin</a></strong> </li><li><strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.Host.SystemWeb.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Host.SystemWeb">Microsoft.Owin.Host.SystemWeb</a></strong> </li><li><strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.Security.OAuth.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Security.OAuth">Microsoft.Owin.Security.OAuth</a></strong> </li><li><strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.Security.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Security">Microsoft.Owin.Security</a></strong> </li><li><strong><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.AspNet.Identity.Owin.aspx" target="_blank" title="Auto generated link to Microsoft.AspNet.Identity.Owin">Microsoft.AspNet.Identity.Owin</a></strong> </li></ol>
<p>In this demonstration, we will not use Global.asax file. So,&nbsp;first, delete the&nbsp;<strong>Global.asax</strong>&nbsp;from solution and add new class &ldquo;<strong>Startup.cs</strong>&rdquo; at the same location of Global.asax file and add following
 code.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;EmployeeService.Provider;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.aspx" target="_blank" title="Auto generated link to Microsoft.Owin">Microsoft.Owin</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Owin.Security.OAuth.aspx" target="_blank" title="Auto generated link to Microsoft.Owin.Security.OAuth">Microsoft.Owin.Security.OAuth</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Http.aspx" target="_blank" title="Auto generated link to System.Web.Http">System.Web.Http</a>;&nbsp;
&nbsp;
[assembly:&nbsp;OwinStartup(<span class="cs__keyword">typeof</span>(EmployeeService.Startup))]&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;EmployeeService&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureAuth(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;OAuthOptions&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OAuthAuthorizationServerOptions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AllowInsecureHttp&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TokenEndpointPath&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PathString(<span class="cs__string">&quot;/token&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AccessTokenExpireTimeSpan&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="cs__number">20</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Provider&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SimpleAuthorizationServerProvider()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseOAuthBearerTokens(OAuthOptions);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseOAuthAuthorizationServer(OAuthOptions);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.UseOAuthBearerAuthentication(<span class="cs__keyword">new</span>&nbsp;OAuthBearerAuthenticationOptions());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpConfiguration&nbsp;config&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpConfiguration();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebApiConfig.Register(config);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConfigureAuth(app);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GlobalConfiguration.Configure(WebApiConfig.Register);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;</pre>
</div>
</div>
</div>
<p>In the above code, you can see, we are using&nbsp;<strong>OWIN&nbsp;</strong>[Open Web Interface for .Net] that is an interface between your web server and web application. So, it works as a middle ware in applications, which process your incoming request
 and validate it. Here we are using SimpleAuthorizationServerProvider, which is nothing but a class which validate user based on their credentials. You can find this class code at the last.</p>
<p>Now it&rsquo;s time to create a model where we can perform database operation like fetching the user information based on credentials and employees data. We can use here different ways to get data like Repository pattern with Unit of work or Dapper. But
 we want to make this example simple and keep the main focus on Token Based Authentication only.&nbsp;So, right click on solution and Click to Add and then New Item and choose&nbsp;<strong>Ado.Net Entity Model.</strong></p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information on X, see .</em></p>
<p><a href="http://www.mukeshkumar.net/articles/web-api/token-based-authentication-in-web-api" target="_blank">http://www.mukeshkumar.net/articles/web-api/token-based-authentication-in-web-api</a></p>
<p><a href="http://www.mukeshkumar.net/articles/angularjs/web-api-token-based-authentication-with-angular-js">http://www.mukeshkumar.net/articles/angularjs/web-api-token-based-authentication-with-angular-js</a></p>
<p><em>.</em></p>
<p><em><br>
</em></p>
