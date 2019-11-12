# Web API With HttpClient Or Consume Web API From Console Application
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- ASP.NET MVC
- ASP.NET Web API
- HttpClient
## Topics
- Development
- Web Development
- ASP.NET Web API
## Updated
- 03/25/2016
## Description

<p><span style="font-size:small">In this article we are going to learn how we can call Web API using HttpClient. Normally we call a Web API either from a&nbsp;<a href="http://sibeeshpassion.com/tag/jquery-ajax/" target="_blank">jQuery Ajax</a>&nbsp;or from&nbsp;<a href="http://sibeeshpassion.com/category/angularjs" target="_blank">Angular
 JS</a>&nbsp;right? Recently I came across a need of calling our Web API from server side itself. Here I am going to use two&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio" target="_blank">Visual Studio</a>&nbsp;application. One is our normal
 Web API application in which I have a Web API controller and actions, another one is a console application where I consume my Web API. Sounds good? I am using Visual Studio 2015. You can always get the tips/tricks/blogs about these mentioned technologies from
 the links given below.</span></p>
<li><span style="font-size:small"><a href="http://sibeeshpassion.com/category/mvc/" target="_blank">MVC Tips, Tricks, Blogs</a></span>
</li><li><span style="font-size:small"><a href="http://sibeeshpassion.com/category/web-api/" target="_blank">Web API Tips, Tricks, Blogs</a></span>
<p><span style="font-size:small">Now we will go and create our application. I hope you will like this.</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">We all uses Web API in our application to implement Http services. Http services are much simpler than ever if we uses Web API. But the fact is, the benefits of a Web API is not limited to that. Previously we uses WCF services
 instead of Web API, where we were working with endpoints and all. Here I am going to explain an important feature of a Web API that we can call Web API from our server itself instead of using an Ajax Call. That is pretty cool right? Now we will create our
 application.</span></p>
<p><span style="font-size:small">First we will create our Web API application.</span></p>
<p><strong><span style="font-size:small">Creating Web API application</span></strong></p>
<p><span style="font-size:small">Click File-&gt; New-&gt; Project then select MVC application. From the following pop up we will select the template as empty and select the core references and folders for MVC.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11405"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Empty-Template-With-MVC-And-Web-API-Folders-e1458711950206.png"><img class="size-full x_x_wp-image-11405" src="-empty-template-with-mvc-and-web-api-folders-e1458711950206.png" alt="Empty Template With MVC And Web API Folders" width="650" height="484"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Empty Template With MVC And Web API Folders</span></p>
</div>
<p><span style="font-size:small">Once you click OK, a project with MVC like folder structure with core references will be created for you.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11362"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Folder-Structure-And-References-For-Empty-MVC-Project.png"><img class="size-full x_x_wp-image-11362" src="-folder-structure-and-references-for-empty-mvc-project.png" alt="Folder Structure And References For Empty MVC Project" width="267" height="367"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Folder Structure And References For Empty MVC Project</span></p>
</div>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">We will set up our database first so that we can create Entity Model for our application later.</span></p>
<p><strong><span style="font-size:small">Create a database</span></strong></p>
<p><span style="font-size:small">The following query can be used to create a database in your SQL Server.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_577197">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[master]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;<span class="js__object">Object</span>:&nbsp;&nbsp;Database&nbsp;[TrialsDB]&nbsp;&nbsp;&nbsp;&nbsp;
CREATE&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;
&nbsp;CONTAINMENT&nbsp;=&nbsp;NONE&nbsp;
&nbsp;ON&nbsp;&nbsp;PRIMARY&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB.mdf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;3072KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;UNLIMITED,&nbsp;FILEGROWTH&nbsp;=&nbsp;1024KB&nbsp;)&nbsp;
&nbsp;LOG&nbsp;ON&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB_log'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB_log.ldf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;1024KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;2048GB&nbsp;,&nbsp;FILEGROWTH&nbsp;=&nbsp;<span class="js__num">10</span>%)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;COMPATIBILITY_LEVEL&nbsp;=&nbsp;<span class="js__num">110</span>&nbsp;
GO&nbsp;
&nbsp;&nbsp;
IF&nbsp;(<span class="js__num">1</span>&nbsp;=&nbsp;FULLTEXTSERVICEPROPERTY(<span class="js__string">'IsFullTextInstalled'</span>))&nbsp;
begin&nbsp;
EXEC&nbsp;[TrialsDB].[dbo].[sp_fulltext_database]&nbsp;@action&nbsp;=&nbsp;<span class="js__string">'enable'</span>&nbsp;
end&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULL_DEFAULT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULLS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_PADDING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_WARNINGS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ARITHABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CLOSE&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CREATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_SHRINK&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_CLOSE_ON_COMMIT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_DEFAULT&nbsp;&nbsp;GLOBAL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CONCAT_NULL_YIELDS_NULL&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;NUMERIC_ROUNDABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;QUOTED_IDENTIFIER&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECURSIVE_TRIGGERS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;DISABLE_BROKER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS_ASYNC&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DATE_CORRELATION_OPTIMIZATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TRUSTWORTHY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ALLOW_SNAPSHOT_ISOLATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PARAMETERIZATION&nbsp;SIMPLE&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;READ_COMMITTED_SNAPSHOT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;HONOR_BROKER_PRIORITY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECOVERY&nbsp;FULL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;MULTI_USER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PAGE_VERIFY&nbsp;CHECKSUM&nbsp;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DB_CHAINING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;FILESTREAM(&nbsp;NON_TRANSACTED_ACCESS&nbsp;=&nbsp;OFF&nbsp;)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TARGET_RECOVERY_TIME&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;SECONDS&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;READ_WRITE&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now we will create the table we needed. As of now I am going to create the table&nbsp;<em>tblTags</em></span></p>
<p><strong><span style="font-size:small">Create tables in database</span></strong></p>
<p><span style="font-size:small">Below is the query to create the table&nbsp;<em>tblTags</em>.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_117000">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[tblTags]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">23</span>-Mar<span class="js__num">-16</span>&nbsp;<span class="js__num">5</span>:<span class="js__num">01</span>:<span class="js__num">22</span>&nbsp;PM&nbsp;******/&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[tblTags](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[tagId]&nbsp;[int]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[tagName]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[tagDescription]&nbsp;[nvarchar](max)&nbsp;NULL,&nbsp;
&nbsp;CONSTRAINT&nbsp;[PK_tblTags]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[tagId]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;TEXTIMAGE_ON&nbsp;[PRIMARY]&nbsp;
&nbsp;&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Can we insert some data to the tables now?</span></p>
<p><strong><span style="font-size:small">Insert data to table</span></strong></p>
<p><span style="font-size:small">You can use the below query to insert the data to the table&nbsp;<em>tblTags</em></span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_172995">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[tblTags]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([tagName]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[tagDescription])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&lt;tagName,&nbsp;nvarchar(<span class="js__num">50</span>),&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;tagDescription,&nbsp;nvarchar(max),&gt;)&nbsp;
GO&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Next thing we are going to do is creating a ADO.NET Entity Data Model.</span></p>
<p><strong><span style="font-size:small">Create Entity Data Model</span></strong></p>
<p><span style="font-size:small">Right click on your model folder and click new, select ADO.NET Entity Data Model. Follow the steps given. Once you have done the processes, you can see the edmx file and other files in your model folder. Here I gave&nbsp;<em>Dashboard</em>&nbsp;for
 our Entity data model name. Now you can see a file with edmx extension have been created.</span><br>
<span style="font-size:small">Now will create our Web API controller.</span></p>
<p><strong><span style="font-size:small">Create Web API Controller</span></strong></p>
<p><span style="font-size:small">To create a Web API controller, just right click on your controller folder and click Add -&gt; Controller -&gt; Select Web API 2 controller with actions, using Entity Framework.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11401"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web-API-2-Controller-With-Actions-Using-Entity-Framework-e1458709497551.png"><img class="size-full x_x_wp-image-11401" src="-web-api-2-controller-with-actions-using-entity-framework-e1458709497551.png" alt="Web API 2 Controller With Actions Using Entity Framework" width="650" height="448"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web API 2 Controller With Actions Using Entity Framework</span></p>
</div>
<p><span style="font-size:small">Now select&nbsp;<em>tblTag (WebAPIWithHttpClient.Models)</em>&nbsp;as our Model class and&nbsp;<em>TrialsDBEntities (WebAPIWithHttpClient.Models)</em>&nbsp;as data context class. This time we will select controller with async
 actions.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11425"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web-API-Controller-With-Async-Actions.png"><img class="size-full x_x_wp-image-11425" src="-web-api-controller-with-async-actions.png" alt="Web API Controller With Async Actions" width="593" height="233"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web API Controller With Async Actions</span></p>
</div>
<p><span style="font-size:small">As you can see It has been given the name of our controller as&nbsp;<em>tblTags</em>. Here I am not going to change that, if you wish to change, you can do that.</span></p>
<p><span style="font-size:small">Now you will be given the following codes in our new Web API controller.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_431136">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.Entity.aspx" target="_blank" title="Auto generated link to System.Data.Entity">System.Data.Entity</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.Entity.Infrastructure.aspx" target="_blank" title="Auto generated link to System.Data.Entity.Infrastructure">System.Data.Entity.Infrastructure</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.aspx" target="_blank" title="Auto generated link to System.Net">System.Net</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.aspx" target="_blank" title="Auto generated link to System.Net.Http">System.Net.Http</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Http.aspx" target="_blank" title="Auto generated link to System.Web.Http">System.Web.Http</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Http.Description.aspx" target="_blank" title="Auto generated link to System.Web.Http.Description">System.Web.Http.Description</a>;&nbsp;
using&nbsp;WebAPIWithHttpClient.Models;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;WebAPIWithHttpClient.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;tblTagsController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;TrialsDBEntities&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TrialsDBEntities();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/tblTags</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IQueryable&lt;tblTag&gt;&nbsp;GettblTags()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.tblTags;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;api/tblTags/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(tblTag))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;GettblTag(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblTag&nbsp;tblTag&nbsp;=&nbsp;await&nbsp;db.tblTags.FindAsync(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(tblTag&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(tblTag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;PUT:&nbsp;api/tblTags/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(<span class="js__operator">void</span>))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;PuttblTag(int&nbsp;id,&nbsp;tblTag&nbsp;tblTag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(id&nbsp;!=&nbsp;tblTag.tagId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Entry(tblTag).State&nbsp;=&nbsp;EntityState.Modified;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;db.SaveChangesAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(DbUpdateConcurrencyException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!tblTagExists(id))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;StatusCode(HttpStatusCode.NoContent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;POST:&nbsp;api/tblTags</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(tblTag))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;PosttblTag(tblTag&nbsp;tblTag)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;BadRequest(ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.tblTags.Add(tblTag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;db.SaveChangesAsync();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;CreatedAtRoute(<span class="js__string">&quot;DefaultApi&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;id&nbsp;=&nbsp;tblTag.tagId&nbsp;<span class="js__brace">}</span>,&nbsp;tblTag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;DELETE:&nbsp;api/tblTags/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ResponseType(<span class="js__operator">typeof</span>(tblTag))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;IHttpActionResult&gt;&nbsp;DeletetblTag(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblTag&nbsp;tblTag&nbsp;=&nbsp;await&nbsp;db.tblTags.FindAsync(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(tblTag&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;NotFound();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.tblTags.Remove(tblTag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;db.SaveChangesAsync();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Ok(tblTag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;Dispose(bool&nbsp;disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.Dispose(disposing);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;bool&nbsp;tblTagExists(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;db.tblTags.Count(e&nbsp;=&gt;&nbsp;e.tagId&nbsp;==&nbsp;id)&nbsp;&gt;&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see, we have actions for,</span></p>
</li><li><span style="font-size:small">Get</span> </li><li><span style="font-size:small">Post</span> </li><li><span style="font-size:small">Put</span> </li><li><span style="font-size:small">Delete</span>
<p><span style="font-size:small">So the coding part to fetch the data from database is ready, now we need to check whether our Web API is ready for action!. To check that, you just need to run the URL&nbsp;<em>http://localhost:7967/api/tbltags</em>. Here<em>tblTags</em>&nbsp;is
 our Web API controller name. I hope you get the data as a result.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11413"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web_API_Result-e1458733092316.png"><img class="size-full x_x_wp-image-11413" src="-web_api_result-e1458733092316.png" alt="Web_API_Result" width="650" height="342"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web_API_Result</span></p>
</div>
<p><span style="font-size:small">As of now our Web API application is ready, and we have just tested whether it is working or not. Now we can move on to create a console application where we can consume this Web API with the help of HttpClient. So shall we
 do that?</span></p>
<p><strong><span style="font-size:small">Create Console Application To Consume Web API</span></strong></p>
<p><span style="font-size:small">To create a console application, Click File -&gt; New -&gt; Click Windows -&gt; Select Console application -&gt; Name your application -&gt; OK</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11426"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Console-Application-e1458836504170.png"><img class="size-full x_x_wp-image-11426" src="-console-application-e1458836504170.png" alt="Console Application" width="650" height="396"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Console Application</span></p>
</div>
<p><span style="font-size:small">I hope now you have a class called Program.cs with the below codes.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_916426">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
namespace&nbsp;WebAPIWithHttpClientConsumer&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;class&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Main(string[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now we will start our coding, We will create a class called&nbsp;<em>tblTag&nbsp;</em>with some properties so that we can use those when we need.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_473888">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;tblTag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;tagId&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;tagName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;tagDescription&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">To get started using the class&nbsp;<em>HttpClient</em>, you must import the namespace as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_811012">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.aspx" target="_blank" title="Auto generated link to System.Net.Http">System.Net.Http</a>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Once you have imported the namespaces, we will set our HttpClient and the properties as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_522325">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">HttpClient&nbsp;cons&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cons.BaseAddress&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Uri(<span class="js__string">&quot;http://localhost:7967/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cons.DefaultRequestHeaders.Accept.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cons.DefaultRequestHeaders.Accept.Add(<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.aspx" target="_blank" title="Auto generated link to System.Net.Http.Headers.MediaTypeWithQualityHeaderValue">System.Net.Http.Headers.MediaTypeWithQualityHeaderValue</a>(<span class="js__string">&quot;application/json&quot;</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">As you can see we are just giving the base address of our API and setting the response header. Now we will create an asyn action to get the data from our database by calling our Web API.</span></p>
<p><strong><span style="font-size:small">Get operation using HttpClient</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_347875">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">MyAPIGet(cons).Wait();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Following is the definition of&nbsp;<em>MyAPIGet&nbsp;</em>function.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_187619">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">static&nbsp;async&nbsp;Task&nbsp;MyAPIGet(HttpClient&nbsp;cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.GetAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res.EnsureSuccessStatusCode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(res.IsSuccessStatusCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblTag&nbsp;tag&nbsp;=&nbsp;await&nbsp;res.Content.ReadAsAsync&lt;tblTag&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;---------------------Calling&nbsp;Get&nbsp;Operation------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;tagId&nbsp;&nbsp;&nbsp;&nbsp;tagName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tagDescription&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;{0}\t{1}\t\t{2}&quot;</span>,&nbsp;tag.tagId,&nbsp;tag.tagName,&nbsp;tag.tagDescription);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here&nbsp;<em>res.EnsureSuccessStatusCode();</em>&nbsp;ensure that it throws errors if we get any. If you don&rsquo;t need to throw the errors, please remove this line of code. If the asyn call is success, the value in&nbsp;<em>IsSuccessStatusCode</em>&nbsp;will
 be true.</span></p>
<p><span style="font-size:small">Now when you run the above code, there are chances to get an error as follows.</span></p>
<p><span style="font-size:small"><em>Error CS1061 &lsquo;HttpContent&rsquo; does not contain a definition for &lsquo;ReadAsAsync&rsquo; and no extension method &lsquo;ReadAsAsync&rsquo; accepting a first argument of type &lsquo;HttpContent&rsquo; could be found
 (are you missing a using directive or an assembly reference?)</em></span></p>
<p><span style="font-size:small">This is just because of the&nbsp;<em>ReadAsAsync</em>&nbsp;is a part of&nbsp;<em>System.Net.Http.Formatting.dll</em>&nbsp;which we have not added to our application as a reference yet. Now we will do that? Sounds OK?</span></p>
<p><span style="font-size:small">Just right click on the references and click add reference -&gt; Click browse -&gt; search for<em>System.Net.Http.Formatting.dll</em>&nbsp;&ndash; Click OK</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11427"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Add-References-e1458838521697.png"><img class="size-full x_x_wp-image-11427" src="-add-references-e1458838521697.png" alt="Add References" width="650" height="447"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Add References</span></p>
</div>
<p><span style="font-size:small">Please add&nbsp;<em>Newtonsoft.Json</em>&nbsp;also. Now let us run our project and see our output.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11429"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web_API_Consumer_Get_Output1-e1458882223957.png"><img class="size-full x_x_wp-image-11429" src="-web_api_consumer_get_output1-e1458882223957.png" alt="Web_API_Consumer_Get_Output" width="650" height="328"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web_API_Consumer_Get_Output</span></p>
</div>
<p><span style="font-size:small">Now shall we create a function for updating the record? Yes, we are going to create a function with &lsquo;Put&rsquo; request. Please copy and paste preceding code for that.</span></p>
<p><strong><span style="font-size:small">Put operation using HttpClient</span></strong></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_627391">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">static&nbsp;async&nbsp;Task&nbsp;MyAPIPut(HttpClient&nbsp;cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.GetAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res.EnsureSuccessStatusCode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(res.IsSuccessStatusCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tblTag&nbsp;tag&nbsp;=&nbsp;await&nbsp;res.Content.ReadAsAsync&lt;tblTag&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tag.tagName&nbsp;=&nbsp;<span class="js__string">&quot;New&nbsp;Tag&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.PutAsJsonAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>,&nbsp;tag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;------------------Calling&nbsp;Put&nbsp;Operation--------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;tagId&nbsp;&nbsp;&nbsp;&nbsp;tagName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tagDescription&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;{0}\t{1}\t\t{2}&quot;</span>,&nbsp;tag.tagId,&nbsp;tag.tagName,&nbsp;tag.tagDescription);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">As you can see we are just updating the record as below once we get the response from&nbsp;<em>await cons.GetAsync(&ldquo;api/tblTags/2&rdquo;)</em>&nbsp;.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_226509">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">tag.tagName&nbsp;=&nbsp;<span class="js__string">&quot;New&nbsp;Tag&quot;</span>;&nbsp;
res&nbsp;=&nbsp;await&nbsp;cons.PutAsJsonAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>,&nbsp;tag);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Now again run your application, and check whether the tag name has been changed to &lsquo;New Tag&rsquo;.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11430"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web_API_Consumer_Put_Output-e1458882875423.png"><img class="size-full x_x_wp-image-11430" src="-web_api_consumer_put_output-e1458882875423.png" alt="Web_API_Consumer_Put_Output" width="650" height="328"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web_API_Consumer_Put_Output</span></p>
</div>
<p><span style="font-size:small">Now did you see that your tag name has been changed? If yes, we are ready to go for our next operation. Are you ready?</span></p>
<p><strong><span style="font-size:small">Delete operation using HttpClient</span></strong></p>
<p><span style="font-size:small">We will follow the same procedure for delete operation too. Please see the code for delete operation below.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_642107">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">async&nbsp;Task&nbsp;MyAPIDelete(HttpClient&nbsp;cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.GetAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res.EnsureSuccessStatusCode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(res.IsSuccessStatusCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.DeleteAsync(<span class="js__string">&quot;api/tblTags/2&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;------------------Calling&nbsp;Delete&nbsp;Operation--------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;------------------Deleted-------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">To delete a record we uses&nbsp;<em>res = await cons.DeleteAsync(&ldquo;api/tblTags/2&rdquo;);</em>&nbsp;method. Now run your application and see the result.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11431"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web_API_Consumer_Delete_Output-e1458883191973.png"><img class="size-full x_x_wp-image-11431" src="-web_api_consumer_delete_output-e1458883191973.png" alt="Web_API_Consumer_Delete_Output" width="650" height="328"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web_API_Consumer_Delete_Output</span></p>
</div>
<p><span style="font-size:small">What action is pending now? Yes, it is Post.</span></p>
<p><strong><span style="font-size:small">Post operation using HttpClient</span></strong></p>
<p><span style="font-size:small">Please add the below function to your project for the post operation.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_260836">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">static&nbsp;async&nbsp;Task&nbsp;MyAPIPost(HttpClient&nbsp;cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(cons)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tag&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;tblTag&nbsp;<span class="js__brace">{</span>&nbsp;tagName&nbsp;=&nbsp;<span class="js__string">&quot;jQuery&quot;</span>,&nbsp;tagDescription&nbsp;=&nbsp;<span class="js__string">&quot;This&nbsp;tag&nbsp;is&nbsp;all&nbsp;about&nbsp;jQuery&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.PostAsJsonAsync(<span class="js__string">&quot;api/tblTags&quot;</span>,&nbsp;tag);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;res.EnsureSuccessStatusCode();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(res.IsSuccessStatusCode)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;-----------------------------------------------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;------------------Calling&nbsp;Post&nbsp;Operation--------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;------------------Created&nbsp;Successfully--------------------&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">We are just creating a new tblTag and assign some values, once the object is ready we are calling the method PostAsJsonAsync as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_830492">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;tag&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;tblTag&nbsp;<span class="js__brace">{</span>&nbsp;tagName&nbsp;=&nbsp;<span class="js__string">&quot;jQuery&quot;</span>,&nbsp;tagDescription&nbsp;=&nbsp;<span class="js__string">&quot;This&nbsp;tag&nbsp;is&nbsp;all&nbsp;about&nbsp;jQuery&quot;</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;res&nbsp;=&nbsp;await&nbsp;cons.PostAsJsonAsync(<span class="js__string">&quot;api/tblTags&quot;</span>,&nbsp;tag);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">As you have noticed, I have not provided the&nbsp;<em>tagId</em>&nbsp;in the object, do yo know why? I have already set<em>Identity Specification</em>&nbsp;with&nbsp;<em>Identity Increment</em>&nbsp;1 in my table&nbsp;<em>tblTags</em>&nbsp;in
 SQL database.</span></p>
<p><span style="font-size:small">Now we will see the output. Shall we?</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11432"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/03/Web_API_Consumer_Post_Output-e1458883741126.png"><img class="size-full x_x_wp-image-11432" src="-web_api_consumer_post_output-e1458883741126.png" alt="Web_API_Consumer_Post_Output" width="650" height="328"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Web_API_Consumer_Post_Output</span></p>
</div>
<p><span style="font-size:small">We have done everything!. That&rsquo;s fantastic right? Have a happy coding.</span></p>
</li>