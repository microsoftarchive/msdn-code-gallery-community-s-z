# SharePoint Integration from CRM Online Workflow/Plugin
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Microsoft Dynamics CRM 2013 Online
## Topics
- SharePoint
## Updated
- 12/29/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">In this sample I&rsquo;ll show you how to integrate with SharePoint directly rather than relying on the out of the box integration.
</span><br>
<span style="font-size:small">Using the standard integration, a new folder will be created for each record underneath the default site. In some solutions you&rsquo;ll find that you want to modify this behaviour so that folders are created in a custom location.
 You may for example want to have an opportunity folder created under a site that is specific to a particular client rather than all under the same site.</span><br>
<span style="font-size:small">The challenge with integrating with SharePoint using a CRM Online Workflow Activity/Plugin is that you can&rsquo;t reference the SharePoint Assemblies which authenticating and calling the SharePoint web service somewhat harder.
 Thanks goes to fellow Dynamics CRM MVP Rhett for his blog that provided a starting point for this sample -
<a href="https://bingsoft.wordpress.com/2013/06/19/crm-online-to-sharepoint-online-integration-using-rest-and-adfs/">
https://bingsoft.wordpress.com/2013/06/19/crm-online-to-sharepoint-online-integration-using-rest-and-adfs/</a>. The sample code in this post shows how to create a folder in SharePoint and then associate it with a Document Location. The authentication with SharePoint
 works via ADFS and since the out of the box integration uses a trust between CRM and SharePoint that is not accessible from a sandbox (even if you try and ILMerge it!) we have to provide a username and password that will act as our privileged user that can
 create folders in SharePoint. I have left a function where you can add your own credentials or implement a method to retrieve from a secure entity in CRM that only administrators have access to. Look in the code for the &lsquo;GetSecureConfigValue&rsquo; function.</span></p>
<p><em>&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">The workflow activity is deployed using the Developer Toolkit for Dynamics CRM and performs the following:</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The sample contains a custom workflow activity that works on both CRM Online and CRM OnPrem accepting the following parameters:</span></p>
<ul>
<li><span style="font-size:small">Site &ndash;&nbsp; A reference to the site that you want to create a folder in. You could store a look up to a site for each customer and populate this parameter from the related account.</span>
</li><li><span style="font-size:small">Record Dynamic Url &ndash; The &lsquo;Dynamic Record Url&rsquo; for the record that you want the SharePoint document location to be related to. This uses my Polymorphic input parameter technique. You simply need to pass the
 Record Url (Dynamic) for the record that you wish to create the folder for.</span>
</li><li><span style="font-size:small">Document Library Name &ndash; The name of the document location to create the folder underneath. In the out of the box integration this is the entity logical name (e.g. account)</span>
</li><li><span style="font-size:small">Record Folder Name &ndash; The name of the folder to create. You could use the client name, client ID etc. &ndash; but it will automatically have the GUID appended to it to ensure uniqueness just like the out of the box integration<br>
</span></li></ul>
<h1><em><em><br>
</em></em></h1>
<h1>More Information</h1>
<p><span style="font-size:small"><em>For more information see the original blog post -
<a href="http://develop1.net/public/post/SharePoint-Integration-Reloaded-e28093-Part-3.aspx">
http://develop1.net/public/post/SharePoint-Integration-Reloaded-e28093-Part-3.aspx</a></em></span></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
