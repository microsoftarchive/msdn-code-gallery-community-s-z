''' <summary>
''' Used to store information about data in an Excel file
''' </summary>
''' <remarks>
''' If it bothers you that read/write properties should be read-only
''' feel free to make them read-only.
''' </remarks>
Public Class ExcelReferenceTable
    Public Property Name As String
    Public Property SheetName As String
    Public Property Address As String
    Public ReadOnly Property SelectString As String
        Get
            Return "SELECT * FROM [" & SheetName & "$" & Address & "]"
        End Get
    End Property
    Public Property SourceDataFile As String
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub New()
    End Sub
    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
