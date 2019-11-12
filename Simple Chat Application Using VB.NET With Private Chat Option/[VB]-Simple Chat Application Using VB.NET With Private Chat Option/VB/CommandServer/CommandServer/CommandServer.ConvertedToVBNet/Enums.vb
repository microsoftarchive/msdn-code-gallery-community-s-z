Imports System.Collections.Generic
Imports System.Text

''' <summary>
''' The type of commands that you can sent to the clients.(Note : These are just some comman types.You should do the desired actions when a command received to the client yourself.)
''' </summary>
Public Enum CommandType
	''' <summary>
	''' Force the target to logoff from the application without prompt.Pass null or "" as command's Metadata.
	''' </summary>
	UserExit
	''' <summary>
	''' Force the target to logoff from the application with prompt.Pass the timer interval of logoff action as command's Metadata in miliseconds.For example "20000".
	''' </summary>
	UserExitWithTimer
	''' <summary>
	''' Force the target PC to LOCK without prompt.Pass null or "" as command's Metadata.
	''' </summary>
	PCLock
	''' <summary>
	''' Force the target PC to LOCK with prompt.Pass the timer interval of LOCK action as command's Metadata in miliseconds.For example "20000".
	''' </summary>
	PCLockWithTimer
	''' <summary>
	''' Force the target PC to RESTART without prompt.Pass null or "" as command's Metadata.
	''' </summary>
	PCRestart
	''' <summary>
	''' Force the target PC to RESTART with prompt.Pass the timer interval of RESTART action as command's Metadata in miliseconds.For example "20000".
	''' </summary>
	PCRestartWithTimer
	''' <summary>
	''' Force the target PC to LOGOFF without prompt.Pass null or "" as command's Metadata.
	''' </summary>
	PCLogOFF
	''' <summary>
	''' Force the target PC to LOGOFF with prompt.Pass the timer interval of LOGOFF action as command's Metadata in miliseconds.For example "20000".
	''' </summary>
	PCLogOFFWithTimer
	''' <summary>
	''' Force the target PC to SHUTDOWN without prompt.Pass null or "" as command's Metadata.
	''' </summary>
	PCShutDown
	''' <summary>
	''' Force the target PC to SHUTDOWN with prompt.Pass the timer interval of SHUTDOWN action as command's Metadata in miliseconds.For example "20000".
	''' </summary>
	PCShutDownWithTimer
	''' <summary>
	''' Send a text message to the server.Pass the body of text message as command's Metadata.
	''' </summary>
	Message
	''' <summary>
	''' This command will sent to all clients when an specific client is had been logged in to the server.The metadata of this command is in this format : "RemoteClientIP:RemoteClientName"
	''' </summary>
	ClientLoginInform
	''' <summary>
	''' This command will sent to all clients when an specific client is had been logged off from the server.
	''' </summary>
	ClientLogOffInform
	''' <summary>
	''' This command will send to the new connected client with MetaData of 'True' or 'False' in replay to the same command that client did sent to the server as a question.
	''' </summary>
	IsNameExists
	''' <summary>
	''' This command will send to the new connected client with MetaData in "RemoteClientIP:RemoteClientName" format in replay to the same command that client did sent to the server as a request.
	''' </summary>
	SendClientList
	''' <summary>
	''' This is a free command that you can sent to the clients.
	''' </summary>
	FreeCommand
End Enum
