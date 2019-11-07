Imports System.Data.SqlClient
''' <summary>
''' Responsible for retrieving data just inserted from PersonExporter.PersonExporter method
''' which in turn is presented in a child form to display and/or modify the data.
''' </summary>
Public Class DataOperations
    Private ConnectionString As String = "Data Source=KARENS-PC;Initial Catalog=BulkCopyDatabaseCodeSample;Integrated Security=True"
    '        
    '         * Note TOP 8, this will wipe out all but 8 records in the merge operation so if you want
    '         * to see all 5,000 records affected remove the TOP 8 clause. If you leave "as is" you can
    '         * remove it then run the code again to re-populate the initial 5,000 plus records.
    '         
    Private selectQuery As String = "SELECT TOP 8 Id,FirstName,LastName,Gender,BirthDay FROM BulkCopyDatabaseCodeSample.dbo.Person"
    Public Function GetPeople() As DataTable
        Dim dt = New DataTable()
        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand() With {.Connection = cn, .CommandText = selectQuery}
                cn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        Return dt
    End Function
End Class
