# Sync101 with Remote Change Application over WCF
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Microsoft Sync Framework 2.0
## Topics
- Sync101
## Updated
- 05/16/2011
## Description

<h1>Introduction</h1>
<p>This sample shows&nbsp;how to synchronize efficiently with a remote replica by using a proxy provider on the local computer. The proxy provider uses the Remote Change Application pattern and Windows Communication Foundation (WCF) to send serialized metadata
 and data to the remote replica so synchronization processing can be performed on the remote computer with fewer round trips between the client and server computers.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>Microsoft Sync Framework synchronizes data between data stores. Typically, these data stores are on different computers or devices that are connected over a network. The application that controls synchronization can be on a third computer or can be on the
 same computer as one of the data stores. When you implement your own custom provider to represent a remote data store, there are two ways to perform synchronization:</p>
<ul>
<li>The remote computer does not run Sync Framework. The provider that represents the remote data store runs on the computer local to the synchronization application. The provider either applies changes individually to the remote data store, resulting in lots
 of round trips, or implements a custom batching mechanism. </li><li>The remote computer runs Sync Framework and the local computer uses a proxy provider. The proxy provider performs minimal processing and uses the Remote Change Application pattern to send metadata and data to the provider on the remote computer, where change
 application is performed. This pattern allows the bulk of synchronization processing to be distributed to the remote computer. By caching change data, only one round trip is needed to process each change batch.
</li></ul>
<p>For more information, see the article: <a href="http://msdn.microsoft.com/en-us/library/ee819079(v=SQL.100).aspx">
http://msdn.microsoft.com/en-us/library/ee819079(v=SQL.100).aspx</a>.</p>
