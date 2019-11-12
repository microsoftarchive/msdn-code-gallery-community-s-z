# SignalR con VB - Ejemplo Practico y Simple
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- jQuery
- Javascript
- Visual Basic .NET
- HTML5
- SignalR 2.0
## Topics
- SignalR
- Notificaciones
## Updated
- 06/06/2014
## Description

<h1>Introduccion</h1>
<div class="OutlineElement Ltr SCX161946830">
<p class="Paragraph SCX161946830"><span class="TextRun SCX161946830">Cuando busque como realizar un ejemplo de esta tecnolog&iacute;a o m&eacute;todo (SignaIR) me toco buscar mucho, sobre todo por que no es tan com&uacute;n en VB.NET o dif&iacute;cil
 de comprender.</span><span class="EOP SCX161946830">&nbsp;</span></p>
</div>
<div class="OutlineElement Ltr SCX161946830">
<p class="Paragraph SCX161946830"><span class="TextRun SCX85310167">Este ejemplo consta de 2 paginas para notificar de una a otra desde eventos cliente&nbsp;</span><span class="TextRun SCX85310167"><span class="SpellingError SCX85310167">SignaIR</span><span class="NormalTextRun SCX85310167">,
 adem&aacute;s pueden probar como notificar a usuarios espec&iacute;ficos.</span></span></p>
</div>
<div class="OutlineElement Ltr SCX161946830">
<p class="Paragraph SCX161946830"><span class="TextRun SCX161946830">&nbsp;</span><span class="EOP SCX161946830">&nbsp;</span></p>
</div>
<div class="OutlineElement Ltr SCX161946830">
<p class="Paragraph SCX161946830"><span class="TextRun SCX161946830">Tambi&eacute;n</span><span class="TextRun SCX161946830"><span class="NormalTextRun SCX161946830">&nbsp;se utiliza un una librer&iacute;a&nbsp;</span><span class="SpellingError SCX161946830">javascript</span><span class="NormalTextRun SCX161946830">&nbsp;para
 emular&nbsp;</span></span><span class="TextRun SCX161946830"><span class="NormalTextRun SCX161946830">notificaciones como mensajes emergentes, este&nbsp;</span><span class="SpellingError SCX161946830">plugin</span><span class="NormalTextRun SCX161946830">&nbsp;permite
 tener diferentes tipos de notificaciones (Error, Decisi&oacute;n, Exitoso</span></span><span class="TextRun SCX161946830">) y en diferentes posiciones de la pantalla.</span></p>
</div>
<p>&nbsp;</p>
<h1><span>Ejemplo</span></h1>
<p><em><span class="TextRun SCX256468429"><span class="NormalTextRun SCX256468429">Este ejemplo requiere de Visual Studio 2013 y de la librer&iacute;as&nbsp;</span><span class="SpellingError SCX256468429">SignaIL,</span><span class="NormalTextRun SCX256468429">&nbsp;Notificaciones</span></span><span class="EOP SCX256468429">&nbsp;y
 Jquery.</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Descripcion</span></p>
<p><em><span class="NormalTextRun SCX114747066">Primero creamos un proyecto web simple y vac&iacute;o, luego con el administrador de paquetes o&nbsp;</span><span class="SpellingError SCX114747066">nugets</span><span class="NormalTextRun SCX114747066">&nbsp;agregamos&nbsp;</span><span class="SpellingError SCX114747066">SignaIR</span><span class="NormalTextRun SCX114747066">&nbsp;y&nbsp;</span><span class="SpellingError SCX114747066">Noty</span><span class="NormalTextRun SCX114747066">.</span></em></p>
<p><em><img id="116342" src="116342-signair%20install.png" alt="" width="499" height="301">&nbsp;&nbsp;</em></p>
<p><em><img id="116343" src="116343-noty%20install.png" alt="" width="452" height="301"></em></p>
<p>&nbsp;</p>
<p><span class="TextRun SCX225770693">Despu&eacute;s</span><span class="TextRun SCX225770693">&nbsp;de esto el proyecto generar un error el cual fue un poco dif&iacute;cil de corregir hasta que al fin entend&iacute; que tenia que agregar una clase con
 el nombre de Startup y con el siguiente codigo:</span><span class="EOP SCX225770693">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Linq&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Threading.Tasks&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Web&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Web.Routing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.AspNet.SignalR&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.Owin.Security&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Owin&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.Owin&nbsp;
&nbsp;
&lt;Assembly:&nbsp;OwinStartup(<span class="visualBasic__keyword">GetType</span>(NotificacionesSignalr.Startup))&gt;&nbsp;&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;NotificacionesSignalr&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Configuration(app&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IAppBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Any&nbsp;connection&nbsp;or&nbsp;hub&nbsp;wire&nbsp;up&nbsp;and&nbsp;configuration&nbsp;should&nbsp;go&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.MapSignalR()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span>&nbsp;
</pre>
</div>
</div>
</div>
<p><span class="TextRun SCX52483283">Despu&eacute;s</span><span class="TextRun SCX52483283">&nbsp;creo la clase de mensajes:</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.AspNet.SignalR&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Notification&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_mensaje&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_user&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;mesanje&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_mensaje&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mensaje&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;user&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_user&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_user&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Por ultimo creamos la clase que se encarga de notificar MessageHub:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.AspNet.SignalR&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MessageHub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Hub&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;senmessage(Message&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;user&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Clients.All.receivenotification(Message,&nbsp;user)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;receivenotification(Message&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Hello()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.Hello()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode">y ya el resto es html y javascript:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;<span class="js__operator">function</span>&nbsp;algo(texto,&nbsp;type)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;noty(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text:&nbsp;texto,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layout:&nbsp;<span class="js__string">'bottomRight'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;maxVisible:&nbsp;<span class="js__num">10</span>,&nbsp;<span class="js__sl_comment">//&nbsp;you&nbsp;can&nbsp;set&nbsp;max&nbsp;visible&nbsp;notification&nbsp;for&nbsp;dismissQueue&nbsp;true&nbsp;option,</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;type,&nbsp;<span class="js__sl_comment">//success,&nbsp;error,&nbsp;warning,&nbsp;information,&nbsp;confir,&nbsp;alert</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;timeout:&nbsp;<span class="js__num">10000</span>&nbsp;<span class="js__sl_comment">//&nbsp;delay&nbsp;for&nbsp;closing&nbsp;event.&nbsp;Set&nbsp;false&nbsp;for&nbsp;sticky&nbsp;notifications</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.connection.hub.start();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#button1&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxy.server.senmessage(document.getElementById(<span class="js__string">'mesaje'</span>).value,&nbsp;document.getElementById(<span class="js__string">'userenviar'</span>).value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;proxy&nbsp;=&nbsp;$.connection.messageHub;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;proxy.client.receivenotification&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(message,&nbsp;user)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(document.getElementById(<span class="js__string">'user'</span>).value&nbsp;==&nbsp;user)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;algo(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.connection.hub.start().done();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h1><img id="116382" src="116382-notificacion%20signair.png" alt="" width="657" height="459"></h1>
<h1><span>Codigo Fuente</span></h1>
<ul>
<li><span>SignaIR</span> </li></ul>
<h1>Mas Informacion</h1>
<ul>
<li>Si requieren mas informacion recuerden preguntar, tal ves le pueda ser de ayuda.
</li></ul>
