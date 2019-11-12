# SharePoint List to JQuery Chart SharePoint Add In
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- Javascript
- Chart
- Sharepoint Online
- jQuery UI
- SharePoint Server 2013
- SharePoint 2016
- SharePoint Add-ins
## Topics
- jQuery
- Chart
- Sharepoint Online
- SharePoint 2013
- SharePoint 2016
## Updated
- 02/28/2016
## Description

<h1>Introduction</h1>
<p><em><span>JQuery Chart is easy to implement&nbsp;</span><span>as a</span><span>&nbsp;SharePoint Add In, in this sample I have retrieved SharePoint list data and formed it as&nbsp;</span><span>JSON</span><span>&nbsp;data and then JSON data object is passed
 into JQuey chart as input parameter. we can implement various type of chart using JQuery chart for as example bar, circle, line,&nbsp;doughnut, etc,... Here I'm going to explain detail about this SharePoint Add-In implementation.</span></em></p>
<h1><img id="149053" src="149053-jquery%20chart%20sharepoint%20list.jpg" alt="" width="600" height="400"></h1>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>To Modify and deploy this solution</strong></p>
<p>Open visual studio 2015</p>
<p>On the file menu select Open -&gt; Project (Ctrl &#43; Shift &#43; o)</p>
<p>In the Open Project window navigate the directory and select solution file (.sln)</p>
<p>Open solution explorer windows and select project solution and click (F4) to open project properties</p>
<p>Change the site URL property on the property window</p>
<div>
<p>Edit the code if required and click play button or (F5) in visual studio&nbsp;</p>
</div>
<p><strong>To add new resource file (.js or .css or Images) into project</strong></p>
<p>Select a folder from solution explorer based on your file type (Images or Scripts or Content for CSS)</p>
<p>Right click and select &ldquo;Open Folder in File Explorer&rdquo; option</p>
<p>Now paste your files into the folder</p>
<p>Again in the solution explorer window at the top, click &ldquo;Show All Files&rdquo; icon</p>
<p>Now you can find the file without active icon, right click and select &ldquo;Include in Project&rdquo; Option</p>
<p><strong>Solution compatibility</strong></p>
<p>This sample is tested with SharePoint Online</p>
<p>This sample also compatible with SharePoint 2013 and SharePoint 2016</p>
<p><strong>Code&nbsp;Flow</strong></p>
<p>Fetching Host web URL and App web URL from query string</p>
<p>Host web content created using app web proxy</p>
<p>Retrieved list data from the host web</p>
<p>on the success event, list item collection converted as JSON data using JSON.parse</p>
<p>then the JSON data sent to <a title="chart js" href="http://www.chartjs.org/" target="_blank">
chart js</a> as parameter</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">html</span>


<div class="preview">
<pre class="js"><span class="js__sl_comment">//'use&nbsp;strict';</span>&nbsp;
&nbsp;
ExecuteOrDelayUntilScriptLoaded(initializePage,&nbsp;<span class="js__string">&quot;sp.js&quot;</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;initializePage()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;context&nbsp;=&nbsp;SP.ClientContext.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;user&nbsp;=&nbsp;context.get_web().get_currentUser();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;hostweburl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;appweburl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;appContextSite;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;list;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listItems;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;web;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;code&nbsp;runs&nbsp;when&nbsp;the&nbsp;DOM&nbsp;is&nbsp;ready&nbsp;and&nbsp;creates&nbsp;a&nbsp;context&nbsp;object&nbsp;which&nbsp;is&nbsp;needed&nbsp;to&nbsp;use&nbsp;the&nbsp;SharePoint&nbsp;object&nbsp;model</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getUrl();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;get&nbsp;the&nbsp;URL&nbsp;informations</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getUrl()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hostweburl&nbsp;=&nbsp;getQueryStringParameter(<span class="js__string">&quot;SPHostUrl&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appweburl&nbsp;=&nbsp;getQueryStringParameter(<span class="js__string">&quot;SPAppWebUrl&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hostweburl&nbsp;=&nbsp;<span class="js__function">decodeURIComponent</span>(hostweburl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appweburl&nbsp;=&nbsp;<span class="js__function">decodeURIComponent</span>(appweburl).toString().replace(<span class="js__string">&quot;#&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;scriptbase&nbsp;=&nbsp;hostweburl&nbsp;&#43;&nbsp;<span class="js__string">&quot;/_layouts/15/&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.getScript(scriptbase&nbsp;&#43;&nbsp;<span class="js__string">&quot;SP.RequestExecutor.js&quot;</span>,&nbsp;execOperation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;get&nbsp;list&nbsp;data&nbsp;from&nbsp;SharePoint</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;execOperation()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;factory&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ProxyWebRequestExecutorFactory(appweburl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.set_webRequestExecutorFactory(factory);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;appContextSite&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.AppContextSite(context,&nbsp;hostweburl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;web&nbsp;=&nbsp;appContextSite.get_web();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.load(web);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;camlQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.CamlQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list&nbsp;=&nbsp;web.get_lists().getByTitle(<span class="js__string">&quot;Post&nbsp;Reach&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listItems&nbsp;=&nbsp;list.getItems(camlQuery);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.load(list);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.load(listItems);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.executeQueryAsync(onGetSPListSuccess,&nbsp;onGetSPListFail);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;is&nbsp;executed&nbsp;if&nbsp;the&nbsp;above&nbsp;call&nbsp;is&nbsp;successful</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;onGetSPListSuccess()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#DivSPGrid&quot;</span>).empty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chartlabel&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chartdata1&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;chartdata2&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;barChartData&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listEnumerator&nbsp;=&nbsp;listItems.getEnumerator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartlabel&nbsp;=&nbsp;<span class="js__string">&quot;{\&quot;labels\&quot;:[&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata1&nbsp;=&nbsp;<span class="js__string">&quot;],\&quot;datasets\&quot;:[{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;fillColor\&quot;:\&quot;rgba(220,220,220,0.5)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;strokeColor\&quot;:\&quot;rgba(220,220,220,0.8)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;highlightFill\&quot;:\&quot;rgba(220,220,220,0.75)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;highlightStroke\&quot;:\&quot;rgba(220,220,220,1)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;data\&quot;:[&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata2&nbsp;=&nbsp;<span class="js__string">&quot;]},{&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;fillColor\&quot;:\&quot;rgba(151,187,205,0.5)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;strokeColor\&quot;:\&quot;rgba(151,187,205,0.8)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;highlightFill\&quot;:\&quot;rgba(151,187,205,0.75)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;highlightStroke\&quot;:\&quot;rgba(151,187,205,1)\&quot;,&quot;</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\&quot;data\&quot;:[&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(listEnumerator.moveNext())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listItem&nbsp;=&nbsp;listEnumerator.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartlabel&nbsp;&#43;=&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>&nbsp;&#43;&nbsp;listItem.get_item(<span class="js__string">&quot;Title&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;\&quot;,&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata1&nbsp;&#43;=&nbsp;listItem.get_item(<span class="js__string">&quot;Facebook&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata2&nbsp;&#43;=&nbsp;listItem.get_item(<span class="js__string">&quot;Twitter&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartlabel&nbsp;=&nbsp;chartlabel.replace(<span class="js__reg_exp">/,\s*$/</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata1&nbsp;=&nbsp;chartdata1.replace(<span class="js__reg_exp">/,\s*$/</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;chartdata2&nbsp;=&nbsp;chartdata2.replace(<span class="js__reg_exp">/,\s*$/</span>,&nbsp;<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;str&nbsp;=&nbsp;chartlabel&nbsp;&#43;&nbsp;chartdata1&nbsp;&#43;&nbsp;chartdata2&nbsp;&#43;&nbsp;<span class="js__string">']}]}'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;barChartData&nbsp;=&nbsp;JSON.parse(str);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ctx&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;chartCanvas&quot;</span>).getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.myBar&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Chart(ctx).Bar(barChartData,&nbsp;<span class="js__brace">{</span>&nbsp;responsive:&nbsp;true&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;function&nbsp;is&nbsp;executed&nbsp;if&nbsp;the&nbsp;above&nbsp;call&nbsp;fails</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;onGetSPListFail(sender,&nbsp;args)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">'Failed&nbsp;to&nbsp;get&nbsp;list&nbsp;data.&nbsp;Error:'</span>&nbsp;&#43;&nbsp;args.get_message());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;function&nbsp;split&nbsp;the&nbsp;url&nbsp;and&nbsp;trim&nbsp;the&nbsp;App&nbsp;and&nbsp;Host&nbsp;web&nbsp;URLs</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getQueryStringParameter(paramToRetrieve)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;params&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.URL.split(<span class="js__string">&quot;?&quot;</span>)[<span class="js__num">1</span>].split(<span class="js__string">&quot;&amp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;params.length;&nbsp;i&nbsp;=&nbsp;i&nbsp;&#43;&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;singleParam&nbsp;=&nbsp;params[i].split(<span class="js__string">&quot;=&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(singleParam[<span class="js__num">0</span>]&nbsp;==&nbsp;paramToRetrieve)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;singleParam[<span class="js__num">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>More Information</h1>
<p>*****************************************************************************************************</p>
<p>Hope you find this sample helpful, check out my other samples too.</p>
<p>Give five stars if you wish to appreciate my work.</p>
<p>Facebook page URL:&nbsp;<a title="https://www.facebook.com/sptechnet2016/" href="https://www.facebook.com/sptechnet2016/" target="_blank">https://www.facebook.com/sptechnet2016/</a></p>
<p>Blog URL:&nbsp;<a title="https://sptechnet.wordpress.com/" href="https://sptechnet.wordpress.com/" target="_blank">https://sptechnet.wordpress.com/</a></p>
<p>*****************************************************************************************************</p>
