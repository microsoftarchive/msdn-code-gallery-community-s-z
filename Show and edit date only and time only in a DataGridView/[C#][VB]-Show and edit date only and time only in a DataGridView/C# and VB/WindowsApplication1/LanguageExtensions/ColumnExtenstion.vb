Imports WindowsApplication1.UserControls

Module ColumnExtenstion
    <Runtime.CompilerServices.Extension()>
    <DebuggerStepThrough()>
    Function IsCalendarCell(ByVal GridView As DataGridView, ByVal e As DataGridViewCellEventArgs) As Boolean
        Return TypeOf GridView.Columns(e.ColumnIndex) Is CalendarColumn AndAlso Not e.RowIndex = -1
    End Function
    <Runtime.CompilerServices.Extension()>
    <DebuggerStepThrough()>
    Function IsTimeCell(ByVal GridView As DataGridView, ByVal e As DataGridViewCellEventArgs) As Boolean
        Return TypeOf GridView.Columns(e.ColumnIndex) Is TimeColumn AndAlso Not e.RowIndex = -1
    End Function
End Module
