# SignalR Simple Users On Line Counter
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Javascript
- SignalR
## Topics
- SignalR
## Updated
- 03/04/2013
## Description

<h1>Introduction</h1>
<p><em>In this sample we use signalR, what is signalR?</em></p>
<p><em>ASP.NET SignalR is a new library for ASP.NET developers that simplifies the process of adding real-time web functionality to our applications.<br>
In the past i used node.js for real time events raised to clients, now with signalR it's pretty simple to use .net objects and real time events.<br>
</em></p>
<p><em>This is a simple sample of signalR usage, it's only a starting point but you can understand the potentialof signalR :)
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To integrate signalR on your web application/web site you can use nuget command:</em></p>
<p><img alt=""></p>
<p><img id="77046" src="http://i1.code.msdn.s-msft.com/signalr-simple-users-on-88936819/image/file/77046/1/screenshot007.png" alt="" width="318" height="13"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>In this sample you can find a simple class UsersOnLine in wich you can define/raise events of your signlR
</em><em><em>server side </em>implementation.</em></p>
<p><em>In this class we override the OnConnected,OnDisconnected,OnReconnected events of Hubs class and also we define two new events: Log and ShowUsersonLine.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UsersOnLine&nbsp;:&nbsp;Hub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;users=<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Threading.Tasks.Task&nbsp;OnConnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId&nbsp;=&nbsp;GetClientId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(users.IndexOf(clientId)==-<span class="cs__number">1</span>)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;users.Add(clientId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowUsersOnLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnConnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Threading.Tasks.Task&nbsp;OnReconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId&nbsp;=&nbsp;GetClientId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(users.IndexOf(clientId)&nbsp;==&nbsp;-<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;users.Add(clientId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowUsersOnLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnReconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;System.Threading.Tasks.Task&nbsp;OnDisconnected()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId&nbsp;=&nbsp;GetClientId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(users.IndexOf(clientId)&nbsp;&gt;&nbsp;-<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;users.Remove(clientId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShowUsersOnLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.OnDisconnected();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetClientId()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!(Context.QueryString[<span class="cs__string">&quot;clientId&quot;</span>]&nbsp;==&nbsp;<span class="cs__keyword">null</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//clientId&nbsp;passed&nbsp;from&nbsp;application</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientId&nbsp;=&nbsp;Context.QueryString[<span class="cs__string">&quot;clientId&quot;</span>].ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(clientId.Trim()&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//default&nbsp;clientId:&nbsp;connectionId</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientId&nbsp;=&nbsp;Context.ConnectionId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;clientId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Log(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.log(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ShowUsersOnLine()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.showUsersOnLine(users.Count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>The client script implementation for the UserOnLine class it's also pretty simple:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;<span class="js__statement">var</span>&nbsp;usr&nbsp;=&nbsp;$.connection.usersOnLine;&nbsp;
&nbsp;&nbsp;$.connection.hub.start().done(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//connected</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;usr.client.log&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(message)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//log&nbsp;event</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;usr.client.showUsersOnLine&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//showUsersOnLine&nbsp;event</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>The showOnLineUsers result is:</p>
<p><img id="77047" src="http://i1.code.msdn.s-msft.com/signalr-simple-users-on-88936819/image/file/77047/1/screenshot012.png" alt="" width="272" height="247"></p>
<h1>More Information</h1>
<p><em>For more information you can see the official signalR's website:</em></p>
<p><a title="signlR Official Web Site" href="http://www.asp.net/signalr" target="_blank"><em>http://www.asp.net/signalr</em></a></p>
<p>gitHub:</p>
<p><a title="github Project Web Site" href="https://github.com/SignalR/SignalR" target="_blank">https://github.com/SignalR/SignalR</a></p>
<p>&nbsp;</p>
<p>I'm italian developer, <span id="result_box" class="short_text" lang="en">
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">so sorry if</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">my English</span>
<span class="hps" title="Fai clic per visualizzare le traduzioni alternative">is not so</span><span class="hps" title="Fai clic per visualizzare le traduzioni alternative"> correct.</span></span></p>
<p><em><br>
</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
ASP.NET SignalR is a new library for ASP.NET developers that simplifies the process of adding real-time web functionality to your applications.</div>
