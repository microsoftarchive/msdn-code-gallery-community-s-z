Imports System.Collections.Generic
Imports System.Text
Imports System.Net

''' <summary>
''' The command class.
''' </summary>
Public Class Command
	Private cmdType As CommandType
	''' <summary>
	''' The type of command to send.If you wanna use the Message command type,create a Message class instead of command.
	''' </summary>
	Public Property CommandType() As CommandType
		Get
			Return cmdType
		End Get
		Set
			cmdType = value
		End Set
	End Property

	Private m_senderIP As IPAddress
	''' <summary>
	''' [Gets/Sets] The IP address of command sender.
	''' </summary>
	Public Property SenderIP() As IPAddress
		Get
			Return m_senderIP
		End Get
		Set
			m_senderIP = value
		End Set
	End Property

	Private m_senderName As String
	''' <summary>
	''' [Gets/Sets] The name of command sender.
	''' </summary>
	Public Property SenderName() As String
		Get
			Return m_senderName
		End Get
		Set
			m_senderName = value
		End Set
	End Property

	Private m_target As IPAddress
	''' <summary>
	''' [Gets/Sets] The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.
	''' </summary>
	Public Property Target() As IPAddress
		Get
			Return m_target
		End Get
		Set
			m_target = value
		End Set
	End Property
	Private commandBody As String
	''' <summary>
	''' The body of the command.This string is different in various commands.
	''' <para>Message : The text of the message.</para>
	''' <para>ClientLoginInform,SendClientList : "RemoteClientIP:RemoteClientName".</para>
	''' <para>***WithTimer : The interval of timer in miliseconds..The default value is 60000 equal to 1 min.</para>
	''' <para>IsNameExists : 'True' or 'False'</para>
	''' <para>Otherwise pass the "" or null.</para>
	''' </summary>
	Public Property MetaData() As String
		Get
			Return commandBody
		End Get
		Set
			commandBody = value
		End Set
	End Property
	''' <summary>
	''' Creates an instance of command object to send over the network.
	''' </summary>
	''' <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
	''' <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
	''' <param name="metaData">
	''' The body of the command.This string is different in various commands.
	''' <para>Message : The text of the message.</para>
	''' <para>ClientLoginInform,SendClientList : "RemoteClientIP:RemoteClientName".</para>
	''' <para>***WithTimer : The interval of timer in miliseconds..The default value is 60000 equal to 1 min.</para>
	''' <para>IsNameExists : 'True' or 'False'</para>
	''' <para>Otherwise pass the "" or null or use the next overriden constructor.</para>
	''' </param>
	Public Sub New(type As CommandType, targetMachine As IPAddress, metaData As String)
		Me.cmdType = type
		Me.m_target = targetMachine
		Me.commandBody = metaData
	End Sub

	''' <summary>
	''' Creates an instance of command object to send over the network.
	''' </summary>
	''' <param name="type">The type of command.If you wanna use the Message command type,create a Message class instead of command.</param>
	''' <param name="targetMachine">The targer machine that will receive the command.Set this property to IPAddress.Broadcast if you want send the command to all connected clients.</param>
	Public Sub New(type As CommandType, targetMachine As IPAddress)
		Me.cmdType = type
		Me.m_target = targetMachine
		Me.commandBody = ""
	End Sub
End Class
