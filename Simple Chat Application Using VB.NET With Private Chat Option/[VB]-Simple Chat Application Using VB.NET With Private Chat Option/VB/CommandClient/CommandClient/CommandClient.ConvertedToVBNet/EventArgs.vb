Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

''' <summary>
''' Occurs when a command received from the server.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">The information about the received command.</param>
Public Delegate Sub CommandReceivedEventHandler(sender As Object, e As CommandEventArgs)

''' <summary>
''' Occurs when a command had been sent to the the remote server Successfully.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub CommandSentEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' Occurs when a command sending action had been failed.This is because disconnection or sending exception.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub CommandSendingFailedEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' The class that contains information about a command.
''' </summary>
Public Class CommandEventArgs
	Inherits EventArgs
	Private m_command As Command
	''' <summary>
	''' The received command.
	''' </summary>
	Public ReadOnly Property Command() As Command
		Get
			Return m_command
		End Get
	End Property
	''' <summary>
	''' Creates an instance of CommandEventArgs class.
	''' </summary>
	''' <param name="cmd">The received command.</param>
	Public Sub New(cmd As Command)
		Me.m_command = cmd
	End Sub
End Class
''' <summary>
''' Occurs when the server had been disconnected from this client.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">The server information.</param>
Public Delegate Sub ServerDisconnectedEventHandler(sender As Object, e As ServerEventArgs)
''' <summary>
''' The class that contains information about the server.
''' </summary>
Public Class ServerEventArgs
	Inherits EventArgs
	Private socket As Socket
	''' <summary>
	''' The IP address of server.
	''' </summary>
	Public ReadOnly Property IP() As IPAddress
		Get
			Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Address
		End Get
	End Property
	''' <summary>
	''' The port of server.
	''' </summary>
	Public ReadOnly Property Port() As Integer
		Get
			Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Port
		End Get
	End Property
	''' <summary>
	''' Creates an instance of ServerEventArgs class.
	''' </summary>
	''' <param name="clientSocket">The client socket of current CommandClient instance.</param>
	Public Sub New(clientSocket As Socket)
		Me.socket = clientSocket
	End Sub
End Class

''' <summary>
''' Occurs when this client disconnected from the server.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub DisconnectedEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' Occurs when this client connected to the remote server Successfully.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub ConnectingSuccessedEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' Occurs when this client failed on connecting to server.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub ConnectingFailedEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' Occurs when the network had been failed.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub NetworkDeadEventHandler(sender As Object, e As EventArgs)

''' <summary>
''' Occurs when the network had been started to work.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">EventArgs.</param>
Public Delegate Sub NetworkAlivedEventHandler(sender As Object, e As EventArgs)

