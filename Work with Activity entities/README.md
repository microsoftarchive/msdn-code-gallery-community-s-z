# Work with Activity entities
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
- Microsoft Dynamics 365
## Updated
- 11/24/2017
## Description

<h1>Work with Activity entities.</h1>
<p><span>In Microsoft Dynamics 365 (online &amp; on-premises), activities are tasks that you or your teams perform when they contact customers, for example, sending letters or making telephone calls. You can create activities for yourselves, can assign them
 to someone else, or can share them with other users or teams. An activity is any action which can be entered on a calendar and has time dimensions (start time, stop time, due date, and duration) that help determine when the action occurred or is to occur.
 Activities has some basic properties that help determine what action the activity represents, for example, subject and description. An activity state can be opened, canceled, or completed. The completed status of an activity will have several substatus values
 associated with it to clarify the way that the activity was completed.</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>For more information, see <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/activity-entities">
Activity entities</a>&nbsp;and <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-code-activity-entities">
Sample code for activity entities</a>.</p>
<h2>Requirements</h2>
<p>For more information about the requirements for running the sample code provided in this SDK, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code">
Use the sample and helper code</a></p>
<h2>Sample: Convert a fax to task</h2>
<p>This sample shows how to create a task for a fax by using the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create?view=dynamics-general-ce-9">
IOrganizationService.Create method.</a></p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=1732892890">
ConvertFaxToTask.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-convert-fax-task">Sample: Convert a fax to task</a>.</p>
<h2>Sample: Create, retrieve, update, and delete an email attachment</h2>
<p>This sample shows how to create, retrieve, update, and delete email attachments using the following methods:</p>
<ul>
<li>IOrganizationService.Create </li><li>IOrganizationService.Retrieve </li><li>IOrganizationService.Update </li><li>IOrganizationService.Delete </li></ul>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=1949710069">
CRUDEmailAttachments.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-create-retrieve-update-delete-email-attachment">Sample: Create, retrieve, update, and delete an email attachment</a>.</p>
<h2>Sample: Promote an email message to Microsoft Dynamics 365</h2>
<p>This sample shows how to create an email activity instance from the specified email message in Microsoft Dynamics 365 by using the DeliverPromoteEmailRequest message.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=722194785">
DeliverPromoteEmail.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-promote-email-message">Sample: Promote an email message to Microsoft Dynamics 365</a>.</p>
<h2>Sample: Send an email</h2>
<p>This sample shows how to send an email SendEmailRequest message.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=637432492">
SendEmail.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-send-email">Sample: Send an email</a>.</p>
<h2>Sample: Send bulk email and monitor results</h2>
<p>This sample shows how to send bulk email using the SendBulkMailRequest and monitor the results by retrieving records from the AsyncOperation entity.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=2040130631">
SendBulkEmailAndMonitor.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-send-bulk-email-monitor-results">Sample: Send bulk email and monitor results</a>.</p>
<h2>Sample: Send an email using a template</h2>
<p>This sample shows how to send an email message by using a template using the SendEmailFromTemplateRequest message.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=734798718">
SendEmailUsingTemplate.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-send-email-template">Sample: Send an email using a template</a>.</p>
<h2>Sample: Work with activity party records</h2>
<p>This sample shows how to work with activity party records.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Activities-Samples-61bf7504/sourcecode?fileId=179755&pathId=1533035710">
WorkingWithActivityParties.cs</a> sample file.</p>
<p>More information:&nbsp;<a href="https://msdn.microsoft.com/en-us/library/hh372955.aspx">Sample: Work with activity party records</a>.</p>
