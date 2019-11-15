# WCF Service Unit Tests Using NUnit With Rhino Mocks And Entity Framework
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- WCF
- SQL Server
- ASP.NET
- Entity Framework
- NUnit
- Visual Studio 2015
- Rhino Mocks
## Topics
- WCF
- Unit Testing
- Performance
- Visual Studio
## Updated
- 11/20/2016
## Description

<p>In this post we will see how we can write unit test cases for our&nbsp;<a href="http://sibeeshpassion.com/category/WCF-Service/" target="_blank">WCF Service</a>&nbsp;with a framework called NUnit. We will also be covering how to mock our dependencies in
 our test, here we wil be using Rhino Mocks. I am going to use&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio/" target="_blank">Visual Studio</a>&nbsp;2015 for the development. I hope you will like this article.</p>
<p><br>
Background</p>
<p>As a developer, we all writes lots of codes in our day to day life. Am I right? It is more important to check whether the codes we have written works well. So for that we developer usually do unit testing, few developers are doing a manual testing to just
 check whether the functionality is working or not. I would say that it is wrong. In a TDD (Test Driven Development) unit testing is very important, where we actually writes the test cases before we start our coding. Let us see what exactly the &ldquo;Unit
 Tesing&rdquo; is.</p>
<p><span>Unit Testing</span></p>
<p>Unit testing is the process of testing a unit, it can be a class, a block of codde, function, a property. We can easily test our units independently. In&nbsp;<a href="http://sibeeshpassion.com/category/asp-net/">dot net</a>&nbsp;we have so many frameworks
 to do unit testing. But here we are going to use NUnit which I found very easy to write tests.</p>
<blockquote>
<p>If you have Resharper installed in your machine, it will be more easier to execute and debug your tests. Here I am using Resharper in my Visual Studio, so the screenshots will be based on that. Thank you</p>
</blockquote>
<p>Now it is time to set up our project and start our coding.</p>
<p><span>Setting up the project</span></p>
<p>To get started, please create an empty project in your Visual Studio.</p>
<div class="wp-caption x_alignnone" id="attachment_11904"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/10/Empty_Project-e1475921231766.png"><img class="size-full x_wp-image-11904" src="http://sibeeshpassion.com/wp-content/uploads/2016/10/Empty_Project-e1475921231766.png" alt="empty_project" width="650" height="507"></a>
<p class="wp-caption-text">empty_project</p>
</div>
<p>Now, we will add a&nbsp;<a href="http://sibeeshpassion.com/category/WCF-Service/" target="_blank">WCF Service</a>&nbsp;as follows.</p>
<div class="wp-caption x_alignnone" id="attachment_11930"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Create_a_wcf_service.png"><img class="size-large x_wp-image-11930" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Create_a_wcf_service-1024x709.png" alt="create_a_wcf_service" width="634" height="439"></a>
<p class="wp-caption-text">create_a_wcf_service</p>
</div>
<p>Once you are done, you can see two files, an Interface(IMyService) and a class (MyService) with .svc extension. If you are completely new to WCF service, I strongly recommend you to read some basics&nbsp;<a href="https://msdn.microsoft.com/en-us/library/bb386386.aspx" target="_blank">here</a>.</p>
<p>Now, it is time to set up our database and insert some data.</p>
<p><span>Creating database</span></p>
<p>Here I am creating a database with name &ldquo;TrialDB&rdquo;, you can always create a DB by running the query given below.</p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_812993">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[master]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Database&nbsp;[TrialDB]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">20</span><span class="js__num">-11</span><span class="js__num">-2016</span>&nbsp;<span class="js__num">03</span>:<span class="js__num">54</span>:<span class="js__num">53</span>&nbsp;PM&nbsp;******/&nbsp;
CREATE&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;
&nbsp;CONTAINMENT&nbsp;=&nbsp;NONE&nbsp;
&nbsp;ON&nbsp;&nbsp;PRIMARY&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialDB'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\TrialDB.mdf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;8192KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;UNLIMITED,&nbsp;FILEGROWTH&nbsp;=&nbsp;65536KB&nbsp;)&nbsp;
&nbsp;LOG&nbsp;ON&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialDB_log'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\TrialDB_log.ldf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;8192KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;2048GB&nbsp;,&nbsp;FILEGROWTH&nbsp;=&nbsp;65536KB&nbsp;)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;COMPATIBILITY_LEVEL&nbsp;=&nbsp;<span class="js__num">130</span>&nbsp;
GO&nbsp;
&nbsp;&nbsp;
IF&nbsp;(<span class="js__num">1</span>&nbsp;=&nbsp;FULLTEXTSERVICEPROPERTY(<span class="js__string">'IsFullTextInstalled'</span>))&nbsp;
begin&nbsp;
EXEC&nbsp;[TrialDB].[dbo].[sp_fulltext_database]&nbsp;@action&nbsp;=&nbsp;<span class="js__string">'enable'</span>&nbsp;
end&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ANSI_NULL_DEFAULT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ANSI_NULLS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ANSI_PADDING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ANSI_WARNINGS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ARITHABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;AUTO_CLOSE&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;AUTO_SHRINK&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;CURSOR_CLOSE_ON_COMMIT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;CURSOR_DEFAULT&nbsp;&nbsp;GLOBAL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;CONCAT_NULL_YIELDS_NULL&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;NUMERIC_ROUNDABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;QUOTED_IDENTIFIER&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;RECURSIVE_TRIGGERS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;&nbsp;DISABLE_BROKER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS_ASYNC&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;DATE_CORRELATION_OPTIMIZATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;TRUSTWORTHY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;ALLOW_SNAPSHOT_ISOLATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;PARAMETERIZATION&nbsp;SIMPLE&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;READ_COMMITTED_SNAPSHOT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;HONOR_BROKER_PRIORITY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;RECOVERY&nbsp;SIMPLE&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;&nbsp;MULTI_USER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;PAGE_VERIFY&nbsp;CHECKSUM&nbsp;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;DB_CHAINING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;FILESTREAM(&nbsp;NON_TRANSACTED_ACCESS&nbsp;=&nbsp;OFF&nbsp;)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;TARGET_RECOVERY_TIME&nbsp;=&nbsp;<span class="js__num">60</span>&nbsp;SECONDS&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;DELAYED_DURABILITY&nbsp;=&nbsp;DISABLED&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;QUERY_STORE&nbsp;=&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
USE&nbsp;[TrialDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;SET&nbsp;MAXDOP&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;FOR&nbsp;SECONDARY&nbsp;SET&nbsp;MAXDOP&nbsp;=&nbsp;PRIMARY;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;SET&nbsp;LEGACY_CARDINALITY_ESTIMATION&nbsp;=&nbsp;OFF;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;FOR&nbsp;SECONDARY&nbsp;SET&nbsp;LEGACY_CARDINALITY_ESTIMATION&nbsp;=&nbsp;PRIMARY;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;SET&nbsp;PARAMETER_SNIFFING&nbsp;=&nbsp;ON;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;FOR&nbsp;SECONDARY&nbsp;SET&nbsp;PARAMETER_SNIFFING&nbsp;=&nbsp;PRIMARY;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;SET&nbsp;QUERY_OPTIMIZER_HOTFIXES&nbsp;=&nbsp;OFF;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;SCOPED&nbsp;CONFIGURATION&nbsp;FOR&nbsp;SECONDARY&nbsp;SET&nbsp;QUERY_OPTIMIZER_HOTFIXES&nbsp;=&nbsp;PRIMARY;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialDB]&nbsp;SET&nbsp;&nbsp;READ_WRITE&nbsp;
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
<p><span>Create a table and insert data in database</span></p>
<p>To create a table, you can run the query below.</p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_403263">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Course]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">20</span><span class="js__num">-11</span><span class="js__num">-2016</span>&nbsp;<span class="js__num">03</span>:<span class="js__num">57</span>:<span class="js__num">30</span>&nbsp;PM&nbsp;******/&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[Course](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CourseID]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CourseName]&nbsp;[nvarchar](<span class="js__num">50</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CourseDescription]&nbsp;[nvarchar](<span class="js__num">100</span>)&nbsp;NULL,&nbsp;
&nbsp;CONSTRAINT&nbsp;[PK_Course]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CourseID]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
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
<p>Now we can insert few data to our newly created table.</p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_597284">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[Course]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([CourseID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseName]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseDescription])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'C#'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'Learn&nbsp;C#&nbsp;in&nbsp;7&nbsp;days'</span>)&nbsp;
&nbsp;INSERT&nbsp;INTO&nbsp;[dbo].[Course]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([CourseID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseName]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseDescription])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'Asp.Net'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'Learn&nbsp;Asp.Net&nbsp;in&nbsp;7&nbsp;days'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[Course]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([CourseID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseName]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseDescription])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'SQL'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'Learn&nbsp;SQL&nbsp;in&nbsp;7&nbsp;days'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[Course]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([CourseID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseName]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CourseDescription])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="js__num">4</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'JavaScript'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="js__string">'Learn&nbsp;JavaScript&nbsp;in&nbsp;7&nbsp;days'</span>)&nbsp;
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
<p>So our data is ready, that means we are all set to write our service and tests. Now go to your solution and create an entity data model.</p>
<div class="wp-caption x_alignnone" id="attachment_11931"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Entity_Framework-e1479637932362.png"><img class="size-full x_wp-image-11931" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Entity_Framework-e1479637932362.png" alt="entity_framework" width="634" height="686"></a>
<p class="wp-caption-text">entity_framework</p>
</div>
<p>So entity is also been created. Now please open your interface and that is where we start our coding. We can change the interface as follows.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_321390">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.Serialization.aspx" target="_blank" title="Auto generated link to System.Runtime.Serialization">System.Runtime.Serialization</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ServiceModel.aspx" target="_blank" title="Auto generated link to System.ServiceModel">System.ServiceModel</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;WCF_NUnit_Tests_Rheno_Mocks&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ServiceContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;interface&nbsp;IMyService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Course&nbsp;GetCourseById(int&nbsp;courseId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[OperationContract]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Course&gt;&nbsp;GetAllCourses();&nbsp;
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
<p>Here we have created two operations, one to get a course by id and one to retrieve all the courses as a list. Now please go and implement these two operations in our service file. You can modify that class as follows.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_160841">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.Serialization.aspx" target="_blank" title="Auto generated link to System.Runtime.Serialization">System.Runtime.Serialization</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ServiceModel.aspx" target="_blank" title="Auto generated link to System.ServiceModel">System.ServiceModel</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;WCF_NUnit_Tests_Rheno_Mocks&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;MyService&nbsp;:&nbsp;IMyService&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;MyEntity&nbsp;_myContext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;IMyService&nbsp;_myIService;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MyService()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MyService(IMyService&nbsp;myIService)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myContext&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MyEntity();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myIService&nbsp;=&nbsp;myIService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Course&nbsp;GetCourseById(int&nbsp;courseId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;crse&nbsp;=&nbsp;_myContext.Courses.FirstOrDefault(dt&nbsp;=&gt;&nbsp;dt.CourseID&nbsp;==&nbsp;courseId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;crse;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;List&lt;Course&gt;&nbsp;GetAllCourses()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;courses&nbsp;=&nbsp;(from&nbsp;dt&nbsp;<span class="js__operator">in</span>&nbsp;_myContext.Courses&nbsp;select&nbsp;dt).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;courses;&nbsp;
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
<p>In the above code, as you can see we are creating two constructor one is without parameter and other is with parameter, and we are having IMyService as a parameter. In this way we can achieve the dependency injection when we write tests for our unit. So
 what we need to do all is, just pass the dependency, in this case it is IMyService.</p>
<blockquote>
<p>In software engineering, dependency injection is a software design pattern that implements inversion of control for resolving dependencies. A dependency is an object that can be used (a service). An injection is the passing of a dependency to a dependent
 object (a client) that would use it. Source: WikiPedia</p>
</blockquote>
<p>If you need to know more on dependency injection, please read&nbsp;<a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection" target="_blank">here</a>. Now we will build and check whether our service is working fine or not.
 Please press CTRL&#43;F5.</p>
<div class="wp-caption x_alignnone" id="attachment_11932"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Invoking_WCF_Service.png"><img class="size-full x_wp-image-11932" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Invoking_WCF_Service-e1479645357913.png" alt="invoking_wcf_service" width="634" height="403"></a>
<p class="wp-caption-text">invoking_wcf_service</p>
</div>
<p>As our services are ready, we can now create the tests for those operations. For that we can create a new class library in our project and name it&nbsp;<em>UnitTest.Service</em>. Please add a class&nbsp;<em>MyServiceTests</em>&nbsp;in the class library where
 we can add our tests. And please do not forget to add our application reference too.</p>
<div class="wp-caption x_alignnone" id="attachment_11939"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Add_project_reference-e1479647898141.png"><img class="size-full x_wp-image-11939" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Add_project_reference-e1479647898141.png" alt="add_project_reference" width="634" height="438"></a>
<p class="wp-caption-text">add_project_reference</p>
</div>
<p><span>Installing and configuring NUnit</span></p>
<p>Now we can install NUnit to our test project from NuGet Package. Once you add the package, you will be able to add the preceding namespace in our&nbsp;<em>MyServiceTests</em>&nbsp;class.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_791120">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;NUnit.Framework;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>In NUnit we have so many attributes that can be used for different purposes, but now we are going to use only four among them.</p>
<li>TestFixture
<div class="wp-caption x_alignnone" id="attachment_11934"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/TestFixture_In_NUnit-e1479646568966.png"><img class="size-full x_wp-image-11934" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/TestFixture_In_NUnit-e1479646568966.png" alt="testfixture_in_nunit" width="634" height="191"></a>
<p class="wp-caption-text">testfixture_in_nunit</p>
</div>
</li><li>OneTimeSetUp
<div class="wp-caption x_alignnone" id="attachment_11935"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/One_Time_SetUp_Attribute_In_NUnit.png"><img class="size-large x_wp-image-11935" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/One_Time_SetUp_Attribute_In_NUnit-1024x283.png" alt="one_time_setup_attribute_in_nunit" width="634" height="175"></a>
<p class="wp-caption-text">one_time_setup_attribute_in_nunit</p>
</div>
<p>In previous versions, we were using&nbsp;<em>TestFixtureSetUp</em>, as the TestFixtureSetUp is obsolete, now we are using&nbsp;<em>OneTimeSetUp</em></p>
<div class="wp-caption x_alignnone" id="attachment_11937"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/TestFixtureSetUp_attribute_is_obsolete-e1479646895142.png"><img class="size-full x_wp-image-11937" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/TestFixtureSetUp_attribute_is_obsolete-e1479646895142.png" alt="testfixturesetup_attribute_is_obsolete" width="634" height="213"></a>
<p class="wp-caption-text">testfixturesetup_attribute_is_obsolete</p>
</div>
</li><li>TearDown
<p>This attribute is used to identify a method that is called immediately after each tests, it will be called even if there is any error, this is the place we can dispose our objects.</p>
</li><li>Test
<p>This attribute is used to make a method callable from NUnit test runner. This can not be inherited.</p>
<p>Now we can see all these attributes in action. So let us write some tests, but the real problem is we need to mock the IMyService right as the parameterized constructor of the class&nbsp;<em>MyService&nbsp;</em>expecting it. Remember, we have discussed about
 setting up our services in the way which can be injected the dependencies? No worries, we can install Rhino Mock for that now.</p>
<div class="wp-caption x_alignnone" id="attachment_11938"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Rhino_Mocks_In_Nuget_Package-1.png"><img class="size-large x_wp-image-11938" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Rhino_Mocks_In_Nuget_Package-1-1024x573.png" alt="rhino_mocks_in_nuget_package" width="634" height="355"></a>
<p class="wp-caption-text">rhino_mocks_in_nuget_package</p>
</div>
<p>So we can add the tests are dependencies as follows in our test class.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_865939">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;NUnit.Framework;&nbsp;
using&nbsp;Rhino.Mocks;&nbsp;
using&nbsp;WCF_NUnit_Tests_Rhino_Mocks;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;UnitTest.Service&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[TestFixture]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;MyServiceTests&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;MyService&nbsp;_myService;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;IMyService&nbsp;_myIservice;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[OneTimeSetUp]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;SetUp()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myIservice&nbsp;=&nbsp;MockRepository.GenerateMock&lt;IMyService&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myService&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MyService(_myIservice);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[TearDown]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;Clean()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Test(Description&nbsp;=&nbsp;<span class="js__string">&quot;A&nbsp;test&nbsp;to&nbsp;check&nbsp;whether&nbsp;the&nbsp;returned&nbsp;value&nbsp;is&nbsp;null&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;GetCourseById_Return_NotNull_Pass()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Up</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;crs&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Course&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CourseID&nbsp;=&nbsp;<span class="js__num">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CourseName&nbsp;=&nbsp;<span class="js__string">&quot;C#&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CourseDescription&nbsp;=&nbsp;<span class="js__string">&quot;Learn&nbsp;course&nbsp;in&nbsp;7&nbsp;days&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myIservice.Stub(dt&nbsp;=&gt;&nbsp;dt.GetCourseById(<span class="js__num">1</span>)).IgnoreArguments().Return(crs);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Act</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;crs&nbsp;=&nbsp;_myService.GetCourseById(<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Assert</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.IsNotNull(crs,<span class="js__string">&quot;The&nbsp;returned&nbsp;value&nbsp;is&nbsp;null&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Test(Description&nbsp;=&nbsp;<span class="js__string">&quot;A&nbsp;test&nbsp;to&nbsp;check&nbsp;we&nbsp;get&nbsp;all&nbsp;the&nbsp;courses&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;GetAllCourses_Return_List_Count_Pass()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Act</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;crs&nbsp;=&nbsp;_myService.GetAllCourses();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Assert</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="js__num">4</span>,&nbsp;crs.Count,<span class="js__string">&quot;The&nbsp;count&nbsp;of&nbsp;retrieved&nbsp;data&nbsp;doesn't&nbsp;match&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_myIservice.VerifyAllExpectations();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
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
<p>As you can see we have mocked our IMyService as follows.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_74191">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">_myIservice&nbsp;=&nbsp;MockRepository.GenerateMock&lt;IMyService&gt;();&nbsp;
&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div class="wp-caption x_alignnone" id="attachment_11940"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Generate_Mock_With_Rhino.png"><img class="size-large x_wp-image-11940" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Generate_Mock_With_Rhino-1024x247.png" alt="generate_mock_with_rhino" width="634" height="153"></a>
<p class="wp-caption-text">generate_mock_with_rhino</p>
</div>
<p>And, in the test&nbsp;<em>GetCourseById_Return_NotNull_Pass</em>&nbsp;we have also used a method called&nbsp;<em>Stub</em>. Stub actually tell the mock object to perform a certain action when a matching method is called, and it doesn&rsquo;t create an expectation
 for the same. So you might be thinking, how can we create an expectation? For that we have a method called&nbsp;<em>Expect</em>.</p>
<div class="wp-caption x_alignnone" id="attachment_11941"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Expect_In_Rhino_Mock.png"><img class="size-full x_wp-image-11941" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Expect_In_Rhino_Mock-e1479648794975.png" alt="expect_in_rhino_mock" width="634" height="149"></a>
<p class="wp-caption-text">expect_in_rhino_mock</p>
</div>
<p>It is always recommended to verify your expectation when you use&nbsp;<em>Expect</em>&nbsp;as we used it in our test&nbsp;<em>GetAllCourses_Return_List_Count_Pass</em>.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_253062">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">_myIservice.VerifyAllExpectations();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>As I already said, I am using Resharper, we have so many shortcuts to run our tests, now if you right click on your&nbsp;<em>TestFixture</em>. You can see a run all option as preceding.</p>
<div class="wp-caption x_alignnone" id="attachment_11942"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Run_all_test_option_in_Resharper-e1479649326532.png"><img class="size-full x_wp-image-11942" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Run_all_test_option_in_Resharper-e1479649326532.png" alt="run_all_test_option_in_resharper" width="634" height="574"></a>
<p class="wp-caption-text">run_all_test_option_in_resharper</p>
</div>
<blockquote>
<p>As I was getting an error as &ldquo;No connection string named &lsquo;Entity&rsquo; could be found in the application config file.&rdquo; when I run the tests, I was forced to install the entity framework in my test project and also add a new config file
 with the connection string like we have in our web config file.</p>
</blockquote>
<p>If everything goes fine and you don&rsquo;t have any errors, I am sure you will get a screen as preceding.</p>
<div class="wp-caption x_alignnone" id="attachment_11943"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/NUnit_Output.png"><img class="size-large x_wp-image-11943" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/NUnit_Output-1024x288.png" alt="nunit_output" width="634" height="178"></a>
<p class="wp-caption-text">nunit_output</p>
</div>
<p>Happy coding!.</p>
</li>