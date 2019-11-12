Imports System.Data.SqlClient

Public Class Operations
    Private Server As String = "KARENS-PC"
    Private Catalog As String = "ForumExamples"
    Private ConnectionString As String = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True"
    Property ExceptionMessage As String
    Property HasException As Boolean
    Public Function UpdateRecord(ByVal CategoryID As Integer, ByVal CategoryName As String, ByVal CategoryShortName As String, CategoryLocked As Integer, CategoryUsed As Integer) As Boolean

        HasException = False
        Dim success As Boolean = False

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Dim sql As String =
                <SQL>
                    UPDATE tblToolCategory 
                    SET                        
                         CategoryName = @CategoryName,
                         CategoryShortName = @CategoryShortName,
                         CategoryLocked = @CategoryLocked,
                         CategoryUsed = @CategoryUsed
                    WHERE CategoryID = @CategoryID
                </SQL>.Value

            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = sql}
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName)
                cmd.Parameters.AddWithValue("@CategoryShortName", CategoryShortName)
                cmd.Parameters.AddWithValue("@CategoryLocked", CategoryLocked)
                cmd.Parameters.AddWithValue("@CategoryUsed", CategoryUsed)
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID)

                Try
                    cn.Open()
                    success = cmd.ExecuteNonQuery = 1
                Catch ex As Exception
                    success = False
                    HasException = True
                    ExceptionMessage = ex.Message
                End Try
            End Using
        End Using

        Return success
    End Function
    Public Function InsertRecord(ByRef CategoryID As Integer, ByVal CategoryName As String, ByVal CategoryShortName As String, ByVal CategoryLocked As Integer, ByVal CategoryUsed As Integer) As Boolean

        HasException = False
        Dim success As Boolean = False

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Dim sql As String =
                <SQL>
                    INSERT INTO tblToolCategory
                        (CategoryName,CategoryShortName,CategoryLocked,CategoryUsed)
                    VALUES
                        (@CategoryName,@CategoryShortName,@CategoryLocked,@CategoryUsed);
                    SELECT CAST(scope_identity() AS int);
                </SQL>.Value

            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = sql}

                cmd.Parameters.AddWithValue("@CategoryName", CategoryName)
                cmd.Parameters.AddWithValue("@CategoryShortName", CategoryShortName)
                cmd.Parameters.AddWithValue("@CategoryLocked", CategoryLocked)
                cmd.Parameters.AddWithValue("@CategoryUsed", CategoryUsed)

                Try
                    cn.Open()
                    CategoryID = CInt(cmd.ExecuteScalar)
                    success = True
                Catch ex As Exception
                    success = False
                    HasException = True
                    ExceptionMessage = ex.Message
                End Try
            End Using
        End Using

        Return success

    End Function
    Public Function GetRecords() As DataTable

        HasException = False
        Dim dt As New DataTable

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Dim sql As String =
                <SQL>
                    SELECT 
                        CategoryID, 
                        CategoryName, 
                        CategoryShortName, 
                        CAST(CategoryLocked AS INT) AS CategoryLocked, 
                        CAST(CategoryUsed AS INT)   AS CategoryUsed
                    FROM tblToolCategory
                </SQL>.Value
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = sql}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)

                    dt.Columns("CategoryLocked").ReadOnly = False
                    dt.Columns("CategoryUsed").ReadOnly = False

                Catch ex As Exception
                    ExceptionMessage = ex.Message
                    HasException = True
                End Try
            End Using
        End Using
        Return dt
    End Function

    Public Function UpdateOtherDatabase(ByVal id As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText =
                <SQL>
                    UPDATE  S
                    SET     S.FirstName = b.FirstName
                    FROM    ForumExamples.dbo.Persons1 S
                            INNER JOIN DeleteOptionDatabase.dbo.Persons1 b ON S.id = b.id
                    WHERE   S.id = @id;
                </SQL>.Value

                cmd.Parameters.AddWithValue("@id", id)
                cn.Open()
                Return cmd.ExecuteNonQuery = 1
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Run view ToolCategory
    ''' </summary>
    ''' <returns></returns>
    Public Function GetRecordsFromView() As DataTable

        HasException = False
        Dim dt As New DataTable

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SELECT * FROM ToolCategory"}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    ExceptionMessage = ex.Message
                    HasException = True
                End Try
            End Using
        End Using
        Return dt
    End Function

End Class
