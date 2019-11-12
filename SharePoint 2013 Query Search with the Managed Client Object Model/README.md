# SharePoint 2013: Query Search with the Managed Client Object Model
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
- SharePoint 2013
## Topics
- Search
- Client Object Model
- SharePoint client object model (CSOM)
## Updated
- 04/19/2013
## Description

<p><strong>Provided by:</strong><span>&nbsp;</span><a href="http://www.dotnetmafia.com/">Corey Roth</a><span>,&nbsp;</span><a href="http://www.sp2apps.com/">SP2 Apps</a></p>
<h1>Introduction</h1>
<div>This code sample provides details on how to query Search with the new SharePoint 2013 Client Object Model.</div>
<h1><span>Building the Sample</span></h1>
<div>The sample is a console application.&nbsp; Edit the server URL in the ClientContext constructor for your SharePoint 2013 server.&nbsp; Build the solution as normal.</div>
<div></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div>This example demonstrates how to use the SharePoint 2013 Search Client Object Model.&nbsp; To get started, we first need to add referenced to the appropriate assemblies.&nbsp; These assemblies can be found in the ISAPI folder of the 15 hive.</div>
<ul>
<li>Microsoft.SharePoint.Client.dll </li><li>Microsoft.SharePoint.Client.Runtime.dll </li><li>Microsoft.SharePoint.Client.Search.dll </li></ul>
<div>Now in our console application, we need to add the following references:</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.Client.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.Client">Microsoft.SharePoint.Client</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.SharePoint.Client.Search;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.Client.Search.Query.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.Client.Search.Query">Microsoft.SharePoint.Client.Search.Query</a>;</pre>
</div>
</div>
</div>
Start by creating a ClientContext object and pass in the URL to a site.&nbsp; Put this in a using block.</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;(ClientContext&nbsp;clientContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ClientContext(<span class="cs__string"><a href="http://servername">http://servername</a></span>))</pre>
</div>
</div>
</div>
Then, create a KeywordQuery class to describe the query.&nbsp; This class is similar to the server side KeywordQuery class but there are some differences.&nbsp; Pass the ClientContext into the constructor.</div>
<div>&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">KeywordQuery&nbsp;keywordQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;KeywordQuery(clientContext);</pre>
</div>
</div>
</div>
<div class="endscriptcode">To set the query use the QueryText property.&nbsp; For example, a search for the keyword &ldquo;SharePoint&rdquo;.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">keywordQuery.QueryText&nbsp;=&nbsp;<span class="js__string">&quot;SharePoint&quot;</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Unlike the server object model, with the Client OM we have to use another class, SearchExecutor, to send the queries to the search engine.&nbsp; Pass a ClientContext to it as well:</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">SearchExecutor&nbsp;searchExecutor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SearchExecutor(clientContext);</pre>
</div>
</div>
</div>
To execute the query, we use the ExecuteQuery method.&nbsp; It returns a type of ClientResult&lt;ResultTableCollection&gt;.</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">ClientResult&lt;ResultTableCollection&gt;&nbsp;results&nbsp;=&nbsp;searchExecutor.ExecuteQuery(keywordQuery);</pre>
</div>
</div>
</div>
<div class="endscriptcode">However, the query doesn&rsquo;t actually execute until you call ExecuteQuery() on the ClientContext object.&nbsp; If you have done a lot of Client OM work before, you might think you need to call Load() first but it is not required.</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">clientContext.ExecuteQuery();</pre>
</div>
</div>
</div>
Assuming no exception occurs, you can now iterate through the results.&nbsp; The ClientResult&lt;ResultTableCollection&gt; will have a property called Value.&nbsp; You will want to check the zero index of it to get the search results.&nbsp; From there, the
 ResultRows collection has the data of each row.&nbsp; This object is simply a dictionary object that you can use an indexer with and pass the name of the managed property.&nbsp; In the example below, write out the Title, Path, and Modified Date (Write).</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">foreach&nbsp;(<span class="js__statement">var</span>&nbsp;resultRow&nbsp;<span class="js__operator">in</span>&nbsp;results.Value[<span class="js__num">0</span>].ResultRows)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;{0}:&nbsp;{1}&nbsp;({2})&quot;</span>,&nbsp;resultRow[<span class="js__string">&quot;Title&quot;</span>],&nbsp;resultRow[<span class="js__string">&quot;Path&quot;</span>],&nbsp;resultRow[<span class="js__string">&quot;Write&quot;</span>]);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;That's it.&nbsp; Review the code from the solution file for the complete listing.</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Main.cs - console application which queries the Search Client Object Model.</em>
</li></ul>
<h1>More Information</h1>
<div><em>For more information, see my blog entry at <a href="http://www.dotnetmafia.com/blogs/dotnettipoftheday/archive/2012/09/10/how-to-query-search-with-the-sharepoint-2013-client-object-model.aspx">
DotNetMafia.com</a>.&nbsp; Follow me on twitter: <a href="http://twitter.com/coreyroth">
@coreyroth</a>.</em></div>
