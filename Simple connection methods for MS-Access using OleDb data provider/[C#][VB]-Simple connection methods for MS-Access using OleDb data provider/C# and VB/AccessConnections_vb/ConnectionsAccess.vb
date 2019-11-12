Imports System.Data.OleDb

Public Module ConnectionsAccess
    Private providers As New Dictionary(Of String, String)() From {{".accdb", "Microsoft.ACE.OLEDB.12.0"}, {".mdb", "Microsoft.Jet.OLEDB.4.0"}}

    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function BuildConnectionString(ByVal DatabaseName As String) As String

        Dim Builder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder With
            {
                .Provider = providers(IO.Path.GetExtension(DatabaseName).ToLower()),
                .DataSource = DatabaseName
            }

        Return Builder.ConnectionString

    End Function
End Module
