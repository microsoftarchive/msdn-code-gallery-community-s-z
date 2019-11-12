# SharePoint Responsive Master Page
## License
- MIT
## Technologies
- SharePoint Server 2010
- Bootstrap
- CSS3
- SharePoint Server 2013
- Responsive web Design
- HTML5/JavaScript
## Topics
- customization
- Bootstrap
- site definitions
- site collection
- SharePoint Branding
- SharePoint master pages
- Responsive web Design
## Updated
- 01/22/2016
## Description

<h1><strong>Introduction</strong></h1>
<p><span style="font-size:medium"><em>In My last article, I've given a responsive master page which can be used for all SharePoint application with some basic bootstrap designs.</em></span></p>
<p><span style="font-size:medium"><em><a class="preview" title="Responsive Master Page" href="https://code.msdn.microsoft.com/office/Sharepoint-Responsive-Page-08fe5c2f" target="_blank">https://code.msdn.microsoft.com/office/Sharepoint-Responsive-Page-08fe5c2f</a></em></span></p>
<p><span style="font-size:medium"><em><br>
</em></span></p>
<p><span style="font-size:medium"><em>In this article, you will find a master page with better design. By using this master page you can change the appearance of your SharePoint site to HTML5 website.
</em></span></p>
<p><span style="font-size:medium"><em>Lets try this!! &nbsp;</em></span></p>
<h1><strong>Description</strong></h1>
<p><span style="font-size:medium"><em>You can now disable all the unwanted content place holder from the user and make your application as a responsive with bootstrap.
</em></span></p>
<p>&nbsp;</p>
<h1><strong><em><span style="text-decoration:underline">Creating Master Page</span></em></strong></h1>
<h2><strong>Step:1</strong></h2>
<p><span style="font-size:medium">Download the&nbsp;<strong><em>Responsive Master Page Template.zip</em></strong>&nbsp;here.</span></p>
<h2><strong>Step:2</strong></h2>
<p><span style="font-size:medium">Go to your&nbsp;<strong><em>site collection</em></strong>&nbsp;and navigate to&nbsp;<strong><em>Site Settings</em></strong></span></p>
<h2><strong>Step: 3</strong></h2>
<p><span style="font-size:medium">(Make sure you have enabled the&nbsp;<strong><em>publishing future</em></strong>&nbsp;in site collection level)</span></p>
<p><span style="font-size:medium">Select the&nbsp;<strong><em>Master pages and page layouts</em></strong>&nbsp;option under Galleries&nbsp;</span></p>
<h2><strong>Step: 4</strong></h2>
<p><span style="font-size:medium">Extract the downloaded zip file and copy</span></p>
<p><span style="font-size:medium"><strong><em>Responsive Master Page Template-&gt;MasterPage-&gt;ResponsiveMaster</em></strong>&nbsp;and upload the folder under the master page list</span></p>
<p><span style="font-size:medium">(Make sure you have uploaded the &ldquo;ResponsiveMaster&rdquo; folder. Inside the masterpage folder, one master file will be there)</span></p>
<h2><strong>Step: 5</strong></h2>
<p><span style="font-size:medium">Click<strong>&nbsp;<em>All Site Content</em></strong>&nbsp;link from Quick Launch pane.&nbsp; (Site Collection Level)</span></p>
<h2><strong>Step: 6</strong></h2>
<p><span style="font-size:medium">Select&nbsp;<strong><em>Style Library</em></strong>&nbsp;list to upload the &nbsp;css and js styles</span></p>
<h2><strong>Step: 7</strong></h2>
<p><span style="font-size:medium">Extract the downloaded zip file and copy</span></p>
<p><span style="font-size:medium"><strong><em>Responsive Master Page Template-&gt;StyleLibrary-&gt;ResponsiveMaster</em></strong>&nbsp;and upload it under the Style Library list</span></p>
<p><span style="font-size:medium">(Make sure you have uploaded the &ldquo;ResponsiveMaster&rdquo; folder. Inside the &quot;StyleLibrary&quot; folder- CSS fonts, images, js sub folders will be there.)</span></p>
<h2><strong>Step: 8</strong></h2>
<p><span style="font-size:medium"><strong><em>Check In</em></strong>&nbsp;all the uploaded files and folders and&nbsp;<strong><em>approve</em></strong>&nbsp;it.</span></p>
<p><span style="font-size:medium">Now your responsive Master page is ready.</span></p>
<p><span style="font-size:medium">Note: Don&rsquo;t set this master page as your default master. It will replace your V4.master as in your sub site level.</span></p>
<p><span style="font-size:medium">You can make it as a custom master page from the designer and change the master page url in the aspx page from ~masterurl/default.master to ~masterurl/custom.master</span></p>
<p><span style="font-size:medium">Please follow the&nbsp;<strong><em>below steps</em></strong>&nbsp;to apply this master page for&nbsp;<strong><em>individual site pages</em></strong>. (Better apply this master page for user level pages)</span></p>
<h1><strong><em><span style="text-decoration:underline">--Creating Site Page with Responsive Master Page</span></em></strong><strong>&nbsp;</strong></h1>
<h2><strong>Step: 1</strong></h2>
<p><span style="font-size:medium"><strong><em>Create a site</em></strong>&nbsp;under the above site collection.</span></p>
<h2><strong>Step: 2</strong></h2>
<p><span style="font-size:medium">Extract the downloaded zip file and copy</span></p>
<p><span style="font-size:medium"><strong><em>Responsive Master Page Template-&gt;SitePage -&gt; ResponsivePageTemplate.aspx</em></strong>&nbsp;and use this template for your site pages.</span></p>
<h2><strong>Step: 3</strong></h2>
<p><span style="font-size:medium">Create your own&nbsp;<strong><em>responsive content under &ldquo;contentplaceholdermain&rdquo;</em></strong>&nbsp;and publish it.&nbsp;</span><strong><em>
</em></strong></p>
<h2>Step: 4</h2>
<p><span style="font-size:medium">The center banner is placed in master page and We have a content place holder to update the text inside the banner. You can change it in your all the aspx pages.&nbsp;</span></p>
<h2><strong><em>Desktop View:&nbsp;</em></strong></h2>
<p><span style="font-size:small"><em>In desktop view you will get &quot;logo.png&quot; as a lengthy size logo (Change the logo file in images folder)</em></span></p>
<p><strong><em><img id="147691" src="147691-sample1.png" alt="" width="700" height="323"><br>
</em></strong></p>
<h3><strong><em>Mobile/Tablet View:</em></strong></h3>
<p><span style="font-size:small"><em><em>In Mobile/Tablet view you will get &quot;logo-small.png&quot; as a small size logo/ icon (Change the logo-small file in images folder)</em></em></span><strong><em><br>
</em></strong></p>
<p><strong><em><img id="147689" src="147689-sample2.png" alt=""><br>
</em></strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h3><strong><em>Mobile/Tablet View: Menu</em></strong></h3>
<p>&nbsp;</p>
<p><img id="147690" src="147690-sample3.png" alt="" width="702" height="532"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:medium">Set&nbsp;<strong><em>Master page file Url</em></strong>&nbsp;like below to inherit the above responsive master page</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="vb"><span style="font-size:medium">&lt;%@&nbsp;Page&nbsp;language=<span class="visualBasic__string">&quot;C#&quot;</span>&nbsp;MasterPageFile=../../_catalogs/masterpage/ResponsiveMaster/&nbsp;ResponsiveMaster.master&nbsp;meta:progid=<span class="visualBasic__string">&quot;SharePoint.WebPartPage.Document&quot;</span>&nbsp;&nbsp;inherits=<span class="visualBasic__string">&quot;&quot;</span>&nbsp;%&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:medium">Or you can set the masterpage as your custom master page and change the master URL like the below</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span style="font-size:medium"><span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;MasterPageFile=~masterurl/custom.master&nbsp;meta:<span class="html__attr_name">progid</span>=<span class="html__attr_value">&quot;SharePoint.WebPartPage.Document&quot;</span>&nbsp;&nbsp;<span class="html__attr_name">inherits</span>=<span class="html__attr_value">&quot;&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span></span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:medium">Use the below content place holder to change the banner text in your aspx pages.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;Content5&quot;</span>&nbsp;<span class="html__attr_name">ContentPlaceHolderId</span>=<span class="html__attr_value">&quot;bannerText&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span><span class="html__tag_start">&lt;h1</span><span class="html__tag_start">&gt;</span>Title&nbsp;<span class="html__tag_end">&lt;/h1&gt;</span>&nbsp;
<span class="html__tag_start">&lt;p</span>&nbsp;<span class="html__attr_name">class</span>=<span class="html__attr_value">&quot;lead&quot;</span><span class="html__tag_start">&gt;</span>Pellentesque&nbsp;habitant&nbsp;morbi&nbsp;tristique&nbsp;senectus&nbsp;et&nbsp;netus&nbsp;et&nbsp;malesuada&nbsp;fames&nbsp;ac&nbsp;turpis&nbsp;egestas.&nbsp;Vestibulum&nbsp;tortor&nbsp;quam,&nbsp;feugiat&nbsp;vitae.<span class="html__tag_end">&lt;/p&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Use the below content place holder to change the page title in your aspx pages.</span></div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;Content6&quot;</span>&nbsp;<span class="html__attr_name">ContentPlaceHolderId</span>=<span class="html__attr_value">&quot;PlaceHolderPageTitle&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>Responsive&nbsp;Page&nbsp;-&nbsp;Custom&nbsp;Title&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:medium; background-color:#00ffff"><em>Thats It!!</em></span></p>
<p><span style="font-size:medium; background-color:#00ffff"><em>No need to code anything. Just follow above procedure and your responsive sharepoint master page will be ready in 5 mins.&nbsp;</em></span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium; background-color:#00ffff"><em>Please let me know, if you guys have any queries.&nbsp;</em></span></p>
<p><span style="font-size:medium; background-color:#ffcc00"><em>Reach me out through&nbsp;<span style="font-size:large"><a title="Sasisprite" href="https://www.linkedin.com/in/sasisprite">https://www.linkedin.com/in/sasisprite</a></span></em></span></p>
