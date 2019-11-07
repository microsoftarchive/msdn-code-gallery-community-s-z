Public Class DataOperations
    Private Builder As New OleDb.OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0",
            .DataSource = IO.Path.Combine(Application.StartupPath, "Database1.accdb")
        }
    Public Function GetRows() As DataTable
        Dim dt As New DataTable

        Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = Builder.ConnectionString
                }

            Using cmd As New OleDb.OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier, RoomNumber, CheckIn, CheckOut FROM Table1 "
                cn.Open()
                dt.Load(cmd.ExecuteReader)
            End Using
        End Using

        Return dt

    End Function
End Class
