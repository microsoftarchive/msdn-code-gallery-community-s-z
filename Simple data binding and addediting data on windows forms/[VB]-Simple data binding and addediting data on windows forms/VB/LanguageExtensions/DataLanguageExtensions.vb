Public Module DataLanguageExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function DataTable(ByVal sender As Windows.Forms.BindingSource) As DataTable
        Return DirectCast(sender.DataSource, DataTable)
    End Function
    ''' <summary>
    ''' Add a new person to the underlying DataTable and position
    ''' it properly to the current row of the BindingSource.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="FirstName"></param>
    ''' <param name="LastName"></param>
    ''' <returns>current row primary key</returns>
    ''' <remarks>
    ''' Like many things we first code the entire operation in this case the 
    ''' form then once it works as we want remove it from the form.
    ''' 
    ''' On the use of ProperCase, 
    '''   * We could work this w/o passing a culture code
    '''   * We could also make ProperCase available outside this project
    ''' I did both different from the norm to get those looking at this code to
    ''' think about other possibilities i.e. perhaps we truly want to force ProperCase
    ''' to English etc.
    ''' 
    ''' </remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function AddPerson(
        ByVal sender As Windows.Forms.BindingSource,
        ByVal FirstName As String,
        ByVal LastName As String) As Int32

        Dim dt As DataTable = sender.DataTable
        dt.Rows.Add(New Object() _
            {
                Nothing,
                FirstName.ProperCaseEnglish,
                LastName.ProperCaseEnglish
            }
        )

        Dim NewRowIdentifier As Int32 =
            CInt(dt.Rows.Item(dt.Rows.Count - 1) _
                .Field(Of Int32)(dt.Columns("Identifier")))

        sender.Position = sender.Find("Identifier", NewRowIdentifier)

        Return NewRowIdentifier

    End Function
    ''' <summary>
    ''' Invokes AcceptChanges for the current data row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub AcceptChanges(ByVal sender As Windows.Forms.BindingSource)
        CType(sender.Current, DataRowView).Row.AcceptChanges()
    End Sub
End Module
