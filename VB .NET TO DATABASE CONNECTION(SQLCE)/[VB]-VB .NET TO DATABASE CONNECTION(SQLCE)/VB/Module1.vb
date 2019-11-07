Option Explicit On
Imports System.Data.SqlServerCe

Module Module1
    Public Conn As New SqlCeConnection("Data Source=" & AppPath() & "\Database1.sdf")
    Public sqlCeCmd As New SqlCeCommand
    Public sqlCeda As New SqlCeDataAdapter
    Public sqlCeds As New DataSet
    Public sqlCedr As SqlCeDataReader

    Public Function AppPath()
        Return System.AppDomain.CurrentDomain.BaseDirectory
    End Function


    Public Sub ConnectTable(ByVal strSql As String, ByVal strTableName As String, ByVal dataGrid As DataGridView)
        sqlCeds.Clear()
        sqlCeCmd = Conn.CreateCommand
        sqlCeCmd.CommandText = strSql
        sqlCeCmd.Connection = Conn
        Conn.Open()

        sqlCeda = New SqlCeDataAdapter(sqlCeCmd)


        sqlCeda.Fill(sqlCeds, strTableName)
        dataGrid.DataSource = sqlCeds
        dataGrid.DataMember = strTableName
        Conn.Close()
    End Sub
End Module
