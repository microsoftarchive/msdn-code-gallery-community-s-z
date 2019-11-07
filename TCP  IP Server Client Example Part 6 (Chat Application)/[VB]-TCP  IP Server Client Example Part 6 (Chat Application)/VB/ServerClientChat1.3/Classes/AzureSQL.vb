Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Imports System.Data.SqlClient

Namespace ServerClientChat1._3.Classes
	''' <summary>
	''' All our methods to interact with the SQL Server
	''' Information about connecting to Azure SQL: http://www.windowsazure.com/EN-US/develop/net/how-to-guides/sql-database/
	''' Read the information provided.
	''' </summary>
	Friend Class AzureSQL
		Public Property ConnectionString() As String
		Public Property conn() As SqlConnection

		Public Property LastError() As String

		Public Delegate Sub SQLInfoMessageHandler(ByVal Message As String)
		Public Event SQLInfoMessage As SQLInfoMessageHandler
		Public Delegate Sub SQLStateChangedHandler(ByVal State As System.Data.ConnectionState)
		Public Event SQLStateChanged As SQLStateChangedHandler

		''' <summary>
		''' Main Connection Method
		''' </summary>
		''' <returns>
		''' Fake Bool: Hard Coded to True
		''' </returns>
		Friend Function Connect() As Boolean
			Dim tConnectAsync As New Task(Sub() ConnectAsync())
			tConnectAsync.Start()
			Return True
		End Function

		''' <summary>
		''' TODO: Keep retrying connection on Fail.
		''' </summary>
		Private Sub ConnectAsync()
			If Not String.IsNullOrWhiteSpace(ConnectionString) Then
				conn = New SqlConnection(ConnectionString)
				conn.Open()
				AddHandler conn.InfoMessage, AddressOf conn_InfoMessage
				AddHandler conn.StateChange, AddressOf conn_StateChange

				Select Case conn.State
					Case System.Data.ConnectionState.Broken
						RaiseEvent SQLStateChanged(conn.State)

					Case System.Data.ConnectionState.Closed
						RaiseEvent SQLStateChanged(conn.State)

					Case System.Data.ConnectionState.Connecting
						RaiseEvent SQLStateChanged(conn.State)

					Case System.Data.ConnectionState.Executing
						RaiseEvent SQLStateChanged(conn.State)

					Case System.Data.ConnectionState.Fetching
						RaiseEvent SQLStateChanged(conn.State)

					Case System.Data.ConnectionState.Open
						RaiseEvent SQLStateChanged(conn.State)

					Case Else
						RaiseEvent SQLStateChanged(conn.State)

				End Select
			End If

		End Sub

		Private Sub conn_StateChange(ByVal sender As Object, ByVal e As System.Data.StateChangeEventArgs)
			RaiseEvent SQLStateChanged(e.CurrentState)
		End Sub

		Private Sub conn_InfoMessage(ByVal sender As Object, ByVal e As SqlInfoMessageEventArgs)
			RaiseEvent SQLInfoMessage(e.Message)
		End Sub

		Public Function RegisterUser(ByVal email As String, ByVal password As String) As Boolean
			Try
				Dim emailValue As String = email
				Dim passwordValue As String = password
				Dim screenNameValue As String = "" ' Not currently used
				Dim onlineStatusValue As Boolean = True
				Dim queryString As String = "INSERT INTO dbo.Users (ScreenName, EmailAddress, Password, Online) Values (@screenName, @email, @password, @Online);"
				Dim command As New SqlCommand(queryString, conn)
				command.Parameters.AddWithValue("@email", emailValue)
				command.Parameters.AddWithValue("@password", passwordValue)
				command.Parameters.AddWithValue("@screenName", screenNameValue)
				command.Parameters.AddWithValue("@Online", onlineStatusValue)

				Dim RowsAffected As Integer = CInt(command.ExecuteNonQuery())
				If RowsAffected > 0 Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				Dim m As String = ex.Message
			End Try
			Return False
		End Function

		''' <summary>
		''' Get the User's ID. Sent by server back to connecting client so that all communications are unique.
		''' Should all be in a Try Catch Block
		''' </summary>
		''' <param name="emailAddress">
		''' The EmailAddress of the User Who's ID we want
		''' </param>
		''' <returns>
		''' int: ClientID from dbo.Users
		''' </returns>
		Friend Function GetUsersID(ByVal emailAddress As String) As Integer
			Try
				Dim userID As Integer = 0
				Dim paramValue As String = emailAddress
				Dim queryString As String = "SELECT ClientID FROM dbo.Users WHERE EmailAddress = @emailAddress;"
				Dim command As New SqlCommand(queryString, conn)
				command.Parameters.AddWithValue("@emailAddress", paramValue)
				userID = DirectCast(command.ExecuteScalar(), Integer)

				Return userID
			Catch ex As Exception
				Dim m As String = ex.Message
			End Try
			Return -1
		End Function

		''' <summary>
		''' Is this user Registered?
		''' </summary>
		''' <param name="p">
		''' string: The User Name
		''' </param>
		''' <returns>
		''' bool:   True = they are registered
		'''         false = they are not registered
		''' </returns>
		Friend Function RegisterUserExists(ByVal emailAddress As String) As Boolean
			Try
				Dim userId As Integer = 0
				Dim paramValue As String = emailAddress
				Dim queryString As String = "SELECT ClientID FROM dbo.Users WHERE EmailAddress = @emailAddress;"
				Dim command As New SqlCommand(queryString, conn)
				command.Parameters.AddWithValue("@emailAddress", paramValue)
				userId = DirectCast(command.ExecuteScalar(), Integer)

				Return True
			Catch ex As Exception
				Dim m As String = ex.Message
			End Try
			Return False
		End Function

		''' <summary>
		''' Now log the user is
		''' </summary>
		''' <param name="p1">
		''' string: Username
		''' </param>
		''' <param name="p2">
		''' string: Password
		''' We would use the password in production to decrypt the user's data before updating and re-encrypt it afterwards. Thus
		''' ensuring that their data is totally private and that we do not have the decryption key for their data
		''' </param>
		''' <returns>
		''' bool:   True if successful
		'''         False if failed
		''' </returns>
		Friend Function LoginUser(ByVal p1 As String, ByVal p2 As String) As Boolean
			Try
				Dim emailValue As String = p1

				Dim onlineStatusValue As Boolean = True
				Dim queryString As String = "UPDATE dbo.Users SET Online = @Online WHERE EmailAddress = @EmailValue"
				Dim command As New SqlCommand(queryString, conn)

				command.Parameters.AddWithValue("@Online", onlineStatusValue)
				command.Parameters.AddWithValue("@EmailValue", emailValue)

				Dim RowsAffected As Integer = CInt(command.ExecuteNonQuery())
				If RowsAffected > 0 Then
					Return True
				Else
					Return False
				End If
			Catch ex As Exception
				Dim m As String = ex.Message
			End Try
			Return False
		End Function

		''' <summary>
		''' Discovers how many users are Registered with our chat server
		''' </summary>
		''' <returns>
		''' int: Number of registered users (In production this may need to be a long)
		''' </returns>
		Friend Function GetRegisteredUsers() As Integer
			Try
				Dim Total As Integer = 0
				Dim queryString As String = "Select Coalesce(Sum(ClientID), 0) From dbo.Users" ' Converts a Null value to 0
				Dim command As New SqlCommand(queryString, conn)

				Total = DirectCast(command.ExecuteScalar(), Integer)

				Return Total
			Catch ex As Exception
				Dim m As String = ex.Message
			End Try
			Return 0
		End Function
	End Class
End Namespace
