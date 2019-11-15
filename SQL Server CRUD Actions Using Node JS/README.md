# SQL Server CRUD Actions Using Node JS
## License
- MIT
## Technologies
- SQL Server
- Node.js
- Visual Studio 2015
## Topics
- SQL
- Visual Studio
- nodejs
## Updated
- 11/27/2016
## Description

<p>In this post we will see how we can perform CRUD application in our&nbsp;<a href="http://sibeeshpassion.com/category/SQL" target="_blank">SQL&nbsp;</a>database using&nbsp;<a href="http://sibeeshpassion.com/category/Node-JS/" target="_blank">Node JS</a>.
 As you all know Node JS is a run time environment built on Chrome&rsquo;s V8 JavaScript engine for server side and networking application. And it is an open source which supports cross platforms. Node JS applications are written in pure&nbsp;<a href="http://sibeeshpassion.com/category/javascript/" target="_blank">JavaScript</a>.
 If you are new to Node JS, I strongly recommend you to read my previous post about Node JS&nbsp;<a href="http://sibeeshpassion.com/introduction-to-node-js/" target="_blank">here</a>. Now let&rsquo;s begin.</p>
<p><br>
Background</p>
<p>There was a time where we developers are depended on any server side languages to perform server side actions, few years back a company called Joyent, Inc brought us a solution for this. That is, we can do the server side actions if you know JavaScript.
 Because of the wonderful idea behind this, it became a great success. You can do server side actions without knowing a single code related to any server side languages like&nbsp;<a href="http://sibeeshpassion.com/category/csharp/" target="_blank">C#</a>&nbsp;and&nbsp;<a href="http://sibeeshpassion.com/category/PHP/" target="_blank">PHP</a>.
 Here we are going to see how you can do the database actions like Create, Read, Update, Delete using Node JS. I hope you will like this.</p>
<p>Before we start coding our Node JS application, we can set up Node JS tool available for&nbsp;<a href="http://sibeeshpassion.com/category/visual-studio/" target="_blank">Visual Studio</a>.</p>
<p><span>Node JS tool for Visual Studio</span></p>
<blockquote>
<p>You can always run your Node JS code by using a command prompt, so setting up this tool is optional. If you install it, you can easily debug and develop Node JS. So I recommend you to install it.</p>
</blockquote>
<p>To download the tool, please click on this&nbsp;<a href="https://www.visualstudio.com/vs/node-js/" target="_blank">link</a>. Once you have downloaded the set up file, you can start installing it.</p>
<div class="wp-caption x_alignnone" id="attachment_11948"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Node_JS_tool_for_Visual_Studio.png"><img class="size-full x_wp-image-11948" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Node_JS_tool_for_Visual_Studio.png" alt="node_js_tool_for_visual_studio" width="618" height="483"></a>
<p class="wp-caption-text">node_js_tool_for_visual_studio</p>
</div>
<p>So I hope you have installed the application, Now you can create a Node JS application in our Visual Studio.</p>
<p><span>Creating Node JS Application In Visual Studio</span></p>
<p>You can find an option as Node JS in your Add New Project window as follows. Please click on that and create a new project.</p>
<div class="wp-caption x_alignnone" id="attachment_11949"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/New_Node_JS_Project.png"><img class="size-large x_wp-image-11949" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/New_Node_JS_Project-1024x709.png" alt="new_node_js_project" width="634" height="439"></a>
<p class="wp-caption-text">new_node_js_project</p>
</div>
<p>Now our Visual Studio is ready for coding, but as I mentioned earlier, we are going to use&nbsp;<a href="http://sibeeshpassion.com/category/sql-server/" target="_blank">SQL Server</a>&nbsp;as our database. So we need to do some configuration related to that
 too. Let&rsquo;s do it now.</p>
<p><span>Configure SQL Server For Node JS Development</span></p>
<p>You need to make sure that the following service are run.</p>
<li>SQL Server </li><li>SQL Server Agent (Skip it if you are using SQLEXPRESS </li><li>SQL Server Browser
<p>To check the status of these service, you can always services by running&nbsp;<em>services.msc</em>&nbsp;in Run command window. Once you are done, you need to enables some protocols and assign a port to it. Now go to your SQL Server Configuration Manager.
 Most probably you can find the file in this&nbsp;<em>C:\Windows\SysWOW64</em>location, if you cant find it start window.</p>
<div class="wp-caption x_alignnone" id="attachment_11950"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/SQL_Server_Manager_Location-e1480260854402.png"><img class="size-full x_wp-image-11950" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/SQL_Server_Manager_Location-e1480260854402.png" alt="sql_server_manager_location" width="634" height="206"></a>
<p class="wp-caption-text">sql_server_manager_location</p>
</div>
<p>Now go to SQL Server Network Configuration and click on Protocols for SQLEXPRESS(Your SQL Server) and Enable TCP/IP.</p>
<div class="wp-caption x_alignnone" id="attachment_11951"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Protocols_For_SQL_EXPRESS-e1480261046507.png"><img class="size-full x_wp-image-11951" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Protocols_For_SQL_EXPRESS-e1480261046507.png" alt="protocols_for_sql_express" width="634" height="266"></a>
<p class="wp-caption-text">protocols_for_sql_express</p>
</div>
<p>Now right click and click on Properties on TCP/IP. Go to to IP Addresses and assign port for all the IP.</p>
<div class="wp-caption x_alignnone" id="attachment_11952"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Assigning_TCP_IP_Port_In_SQL_Server.png"><img class="size-large x_wp-image-11952" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Assigning_TCP_IP_Port_In_SQL_Server-1024x707.png" alt="assigning_tcp_ip_port_in_sql_server" width="634" height="438"></a>
<p class="wp-caption-text">assigning_tcp_ip_port_in_sql_server</p>
</div>
<p>If have done it, it is time to set up our database and insert some data. Please do not forget to restart your service, as it is mandatory to get updated the changes we have done in the configurations.</p>
<div class="wp-caption x_alignnone" id="attachment_11954"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Restart_SQL_EXPRESS.png"><img class="size-large x_wp-image-11954" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Restart_SQL_EXPRESS-1024x595.png" alt="restart_sql_express" width="634" height="368"></a>
<p class="wp-caption-text">restart_sql_express</p>
</div>
<p><span>Creating database</span></p>
<p>Here I am creating a database with name &ldquo;TrialDB&rdquo;, you can always create a DB by running the query given below.</p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_171790">
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
<div class="syntaxhighlighter sql" id="highlighter_641564">
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
<div class="syntaxhighlighter sql" id="highlighter_455103">
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
<p>So our data is ready, that means we are all set to write our Node JS application. Go to the application we created and you can see a JS file there, normally named as&nbsp;<em>server.js</em>. Here I am going to change the name as&nbsp;<em>App.js</em>.</p>
<p><span>MSSQL &ndash; Microsoft SQL Server client for Node.js</span></p>
<p>You can find many packages for our day to day life in Node JS, what you need to do all is , just install that package and start using it. Here we are going to use a package called MSSQL.</p>
<p>Node-MSSQL</p>
</li><li>Has unified interface for multiple TDS drivers. </li><li>Has built-in connection pooling. </li><li>Supports built-in JSON serialization introduced in SQL Server 2016. </li><li>Supports Stored Procedures, Transactions, Prepared Statements, Bulk Load and TVP.
</li><li>Supports serialization of Geography and Geometry CLR types. </li><li>Has smart JS data type to SQL data type mapper. </li><li>Supports Promises, Streams and standard callbacks. </li><li>Supports ES6 tagged template literals. </li><li>Is stable and tested in production environment. </li><li>Is well documented.
<p>You can find more about the package&nbsp;<a href="https://www.npmjs.com/package/mssql" target="_blank">here</a>. You can easily install this package by running the following command in your Nuget Package Manager Console.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_587742">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2">1</div>
</td>
<td class="code">
<div class="container">
<div class="line number1 index0 alt2"><code class="csharp plain">npm install mssql</code></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<div class="wp-caption x_alignnone" id="attachment_11953"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/MSSQL_Node_JS_Install.png"><img class="size-large x_wp-image-11953" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/MSSQL_Node_JS_Install-1024x236.png" alt="mssql_node_js_install" width="634" height="146"></a>
<p class="wp-caption-text">mssql_node_js_install</p>
</div>
<p>Now we can load this package by using a function called require.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_678552">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//MSSQL&nbsp;Instance&nbsp;Creation</span>&nbsp;
<span class="js__statement">var</span>&nbsp;sqlInstance&nbsp;=&nbsp;require(<span class="js__string">&quot;mssql&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p>Then, you can set the database configurations as preceding.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_485608">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//Database&nbsp;configuration</span>&nbsp;
<span class="js__statement">var</span>&nbsp;setUp&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;server:&nbsp;<span class="js__string">'localhost'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;database:&nbsp;<span class="js__string">'TrialDB'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;user:&nbsp;<span class="js__string">'sa'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;password:&nbsp;<span class="js__string">'sa'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;port:&nbsp;<span class="js__num">1433</span>&nbsp;
<span class="js__brace">}</span>;</pre>
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
<p>Once you have a configuration set up, you can connect your database by using connect() function.</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_830707">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2">1</div>
</td>
<td class="code">
<div class="container">
<div class="line number1 index0 alt2"><code class="jscript x_plain">sqlInstance.connect(setUp)</code></div>
</div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p>Now we can perform the CRUD operations. Are you ready?</p>
<p><span>Select all the data from database using Node JS</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_420032">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;retrieve&nbsp;all&nbsp;the&nbsp;data&nbsp;-&nbsp;Start</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;sqlInstance.Request()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.query(<span class="js__string">&quot;select&nbsp;*&nbsp;from&nbsp;Course&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.then(<span class="js__operator">function</span>&nbsp;(dbData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(dbData&nbsp;==&nbsp;null&nbsp;||&nbsp;dbData.length&nbsp;===&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.dir(<span class="js__string">'All&nbsp;the&nbsp;courses'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.dir(dbData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.<span class="js__statement">catch</span>(<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.dir(error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;retrieve&nbsp;all&nbsp;the&nbsp;data&nbsp;-&nbsp;End</span></pre>
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
<p>Now run your application and see the output as preceding.</p>
<div class="wp-caption x_alignnone" id="attachment_11955"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/11/Node_JS_Select_All_Data_From_Database.png"><img class="size-full x_wp-image-11955" src="http://sibeeshpassion.com/wp-content/uploads/2016/11/Node_JS_Select_All_Data_From_Database.png" alt="node_js_select_all_data_from_database" width="583" height="414"></a>
<p class="wp-caption-text">node_js_select_all_data_from_database</p>
</div>
<p>You can always download the source code attached to see the complete code and application. Happy coding!.</p>
</li>