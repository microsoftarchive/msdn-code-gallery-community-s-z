# Sockets aplicacion cliente
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- Visual Studio 2010
- .NET Framework
## Topics
- Windows Forms
- Socket
## Updated
- 07/11/2011
## Description

<p>Ejemplo del uso de socket en .net , muestra como y cuales son los pasos a seguir para trabajar con sockets en vb.net</p>
<p><a id="24858" href="/site/view/file/24858/1/cliente.zip">cliente.zip</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<a id="24859" href="/site/view/file/24859/1/servidor.zip">servidor.zip</a>&nbsp;&nbsp;</p>
<p>codigo de cliente</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic
Public Class Form1
    Public cliente As TcpClient
    Public bytes() As Byte = Nothing
    Public leer_escribir As NetworkStream
    Public cadena As String
    Private Sub conectar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conectar.CheckedChanged
        cliente = New TcpClient
        Try
            cliente.Connect(IPAddress.Parse(&quot;127.0.0.1&quot;), 6000)
            System.Windows.Forms.Application.DoEvents()
        Catch ex As Exception
            conversacion.Text = &quot;IMPOSIBLE CONECTAR CON SERVIDOR&quot;
        End Try
        If cliente.Connected = True Then
            leer_escribir = cliente.GetStream
            secuencia_lecturas.Interval = 1000
            secuencia_lecturas.Start()
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub secuencia_lecturas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secuencia_lecturas.Tick
        If cliente.Connected = True Then
            'leer_escribir.ReadTimeout = 1
            If leer_escribir.DataAvailable = True Then
                'leer_escribir.Dispose()
                'RaiseEvent Resize(bytes, cliente.ReceiveBufferSize)
                ReDim bytes(cliente.ReceiveBufferSize)
                leer_escribir.Read(bytes, 0, bytes.Length)
                cadena = Encoding.ASCII.GetString(bytes, 0, bytes.Length)

                If cadena(0) = &quot;U&quot; And cadena(1) = &quot;.&quot; Then
                    usuarios.Text = cadena
                    'MsgBox(&quot;as&quot;)
                Else
                    conversacion.Text &amp;= cadena
                End If
            End If
            'leer_escribir.Flush()
            bytes = Nothing
            cadena = &quot;&quot;
        Else
            conversacion.Text &amp;= &quot;PERDIDA LA CONEXION CON SERVIDOR&quot;
            conversacion.SendToBack()
        End If
    End Sub

    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar.Click
        If txtenviar.Text &lt;&gt; &quot;&quot; Then

            cadena = txtenviar.Text
            bytes = Encoding.ASCII.GetBytes(cadena)
            leer_escribir.Write(bytes, 0, bytes.Length)

            cadena = &quot;&quot;
            bytes = Nothing

        End If
    End Sub
End Class</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net.Sockets&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.VisualBasic&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;cliente&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpClient&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;bytes()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;leer_escribir&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;NetworkStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;cadena&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;conectar_CheckedChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;conectar.CheckedChanged&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TcpClient&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente.Connect(IPAddress.Parse(<span class="visualBasic__string">&quot;127.0.0.1&quot;</span>),&nbsp;<span class="visualBasic__number">6000</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.Application.DoEvents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conversacion.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;IMPOSIBLE&nbsp;CONECTAR&nbsp;CON&nbsp;SERVIDOR&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;cliente.Connected&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;cliente.GetStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secuencia_lecturas.Interval&nbsp;=&nbsp;<span class="visualBasic__number">1000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secuencia_lecturas.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;secuencia_lecturas_Tick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;secuencia_lecturas.Tick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;cliente.Connected&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'leer_escribir.ReadTimeout&nbsp;=&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;leer_escribir.DataAvailable&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'leer_escribir.Dispose()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'RaiseEvent&nbsp;Resize(bytes,&nbsp;cliente.ReceiveBufferSize)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ReDim</span>&nbsp;bytes(cliente.ReceiveBufferSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Read(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;Encoding.ASCII.GetString(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;cadena(<span class="visualBasic__number">0</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;U&quot;</span>&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;cadena(<span class="visualBasic__number">1</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;.&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;usuarios.Text&nbsp;=&nbsp;cadena&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'MsgBox(&quot;as&quot;)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conversacion.Text&nbsp;&amp;=&nbsp;cadena&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'leer_escribir.Flush()</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conversacion.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;PERDIDA&nbsp;LA&nbsp;CONEXION&nbsp;CON&nbsp;SERVIDOR&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conversacion.SendToBack()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnenviar_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnenviar.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;txtenviar.Text&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;txtenviar.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;Encoding.ASCII.GetBytes(cadena)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Write(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>codigo servidor</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">{#scriptcode_dlg.remove_script}</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic
Public Class TCPSERVIDOR

    Public servidor As TcpListener = Nothing ''servidor de escucha
    Public ip As IPAddress = Nothing '' ip del servidor
    Public port As Integer = Nothing '' puerto por el que realiza la escucha
    Public cliente As TcpClient = Nothing  '' cliente conectado(aceptamos la solicitud y asignamos el tcpclient)
    Public leer_escribir As NetworkStream = Nothing '' metodo para enviar y recibir informacion desde cliente

    Public bytes() As Byte '' donde almacenamos lo recibido o lo que vamos a enviar
    Public cadena As String = &quot;&quot; ''almacenamos la info antes de codificar o bien despues para tratarla
    Public max_connect As Integer = 10 '' maximas conexiones permitidas
    Public conectados = 0 '' usuarios conectados
    Public idclientes(max_connect) As IntPtr '' array de identificadores de clientes
    Public tcpclientes(max_connect) As TcpClient '' array de tcpclient de los clientes
    Public posicion As Integer = 0
    Private Sub escucha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles escucha.CheckedChanged

        Try
            '' indicamos ip y puerto
            ip = IPAddress.Parse(&quot;127.0.0.1&quot;)
            port = 6000
            '' asignamos un nuevo tcplistener a servidor
            servidor = New TcpListener(ip, port)
            servidor.Start() ''inicializamos el modo escucha
            ''
            While True
                '' preguntamos si existen solicitudes pendientes
                '' y posteriormente se acepta y luego se controla si se mantiene
                If servidor.Pending() = True Then
                    cliente = servidor.AcceptTcpClient
                    If conectados &lt; max_connect Then
                        conectados &#43;= 1
                        ''guardamos info del cliente
                        idclientes(posicion) = cliente.Client.Handle.ToString
                        usuarios.Text &amp;= &quot;********************************************&quot; &amp; vbCrLf
                        usuarios.Text &amp;= &quot;[ID] &quot; &amp; idclientes(posicion).ToString &amp; &quot;     &quot; &amp; &quot;[DT] &quot; &amp; Date.Now &amp; vbCrLf
                        tcpclientes(posicion) = cliente
                        mandar_usuarios()
                        'If posicion = 0 Then
                        'End If
                        secuencia_lecturas.Interval = 1000
                        secuencia_lecturas.Start()
                        posicion &#43;= 1
                    Else
                        noconnect(cliente)
                    End If
                End If
                ''esperamos cualquier escritura en el servidor 


                System.Windows.Forms.Application.DoEvents()
            End While
        Catch ex As Exception

        End Try
       
    End Sub
    Public Sub noconnect(ByRef cliente As TcpClient)
        cadena = &quot;Servidor Saturado&quot; &amp; vbCrLf
        bytes = Encoding.ASCII.GetBytes(cadena)
        leer_escribir = cliente.GetStream
        leer_escribir.Write(bytes, 0, bytes.Length)

        leer_escribir.Flush()

        leer_escribir = Nothing
        bytes = Nothing
        cadena = &quot;&quot;

        cliente.Close()
    End Sub
    Public Sub mandar_usuarios()
        Dim i As Integer
        Dim j As Integer
        '' almacenar lista usuarios en cadena
        For j = 0 To posicion Step 1
            cadena &amp;= &quot;U.[ID] - &quot; &amp; idclientes(j).ToString &amp; vbCrLf
        Next
        For i = 0 To posicion Step 1
            ''meter en cadena todos los id
            leer_escribir = tcpclientes(i).GetStream
            bytes = Encoding.ASCII.GetBytes(cadena)
            leer_escribir.Write(bytes, 0, bytes.Length)
        Next
        cadena = &quot;&quot;
        bytes = Nothing
        leer_escribir = Nothing
    End Sub
    Private Sub secuencia_lecturas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secuencia_lecturas.Tick
        Dim i As Integer
        Dim j As Integer
        For i = 0 To posicion - 1 Step 1
            leer_escribir = tcpclientes(i).GetStream
            If leer_escribir.DataAvailable = True Then
                ReDim bytes(cliente.ReceiveBufferSize)
                leer_escribir.Read(bytes, 0, bytes.Length)
                cadena &amp;= vbCrLf &amp; cliente.Client.Handle.ToString
                cadena &amp;= &quot;  DICE :&quot; &amp; Encoding.ASCII.GetString(bytes)
                cadena &amp;= vbCrLf
                For j = 0 To posicion - 1 Step 1
                    leer_escribir = tcpclientes(j).GetStream
                    bytes = Encoding.ASCII.GetBytes(cadena)
                    leer_escribir.Write(bytes, 0, bytes.Length)
                Next
                cadena = &quot;&quot;
                bytes = Nothing
                leer_escribir = Nothing
            End If
        Next
    End Sub
End Class</pre>
<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Net.Sockets&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.VisualBasic&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;TCPSERVIDOR&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;servidor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpListener&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__com">''servidor&nbsp;de&nbsp;escucha</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;ip&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IPAddress&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__com">''&nbsp;ip&nbsp;del&nbsp;servidor</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;port&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__com">''&nbsp;puerto&nbsp;por&nbsp;el&nbsp;que&nbsp;realiza&nbsp;la&nbsp;escucha</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;cliente&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpClient&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;cliente&nbsp;conectado(aceptamos&nbsp;la&nbsp;solicitud&nbsp;y&nbsp;asignamos&nbsp;el&nbsp;tcpclient)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;leer_escribir&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;NetworkStream&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__com">''&nbsp;metodo&nbsp;para&nbsp;enviar&nbsp;y&nbsp;recibir&nbsp;informacion&nbsp;desde&nbsp;cliente</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;bytes()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;<span class="visualBasic__com">''&nbsp;donde&nbsp;almacenamos&nbsp;lo&nbsp;recibido&nbsp;o&nbsp;lo&nbsp;que&nbsp;vamos&nbsp;a&nbsp;enviar</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;cadena&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__com">''almacenamos&nbsp;la&nbsp;info&nbsp;antes&nbsp;de&nbsp;codificar&nbsp;o&nbsp;bien&nbsp;despues&nbsp;para&nbsp;tratarla</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;max_connect&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">10</span>&nbsp;<span class="visualBasic__com">''&nbsp;maximas&nbsp;conexiones&nbsp;permitidas</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;conectados&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__com">''&nbsp;usuarios&nbsp;conectados</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;idclientes(max_connect)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;<span class="visualBasic__com">''&nbsp;array&nbsp;de&nbsp;identificadores&nbsp;de&nbsp;clientes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;tcpclientes(max_connect)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpClient&nbsp;<span class="visualBasic__com">''&nbsp;array&nbsp;de&nbsp;tcpclient&nbsp;de&nbsp;los&nbsp;clientes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;posicion&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;escucha_CheckedChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;escucha.CheckedChanged&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;indicamos&nbsp;ip&nbsp;y&nbsp;puerto</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ip&nbsp;=&nbsp;IPAddress.Parse(<span class="visualBasic__string">&quot;127.0.0.1&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;port&nbsp;=&nbsp;<span class="visualBasic__number">6000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;asignamos&nbsp;un&nbsp;nuevo&nbsp;tcplistener&nbsp;a&nbsp;servidor</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;servidor&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TcpListener(ip,&nbsp;port)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;servidor.Start()&nbsp;<span class="visualBasic__com">''inicializamos&nbsp;el&nbsp;modo&nbsp;escucha</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;preguntamos&nbsp;si&nbsp;existen&nbsp;solicitudes&nbsp;pendientes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;y&nbsp;posteriormente&nbsp;se&nbsp;acepta&nbsp;y&nbsp;luego&nbsp;se&nbsp;controla&nbsp;si&nbsp;se&nbsp;mantiene</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;servidor.Pending()&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente&nbsp;=&nbsp;servidor.AcceptTcpClient&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;conectados&nbsp;&lt;&nbsp;max_connect&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conectados&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''guardamos&nbsp;info&nbsp;del&nbsp;cliente</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idclientes(posicion)&nbsp;=&nbsp;cliente.Client.Handle.ToString&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;usuarios.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;********************************************&quot;</span>&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;usuarios.Text&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;[ID]&nbsp;&quot;</span>&nbsp;&amp;&nbsp;idclientes(posicion).ToString&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;[DT]&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__keyword">Date</span>.Now&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tcpclientes(posicion)&nbsp;=&nbsp;cliente&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mandar_usuarios()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;posicion&nbsp;=&nbsp;0&nbsp;Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'End&nbsp;If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secuencia_lecturas.Interval&nbsp;=&nbsp;<span class="visualBasic__number">1000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secuencia_lecturas.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;posicion&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;noconnect(cliente)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''esperamos&nbsp;cualquier&nbsp;escritura&nbsp;en&nbsp;el&nbsp;servidor&nbsp;</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Windows.Forms.Application.DoEvents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;noconnect(<span class="visualBasic__keyword">ByRef</span>&nbsp;cliente&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TcpClient)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Servidor&nbsp;Saturado&quot;</span>&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;Encoding.ASCII.GetBytes(cadena)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;cliente.GetStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Write(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Flush()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;mandar_usuarios()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;j&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''&nbsp;almacenar&nbsp;lista&nbsp;usuarios&nbsp;en&nbsp;cadena</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;j&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;posicion&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;U.[ID]&nbsp;-&nbsp;&quot;</span>&nbsp;&amp;&nbsp;idclientes(j).ToString&nbsp;&amp;&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;posicion&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">''meter&nbsp;en&nbsp;cadena&nbsp;todos&nbsp;los&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;tcpclientes(i).GetStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;Encoding.ASCII.GetBytes(cadena)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Write(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;secuencia_lecturas_Tick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;secuencia_lecturas.Tick&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;j&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;posicion&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;tcpclientes(i).GetStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;leer_escribir.DataAvailable&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ReDim</span>&nbsp;bytes(cliente.ReceiveBufferSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Read(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;&amp;=&nbsp;vbCrLf&nbsp;&amp;&nbsp;cliente.Client.Handle.ToString&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;&amp;=&nbsp;<span class="visualBasic__string">&quot;&nbsp;&nbsp;DICE&nbsp;:&quot;</span>&nbsp;&amp;&nbsp;Encoding.ASCII.GetString(bytes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;&amp;=&nbsp;vbCrLf&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;j&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;posicion&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;tcpclientes(j).GetStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;Encoding.ASCII.GetBytes(cadena)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir.Write(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;bytes.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cadena&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bytes&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;leer_escribir&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Servidorr</p>
<p>Imports System Imports System.IO Imports System.Net Imports System.Net.Sockets Imports System.Text Imports Microsoft.VisualBasic Public Class TCPSERVIDOR Public servidor As TcpListener = Nothing ''servidor de escucha Public ip As IPAddress = Nothing '' ip
 del servidor Public port As Integer = Nothing '' puerto por el que realiza la escucha Public cliente As TcpClient = Nothing '' cliente conectado(aceptamos la solicitud y asignamos el tcpclient) Public leer_escribir As NetworkStream = Nothing '' metodo para
 enviar y recibir informacion desde cliente Public bytes() As Byte '' donde almacenamos lo recibido o lo que vamos a enviar Public cadena As String = &quot;&quot; ''almacenamos la info antes de codificar o bien despues para tratarla Public max_connect As Integer = 10
 '' maximas conexiones permitidas Public conectados = 0 '' usuarios conectados Public idclientes(max_connect) As IntPtr '' array de identificadores de clientes Public tcpclientes(max_connect) As TcpClient '' array de tcpclient de los clientes Public posicion
 As Integer = 0 Private Sub escucha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles escucha.CheckedChanged Try '' indicamos ip y puerto ip = IPAddress.Parse(&quot;127.0.0.1&quot;) port = 6000 '' asignamos un nuevo tcplistener a servidor
 servidor = New TcpListener(ip, port) servidor.Start() ''inicializamos el modo escucha '' While True '' preguntamos si existen solicitudes pendientes '' y posteriormente se acepta y luego se controla si se mantiene If servidor.Pending() = True Then cliente
 = servidor.AcceptTcpClient If conectados &lt; max_connect Then conectados &#43;= 1 ''guardamos info del cliente idclientes(posicion) = cliente.Client.Handle.ToString usuarios.Text &amp;= &quot;********************************************&quot; &amp; vbCrLf usuarios.Text
 &amp;= &quot;[ID] &quot; &amp; idclientes(posicion).ToString &amp; &quot; &quot; &amp; &quot;[DT] &quot; &amp; Date.Now &amp; vbCrLf tcpclientes(posicion) = cliente mandar_usuarios() 'If posicion = 0 Then 'End If secuencia_lecturas.Interval = 1000 secuencia_lecturas.Start() posicion &#43;=
 1 Else noconnect(cliente) End If End If ''esperamos cualquier escritura en el servidor System.Windows.Forms.Application.DoEvents() End While Catch ex As Exception End Try End Sub Public Sub noconnect(ByRef cliente As TcpClient) cadena = &quot;Servidor Saturado&quot;
 &amp; vbCrLf bytes = Encoding.ASCII.GetBytes(cadena) leer_escribir = cliente.GetStream leer_escribir.Write(bytes, 0, bytes.Length) leer_escribir.Flush() leer_escribir = Nothing bytes = Nothing cadena = &quot;&quot; cliente.Close() End Sub Public Sub mandar_usuarios()
 Dim i As Integer Dim j As Integer '' almacenar lista usuarios en cadena For j = 0 To posicion Step 1 cadena &amp;= &quot;U.[ID] - &quot; &amp; idclientes(j).ToString &amp; vbCrLf Next For i = 0 To posicion Step 1 ''meter en cadena todos los id leer_escribir = tcpclientes(i).GetStream
 bytes = Encoding.ASCII.GetBytes(cadena) leer_escribir.Write(bytes, 0, bytes.Length) Next cadena = &quot;&quot; bytes = Nothing leer_escribir = Nothing End Sub Private Sub secuencia_lecturas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secuencia_lecturas.Tick
 Dim i As Integer Dim j As Integer For i = 0 To posicion - 1 Step 1 leer_escribir = tcpclientes(i).GetStream If leer_escribir.DataAvailable = True Then ReDim bytes(cliente.ReceiveBufferSize) leer_escribir.Read(bytes, 0, bytes.Length) cadena &amp;= vbCrLf &amp;
 cliente.Client.Handle.ToString cadena &amp;= &quot; DICE :&quot; &amp; Encoding.ASCII.GetString(bytes) cadena &amp;= vbCrLf For j = 0 To posicion - 1 Step 1 leer_escribir = tcpclientes(j).GetStream bytes = Encoding.ASCII.GetBytes(cadena) leer_escribir.Write(bytes, 0,
 bytes.Length) Next cadena = &quot;&quot; bytes = Nothing leer_escribir = Nothing End If Next End Sub End Class</p>
<p>Cliente</p>
<p>Imports System Imports System.IO Imports System.Net Imports System.Net.Sockets Imports System.Text Imports Microsoft.VisualBasic Public Class Form1 Public cliente As TcpClient Public bytes() As Byte = Nothing Public leer_escribir As NetworkStream Public
 cadena As String Private Sub conectar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles conectar.CheckedChanged cliente = New TcpClient Try cliente.Connect(IPAddress.Parse(&quot;127.0.0.1&quot;), 6000) System.Windows.Forms.Application.DoEvents()
 Catch ex As Exception conversacion.Text = &quot;IMPOSIBLE CONECTAR CON SERVIDOR&quot; End Try If cliente.Connected = True Then leer_escribir = cliente.GetStream secuencia_lecturas.Interval = 1000 secuencia_lecturas.Start() End If End Sub Private Sub Form1_Load(ByVal
 sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load End Sub Private Sub secuencia_lecturas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secuencia_lecturas.Tick If cliente.Connected = True Then 'leer_escribir.ReadTimeout
 = 1 If leer_escribir.DataAvailable = True Then 'leer_escribir.Dispose() 'RaiseEvent Resize(bytes, cliente.ReceiveBufferSize) ReDim bytes(cliente.ReceiveBufferSize) leer_escribir.Read(bytes, 0, bytes.Length) cadena = Encoding.ASCII.GetString(bytes, 0, bytes.Length)
 If cadena(0) = &quot;U&quot; And cadena(1) = &quot;.&quot; Then usuarios.Text = cadena 'MsgBox(&quot;as&quot;) Else conversacion.Text &amp;= cadena End If End If 'leer_escribir.Flush() bytes = Nothing cadena = &quot;&quot; Else conversacion.Text &amp;= &quot;PERDIDA LA CONEXION CON SERVIDOR&quot; conversacion.SendToBack()
 End If End Sub Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar.Click If txtenviar.Text &lt;&gt; &quot;&quot; Then cadena = txtenviar.Text bytes = Encoding.ASCII.GetBytes(cadena) leer_escribir.Write(bytes, 0,
 bytes.Length) cadena = &quot;&quot; bytes = Nothing End If End Sub End Class</p>
