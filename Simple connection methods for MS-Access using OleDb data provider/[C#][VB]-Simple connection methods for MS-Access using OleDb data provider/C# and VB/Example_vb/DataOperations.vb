Imports System.Data.OleDb
Imports AccessConnections_vb
Public Class DataOperations
    Private fileName As String = ""
    Public Sub New(ByVal databaseFileName As String)
        fileName = databaseFileName
        CustomerTable = New DataTable
    End Sub
    Public Property CustomerTable As DataTable
    Public Sub LoadCustomers()
        Using cn As New OleDbConnection With {.ConnectionString = fileName.BuildConnectionString}
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT CompanyName FROM Customer;"
                Dim dt As New DataTable With {.TableName = "Customer"}
                cn.Open()
                CustomerTable.Load(cmd.ExecuteReader)
            End Using
        End Using
    End Sub
End Class
