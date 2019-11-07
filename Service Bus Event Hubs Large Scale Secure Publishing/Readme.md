# Service Bus Event Hubs Large Scale Secure Publishing
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
## Topics
- Service Bus
- Windows Azure Service Bus
- Internet of Things
- IoT
- Event Hub
- Event Hub Publisher
- Event Hubs
- Windows Azure Event Hubs
- Event Hubs Publisher Policy
## Updated
- 02/11/2016
## Description

<h1>Introduction</h1>
<p><em>Event Hubs enable developers to build </em>Distributed Applications<em>, which requires durable collection of event streams at very high throughput, low latency and from variety of sources like devices and services. One of the most important scenarios
 it enables is - IoT, where millions of devices tries to publish event streams and different types of consumers processes these events. At this Scale, there is an eminent need to be able to Authorize and Identify per device basis.
</em></p>
<p><em>&quot;Large Scale Publishing to Event Hubs&quot; enables this unique scenario of being able to send from devices at a Million scale in a secure way - by introducing the notion of</em> Publisher<em>. A
</em>Publisher<em> is a logical construct for sending messages into an Event Hub. Each publisher provides a unique endpoint that lives within an Event Hub, to which you can send messages. The only way to
</em>Create<em> a publisher is to send a message to it.</em></p>
<p><em><em>&quot;Large Scale Publishing to Event Hubs&quot; enables powerfull scenarios like - rejecting data from comprimised devices, i</em>f the devices (or publishers) are grouped by
</em>Trust Levels<em>, and if a unique SaS key is assigned per trust level.</em></p>
<p><em><a href="http://blogs.msdn.com/b/servicebus/archive/2015/02/02/event-hub-publisher-policy-in-action.aspx">Dan's blog</a> is an excellent starting point for Publisher Policy using .net API's.
</em></p>
<p><em>The current sample focus'es more on the Rest APIs - which enables powerful scenarios - like sending msgs from devices.&nbsp;<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample demonstrates: </em></p>
<p><em>1. Sending messages to multiple publishers in an Event Hub using the REST<br>
</em></p>
<ul>
<li><em>Creates a SAS Token per Publisher Endpoint using the Entity level SAS Rule and Uses the resource Url as &lt;EventHubName&gt;/Publishers/&lt;DeviceId&gt;<br>
</em></li><li><em>Sends the message to the publisher endpoint - </em><em>&lt;EventHubName&gt;/Publishers/&lt;DeviceId&gt;</em>
</li></ul>
<p>Since the Resource Url in the generated SAS Token matches with the Url to which the message is sent to, this Send operation will be Authorized.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">string token1 = CreateSasToken(eventHubAddress &#43; &quot;/publishers/dev-01&quot;, devicesSendKeyName, primaryDeviceKey);
HttpClientHelper deviceHttpClientHelper1 = new HttpClientHelper(eventHubAddress &#43; &quot;/publishers/dev-01&quot;, token1);
deviceHttpClientHelper1.SendMessage(messageBody1);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;token1&nbsp;=&nbsp;CreateSasToken(eventHubAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/publishers/dev-01&quot;</span>,&nbsp;devicesSendKeyName,&nbsp;primaryDeviceKey);&nbsp;
HttpClientHelper&nbsp;deviceHttpClientHelper1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClientHelper(eventHubAddress&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/publishers/dev-01&quot;</span>,&nbsp;token1);&nbsp;
deviceHttpClientHelper1.SendMessage(messageBody1);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>2. Consuming all messages sent from one Publisher at a PartitionID.</em></div>
