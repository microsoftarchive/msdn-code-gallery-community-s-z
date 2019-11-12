# Work with SharePoint Integration
## Requires
- Visual Studio 2017
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Dynamics CRM SDK
## Updated
- 11/16/2017
## Description

<h1>Work with SharePoint integration</h1>
<p>SharePoint Server integration enables document management capabilities in Microsoft Dynamics 365. There are two aspects to SharePoint Server integration:</p>
<ul class="unordered">
<li>
<p><span class="label">Setting up SharePoint integration</span>. A system administrator sets up a SharePoint Server environment. The Microsoft Dynamics 365 administrator (a user who has the SharePoint Site Collection Administrator role) selects the Microsoft
 Dynamics 365 entities for which to enable the document management feature, and specifies the target SharePoint Server. As part of specifying the target server, the Microsoft Dynamics 365 administrator specifies the SharePoint Server site collection or the
 SharePoint Server site URL by using the <strong>SharePointSite</strong> entity.</p>
</li><li>
<p><span class="label">Creating and managing SharePoint document location records</span>. Microsoft Dynamics 365 users can create and manage SharePoint Server document location records after SharePoint Server integration is enabled. You can create and manage
 SharePoint Server document location records by using the <strong>SharePointDocumentLocation</strong> entity. Microsoft Dynamics 365 also allows for the automatic creation of folders on the server that is running SharePoint Server for entity records under certain
 conditions. However, automatic creation of folders cannot be done through the Microsoft Dynamics 365 SDK.</p>
</li></ul>
<p>The <strong>SharePointIntegration.sln</strong> file contains the following code samples.</p>
<h2>Requirements</h2>
<p>For more information about the requirements for running the sample code provided here, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code">
Use the sample and helper code</a>.</p>
<h2><span>Sample: Enable document management for entities</span></h2>
<p>The following sample shows how to enable document management for entities in Microsoft Dynamics 365. In this sample code, document management is enabled for the
<strong>Contact</strong> entity using the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updateentityrequest?view=dynamics-general-ce-9">
UpdateEntityRequest</a> message. By default, the setting for the <strong>Contact</strong> entity isn&rsquo;t enabled in a new installation of Dynamics 365.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Samples-of-Sharepoint-b4fb016f/sourcecode?fileId=182202&pathId=958299383">
EnableDocumentManagement.cs</a> sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/sample-enable-document-management-entities">
Sample: Enable document management for entities</a> and <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/enable-document-management-entities" tabindex="0">
Enable document management for entities</a> <strong>&nbsp;</strong><em>&nbsp;</em><em><br>
</em></p>
<h2><span>Sample: Create, retrieve, update, and delete a SharePoint location record</span></h2>
<p>The sample shows how to create, retrieve, update, and delete a SharePoint Server document location records.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Samples-of-Sharepoint-b4fb016f/sourcecode?fileId=182202&pathId=958299383">
CRUDSharePointLocationRecords.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/sample-create-retrieve-update-delete-sharepoint-location-record">Sample: Create, retrieve, update, and delete a SharePoint location
 record</a> and <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/actions-on-sharepoint-location-records" tabindex="0">
Actions on SharePoint location records</a></p>
<h2><span>Sample: Retrieve absolute URL and site collection URL of a location record</span></h2>
<p>This sample shows how to retrieve the absolute URL and the site collection URL of a SharePoint Server location record in Dynamics 365 using the
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrieveabsoluteandsitecollectionurlrequest?view=dynamics-general-ce-9">
RetrieveAbsoluteAndSiteCollectionUrlRequest</a> message.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Samples-of-Sharepoint-b4fb016f/sourcecode?fileId=182202&pathId=19308438">
RetrieveAbsoluteAndSiteCollectionURLs.cs</a> sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/sample-retrieve-absolute-url-and-site-collection-url-of-a-location-record">
Sample: Retrieve absolute URL and site collection URL of a location record</a> and
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/integration-dev/actions-on-sharepoint-location-records#retrieve-absolute-and-site-collection-urls-for-a-location-record">
Actions on SharePoint location records</a></p>
