Imports Microsoft.AspNet.SignalR

Public Class MessageHub
    Inherits Hub

    Public Sub senmessage(Message As String, user As String)
        Me.Clients.All.receivenotification(Message, user)
    End Sub
    Public Function receivenotification(Message As String) As String
        Return Message
    End Function
    Public Sub Hello()
        Clients.All.Hello()
    End Sub

End Class
