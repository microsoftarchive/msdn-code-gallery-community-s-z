Imports Microsoft.AspNet.SignalR
Public Class Notification
    Private _mensaje As String
    Private _user As String
    Public Property mesanje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property
    Public Property user As String
        Get
            Return _user
        End Get
        Set(value As String)
            _user = value
        End Set
    End Property
End Class
