<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs"
    Inherits="SimpleWebSocketApplication.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span id="webSocketStatusSpan"></span>
            <br />
            <span id="webSocketReceiveDataSpan"></span>
            <br />
            <span>Please enter a string</span>
            <br />
            <input id="nameTextBox" type="text" value="" />
            <input type="button" value="Send data" onclick="SendData();" />
            <input type="button" value="Close WebSocket" onclick="CloseWebSocket();" />
        </div>
    </form>
    <script type="text/javascript">

        var webSocketStatusSpan = document.getElementById("webSocketStatusSpan");
        var webSocketReceiveDataSpan = document.getElementById("webSocketReceiveDataSpan");
        var nameTextBox = document.getElementById("nameTextBox");

        var webSocket;

        //The address of our HTTP-handler
        var handlerUrl = "ws://localhost/SimpleWebSocketApplication/WebSocketHandler.ashx";

        function SendData() {

            //Initialize WebSocket.
            InitWebSocket();

            //Send data if WebSocket is opened.
            if (webSocket.OPEN && webSocket.readyState == 1)
                webSocket.send(nameTextBox.value);

            //If WebSocket is closed, show message.
            if (webSocket.readyState == 2 || webSocket.readyState == 3)
                webSocketStatusSpan.innerText = "WebSocket closed, the data can't be sent.";
        }

        function CloseWebSocket() {
            webSocket.close();
        }

        function InitWebSocket() {

            //If the WebSocket object isn't initialized, we initialize it.
            if (webSocket == undefined) {
                webSocket = new WebSocket(handlerUrl);

                //Open connection  handler.
                webSocket.onopen = function () {
                    webSocketStatusSpan.innerText = "WebSocket opened.";
                    webSocket.send(nameTextBox.value);
                };

                //Message data handler.
                webSocket.onmessage = function (e) {
                    webSocketReceiveDataSpan.innerText = e.data;
                };

                //Close event handler.
                webSocket.onclose = function () {
                    webSocketStatusSpan.innerText = "WebSocket closed.";
                };

                //Error event handler.
                webSocket.onerror = function (e) {
                    webSocketStatusSpan.innerText = e.message;
                }
            }
        }
    </script>
</body>
</html>
