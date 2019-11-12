# SharePoint 2013: Querying Search with the JavaScript Client Object Model
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
- apps for SharePoint
## Topics
- Search
- apps for SharePoint
## Updated
- 04/19/2013
## Description

<p><strong>Provided by:</strong> <a href="http://www.dotnetmafia.com">Corey Roth</a>,
<a href="http://www.sp2apps.com">SP2 Apps</a></p>
<h1>Introduction</h1>
<p>This code&nbsp;sample shows you how to query search in SharePoint 2013 using the JavaScript Client Object Model (CSOM).</p>
<h1><span>Building the Sample</span></h1>
<p>The sample provided is a SharePoint-hosted App. &nbsp;Apps must be configured on your SharePoint environment in order to run the sample. &nbsp;This sample is build with the RTM version of the Office Developer Tools which need to be installed prior to running.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This example demonstrates how to use the SharePoint 2013 JavaScript Client Object Model. &nbsp;In this sample we are going to create a page with a search box that displays results in a grid. &nbsp;To get started, create a new SharePoint-hosted app. &nbsp;Then,
 you must grant permissions to the App to use search. &nbsp;To do this, open <strong>
AppManifest.xml</strong>&nbsp;and click on the <em>Permissions</em>&nbsp;tab. &nbsp;Under
<em>Scope</em>, choose a value of <em>Search</em>&nbsp;and then select <em>QueryAsUserIgnoreAppPrincipal</em>. &nbsp;If you forget this step, you will be unable to retieve any search results from SharePoint.</p>
<p><img id="80205" src="80205-searchapprestpermission.png" alt="" width="719" height="241"></p>
<p>Now, edit <strong>Default.aspx</strong>&nbsp;to add the HTML for our search box and button as well as a div tag to hold the results.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;searchTextBox&quot;</span><span class="html__tag_start">&gt;</span>Search:&nbsp;<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;searchTextBox&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;searchButton&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Search&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;resultsDiv&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Next, edit <strong>App.js</strong>&nbsp;to include your script to query search and display the results. &nbsp;Add a click event handle to your document ready function. &nbsp;We'll put our code to query search here.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">&quot;#searchButton&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">The following code is similar to the technique used for
<a href="http://code.msdn.microsoft.com/Query-Search-with-the-649f1bc1">querying using Managed CSOM</a>. &nbsp;Next, you need to create a
<strong>KeywordQuery</strong> class.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;keywordQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.Client.Search.Query.KeywordQuery.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.Client.Search.Query.KeywordQuery">Microsoft.SharePoint.Client.Search.Query.KeywordQuery</a>(context);</pre>
</div>
</div>
</div>
<div class="endscriptcode">Then we will use the value of our textbox with the <strong>
set_queryText() </strong>method.</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">keywordQuery.set_queryText($(<span class="js__string">&quot;#searchTextBox&quot;</span>).val());</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Now, create a SearchExecutor object and execute the query.&nbsp; I am assigning the results of the query back to a global variable called
<em>results</em>.&nbsp; Since apps by default have &lsquo;use strict&rsquo; enabled, be sure and declare this first.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;searchExecutor&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.Client.Search.Query.SearchExecutor.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.Client.Search.Query.SearchExecutor">Microsoft.SharePoint.Client.Search.Query.SearchExecutor</a>(context);&nbsp;
&nbsp;
results&nbsp;=&nbsp;searchExecutor.executeQuery(keywordQuery);&nbsp;</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">To execute the query, use <strong>executeQyeryAsync</strong>&nbsp;and pass it methods for both success and failure.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">context.executeQueryAsync(onQuerySuccess,&nbsp;onQueryError);</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode">Each individual result can be found in <strong>results.m_value.ResultTables[0].ResultRows</strong>.&nbsp; The managed properties of each row are typed directly on the object so that it means you can access them directly if you know
 the name (i.e.: Author, Write, etc). Iterating the values is simple using $.each. &nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;onQuerySuccess()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;table&gt;'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.each(results.m_value.ResultTables[<span class="js__num">0</span>].ResultRows,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;tr&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.Title&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.Author&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.Write&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.Path&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;/tr&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;/table&gt;'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Review the attached code for complete details.</div>
</div>
<div class="endscriptcode"></div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Default.aspx - HTML for the solution </li><li>App.js - JavaScript to query search </li></ul>
<h1>More Information</h1>
<p>For more infromation, see the related blog entry at <a href="http://www.dotnetmafia.com/blogs/dotnettipoftheday/archive/2013/04/18/how-to-query-search-with-the-sharepoint-2013-javascript-client-object-model.aspx">
DotNetMafia.com</a>. &nbsp;Follow me on twitter: <a href="http://twitter.com/coreyroth">
@coreyroth</a>.</p>
