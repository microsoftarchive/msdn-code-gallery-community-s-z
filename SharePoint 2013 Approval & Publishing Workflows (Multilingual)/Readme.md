# SharePoint 2013 Approval & Publishing Workflows (Multilingual)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
- SharePoint Foundation 2013
- apps for SharePoint
## Topics
- SharePoint
- Workflows
- apps for SharePoint
## Updated
- 09/10/2013
## Description

<h1>Introduction</h1>
<p><em>SharePoint 2013 doesnt provide any out of the box Approval or Publishing Approval Workflows as like 2010. Moreover the workflow has been completly</em> re architectured in 2013 based on CSOM.
<span>The Custom workflow sample provides an option of enabling workflows on any list with a custom association form to configure input parameters and task alert email parameters. The sample also&nbsp;provides&nbsp;multilingual capabilities. Moreover the publishing
 approval workflow can be enabled on publishing sites by enabling just one feature. provides an additional option of configuring the global settings thru a common configuration list.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Upon deployment, the solution&nbsp;enables the following&nbsp;3 features.</em></p>
<ol>
<li>Custom Approval Workflows Infrastructure (Site Collection Scoped) &nbsp; </li><li>Custom Approval Workflows Infrastructure (Web Scoped) </li><li>Configure Publishing Approval Workflow - For Windows Based Authentication (Web Scoped)
</li></ol>
<p><strong>Custom Approval Workflows Infrastructure (Web Scoped) <br>
</strong>If you would like to enable workflow on a non publishing site, this is the only feature you need to activate. the feature basically deploys the Approval Worklfow, associated resources and forms. Upon activation you will be able to see the worklfow
 listed on any list workflow settings.</p>
<p>Upon association the workflow does provides an association page 2, where it does provide an option to fill the following parameters.</p>
<ol>
<li>Approvers </li><li>Due duration (days) </li><li>Option to end on document change </li><li>Option to End on First Approval </li><li>Task Title </li><li>Task Assignment Email Subject </li><li>Task Assignment Email Body </li><li>Task Cancellation Email Subject </li><li>Task Cancellation Email Body </li><li>Task Overdue Email Subject </li><li>Task Overdue Email Body </li></ol>
<p>During first time configuration the fields will be filled with default values. If you would like to change the values, please ensure you dont remove the place holders from the default values.</p>
<p>Upon submission the workflow will be configured on the given list.</p>
<p><strong>Important Note:</strong></p>
<p>Upon assocation, the following manul steps are required for the workflow to work as expected.</p>
<ol>
<li>Enable &quot;<strong>Worklfow 2013 Task&quot; Content Type </strong>on Workflow Task list associated with the workflow.
</li><li>Activate the web scoped feature <strong>&quot;Workflows can use app permissions&quot;</strong>
</li><li>Enable <a href="http://msdn.microsoft.com/en-us/library/jj822159.aspx/">permission</a> for the workflow to access the content on the sharepoint.
</li></ol>
<p><strong>Custom Approval Workflows Infrastructure (Site Collection Scoped)<br>
</strong>Required only when you need to <strong>enable publishing workflows.</strong> Can be activated only on the Root site collection. Upon activation, the feature deploys a
<strong>&quot;Workflow Global Settings&quot;</strong> list with the following items.</p>
<ul>
<li><strong>ApprovalWorkflowApproversSharePointGroup </strong>- Approvers|Administrators
<ul>
<li>use this entry to configure the default approvers group associated with the publishing approval. The values can be | (or) or &amp; (And) splitted. Can have multiple values. however doesnt support mixed splitters. (both | and &amp;)
</li></ul>
</li><li><strong>ApprovalWorkflowDefaultDurationDays </strong>- 7
<ul>
<li>Default number of duration days. </li></ul>
</li><li><strong>EnablePublishingApprovalWorkflowOnLists </strong>- Pages,Images,Documents
<ul>
<li>Lists on Publlishing site for which the approval workflow needs to be enabled.
</li></ul>
</li></ul>
<p><strong>Configure Publishing Approval Workflow - For Windows Based Authentication (Web Scoped)<br>
</strong>This feature configures publishing approval workflows as per the above configuration settings on a publishing site. Upon activation the feature perfroms the following actions on the web.</p>
<ol>
<li>Associates the workflow on Pages, Images and Document Libraries. </li><li>Uses the email templates from resource files. </li><li>Since Sharepoint 2013 supports triggering of workflow only on Item Added, Updated or Manul, there is no option of triggering the workflow on Item Major checkins, hence the approval action can be handled only thru the event recivers.
<ul>
<li>Associates the following event receivers on the lists to handle all the possible scenarios of approval actions.
<ul>
<li>Item Updating </li><li>Item Updated </li><li>Item CheckedIn </li></ul>
</li><li>Approval Actions Supported
<ul>
<li>Approval Override (Direct Approval/Reject) thru ribbon (cancells the in progress workflow)
</li><li>Cancel Approval (Cancells the inprogress workflow) </li><li>Approval/Rejection thru workflow task. </li></ul>
</li></ul>
</li><li>Activates the dependency feature - &nbsp;<strong>&quot;Workflows can use app permissions&quot;</strong>
</li><li>Enables Trust to the workflow - (Automation of enabling <a href="http://msdn.microsoft.com/en-us/library/jj822159.aspx/">
permission</a> for the workflow to access the sharepoint) </li></ol>
<h1>More Information</h1>
<p><strong><em>Workflow Services WCF Service</em></strong></p>
<p><em>The solution includes a WCF service which provides some management capabilities like&nbsp;approval/Rejection. As the 2013 workflows are CSOM based these actions are not possible directly from the workflow. hence those capabilities are acheived thru the
 server based services.</em></p>
<h1>Jquery (OpenSource) - Work with your Legal Dept</h1>
<p>The solution leverages Jquery to perform some operations on the association form to provide enhanced features.
<br>
<span style="color:#ff0000"><strong><span style="text-decoration:underline">However the script files are not included as part of the solution.</span></strong></span><br>
<br>
For the solution, in order to work/behave as expected the following Jquery <span style="text-decoration:underline">
.js files need to be included</span> in the solution path <span style="text-decoration:underline">
\layouts\customapprovalworkflow\scripts\</span> before compilation and deployment.</p>
<ol>
<li>jquery-1.8.2.js </li><li>jquery-1.8.2.min.js </li></ol>
<p><span style="color:#ff0000"><span style="text-decoration:underline">Please check with your legal department before enabling the jquery scripts on the end user solution</span>.</span></p>
