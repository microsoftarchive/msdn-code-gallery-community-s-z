# SharePoint 2013: Query Search with the KeywordQuery Class
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
- SharePoint 2013
## Topics
- Search
- Enterprise Search
## Updated
- 04/19/2013
## Description

<p><strong>Provided by:</strong><span>&nbsp;</span><a href="http://www.dotnetmafia.com/">Corey Roth</a><span>,&nbsp;</span><a href="http://www.sp2apps.com/">SP2 Apps</a></p>
<h1>Introduction</h1>
<p>This code sample provides details on how to query Search with the new SharePoint 2013 object model using the
<a href="http://msdn.microsoft.com/en-us/library/microsoft.office.server.search.query.keywordquery.aspx">
KeywordQuery</a> class. &nbsp;Typically, the KeywordQuery class is used directly inside SharePoint web parts or on other applications running directly on the SharePoint farm.</p>
<p>For querying with the Client Object Model, see this <a href="http://code.msdn.microsoft.com/Query-Search-with-the-649f1bc1">
sample</a>.</p>
<h1><span>Building the Sample</span></h1>
<p><span>The sample is a console application.&nbsp; Edit the server URL in the SPSite constructor for a site collection on your SharePoint 2013 server.&nbsp; Build the solution as normal.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This example demonstrates how to query search using the SharePoint 2013 Search
<strong>KeywordQuery </strong>class.&nbsp; To get started, create a console application and add references to the appropriate assemblies.&nbsp; These assemblies can be found in the ISAPI folder of the 15 hive.</p>
<ul>
<li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Server.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Server">Microsoft.Office.Server</a> </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Server.Search.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Server.Search">Microsoft.Office.Server.Search</a> </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a> </li><li><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.Security.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.Security">Microsoft.SharePoint.Security</a> </li></ul>
<p>Add the following references:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Data.aspx" target="_blank" title="Auto generated link to System.Data">System.Data</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Office.Server.Search.Query.aspx" target="_blank" title="Auto generated link to Microsoft.Office.Server.Search.Query">Microsoft.Office.Server.Search.Query</a>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Add a SPSite object for a site collection on your SharePoint farm.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(SPSite&nbsp;siteCollection&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SPSite(<span class="cs__string">&quot;http://server/sitecollection&quot;</span>))&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Create a&nbsp;</span><strong>KeywordQuery</strong><span>&nbsp;object using that site collection.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">KeywordQuery&nbsp;keywordQuery&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeywordQuery(siteCollection);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Now, specify the query using the <em>QueryText</em> field. &nbsp;You can specify custom KQL queries here.&nbsp; See this
<a href="http://msdn.microsoft.com/en-us/library/ee558911.aspx">post</a> for more on KQL.&nbsp;</span><span>&nbsp;For the example, we'll search on the term&nbsp;</span><em>SharePoint</em><span>.</span></div>
</span></div>
<div class="endscriptcode"><span><br>
</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">keywordQuery.QueryText&nbsp;=&nbsp;<span class="cs__string">&quot;SharePoint&quot;</span>;</pre>
</div>
</div>
</div>
Use the <a href="http://msdn.microsoft.com/en-us/library/jj250940.aspx">SearchExecutor</a> class to execute the query.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">SearchExecutor&nbsp;searchExecutor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SearchExecutor();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Use the&nbsp;<em>ExecuteQuery</em>&nbsp;method by passing an instance of the&nbsp;<em>KeywordQuery</em>&nbsp;class.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">ResultTableCollection&nbsp;resultTableCollection&nbsp;=&nbsp;searchExecutor.ExecuteQuery(keywordQuery);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Assuming no exception occurs, you can now iterate through the results. &nbsp;Use the new&nbsp;<em>Filter&nbsp;</em>method on the
<strong>ResultTableCollection </strong>to get the relevant results. For the first value, it needs a string with a value of&nbsp;<em>TableType</em>&nbsp;and the second value uses&nbsp;<em>KnownTableTypes.RelevantResults</em>.</span></div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;resultTables&nbsp;=&nbsp;resultTableCollection.Filter(<span class="cs__string">&quot;TableType&quot;</span>,&nbsp;KnownTableTypes.RelevantResults);&nbsp;</pre>
</div>
</div>
</div>
<p>It returns an&nbsp;<strong>IEnumerable&lt;ResultType&gt;</strong>, so filter it with&nbsp;<em>FirstOrDefault()</em>&nbsp;to get the needed table.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;resultTable&nbsp;=&nbsp;resultTables.FirstOrDefault();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The data can then be retrieved from the DataTable.</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">DataTable&nbsp;dataTable&nbsp;=&nbsp;resultTable.Table;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">That's it.&nbsp; Review the code from the solution file for the complete listing.</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Main.cs - console application which queries the Search Client Object Model.</em>
</li></ul>
<h1>More Information</h1>
<p><em><em>For more information, see my blog entry at&nbsp;<a href="http://www.dotnetmafia.com/blogs/dotnettipoftheday/archive/2013/01/03/how-to-use-the-sharepoint-2013-search-keywordquery-class.aspx">DotNetMafia.com</a>.&nbsp; Follow me on twitter:&nbsp;<a href="http://twitter.com/coreyroth">@coreyroth</a>.</em></em></p>
