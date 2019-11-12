Imports System.Net
Imports System.Net.Sockets

'Your program will typically require a custom object which encapsulates the TcpClient instance
'and the data received from that client.  There is no single way to design this class as it's
'requirements will depend entirely on the desired functionality of the application being developed.
Public Class ConnectedClient
    'implement property change notification to facilitate databinding
    Implements System.ComponentModel.INotifyPropertyChanged

    'store the TcpClient instance
    Public ReadOnly TcpClient As TcpClient
    'store a unique id for this client connection
    Public ReadOnly Id As String
    Public Property Task As Task

    'store the data received from the remote client
    Public ReadOnly Received As New List(Of Byte)

    'expose the received data as a string property to facilitate databinding
    Private _Text As String = String.Empty
    Public ReadOnly Property Text As String
        Get
            'Return Received.ToString
            Return _Text
        End Get
    End Property

    Public Sub New(client As TcpClient)
        TcpClient = client
        'craft the unique id from the remote client's IP address and the port they connected from
        Id = CType(TcpClient.Client.RemoteEndPoint, IPEndPoint).ToString
    End Sub

    'expose a helper method for capturing and storing data received from the remote client
    Public Sub AppendData(buffer() As Byte, read As Integer)
        If read = 0 Then Exit Sub
        'add the bytes read this time to the collection of bytes read so far
        Received.AddRange(buffer.Take(read))
        'check to see if the bytes read so far represent a complete message
        If XProtocol.XMessage.IsMessageComplete(Received) Then
            'if so, build a message from the byte data and then clear the byte data to prepare for the next message
            Dim message As XProtocol.XMessage = XProtocol.XMessage.FromByteArray(Received.ToArray)
            Received.Clear()
            'read data elements from the message as appropriate
            Select Case message.Element.Name
                Case "TextMessage"
                    _Text = message.Element.@text1
                    RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Text"))
            End Select
        End If
    End Sub

    'implement primary object method overrides based on unique id
    Public Overrides Function Equals(obj As Object) As Boolean
        If TypeOf obj Is ConnectedClient Then Return Id = DirectCast(obj, ConnectedClient).Id
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return Id.GetHashCode
    End Function

    Public Overrides Function ToString() As String
        Return Id
    End Function

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class