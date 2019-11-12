# Simple connection methods for MS-Access using OleDb data provider
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Data Access
- OLEDB
- ACE.OLEDB
## Topics
- Windows Forms
- Data Access
- Databases
## Updated
- 06/01/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">Microsoft Access database, for many new developers just starting out is there choice for learning how to work with databases. There are a handful of methods to interact with MS-Access databases where one uses OleDb, a managed
 data provider. When working with OleDb one simple needs to create a connection object and a command object to do CRUD (Create, Read, Update and Delete operations). At the command object level you might uses a DataTable to return a record-set, use a DataReader
 to cycle through returned data etc.</span><br>
<br>
<span style="font-size:small">The focus here is creating the connection string. The majority of new developers will create a connection string by concatenating various properties of the connection string together which can lead to issues when done incorrectly.
 This is where the OleDbConnectionStringBuilder class shines in that you instantiate a new instance of the OleDbConnectionStringBuilder class and set two properties, Provider which denotes the name of the data provider associated with the internal connection
 string and the DataSource which represents (in this case) the full path and file name of the database to open. Before going any farther I would suggest reviewing the other properties and methods of the OleDbConnectionStringBuilder.</span><br>
<br>
<span style="font-size:small">Okay, getting to the point of why have a method presented here to create a connection string which we can feed to the connection object, OleDbConnection. &nbsp;There are two major versions of MS-Access, one ends with .MDB while
 the other ends with .ACCDB extension. Both require different providers which brings us to the code in this code sample.</span></p>
<p><span style="font-size:small">The code below is a function turned into a language extension method,
<a href="https://msdn.microsoft.com/en-us/library/bb383977.aspx">C# description</a> and
<a href="https://msdn.microsoft.com/en-us/library/bb384936.aspx">VB.NET description</a>.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Data.OleDb.aspx" target="_blank" title="Auto generated link to System.Data.OleDb">System.Data.OleDb</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;AccessConnections_cs&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ConnectionsAccess&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;providers&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__string">&quot;.accdb&quot;</span>&nbsp;,&nbsp;<span class="cs__string">&quot;Microsoft.ACE.OLEDB.12.0&quot;</span>&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__string">&quot;.mdb&quot;</span>&nbsp;,&nbsp;<span class="cs__string">&quot;Microsoft.Jet.OLEDB.4.0&quot;</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;BuildConnectionString(<span class="cs__keyword">this</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;DatabaseName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OleDbConnectionStringBuilder&nbsp;Builder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OleDbConnectionStringBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Provider&nbsp;=&nbsp;providers[Path.GetExtension(DatabaseName).ToLower()],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSource&nbsp;=&nbsp;DatabaseName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Builder.ConnectionString;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><span style="font-size:small">These extension methods do basically one thing, which is look at the file passed in, get it's extension and retrieve the proper provider from a dictionary. The provider is set in the &nbsp;new instance of our&nbsp;OleDbConnectionStringBuilder
 and the file name passed in is set as the DataSource.</span></p>
<p><span style="font-size:small">The usage is simple, call the extension method on the file name as the extension method is for strings which our file name is.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(OleDbConnection&nbsp;cn&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OleDbConnection&nbsp;{&nbsp;ConnectionString&nbsp;=&nbsp;fileName.BuildConnectionString()&nbsp;})</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">How to implement into your project, add the appropriate languge class project to your solution, add a reference to the project you are working with MS-Access and create your connection the same or similar
 as I have done in the demo projects.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">As in the demo projects I always use a Using statement so to access data then immediately dispose of all objects rather than using a global connection which is not so much a big deal in desktop projects
 but usually is with web applications.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">Even after getting passed the novice stage of coding these methods are still valuable in your toolbox as they simply work and are out of sight. Sure there are other ways to do what has been shown here,
 it's up to you to decide what is best for your style of coding.</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
