Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Microsoft.AspNet.SignalR

Namespace SimpleUsersOnLine
    Public Class UsersOnLine
        Inherits Hub
        Public Shared users As New List(Of String)()

        Public Overrides Function OnConnected() As System.Threading.Tasks.Task
            Dim clientId As String = GetClientId()

            If users.IndexOf(clientId) = -1 Then
                users.Add(clientId)
            End If

            ShowUsersOnLine()

            Return MyBase.OnConnected()
        End Function

        Public Overrides Function OnReconnected() As System.Threading.Tasks.Task
            Dim clientId As String = GetClientId()
            If users.IndexOf(clientId) = -1 Then
                users.Add(clientId)
            End If

            ShowUsersOnLine()

            Return MyBase.OnReconnected()
        End Function

        Public Overrides Function OnDisconnected() As System.Threading.Tasks.Task
            Dim clientId As String = GetClientId()

            If users.IndexOf(clientId) > -1 Then
                users.Remove(clientId)
            End If

            ShowUsersOnLine()

            Return MyBase.OnDisconnected()
        End Function


        Private Function GetClientId() As String
            Dim clientId As String = ""
            If Not (Context.QueryString("clientId") Is Nothing) Then
                'clientId passed from application
                clientId = Context.QueryString("clientId").ToString()
            End If

            If clientId.Trim() = "" Then
                'default clientId: connectionId
                clientId = Context.ConnectionId
            End If
            Return clientId

        End Function
        Public Sub Log(message As String)
            Clients.All.log(message)
        End Sub
        Public Sub ShowUsersOnLine()
            Clients.All.showUsersOnLine(users.Count)
        End Sub
    End Class
End Namespace
