# Sharepoint 2013 - How to add a Promoted links web part to your default app page
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- apps for SharePoint
- SharePoint 2013
## Topics
- SharePoint
- Development
## Updated
- 04/30/2013
## Description

<h1>Introduction</h1>
<p>In this sample will help you to add a Promoted links web part to your default app page. by using Microsoft Office Developer Tools for Visual Studio 2012 we will create nice view for Promoted links list and add to out sharepoint 2013 sharepoint-host app.</p>
<p>To more details and apply this article step by step:<a href="http://mushannak.blogspot.com/2013/02/how-add-promoted-links-web-part-to.html">http://mushannak.blogspot.com/2013/02/how-add-promoted-links-web-part-to.html</a></p>
<p>&nbsp;</p>
<p>After we you prepared your SharePoint 2013 development environment then download and deploy the project, you will find your default app page as the following figure:</p>
<p><img id="76382" src="76382-promoted%20links%20web-part%20to%20sharepoint%202013%20app.png" alt="" width="507" height="275"></p>
<p>&nbsp;</p>
<h1><span>Prerequisites</span></h1>
<p><em>This sample requires the following:<br>
&bull;&nbsp;A SharePoint 2013 development environment (you can use office 365 developer preview)<br>
&bull;&nbsp;Visual Studio 2012 and SharePoint development tools in Visual Studio 2012 installed on your developer computer</em></p>
<h1><span style="font-size:20px; font-weight:bold"><span>Description</span></span></h1>
<p>The sample also demonstrates how to create, package, and deploy a Promoted links list to the app web and add the Promoted links web part to your default app page.&nbsp;</p>
<p>&nbsp;We will use the following tags to add the web part to the default.aspx app page:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">&lt;WebPartPages:WebPartZone ID=&quot;WebPartZone&quot; runat=&quot;server&quot; FrameType=&quot;None&quot;&gt;
            &lt;WebPartPages:XsltListViewWebPart ID=&quot;XsltListViewAppPromotedList&quot;
                runat=&quot;server&quot; ListUrl=&quot;Lists/MyPromotedLinks&quot; IsIncluded=&quot;True&quot;
                NoDefaultStyle=&quot;TRUE&quot; Title=&quot;Images used in switcher&quot;
                PageType=&quot;PAGE_NORMALVIEW&quot; Default=&quot;False&quot;
                ViewContentTypeId=&quot;0x&quot;&gt;
            &lt;/WebPartPages:XsltListViewWebPart&gt;
       &lt;/WebPartPages:WebPartZone&gt;
</pre>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;WebPartPages</span>:WebPartZone&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;WebPartZone&quot;</span>&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">FrameType</span>=<span class="html__attr_value">&quot;None&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;WebPartPages</span>:XsltListViewWebPart&nbsp;<span class="html__attr_name">ID</span>=<span class="html__attr_value">&quot;XsltListViewAppPromotedList&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">runat</span>=<span class="html__attr_value">&quot;server&quot;</span>&nbsp;<span class="html__attr_name">ListUrl</span>=<span class="html__attr_value">&quot;Lists/MyPromotedLinks&quot;</span>&nbsp;<span class="html__attr_name">IsIncluded</span>=<span class="html__attr_value">&quot;True&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">NoDefaultStyle</span>=<span class="html__attr_value">&quot;TRUE&quot;</span>&nbsp;<span class="html__attr_name">Title</span>=<span class="html__attr_value">&quot;Images&nbsp;used&nbsp;in&nbsp;switcher&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">PageType</span>=<span class="html__attr_value">&quot;PAGE_NORMALVIEW&quot;</span>&nbsp;<span class="html__attr_name">Default</span>=<span class="html__attr_value">&quot;False&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__attr_name">ViewContentTypeId</span>=<span class="html__attr_value">&quot;0x&quot;</span><span class="html__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/WebPartPages:XsltListViewWebPart&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/WebPartPages:WebPartZone&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>To more details and apply this article step by step:<a href="http://mushannak.blogspot.com/2013/02/how-add-promoted-links-web-part-to.html">http://mushannak.blogspot.com/2013/02/how-add-promoted-links-web-part-to.html</a></em></p>
<p><em>How to Set up an environment for developing apps for SharePoint on Office 365:
<a href="http://msdn.microsoft.com/en-us/library/fp161179.aspx">http://msdn.microsoft.com/en-us/library/fp161179.aspx</a></em></p>
<p><em>How to Create a basic app for SharePoint by using &quot;Napa&quot; Office 365 Development Tools :
<a href="http://msdn.microsoft.com/en-us/library/jj220041.aspx">http://msdn.microsoft.com/en-us/library/jj220041.aspx</a></em></p>
<h1>Troubleshooting</h1>
<p><span style="font-size:small">The following table lists common configuration and environment errors that prevent the sample from running or deploying properly and how to solve them.</span></p>
<table border="0" cellspacing="5" cellpadding="5" frame="void" align="left" style="width:601px; height:212px">
<tbody>
<tr style="background-color:#a9a9a9">
<th align="left" scope="col"><strong><span style="font-size:small">Problem </span>
</strong></th>
<th align="left" scope="col"><strong><span style="font-size:small">Solution</span></strong></th>
</tr>
<tr valign="top">
<td><span style="font-size:small">Visual Studio does not open the browser after you press the F5 key.</span></td>
<td><span style="font-size:small">Set the app for SharePoint project as the startup project.</span></td>
</tr>
<tr valign="top">
<td><span style="font-size:small">
<div>
<p>&ldquo;The file not found&rdquo; error in App default.aspx page</p>
</div>
</span></td>
<td><span style="font-size:small">validate and correct the ListUrl path.</span></td>
</tr>
</tbody>
</table>
<h1><br>
<br>
<span style="font-size:small">&nbsp;</span><br>
<br>
<br>
</h1>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
