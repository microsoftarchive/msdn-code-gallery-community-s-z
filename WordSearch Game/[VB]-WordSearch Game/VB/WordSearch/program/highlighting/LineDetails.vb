''' <summary>
''' An instance of this is used as a record of all details of a highlighted word in the dgv.
''' </summary>
''' <remarks></remarks>
Public Class LineDetails

    Public startCell As Point
    Public endCell As Point
    Public allCells As List(Of Point)
    Public linePen As Pen
    Public listIndex As Integer

    Public Sub New(ByVal startCell As Point, ByVal endCell As Point, ByVal linePen As Pen, ByVal allCells As List(Of Point), ByVal listIndex As Integer)
        Me.startCell = startCell
        Me.endCell = endCell
        Me.linePen = linePen
        Me.allCells = allCells
        Me.listIndex = listIndex
    End Sub

    Public Shadows Function ToString(ByVal dgv As DataGridView) As String
        If allCells.Any(Function(p) p.X < 0 Or p.Y < 0) Then Return Nothing
        Return String.Join("", Array.ConvertAll(allCells.ToArray, Function(p) dgv(p.X, p.Y).Value.ToString))
    End Function

End Class
