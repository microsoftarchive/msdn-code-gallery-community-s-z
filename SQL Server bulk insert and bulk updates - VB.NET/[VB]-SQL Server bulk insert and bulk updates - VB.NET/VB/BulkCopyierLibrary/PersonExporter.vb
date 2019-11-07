Imports System.Data.SqlClient
''' <summary>
''' Responsible for bulk and merge operations
''' </summary>
Public Class PersonExporter
    Public Exception As New ErrorInformation()
    Public List As List(Of Person)
    Public Property BatchSize() As Integer

    Private ConnectionString As String = "Data Source=KARENS-PC;Initial Catalog=BulkCopyDatabaseCodeSample;Integrated Security=True"
    ''' <summary>
    ''' Set BatchSize to a default of 100
    ''' </summary>
    ''' <param name="pList">List of person</param>
    Public Sub New(ByVal pList As List(Of Person))
        List = pList
        BatchSize = 100
    End Sub
    ''' <summary>
    ''' </summary>
    ''' <param name="pList">List of person</param>
    ''' <param name="pBatchSize">A value to indicate when to write data to the backend database</param>
    Public Sub New(ByVal pList As List(Of Person), ByVal pBatchSize As Integer)
        List = pList
        BatchSize = pBatchSize

    End Sub
    ''' <summary>
    ''' Simple bulk copy with no column mappings as in this case the fields in
    ''' Person class names and data types are a match to the table in the database.
    ''' 
    ''' If an exception is thrown, the caller can check Exception property of this
    ''' class for the exception message.
    ''' </summary>
    ''' <param name="pReset">Passing true will empty the current table's data while not passing a value will not empty the tables content</param>
    ''' <returns>Success of the operation</returns>
    Public Function Execute(Optional ByVal pReset As Boolean = False) As Boolean
        Dim success As Boolean = True
        Using cn As SqlConnection = New SqlConnection With {.ConnectionString = ConnectionString}
            cn.Open()

            If pReset Then
                Using cmd As New SqlCommand() With {.Connection = cn}
                    ' allows us to start fresh :-)
                    cmd.CommandText = "TRUNCATE TABLE Person"
                    cmd.ExecuteNonQuery()
                End Using
            End If

            Dim transaction As SqlTransaction = cn.BeginTransaction()

            Using sbc = New SqlBulkCopy(cn, SqlBulkCopyOptions.Default, transaction)

                ' you should tinker with this in your project
                sbc.BatchSize = BatchSize
                sbc.DestinationTableName = "Person"

                Try
                    sbc.WriteToServer(List.AsDataTable())
                Catch ex As Exception

                    transaction.Rollback()
                    cn.Close()

                    Exception.HasError = True
                    Exception.Message = ex.Message
                    success = False
                End Try
            End Using

            transaction.Commit()
        End Using

        Return success
    End Function
    Public Sub UpdateData(ByVal pDt As DataTable)
        Using cn As New SqlConnection() With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand("", cn)
                Try
                    cn.Open()

                    'Creating temp table on database which is used them removed after the merge
                    cmd.CommandText =
                        <SQL>
                            CREATE TABLE #TmpPersonTable(
                                [Id] [INT],
                                [FirstName] [TEXT] NULL,
                                [LastName] [TEXT] NULL,
                                [Gender] [INT] NULL,[BirthDay] [DATETIME2](7) NULL)
                        </SQL>.Value

                    cmd.ExecuteNonQuery()

                    'Bulk insert into temp table
                    Using bulkcopy As New SqlBulkCopy(cn)
                        ' you should tinker with this in your project
                        bulkcopy.BulkCopyTimeout = 660
                        bulkcopy.DestinationTableName = "#TmpPersonTable"
                        bulkcopy.WriteToServer(pDt)
                        bulkcopy.Close()
                    End Using

                    ' you should tinker with this in your project
                    cmd.CommandTimeout = 300

                    cmd.CommandText =
                        <SQL>
                            MERGE INTO dbo.Person AS P
                            USING dbo.#TmpPersonTable AS S
                            ON P.Id = S.Id
                            WHEN MATCHED THEN
                                UPDATE SET P.FirstName = S.FirstName ,
                                           P.LastName = S.LastName ,
                                           P.Gender = S.Gender ,
                                           P.BirthDay = S.BirthDay
                            WHEN NOT MATCHED THEN
                                INSERT ( FirstName ,
                                         LastName ,
                                         Gender ,
                                         BirthDay
                                       )
                                VALUES ( S.FirstName ,
                                         S.LastName ,
                                         S.Gender ,
                                         S.BirthDay
                                       )
                            WHEN NOT MATCHED BY SOURCE THEN
                                DELETE;
                            DROP TABLE #TmpPersonTable
                        </SQL>.Value

                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    Exception.HasError = True
                    Exception.Message = ex.Message
                Finally
                    cn.Close()
                End Try
            End Using
        End Using
    End Sub
End Class


