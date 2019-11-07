Module DataGridViewMethods
    <System.Diagnostics.DebuggerHidden()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub ExpandColumns(ByVal sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module
