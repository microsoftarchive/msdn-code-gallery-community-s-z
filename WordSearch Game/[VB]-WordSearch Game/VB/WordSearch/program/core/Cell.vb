''' <summary>
''' Cell Class - 
''' Each Cell has a line index. There are 76 distinct lines used. 
''' Horizontal, vertical, and 2 diagonal. Each Cell belongs to 4 lines.
''' The Boolean available() array holds values for each cells availability
''' in any of the 4 possible directions.
''' </summary>
''' <remarks></remarks>
Public Class Cell

    Public line() As Integer = {0, 0, 0, 0}
    Public text As String
    Public available() As Boolean = {True, True, True, True}

End Class
