# Service Bus Event Hubs Direct Receivers
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
## Topics
- Service Bus
## Updated
- 06/05/2015
## Description

<h1>Introduction</h1>
<p>Event Hubs feature in Service Bus enables developers to build rich data applications which require very high throughput event stream ingestion.&nbsp;Eventhub client SDK has built in&nbsp;support for consuming event data from partitions in a scaled out manner
 using <strong>EventProcessorHost</strong>. While EventProcessorHost SDK with partition distribution helps consume events from Event Hubs ,it may not fit all the generic needs of consuming applications.&nbsp;There are&nbsp;consuming applications for processing
 events from non .Net clients like Storm spouts or application which have their own systems for distributed synchronization systems based on centralized services like ZooKeeper.</p>
<p>Event Hub client also provides the raw receiver API in case the user wants to&nbsp;control the partition distribution and also the control over the cursor of the stream. Using the low level receiver one can specify the offset or timestamp to start or resume
 processing. One example of having the control on the stream offset is when the consuming application fails processing and wants to rewind the stream.&nbsp;Event Hub client also takes receiver epoch as a parameter to ensure that there is only one receiver created
 per partition. Events in the Event Hub are only available until the retention period as specified in the EvenHub entity during its creation.</p>
<p>Refer to the API documentation here <span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:11pt">
<a href="http://go.microsoft.com/fwlink/?LinkId=403119"><span style="color:#0563c1">http://go.microsoft.com/fwlink/?LinkId=403119</span></a></span></p>
<p>&nbsp;</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>This sample demonstrates consuming events from Event Hub using low level receiver API.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Creating a receiver with offset.

await consumerGroup.CreateReceiverAsync(partitionId, offset, receiverEpoch)

Creating a receiver to receive from the stream beginning

await consumerGroup.CreateReceiverAsync(partitionId, receiverEpoch)</pre>
<div class="preview">
<pre class="csharp">Creating&nbsp;a&nbsp;receiver&nbsp;with&nbsp;offset.&nbsp;
&nbsp;
await&nbsp;consumerGroup.CreateReceiverAsync(partitionId,&nbsp;offset,&nbsp;receiverEpoch)&nbsp;
&nbsp;
Creating&nbsp;a&nbsp;receiver&nbsp;to&nbsp;receive&nbsp;from&nbsp;the&nbsp;stream&nbsp;beginning&nbsp;
&nbsp;
await&nbsp;consumerGroup.CreateReceiverAsync(partitionId,&nbsp;receiverEpoch)</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:38px; width:1px; height:1px; overflow:hidden">
</div>
