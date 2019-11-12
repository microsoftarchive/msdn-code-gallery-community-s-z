# Work with early bound entity classes in code
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Dynamics CRM SDK
- Microsoft Dynamics 365
## Updated
- 12/18/2017
## Description

<h1>Work with early bound entity classes in code</h1>
<p>In Microsoft Dynamics 365 (online &amp; on-premises), the code generation tool (CrmSvcUtil) creates early-bound entity classes that you can use to access business data in Microsoft Dynamics 365. These classes include one class for each entity in your installation,
 including custom entities. Each time you make customizations to your system, you must regenerate these classes. The classes can be used in any project type or built into a class library. You can use early-bound entity classes when creating applications that
 use Microsoft Dynamics 365 as well as plug-ins and custom workflow activities. For more information about using the code generation tool, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/create-early-bound-entity-classes-code-generation-tool">
Create early bound entity classes with the code generation tool (CrmSvcUtil.exe)</a>.</p>
<p>The advantages to using early-bound entity classes is that all type references are checked at compile time. The compiled executable contains the code necessary to invoke the types&rsquo; properties, methods, and events. For more information, see
<a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-early-bound-entity-classes-create-update-delete">
Use the early-bound entity classes for create, update, and delete</a>.</p>
<p>The class created by the code generation tool includes all the entity&rsquo;s attributes and relationships. By using the class in your code, you can access these attributes and be type safe. A class with attributes and relationships is created for all entities
 in your organization. There is no difference between the generated types for system and custom entities.</p>
<p>The <strong>Strongtypes.sln</strong> contains the following code samples.</p>
<h2 class="heading">Requirements</h2>
<div class="section">
<p>This sample code requires that you have administrator rights to create a new user. For more information about the requirements for running the sample code provided, see
<a href="https://msdn.microsoft.com/en-us/library/gg328228.aspx">Use the sample and helper code</a></p>
</div>
<h2 class="title">Sample: Use the organization service context<strong>&nbsp;</strong><em>&nbsp;</em></h2>
<p>This sample shows how to use the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.client.organizationservicecontext?view=dynamics-general-ce-9">
OrganizationServiceContext</a> to perform basic operations such as create, retrieve, update and delete.</p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1982112209">BasicContextExamples.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-use-organization-service-context" tabindex="0">
Sample: Use the organization service context</a> and <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-the-organizationservicecontext-class" tabindex="0">
Use the OrganizationServiceContext class</a></p>
<h2>Sample: Create, retrieve, update, and delete records (early bound)<strong>&nbsp;</strong><em>&nbsp;</em></h2>
<p>This sample shows how to create, retrieve, update, and delete operations on an account using the early bound class. This sample uses the following common methods:</p>
<ul class="lf-text-block x_x_x_x_x_x_x_x_x_x_x_lf-block">
<li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create">Create</a>
</li><li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.retrieve">Retrieve</a>
</li><li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.update">Update</a>
</li><li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.delete">Delete</a>
</li></ul>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1409068811">
CRUDOperations.cs</a> sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-create-retrieve-update-delete-records-early-bound" tabindex="0">
Sample: Create, retrieve, update, and delete records (early bound)</a> and <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-early-bound-entity-classes-create-update-delete" tabindex="0">
Use the early-bound entity classes for create, update, and delete</a></p>
<h2>Sample: Associate records (early bound)</h2>
<p>This sample shows how to associate a contact with three account records using the
<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">
IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.associate">Associate</a> method. It also shows how to use the
<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">
IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.disassociate">Disassociate</a> method.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1902547001">
AssociateDisassociate.cs</a> sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-associate-records-early-bound" tabindex="0">
Sample: Associate records (early bound)</a></p>
<h2>Sample: Create and update records with related records (early bound)<strong>&nbsp;</strong><em>&nbsp;</em></h2>
<p>This sample shows how to create and update a record and related records in one call by using the
<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">
IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.create">Create</a> and<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">IOrganizationService</a>.
<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice.update">
Update</a> methods.</p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1019746456">CompoundCreateUpdate.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-create-update-records-related-records-early-bound" tabindex="0">
Sample: Create and update records with related records (early bound)</a> <strong>
</strong><em>&nbsp;</em></p>
<h2 class="title">Sample: Assign a record to a new owner</h2>
<div id="mainSection">
<div id="mainBody">
<div class="introduction">
<p>The sample performs the following actions:</p>
<ol>
<li>Uses a QueryExpression to retrieve the details for the current user and one other system user.&nbsp;
</li><li>Creates a new Account record for the current user, using early-bound types.&nbsp;
</li><li>Assign this new account to the other system user, using the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.assignrequest?view=dynamics-general-ce-9">
AssignRequest</a> message. </li><li>Prompts to delete all created records. </li></ol>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1168031368">
Assign.cs</a> sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-assign-record-new-owner" tabindex="0">
Sample: Assign a record to a new owner</a></p>
<h2>Sample: Retrieve license information<strong>&nbsp;</strong><em>&nbsp;</em></h2>
<p>This sample shows how to use the <a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.deployment.ideploymentservice">
IDeploymentService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievedeploymentlicensetyperequest">RetrieveDeploymentLicenseTypeRequest</a> message and the
<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.xrm.sdk.iorganizationservice">
IOrganizationService</a>.<a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.retrievelicenseinforequest">RetrieveLicenseInfoRequest</a> message to retrieve information about licenses.
<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=1935331369">License.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-retrieve-license-information" tabindex="0">
Sample: Retrieve license information</a> <strong>&nbsp;</strong><em>&nbsp;</em></p>
<h2>Sample: Initialize a record from an existing record</h2>
<p>This sample shows how to use the <a href="https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.aspx">
IOrganizationService</a>.<a href="https://msdn.microsoft.com/en-us/library/microsoft.crm.sdk.messages.initializefromrequest.aspx">InitializeFromRequest</a> message to create new records from an existing record.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Click to see&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=137603396">InitializeFrom.cs</a><strong>
</strong>the sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/sample-initialize-record-existing-record" tabindex="0">
Sample: Initialize a record from an existing record</a>&nbsp;</p>
</div>
</div>
</div>
<h2>Sample: Associate a security role to a team</h2>
<p>This sample shows how to assign a security role to a team by using the <a href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.assignrequest?view=dynamics-general-ce-9">
AssignRequest</a> <strong>&nbsp;</strong><em>&nbsp;</em>message. Note that this example does not take into consideration that a team or user can only be assigned a role from its business unit. The role to be assigned is the first from the collection that is
 returned by the <strong>RetrieveMultiple</strong> method. If that record is from a business unit that is different from the requesting team, the assignment fails.</p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=55540978">AssignSecurityRoleToTeam.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-associate-security-role-team" tabindex="0">
Sample: Associate a security role to a team</a></p>
<h2>Sample: Assign a record to a team</h2>
<p>This sample shows how to assign a record to a team by using the <a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.assignrequest">
AssignRequest</a> message.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=401413335">AssignRecordToTeam.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-assign-record-team" tabindex="0">
Sample: Assign a record to a team</a> <strong>&nbsp;</strong><em>&nbsp;</em></p>
<h2>Sample: Share records using GrantAccess, ModifyAccess and RevokeAccess messages</h2>
<p>This sample shows how to share a record using the following messages:<span class="lf-thread-btn">&nbsp;</span></p>
<ul class="lf-text-block x_x_x_x_x_x_x_x_x_lf-block">
<li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.grantaccessrequest">GrantAccessRequest</a>
</li><li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.modifyaccessrequest">ModifyAccessRequest</a>
</li><li><a class="xref" href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.crm.sdk.messages.revokeaccessrequest">RevokeAccessRequest</a>
</li></ul>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=443914102">UserAccess.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-share-records-using-grantaccess-modifyaccess-revokeaccess-messages" tabindex="0">
Sample: Share records using GrantAccess, ModifyAccess and RevokeAccess messages</a></p>
<h2>Sample: Share a record using an access team</h2>
<p>This sample shows how to allow access to a record using an access team. All members of the team receive the same access to the record as is granted to the team.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>Click to see the&nbsp;<a href="https://code.msdn.microsoft.com/Work-with-early-bound-6914f6e7/sourcecode?fileId=183415&pathId=2091089255">CreateAndShareAccessTeam.cs</a><strong>
</strong>sample file.</p>
<p>More information: <a class="selected" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-share-record-using-access-team" tabindex="0">
Sample: Share a record using an access team</a> <strong>&nbsp;</strong><em>&nbsp;</em></p>
<div id="mainSection">
<div id="mainBody">
<div class="introduction">
<ol>
</ol>
</div>
</div>
</div>
