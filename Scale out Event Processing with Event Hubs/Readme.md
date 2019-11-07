# Scale out Event Processing with Event Hubs
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Service Bus
- Windows Azure Service Bus
- Event Hubs
- Windows Azure Event Hubs
## Topics
- Service Bus
- Windows Azure Service Bus
- Event Hubs
- Windows Azure Event Hubs
## Updated
- 10/27/2014
## Description

<h1>Introduction</h1>
<p><span style="font-family:Calibri">Event Hubs enable you to build applications that require ingesting event streams at very high throughput and low latency. Event Hubs enable you to durably store the events until the required retention period expires. Some
 of the typical types of applications that require high throughput event ingestion are log analytics systems for monitoring, billing and commerce services, and Internet of Things (IoT) scenarios that involve large numbers of devices publishing event streams.</span></p>
<p style="margin:0in 0in 8pt"><span style="font-family:Calibri">You can use the <strong>
EventProcessorHost </strong>API from Azure Event Hubs to reliably process large-scale data streams from Event Hubs. The
<strong>EventProcessorHost </strong>simplifies the workload distribution model and the client can focus on the actual data processing rather than handling the checkpoint and fault tolerance.</span></p>
<p style="margin:0in 0in 8pt"><span style="font-family:Calibri">Currently, Event Hubs are enabled in only 4 regions. Therefore, please make sure that the Service Bus namespace being used to run this sample is created in one of these 4 regions:<br>
&nbsp;1. Central US<br>
&nbsp;2. East US 2<br>
&nbsp;3. West Europe<br>
&nbsp;4. Southeast Asia<span style="font-size:small"><br>
</span></span></p>
<h1><span style="font-family:Times New Roman">&nbsp;</span><span>Building the Sample</span></h1>
<p>Please take a look at ReadMe.txt before build and run sample.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>This sample demonstrates how the EventProcessorHost to be used to distributed the work load of Event Hubs stream consumption. It shows how to implement the EventProcessor and EventProcesorFactory to keep things managed.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Host folder contains the host project. </li><li>Sender folder contains a simple sender. </li><li>ReadMe.txt important to take a look. </li></ul>
<h1>More Information</h1>
<p>Refer to Event Hubs Developer guide for detailed API documentation <span style="font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;; font-size:11pt">
<a href="http://go.microsoft.com/fwlink/?LinkId=403119"><span style="color:#0563c1">http://go.microsoft.com/fwlink/?LinkId=403119</span></a></span></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
