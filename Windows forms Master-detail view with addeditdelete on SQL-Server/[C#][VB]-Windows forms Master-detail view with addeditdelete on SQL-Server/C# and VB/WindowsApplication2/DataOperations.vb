Imports System.Data.OleDb

Public Class DataOperations
    Private Builder As New OleDbConnectionStringBuilder With
    {
        .Provider = "Microsoft.ACE.OLEDB.12.0",
        .DataSource = IO.Path.Combine(Application.StartupPath, "0Database1.accdb")
    }

    Public Function ValidateUserLogin(ByVal userName As String, ByVal userPassword As String) As Boolean
        Dim success As Boolean = False

        Using cn As New OleDbConnection With {.ConnectionString = Builder.ConnectionString}
            Using cmd As New OleDbCommand("SELECT COUNT(1) FROM pengguna WHERE NAMA_USER = @UserName AND [PASSWORD] = @UserPassword", cn)
                cmd.Parameters.AddWithValue("@UserName", userName)
                cmd.Parameters.AddWithValue("@UserPassword", userPassword)
                cn.Open()

                Try
                    success = CInt(cmd.ExecuteScalar) = 1

                Catch ex As Exception
                    success = False
                End Try
            End Using

        End Using

        Return success

    End Function
End Class
