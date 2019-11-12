# UWP + Linux Socket communication & Handling communciation in the BackgroundTask
## Requires
- Visual Studio 2017
## License
- MS-LPL
## Technologies
- universal windows app
- Background task
- Stream socket
- SocketActivityConnectedStandbyAction
- SocketActivityTrigger
## Topics
- Background tasks
- Socket communication
## Updated
- 12/18/2016
## Description

<h1>Introduction</h1>
<p><span>Quick Overview of Socket Communications in the BackgroundTask.</span></p>
<p><span>Why has it required?</span></p>
<p><span>When the GUI leaving in the foreground due to some synchro like app has suspended in the foreground, delegate this job to the background task, background Task will be handling the communication.</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><span>The server application is running in the Linux PC, the Client application is running on the Windows 10 PC.</span></p>
<p><span>Client</span></p>
<p><span>1.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>Windows 10</span></p>
<p><span>2.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><strong><span>Visual studio 2017 RC With UWP tools</span></strong></p>
<p><span>3.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>C#</span></p>
<p><span>4.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>UWP Toolkit</span></p>
<p><span>Server (Any Server)</span></p>
<p><span>1.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>Linux mint 18</span></p>
<p><span>2.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><strong><span>Visual Studio Code IDE</span></strong></p>
<p><span>3.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>C Programming</span></p>
<p><span>4.<span>&nbsp;&nbsp;&nbsp;&nbsp; </span></span><span>Oracle Virtual Box</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="color:#333333; font-family:Segoe UI; font-size:large">Transfer the Socket Communications</span></p>
<p><span>Transfer the StreamSocket to the BackgroundTask, first, we have to Enable the transfer the ownership, to enable the use the&nbsp;<strong>EnableTransferOwnership</strong>&nbsp;API. To call this function in Server Side socket before the binding host
 address, In Client side call this function, before Connect to the server socket.&nbsp;</span></p>
<p><span>Transfer the socket: &nbsp;Based on the needs, call the TransferOwnerShip API to transfer the socket communication to the Background Task.(Socket Broker) , In this example OnSuspending event, we call the&nbsp;<strong>TransferOwnership</strong>&nbsp;API.</span></p>
<p><span>Concept of this sample</span></p>
<p><span>Using TCP protocol, Server sends the continues data to the client, the client will receive the data&rsquo;s display in GUI, Once Client App has suspended, BackgroundTask of the app receives the data&rsquo;s display as a ToastNotification.</span><strong>&nbsp;</strong><em>&nbsp;</em></p>
<p>&nbsp;</p>
<p><span style="font-size:medium">More Info : <a title="UWP &#43; Linux Socket communication & Handling communciation in the BackgroundTask" href="http://social.technet.microsoft.com/wiki/contents/articles/36500.uwp-linux-socket-communication-handling-communciation-in-the-backgroundtask.aspx?wa=wsignin1.0" target="_blank">
http://social.technet.microsoft.com/wiki/contents/articles/36500.uwp-linux-socket-communication-handling-communciation-in-the-backgroundtask.aspx?wa=wsignin1.0</a></span></p>
<p>&nbsp;</p>
<p>Server APP</p>
<p>Server code has written in the C lanuguage</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__preproc">#include&nbsp;&lt;unistd.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;stdio.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;stdlib.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;netdb.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;netinet/in.h&gt;</span><span class="cpp__preproc">&nbsp;
#include&nbsp;&lt;string.h&gt;</span>&nbsp;
&nbsp;
<span class="cpp__datatype">int</span>&nbsp;main()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;UWP&nbsp;Socket&nbsp;Demo\n&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;sockfd,&nbsp;newsockfd,&nbsp;portno,&nbsp;clilen;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;buf[<span class="cpp__number">256</span>];&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">struct</span>&nbsp;sockaddr_in&nbsp;serv_addr,&nbsp;cli_addr;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;n;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sockfd&nbsp;=&nbsp;socket(AF_INET,&nbsp;SOCK_STREAM,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(sockfd&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;perror(<span class="cpp__string">&quot;socket&nbsp;created&nbsp;error&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;bzero((<span class="cpp__datatype">char</span>&nbsp;*)&nbsp;&amp;serv_addr,&nbsp;<span class="cpp__keyword">sizeof</span>(serv_addr));&nbsp;
&nbsp;&nbsp;&nbsp;portno&nbsp;=&nbsp;<span class="cpp__number">6000</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;serv_addr.sin_family&nbsp;=&nbsp;AF_INET;&nbsp;
&nbsp;&nbsp;&nbsp;serv_addr.sin_addr.s_addr&nbsp;=&nbsp;INADDR_ANY;&nbsp;
&nbsp;&nbsp;&nbsp;serv_addr.sin_port&nbsp;=&nbsp;htons(portno);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(bind(sockfd,&nbsp;(<span class="cpp__keyword">struct</span>&nbsp;sockaddr&nbsp;*)&nbsp;&amp;serv_addr,&nbsp;<span class="cpp__keyword">sizeof</span>(serv_addr))&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;perror(<span class="cpp__string">&quot;ERROR&nbsp;on&nbsp;binding&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;socket&nbsp;created\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;listen(sockfd,<span class="cpp__number">5</span>);&nbsp;
&nbsp;&nbsp;&nbsp;clilen&nbsp;=&nbsp;<span class="cpp__keyword">sizeof</span>(cli_addr);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;listen&nbsp;has&nbsp;accepted\n&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;newsockfd&nbsp;=&nbsp;accept(sockfd,(<span class="cpp__keyword">struct</span>&nbsp;sockaddr&nbsp;*)&amp;cli_addr,&nbsp;&amp;clilen);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(newsockfd&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;perror(<span class="cpp__string">&quot;ERROR&nbsp;on&nbsp;accept&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;Welcome&nbsp;new&nbsp;client\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;Here&nbsp;is&nbsp;the&nbsp;message:&nbsp;%s\n&quot;</span>,buf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bzero(buf,<span class="cpp__number">256</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;n&nbsp;=&nbsp;read(newsockfd,buf,<span class="cpp__number">255</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(n&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;perror(<span class="cpp__string">&quot;ERROR&nbsp;reading&nbsp;from&nbsp;socket&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">while</span>(<span class="cpp__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">char</span>&nbsp;str[<span class="cpp__number">20</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;len&nbsp;=&nbsp;sprintf(str,<span class="cpp__string">&quot;value&nbsp;:&nbsp;%d&quot;</span>,i&#43;&#43;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;n&nbsp;=&nbsp;write(newsockfd,str,len);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(n&nbsp;&lt;&nbsp;<span class="cpp__number">0</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;perror(<span class="cpp__string">&quot;Send&nbsp;Failed!!!\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sleep(<span class="cpp__number">10</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printf(<span class="cpp__string">&quot;Send&nbsp;%d&nbsp;\n&quot;</span>,i);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>&nbsp;<span class="cpp__number">0</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="165912" width="1366" height="728" src="165912-bgsocketserver.png" alt=""></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>UWP Client App</p>
<p>&nbsp;</p>
<p><img id="165914" width="1362" height="664" src="165914-output.png" alt=""></p>
