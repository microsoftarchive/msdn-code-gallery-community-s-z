# Service Bus PowerShell Scripts
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Azure Powershell
## Topics
- Service Bus
- Provisioning
## Updated
- 03/02/2015
## Description

<h1>Introduction</h1>
<p>The zip file contains the following PowerShell scripts:</p>
<ul>
<li><strong>CreateEventHub</strong>: this script can be used to create a Service Bus namespace, an event hub and a consumer group for the newly created event hub.
</li><li><strong>CreateQueue</strong>: this script can be used to create a Service Bus namespace and a queue.
</li><li><strong>CreateTopic</strong>: this script can be used to create a Service Bus namespace and a topic.
</li><li><strong>CreateSubscription</strong>: this script can be used to a subscription for an existing topic.
</li></ul>
<p>These script can be combined to create complex scripts. For example, the following command file shows how to use the CreateTopic and CreateSubscription scripts to create a Service Bus namespace called
<strong>stockmarket</strong>, a topic called <strong>stocks</strong> and two subscriptions called, respectively,
<strong>MSFT</strong> and <strong>ORCL</strong>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="windowsshell">powershell&nbsp;.\CreateTopic.ps1&nbsp;<span class="windowsshell__commandext">-Path</span>&nbsp;stocks&nbsp;<span class="windowsshell__commandext">-Namespace</span>&nbsp;stockmarket&nbsp;<span class="windowsshell__commandext">-EnableExpress</span>&nbsp;<span class="windowsshell__number">$True</span>&nbsp;<span class="windowsshell__commandext">-EnableLargeMessages</span>&nbsp;<span class="windowsshell__number">$True</span>&nbsp;<span class="windowsshell__commandext">-EnablePartitioning</span>&nbsp;<span class="windowsshell__number">$True</span>&nbsp;<span class="windowsshell__commandext">-</span>&nbsp;
&nbsp;
MaxSizeInMegabytes&nbsp;<span class="windowsshell__number">2048</span>&nbsp;<span class="windowsshell__commandext">-UserMetadata</span>&nbsp;<span class="windowsshell__string">'This&nbsp;topic&nbsp;is&nbsp;used&nbsp;to&nbsp;process&nbsp;stock&nbsp;price&nbsp;messages.'</span>&nbsp;
powershell&nbsp;.\CreateSubscription.ps1&nbsp;<span class="windowsshell__commandext">-TopicPath</span>&nbsp;stocks&nbsp;<span class="windowsshell__commandext">-Name</span>&nbsp;MSFT&nbsp;<span class="windowsshell__commandext">-Namespace</span>&nbsp;stockmarket&nbsp;<span class="windowsshell__commandext">-DefaultMessageTimeToLive</span>&nbsp;<span class="windowsshell__number">1</span>&nbsp;<span class="windowsshell__commandext">-SqlFilter</span>&nbsp;<span class="windowsshell__string">'StockTicker='</span><span class="windowsshell__string">'MSFT'</span>''&nbsp;<span class="windowsshell__commandext">-</span>&nbsp;
&nbsp;
SqlRuleAction&nbsp;<span class="windowsshell__string">'SET&nbsp;sys.Label='</span><span class="windowsshell__string">'Stocks'</span><span class="windowsshell__string">';&nbsp;SET&nbsp;Priority='</span><span class="windowsshell__string">'High'</span>'<span class="windowsshell__string">'&nbsp;-UserMetadata&nbsp;'</span>This&nbsp;subscription&nbsp;is&nbsp;used&nbsp;to&nbsp;process&nbsp;messages&nbsp;<span class="windowsshell__command">for</span>&nbsp;the&nbsp;MSFT&nbsp;stock&nbsp;ticker'&nbsp;
powershell&nbsp;.\CreateSubscription.ps1&nbsp;<span class="windowsshell__commandext">-TopicPath</span>&nbsp;stocks&nbsp;<span class="windowsshell__commandext">-Name</span>&nbsp;ORCL&nbsp;<span class="windowsshell__commandext">-Namespace</span>&nbsp;stockmarket&nbsp;<span class="windowsshell__commandext">-DefaultMessageTimeToLive</span>&nbsp;<span class="windowsshell__number">1</span>&nbsp;<span class="windowsshell__commandext">-SqlFilter</span>&nbsp;<span class="windowsshell__string">'StockTicker='</span><span class="windowsshell__string">'ORCL'</span>''&nbsp;<span class="windowsshell__commandext">-</span>&nbsp;
&nbsp;
SqlRuleAction&nbsp;<span class="windowsshell__string">'SET&nbsp;sys.Label='</span><span class="windowsshell__string">'Stocks'</span><span class="windowsshell__string">';&nbsp;SET&nbsp;Priority='</span><span class="windowsshell__string">'Medium'</span>'<span class="windowsshell__string">'&nbsp;-UserMetadata&nbsp;'</span>This&nbsp;subscription&nbsp;is&nbsp;used&nbsp;to&nbsp;process&nbsp;messages&nbsp;<span class="windowsshell__command">for</span>&nbsp;the&nbsp;ORCL&nbsp;stock&nbsp;ticker'</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p>These scripts should be:</p>
<ul>
<li>included in the source control system (Visual Studio Online or GitHub) along with the solution and versioned as the application code
</li><li>executed as part of the Continuous Delivery process used to automatically deploy the solution to a QA environment when a new version of the application is built
</li></ul>
<p>In fact, you probably heard the term DevOps more and more times. The term remarks the need to integrate development and operations tasks to build software solutions efficiently over time. This goal can be achieved using a process in which you develop an
 application, deploy it, learn from production usage of it, change it in response to what you learn, and repeat the cycle quickly and reliably.
<br>
To achieve this result, you have to build a development and deployment cycle that is repeatable, reliable, predictable, and has low cycle time. In particular, to create the staging and production environment for an Azure application and to deploy the solution
 in an automated way and integrate this task in the Continuous integration (CI) and Continuous delivery (CD) processes, you should use parametric PowerShell scripts.&nbsp;&nbsp;&nbsp;&nbsp;</p>
<strong>&nbsp;</strong>
<p><strong>Note</strong>: Continuous integration (CI) means that whenever a developer checks in code to the source repository, a build is automatically triggered. Continuous delivery (CD) takes this one-step further: after a build and automated unit tests are
 successful, you automatically deploy the application to an environment where you can do more in-depth testing.</p>
&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">For more information on the scripts, see the articles on my blog:</div>
<div class="endscriptcode">
<ul>
<li><a href="http://blogs.msdn.com/b/paolos/archive/2014/12/01/how-to-create-a-service-bus-namespace-and-an-event-hub-using-a-powershell-script.aspx">How to create a Service Bus Namespace and an Event Hub using a PowerShell script</a>
</li><li><a href="http://blogs.msdn.com/b/paolos/archive/2014/12/02/how-to-create-a-service-bus-queues-topics-and-subscriptions-using-a-powershell-script.aspx">How to create Service Bus queues, topics and subscriptions using a PowerShell script</a>
</li></ul>
</div>
<div class="endscriptcode"></div>
