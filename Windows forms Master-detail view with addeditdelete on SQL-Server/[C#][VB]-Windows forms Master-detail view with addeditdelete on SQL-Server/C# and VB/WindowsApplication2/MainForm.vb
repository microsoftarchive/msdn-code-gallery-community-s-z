Public Class MainForm
    Private bsData As New BindingSource
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New Operations
        bsData.DataSource = ops.GetRecords
        DataGridView1.DataSource = bsData
        ops.GetRecordsFromView()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If bsData.Current IsNot Nothing Then
            Dim ops As New Operations
            Dim row As DataRow = CType(bsData.Current, DataRowView).Row

            If ops.UpdateRecord(row.Field(Of Integer)("CategoryID"), row.Field(Of String)("CategoryName"), row.Field(Of String)("CategoryShortName"), row.Field(Of Integer)("CategoryLocked"), row.Field(Of Integer)("CategoryUsed")) Then
                MessageBox.Show("Updated")
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ops As New Operations
        Dim newIdentifier As Integer = 0
        Dim CategoryName As String = "Just added"
        Dim CategoryShortName As String = "Added"
        Dim Locked As Integer = 0
        Dim Used As Integer = 1

        If ops.InsertRecord(newIdentifier, CategoryName, CategoryShortName, Locked, Used) Then
            CType(bsData.DataSource, DataTable).Rows.Add(New Object() {newIdentifier, CategoryName, CategoryShortName, Locked, Used})
        Else
            MessageBox.Show("Failed to insert")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ops As New DataOperations
        If ops.ValidateUserLogin("Karen", "pass1") Then
            MessageBox.Show("Let them in")
        Else
            MessageBox.Show("Incorrect login")
        End If
    End Sub


End Class