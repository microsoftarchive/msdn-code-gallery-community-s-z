''' <summary>
''' An instance of the NewGame Class is used as a return value from the Game Class' createNew function.
''' letterGrid is a 15 by 15 String array containing the 225 characters used in a new game.
''' wordList is a String array containing the 25 words used in a new game.
''' </summary>
''' <remarks></remarks>
Public Class NewGame

    Public letterGrid()() As String
    Public wordList() As String

    Public Sub New(ByVal letterGrid()() As String, ByVal wordList() As String)
        Me.letterGrid = letterGrid
        Me.wordList = wordList
    End Sub

End Class
