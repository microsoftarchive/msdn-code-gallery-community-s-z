Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Net.Sockets

''' <summary>
''' Occurs when a command received from a client.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">The received command object.</param>
Public Delegate Sub CommandReceivedEventHandler(sender As Object, e As CommandEventArgs)

''' <summary>
''' Occurs when a command had been sent to the remote client successfully.
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
''' The class that contains information about received command.
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
''' Occurs when a remote client had been disconnected from the server.
''' </summary>
''' <param name="sender">Sender.</param>
''' <param name="e">The client information.</param>
Public Delegate Sub DisconnectedEventHandler(sender As Object, e As ClientEventArgs)
''' <summary>
''' Client event args.
''' </summary>
Public Class ClientEventArgs
	Inherits EventArgs
	Private socket As Socket
	''' <summary>
	''' The ip address of remote client.
	''' </summary>
	Public ReadOnly Property IP() As IPAddress
		Get
			Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Address
		End Get
	End Property
	''' <summary>
	''' The port of remote client.
	''' </summary>
	Public ReadOnly Property Port() As Integer
		Get
			Return DirectCast(Me.socket.RemoteEndPoint, IPEndPoint).Port
		End Get
	End Property
	''' <summary>
	''' Creates an instance of ClientEventArgs class.
	''' </summary>
	''' <param name="clientManagerSocket">The socket of server side socket that comunicates with the remote client.</param>
	Public Sub New(clientManagerSocket As Socket)
		Me.socket = clientManagerSocket
	End Sub
End Class
