# SharePoint List to JQuery Table
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- jQuery
- Javascript
- HTML
- Sharepoint Online
- jQuery UI
- SharePoint Server 2013
- apps for SharePoint
- SharePoint Add-ins
## Topics
- jQuery
- Javascript
- Sharepoint Online
- SharePoint 2013
- SharePoint Apps
- Jquery Table
## Updated
- 02/25/2016
## Description

<h1>Introduction</h1>
<p>We have lot of benefits using JQuery Table in SharePoint such as quick&nbsp;search, selecting of number of items in view, shorting and footer navigation. In this SharePoint Add-in, I&rsquo;m retrieving SharePoint list data and building HTML table, then the
 HTML table mapped with JQuery Table script. Read further for detailed step by step instruction to develop this SharePoint Add-In.</p>
<h1><em style="font-size:10px"><img id="148299" src="148299-2016-02-08_22-11-19.png" alt="" width="858" height="400">&nbsp;&nbsp;</em></h1>
<p><strong>Solution compatibility</strong></p>
<p>This sample is tested with SharePoint Online</p>
<p>This sample also compatible with SharePoint 2013 and SharePoint 2016</p>
<p><br>
<strong>To Modify and deploy this solution</strong></p>
<p>Open visual studio 2015</p>
<p>On the file menu select Open -&gt; Project (Ctrl &#43; Shift &#43; o)</p>
<p>In the Open Project window navigate the directory and select solution file (.sln)</p>
<p>Open solution explorer windows and select project solution and click (F4) to open project propertiesChange the site URL property on the property window&nbsp;</p>
<p>Edit the code if required and click play button or (F5) in visual studio&nbsp;</p>
<p>&nbsp;</p>
<p><strong>To add new resource file (.js or .css or Images) into project</strong></p>
<p>Select a folder from solution explorer based on your file type (Images or Scripts or Content for CSS)</p>
<p>Right click and select &ldquo;Open Folder in File Explorer&rdquo; option</p>
<p>Now paste your files into the folderAgain in the solution explorer window at the top, click &ldquo;Show All Files&rdquo; icon</p>
<p>Now you can find the file without active icon, right click and select &ldquo;Include in Project&rdquo; Option</p>
<p><img id="148925" src="148925-2016-02-08_22-35-22.png" alt="" width="289" height="488"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span><span class="hidden">js</span>


<div class="preview">
<pre class="html">&lt;%--&nbsp;The&nbsp;following&nbsp;4&nbsp;lines&nbsp;are&nbsp;ASP.NET&nbsp;directives&nbsp;needed&nbsp;when&nbsp;using&nbsp;SharePoint&nbsp;components&nbsp;--%&gt;&nbsp;
&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Page</span>&nbsp;<span class="html__attr_name">Inherits</span>=<span class="html__attr_value">&quot;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.WebPartPages.WebPartPage.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint.WebPartPages.WebPartPage">Microsoft.SharePoint.WebPartPages.WebPartPage</a>,&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__attr_name">MasterPageFile</span>=<span class="html__attr_value">&quot;~masterurl/default.master&quot;</span>&nbsp;<span class="html__attr_name">Language</span>=<span class="html__attr_value">&quot;C#&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;Utilities&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.Utilities&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;WebPartPages&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.WebPartPages&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
<span class="html__tag_start">&lt;%@&nbsp;Register</span>&nbsp;<span class="html__attr_name">TagPrefix</span>=<span class="html__attr_value">&quot;SharePoint&quot;</span>&nbsp;<span class="html__attr_name">Namespace</span>=<span class="html__attr_value">&quot;Microsoft.SharePoint.WebControls&quot;</span>&nbsp;<span class="html__attr_name">Assembly</span>=<span class="html__attr_value">&quot;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.SharePoint.aspx" target="_blank" title="Auto generated link to Microsoft.SharePoint">Microsoft.SharePoint</a>,&nbsp;Version=15.0.0.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=71e9bce111e9429c&quot;</span>&nbsp;<span class="html__tag_start">%&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;and&nbsp;script&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;<span class="html__tag_start">&lt;head</span><span class="html__tag_start">&gt;&nbsp;</span>of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderAdditionalPageHead&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery-1.9.1.min.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;SharePoint</span>:ScriptLink&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;sp.js&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">OnDemand</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">LoadAfterUI</span>=<span class="html__attr_value">&quot;true&quot;</span>&nbsp;<span class="html__attr_name">Localizable</span>=<span class="html__attr_value">&quot;false&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;meta</span>&nbsp;<span class="html__attr_name">name</span>=<span class="html__attr_value">&quot;WebPartPageExpansion&quot;</span>&nbsp;<span class="html__attr_name">content</span>=<span class="html__attr_value">&quot;full&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Add&nbsp;your&nbsp;CSS&nbsp;styles&nbsp;to&nbsp;the&nbsp;following&nbsp;file&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;Stylesheet&quot;</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/css&quot;</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/App.css&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;link</span>&nbsp;<span class="html__attr_name">href</span>=<span class="html__attr_value">&quot;../Content/jquery.dataTables.css&quot;</span>&nbsp;<span class="html__attr_name">rel</span>=<span class="html__attr_value">&quot;stylesheet&quot;</span>&nbsp;<span class="html__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__comment">&lt;!--&nbsp;Add&nbsp;your&nbsp;JavaScript&nbsp;to&nbsp;the&nbsp;following&nbsp;file&nbsp;--&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/App.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;script</span>&nbsp;<span class="html__attr_name">type</span>=<span class="html__attr_value">&quot;text/javascript&quot;</span>&nbsp;<span class="html__attr_name">src</span>=<span class="html__attr_value">&quot;../Scripts/jquery.dataTables.js&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/script&gt;</span>&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;TitleArea&nbsp;of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderPageTitleInTitleArea&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;SharePoint&nbsp;List&nbsp;to&nbsp;JQuery&nbsp;Table&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;
&nbsp;
&lt;%--&nbsp;The&nbsp;markup&nbsp;and&nbsp;script&nbsp;in&nbsp;the&nbsp;following&nbsp;Content&nbsp;element&nbsp;will&nbsp;be&nbsp;placed&nbsp;in&nbsp;the&nbsp;<span class="html__tag_start">&lt;body</span><span class="html__tag_start">&gt;&nbsp;</span>of&nbsp;the&nbsp;page&nbsp;--%&gt;&nbsp;
<span class="html__tag_start">&lt;asp</span>:Content&nbsp;<span class="html__attr_name">ContentPlaceHolderID</span>=<span class="html__attr_value">&quot;PlaceHolderMain&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;div</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;DivSPGrid&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;
<span class="html__tag_end">&lt;/asp:Content&gt;</span>&nbsp;</pre>
</div>
</div>
</div>
<p>*****************************************************************************************************</p>
<p>Hope you find this sample helpful, check out my other samples too.</p>
<p>Give five stars if you wish to appreciate my work.</p>
<p>Facebook page URL:&nbsp;<a title="https://www.facebook.com/sptechnet2016/" href="https://www.facebook.com/sptechnet2016/" target="_blank">https://www.facebook.com/sptechnet2016/</a></p>
<p>Blog URL:&nbsp;<a title="https://sptechnet.wordpress.com/" href="https://sptechnet.wordpress.com/" target="_blank">https://sptechnet.wordpress.com/</a></p>
<p>*****************************************************************************************************</p>
<p><em><br>
</em></p>
<p><em><br>
</em></p>
