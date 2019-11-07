Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim databaseFileNameMdb As String = "..\..\..\Databases\Database1.mdb"
        Dim databaseFileNameAccdb As String = "..\..\..\Databases\Database1.accdb"

        Dim demo As New DataOperations(databaseFileNameMdb)
        demo.LoadCustomers()

        ListBox1.DisplayMember = "CompanyName"
        ListBox1.DataSource = demo.CustomerTable

        demo = New DataOperations(databaseFileNameAccdb)
        demo.LoadCustomers()

        ListBox2.DisplayMember = "CompanyName"
        ListBox2.DataSource = demo.CustomerTable

    End Sub
End Class
