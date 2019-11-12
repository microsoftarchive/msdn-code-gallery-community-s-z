Imports System.Collections.Generic
Imports System.Text

''' <summary>
''' The type of commands that you can sent to the server.(Note : These are just some comman types.You should do the desired actions when a command received to the client yourself.)
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
	''' This command will sent to all clients when an specific client is had been logged in to the server.The metadata of this command is in this format : "ClientIP:ClientNetworkName"
	''' </summary>
	ClientLoginInform
	''' <summary>
	''' This command will sent to all clients when an specific client is had been logged off from the server.You can get the disconnected client information from SenderIP and SenderName properties of command event args.
	''' </summary>
	ClientLogOffInform
	''' <summary>
	''' To ask from the server pass the name that you want check it's existance as meta data of command.The server will replay to you a command with the same type and MetaData of 'True' or 'False' that specifies the Network name is exists on the server or not.
	''' </summary>
	IsNameExists
	''' <summary>
	''' To get a list of current connected clients to the server,Send this type of command to it.The server will replay to you one same command for each client with the metadata in this format : "ClientIP:ClientNetworkName".
	''' </summary>
	SendClientList
	''' <summary>
	''' This is a free command that you can sent to the server.
	''' </summary>
	FreeCommand
End Enum
