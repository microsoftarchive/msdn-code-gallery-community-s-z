Public Class MainForm
    WithEvents bsData As New BindingSource
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As DataTable = DataAccess.GetData()

        bsData.DataSource = dt
        bsData.Sort = "LastName"
        BindingNavigator1.BindingSource = bsData
        DataGridView1.DataSource = bsData

        txtFirstName.DataBindings.Add("Text", bsData, "FirstName")
        txtLastName.DataBindings.Add("Text", bsData, "LastName")

    End Sub
    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        AddNewRecord()
    End Sub
    Private Sub AddNewRecord()
        Dim f As New frmEditForm

        Try
            f.Text = "Add new"
            f.cmdAccept.Enabled = False
            f.AddingNewRecord = True

            If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                bsData.AddPerson(f.txtFirstName.Text, f.txtLastName.Text)
            End If
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            EditCurrentRow()
        End If
    End Sub
    Private Sub cmdEditCurrentRow_Click(sender As Object, e As EventArgs) Handles cmdEditCurrentRow.Click
        EditCurrentRow()
    End Sub
    ''' <summary>
    ''' Used to edit the current record in the BindingSource
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditCurrentRow()
        If bsData.Current IsNot Nothing Then
            Dim f As New frmEditForm

            Try

                f.Text = "Editing"

                f.txtFirstName.DataBindings.Add("Text", bsData, "FirstName")
                f.txtLastName.DataBindings.Add("Text", bsData, "LastName")

                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    bsData.AcceptChanges()
                Else
                    bsData.CancelEdit()
                End If

            Finally
                f.Dispose()
            End Try
        End If
    End Sub
End Class
