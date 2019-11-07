# Sdk.Soap.js
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- CRM Online
- Javascript
- Microsoft CRM SDK
- Microsoft Dynamics CRM 2013
## Topics
- CRM Extensibility
- Microsoft Dynamics CRM SDK
- SOAP Web Service
- Use Microsoft CRM SOAP web service with JavaScript
## Updated
- 10/03/2018
## Description

<ul>
<li><a href="#intro">Introduction</a> </li><li><a href="#intellisense">IntelliSense support</a> </li><li><a href="#earlybound">Early-bound vs. Late-bound</a> </li><li><a href="#promises">Use promises and asynchronous XmlHttpRequests</a> </li><li><a href="#messages">Use messages</a> </li><li><a href="#actions">Use actions</a> </li><li><a href="#query">Query Data</a> </li><li><a href="#collection">Use the Sdk.Collection class</a> </li><li><a href="#design">Design notes</a> </li><li><a href="#issues">Known issues</a> </li></ul>
<h1 id="intro">Introduction</h1>
<p>Use this library to write JavaScript code in web resources that can perform actions using the Microsoft Dynamics CRM 2013 Modern App SOAP endpoint (formerly known as the SOAP endpoint for web resources).</p>
<p>You can use this library in form scripts, ribbon commands, or HTML web resources. This library does not provide code to allow authentication for outside of web resources.</p>
<h1 id="intellisense">IntelliSense support</h1>
<p>The Sdk.Soap.js library provides an object model, methods, and messages that you use to write JavaScript code in a manner similar to how you write C# code. Visual Studio has greatly improved how IntelliSense is provided at design time. The Sdk.Soap.js project
 provides two files described in the following table, but this document refers to them used together as the Sdk.Soap.js library.</p>
<table>
<thead>
<tr>
<th>File</th>
<th>Description and Usage</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>Sdk.Soap.vsdoc.js</strong></td>
<td>
<ul>
<li>Use this file at design time by including a reference at the top of JavaScript files you author. Simply include this file in your project and drag it to the top of the JavaScript library that you&rsquo;re writing.
</li><li>This library includes comments that provide detailed design-time IntelliSense about the objects and methods included.
</li><li>Size: 400 Kb </li></ul>
</td>
</tr>
<tr>
<td><strong>Sdk.Soap.min.js</strong></td>
<td>
<ul>
<li>Create a JavaScript web resource using this file and include links to it within any HTML pages that use it.
</li><li>If you&rsquo;re adding this library to a ribbon command or form event handler, it must load before any other code that references it loads.
</li><li>Size: 164 Kb. </li><li>This file is simply the minimized version of Sdk.Soap.vsdoc.js. If you need to edit the library, edit the vsdoc version and then minimize it.
</li></ul>
</td>
</tr>
</tbody>
</table>
<p><strong>Note</strong>: Full reference documentation for Sdk.Soap.js is not currently available, but you can reference the object and method notes for any method using IntelliSense or by reviewing the comments in Sdk.Soap.vsdoc.js.</p>
<p>Like writing managed code using the Microsoft Dynamics CRM web services, this library provides the options to choose whether you write code using an &ldquo;early-bound&rdquo; or &ldquo;late-bound&rdquo; style. You can use the Sdk.Soap.js library alone to
 write code in the late-bound style.</p>
<p>See <a title="Sdk.Soap.js Samples" href="http://code.msdn.microsoft.com/SdkSoapjs-Samples-378151cd" target="_blank">
Sdk.Soap.js Samples</a> for examples.</p>
<h1 id="earlybound">Early-bound vs. Late-bound</h1>
<p>Many developers prefer an early-bound style that requires you to generate class files that provide design-time IntelliSense support for the CRM entities that you&rsquo;re working with. With managed code, this requires generating a supporting file using the
<a href="http://msdn.microsoft.com/en-us/library/gg327844(v=crm.6).aspx" target="_blank">
CRMSvcUtil.exe code generation tool</a>.</p>
<p>With Sdk.Soap.js you can generate files to provide object definition and design-time IntelliSense support in Visual Studio using the separate
<a href="http://code.msdn.microsoft.com/SdkSoapjs-Entity-Class-14ca830f" target="_blank">
Sdk.Soap Entity Class Generator</a> project. See that project for more information.</p>
<p>However, the code generation tool and the Sdk.Soap entity class generator can only generate classes for entity definitions known in the organization that they&rsquo;re run against. If your code only uses the entities, attributes, and entity relationships
 present when these tools are used, the classes will represent the objects your code needs. When you move your code to a different organization, or when new entities, attributes, or entity relationships get added through customizations, you have to generate
 these classes again.</p>
<p>The alternative is to write your code without the supporting design time classes. Sdk.Soap.js provides an
<strong>Sdk.Entity</strong> class that corresponds to the <a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.entity(v=crm.6).aspx" target="_blank">
Microsoft.Xrm.Entity</a> class. However, you won&rsquo;t be able to take advantage of the design-time auto-completion and IntelliSense in Visual Studio. You'll have to look up information about entities and attributes using resources like the
<a href="http://msdn.microsoft.com/en-us/library/hh547411(v=crm.6).aspx" target="_blank">
Metadata Browser</a>.</p>
<p>The advantage of using a late-bound style, especially with JavaScript, is that you can reduce the number of files that must be loaded into the page.</p>
<p>The <strong><a title="Sdk.Soap.js Samples" href="http://code.msdn.microsoft.com/SdkSoapjs-Samples-378151cd" target="_blank">Sdk.Soap.js Samples</a></strong> project contains a number of examples showing both early-bound and late-bound styles. For example:</p>
<h2>Early-bound initialization of an Account:</h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden"> var account = new Sdk.Account()
 account.Name.setValue(&quot;Sample Account 001&quot;);
 account.CreditOnHold.setValue(false);
 account.Address1_Latitude.setValue(47.638197);
 account.Address1_Longitude.setValue(-122.131378);
 account.NumberOfEmployees.setValue(500);
 account.Description.setValue(&quot;This is a description.&quot;);
 account.CreditLimit.setValue(200000.00);
 account.AccountCategoryCode.setValue(1);
</pre>
<div class="preview">
<pre class="js">&nbsp;<span class="js__statement">var</span>&nbsp;account&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Sdk.Account()&nbsp;
&nbsp;account.Name.setValue(<span class="js__string">&quot;Sample&nbsp;Account&nbsp;001&quot;</span>);&nbsp;
&nbsp;account.CreditOnHold.setValue(false);&nbsp;
&nbsp;account.Address1_Latitude.setValue(<span class="js__num">47.638197</span>);&nbsp;
&nbsp;account.Address1_Longitude.setValue(-<span class="js__num">122.131378</span>);&nbsp;
&nbsp;account.NumberOfEmployees.setValue(<span class="js__num">500</span>);&nbsp;
&nbsp;account.Description.setValue(<span class="js__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&quot;</span>);&nbsp;
&nbsp;account.CreditLimit.setValue(<span class="js__num">200000.00</span>);&nbsp;
&nbsp;account.AccountCategoryCode.setValue(<span class="js__num">1</span>);&nbsp;</pre>
</div>
</div>
</div>
<h2>Late-bound initialization of an Account:</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden"> var account = new Sdk.Entity(&quot;account&quot;);
 account.addAttribute(new Sdk.String(&quot;name&quot;, name));
 account.addAttribute(new Sdk.Boolean(&quot;creditonhold&quot;, false));
 account.addAttribute(new Sdk.Double(&quot;address1_latitude&quot;, 47.638197));
 account.addAttribute(new Sdk.Double(&quot;address1_longitude&quot;, -122.131378));
 account.addAttribute(new Sdk.Int(&quot;numberofemployees&quot;, 100000));
 account.addAttribute(new Sdk.String(&quot;description&quot;, &quot;This is a description.&quot;));
 account.addAttribute(new Sdk.Money(&quot;creditlimit&quot;, 2000000));
 account.addAttribute(new Sdk.OptionSet(&quot;accountcategorycode&quot;, 1)); //Preferred Customer
</pre>
<div class="preview">
<pre class="js">&nbsp;<span class="js__statement">var</span>&nbsp;account&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Sdk.Entity(<span class="js__string">&quot;account&quot;</span>);&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">String</span>(<span class="js__string">&quot;name&quot;</span>,&nbsp;name));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">Boolean</span>(<span class="js__string">&quot;creditonhold&quot;</span>,&nbsp;false));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Double(<span class="js__string">&quot;address1_latitude&quot;</span>,&nbsp;<span class="js__num">47.638197</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Double(<span class="js__string">&quot;address1_longitude&quot;</span>,&nbsp;-<span class="js__num">122.131378</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Int(<span class="js__string">&quot;numberofemployees&quot;</span>,&nbsp;<span class="js__num">100000</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.<span class="js__object">String</span>(<span class="js__string">&quot;description&quot;</span>,&nbsp;<span class="js__string">&quot;This&nbsp;is&nbsp;a&nbsp;description.&quot;</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.Money(<span class="js__string">&quot;creditlimit&quot;</span>,&nbsp;<span class="js__num">2000000</span>));&nbsp;
&nbsp;account.addAttribute(<span class="js__operator">new</span>&nbsp;Sdk.OptionSet(<span class="js__string">&quot;accountcategorycode&quot;</span>,&nbsp;<span class="js__num">1</span>));&nbsp;<span class="js__sl_comment">//Preferred&nbsp;Customer</span>&nbsp;</pre>
</div>
</div>
</div>
<h1 id="promises">Use promises and asynchronous XmlHttpRequests</h1>
<p>XmlHttpRequests performed using JavaScript should be asynchronous. Sdk.Soap.js provides the capability to perform synchronous requests, but this isn&rsquo;t recommended.</p>
<p>Traditionally asynchronous XmlHttpRequests are performed using functions that allow for setting callback functions for success and error conditions. With this style, a chain of operations are added by continuing the next step within the success callback.</p>
<p>The alternative to this approach is to use promises. JQuery uses a <a href="http://api.jquery.com/category/deferred-object/" target="_blank">
Deferred object</a> that provides chainable utility that returns a promise. The <a href="http://wiki.commonjs.org/wiki/Promises/A" target="_blank">
CommonJS Promises/A proposal</a> defines a slightly different definition of how promises should work. There are a number of different libraries that implement this standard.
<a href="https://github.com/kriskowal/q" target="_blank">One of them is Q</a>.</p>
<p>In order to provide you with options that match your preferences, Sdk.Soap.js separates the core methods used in CRM web services into four separate namespaces. Each of these namespaces provides the methods in the following table that correspond to
<a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.aspx" target="_blank">
IOrganizationService</a> methods.</p>
<table>
<thead>
<tr>
<th>Method</th>
<th>IOrganizationService method</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>associate</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.associate(v=crm.6).aspx" target="_blank">Associate</a></td>
</tr>
<tr>
<td><strong>create</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.create(v=crm.6).aspx" target="_blank">Create</a></td>
</tr>
<tr>
<td><strong>del</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.delete(v=crm.6).aspx" target="_blank">Delete</a><br>
<strong>Note</strong>: &lsquo;delete&rsquo; is a JavaScript keyword and can&rsquo;t be used as a method name.</td>
</tr>
<tr>
<td><strong>disassociate</strong></td>
<td><a title="Disassociate" href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.disassociate(v=crm.6).aspx" target="_blank">Disassociate</a></td>
</tr>
<tr>
<td class="auto-style1"><strong>execute</strong></td>
<td class="auto-style1"><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.execute(v=crm.6).aspx" target="_blank">Execute</a></td>
</tr>
<tr>
<td><strong>retrieve</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.retrieve(v=crm.6).aspx" target="_blank">Retrieve</a></td>
</tr>
<tr>
<td><strong>retrieveMultiple</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.retrievemultiple(v=crm.6).aspx" target="_blank">RetrieveMultiple</a></td>
</tr>
<tr>
<td><strong>update</strong></td>
<td><a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iorganizationservice.update(v=crm.6).aspx" target="_blank">Update</a></td>
</tr>
</tbody>
</table>
<p>The following table describes the namespaces that implement these methods.</p>
<table>
<thead>
<tr>
<th>Namespace</th>
<th>Description &amp; Comments</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>Sdk.Async</strong></td>
<td>
<ul>
<li>The method signatures provide successCallBack and errorCallBack parameters. </li><li>No supporting library required. </li></ul>
</td>
</tr>
<tr>
<td><strong>Sdk.jQ</strong></td>
<td>
<ul>
<li>Depends on the existence of the jQuery library. </li><li>Returns a jQuery.Deferred object. </li><li>Requires that the global jQuery variable be explicitly set using the Sdk.jQ.setJQueryVariable function.
<ul>
<li>This supports the best practice defined in the <a href="http://msdn.microsoft.com/en-us/library/hh771584(v=crm.6).aspx#BKMK_UsingjQuery" target="_blank">
Use of jQuery</a> topic in the Microsoft Dynamics CRM SDK. </li><li>To avoid conflicts when multiple versions of jQuery might be loaded in a single page, you should explicitly set the jQuery variable.
</li><li>If you&rsquo;re using jQuery in your own HTML web resource and want to use the default jQuery variable, simply include the following line somewhere in your code:<br>
<span style="font-family:Consolas; font-size:smaller">Sdk.jQ.setJQueryVariable($);</span>
</li></ul>
</li></ul>
</td>
</tr>
<tr>
<td><strong>Sdk.Q</strong></td>
<td>
<ul>
<li>Depends on the <a href="https://github.com/kriskowal/q" target="_blank">Q.js</a> library
</li><li>Throws an error if the global variable Q isn&rsquo;t defined. </li></ul>
</td>
</tr>
<tr>
<td><strong>Sdk.Sync</strong></td>
<td>
<ul>
<li>Methods return synchronously. </li><li>Strongly not recommended for most situations. </li></ul>
</td>
</tr>
</tbody>
</table>
<p>If you don&rsquo;t want to use these different styles, you can edit the Sdk.Soap.vsdoc.js file and remove the entire namespace group. Then minimize the file and use it instead of Sdk.Soap.min.js.</p>
<p>If you want to implement another style, for example <strong>Sdk.WinJs</strong>, you can implement the same interface methods in a new namespace and add them to Sdk.Soap.js.</p>
<h1 id="messages">Use messages</h1>
<p>In addition to the eight core methods implemented by each namespace, you can perform operations using messages and the
<strong>execute</strong> method. The <strong>Sdk.Soap.js </strong>project provides 202 messages you can use.</p>
<table>
<tbody>
<tr>
<td>Sdk.AddItemCampaign.js</td>
<td>Sdk.AddItemCampaignActivity.js</td>
</tr>
<tr>
<td>Sdk.AddListMembersList.js</td>
<td>Sdk.AddMemberList.js</td>
</tr>
<tr>
<td>Sdk.AddMembersTeam.js</td>
<td>Sdk.AddPrivilegesRole.js</td>
</tr>
<tr>
<td>Sdk.AddProductToKit.js</td>
<td>Sdk.AddRecurrence.js</td>
</tr>
<tr>
<td>Sdk.AddSolutionComponent.js</td>
<td>Sdk.AddToQueue.js</td>
</tr>
<tr>
<td>Sdk.AddUserToRecordTeam.js</td>
<td>Sdk.Assign.js</td>
</tr>
<tr>
<td>Sdk.Associate.js</td>
<td>Sdk.AutoMapEntity.js</td>
</tr>
<tr>
<td>Sdk.BackgroundSendEmail.js</td>
<td>Sdk.Book.js</td>
</tr>
<tr>
<td>Sdk.BulkDelete.js</td>
<td>Sdk.BulkDetectDuplicates.js</td>
</tr>
<tr>
<td>Sdk.CalculateActualValueOpportunity.js</td>
<td>Sdk.CalculateTotalTimeIncident.js</td>
</tr>
<tr>
<td>Sdk.CanBeReferenced.js</td>
<td>Sdk.CanBeReferencing.js</td>
</tr>
<tr>
<td>Sdk.CancelContract.js</td>
<td>Sdk.CancelSalesOrder.js</td>
</tr>
<tr>
<td>Sdk.CanManyToMany.js</td>
<td>Sdk.CheckIncomingEmail.js</td>
</tr>
<tr>
<td>Sdk.CheckPromoteEmail.js</td>
<td>Sdk.CloneContract.js</td>
</tr>
<tr>
<td>Sdk.CloseIncident.js</td>
<td>Sdk.CloseQuote.js</td>
</tr>
<tr>
<td>Sdk.CompoundUpdateDuplicateDetectionRule.js</td>
<td>Sdk.ConvertKitToProduct.js</td>
</tr>
<tr>
<td>Sdk.ConvertOwnerTeamToAccessTeam.js</td>
<td>Sdk.ConvertProductToKit.js</td>
</tr>
<tr>
<td>Sdk.ConvertQuoteToSalesOrder.js</td>
<td>Sdk.ConvertSalesOrderToInvoice.js</td>
</tr>
<tr>
<td>Sdk.CopyCampaign.js</td>
<td>Sdk.CopyCampaignResponse.js</td>
</tr>
<tr>
<td>Sdk.CopyDynamicListToStatic.js</td>
<td>Sdk.CopyMembersList.js</td>
</tr>
<tr>
<td>Sdk.CopySystemForm.js</td>
<td>Sdk.Create.js</td>
</tr>
<tr>
<td>Sdk.CreateActivitiesList.js</td>
<td>Sdk.CreateException.js</td>
</tr>
<tr>
<td>Sdk.CreateInstance.js</td>
<td>Sdk.CreateWorkflowFromTemplate.js</td>
</tr>
<tr>
<td>Sdk.Delete.js</td>
<td>Sdk.DeleteAuditData.js</td>
</tr>
<tr>
<td>Sdk.DeleteOpenInstances.js</td>
<td>Sdk.DeliverIncomingEmail.js</td>
</tr>
<tr>
<td>Sdk.DeliverPromoteEmail.js</td>
<td>Sdk.DeprovisionLanguage.js</td>
</tr>
<tr>
<td>Sdk.Disassociate.js</td>
<td>Sdk.DistributeCampaignActivity.js</td>
</tr>
<tr>
<td>Sdk.DownloadReportDefinition.js</td>
<td>Sdk.ExecuteByIdSavedQuery.js</td>
</tr>
<tr>
<td>Sdk.ExecuteByIdUserQuery.js</td>
<td>Sdk.ExecuteMultiple.js</td>
</tr>
<tr>
<td>Sdk.ExecuteWorkflow.js</td>
<td>Sdk.ExpandCalendar.js</td>
</tr>
<tr>
<td>Sdk.ExportMappingsImportMap.js</td>
<td>Sdk.FetchXmlToQueryExpression.js</td>
</tr>
<tr>
<td>Sdk.FindParentResourceGroup.js</td>
<td>Sdk.FulfillSalesOrder.js</td>
</tr>
<tr>
<td>Sdk.GenerateInvoiceFromOpportunity.js</td>
<td>Sdk.GenerateQuoteFromOpportunity.js</td>
</tr>
<tr>
<td>Sdk.GenerateSalesOrderFromOpportunity.js</td>
<td>Sdk.GetAllTimeZonesWithDisplayName.js</td>
</tr>
<tr>
<td>Sdk.GetInvoiceProductsFromOpportunity.js</td>
<td>Sdk.GetQuantityDecimal.js</td>
</tr>
<tr>
<td>Sdk.GetQuoteProductsFromOpportunity.js</td>
<td>Sdk.GetReportHistoryLimit.js</td>
</tr>
<tr>
<td>Sdk.GetSalesOrderProductsFromOpportunity.js</td>
<td>Sdk.GetTimeZoneCodeByLocalizedName.js</td>
</tr>
<tr>
<td>Sdk.GetTrackingTokenEmail.js</td>
<td>Sdk.GrantAccess.js</td>
</tr>
<tr>
<td>Sdk.ImportMappingsImportMap.js</td>
<td>Sdk.ImportRecordsImport.js</td>
</tr>
<tr>
<td>Sdk.InitializeFrom.js</td>
<td>Sdk.InstallSampleData.js</td>
</tr>
<tr>
<td>Sdk.InstantiateFilters.js</td>
<td>Sdk.InstantiateTemplate.js</td>
</tr>
<tr>
<td>Sdk.IsComponentCustomizable.js</td>
<td>Sdk.IsDataEncryptionActive.js</td>
</tr>
<tr>
<td>Sdk.IsValidStateTransition.js</td>
<td>Sdk.LocalTimeFromUtcTime.js</td>
</tr>
<tr>
<td>Sdk.LockInvoicePricing.js</td>
<td>Sdk.LockSalesOrderPricing.js</td>
</tr>
<tr>
<td>Sdk.LoseOpportunity.js</td>
<td>Sdk.Merge.js</td>
</tr>
<tr>
<td>Sdk.ModifyAccess.js</td>
<td>Sdk.ParseImport.js</td>
</tr>
<tr>
<td>Sdk.ProcessInboundEmail.js</td>
<td>Sdk.PropagateByExpression.js</td>
</tr>
<tr>
<td>Sdk.ProvisionLanguage.js</td>
<td>Sdk.PublishAllXml.js</td>
</tr>
<tr>
<td>Sdk.PublishDuplicateRule.js</td>
<td>Sdk.PublishXml.js</td>
</tr>
<tr>
<td>Sdk.QualifyLead.js</td>
<td>Sdk.QualifyMemberList.js</td>
</tr>
<tr>
<td>Sdk.QueryExpressionToFetchXml.js</td>
<td>Sdk.QueryMultipleSchedules.js</td>
</tr>
<tr>
<td>Sdk.QuerySchedule.js</td>
<td>Sdk.ReassignObjectsOwner.js</td>
</tr>
<tr>
<td>Sdk.ReassignObjectsSystemUser.js</td>
<td>Sdk.Recalculate.js</td>
</tr>
<tr>
<td>Sdk.RemoveItemCampaign.js</td>
<td>Sdk.RemoveItemCampaignActivity.js</td>
</tr>
<tr>
<td>Sdk.RemoveMemberList.js</td>
<td>Sdk.RemoveMembersTeam.js</td>
</tr>
<tr>
<td>Sdk.RemoveParent.js</td>
<td>Sdk.RemovePrivilegeRole.js</td>
</tr>
<tr>
<td>Sdk.RemoveProductFromKit.js</td>
<td>Sdk.RemoveSolutionComponent.js</td>
</tr>
<tr>
<td>Sdk.RemoveUserFromRecordTeam.js</td>
<td>Sdk.RenewContract.js</td>
</tr>
<tr>
<td>Sdk.ReplacePrivilegesRole.js</td>
<td>Sdk.Reschedule.js</td>
</tr>
<tr>
<td>Sdk.ResetUserFilters.js</td>
<td>Sdk.Retrieve.js</td>
</tr>
<tr>
<td>Sdk.RetrieveAbsoluteAndSiteCollectionUrl.js</td>
<td>Sdk.RetrieveAllChildUsersSystemUser.js</td>
</tr>
<tr>
<td>Sdk.RetrieveAttributeChangeHistory.js</td>
<td>Sdk.RetrieveAuditDetails.js</td>
</tr>
<tr>
<td>Sdk.RetrieveAvailableLanguages.js</td>
<td>Sdk.RetrieveBusinessHierarchyBusinessUnit.js</td>
</tr>
<tr>
<td>Sdk.RetrieveByGroupResource.js</td>
<td>Sdk.RetrieveByResourceResourceGroup.js</td>
</tr>
<tr>
<td>Sdk.RetrieveByResourcesService.js</td>
<td>Sdk.RetrieveByTopIncidentProductKbArticle.js</td>
</tr>
<tr>
<td>Sdk.RetrieveByTopIncidentSubjectKbArticle.js</td>
<td>Sdk.RetrieveDataEncryptionKey.js</td>
</tr>
<tr>
<td>Sdk.RetrieveDependenciesForDelete.js</td>
<td>Sdk.RetrieveDependenciesForUninstall.js</td>
</tr>
<tr>
<td>Sdk.RetrieveDependentComponents.js</td>
<td>Sdk.RetrieveDeploymentLicenseType.js</td>
</tr>
<tr>
<td>Sdk.RetrieveDeprovisionedLanguages.js</td>
<td>Sdk.RetrieveDuplicates.js</td>
</tr>
<tr>
<td>Sdk.RetrieveExchangeRate.js</td>
<td>Sdk.RetrieveFilteredForms.js</td>
</tr>
<tr>
<td>Sdk.RetrieveFormattedImportJobResults.js</td>
<td>Sdk.RetrieveInstalledLanguagePacks.js</td>
</tr>
<tr>
<td>Sdk.RetrieveInstalledLanguagePackVersion.js</td>
<td>Sdk.RetrieveLicenseInfo.js</td>
</tr>
<tr>
<td>Sdk.RetrieveLocLabels.js</td>
<td>Sdk.RetrieveMembersBulkOperation.js</td>
</tr>
<tr>
<td>Sdk.RetrieveMetadataChanges.js</td>
<td>Sdk.RetrieveMissingDependencies.js</td>
</tr>
<tr>
<td>Sdk.RetrieveMultiple.js</td>
<td>Sdk.RetrieveOrganizationResources.js</td>
</tr>
<tr>
<td>Sdk.RetrieveParentGroupsResourceGroup.js</td>
<td>Sdk.RetrievePersonalWall.js</td>
</tr>
<tr>
<td>Sdk.RetrievePrincipalAccess.js</td>
<td>Sdk.RetrievePrincipalAttributePrivileges.js</td>
</tr>
<tr>
<td>Sdk.RetrievePrivilegeSet.js</td>
<td>Sdk.RetrieveProvisionedLanguagePackVersion.js</td>
</tr>
<tr>
<td>Sdk.RetrieveProvisionedLanguages.js</td>
<td>Sdk.RetrieveRecordChangeHistory.js</td>
</tr>
<tr>
<td>Sdk.RetrieveRecordWall.js</td>
<td>Sdk.RetrieveRequiredComponents.js</td>
</tr>
<tr>
<td>Sdk.RetrieveRolePrivilegesRole.js</td>
<td>Sdk.RetrieveSharedPrincipalsAndAccess.js</td>
</tr>
<tr>
<td>Sdk.RetrieveSubGroupsResourceGroup.js</td>
<td>Sdk.RetrieveTeamPrivileges.js</td>
</tr>
<tr>
<td>Sdk.RetrieveTimestamp.js</td>
<td>Sdk.RetrieveUnpublished.js</td>
</tr>
<tr>
<td>Sdk.RetrieveUserPrivileges.js</td>
<td>Sdk.RetrieveVersion.js</td>
</tr>
<tr>
<td>Sdk.ReviseQuote.js</td>
<td>Sdk.RevokeAccess.js</td>
</tr>
<tr>
<td>Sdk.Rollup.js</td>
<td>Sdk.Search.js</td>
</tr>
<tr>
<td>Sdk.SearchByBodyKbArticle.js</td>
<td>Sdk.SearchByKeywordsKbArticle.js</td>
</tr>
<tr>
<td>Sdk.SearchByTitleKbArticle.js</td>
<td>Sdk.SendBulkMail.js</td>
</tr>
<tr>
<td>Sdk.SendEmail.js</td>
<td>Sdk.SendEmailFromTemplate.js</td>
</tr>
<tr>
<td>Sdk.SendFax.js</td>
<td>Sdk.SendTemplate.js</td>
</tr>
<tr>
<td>Sdk.SetBusinessEquipment.js</td>
<td>Sdk.SetBusinessSystemUser.js</td>
</tr>
<tr>
<td>Sdk.SetDataEncryptionKey.js</td>
<td>Sdk.SetParentBusinessUnit.js</td>
</tr>
<tr>
<td>Sdk.SetParentSystemUser.js</td>
<td>Sdk.SetParentTeam.js</td>
</tr>
<tr>
<td>Sdk.SetReportRelated.js</td>
<td>Sdk.SetState.js</td>
</tr>
<tr>
<td>Sdk.TransformImport.js</td>
<td>Sdk.TriggerServiceEndpointCheck.js</td>
</tr>
<tr>
<td>Sdk.UninstallSampleData.js</td>
<td>Sdk.UnlockInvoicePricing.js</td>
</tr>
<tr>
<td>Sdk.UnlockSalesOrderPricing.js</td>
<td>Sdk.UnpublishDuplicateRule.js</td>
</tr>
<tr>
<td>Sdk.Update.js</td>
<td>Sdk.UtcTimeFromLocalTime.js</td>
</tr>
<tr>
<td>Sdk.Validate.js</td>
<td>Sdk.ValidateRecurrenceRule.js</td>
</tr>
<tr>
<td>Sdk.ValidateSavedQuery.js</td>
<td>Sdk.WhoAmI.js</td>
</tr>
<tr>
<td>Sdk.WinOpportunity.js</td>
<td>Sdk.WinQuote.js</td>
</tr>
</tbody>
</table>
<p>These message libraries were generated using code based on the data in entities in Microsoft Dynamics CRM. These don&rsquo;t represent all the messages available. Certain messages were not included based on the following criteria:</p>
<ul>
<li>Message documented as internal use only </li><li>Deprecated messages </li><li>Messages used to create or edit metadata </li><li>Messages to retrieve metadata other than <a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.messages.retrievemetadatachangesrequest(v=crm.6).aspx" target="_blank">
RetrieveMetadataChanges</a> </li></ul>
<div style="margin-left:10px; padding-left:5px; border:1px solid black">
<h3>Why is metadata treated differently?</h3>
<p>Creating a library to replace application functionality to create or edit entities, attributes, or entity relationships was out of scope.</p>
<p>Messages like <strong>RetrieveAllEntities</strong>, <strong>RetrieveEntity</strong>,
<strong>RetrieveAttributes</strong>, and so on perform poorly and are inefficient.
<strong>RetrieveMetadataChanges</strong> provides a more robust means to define queries for metadata and returns only required metadata.</p>
<p>Metadata objects returned via <strong>RetrieveMetadataChanges</strong> are simple JavaScript objects without get/set methods on the properties. They are read-only.</p>
</div>
<p>All message libraries include classes that inherit from a base <strong>Sdk.OrganizationRequest</strong> class that includes much of the functionality to make these requests work. Each of these libraries includes a
<strong>Request</strong> and <strong>Response</strong> class for each message.</p>
<p><strong>Note</strong>: Not every one of these messages has been tested. Each of them matches a known pattern with known data types. Because each of the data types is known and can be serialized into the XML needed to create the request and to parse the response,
 they all should work. But full testing of each message was out of scope for this sample. If you find a message that doesn&rsquo;t work as you expect, please report it.</p>
<p>Some libraries contain additional supporting classes used only for that message. For example,
<strong>Sdk.RetrieveMetadataChanges.js</strong> contains classes found in the<a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.metadata.query(v=crm.6).aspx" target="_blank"> Microsoft.Xrm.Sdk.Metadata.Query</a> namespace that support this message.
<strong>Sdk.Search.js</strong> also contains classes used only by that message.</p>
<h3>Minimizing messages</h3>
<p>The messages provided in the Sdk.Soap.js project contain comments to support design-time IntelliSense. Although most of these files are already rather small (186 of them are 10Kb or below), you can still minimize them to make them smaller. Minimized versions
 of these libraries aren&rsquo;t provided in the Sdk.Soap.js project.</p>
<h1 id="actions">Use actions</h1>
<p>Actions were introduced in Microsoft Dynamics CRM 2013. An action is essentially a workflow that you can define to generate a custom message. Actions can only be executed in code.</p>
<p>The <a href="http://code.msdn.microsoft.com/SdkSoapjs-Action-Message-971be943" target="_blank">
Sdk.Soap.js Action Message Generator </a>project includes an application you can use to generate JavaScript libraries for any custom actions in your organization. Use these libraries just as you would use the libraries for messages.</p>
<h1 id="query">Query Data</h1>
<p>The Sdk.Soap.js library supports the three main query styles used with retrieve operations:</p>
<ul>
<li><a href="http://msdn.microsoft.com/en-us/library/gg328259(v=crm.6).aspx" target="_blank">QueryByAttribute</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/gg328332(v=crm.6).aspx" target="_blank">FetchExpression</a>
</li><li><a href="http://msdn.microsoft.com/en-us/library/gg334688(v=crm.6).aspx" target="_blank">QueryExpression</a>
</li></ul>
<p>The objects used to define these queries are found in the <strong>Sdk.Query</strong> namespace. Each of these classes inherits from an
<strong>Sdk.QueryBase</strong> class so each of them is valid to use as a property for an
<strong>Sdk.RetrieveMultipleRequest</strong> or as a parameter to the <strong>retrieveMultiple</strong> method.</p>
<p>Use these classes in a manner similar to the way you use them in managed code However, since JavaScript can&rsquo;t detect types at runtime, you must use the appropriate class in this namespace to explicitly state the type of object when setting the criteria
 for <strong>Sdk.Query.QueryByAttribute</strong> or <strong>Sdk.Query.QueryExpression</strong>.</p>
<p>The classes listed in the following table inherit from <strong>Sdk.Query.ValueBase</strong>.</p>
<table>
<tbody>
<tr>
<td>Sdk.Query.Booleans</td>
<td>Sdk.Query.BooleanManagedProperties</td>
<td>Sdk.Query.Dates</td>
</tr>
<tr>
<td>Sdk.Query.Decimals</td>
<td>Sdk.Query.Doubles</td>
<td>Sdk.Query.EntityReferences</td>
</tr>
<tr>
<td>Sdk.Query.Guids</td>
<td>Sdk.Query.Ints</td>
<td>Sdk.Query.Longs</td>
</tr>
<tr>
<td>Sdk.Query.Money</td>
<td>Sdk.Query.OptionSets</td>
<td>Sdk.Query.Strings</td>
</tr>
</tbody>
</table>
<p><strong>Sdk.Query.FetchExpression </strong>simply requires a string representing the XML for the query. No object model is provided to compose a FetchXML string programmatically. Use
<strong>Sdk.Query.QueryExpression</strong> if you want to do this.</p>
<h1 id="collection">Use the Sdk.Collection class</h1>
<p>The Sdk.Collection class is re-used throughout Sdk.Soap.js. It manages an array of a type set when it is instantiated based on a function set as the type parameter. Any time a new object is added to the collection, it&rsquo;s checked to ensure all objects
 in the collection are the same type or inherit from the same type.</p>
<p>Sdk.Collection is used instead of a typed Array used in several CRM object properties.</p>
<p>Sdk.Collection also provides a consistent interface to work with collections. The Sdk.Collection class exposes the following methods:</p>
<ul>
<li><strong>getType</strong> : Gets the type defined for the collection. </li><li><strong>add</strong>: Adds an item to the collection. </li><li><strong>addRange</strong>: Adds an array of objects to the collection. </li><li><strong>clear</strong>: Removes all items from the collection. </li><li><strong>contains</strong>: Returns whether an object exists within the collection.
</li><li><strong>forEach</strong>: Applies the action contained within a delegate function.
</li><li><strong>getByIndex</strong>: Gets the item in the collection at the specified index.
</li><li><strong>remove</strong>: Removes an item from the collection. </li><li><strong>toArray</strong>: Gets a copy of the array of items in the collection.
</li><li><strong>getCount</strong>: Returns the number of items in the collection. </li></ul>
<h1 id="design">Design notes</h1>
<p>Sdk.Soap.js was written using &ldquo;plain old JavaScript&rdquo; rather than some of the other technologies used to build large libraries such as
<a href="http://www.typescriptlang.org/" target="_blank">TypeScript</a> and <a href="http://scriptsharp.com/" target="_blank">
Script#</a>. These technologies have great advantages for maintaining a code base, automated testing, and compile time errors, but the goal of this project was to not require a developer to learn those technologies in order to use the library.</p>
<p>Every operation that uses the Microsoft Dynamics CRM Modern App SOAP endpoint is essentially just serializing objects into a known XML schema and passing that XML as a request and then parsing the XML returned in the response back into JavaScript objects.
 Because JavaScript is not a strongly typed language, classes needed to be defined as functions to ensure the integrity of each object so that it can be serialized and parsed consistently.</p>
<p>In order to reduce the opportunity for errors to be introduced by developers using the library, every object property or method parameter is carefully type checked. This library also needs to support every browser supported by Microsoft Dynamics CRM, which
 at this time includes Internet Explorer 8. Internet Explorer 8 standard mode supports the
<a href="http://msdn.microsoft.com/en-us/library/ie/dd548687(v=vs.94).aspx" target="_blank">
Object.defineProperty Function (JavaScript)</a> only for DOM objects but not user-defined objects. This function is key in creating properties with internal get/set functions that can ensure the type when assigning a value to a property. Without this capability,
 this library uses explicit getValue/setValue functions for each property, just as the Xrm.Page form scripting object does.</p>
<h2>Managing XML namespaces</h2>
<p>The patterns used in this library were inferred by using the SOAPLogger sample application in the SDK. One thing that became clear immediately is that the XML namespaces assigned by the application depended on the particular set of objects being serialized.
 Because XPath expressions were used to parse the values returned and consistent namespace aliases needed to be set when composing the XML to include in the request, it was necessary to define a set of specific alias values to use when composing the XML and
 to explicitly set namespace alias values when parsing the XML returned in responses.</p>
<p>Within the Sdk.Xml namespace there is an ns property used to set an appropriate alias for each of the schemas.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden"> var ns = {
  &quot;s&quot;: &quot;http://schemas.xmlsoap.org/soap/envelope/&quot;,
  &quot;a&quot;: &quot;http://schemas.microsoft.com/xrm/2011/Contracts&quot;,
  &quot;i&quot;: &quot;http://www.w3.org/2001/XMLSchema-instance&quot;,
  &quot;b&quot;: &quot;http://schemas.datacontract.org/2004/07/System.Collections.Generic&quot;,
  &quot;c&quot;: &quot;http://www.w3.org/2001/XMLSchema&quot;,
  &quot;d&quot;: &quot;http://schemas.microsoft.com/xrm/2011/Contracts/Services&quot;,
  &quot;e&quot;: &quot;http://schemas.microsoft.com/2003/10/Serialization/&quot;,
  &quot;f&quot;: &quot;http://schemas.microsoft.com/2003/10/Serialization/Arrays&quot;,
  &quot;g&quot;: &quot;http://schemas.microsoft.com/crm/2011/Contracts&quot;,
  &quot;h&quot;: &quot;http://schemas.microsoft.com/xrm/2011/Metadata&quot;,
  &quot;j&quot;: &quot;http://schemas.microsoft.com/xrm/2011/Metadata/Query&quot;,
  &quot;k&quot;: &quot;http://schemas.microsoft.com/xrm/2013/Metadata&quot;,
  &quot;l&quot;: &quot;http://schemas.microsoft.com/xrm/2012/Contracts&quot;
 };
</pre>
<div class="preview">
<pre class="js">&nbsp;<span class="js__statement">var</span>&nbsp;ns&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;s&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;a&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2011/Contracts&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;i&quot;</span>:&nbsp;<span class="js__string">&quot;http://www.w3.org/2001/XMLSchema-instance&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;b&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.datacontract.org/2004/07/System.Collections.Generic&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;c&quot;</span>:&nbsp;<span class="js__string">&quot;http://www.w3.org/2001/XMLSchema&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;d&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2011/Contracts/Services&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;e&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/2003/10/Serialization/&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;f&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/2003/10/Serialization/Arrays&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;g&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/crm/2011/Contracts&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;h&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2011/Metadata&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;j&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2011/Metadata/Query&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;k&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2013/Metadata&quot;</span>,&nbsp;
&nbsp;&nbsp;<span class="js__string">&quot;l&quot;</span>:&nbsp;<span class="js__string">&quot;http://schemas.microsoft.com/xrm/2012/Contracts&quot;</span>&nbsp;
&nbsp;<span class="js__brace">}</span>;&nbsp;</pre>
</div>
</div>
</div>
<p>These alias values were added as each schema was encountered in the development process and don&rsquo;t represent any kind of standard alias value for other purposes.</p>
<h1 id="issues">Known issues</h1>
<ul>
<li>The <strong>Sdk.Long </strong>data type returns a JavaScript Number value. There is no JavaScript equivalent to the SQL BigInt or .NET Long data type. As a result, conversion of a value returned from CRM using
<a href="http://msdn.microsoft.com/en-us/library/ie/d5hbbd4z(v=vs.94).aspx" target="_blank">
ParseFloat</a> to represent a Long value may have some loss of precision.
<ul>
<li>For example, a value of 8246295522085275215 will become 8246295522085276000. </li><li>Fortunately this type is not frequently used in Microsoft Dynamics CRM. A future version of this library may simply return the value as a string.
</li></ul>
</li><li>
<p><strong>Sdk is not defined error</strong>.</p>
<p>This issue is described in the Microsoft CRM SDK topic <a href="https://msdn.microsoft.com/en-us/library/gg328261.aspx#BKMK_ManageLibraryDependencies">
Write code for Microsoft Dynamics CRM forms: Manage library dependencies</a> but is summarized below in the context of Sdk.Soap.js.</p>
<p>JavaScript web resources in used in the&nbsp; Microsoft CRM applicaiton are not loaded sequentially. They are loaded asynchronously and in parallel, which means they don't wait for the library before them to finish loading before the next library starts
 to load. This is the case when scripts are used in forms or ribbons. When used in HTML web resources they will load sequentially in the order they are listed in the head of the page.</p>
<p>This can be a problem for libraries which have dependencies on objects instantiated by other libraries. For example, jQueryUI depends on a jQuery instance. The same is true when using Sdk.Soap.js with script loaded in other libraries. Sdk.Soap.js is a larger
 library and it is likely that it will not be fully instantiated before another library that start loading after it. The result is the Sdk is not defined error.</p>
<p>There are a couple of ways to mitigate this:</p>
<ul>
<li>The simplest way is to simply append the content of any messages or custom action scripts to the bottom of the Sdk.Soap.js library. The library will be loaded in order from top to bottom and the Sdk object will be fully instantiated by the time it gets
 to the content of the message or custom actions scripts. </li><li>A more sophisticated approach is to use third party libraries like <a href="http://headjs.com/" target="_blank">
head.js</a> or <a href="http://requirejs.org/" target="_blank">require.js</a> to take control over how the libraries get loaded.
</li></ul>
</li><li>
<p>This library is based on Microsoft Dynamics CRM 2013. When requests are sent the
<strong>Sdk.Xml.getEnvelopeHeader</strong> function specifies an <a href="http://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.client.organizationserviceproxy.sdkclientversion(v=crm.6).aspx" target="_blank">
SdkClientVersion</a> value of 6.0 in the following code:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">this.getEnvelopeHeader = function () {
  var _envelopeHeader = [&quot;&lt;s:Envelope &quot;];
  for (var i in ns) {
   _envelopeHeader.push(&quot; xmlns:&quot; &#43; i &#43; &quot;=\&quot;&quot; &#43; ns[i] &#43; &quot;\&quot;&quot;)
  }
_envelopeHeader.push(&quot;&gt;&lt;s:Header&gt;&lt;a:SdkClientVersion&gt;6.0&lt;/a:SdkClientVersion&gt;&lt;/s:Header&gt;&quot;);
  return _envelopeHeader.join(&quot;&quot;);
};
</pre>
<div class="preview">
<pre class="js"><span class="js__operator">this</span>.getEnvelopeHeader&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;_envelopeHeader&nbsp;=&nbsp;[<span class="js__string">&quot;&lt;s:Envelope&nbsp;&quot;</span>];&nbsp;
&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;<span class="js__operator">in</span>&nbsp;ns)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;_envelopeHeader.push(<span class="js__string">&quot;&nbsp;xmlns:&quot;</span>&nbsp;&#43;&nbsp;i&nbsp;&#43;&nbsp;<span class="js__string">&quot;=\&quot;&quot;</span>&nbsp;&#43;&nbsp;ns[i]&nbsp;&#43;&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
_envelopeHeader.push(<span class="js__string">&quot;&gt;&lt;s:Header&gt;&lt;a:SdkClientVersion&gt;6.0&lt;/a:SdkClientVersion&gt;&lt;/s:Header&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_envelopeHeader.join(<span class="js__string">&quot;&quot;</span>);&nbsp;
<span class="js__brace">}</span>;&nbsp;</pre>
</div>
</div>
</div>
<p>For this library to retrieve metadata in later versions, the value must be updated to reflect the current version.</p>
</li></ul>
