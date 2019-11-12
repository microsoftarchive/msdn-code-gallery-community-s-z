# Simple Multi-User TCP/IP Client & Server using TAP
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- .NET
- Class Library
- XML
- .NET Framework
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- Network
- .NET Framework 4.5
- TCP/IP
- Visual Studio 2013
- .NET 4.5
- .NET Development
- Windows Desktop App Development
## Topics
- TCP/IP Client/Server
- Custom Data Protocols
## Updated
- 03/22/2015
## Description

<h1>Introduction</h1>
<p>In today's connected world it is no surprise that many new developers want to create some kind of client-server application soon after getting the hang of writing simple Windows Forms applications. &nbsp;These tend to be chat clients, data sharing utilities,
 and simple games meant for use with a small group of friends, family, or colleagues. &nbsp;It seems like it should be easy enough; there are classes like&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.sockets.tcpclient%28v=vs.110%29.aspx" target="_blank">System.Net.Sockets.TcpClient</a>&nbsp;and&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener%28v=vs.110%29.aspx" target="_blank">TcpListener</a>&nbsp;for
 communicating over the network with TCP/IP, and&nbsp;<a href="https://msdn.microsoft.com/en-us/library/system.threading.thread%28v=vs.110%29.aspx" target="_blank">Threads</a>&nbsp;or<a href="https://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker%28v=vs.110%29.aspx" target="_blank">BackgroundWorkers</a>&nbsp;for
 running the processing routines, so how hard could it be?<br>
<br>
It turns out that it can be quite difficult, depending on how you go about it. &nbsp;The interaction of the main Form's GUI thread with the background processing thread(s) and the client and listener instances can get complex in a hurry. &nbsp;It can become
 quite easy to make any number of mistakes when you try to get your code to allow new client connections, continue processing existing clients, and all the while keep a GUI responsive.<br>
<br>
Thankfully, the majority of these issues can be eloquently handled through implementation of the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/hh873175%28v=vs.110%29.aspx" target="_blank">Task-based Asynchronous Programming Pattern</a>, or TAP. &nbsp;Through
 the use of Task instances and the Async/Await keywords we can vastly simplify the processes of the server for scenarios where we have a reasonable number of clients sending reasonably sized messages in reasonable intervals.</p>
<h1><span>Building the Sample</span></h1>
<p>The sample project consists of 3 projects. &nbsp;The &quot;XProtocol&quot; project is a reference assembly for the other two projects; be sure it is built first. &nbsp;When running the sample you can launch additional clients from the Solution Explorer by right clicking
 the AsyncTcpClient project and selecting Debug -&gt; Start new instance from the context menu.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample provides an easy-to-use client-server framework based on the TAP pattern and Async/Await. &nbsp;It also demonstrates a simple XML-based message protocol for transfering complex messages as a byte stream.</p>
<ul>
</ul>
<h1>More Information</h1>
<p>For a complete write-up of the code in this solution, see the Technet Wiki article:</p>
<p><a href="http://social.technet.microsoft.com/wiki/contents/articles/30394.simple-multi-user-tcpip-client-server-using-tap.aspx" target="_blank">Simple Multi-User TCP/IP Client &amp; Server using TAP</a></p>
