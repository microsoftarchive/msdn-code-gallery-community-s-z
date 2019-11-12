# Sample MVC4/WCF and EF Code First .NET 4.5. Domain design
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- WCF
- Visual Studio 2010
- jQuery
- Entity Framework
- .NET Framework 4.0
- C# Language
- HTML5
- ASP.NET MVC 4
- Visual Studio 2012
- .NET 4.5
## Topics
- C#
- WCF
- ASP.NET
- Architecture and Design
- ASP.NET MVC
- jQuery
- Web Services
- Javascript
- Entity Framework
- Image manipulation
- Getting Started
- .NET 4
- Imaging
- Generic C# resuable code
- Image Optimization
- Software Architecture
- Web Architecture
## Updated
- 06/13/2013
## Description

<h1>Introduction</h1>
<p><span style="background-color:#ffffff"><em>This sample provides basic infrastructure for MVC application with WCF and EF Code first support. All communications in this application are done through the WCF services without service references. There are no
 ties to the EF in MVC at all. Application has an example of storing and displaying images in database with replication on file system for better performance. Common design patterns are used:
<span style="background-color:#ffffff">Repository, Unit Of Work, MVC, Service Locator</span></em></span></p>
<p><span style="background-color:#ffffff"><em><span style="background-color:#ffff99"><span style="background-color:#ffffff"><strong>In this scenario I didn&rsquo;t want my WEB client to know anything about Entity Framework. Please not that there is not Membership
 provider as well.&nbsp;</strong></span></span></em></span><span style="background-color:#ffffff"><span style="background-color:#ffff99"><span style="background-color:#ffffff">Authentication is done in similar way, but without dependency on Membership Provider.
 You may change this if you want to have use regular MS Membership provider. Domain objects will support that structure.</span></span></span></p>
<h1><span>Building the Sample</span></h1>
<p><strong><span style="color:#ff0000; background-color:#ffffff">Important!</span> Please download all required NuGet packages.
</strong></p>
<p>The sample requires Visual Studio 2010/2012, .net 4.5 and SQL Server.&nbsp;To build and seed the database run integration unit test method
<span style="background-color:#ffff00">CreateAndSeedDatabaseTest </span></p>
<ul>
<li><span style="background-color:#ffffff">Login: <strong>sysadmin </strong></span></li><li><span style="background-color:#ffffff">Password: <strong>Virtue2013!</strong></span>
</li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Main advantages:</em></p>
<ul>
<li>Basic Application layout </li><li>Loosely coupled components </li><li>Service calls without service references </li><li>EF Code First </li><li>Remove Circular references in Entities for WCF serialization </li><li>Use of common design patterns </li><li>No knowledge of EF in MVC </li><li>Use of Areas </li><li>Dynamic Ajax calls with partial views <br>
<em></em></li></ul>
<p><em>Basic layout for distributed application.</em></p>
<p><em>&nbsp;<img id="83647" src="83647-solution.png" alt="" width="304" height="263">&nbsp;</em></p>
<p>Client MVC application has knowledge of service interfaces and domain objects.<br>
Domain objects are used by web client and server (EF).&nbsp; Web client only knows is how to call services, it has no idea where is the data coming from. A Service host responsibility is to specify database connection and provide centralized configurations
 for WCF services.<br>
WCF services implementation is also separated into different projects and loosely coupled with the service host.<br>
DAL &ndash; Data Access Layer is divided into two logical groups: Context and Infrastructure<br>
Context project is responsible for creating and managing Entities and databases. Database migration should be added here for future updates.<br>
Infrastructure project is implementation of Unit of work and repositories.<br>
A WCF Services implementation project knows how to create UOW or call repositories.<br>
Domain objects and Core project are shared between layers. Interface based implementation provides nice decoupling and separations<em><br>
</em></p>
<p><em>Sample&nbsp;WCF service invocation through interface call.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;GetHomeTypes()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;model&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_wcfService.InvokeService&lt;IVirtueContextService,&nbsp;ICollection&lt;HomeType&gt;&gt;((svc)&nbsp;=&gt;&nbsp;svc.GetHomeTypes(<span class="cs__keyword">true</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;PartialView(<span class="cs__string">&quot;_HomeTypes&quot;</span>,&nbsp;model.OrderBy(i&nbsp;=&gt;&nbsp;i.SortOrder));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><strong>ManagementController</strong>.cs &ndash; This controller is an example of displaying, creating and editing application types.<br>
Only <span style="color:#ff0000">HomeTypes </span>are implemented. You should be able to create a new HomeType and attach the image to it. Thumbnail is generated up on image upload.<br>
</em></li></ul>
<h1>More Information</h1>
<p><em>This solution is designed as a starting point with all basic components in place and provides complete wiring for application</em></p>
<p><em>Please post any question, I will be more than happy to answer them.</em></p>
