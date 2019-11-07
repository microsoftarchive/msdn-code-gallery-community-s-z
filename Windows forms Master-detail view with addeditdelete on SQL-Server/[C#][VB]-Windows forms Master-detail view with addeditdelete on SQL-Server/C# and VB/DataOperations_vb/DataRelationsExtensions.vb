Public Module DataRelationsExtensions
    ''' <summary>
    ''' USed to create a one to many relationship for a master-detail in a DataSet.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="MasterTableName">master table</param>
    ''' <param name="ChildTableName">child table of master table</param>
    ''' <param name="MasterKeyColumn">master table primary key</param>
    ''' <param name="ChildKeyColumn">child table of master's primary key</param>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub SetRelation(ByVal sender As DataSet, ByVal MasterTableName As String, ByVal ChildTableName As String, ByVal MasterKeyColumn As String, ByVal ChildKeyColumn As String)

        sender.Relations.Add(
         New DataRelation(String.Concat(MasterTableName, ChildTableName),
            sender.Tables(MasterTableName).Columns(MasterKeyColumn),
            sender.Tables(ChildTableName).Columns(ChildKeyColumn)
         )
      )

    End Sub

End Module
