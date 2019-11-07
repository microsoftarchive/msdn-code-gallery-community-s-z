# Work with Microsoft Dynamics 365 and Azure Integration
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Microsoft Azure
- Microsoft Dynamics CRM
- Dynamics 365 Customer Engagement
## Topics
- Microsoft Azure
- library assembly
- Microsoft Dynamics CRM SDK
## Updated
- 06/19/2018
## Description

<h1>Work with Microsoft Dynamics 365 and Azure Integration</h1>
<p>Applies To: Dynamics 365 (online), Dynamics 365 (on-premises), Dynamics CRM 2016, Dynamics CRM Online</p>
<p>This section contains sample code for integrating Microsoft Dynamics 365 and Microsoft Azure through the Microsoft Azure Service Bus.</p>
<h2>Requirements</h2>
<p>For more information about the requirements for running the sample code, see <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/org-service/use-sample-helper-code">
Use the sample and helper code</a>.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<h2>Azure aware custom plug-in</h2>
<p>This is a sample custom plug-in that can post the pipeline execution context to the Microsoft Azure Service Bus.</p>
<p>The plug-in demonstrates how to obtain the execution context and the tracing service from the service provider parameter of the Execute method. The plug-in then posts the context to the Microsoft Azure Service Bus endpoint and writes information to the trace
 log to facilitate debugging.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=2128679881">
SandboxPlugin.cs</a> sample file.<strong>&nbsp;</strong><em>&nbsp;</em><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-azure-aware-custom-plugin">
Sample: Azure aware custom plug-in</a> and <a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-custom-azure-aware-plugin">
Write a custom Azure-aware plug-in</a> <strong></strong><em></em></p>
<h2>Azure aware custom workflow activity</h2>
<p>This sample obtains the data context from the current Microsoft Dynamics 365 operation and posts it to the Microsoft Azure Service Bus.</p>
<p>This sample shows how to write a custom workflow activity that can post the data context from the current Microsoft Dynamics 365 operation to the Microsoft Azure Service Bus. The posting of the data context is done through the
<a href="https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.iserviceendpointnotificationservice.execute.aspx">
Execute method</a>.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=1656988113">
Activity.cs</a> sample file.<strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-azure-aware-custom-workflow-activity">
Sample: Azure aware custom workflow activity</a></p>
<h2>One-way listener</h2>
<p>This sample listener application registers a remote service plug-in that executes whenever a Microsoft Dynamics 365 message is posted to a one-way endpoint on the Microsoft Azure Service Bus. When the plug-in executes, it outputs to the console the contents
 of the Microsoft Dynamics 365 execution context contained in the message.</p>
<p>This sample shows how to write a Microsoft Azure Service Bus listener for a one-way endpoint contract.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=188775965">
OneWayListener.cs</a> sample file.</p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-two-way-listener">
One way listener</a> and <a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-listener-application-azure-solution">
Write a listener application for a Microsoft Azure solution</a> <strong></strong><em></em></p>
<h2>Two-way listener</h2>
<p>This sample registers a remote service plug-in that executes whenever a Microsoft Dynamics 365 message is posted to a two-way endpoint on the Microsoft Azure Service Bus. When the plug-in executes, it prints to the console the contents of the Microsoft Dynamics
 365 execution context contained in the message.</p>
<p>This sample shows how to write a Microsoft Azure Service Bus Listener for a two-way endpoint contract.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=604186481">
TwoWayListener.cs</a> sample file.</p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-two-way-listener">
Sample: Two-way listener</a>&nbsp;and <a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-listener-application-azure-solution">
Write a listener application for a Microsoft Azure solution</a> <strong></strong><em></em></p>
<h2>Rest listener</h2>
<p>This sample registers a remote service plug-in that executes whenever a Microsoft Dynamics 365 message is posted to a two-way endpoint on the Microsoft Azure Service Bus. When the plug-in executes, it prints to the console the contents of the Microsoft Dynamics
 365 execution context contained in the message.</p>
<h4>Requirements</h4>
<p>You must configure Microsoft Dynamics 365 integration with Microsoft Azure prior to registering and executing this sample activity.</p>
<h4>Demonstrates</h4>
<p>This sample shows how to write a Microsoft Azure Service Bus Listener for a REST endpoint contract.</p>
<p>This sample registers a remote service plug-in that executes whenever a Microsoft Dynamics 365 message is posted to a REST endpoint on the service bus. When the plug-in executes, it prints to the console the contents of the Microsoft Dynamics 365 execution
 context contained in the message.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=504898101">
RestListener.cs </a>sample file.</p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-rest-listener">
REST listener</a>&nbsp;and <a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-listener-application-azure-solution">
Write a listener application for a Microsoft Azure solution</a> <strong></strong><em></em></p>
<h2>Persistent queue listener</h2>
<p>This sample registers a remote service plug-in that executes whenever a Microsoft Dynamics 365 message is posted to a two-way endpoint on the Microsoft Azure Service Bus. When the plug-in executes, it prints to the console the contents of the Microsoft Dynamics
 365 execution context contained in the message.</p>
<h4>Requirements</h4>
<p>This sample code requires the following additional Microsoft Visual Studio project reference: Microsoft.ServiceBus. The Microsoft.ServiceBus.dll assembly can be found in the
<a href="https://azure.microsoft.com/en-us/downloads/archive-net-downloads/">Microsoft Azure SDK</a>.</p>
<h4>Demonstrates</h4>
<p>This sample shows how to write a Microsoft Azure Service Bus listener application for a persistent queue endpoint contract.</p>
<p>The listener waits for a Microsoft Dynamics 365 message to be posted to the service bus and to be available in the endpoint queue. When a message is available in the queue, the listener reads the message, prints the Microsoft Dynamics 365 execution context
 contained in the message to the console, and deletes the message from the queue.</p>
<p>Click to see the <a href="https://code.msdn.microsoft.com/Sample-Dynamics-365-and-6a95df2a/sourcecode?fileId=179917&pathId=852823244">
PersistentQueueListener.cs</a> sample file.</p>
<p>More Information: <a href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/sample-persistent-queue-listener">
Persistent queue listener</a>&nbsp;and <a class="selected" tabindex="0" href="https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/write-listener-application-azure-solution">
Write a listener application for a Microsoft Azure solution</a> <strong></strong><em></em></p>
