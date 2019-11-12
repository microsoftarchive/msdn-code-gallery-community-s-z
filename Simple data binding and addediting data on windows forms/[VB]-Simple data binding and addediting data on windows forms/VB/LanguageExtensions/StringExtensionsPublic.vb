''' <summary>
''' Code here is available to any project in the solution
''' </summary>
''' <remarks></remarks>
Public Module StringExtensionsPublic
    ''' <summary>
    ''' Used to proper case a token
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="CultureCode">i.e. English en-US, Mexico es-MX etc.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function ProperCase(ByVal sender As String, ByVal CultureCode As String) As String
        Dim TI As System.Globalization.TextInfo = New System.Globalization.CultureInfo(CultureCode, False).TextInfo
        Return TI.ToTitleCase(sender.ToLower)
    End Function
End Module
