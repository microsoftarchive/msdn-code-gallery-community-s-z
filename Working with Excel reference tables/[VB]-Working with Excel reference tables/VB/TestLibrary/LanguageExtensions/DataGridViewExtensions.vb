Module DataGridViewExtensions
    ''' <summary>
    ''' Generates comma delimited rows into a string array.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <Runtime.CompilerServices.Extension()> _
    Public Function ExportRows(ByVal sender As DataGridView, ByVal EmptyValue As String) As String()
        Return _
            (
                From row In sender.Rows
                Where Not DirectCast(row, DataGridViewRow).IsNewRow
                Let RowItem = String.Join(",",
                Array.ConvertAll(DirectCast(row, DataGridViewRow).Cells.Cast(Of DataGridViewCell).ToArray,
                    Function(c As DataGridViewCell) _
                        If(String.IsNullOrWhiteSpace(c.Value.ToString), EmptyValue, c.Value.ToString)))
                Select RowItem
            ).ToArray
    End Function
End Module
