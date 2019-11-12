# Using Shared Access Signature (SAS) authentication with ServiceBus Subscriptions
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
## Topics
- Security
- Service Bus
- Windows Azure Service Bus
## Updated
- 06/28/2013
## Description

<h1>Using Shared Access Signature (SAS) authentication with Service Bus Subscriptions</h1>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;">Shared Access Signature (SAS) authentication allows applications to authenticate to Windows Azure Service
 Bus using an access key configured on the namespace or the entity with specific rights associated with it. This key can then be used to generate a Shared Access Signature token that clients can use to authenticate to Service Bus.</span></span></div>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium">Authorization rules for SAS can be configured on a Service Bus namespace or a queue, topic, relay or notification hub. Configuration of authorization rules for SAS on
 subscriptions is currently not supported. However, you can use an access key configured on a namespace or a topic to generate SAS tokens that are scoped to a subscription. Since the token is scoped to a subscription, it can be shared with clients whose access
 needs to be limited to a given subscription only.</span></div>
<div><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium">For more details on using SAS authentication, please see:</span></div>
<ul>
<li><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><a href="http://msdn.microsoft.com/en-us/library/dn170477.aspx">Shared Access Signature Authentication with Service Bus</a></span>
</li><li><span style="line-height:107%; font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:medium"><a href="http://msdn.microsoft.com/en-us/library/dn205161.aspx" target="_blank">How to use Shared Access Signature Authentication with Service Bus</a></span>
</li></ul>
<h2>Prerequisites for using this sample:</h2>
<div>
<li style="padding-left:30px"><span style="font-size:small">A valid subscription to Windows Azure is required.</span>
</li></div>
<h2><span>Building this sample:</span></h2>
<ul>
<li><span style="font-size:small">This sample requires Windows Azure SDK for .NET version 2.0 or later.
</span></li><li><span style="font-size:small">Install&nbsp;the <strong><em>Json.NET </em></strong>NuGet package through Visual Studio.</span>
</li><li><span style="font-size:small">Build the sample.</span> </li></ul>
<div><span style="font-size:20px; font-weight:bold">Details</span></div>
<div><span style="font-size:small">This sample&nbsp;demonstrates the use of Shared Access Signature authentication and authorization with Service Bus subscriptions. It includes:</span></div>
<ul>
<li><span style="font-size:small">Operations on the Service Bus namespace&nbsp;to create a Service Bus topic and a subscription.
</span></li><li><span style="font-size:small">Operations on the Service Bus namespace to send a message to a topic.
</span></li><li><span style="font-size:small">A class for generating SAS tokens scoped to a given URI and for a desired expiry period.
</span></li><li><span style="font-size:small">A static token provider class that can be used with a static token.
</span></li><li><span style="font-size:small">Operations on a Service Bus subscription to receive messages using a SAS token.
</span></li></ul>
<h1><em>&nbsp;</em></h1>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Code&nbsp;snippet&nbsp;for&nbsp;using&nbsp;an&nbsp;existing&nbsp;SAS&nbsp;token&nbsp;to&nbsp;access&nbsp;a&nbsp;subscription</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessagingFactory&nbsp;listenMF&nbsp;=&nbsp;MessagingFactory.Create(endpoints,&nbsp;<span class="cs__keyword">new</span>&nbsp;StaticSASTokenProvider(subscriptionToken));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SubscriptionClient&nbsp;sc&nbsp;=&nbsp;listenMF.CreateSubscriptionClient(topicPath,&nbsp;subscriptionName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BrokeredMessage&nbsp;receivedMessage&nbsp;=&nbsp;sc.Receive(TimeSpan.FromSeconds(<span class="cs__number">10</span>));</pre>
</div>
</div>
</div>
