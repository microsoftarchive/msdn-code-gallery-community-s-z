''' <summary>
''' Demo custom DataGridView columns.
''' 
''' We read data, allow changing data in the DataGridView
''' but do not save back to the database because I am showing
''' custom columns. To show we can get at the data I included
''' cmdShowRow code.
''' </summary>
''' <remarks>
''' Modified from
''' http://code.msdn.microsoft.com/Show-and-edit-date-only-35444290
''' 
''' 4/17/2017 seems there was an issue with the data and has been resolved
''' at the database level, no real code changes.
''' </remarks>
Public Class Form1
    WithEvents bsData As New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New DataOperations
        bsData.DataSource = ops.GetRows()

        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsData

        ' The following is for demoing showing we can access the primary key
        Label1.DataBindings.Add("Text", bsData, "Identifier")
        DataGridView1.ExpandColumns
    End Sub
    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1(e.ColumnIndex, e.RowIndex).EditType IsNot Nothing Then
            If DataGridView1.IsCalendarCell(e) OrElse DataGridView1.IsTimeCell(e) Then
                SendKeys.Send("{F2}")
            End If
        End If
    End Sub
    Private Sub cmdShowRow_Click(sender As Object, e As EventArgs) Handles cmdShowRow.Click
        MessageBox.Show(String.Join(Environment.NewLine, CType(bsData.Current, DataRowView).Row.ItemArray))
    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class
