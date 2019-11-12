# Using Promises with the JavaScript Object Model in SharePoint 2013
## License
- MIT
## Technologies
- SharePoint Server 2013
## Topics
- SharePoint 2013
## Updated
- 02/09/2015
## Description

<h1>Introduction</h1>
<p><em>The front-end development provides support to have a responsive UI, now exist very third-party libraries that help the developers.In this article I want to explain how is possible to use the javascript promises applied to JSOM (javascript object model)
 in SharePoint 2013, I used this particular topic in a project for a customer.<br>
JSOM provides the possibility to retrieve information, for example from a SharePoint list and to conduct the CRUD operations on it in asynchronous mode at all advantage of the UI.<br>
However, in some cases is useful to wait the response of the call, for this support us the Deferred object of jQuery, in fact this object can storing a queue of callbacks and observe the success or failure state of any synchronous or asynchronous function.<br>
Check this example present on the MSDN portal, obviously is necessary to do referencing at jQuery in the web page.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>Is necessary to do referencing at jQuery in the web page and to have a sharepoint farm.</em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>For the responsive web UI is useful to wait the response of the call, for this support us the Deferred object of jQuery, in fact this object can storing a queue of callbacks and observe the success or failure state of any synchronous or asynchronous
 function.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;siteUrl&nbsp;=&nbsp;<span class="js__string">'/sites/MySiteCollection'</span>;&nbsp;
<span class="js__statement">var</span>&nbsp;dfd&nbsp;=&nbsp;$.Deferred();&nbsp;
&nbsp;&nbsp;
$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;When&nbsp;the&nbsp;function&nbsp;has&nbsp;finished...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.when(retrieveListItemsInclude())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.done(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;do&nbsp;something</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.fail(<span class="js__operator">function</span>&nbsp;(sender,&nbsp;args)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;do&nbsp;something</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;retrieveListItemsInclude()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;clientContext&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.ClientContext(siteUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;oList&nbsp;=&nbsp;clientContext.get_web().get_lists().getByTitle(<span class="js__string">'Announcements'</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;camlQuery&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SP.CamlQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;camlQuery.set_viewXml(<span class="js__string">'100'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.collListItem&nbsp;=&nbsp;oList.getItems(camlQuery);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;clientContext.load(collListItem,&nbsp;<span class="js__string">'Include(Id,&nbsp;DisplayName,&nbsp;HasUniqueRoleAssignments)'</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;clientContext.executeQueryAsync(<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;<span class="js__operator">this</span>.onQuerySucceeded),&nbsp;<span class="js__object">Function</span>.createDelegate(<span class="js__operator">this</span>,&nbsp;<span class="js__operator">this</span>.onQueryFailed));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;dfd;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;onQuerySucceeded(sender,&nbsp;args)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listItemInfo&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listItemEnumerator&nbsp;=&nbsp;collListItem.getEnumerator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(listItemEnumerator.moveNext())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;oListItem&nbsp;=&nbsp;listItemEnumerator.get_current();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listItemInfo&nbsp;&#43;=&nbsp;<span class="js__string">'\nID:&nbsp;'</span>&nbsp;&#43;&nbsp;oListItem.get_id()&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'\nDisplay&nbsp;name:&nbsp;'</span>&nbsp;&#43;&nbsp;oListItem.get_displayName()&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'\nUnique&nbsp;role&nbsp;assignments:&nbsp;'</span>&nbsp;&#43;&nbsp;oListItem.get_hasUniqueRoleAssignments();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dfd.resolve(listItemInfo.toString());&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
<span class="js__operator">function</span>&nbsp;onQueryFailed(sender,&nbsp;args)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dfd.reject(sender,&nbsp;args);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>JSOMwithPromises.js</em> </li></ul>
<h1>More Information</h1>
<p><em>Follow me in my website <a class="title" title="De Luca Giuliano website" href="http://www.delucagiuliano.com" target="_blank">
http://www.delucagiuliano.com</a></em></p>
