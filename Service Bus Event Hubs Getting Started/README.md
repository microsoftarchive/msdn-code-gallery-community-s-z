# Service Bus Event Hubs Getting Started
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
## Topics
- Service Bus
- service
## Updated
- 01/07/2016
## Description

<h1>Introduction</h1>
<p class="MsoNormal">Event Hubs feature in Service Bus enables developers to build rich data applications that require ingesting event streams at very high throughput and low latency. The ingested events are stored durably until the required retention period
 expires. Some of the typical types of applications that require high throughput event ingestion are log analytics systems for monitoring, billing and commerce services, and Internet of Things (IoT) scenarios that involve large numbers of devices publishing
 event streams.</p>
<p class="MsoNormal">Events are partitioned based on a system property called <strong>
PartitionKey,</strong> and sent to the Event Hub using an <strong>EventhubClient</strong> object. Consuming applications can then process the events from each of the partitions of the Event Hub. Events within a partition are delivered to the consumer in order.
 In an Event Hub, you can create one consumer group per consuming application. An example of a scenario in which multiple consumer groups are created is batch processing and real time processing of the same event stream.</p>
<p class="MsoNormal">Typically, applications that consume events must distribute the partitions among several workers for load balancing, as well as for fault handling. Building such distributed applications is not trivial. For this purpose, the
<strong>EventHub</strong> client ships with an out-of-box solution for partition distribution using the
<strong>EventProcessorHost</strong> SDK. <strong>EventprocessorHost</strong> distributes the partitions among the workers uniformly, and load balances the partitions as the workers encounter errors or go down.</p>
<p class="MsoNormal">&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample demonstrates the basic capabilities of Event Hub&nbsp;like - Create an Event Hub, Send events to Event hub, Consume events using EventProcessor.</p>
<p>Refer to Event Hub Developer guide for detailed API documentation&nbsp;<span style="color:#1f497d; font-family:&quot;Calibri&quot;,sans-serif; font-size:11pt"><a href="https://azure.microsoft.com/documentation/articles/event-hubs-ingest-telemetry-and-application-events/"><span style="color:#0563c1">https://azure.microsoft.com/documentation/articles/event-hubs-ingest-telemetry-and-application-events/</span></a></span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Create&nbsp;EventHub&nbsp;:&nbsp;
&nbsp;
var&nbsp;ehd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHubDescription(eventHubName);&nbsp;
ehd.PartitionCount&nbsp;=&nbsp;numberOfPartitions;&nbsp;
manager.CreateEventHubIfNotExistsAsync(ehd).Wait();&nbsp;
&nbsp;
Sent&nbsp;Events:&nbsp;
&nbsp;
EventData&nbsp;data&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventData(bytes)&nbsp;
data.PartitionKey&nbsp;=&nbsp;info.DeviceId.ToString();&nbsp;
await&nbsp;client.SendAsync(data);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
