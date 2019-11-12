Imports System.Data.SqlClient

Public Class DataOperations
    Private CustomerDataTable As DataTable
    Public Function GetCustomers() As DataTable
        Return CustomerDataTable
    End Function
    Public Sub New()
        Me.CustomerDataTable = New DataTable
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier, CompanyName FROM [Customer]"
                cn.Open()
                Me.CustomerDataTable.Load(cmd.ExecuteReader)
            End Using
        End Using
    End Sub
    Public Function AddNewCustomer(ByVal Name As String, ByRef NewIdentifier As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "INSERT INTO [Customer] (CompanyName) VALUES (@CompanyName); SELECT CAST(scope_identity() AS int);"
                cmd.Parameters.AddWithValue("@CompanyName", Name)
                cn.Open()
                Try
                    NewIdentifier = CInt(cmd.ExecuteScalar)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function
    Public Function ReadSingleField(ByVal CompanyName As String) As Integer
        Dim Identifier As Integer = 0
        Using cn As New SqlConnection With {.ConnectionString = My.Settings.ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier FROM [Customer] WHERE CompanyName=@CompanyName"
                cmd.Parameters.AddWithValue("@CompanyName", CompanyName)
                cn.Open()
                Identifier = CInt(cmd.ExecuteScalar)
            End Using
        End Using

        Return Identifier

    End Function
End Class
