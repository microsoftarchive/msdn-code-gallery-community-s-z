
''' <summary>
''' Throw when the remote server not found.
''' </summary>
Public Class ServerNotFoundException
	Inherits Exception
	''' <summary>
	''' Creates an instance of ServerNotFoundException class.
	''' </summary>
	''' <param name="message">The message to show to the user.</param>
	Public Sub New(message As String)
		MyBase.New(message)
	End Sub
End Class
