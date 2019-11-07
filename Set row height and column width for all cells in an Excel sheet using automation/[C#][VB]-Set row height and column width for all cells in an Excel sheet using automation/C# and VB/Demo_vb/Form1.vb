Public Class Form1
    Private fileName As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Demo.xlsx")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim demoCreate As New CreateExcel(fileName)
        demoCreate.CreateFileIfMissing()
        setRowColumnButton.Enabled = IO.File.Exists(fileName)
    End Sub
    Private Sub setRowColumnButton_Click(sender As Object, e As EventArgs) Handles setRowColumnButton.Click
        Dim Ops As New Operations With
            {
                .FileName = fileName,
                .SheetName = "Sheet1",
                .RowHeight = CInt(NumericUpDownRowHeight.Value),
                .ColumnHeight = CInt(NumericUpDownColumn.Value)
            }

        Dim result As OperationReasons = Ops.SetRowHeightColumnWidth()
        If result = OperationReasons.Success Then
            MessageBox.Show("Finished")
        ElseIf result = OperationReasons.FileNameFound Then
            MessageBox.Show("Failed to locate file")
        ElseIf result = OperationReasons.SheetNotFound Then
            MessageBox.Show("Failed to locate sheet")
        End If
    End Sub
End Class
