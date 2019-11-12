# Working with Azure Scheduler using .Net SDK
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Azure
## Topics
- Azure Scheduler
## Updated
- 11/04/2014
## Description

<h1>Introduction</h1>
<h2>Create jobs that run on your schedule</h2>
<p>Azure Scheduler lets you create jobs in the cloud that reliably invoke services inside and outside of Azure&mdash;such as calling HTTP/S endpoints or posting messages to Azure Storage queues. You can choose to run jobs right away, on a recurring schedule,
 or at some point in the future.</p>
<h2>Ideal for recurring actions, daily maintenance, developers</h2>
<p>Azure Scheduler is great for recurring actions&mdash;for example, periodically gathering data from Twitter into a feed. It&rsquo;s also ideal for cleaning up logs, kicking off routine backups, and other application maintenance tasks. Developers can also
 integrate Scheduler into their applications.</p>
<h2>Designed for high availability, reliability</h2>
<p>Scheduler is designed to operate even in the face of network, machine, and datacenter failures, so your scheduled jobs continue to execute on time. It can automatically switch to an alternative datacenter in the same region if needed. Users can also configure
 alternate endpoints, in case their main endpoint becomes unavailable.</p>
<h2>Create asynchronous jobs using queues</h2>
<p>Scheduler can also post messages to <a href="http://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-queues/">
Azure Storage queues</a> for asynchronous processing of recurring requests. This is useful for complex or long-running requests&mdash;such as a series of SQL queries against a large database&mdash;and when you want to invoke a service that&rsquo;s offline</p>
<p>&nbsp;</p>
<p>&nbsp;Before Starting Sample Creation , We need Azure Certificate for given Subcription. Use below steps to get that:</p>
<p>Have a Subscription ready.</p>
<p>Open Azure Powershell and excute below commands:</p>
<ul>
<li>
<p>The <strong>Get-AzurePublishSettingsFile</strong> cmdlet opens a web page on the Azure Management Portal, from which you can download the subscription information. The information is contained in a .publishsettings file.</p>
</li><li>
<p>The <strong>Import-AzurePublishSettingsFile</strong> imports the .publishsettings file for use by the module. This file includes a management certificate that has security credentials.&nbsp;</p>
</li></ul>
<p>Once done retrive ThumbPrint from Management Portal like below:</p>
<p><img id="128186" src="128186-azurecertificate.jpg" alt="" width="924" height="189"></p>
<p><em>&nbsp; &nbsp;</em></p>
<p>Now Create C# Console Application and Add below Package for Azure Scheduler:</p>
<p>&gt;install-package&nbsp;Microsoft.WindowsAzure.Management.Scheduler.</p>
<p>Then add below code &nbsp;and references:</p>
<p>using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Security.Cryptography.X509Certificates.aspx" target="_blank" title="Auto generated link to System.Security.Cryptography.X509Certificates">System.Security.Cryptography.X509Certificates</a>;using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure">Microsoft.WindowsAzure</a>;</p>
<p>using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.Management.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure.Management">Microsoft.WindowsAzure.Management</a>;using Microsoft.WindowsAzure.Scheduler;</p>
<p>using Microsoft.WindowsAzure.Scheduler.Models;using Microsoft.WindowsAzure.Management.Scheduler;</p>
<p>using <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.WindowsAzure.Common.Internals.aspx" target="_blank" title="Auto generated link to Microsoft.WindowsAzure.Common.Internals">Microsoft.WindowsAzure.Common.Internals</a>;using Microsoft.WindowsAzure.Management.Scheduler.Models;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;store&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;X509Store(StoreName.My,&nbsp;StoreLocation.CurrentUser);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;store.Open(OpenFlags.ReadWrite);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;certificate&nbsp;=&nbsp;store.Certificates.Find(X509FindType.FindByThumbprint,&nbsp;<span class="cs__string">&quot;&lt;ThumbPrint&gt;&quot;</span>,&nbsp;<span class="cs__keyword">false</span>)[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;store.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;management&nbsp;credencials&nbsp;and&nbsp;cloud&nbsp;service&nbsp;management&nbsp;client</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CertificateCloudCredentials(<span class="cs__string">&quot;8cb918af-59d0-4b24-893c-15661d048f16&quot;</span>,&nbsp;certificate);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cloudServiceMgmCli&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CloudServiceManagementClient(credentials);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;cloud&nbsp;service</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cloudServiceCreateParameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CloudServiceCreateParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;schedulerdemo1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Email&nbsp;=&nbsp;<span class="cs__string">&quot;microsoft.com&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GeoRegion&nbsp;=&nbsp;<span class="cs__string">&quot;Southeast&nbsp;Asia&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;<span class="cs__string">&quot;schedulerdemo1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cloudService&nbsp;=&nbsp;cloudServiceMgmCli.CloudServices.Create(<span class="cs__string">&quot;schedulerdemo1&quot;</span>,&nbsp;cloudServiceCreateParameters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;job&nbsp;collection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;schedulerMgmCli&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SchedulerManagementClient(credentials);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobCollectionIntrinsicSettings&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobCollectionIntrinsicSettings()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Plan&nbsp;=&nbsp;JobCollectionPlan.Free,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Quota&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobCollectionQuota()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxJobCount&nbsp;=&nbsp;<span class="cs__number">5</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxJobOccurrence&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxRecurrence&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobCollectionMaxRecurrence()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Frequency&nbsp;=&nbsp;JobCollectionRecurrenceFrequency.Hour,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Interval&nbsp;=&nbsp;<span class="cs__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobCollectionCreateParameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobCollectionCreateParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IntrinsicSettings&nbsp;=&nbsp;jobCollectionIntrinsicSettings,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label&nbsp;=&nbsp;<span class="cs__string">&quot;jc1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobCollectionCreateResponse&nbsp;=&nbsp;schedulerMgmCli.JobCollections.Create(<span class="cs__string">&quot;schedulerdemo1&quot;</span>,&nbsp;<span class="cs__string">&quot;jc1&quot;</span>,&nbsp;jobCollectionCreateParameters);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;schedulerClient&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SchedulerClient(<span class="cs__string">&quot;schedulerdemo1&quot;</span>,&nbsp;<span class="cs__string">&quot;jc1&quot;</span>,&nbsp;credentials);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobAction&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobAction()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;=&nbsp;JobActionType.Http,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Request&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobHttpRequest()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;http://blog.shaunxu.me&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Method&nbsp;=&nbsp;<span class="cs__string">&quot;GET&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobRecurrence&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobRecurrence()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Frequency&nbsp;=&nbsp;JobRecurrenceFrequency.Hour,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Interval&nbsp;=&nbsp;<span class="cs__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobCreateOrUpdateParameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobCreateOrUpdateParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Action&nbsp;=&nbsp;jobAction,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Recurrence&nbsp;=&nbsp;jobRecurrence&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobCreateResponse&nbsp;=&nbsp;schedulerClient.Jobs.CreateOrUpdate(<span class="cs__string">&quot;poll_blog&quot;</span>,&nbsp;jobCreateOrUpdateParameters);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;jobGetHistoryParameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JobGetHistoryParameters()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Skip&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Top&nbsp;=&nbsp;<span class="cs__number">100</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;history&nbsp;=&nbsp;schedulerClient.Jobs.GetHistory(<span class="cs__string">&quot;poll_blog&quot;</span>,&nbsp;jobGetHistoryParameters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;action&nbsp;<span class="cs__keyword">in</span>&nbsp;history)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}\t{1}\t{2}\t{3}\t{4}&quot;</span>,&nbsp;action.Status,&nbsp;action.Message,&nbsp;action.RetryCount,&nbsp;action.RepeatCount,&nbsp;action.Timestamp);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Verify Results in Management Portal:</span></h1>
<p><span><img id="128188" src="128188-schedulerresults.jpg" alt=""></span></p>
<p>&nbsp;</p>
<p><span style="font-size:medium">Done!</span></p>
