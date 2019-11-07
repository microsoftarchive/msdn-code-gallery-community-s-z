<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Notificaciones2.aspx.vb" Inherits="SignaIR.Notificaciones2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script src="Scripts/jquery-1.8.3.min.js"></script>
    <script src="Scripts/noty/jquery.noty.packaged.min.js"></script>
    <script src="Scripts/jquery.signalR-2.0.3.min.js"></script>
    <script type="text/javascript" src="signalr/hubs"></script>
        <script>
        function algo(texto, type) {
            noty({
                text: texto,
                layout: 'bottomRight',
                maxVisible: 10, // you can set max visible notification for dismissQueue true option,
                type: type, //success, error, warning, information, confir, alert
                timeout: 10000 // delay for closing event. Set false for sticky notifications
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $.connection.hub.start();
            $("#button1").click(function () {
                proxy.server.senmessage(document.getElementById('mesaje').value, document.getElementById('userenviar').value);
            });
            
        });
    </script>
    <script type="text/javascript">
        var proxy = $.connection.messageHub;
        $(function () {
            proxy.client.receivenotification = function (message, user) {
                if (document.getElementById('user').value == user) {
                    algo(message);
                }
            }
            $.connection.hub.start().done();

        });
    </script>
     <style type="text/css">
        #mesaje {
            height: 80px;
            width: 253px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>Notificacion 2</p>
        <fieldset>
            <p>Prueva de Notificacion javascript</p>
            <input type="button" onclick="algo('noty - a jquery notification library!'); return false;" title="Notificar" value="Alerta" />
        </fieldset>
        <br />
        <br />
        <div>
            <table>
                <tr>
                    <td>Usuario a Notificar</td>
                    <td>
                        <input type="text" value="Juan" id="userenviar" /></td>
                </tr>
                <tr>
                    <td>Mensaje:</td>
                    <td>
                        <textarea id="mesaje">Mensaje enviado a Pedro</textarea></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <input id="button1" type="button" title="Notificar" value="Notificar Mensaje" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <table>
                <tr>
                    <td>Usuario a Notificar</td>
                    <td><input type="text" value="Pedro" id="user" /></td>
                </tr>
            </table>


            
        </div>
    </form>
</body>
</html>
