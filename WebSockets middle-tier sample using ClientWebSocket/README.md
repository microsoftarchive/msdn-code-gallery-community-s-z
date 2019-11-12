# WebSockets middle-tier sample using ClientWebSocket
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WCF
- ASP.NET
- WebSockets
- ClientWebSocket
## Topics
- WCF
- WebSockets
## Updated
- 08/02/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">The sample demonstrates the usage of ClientWebSocket.
</span></p>
<p><span style="font-size:small">The same takes a scenario of a browser client talking to an Asp.Net web application - ScoreTickerApp,&nbsp;to get live score updates over websockets.
</span><span style="font-size:small">This Asp.Net Web App acting as the middle tier connects to two backend HttpListener based services -&nbsp;ScoreService1 and ScoreService2 to get the score updates.
</span></p>
<p><span style="font-size:small">As the backend score services are sending score updates over WebSockets to the Asp.net web app, it combines this and sends it back to the browser client again over websockets connection.
</span></p>
<h1><span>Running the Sample</span></h1>
<p><span style="font-size:small">-&nbsp;Start ScoreService1 and ScoreService2 and they send their listen URIs to a WCF
</span><span style="font-size:small">service: ScoreServicesRepository. </span><br>
<span style="font-size:small">-&nbsp;Start ScoreTickerApp which will connect to this WCF service :
</span><span style="font-size:small">ScoreServiceRepository, get the ScoreService URIs available and then use ClientWebSocket
</span><span style="font-size:small">to connect to ScoreService1 and ScoreService2 over WebSockets and start getting
</span><span style="font-size:small">score updates from the two services. It will then coalesce this and and send it back to the
</span><span style="font-size:small">browser.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The solution consists of 4 projects:</span></p>
<p><span style="font-size:small">1) &nbsp;ScoreServiceRepository (a WCF service which maintains all the Score services available - each of which correspond to a live game going on)
<br>
</span></p>
<p><span style="font-size:small">2) ScoreTickerApp (an Asp.Net generic handler which handles the requests from the browsers and send them score updates by connecting with backend score services)
</span></p>
<p><span style="font-size:small">3) ScoreService1 and ScoreService2 - both of these provide score updates for live games going on.
</span></p>
<h1>More Information</h1>
<p><span style="font-size:small"><em>More WebSocket samples are available here - <a href="https://github.com/paulbatum/WebSocket-Samples">
https://github.com/paulbatum/WebSocket-Samples</a></em></span></p>
