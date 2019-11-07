
''' <summary>
''' The SQL database is copied new each time this project runs
''' so run it, add rows, close, run and the first run's rows added
''' will not be there because of the Copy to output directory is set
''' to allows. Feel free to change to copy if newer.
''' </summary>
''' <remarks></remarks>
Public Class Form1
    WithEvents bsCustomers As New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IO.File.Exists(FileOperations.DatabaseLocation(My.Settings.ConnectionString)) Then
            cmdAddNewRow.Enabled = False
            MessageBox.Show("Failed to find database")
        Else
            Dim DataOps As New DataOperations
            bsCustomers.DataSource = DataOps.GetCustomers
            DataGridView1.DataSource = bsCustomers
            DataGridView1.ExpandColumns()
            bsCustomers.Sort = "CompanyName"
            ActiveControl = txtCompanyName
        End If

    End Sub

    Private Sub cmdAddNewRow_Click(sender As Object, e As EventArgs) Handles cmdAddNewRow.Click
        If Not String.IsNullOrWhiteSpace(txtCompanyName.Text) Then
            Dim DataOps As New DataOperations
            Dim NewId As Integer = 0
            If DataOps.AddNewCustomer(txtCompanyName.Text, NewId) Then
                CType(bsCustomers.DataSource, DataTable).Rows.Add(New Object() {NewId, txtCompanyName.Text})
                bsCustomers.Position = bsCustomers.Find("Identifier", NewId)
            Else
                MessageBox.Show("Failed to add new company")
            End If
        Else
            MessageBox.Show("Enter data into the textbox to add a row")
            ActiveControl = txtCompanyName
        End If
    End Sub
End Class
