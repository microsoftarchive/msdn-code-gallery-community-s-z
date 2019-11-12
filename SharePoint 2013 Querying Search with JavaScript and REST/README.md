# SharePoint 2013: Querying Search with JavaScript and REST
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
- apps for SharePoint
## Topics
- REST
- SharePoint
- Javascript
- Search
## Updated
- 05/21/2014
## Description

<p><strong>Provided by:</strong><span>&nbsp;</span><a href="http://www.dotnetmafia.com/">Corey Roth</a><span>,&nbsp;</span><a href="http://www.sp2apps.com/">SP2 Apps</a></p>
<h1>Introduction</h1>
<p>This sample shows you how to query SharePoint 2013 Search using REST and JavaScript.&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><span>The sample provided is a SharePoint-hosted App. &nbsp;Apps must be configured on your SharePoint environment in order to run the sample. &nbsp;This sample is build with the RTM version of the Office Developer Tools which need to be installed prior
 to running.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>This example demonstrates how to query search using the SharePoint 2013 REST API. &nbsp;In this sample we are going to create a page with a search box that displays results in a grid. &nbsp;To get started, create a new SharePoint-hosted app. &nbsp;Then,
 you must grant permissions to the App to use search. &nbsp;To do this, open&nbsp;</span><strong>AppManifest.xml</strong><span>&nbsp;and click on the&nbsp;</span><em>Permissions</em><span>&nbsp;tab. &nbsp;Under&nbsp;</span><em>Scope</em><span>, choose a value
 of&nbsp;</span><em>Search</em><span>&nbsp;and then select&nbsp;</span><em>QueryAsUserIgnoreAppPrincipal</em><span>. &nbsp;If you forget this step, you will be unable to retieve any search results from SharePoint.</span></p>
<p><img id="80208" src="80208-searchapprestpermission.png" alt="" width="719" height="241"></p>
<p>Now, edit&nbsp;<strong>Default.aspx</strong>&nbsp;to add the HTML for our search box and button as well as a div tag to hold the results.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;div</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;label</span>&nbsp;<span class="html__attr_name">for</span>=<span class="html__attr_value">&quot;searchTextBox&quot;</span><span class="html__tag_start">&gt;</span>Search:&nbsp;<span class="html__tag_end">&lt;/label&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;searchTextBox&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;input</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;searchButton&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;button&quot;</span>&nbsp;<span class="html__attr_name">value</span>=<span class="html__attr_value">&quot;Search&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;
<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;resultsDiv&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;
<span class="html__tag_end">&lt;/div&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>Next, edit&nbsp;</span><strong>App.js</strong><span>&nbsp;to include your script to query search and display the results. &nbsp;Add a click event handle to your document ready function. &nbsp;We'll put our code to query search
 here.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">&quot;#searchButton&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">To query with REST, you must assemble a URL by appending
<em>/api/search/query</em>&nbsp;to your SharePoint host URL. &nbsp;This <a href="http://blogs.msdn.com/b/nadeemis/archive/2012/08/24/sharepoint-2013-search-rest-api.aspx">
post</a> has detailed information on the REST API parameters. &nbsp;To get the host URL, use the following line of code in your event handler.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;spAppWebUrl&nbsp;=&nbsp;<span class="js__function">decodeURIComponent</span>(getQueryStringParameter(<span class="js__string">'SPAppWebUrl'</span>));</pre>
</div>
</div>
</div>
<div class="endscriptcode">The implementation of <strong>getQueryStringParameter()&nbsp;</strong>is included in the full code snippet. &nbsp;To assemble the full URL, add the
<em>querytext </em>paramater to your URL. &nbsp;Be sure to enclose the value of your query in single quotes. &nbsp;Here is what an example URL might look like.&nbsp;</div>
<div class="endscriptcode"><strong>http://server/_api/search/query?querytext='myquery'</strong></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The entire URL can be concatenated with the following line of code. &nbsp;It takes the value of the search box and appends it to the string.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;queryUrl&nbsp;=&nbsp;spAppWebUrl&nbsp;&#43;&nbsp;<span class="js__string">&quot;/_api/search/query?querytext='&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#searchTextBox&quot;</span>).val()&nbsp;&#43;&nbsp;<span class="js__string">&quot;'&quot;</span>;</pre>
</div>
</div>
</div>
</span>
<div class="endscriptcode">Now, execute the query with&nbsp;</div>
<div class="endscriptcode"><strong>$.ajax()</strong>.&nbsp; Pass the&nbsp;<em>queryUrl&nbsp;</em>in the&nbsp;<em>url</em>&nbsp;parameter.&nbsp;&nbsp; This example uses the&nbsp;<em>GET</em>&nbsp;method but if you have a lot of parameters, you may consider
 using&nbsp;<em>POST</em>&nbsp;instead (note postquery requires a <a href="http://blogs.msdn.com/b/nadeemis/archive/2012/08/24/sharepoint-2013-search-rest-api.aspx">
different URL</a>).&nbsp; Lastly, this part is key to get this example to work.&nbsp; The accept header must have value of&nbsp;<em>&quot;application/json; odata=verbose&quot;</em>.&nbsp; The&nbsp;<em>odata=verbose&nbsp;</em></div>
<div class="endscriptcode">part is not present in previous MSDN examples.&nbsp; If you leave it out, you will receive an error.&nbsp; The last parameters are the methods that will handle the success and failure of the AJAX call.&nbsp; Here&rsquo;s what the
 whole method looks like.&nbsp;</div>
<span style="font-size:x-small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(<span class="js__string">&quot;#searchButton&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;queryUrl&nbsp;=&nbsp;spAppWebUrl&nbsp;&#43;&nbsp;<span class="js__string">&quot;/_api/search/query?querytext='&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#searchTextBox&quot;</span>).val()&nbsp;&#43;&nbsp;<span class="js__string">&quot;'&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;url:&nbsp;queryUrl,&nbsp;method:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;headers:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;Accept&quot;</span>:&nbsp;<span class="js__string">&quot;application/json;&nbsp;odata=verbose&quot;</span><span class="js__brace">}</span>,&nbsp;success:&nbsp;onQuerySuccess,&nbsp;error:&nbsp;onQueryError&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
</span>
<div class="endscriptcode">The results come back in JSON format. &nbsp;Each individual result can be found in&nbsp;<strong>data.d.query.PrimaryQueryResult.RelevantResults.Table.Rows.results</strong>. &nbsp;In this example, use $.each to iterate through the
 result rows and columns.</div>
<span style="font-size:x-small"></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:x-small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;onQuerySuccess(data)&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;results&nbsp;=&nbsp;data.d.query.PrimaryQueryResult.RelevantResults.Table.Rows.results;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;table&gt;'</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.each(results,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;tr&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(<span class="js__operator">this</span>.Cells.results,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;td&gt;'</span>&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.Value&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;/tr&gt;'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#resultsDiv&quot;</span>).append(<span class="js__string">'&lt;/table&gt;'</span>);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</span>
<div class="endscriptcode">This is all you need to build a grid with the search results. &nbsp;The error handling can be seen in the attached source code.</div>
<span style="font-size:x-small"></span></div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Default.aspx - HTML for the solution </li><li>App.js - JavaScript to query search </li></ul>
<h1>More Information</h1>
<p><em>For more infromation, see the related blog entry at <a href="http://www.dotnetmafia.com/blogs/dotnettipoftheday/archive/2013/04/09/how-to-query-sharepoint-2013-using-rest-and-javascript.aspx">
DotNetMafia.com</a>. &nbsp;Follow me on twitter:&nbsp;<a href="http://twitter.com/coreyroth">@coreyroth</a>.</em></p>
