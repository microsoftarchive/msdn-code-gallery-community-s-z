# SharePoint 2013 Folder Navigation for List View WebPart
## License
- Apache License, Version 2.0
## Technologies
- Sharepoint Online
- SharePoint  2013
## Topics
- SharePoint Folder Navigation
- List View Webpart
## Updated
- 06/17/2015
## Description

<h1>Introduction</h1>
<p>Maybe we&rsquo;ve noticed the issue in SharePoint - if a list view webpart is added to page and user navigate to different folders in the list view, there&rsquo;s no way for users to know current folder hierarchy. So basically breadcrumb for the list view
 webpart missing. If there would be a way of showing users the exact location in the folder hierarchy the user is current in (as shown in the image below), wouldn&rsquo;t be that great?</p>
<p><img id="92869" src="92869-folder%20navigation.png" alt="" width="535" height="195"><br>
<strong>Image 1: Folder Navigation in action</strong></p>
<p>&nbsp;</p>
<p><strong><br>
</strong></p>
<h1><span>Deploy the FolderNavigation.js File<br>
</span></h1>
<p><br>
Download the FolderNavigation.js and then you can deploy the script either in Layouts folder (in case of full trust solutions) or in Master Page gallery (in case of SharePoint Online or full trust). I would recommend to deploy in Master Page Gallery so that
 even if you move to cloud, it works without modification. If you deploy in Master page gallery, you don&rsquo;t need to make any changes, but if you deploy in layouts folder, you need to make small changes in the script which is described in section &lsquo;Deploy
 JS Link file in Layouts folder&rsquo;.</p>
<p>&nbsp;</p>
<h3>Option 1: Deploy in Master Page Gallery (Suggested)</h3>
<p>If you are dealing with SharePoint Online, you don&rsquo;t have the option to deploy in Layouts folder. In that case you need to deploy it in Master page gallery.
<strong><span style="text-decoration:underline"><span style="color:#ff0000">Note, deploying the script in other libraries (like site assets, site library) will not work, you need to deploy in master page gallery</span></span></strong>. Otherwise you can deploy
 in Layouts folder as described in next section. To deploy in master page gallery manually, please follow the steps:</p>
<ol>
<li>Download the JavaScript file attached. </li><li>Navigate to Root web =&gt; site settings =&gt; Master Pages (under group &lsquo;Web Designer Galleries&rsquo;).
</li><li>From the &lsquo;New Document&rsquo; ribbon try adding &rsquo;JavaScript Display Template&rsquo; and then upload the FolderNavigation.js file and set properties as shown below:<br>
<img id="92872" src="92872-upload%20in%20masterpagegallery.png" alt="" width="553" height="635"><br>
<strong>Image 2: Upload the JavaScript file in master page gallery</strong><br>
<br>
In the above image, we&rsquo;ve specified the content type to &lsquo;JavaScript Display Template&rsquo;, &lsquo;target control type&rsquo; to view to use the js file in list view. Also I&rsquo;ve set target scope to &lsquo;/&rsquo; which means all sites and
 subsites will be applied. If you have a site collection &lsquo;/sites/HR&rsquo;, then you need to use &lsquo;/Sites/HR&rsquo; instead. You can also use List Template ID, if you need.
</li></ol>
<p>&nbsp;</p>
<h3>Option 2: Deploy in Layouts Folder</h3>
<p>If you are deploying the FolderNavigation.js file in Layouts folder, you need to make small changes in the downloaded script&rsquo;s RegisterModuleInti method as shown below:</p>
<p>RegisterModuleInit(<span class="str">'<span style="background-color:#ffff00">FolderNavigation.js</span>'</span>, folderNavigation);</p>
<p>&nbsp;</p>
<p>In this case the &lsquo;RegisterModuleInit&rsquo; first parameter will be the path relative to Layouts folder. If you deploy your file in path &lsquo;/_Layouts/folder1&rsquo;, the then you need to modify code as shown below:</p>
<p>RegisterModuleInit(<span class="str">'<span style="background-color:#ffff00">Folder1/FolderNavigation.js</span>'</span>, folderNavigation);</p>
<p>&nbsp;</p>
<p>If you are deploying in other subfolders in Layouts folder, you need to update the path accordingly. What I&rsquo;ve found till now, you can only deploy in Layouts and Master page gallery. But if you find deploying in other folders works, please share. Basically
 first paramter in RegisterModuleInti is the file either:</p>
<ul>
<li>Relative to '_Layouts' folder </li><li>Or Master page gallery in which case the path is started with '/_catalogs/masterpage'
</li></ul>
<p>&nbsp;</p>
<h1>Use the FolderNavigation.js in List View WebPart</h1>
<p>Once you deploy the JavaScript file in Master page gallery or Layouts folder, you need to use it in List View WebPart. Once you deploy the FolderNavigation.js file, you can start using it in list view webpart. Edit the list view web part properties and then
 under &lsquo;Miscellaneous&rsquo; section put the file url for JS Link as shown below:</p>
<p><img id="92873" src="92873-list%20view%20webpart.png" alt="" width="399" height="496"></p>
<p>Image 3: List View WebPart's JS Like Propery</p>
<p>&nbsp;</p>
<p>Few points to note for this JS Link:</p>
<ul>
<li>if you have deployed the js file in Master Page Gallery, You can use ~site or ~SiteCollection token, which means current site or current site collection respectively. The URL for JS Link then might be '~siteCollection/_catalogs/masterpage/FolderNavigation.js'
 or&nbsp; '~site/_catalogs/masterpage/FolderNavigation.js'. If you deploy the file in Site Collection Master Page gallery only, you need to use ~siteCollection token in subsites so that it uses the JavaScript file from Site Collection.
</li><li>If you have deployed in Layouts folder, you need to use corresponding path in the JS Link properties. For example if you are deploying the file in Layouts folder, then use &lsquo;/_layouts/15/FolderNavigation.js&rsquo;, if you are deploying in &lsquo;Layouts/Folder1&rsquo;
 then, use &lsquo;/_layouts/15/Folder1/FolderNavigation.js&rsquo;. Just to inform again, if you deploy in Layouts folder, you need to make small changes in the JavaScript file as described under 'Option 2: Deploy in Layouts Folder' section.
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">JavaScript file Description</span></p>
<p><em>In case you are interested to know how the code works, the code snippet is given below:</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">///Author:&nbsp;Sohel&nbsp;Rana</span>&nbsp;
<span class="js__sl_comment">//Version&nbsp;1.2</span>&nbsp;
<span class="js__sl_comment">//Last&nbsp;Modified&nbsp;on&nbsp;27-Oct-2013</span>&nbsp;
<span class="js__sl_comment">//Version&nbsp;History:</span>&nbsp;
<span class="js__sl_comment">//&nbsp;&nbsp;1.&nbsp;Added</span>&nbsp;
<span class="js__sl_comment">//&nbsp;&nbsp;2.&nbsp;Fixed&nbsp;the&nbsp;bug&nbsp;'Filtering&nbsp;by&nbsp;clicking&nbsp;on&nbsp;field&nbsp;title&nbsp;would&nbsp;result&nbsp;duplicate&nbsp;navigation&nbsp;link'</span>&nbsp;
<span class="js__sl_comment">//&nbsp;&nbsp;3.&nbsp;Fixed&nbsp;the&nbsp;bug&nbsp;'breadcrumb&nbsp;title&nbsp;always&nbsp;lowercase'.&nbsp;Now&nbsp;breadcrumb&nbsp;title&nbsp;is&nbsp;as&nbsp;like&nbsp;the&nbsp;folder&nbsp;name&nbsp;in&nbsp;the&nbsp;library&nbsp;even&nbsp;with&nbsp;case&nbsp;(lower/upper)</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//replace&nbsp;query&nbsp;string&nbsp;key&nbsp;with&nbsp;value</span>&nbsp;
<span class="js__operator">function</span>&nbsp;replaceQueryStringAndGet(url,&nbsp;key,&nbsp;value)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;re&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">RegExp</span>(<span class="js__string">&quot;([?|&amp;])&quot;</span>&nbsp;&#43;&nbsp;key&nbsp;&#43;&nbsp;<span class="js__string">&quot;=.*?(&amp;|$)&quot;</span>,&nbsp;<span class="js__string">&quot;i&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;separator&nbsp;=&nbsp;url.indexOf(<span class="js__string">'?'</span>)&nbsp;!==&nbsp;-<span class="js__num">1</span>&nbsp;?&nbsp;<span class="js__string">&quot;&amp;&quot;</span>&nbsp;:&nbsp;<span class="js__string">&quot;?&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(url.match(re))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;url.replace(re,&nbsp;<span class="js__string">'$1'</span>&nbsp;&#43;&nbsp;key&nbsp;&#43;&nbsp;<span class="js__string">&quot;=&quot;</span>&nbsp;&#43;&nbsp;value&nbsp;&#43;&nbsp;<span class="js__string">'$2'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;url&nbsp;&#43;&nbsp;separator&nbsp;&#43;&nbsp;key&nbsp;&#43;&nbsp;<span class="js__string">&quot;=&quot;</span>&nbsp;&#43;&nbsp;value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;folderNavigation()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;onPostRender(renderCtx)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(renderCtx.rootFolder)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;listUrl&nbsp;=&nbsp;<span class="js__function">decodeURIComponent</span>(renderCtx.listUrlDir);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rootFolder&nbsp;=&nbsp;<span class="js__function">decodeURIComponent</span>(renderCtx.rootFolder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(renderCtx.rootFolder&nbsp;==&nbsp;<span class="js__string">''</span>&nbsp;||&nbsp;rootFolder.toLowerCase()&nbsp;==&nbsp;listUrl.toLowerCase())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//get&nbsp;the&nbsp;folder&nbsp;path&nbsp;excluding&nbsp;list&nbsp;url.&nbsp;removing&nbsp;list&nbsp;url&nbsp;will&nbsp;give&nbsp;us&nbsp;path&nbsp;relative&nbsp;to&nbsp;current&nbsp;list&nbsp;url</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;folderPath&nbsp;=&nbsp;rootFolder.toLowerCase().indexOf(listUrl.toLowerCase())&nbsp;==&nbsp;<span class="js__num">0</span>&nbsp;?&nbsp;rootFolder.substr(listUrl.length)&nbsp;:&nbsp;rootFolder;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pathArray&nbsp;=&nbsp;folderPath.split(<span class="js__string">'/'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;navigationItems&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Array</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;currentFolderUrl&nbsp;=&nbsp;listUrl;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rootNavItem&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;<span class="js__string">'Root'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;replaceQueryStringAndGet(document.location.href,&nbsp;<span class="js__string">'RootFolder'</span>,&nbsp;listUrl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;navigationItems.push(rootNavItem);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;pathArray.length;&nbsp;index&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(pathArray[index]&nbsp;==&nbsp;<span class="js__string">''</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;lastItem&nbsp;=&nbsp;index&nbsp;==&nbsp;pathArray.length&nbsp;-&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;currentFolderUrl&nbsp;&#43;=&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;pathArray[index];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;item&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;title:&nbsp;pathArray[index],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;lastItem&nbsp;?&nbsp;<span class="js__string">''</span>&nbsp;:&nbsp;replaceQueryStringAndGet(document.location.href,&nbsp;<span class="js__string">'RootFolder'</span>,&nbsp;<span class="js__function">encodeURIComponent</span>(currentFolderUrl))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;navigationItems.push(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RenderItems(renderCtx,&nbsp;navigationItems);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Add&nbsp;a&nbsp;div&nbsp;and&nbsp;then&nbsp;render&nbsp;navigation&nbsp;items&nbsp;inside&nbsp;span</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;RenderItems(renderCtx,&nbsp;navigationItems)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(navigationItems.length&nbsp;==&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;folderNavDivId&nbsp;=&nbsp;<span class="js__string">'foldernav_'</span>&nbsp;&#43;&nbsp;renderCtx.wpq;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;webpartDivId&nbsp;=&nbsp;<span class="js__string">'WebPart'</span>&nbsp;&#43;&nbsp;renderCtx.wpq;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//a&nbsp;div&nbsp;is&nbsp;added&nbsp;beneth&nbsp;the&nbsp;header&nbsp;to&nbsp;show&nbsp;folder&nbsp;navigation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;folderNavDiv&nbsp;=&nbsp;document.getElementById(folderNavDivId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;webpartDiv&nbsp;=&nbsp;document.getElementById(webpartDivId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(folderNavDiv!=null)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv.parentNode.removeChild(folderNavDiv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv&nbsp;=null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(folderNavDiv&nbsp;==&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;folderNavDiv&nbsp;=&nbsp;document.createElement(<span class="js__string">'div'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv.setAttribute(<span class="js__string">'id'</span>,&nbsp;folderNavDivId)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;webpartDiv.parentNode.insertBefore(folderNavDiv,&nbsp;webpartDiv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv&nbsp;=&nbsp;document.getElementById(folderNavDivId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;index&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;index&nbsp;&lt;&nbsp;navigationItems.length;&nbsp;index&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(navigationItems[index].url&nbsp;==&nbsp;<span class="js__string">''</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;span&nbsp;=&nbsp;document.createElement(<span class="js__string">'span'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;span.innerHTML&nbsp;=&nbsp;navigationItems[index].title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv.appendChild(span);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;span&nbsp;=&nbsp;document.createElement(<span class="js__string">'span'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;anchor&nbsp;=&nbsp;document.createElement(<span class="js__string">'a'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;anchor.setAttribute(<span class="js__string">'href'</span>,&nbsp;navigationItems[index].url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;anchor.innerHTML&nbsp;=&nbsp;navigationItems[index].title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;span.appendChild(anchor);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv.appendChild(span);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//add&nbsp;arrow&nbsp;(&gt;)&nbsp;to&nbsp;separate&nbsp;navigation&nbsp;items,&nbsp;except&nbsp;the&nbsp;last&nbsp;one</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(index&nbsp;!=&nbsp;navigationItems.length&nbsp;-&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;span&nbsp;=&nbsp;document.createElement(<span class="js__string">'span'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;span.innerHTML&nbsp;=&nbsp;<span class="js__string">'&amp;nbsp;&gt;&amp;nbsp;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;folderNavDiv.appendChild(span);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;_registerTemplate()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;viewContext&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewContext.Templates&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;viewContext.OnPostRender&nbsp;=&nbsp;onPostRender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SPClientTemplates.TemplateManager.RegisterTemplateOverrides(viewContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//delay&nbsp;the&nbsp;execution&nbsp;of&nbsp;the&nbsp;script&nbsp;until&nbsp;clienttempltes.js&nbsp;gets&nbsp;loaded</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ExecuteOrDelayUntilScriptLoaded(_registerTemplate,&nbsp;<span class="js__string">'clienttemplates.js'</span>);&nbsp;
<span class="js__brace">}</span>;&nbsp;
&nbsp;
<span class="js__sl_comment">//RegisterModuleInit&nbsp;ensure&nbsp;folderNavigation()&nbsp;function&nbsp;get&nbsp;executed&nbsp;when&nbsp;Minimum&nbsp;Download&nbsp;Strategy&nbsp;is&nbsp;enabled.</span>&nbsp;
<span class="js__sl_comment">//if&nbsp;you&nbsp;deploy&nbsp;the&nbsp;FolderNavigation.js&nbsp;file&nbsp;in&nbsp;'_layouts'&nbsp;folder&nbsp;use&nbsp;'FolderNavigation.js'&nbsp;as&nbsp;first&nbsp;paramter.</span>&nbsp;
<span class="js__sl_comment">//if&nbsp;you&nbsp;deploy&nbsp;the&nbsp;FolderNavigation.js&nbsp;file&nbsp;in&nbsp;'_layouts/folder/subfolder'&nbsp;folder,&nbsp;use&nbsp;'folder/subfolder/FolderNavigation.js&nbsp;as&nbsp;first&nbsp;parameter'</span>&nbsp;
<span class="js__sl_comment">//if&nbsp;you&nbsp;are&nbsp;deploying&nbsp;in&nbsp;master&nbsp;page&nbsp;gallery,&nbsp;use&nbsp;'/_catalogs/masterpage/FolderNavigation.js'&nbsp;as&nbsp;first&nbsp;parameter</span>&nbsp;
RegisterModuleInit(<span class="js__string">'/_catalogs/masterpage/FolderNavigation.js'</span>,&nbsp;folderNavigation);&nbsp;
&nbsp;
<span class="js__sl_comment">//this&nbsp;function&nbsp;get&nbsp;executed&nbsp;in&nbsp;case&nbsp;when&nbsp;Minimum&nbsp;Download&nbsp;Strategy&nbsp;not&nbsp;enabled.</span>&nbsp;
folderNavigation();&nbsp;
</pre>
</div>
</div>
</div>
<p>Let me explain the code briefly:</p>
<ul>
<li>The method &lsquo;replaceQueryStringAndGet&rsquo; is used to replace query string parameter with new value. For example if you have url &lsquo;<a href="http://abc.com?key=value&name=sohel">http://abc.com?key=value&amp;name=sohel</a>&rsquo;&nbsp; and you
 would like to replace the query string &lsquo;key&rsquo; with value &lsquo;New Value&rsquo;, you can use the method like<br>
<br>
replaceQueryStringAndGet(<span class="str">&quot;http://abc.com?key=value&amp;name=sohel&quot;</span>,<span class="str">&quot;key&quot;</span>,<span class="str">&quot;New Value&quot;</span>)<br>
<br>
</li><li>The function folderNavigation has three methods. Function &lsquo;onPostRender&rsquo; is bound to rendering context&rsquo;s OnPostRender event. The method first checks if the list view&rsquo;s root folder is not null&nbsp; and root folder url is not list
 url (which means user is browsing list&rsquo;s/library&rsquo;s root). Then the method split the render context&rsquo;s folder path and creates navigation items as shown below:<br>
<br>
<span class="kwrd">var</span> item = { title: title, url: lastItem ? <span class="str">
''</span> : replaceQueryStringAndGet(document.location.href, <span class="str">
'RootFolder'</span>, encodeURIComponent(rootFolderUrl)) };<br>
<br>
As shown above, in case of last item (which means current folder user browsing), the url is empty as we&rsquo;ll show a text instead of link for current folder.<br>
<br>
</li><li>Function &lsquo;RenderItems&rsquo; renders the items in the page. I think this is the place of customisation you might be interested. Having all navigation items passed to this function, you can render your navigation items in your own way. renderContext.wpq
 is unique webpart id in the page. As shown below with the wpq value of &lsquo;<span style="text-decoration:underline"><em>WPQ2</em></span>&rsquo; the webpart is rendered in a div with id &lsquo;WebPart<span style="text-decoration:underline"><em>WPQ2</em></span>&rsquo;.
<br>
<img id="92876" src="http://i1.code.msdn.s-msft.com/sharepoint-2013-folder-661709eb/image/file/92876/1/webpart%20dissect.png" alt="" width="608" height="716"><strong><br>
<br>
Image 4: List View WebPart in Firebug</strong><br>
<br>
In &lsquo;RenderItems&rsquo; function I&rsquo;ve added a div just before the webpart div &lsquo;WebPart<span style="text-decoration:underline"><em>WPQ2</em></span>&rsquo; to put the folder navigation as shown in the image 1.
</li><li>In the method &lsquo;_registerTemplate&rsquo;, I&rsquo;ve registered the template and bound the OnPostRender event.<br>
<br>
</li><li>The final piece is RegisterModuleInit. In some example you will find the function folderNavigation is executed immediately along with the declaration. However, there&rsquo;s a problem with Client Side Rendering and Minimal Download Strategy (MDS) working
 together as <a href="http://blogs.technet.com/b/sharepointdevelopersupport/archive/2013/02/08/register-csr-override-on-mds-enabled-sharepoint-2013-site.aspx">
described in here</a>. To avoid this problem, we need to Register foldernavigation function with RegisterModuleInit to ensure the script get executed in case of MDS-enabled site. The last line &lsquo;folderNavigation()&rsquo; will execute normally in case of
 MDS-disabled site. </li></ul>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>FolderNavigation.js</em> </li></ul>
<h1>More Information</h1>
<p><em>More information available in <a href="http://ranaictiu-technicalblog.blogspot.com.au/2013/07/sharepoint-2013-folder-navigation-for.html">
my blog</a> <br>
</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:3990px; width:1px; height:1px; overflow:hidden">
</div>
