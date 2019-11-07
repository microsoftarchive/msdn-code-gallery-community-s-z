Imports System.Data.Common
Imports System.Reflection


' For SQLite  download/install below providers or choose different framework...please read readme.htm file after installation ..
'             https://system.data.sqlite.org/downloads/1.0.104.0/sqlite-netFx20-setup-bundle-x64-2005-1.0.104.0.exe
'             https://system.data.sqlite.org/downloads/1.0.104.0/sqlite-netFx20-setup-x86-2005-1.0.104.0.exe
'             http://webbo.sourceforge.net/tut_aspnet_sqlite.php     
Class DataCommon

    Private gedSQLTimeOut As Integer = CInt(System.Configuration.ConfigurationManager.AppSettings.Item("SQLTimeout"))
    Private _connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connection").ConnectionString
    Private _providerName As String = System.Configuration.ConfigurationManager.ConnectionStrings("connection").ProviderName

    Private conn As System.Data.Common.DbConnection
    Private _commandDB As DbCommand


    Property connectionString As String
        Get
            Return _connectionString
        End Get

        Set(value As String)
            _connectionString = value
        End Set

    End Property

    Property providerName As String
        Get
            Return _providerName
        End Get

        Set(value As String)
            _providerName = value
        End Set

    End Property


    ''' <summary>
    ''' When you read - you create Connection and Command - return DBCommand (provider will be bring from web.config)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property commandDB As DbCommand
        Get
            conn = CreateDbConnection()
            _commandDB = conn.CreateCommand
            _commandDB.CommandTimeout = gedSQLTimeOut
            Return _commandDB
        End Get
    End Property

    ' Given a provider name and connection string, 
    ' create the DbProviderFactory and DbConnection.
    ' Returns a DbConnection on success; null on failure.

    Private Function CreateDbConnection(Optional ByRef strError As String = "") As DbConnection
        ' Assume failure.
        conn = Nothing
        strError = ""

        ' Create the DbProviderFactory and DbConnection.
        If _connectionString IsNot Nothing Then
            Try
                Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(_providerName)

                conn = factory.CreateConnection()
                conn.ConnectionString = _connectionString
            Catch ex As Exception
                ' Set the connection to null if it was created.
                If conn IsNot Nothing Then
                    conn = Nothing
                End If
                strError = ex.Message
            End Try
        End If
        ' Return the connection.
        Return conn
    End Function


    ''' <summary>
    '''  Just send DBCommand, see "ReadOnly Property commandDB As DbCommand" , other optional parameters ....
    ''' </summary>
    ''' <param name="cmd"></param>
    ''' <param name="comType"></param>
    ''' <param name="parameters"></param>
    ''' <param name="strError"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExecuteSqlNonQuery(ByVal cmd As DbCommand, Optional comType As CommandType = CommandType.Text, Optional parameters As Dictionary(Of String, Object) = Nothing, Optional ByRef strError As String = "") As Integer

        Dim intEffected As Integer = -1  ' Depends from DataBase

        Try
            conn = cmd.Connection
            conn.Open()
            'Catch ex As Exception
            '    strError = ex.Message
            '    CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ", cmd.CommandText)
            '    Return intEffected
        Finally
        End Try

        Try
            cmd.CommandType = comType
            ' If procedure Dictionary should not be Nothing
            If Not parameters Is Nothing Then
                cmd.Parameters.Clear()     ' WE MUST CLEAR HERE PARAMETERS
                If parameters.Count > 0 Then
                    SetCmd(cmd, parameters)
                End If
            End If

            intEffected = cmd.ExecuteNonQuery()

            'Catch ex As Exception
            'CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ", cmd.CommandText)
            'strError = ex.Message
            'intEffected = -1
        Finally
            conn.Close()
        End Try
        Return intEffected   ' Depends from DataBase

    End Function

    ''' <summary>
    ''' Just send DBCommand, see "ReadOnly Property commandDB As DbCommand" , other optional parameters ....
    ''' </summary>
    ''' <param name="cmd"></param>
    ''' <param name="comType"></param>
    ''' <param name="parameters"></param>
    ''' <param name="strError"></param>
    ''' <param name="intEffected"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataSet(ByVal cmd As DbCommand, Optional comType As CommandType = CommandType.Text, Optional parameters As Dictionary(Of String, Object) = Nothing, Optional ByRef strError As String = "", Optional ByRef intEffected As Integer = 0) As DataSet
        intEffected = -1
        strError = ""

        Try
            conn = cmd.Connection
            conn.Open()
            'Catch ex As Exception
            '    strError = ex.Message
            '    Return Nothing
        Finally
        End Try

        Dim dataSet As New DataSet()
        Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(_providerName)

        Try
            'System.Data.Common.DbCommand
            Dim dbAdapter As DbDataAdapter = factory.CreateDataAdapter()

            cmd.CommandType = comType
            ' If PROCEDURE -> Dictionary should not be Nothing
            If Not parameters Is Nothing Then
                cmd.Parameters.Clear()     ' WE MUST CLEAR HERE PARAMETERS
                If parameters.Count > 0 Then
                    SetCmd(cmd, parameters)
                End If
            Else
                cmd.Parameters.Clear()     'DISTLER - added this b/c was using previous parameters when current call had 0
            End If

            dbAdapter.SelectCommand = cmd
            dbAdapter.FillLoadOption = LoadOption.PreserveChanges
            intEffected = dbAdapter.Fill(dataSet)

            'conn.Close()
            'Catch ex As Exception
            'strError = ex.Message
            ''conn.Close()
            'CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ", cmd.CommandText)
        Finally
            conn.Close()
        End Try
        Return dataSet

    End Function


    Public Function GetOneValue(ByVal cmd As DbCommand, Optional comType As CommandType = CommandType.Text, Optional parameters As Dictionary(Of String, Object) = Nothing, Optional ByRef strError As String = "", Optional ByRef intEffected As Integer = 0) As String
        intEffected = -1
        strError = ""

        Try
            conn = cmd.Connection
            conn.Open()
            'Catch ex As Exception
            'CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ", cmd.CommandText)
            'strError = ex.Message
            'Return Nothing
        Finally
        End Try

        Dim dataSet As New DataSet()
        Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(_providerName)

        Try
            'System.Data.Common.DbCommand
            Dim dbAdapter As DbDataAdapter = factory.CreateDataAdapter()

            cmd.CommandType = comType
            ' If PROCEDURE -> Dictionary should not be Nothing
            If Not parameters Is Nothing Then
                cmd.Parameters.Clear()     ' WE MUST CLEAR HERE PARAMETERS
                If parameters.Count > 0 Then
                    SetCmd(cmd, parameters)
                End If
            End If

            dbAdapter.SelectCommand = cmd
            dbAdapter.FillLoadOption = LoadOption.PreserveChanges
            intEffected = dbAdapter.Fill(dataSet)

            'conn.Close()
            'Catch ex As Exception
            '    CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ", cmd.CommandText)
            '    strError = ex.Message
        Finally
            conn.Close()
        End Try

        Dim strReturn As String = Nothing
        Try
            strReturn = dataSet.Tables(0).Rows(0)(0).ToString
            'Catch ex As Exception
            '    CQICommon.SendErrorEmail(ex, ex.StackTrace & " " & HttpContext.Current.Request.Url.AbsolutePath & "/" & "/" & "DISTLJ")
        Finally
        End Try

        Return strReturn

    End Function

    Private Sub SetCmd(ByRef cmd As DbCommand, parameters As Dictionary(Of String, Object))   ' MUST USE ByRef

        For Each pair In parameters
            Dim param = cmd.CreateParameter
            param.ParameterName = pair.Key
            param.Value = pair.Value
            cmd.Parameters.Add(param)
        Next
    End Sub

    Public Function TestConnection(ByRef strError As String) As Boolean
        strError = ""
        Try
            conn = CreateDbConnection(strError)
            conn.Open()
            conn.Close()
            Return True
        Catch ex As Exception
            strError = ex.Message
            Return False
        End Try
    End Function


    Public Sub closeConnection()
        ' Use it if you need to brake long RUN;
        Try
            conn.Close()
            'Catch
        Finally
        End Try
    End Sub

End Class

