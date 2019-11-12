# TCP Communication in VB.NET
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- threading
- Async
- TCP/IP
## Topics
- TCP/IP Client/Server
## Updated
- 07/03/2012
## Description

<p><em>&nbsp;</em>&nbsp;</p>
<p>&nbsp;&nbsp;</p>
<h1>Introduction</h1>
<p>My sample demonstrates how You can use TCPListener and TCpclient classes and also how to use asynchronous read.</p>
<p>My class TCPChat supports full OOP. Therefore You can add this class very easy to Your existing project.</p>
<p>　</p>
<h1>Building the Sample</h1>
<p>There are no special requirements or instructions necessary. You only need a networkadapter.</p>
<p>　</p>
<h1>Description</h1>
<p>The sample indentificates the network adapter of the local machine (host) displays this items in textboxes (host). Enter a desired host port number on which You want to communicate now (host). In the textboxes remote You enter the items of the remote computer
 who is listening.</p>
<p>Press button connect.</p>
<p>You connect the app with the host socket. Enter the text to be sent into the box an press key return to finish this. Now the message wil be sent to the given remote address. In case that there is no remote listening a exception (timeout after 15 seconds)
 will occur. In this case press disconnect button and try it again with other remote parameters.</p>
<p>The easiest way to test this is to install this sample on 2 computer in a common subnetwork.</p>
<p>sreenshot: two computer in a common network</p>
<p>&nbsp;</p>
<p><em><img id="59313" src="59313-tcp1.jpg" alt="" width="461" height="287"></em></p>
<p><em>&nbsp;</em>&nbsp;</p>
<p>remarks: this sample also accepts DNS names instead IP Adresses in the boxes. Therefore You can communicate also via internet.&nbsp;</p>
<p>Here You can see a live demo:&nbsp;<span style="color:#0000ff; font-size:large"><span style="color:#0000ff; font-size:large">&nbsp;</span></span><a href="http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/be0bc7c6-4fe7-490d-860b-e84eed05b7c6">http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/be0bc7c6-4fe7-490d-860b-e84eed05b7c6</a></p>
<p>sreenshot: testing connection with yourself over internet. All You need is a dynDns.org name of Your router and configure a portforwarding to the host IP address:</p>
<p><img id="59314" src="59314-tcp3.jpg" alt="" width="464" height="303"></p>
<p>&nbsp;</p>
<p>the most important code snippsets are:</p>
<h1>&nbsp;Async reading a frame</h1>
<p>As You see, we create from the incoming frame (IAsyncResult) a instance of the clientsocket. With getStream().Read method You readout the data. At last you have to start a new Async Read and post the data back to the main thread (UI).A tcp read runs on a
 secondary thread in background and is started with the BeginAcceptTcpClient method. Now we take a look at the DoAccept method:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DoAccept(<span class="visualBasic__keyword">ByVal</span>&nbsp;ar&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IAsyncResult)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;buf()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;datalen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;listener&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpListener&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;clientSocket&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpClient&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;isConnected&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listener&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(ar.AsyncState,&nbsp;TcpListener)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket&nbsp;=&nbsp;listener.EndAcceptTcpClient(ar)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.ReceiveTimeout&nbsp;=&nbsp;<span class="visualBasic__number">5000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'update&nbsp;10.5.2011</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iRemote&nbsp;=&nbsp;clientSocket.Client.RemoteEndPoint&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pLocal&nbsp;=&nbsp;clientSocket.Client.LocalEndPoint&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ObjectDisposedException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;DoAccept&nbsp;ObjectDisposedException&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;MsgBoxStyle.Exclamation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;after&nbsp;server.stop()&nbsp;AsyncCallback&nbsp;is&nbsp;also&nbsp;active,&nbsp;but&nbsp;the&nbsp;object&nbsp;server&nbsp;is&nbsp;disposed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;clientSocket&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datalen&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;somtimes&nbsp;it&nbsp;occurs&nbsp;that&nbsp;.available&nbsp;returns&nbsp;the&nbsp;value&nbsp;0&nbsp;also&nbsp;data&nbsp;in&nbsp;buffer&nbsp;exists</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;datalen&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;data&nbsp;in&nbsp;read&nbsp;Buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;datalen&nbsp;=&nbsp;.Available&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buf&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Byte</span>(datalen&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;{}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'get&nbsp;entire&nbsp;bytes&nbsp;at&nbsp;once</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.GetStream().Read(buf,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;buf.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(Encoding.ASCII.GetString(buf,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;buf.Length))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TimeoutException&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;doAcceptData&nbsp;timeout:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;MsgBoxStyle.Exclamation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;doAcceptData:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;MsgBoxStyle.Exclamation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;receiveStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientSocket.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">RaiseEvent</span>&nbsp;recOK(receiveStatus)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;post&nbsp;data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sc.Post(<span class="visualBasic__keyword">New</span>&nbsp;SendOrPostCallback(<span class="visualBasic__keyword">AddressOf</span>&nbsp;OnDatareceived),&nbsp;sb.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;start&nbsp;new&nbsp;read</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server.BeginAcceptTcpClient(<span class="visualBasic__keyword">New</span>&nbsp;AsyncCallback(<span class="visualBasic__keyword">AddressOf</span>&nbsp;DoAccept),&nbsp;server)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>Start async read&nbsp;&nbsp;</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;server&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TcpListener(IPAddress.Parse(hostAdress),&nbsp;hostPort)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;server&nbsp;create:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;MsgBoxStyle.Exclamation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;server&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BeginAcceptTcpClient(<span class="visualBasic__keyword">New</span>&nbsp;AsyncCallback(<span class="visualBasic__keyword">AddressOf</span>&nbsp;DoAccept),&nbsp;server)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isConnected&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;server&nbsp;listen:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;ex.Message,&nbsp;MsgBoxStyle.Exclamation)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isConnected&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">RaiseEvent</span>&nbsp;connection(isConnected)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>&nbsp;Capturing data</h1>
<p>when You download the project, You will find file TCP-chat_comunication_on_LAN-sendMessage_hello_world.txt.</p>
<p>This is a full data capturing made with wireshark software.</p>
<p>The principal sequences are:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Windows Shell Script</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Skript bearbeiten</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">windowsshell</span>

<div class="preview">
<pre class="windowsshell">Frame&nbsp;&nbsp;&nbsp;host&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;remote&nbsp;
================================&nbsp;
<span class="windowsshell__number">1</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SYN&nbsp;&gt;&nbsp;
<span class="windowsshell__number">2</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;&nbsp;SYN,ACK&nbsp;&nbsp;
<span class="windowsshell__number">3</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ACK&nbsp;&gt;&nbsp;&nbsp;
<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connected&nbsp;&nbsp;<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span>&nbsp;
<span class="windowsshell__number">4</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PSH,ACK&nbsp;&gt;&nbsp;
<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data&nbsp;sent&nbsp;&nbsp;<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span>&nbsp;
<span class="windowsshell__number">5</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FIN,ACK&nbsp;&gt;&nbsp;
<span class="windowsshell__number">6</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;&nbsp;ACK&nbsp;
<span class="windowsshell__number">7</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;&nbsp;FIN,ACK&nbsp;
<span class="windowsshell__number">8</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ACK&nbsp;&gt;&nbsp;
<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;disconnected&nbsp;<span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span><span class="windowsshell__commandext">-</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>Appendix (msdn)</h1>
<p>The <strong>TcpListener</strong> class provides simple methods that listen for and accept incoming connection requests in blocking synchronous mode. You can use either a
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcpclient(v=vs.80).aspx">
TcpClient</a> or a <a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.socket(v=vs.80).aspx">
Socket</a> to connect with a <strong>TcpListener</strong>. Create a <strong>TcpListener</strong> using an
<a href="http://msdn.microsoft.com/en-us/library/system.net.ipendpoint(v=vs.80).aspx">
IPEndPoint</a>, a Local IP address and port number, or just a port number. Specify
<a href="http://msdn.microsoft.com/en-us/library/system.net.ipaddress.any(v=vs.80).aspx">
Any</a> for the local IP address and 0 for the local port number if you want the underlying service provider to assign those values for you. If you choose to do this, you can use the
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.localendpoint(v=vs.80).aspx">
LocalEndpoint</a> property to identify the assigned information, after the socket has connected.</p>
<p>Use the <a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.start(v=vs.80).aspx">
Start</a> method to begin listening for incoming connection requests. <strong>Start</strong> will queue incoming connections until you either call the
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.stop(v=vs.80).aspx">
Stop</a> method or it has queued <span class="unresolvedLink">MaxConnections</span>. Use either
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.acceptsocket(v=vs.80).aspx">
AcceptSocket</a> or <a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.accepttcpclient(v=vs.80).aspx">
AcceptTcpClient</a> to pull a connection from the incoming connection request queue. These two methods will block. If you want to avoid blocking, you can use the
<a href="http://msdn.microsoft.com/en-us/library/system.net.sockets.tcplistener.pending(v=vs.80).aspx">
Pending</a> method first to determine if connection requests are available in the queue.</p>
<p>The <strong>TcpClient</strong> class provides simple methods for connecting, sending, and receiving stream data over a network in synchronous blocking mode.</p>
<p>In order for <strong>TcpClient</strong> to connect and exchange data, a <a href="http://msdn.microsoft.com/en-US/library/system.net.sockets.tcplistener(v=vs.80)">
TcpListener</a> or <a href="http://msdn.microsoft.com/en-US/library/system.net.sockets.socket(v=vs.80)">
Socket</a> created with the TCP <a href="http://msdn.microsoft.com/en-US/library/system.net.sockets.protocoltype(v=vs.80)">
ProtocolType</a> must be listening for incoming connection requests. You can connect to this listener in one of the following two ways:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>Members of class TCPChat</h1>
<p>.....</p>
<p>&nbsp;&nbsp;&nbsp; Public Event Datareceived(ByVal txt As String)</p>
<p>Event: returns the received message bach to event handle of the UI thread</p>
<p>.....</p>
<p>&nbsp;&nbsp;&nbsp; Public Event connection(ByVal cStatus As Boolean)</p>
<p>Event: returns the status of the socket connection to event handle of the UI thread</p>
<p>.....</p>
<p>&nbsp;&nbsp;&nbsp; Public Event sendOK(ByVal sStatus As Boolean)</p>
<p>Event: the status of sending a frame successfull</p>
<p>.....</p>
<p>&nbsp;&nbsp; Public Event recOK(ByVal sReceive As Boolean)</p>
<p>Event: returns status of successfull reading a frame</p>
<p>.....</p>
<p><br>
&nbsp;&nbsp;&nbsp; Public ReadOnly Property Remote() As EndPoint</p>
<p>Property: returns remote Ednpoit of connection</p>
<p>.....</p>
<p>&nbsp;&nbsp;&nbsp; Public ReadOnly Property Local() As EndPoint</p>
<p>Property: returns host Endpoint of socket connection</p>
<p>.....</p>
<p>&nbsp;&nbsp; Public Sub connect(ByVal hostAdress As String, ByVal hostPort As Integer)</p>
<p>Method: make socket connection by given hostaddress and port</p>
<p>.....</p>
<p>&nbsp;&nbsp; Public Sub disconnect()</p>
<p>Method: disconnect the host socket</p>
<p>.....</p>
<p>&nbsp;&nbsp;&nbsp; Public Sub SendData(ByVal txt As String, ByVal remoteAddress As String, ByVal remotePort As Integer)</p>
<p>Method: send a frame to the given remote address and port</p>
<p>.....</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
