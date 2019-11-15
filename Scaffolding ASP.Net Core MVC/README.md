# Scaffolding ASP.Net Core MVC
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET Core
- Entity Framework Core 1.0
- ASP.NET MVC Core
## Topics
- ASP.NET Core
- Entity Framework Core 1.0
- ASP.NET MVC Core
## Updated
- 12/09/2016
## Description

<p><span>In this post we are going to explore how to create model based on existing database (Db-First), with the help of Entityframework Core Command then learn how to generate Controller &amp; Views using Scaffolding (Interface &amp; Code-Generator Command)
 based on model.</span></p>
<p><strong>Here&rsquo;s the Topics:</strong></p>
<ol>
<li>Manage Packages </li><li>EF Core Model(DB-First) </li><li>MVC Core Scaffolding </li></ol>
<p>Let&rsquo;s Create New Project: File &gt; New &gt; Project</p>
<p><img src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_1.png" alt="" width="630px" height="169px"></p>
<p>From left menu choose .Net Core &gt; ASP.Net Core Web Application</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_2.png"><img class="alignnone size-full x_x_wp-image-3653" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_2.png" alt="coremvc_2"></a></p>
<p>Choose ASP.Net Core sample template, Click OK.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_3.png"><img class="alignnone size-full x_x_wp-image-3654" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_3.png" alt="coremvc_3"></a>Here&rsquo;s the initial view of sample
 template in solution explorer.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_4.png"><img class="alignnone size-full x_x_wp-image-3655" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_4.png" alt="coremvc_4"></a></p>
<p>Create a new database using SSMS, name it &ldquo;PhoneBook&rdquo;. Copy the below query &amp; run it using query editor of SSMS.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[PhoneBook]&nbsp;
GO&nbsp;
&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Contacts]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">12</span>/<span class="js__num">9</span><span class="js__reg_exp">/2016&nbsp;2:47:49&nbsp;AM&nbsp;******/</span>&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[Contacts](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ContactID]&nbsp;[int]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[FirstName]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[LastName]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Phone]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Email]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NULL,&nbsp;
&nbsp;CONSTRAINT&nbsp;[PK_Contacts]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ContactID]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
&nbsp;
GO</pre>
</div>
</div>
</div>
<p></p>
<h3><strong>Entity Framework Core:</strong></h3>
<p><a href="https://github.com/aspnet/EntityFramework/wiki/Roadmap">Entity Framework (EF) Core</a>&nbsp;is data access technology which is targeted for cross-platform. Open project.json add below packages in Dependency &amp; Tools section.</p>
<p><em><span style="text-decoration:underline">Add Dependency Package:</span></em></p>
<p><em><span style="text-decoration:underline"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Database&nbsp;Provider&nbsp;for&nbsp;EF&nbsp;Core</span>&nbsp;
<span class="js__string">&quot;Microsoft.EntityFrameworkCore.SqlServer&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//EF&nbsp;Core&nbsp;Package&nbsp;Manager&nbsp;Console&nbsp;Tools</span>&nbsp;
<span class="js__string">&quot;Microsoft.EntityFrameworkCore.Tools&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//EF&nbsp;Core&nbsp;Funtionality&nbsp;for&nbsp;MSSQL&nbsp;Server</span>&nbsp;
<span class="js__string">&quot;Microsoft.EntityFrameworkCore.SqlServer.Design&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.1&quot;</span></pre>
</div>
</div>
</div>
</span></em>
<p></p>
<p><em><span style="text-decoration:underline">Add Tools:</span></em></p>
<div class="pre-action-link" id="premain172079">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Access&nbsp;Command&nbsp;Tools&nbsp;EF&nbsp;Core</span>&nbsp;
<span class="js__string">&quot;Microsoft.EntityFrameworkCore.Tools&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><em><span style="text-decoration:underline">EntityFrameworkCore.SqlServer:</span></em>&nbsp;Database Provider, that allows Entity Framework Core to be used with Microsoft SQL Server.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><em><span style="text-decoration:underline">EntityFrameworkCore.SqlServer.Design:</span></em>&nbsp;Design-time, that allows Entity Framework Core functionality (EF Core Migration) to be used with Microsoft SQL Server.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><em><span style="text-decoration:underline">EntityFrameworkCore.Tools:</span></em><span style="text-decoration:underline">&nbsp;</span><a href="https://docs.efproject.net/en/latest/miscellaneous/cli/dotnet.html">Command line</a>&nbsp;tool
 for EF Core that Includes Commands</div>
</div>
<p>For&nbsp;<strong>Package Manager Console</strong>:</p>
<ul>
<li>Scaffold-DbContext </li><li>Add-Migration </li><li>Update-Database </li></ul>
<p>For&nbsp;<strong>Command Window</strong></p>
<ul>
<li>dotnet ef dbcontext scaffold </li></ul>
<p><strong>Using CommandLine</strong>&nbsp;In our sample application we are going to apply Commands using the command line.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_5.png"><img class="alignnone size-full x_x_wp-image-3656" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_5.png" alt="coremvc_5"></a></p>
<p>Go to Project directory &gt; Shift &#43; Right Click to open Command window.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_6.png"><img class="alignnone size-full x_x_wp-image-3657" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_6.png" alt="coremvc_6"></a><em><strong><span style="text-decoration:underline">Command:</span></strong>&nbsp;dotnet
 ef &ndash;help</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_7.png"><img class="alignnone size-full x_x_wp-image-3658" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_7.png" alt="coremvc_7"></a></p>
<p><strong><em><span style="text-decoration:underline">Command:</span></em></strong>&nbsp;<em>dotnet ef dbcontext scaffold &quot;Server=DESKTOP-5B67SHH;Database=PhoneBook;Trusted_Connection=True;&quot; Microsoft.EntityFrameworkCore.SqlServer --output-dir Models</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_8.png"><img class="alignnone size-full x_x_wp-image-3659" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_8.png" alt="coremvc_8"></a></p>
<p>As we&nbsp;can see&nbsp;from solution explorer models folder is created with Context &amp; Entities.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_9.png"><img class="alignnone size-full x_x_wp-image-3660" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_9.png" alt="coremvc_9"></a></p>
<p><strong>Generated DbContext:&nbsp;</strong>Finally full view of generated Context class.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;partial&nbsp;class&nbsp;PhoneBookContext&nbsp;:&nbsp;DbContext&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnConfiguring(DbContextOptionsBuilder&nbsp;optionsBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#warning&nbsp;To&nbsp;protect&nbsp;potentially&nbsp;sensitive&nbsp;information&nbsp;<span class="js__operator">in</span>&nbsp;your&nbsp;connection&nbsp;string,&nbsp;you&nbsp;should&nbsp;move&nbsp;it&nbsp;out&nbsp;of&nbsp;source&nbsp;code.&nbsp;See&nbsp;http:<span class="js__sl_comment">//go.microsoft.com/fwlink/?LinkId=723263&nbsp;for&nbsp;guidance&nbsp;on&nbsp;storing&nbsp;connection&nbsp;strings.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;optionsBuilder.UseSqlServer(@<span class="js__string">&quot;Server=DESKTOP-5B67SHH;Database=PhoneBook;Trusted_Connection=True;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnModelCreating(ModelBuilder&nbsp;modelBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Entity&lt;Contacts&gt;(entity&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.HasKey(e&nbsp;=&gt;&nbsp;e.ContactId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HasName(<span class="js__string">&quot;PK_Contacts&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.Property(e&nbsp;=&gt;&nbsp;e.ContactId).HasColumnName(<span class="js__string">&quot;ContactID&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.Property(e&nbsp;=&gt;&nbsp;e.Email).HasMaxLength(<span class="js__num">50</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.Property(e&nbsp;=&gt;&nbsp;e.FirstName).HasMaxLength(<span class="js__num">50</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.Property(e&nbsp;=&gt;&nbsp;e.LastName).HasMaxLength(<span class="js__num">50</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;entity.Property(e&nbsp;=&gt;&nbsp;e.Phone).HasMaxLength(<span class="js__num">50</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;virtual&nbsp;DbSet&lt;Contacts&gt;&nbsp;Contacts&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="font-size:1.17em">ASP.Net MVC Core Scaffolding:</strong></div>
<p></p>
<p>We have used scaffolding in previous version of .Net, as .Net Core is new sometimes it&rsquo;s getting confusing how to start, here we will explore those issues. Open project.json add below packages in Dependency &amp; Tools section.&nbsp;</p>
<p><em><span style="text-decoration:underline">Add Dependency Package:</span></em></p>
<p><em><span style="text-decoration:underline"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Code&nbsp;Generators&nbsp;Package&nbsp;Generate&nbsp;Controller,Views</span>&nbsp;
<span class="js__string">&quot;Microsoft.VisualStudio.Web.CodeGenerators.Mvc&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span>,&nbsp;
<span class="js__string">&quot;Microsoft.VisualStudio.Web.CodeGeneration.Tools&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span></pre>
</div>
</div>
</div>
</span></em>
<p></p>
<p><em><span style="text-decoration:underline">Add Tools:</span></em></p>
<p><em><span style="text-decoration:underline"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Access&nbsp;Command&nbsp;Tools&nbsp;Code&nbsp;Generation</span>&nbsp;
<span class="js__string">&quot;Microsoft.VisualStudio.Web.CodeGeneration.Tools&quot;</span>:&nbsp;<span class="js__string">&quot;1.0.0-preview2-final&quot;</span></pre>
</div>
</div>
</div>
</span></em>
<p></p>
<p>Click Save, packages will restore automatically. Well packages are installed to our application, we are good to perform next step of Scaffolding Controller &amp; Views.</p>
<p><strong>Scaffold using Interface:</strong>&nbsp;Right Click on Controller folder &gt; Add &gt; New Scaffolding Item</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_10.png"><img class="alignnone size-full x_x_wp-image-3661" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_10.png" alt="coremvc_10"></a></p>
<p>Choose the scaffold option how the code will generated.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_11.png"><img class="alignnone size-full x_x_wp-image-3662" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_11.png" alt="coremvc_11"></a></p>
<p>Now provide model, context classes that is going to use to interact with database, choose view options then click Add button to perform the action.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_12.png"><img class="alignnone size-full x_x_wp-image-3663" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_12.png" alt="coremvc_12"></a></p>
<p>Wait for a while as we can see from solution explorer the views are generated.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_13.png"><img class="alignnone size-full x_x_wp-image-3664" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_13.png" alt="coremvc_13"></a></p>
<p>The output messages are shown below.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">C:\Program&nbsp;Files\dotnet\dotnet.exe&nbsp;aspnet-codegenerator&nbsp;--project&nbsp;<span class="js__string">&quot;E:\Documents\Article\ScaffoldingCoreMVC\CoreMVCScaffolding\src\CoreMVCScaffolding&quot;</span>&nbsp;controller&nbsp;--force&nbsp;--controllerName&nbsp;ContactsController&nbsp;--model&nbsp;CoreMVCScaffolding.Models.Contacts&nbsp;--dataContext&nbsp;CoreMVCScaffolding.Models.PhoneBookContext&nbsp;--relativeFolderPath&nbsp;Controllers&nbsp;--controllerNamespace&nbsp;CoreMVCScaffolding.Controllers&nbsp;--useDefaultLayout&nbsp;
Finding&nbsp;the&nbsp;generator&nbsp;<span class="js__string">'controller'</span>...&nbsp;
Running&nbsp;the&nbsp;generator&nbsp;<span class="js__string">'controller'</span>...&nbsp;
Attempting&nbsp;to&nbsp;compile&nbsp;the&nbsp;application&nbsp;<span class="js__operator">in</span>&nbsp;memory&nbsp;
Attempting&nbsp;to&nbsp;figure&nbsp;out&nbsp;the&nbsp;EntityFramework&nbsp;metadata&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;model&nbsp;and&nbsp;DbContext:&nbsp;Contacts&nbsp;
Added&nbsp;Controller&nbsp;:&nbsp;\Controllers\ContactsController.cs&nbsp;
Added&nbsp;View&nbsp;:&nbsp;\Views\Contacts\Create.cshtml&nbsp;
Added&nbsp;View&nbsp;:&nbsp;\Views\Contacts\Edit.cshtml&nbsp;
Added&nbsp;View&nbsp;:&nbsp;\Views\Contacts\Details.cshtml&nbsp;
Added&nbsp;View&nbsp;:&nbsp;\Views\Contacts\Delete.cshtml&nbsp;
Added&nbsp;View&nbsp;:&nbsp;\Views\Contacts\Index.cshtml&nbsp;
RunTime&nbsp;<span class="js__num">00</span>:<span class="js__num">00</span>:<span class="js__num">07.87</span></pre>
</div>
</div>
</div>
<p></p>
<p><strong>Scaffold using CommandLine:</strong>&nbsp;We can generate that by using CommandLine, pointing the project folder with Shift &#43; Right Click then command window will appear. Get help information by the following command.</p>
<p><strong><em><span style="text-decoration:underline">Command:</span></em></strong>&nbsp;<em>dotnet aspnet-codegenerator --help</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_14.png"><img class="alignnone size-full x_x_wp-image-3665" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_14.png" alt="coremvc_14"></a></p>
<p>Let&rsquo;s generate Controller &amp; View using below command with project path, controller, model info.</p>
<p><strong><em><span style="text-decoration:underline">Command:</span></em></strong>&nbsp;<em>dotnet aspnet-codegenerator --project &quot;E:\Documents\Article\ScaffoldingCoreMVC\CoreMVCScaffolding\src\CoreMVCScaffolding&quot; controller --force --controllerName ContactsController
 --model CoreMVCScaffolding.Models.Contacts --dataContext CoreMVCScaffolding.Models.PhoneBookContext --relativeFolderPath Controllers --controllerNamespace CoreMVCScaffolding.Controllers &ndash;useDefaultLayout</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_15.png"><img class="alignnone size-full x_x_wp-image-3666" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_15.png" alt="coremvc_15"></a></p>
<p>As we can see the controller &amp; view is successfully generated using MVC model. In our sample application if we notice in the Error List tab there&rsquo;s a warning about to move sensitive information from DbContext.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_16.png"><img class="alignnone size-full x_x_wp-image-3667" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_16.png" alt="coremvc_16"></a>This is the area in DbContext class which
 cause the warning.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnConfiguring(DbContextOptionsBuilder&nbsp;optionsBuilder)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#warning&nbsp;To&nbsp;protect&nbsp;potentially&nbsp;sensitive&nbsp;information&nbsp;<span class="js__operator">in</span>&nbsp;your&nbsp;connection&nbsp;string,&nbsp;you&nbsp;should&nbsp;move&nbsp;it&nbsp;out&nbsp;of&nbsp;source&nbsp;code.&nbsp;See&nbsp;http:<span class="js__sl_comment">//go.microsoft.com/fwlink/?LinkId=723263&nbsp;for&nbsp;guidance&nbsp;on&nbsp;storing&nbsp;connection&nbsp;strings.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;optionsBuilder.UseSqlServer(@<span class="js__string">&quot;Server=DESKTOP-5B67SHH;Database=PhoneBook;Trusted_Connection=True;&quot;</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p></p>
<p>Let&rsquo;s comment that out, here in startup class now add the service by moving the connectionstring info from DbContext. Below you may notice the code snippet that add the service.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;add&nbsp;services&nbsp;to&nbsp;the&nbsp;container.</span>&nbsp;
public&nbsp;<span class="js__operator">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;framework&nbsp;services.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;connection&nbsp;=&nbsp;@<span class="js__string">&quot;Server=DESKTOP-5B67SHH;Database=PhoneBook;Trusted_Connection=True;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddDbContext&lt;PhoneBookContext&gt;(options&nbsp;=&gt;&nbsp;options.UseSqlServer(connection));&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p></p>
<p>If we now try to run our application below exception will occur. Here&rsquo;s the Exception message:</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">InvalidOperationException:&nbsp;No&nbsp;database&nbsp;provider&nbsp;has&nbsp;been&nbsp;configured&nbsp;<span class="js__statement">for</span>&nbsp;<span class="js__operator">this</span>&nbsp;DbContext.&nbsp;
A&nbsp;provider&nbsp;can&nbsp;be&nbsp;configured&nbsp;by&nbsp;overriding&nbsp;the&nbsp;DbContext.OnConfiguring&nbsp;method&nbsp;or&nbsp;&nbsp;
by&nbsp;using&nbsp;AddDbContext&nbsp;on&nbsp;the&nbsp;application&nbsp;service&nbsp;provider.&nbsp;&nbsp;
If&nbsp;AddDbContext&nbsp;is&nbsp;used,&nbsp;then&nbsp;also&nbsp;ensure&nbsp;that&nbsp;your&nbsp;DbContext&nbsp;&nbsp;
type&nbsp;accepts&nbsp;a&nbsp;DbContextOptions&lt;TContext&gt;&nbsp;object&nbsp;<span class="js__operator">in</span>&nbsp;its&nbsp;constructor&nbsp;&nbsp;
and&nbsp;passes&nbsp;it&nbsp;to&nbsp;the&nbsp;base&nbsp;constructor&nbsp;<span class="js__statement">for</span>&nbsp;DbContext.</pre>
</div>
</div>
</div>
<p></p>
<p><img class="alignnone size-large x_x_wp-image-3668" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_17.png" alt="coremvc_17"></p>
<p>It says, No database provider has been configured for this DbContext. Notice that we have used AddDbContext in ConfigureServices(IServiceCollection services) method.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">services.AddDbContext&lt;PhoneBookContext&gt;(options&nbsp;=&gt;&nbsp;options.UseSqlServer(connection));</pre>
</div>
</div>
</div>
<p></p>
<p>But we didn&rsquo;t pass it for DbContext, We need to add below constructor to pass it to the base constructor for DbContext.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;PhoneBookContext(DbContextOptions&lt;PhoneBookContext&gt;&nbsp;options)&nbsp;:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;base(options)&nbsp;
<span class="js__brace">{</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p></p>
<p>Now we may run our sample application by Ctrl&#43;f5 or we can run using below command.</p>
<p><strong><em><span style="text-decoration:underline">Command:</span></em></strong>&nbsp;<em>dotnet run</em></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_18.png"><img class="alignnone size-full x_x_wp-image-3669" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_18.png" alt="coremvc_18"></a></p>
<p>Open browser Go to&nbsp;http://localhost:5000,&nbsp;finally the application is running.</p>
<p><strong>Contact List</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_19.png"><img class="alignnone wp-image-3670 x_x_size-full" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_19.png" alt="coremvc_19"></a></p>
<p><strong>Create New Contact</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_20.png"><img class="alignnone wp-image-3671 x_x_size-full" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_20.png" alt="coremvc_20"></a></p>
<p><strong>Edit Existing Contact</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_21.png"><img class="alignnone wp-image-3672 x_x_size-full" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_21.png" alt="coremvc_21"></a></p>
<p><strong>View Details Existing Contact</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_22.png"><img class="alignnone wp-image-3673 x_x_size-full" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_22.png" alt="coremvc_22"></a></p>
<p><strong>Delete Existing Contact</strong></p>
<p><a href="http://shashangka.com/wp-content/uploads/2016/12/coremvc_23.png"><img class="alignnone wp-image-3674 x_x_size-full" src="https://www.codeproject.com/KB/aspnet/1160127/coremvc_23.png" alt="coremvc_23"></a></p>
<p>Hope this will help 🙂</p>
<p><strong>References:</strong></p>
<ol>
<li><a href="https://docs.microsoft.com/en-us/ef/core/index">https://docs.microsoft.com/en-us/ef/core/index</a>
</li><li><a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet</a>
</li><li><a href="https://github.com/aspnet/EntityFramework/wiki/Roadmap">https://github.com/aspnet/EntityFramework/wiki/Roadmap</a>
</li><li><a href="https://www.codeproject.com/articles/1118189/crud-using-net-core-angularjs-webapi">https://www.codeproject.com/articles/1118189/crud-using-net-core-angularjs-webapi</a>
</li></ol>
<p><span><br>
</span></p>
