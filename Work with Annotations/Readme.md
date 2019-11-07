# Work with Annotations
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- library assembly
- Microsoft Dynamics CRM SDK
## Updated
- 11/24/2017
## Description

<div class="content">
<div>
<div class="topic">
<h1 class="title">Sample: Upload, retrieve, and download an attachment</h1>
<div id="mainSection">
<div id="mainBody">
<div class="introduction">
<p>The annotations (notes) provide easy ways to append additional information to any record in the Microsoft Dynamics 365 database. An annotation (note) is a text entry that can be associated with any entity in Dynamics 365. However, you can associate annotations
 with only those custom entities that are created with the HasNotes property set to true. You can update a custom entity, which is not enabled for notes, to have notes by setting the HasNotes property to true.</p>
<p>An attached file can be any standard computer file format that includes Microsoft Office Word documents, Microsoft Office Excel spreadsheets, CAD files, and PDF files. An attachment can be associated with any object, other than an annotation (note), in Dynamics
 365.</p>
<p>To upload or remove an attachment, use the&nbsp;<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.update?view=dynamics-general-ce-9" target="_blank">IOrganizationService.Update</a>&nbsp;method or&nbsp;<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.messages.updaterequest?view=dynamics-general-ce-9" target="_blank">UpdateRequest</a>&nbsp;message,
 setting the&nbsp;<strong>Annotation.Filename</strong>&nbsp;and&nbsp;<strong>Annotation.MimeType</strong>&nbsp;properties. This uploads an attachment that has been decoded into a base64 string format. The&nbsp;System.Convert.ToBase64String method can be used
 to convert the contents of a data file into a base64-formatted string. The maximum size of files that can be uploaded is determined by the&nbsp;<strong>Organization.MaxUploadFileSize</strong>&nbsp;property. This property is set in the&nbsp;<strong>Email</strong>&nbsp;tab
 of the&nbsp;<strong>System Settings</strong>&nbsp;in the Dynamics 365 application. This setting limits the size of files that can be attached to email messages, notes, and web resources. The default setting is 5 MB.&nbsp;</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/annotation-note-entity">
Annotation (note) entity</a>.</p>
</div>
<div class="section">
<h2 class="heading">Requirements</h2>
<div class="section">
<p>For more information about the requirements for running the sample code provided in this SDK, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code" target="_blank">
Use the sample and helper code</a>.</p>
</div>
</div>
<div class="section">
<h2 class="heading">Demonstrates</h2>
<div class="section">
<p>This sample shows how to upload, retrieve, and download an attachment for an annotation using the
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create?view=dynamics-general-ce-9#Microsoft_Xrm_Sdk_IOrganizationService_Create_Microsoft_Xrm_Sdk_Entity_" target="_blank">
IOrganizationService.Create</a> and <a href="https://docs.microsoft.com/dotnet/api/microsoft.xrm.sdk.iorganizationservice.retrieve?view=dynamics-general-ce-9">
IOrganizationService.Retrieve</a> methods.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Annotation-Sample-9d797e21/sourcecode?fileId=182600&pathId=1623756143">
UploadAndDownloadAttachment.cs</a> sample file.</p>
<p>More information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-upload-retrieve-download-attachment">
Sample: Upload, retrieve and download an attachment</a>.</p>
</div>
</div>
<div class="section">
<div class="codeSnippetContainer" id="code-snippet-1">
<div class="code"></div>
<hr class="codeDivider">
</div>
</div>
<div class="LW_CollapsibleArea_Container">
<div class="LW_CollapsibleArea_TitleDiv"><span class="LW_CollapsibleArea_Title">See Also</span>
<div class="LW_CollapsibleArea_HrDiv">
<hr class="LW_CollapsibleArea_Hr">
</div>
</div>
<p><a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice?view=dynamics-general-ce-9" target="_blank">IOrganizationService</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create?view=dynamics-general-ce-9" target="_blank">Create</a><br>
<a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.retrieve?view=dynamics-general-ce-9" target="_blank">Retrieve</a><br>
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/helper-code-serverconnection-class">Helper code: ServerConnection class</a><br>
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/annotation-note-entity">Annotation (note) entity</a></p>
</div>
<p>&nbsp;</p>
</div>
</div>
</div>
</div>
</div>
