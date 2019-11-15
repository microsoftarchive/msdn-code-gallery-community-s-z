# Working with SQL Server Management Objects (SMO) Part 1 (C#)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- SQL Server
- SMO
- SQL Server SMO
## Topics
- SQL Server
- Data Access
- SMO
- SQL Server SMO
## Updated
- 12/26/2017
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This code sample shows some of the basics for working with SQL Server Management Objects commonly referred to as SMO.</span></p>
<p><span style="font-size:small">SQL Server Management Objects (SMO) is a collection of objects that are designed for programming all aspects of managing Microsoft SQL Server. SQL Server Replication Management Objects (RMO) is a collection of objects that encapsulates
 SQL Server replication management.</span></p>
<p><span style="font-size:small">To get a good overview see the <a href="https://docs.microsoft.com/en-us/sql/relational-databases/server-management-objects-smo/sql-server-management-objects-smo-programming-guide">
SMO Programming Guide</a>.</span></p>
<p><span style="font-size:small">Please note, whenever possible consider options e.g. should I do this task in code via SMO,
<a href="https://technet.microsoft.com/en-us/library/ms189826%28v=sql.90%29.aspx?f=255&MSPPError=-2147217396">
T-SQL</a> or <a href="https://docs.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms">
SSMS</a>. Always know your toolbox. Suppose I want to know if a database exists or a table exists, T-SQL or SMO works (here is
<a href="https://code.msdn.microsoft.com/SQL-Server-check-if-server-1f53886f?redir=0">
a T-SQL solution</a> I wrote) or perhaps you need detault server and want to create database and tables, here is
<a href="https://code.msdn.microsoft.com/Get-default-SQL-Server-b090d9d4?redir=0">
a code mixure</a> of T-SQL and SMO I wrote.</span></p>
<p><span style="font-size:small">Last thing, although this is shown in a desktop solution this will work on a server too as I've placed all operations (other than execution) in classes where the classes could be placed into a class project and then used.</span></p>
<p><span style="font-size:small"><a href="https://code.msdn.microsoft.com/Working-with-SQL-Server-986fff9e">Part 2 is here</a>.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">There are several DLL files which are required that may not appear in the dialog for adding the references to your project. Below is the path for my machine, depending on the version installed on your machine you might need
 to traverse to a different folder e.g. instead of the 130 in the path it might be 120.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><span style="font-size:large"><span style="color:#ff0000"><strong>Special note</strong></span>:</span> I have modified the solution since the initial publish. Now the form which fires up is shown at the bottom of this page.
 You can change to the original form by opening Program.cs and changing the form there. Also I now have a class project which you can use easily in your solution.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><em><img id="184231" src="184231-smo__references.jpg" alt="" width="575" height="498"><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">There many operations which may be performed with SMO from obtaining information about SQL-Server objects to creating and modifying objects or perhaps backing up or restoring a database.</span></p>
<p><span style="font-size:small">In this code sample (part 1) I will show you how to setup a class that provides the ability to get databases, tables, table columns and column information from a specific database server.</span></p>
<p><span style="font-size:small">Let's look at a screenshot of a form which provides a high level overview. I've rotated it sideways as a normal view would not be readable.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><img id="184232" src="184232-screenshotofform.jpg" alt="" width="470" height="1108"></p>
<p>&nbsp;</p>
<p><span style="font-size:small">There are several buttons, &quot;Load database names from server&quot; does just that, loads names of databases from a server. In the class used to get this information we have the following.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Your&nbsp;server&nbsp;name&nbsp;e.g.&nbsp;could&nbsp;be&nbsp;(local)&nbsp;or&nbsp;perhaps&nbsp;.\SQLEXPRESS</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ServerName&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;=&gt;&nbsp;<span class="cs__string">&quot;KARENS-PC&quot;</span>;&nbsp;}&nbsp;
<span class="cs__keyword">private</span>&nbsp;Server&nbsp;mServer;&nbsp;
<span class="cs__keyword">public</span>&nbsp;SmoOperations()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mServer&nbsp;=&nbsp;InitializeServer();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Here &quot;ServerName&quot; represents the SQL-Server name where mine is KARENS-PC. You need to change this to the name of your SQL-Server.</span></div>
<div class="endscriptcode"><span style="color:#ffffff; font-size:small">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">For all operations we need a
<a href="https://msdn.microsoft.com/en-us/library/microsoft.sqlserver.management.smo.server.aspx?f=255&MSPPError=-2147217396">
Server</a> object. In the class I setup a private variable for the server and intialize it from the class constructor.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;Server&nbsp;mServer;&nbsp;
public&nbsp;SmoOperations()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mServer&nbsp;=&nbsp;InitializeServer();&nbsp;
<span class="js__brace">}</span>&nbsp;
Server&nbsp;InitializeServer()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServerConnection&nbsp;connection&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ServerConnection(ServerName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Server&nbsp;sqlServer&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Server(connection);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;sqlServer;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Now to get the database names the server object is ready to use.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;List&lt;string&gt;&nbsp;DatabaseNames()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;databaseNames&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;server.Databases.OfType&lt;Database&gt;().Select(db&nbsp;=&gt;&nbsp;db.Name).ToList();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">It would be good to know if a database exists so we use the above with slight modifications.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Determine&nbsp;if&nbsp;database&nbsp;exists&nbsp;on&nbsp;the&nbsp;server.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
public&nbsp;bool&nbsp;DatabaseExists(string&nbsp;pDatabaseName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;databaseNames&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(item&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Usually we want to do something to the database so there is a method to get a database object.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Return&nbsp;a&nbsp;valid&nbsp;Database&nbsp;based&nbsp;on&nbsp;a&nbsp;database&nbsp;name</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;Database&nbsp;GetDatabase(<span class="cs__keyword">string</span>&nbsp;pDatabaseName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;databaseNames&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Once we have a database or databases we can get table information, first table names.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Get&nbsp;table&nbsp;names&nbsp;for&nbsp;database</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;Exists&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;remarks&gt;System&nbsp;objects/tables&nbsp;are&nbsp;filtered&nbsp;out&lt;/remarks&gt;</span>&nbsp;
public&nbsp;List&lt;string&gt;&nbsp;TableNames(string&nbsp;pDatabaseName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;tableNames&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(database&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tableNames&nbsp;=&nbsp;database.Tables.OfType&lt;Table&gt;().Where(tbl&nbsp;=&gt;&nbsp;!tbl.IsSystemObject).Select(tbl&nbsp;=&gt;&nbsp;tbl.Name).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;tableNames;&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;Does the table exists in a database?</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Does&nbsp;the&nbsp;table&nbsp;exists&nbsp;in&nbsp;the&nbsp;specified&nbsp;database</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;valid&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pTableName&quot;&gt;Table&nbsp;name&nbsp;to&nbsp;see&nbsp;if&nbsp;it&nbsp;exists&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
public&nbsp;bool&nbsp;TableExists(string&nbsp;pDatabaseName,&nbsp;string&nbsp;pTableName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;exists&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(database&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exists&nbsp;=&nbsp;(database.Tables.OfType&lt;Table&gt;().Where(tbl&nbsp;=&gt;&nbsp;!tbl.IsSystemObject).FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pTableName)&nbsp;!=&nbsp;null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;exists;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">From here let's get column names for a table in a database.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Get&nbsp;column&nbsp;names&nbsp;for&nbsp;table&nbsp;in&nbsp;database.</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;valid&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pTableName&quot;&gt;Exists&nbsp;table&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
public&nbsp;List&lt;string&gt;&nbsp;TableColumnNames(string&nbsp;pDatabaseName,&nbsp;string&nbsp;pTableName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;columnNames&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(database&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;table&nbsp;=&nbsp;database.Tables.OfType&lt;Table&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pTableName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(table&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnNames&nbsp;=&nbsp;table.Columns.OfType&lt;Column&gt;().Select(col&nbsp;=&gt;&nbsp;col.Name).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;columnNames;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Does a specific column exists by name?</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Does&nbsp;a&nbsp;column&nbsp;name&nbsp;exists&nbsp;in&nbsp;a&nbsp;table&nbsp;within&nbsp;a&nbsp;specific&nbsp;database</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;valid&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pTableName&quot;&gt;Exists&nbsp;table&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pColumnName&quot;&gt;Column&nbsp;to&nbsp;check&nbsp;if&nbsp;it&nbsp;exists&nbsp;in&nbsp;pTableName&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
public&nbsp;bool&nbsp;ColumnExists(string&nbsp;pDatabaseName,&nbsp;string&nbsp;pTableName,&nbsp;string&nbsp;pColumnName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;exists&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(database&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;table&nbsp;=&nbsp;database.Tables.OfType&lt;Table&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pTableName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(table&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exists&nbsp;=&nbsp;(table.Columns.OfType&lt;Column&gt;().FirstOrDefault(col&nbsp;=&gt;&nbsp;col.Name&nbsp;==&nbsp;pColumnName)&nbsp;!=&nbsp;null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;exists;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;Get details for columns, here I've touched only the surface of information we can get and hopefully you get a good idea where to go from here.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Get&nbsp;details&nbsp;for&nbsp;each&nbsp;column&nbsp;in&nbsp;a&nbsp;table&nbsp;within&nbsp;a&nbsp;database.</span>&nbsp;
<span class="cs__com">///&nbsp;There&nbsp;are&nbsp;more&nbsp;details&nbsp;then&nbsp;returned&nbsp;here&nbsp;so&nbsp;feel&nbsp;free&nbsp;to&nbsp;explore.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;valid&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;pTableName&quot;&gt;Exists&nbsp;table&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;List&lt;ColumnDetails&gt;&nbsp;GetColumnDetails(<span class="cs__keyword">string</span>&nbsp;pDatabaseName,&nbsp;<span class="cs__keyword">string</span>&nbsp;pTableName)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;columnDetails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;ColumnDetails&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;columnNames&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(database&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;table&nbsp;=&nbsp;database.Tables.OfType&lt;Table&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pTableName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(table&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columnDetails&nbsp;=&nbsp;table.Columns.OfType&lt;Column&gt;().Select(col&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;ColumnDetails()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identity&nbsp;=&nbsp;col.Identity,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataType&nbsp;=&nbsp;col.DataType,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;col.Name,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InPrimaryKey&nbsp;=&nbsp;col.InPrimaryKey,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nullable&nbsp;=&nbsp;col.Nullable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;columnDetails;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">A visual representation where I focus on dates.</span></div>
<div class="endscriptcode"><img id="184235" src="184235-1a.jpg" alt="" width="612" height="322">&nbsp;</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Here is the backing class for column information. Note the read-only properties e.g. IsDate, IsDateTime, IsDateTimeOffset</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SqlServer.Management.Smo.aspx" target="_blank" title="Auto generated link to Microsoft.SqlServer.Management.Smo">Microsoft.SqlServer.Management.Smo</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WindowsFormsApp1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Container&nbsp;for&nbsp;columns&nbsp;of&nbsp;a&nbsp;table&nbsp;in&nbsp;a&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ColumnDetails&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Column&nbsp;is&nbsp;a&nbsp;identify&nbsp;column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;the&nbsp;field&nbsp;is&nbsp;Identity&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Identity&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;General&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Column&nbsp;Name&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;There&nbsp;are&nbsp;plenty&nbsp;of&nbsp;useful&nbsp;properties&nbsp;within&nbsp;DataType&nbsp;as&nbsp;an</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;example&nbsp;in&nbsp;the&nbsp;property&nbsp;SqlDataType&nbsp;or&nbsp;IsDate&nbsp;(which&nbsp;we&nbsp;know</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;there&nbsp;are&nbsp;multiple&nbsp;data&nbsp;types).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Describes&nbsp;the&nbsp;data&nbsp;type&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataType&nbsp;DataType&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Describes&nbsp;the&nbsp;sql&nbsp;data&nbsp;type&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;SqlDataType&nbsp;SqlDataType&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;DataType.SqlDataType;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;I&nbsp;setup&nbsp;several&nbsp;properties&nbsp;for&nbsp;Dates&nbsp;to&nbsp;show&nbsp;that&nbsp;we&nbsp;can&nbsp;do&nbsp;this&nbsp;but&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;generally&nbsp;speaking&nbsp;we&nbsp;don't&nbsp;need&nbsp;to&nbsp;do&nbsp;all&nbsp;of&nbsp;them.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;this&nbsp;field&nbsp;is&nbsp;a&nbsp;Date&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;DataType.SqlDataType&nbsp;==&nbsp;SqlDataType.Date;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;this&nbsp;field&nbsp;is&nbsp;a&nbsp;DateTime&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsDateTime&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;DataType.SqlDataType&nbsp;==&nbsp;SqlDataType.DateTime;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;this&nbsp;field&nbsp;is&nbsp;a&nbsp;DateTime&nbsp;Offset&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsDateTimeOffset&nbsp;{&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;DataType.SqlDataType&nbsp;==&nbsp;SqlDataType.DateTimeOffset;&nbsp;}&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;this&nbsp;field&nbsp;is&nbsp;Nullable&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Nullable&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;Indicates&nbsp;if&nbsp;field&nbsp;is&nbsp;in&nbsp;a&nbsp;primary&nbsp;key&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;InPrimaryKey&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;get&nbsp;foreign&nbsp;keys</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;ForeignKeys&nbsp;DataTable&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataTable&nbsp;ForeignKeys&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Contains&nbsp;row&nbsp;data&nbsp;retrieved&nbsp;from&nbsp;EnumForeignKeys</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;which&nbsp;represent&nbsp;any&nbsp;foreign&nbsp;key&nbsp;definitions</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CategoryAttribute(<span class="cs__string">&quot;Items&quot;</span>),&nbsp;DescriptionAttribute(<span class="cs__string">&quot;ForeignKeys&nbsp;break&nbsp;down&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;ForeignKeysDetails&gt;&nbsp;ForeignKeysList&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Name;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Next, key constraints, read them (not changing anything here or reading the actual keys).</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;Get&nbsp;foreign&nbsp;key&nbsp;details&nbsp;for&nbsp;specified&nbsp;table&nbsp;in&nbsp;specified&nbsp;database</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pDatabaseName&quot;&gt;valid&nbsp;SQL-Server&nbsp;database&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;param&nbsp;name=&quot;pTableName&quot;&gt;Exists&nbsp;table&nbsp;in&nbsp;pDatabaseName&lt;/param&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
public&nbsp;List&lt;ForeignKeysDetails&gt;&nbsp;TableKeys(string&nbsp;pDatabaseName,&nbsp;string&nbsp;pTableName)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;keyList&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;ForeignKeysDetails&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;server&nbsp;=&nbsp;mServer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;database&nbsp;=&nbsp;server.Databases.OfType&lt;Database&gt;().FirstOrDefault(db&nbsp;=&gt;&nbsp;db.Name&nbsp;==&nbsp;pDatabaseName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(database&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;table&nbsp;=&nbsp;database.Tables.OfType&lt;Table&gt;().FirstOrDefault(tbl&nbsp;=&gt;&nbsp;tbl.Name&nbsp;==&nbsp;pTableName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(table&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(Column&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;table.Columns.OfType&lt;Column&gt;())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;&nbsp;ForeignKeysDetails&gt;&nbsp;fkds&nbsp;=&nbsp;item.EnumForeignKeys().AsEnumerable().Select(row&nbsp;=&gt;&nbsp;<span class="js__operator">new</span>&nbsp;ForeignKeysDetails&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableSchema&nbsp;=&nbsp;row.Field&lt;string&gt;(<span class="js__string">&quot;Table_Schema&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableName&nbsp;=&nbsp;row.Field&lt;string&gt;(<span class="js__string">&quot;Table_Name&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SchemaName&nbsp;=&nbsp;row.Field&lt;string&gt;(<span class="js__string">&quot;Name&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).ToList();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(ForeignKeysDetails&nbsp;ts&nbsp;<span class="js__operator">in</span>&nbsp;fkds)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;keyList.Add(ts);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;keyList;&nbsp;
&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Backing class for keys</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;ForeignKeysDetails&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;TableSchema&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;TableName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;SchemaName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;string&nbsp;ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;SchemaName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">After the first publish I added a class project for the smo operations so you can easily add the class project to your solution.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Also added a code sample that builds on the above which is to create an SQL INSERT statement suitable for using in your code.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Here is the form.</span></div>
<div class="endscriptcode"><span style="font-size:small"><img id="184244" src="https://i1.code.msdn.s-msft.com/working-with-sql-server-2443a157/image/file/184244/1/buildinsertstatement.jpg" alt="" width="558" height="444"></span></div>
<div class="endscriptcode"><span style="font-size:small">As in the first example, select a database, in this case from the Combobox followed by selecting a table. Once the table is selected a CheckedListBox is populated with columns. Select columns and press
 &quot;Create INSERT statement&quot; button. The insert statement excludes any identity columns as the primary-key is generally a auto-incrementing field so in the selection if you selected a identity column (like I did in the above example I check for this in each item
 as the CheckedListBox is populated with ColumnDetails hence we can check if any field is an identity fields.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small"><img id="184245" src="https://i1.code.msdn.s-msft.com/working-with-sql-server-2443a157/image/file/184245/1/04.jpg" alt="" width="468" height="138"></span></div>
<div class="endscriptcode"><span style="font-size:small">Note the check box for wrap columns with [] around field names, this is good for fields with spaces or reserved words. The code could be altered to catch reserved words but that gets a little outside
 where I wanted to go with this.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">That's it for part 1, will dig deeper in part 2 I will go deeper into smo operations and scriptting database and table objects (all of this functionality is available in
<a href="https://www.red-gate.com/products/sql-development/sql-prompt/entrypage/get-your-license">
Red-Gate SQL Prompt</a> in <a href="https://docs.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms">
SSMS</a>).</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Hopefully this code sample finds usefullness for your coding.&nbsp;</span></div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
