Imports Microsoft.Office.Interop
Public Enum ResultReason
    ''' <summary>
    ''' Okay to use lists
    ''' </summary>
    ''' <remarks></remarks>
    Success
    ''' <summary>
    ''' Failed to open Excel file
    ''' </summary>
    ''' <remarks></remarks>
    FailedToOpenFile
    ''' <summary>
    ''' Internal error from Excel automation
    ''' </summary>
    ''' <remarks></remarks>
    ExcelInternalFailure
End Enum
''' <summary>
''' 
''' </summary>
''' <remarks>
''' This was a trick devil in regards to releasing objects but
''' has been done without making any calls to the GC.
''' </remarks>
Public Class ExcelInfo
    Private Extensions As String() = {".xls", ".xlsx"}
    Private mFileName As String
    ''' <summary>
    ''' Valid/existing Excel file name to work with.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName() As String
        Get
            Return mFileName
        End Get
        Set(ByVal value As String)
            If Not Extensions.Contains(IO.Path.GetExtension(value.ToLower)) Then
                Throw New Exception("Invalid file name")
            End If

            mFileName = value
        End Set
    End Property
    Private mReferenceTables As List(Of ExcelReferenceTable)
    ''' <summary>
    ''' List of reference tables
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ReferenceTables As List(Of ExcelReferenceTable)
        Get
            Return mReferenceTables
        End Get
    End Property
    Private mNameRanges As New List(Of String)
    ''' <summary>
    ''' List of named ranges in current file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NameRanges() As List(Of String)
        Get
            Return mNameRanges
        End Get
    End Property
    Private mSheets As New List(Of String)
    ''' <summary>
    ''' List of work sheets in current file
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Sheets() As List(Of String)
        Get
            Return mSheets
        End Get
    End Property

    Public Sub New()
    End Sub
    ''' <summary>
    ''' File to get information from
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks>
    ''' The caller is responsible to ensure the file exists.
    ''' </remarks>
    Public Sub New(ByVal FileName As String)
        Me.FileName = FileName
    End Sub
    ''' <summary>
    ''' Get information and return success
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetInformation() As ResultReason
        Dim Success As ResultReason = ResultReason.Success

        mSheets.Clear()
        mNameRanges.Clear()
        If mReferenceTables IsNot Nothing Then
            mReferenceTables.Clear()
        End If

        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBooks As Excel.Workbooks = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlSheet As Excel.Worksheet = Nothing
        Dim xlWorkSheets As Excel.Sheets = Nothing

        Try
            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks

            Try
                xlWorkBook = xlWorkBooks.Open(FileName)
            Catch ex As Exception
                Success = ResultReason.FailedToOpenFile
            End Try

            xlWorkSheets = xlWorkBook.Sheets

            Dim xlRangeNames As Excel.Name = Nothing
            Try
                For Each xlRangeNames In xlWorkBook.Names
                    mNameRanges.Add(xlRangeNames.Name)
                Next
            Finally
                ReleaseComObject(xlRangeNames)
            End Try

            For x As Int32 = 1 To xlWorkSheets.Count
                xlSheet = CType(xlWorkBook.Sheets(x), Excel.Worksheet)
                mSheets.Add(xlSheet.Name)
            Next

            GetReferenceTables(xlWorkSheets)
            ReleaseComObject(xlWorkSheets)
            xlWorkBook.Close()

            xlApp.UserControl = True
            xlApp.Quit()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Success = ResultReason.ExcelInternalFailure
        Finally
            ReleaseComObject(xlSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlApp)
        End Try

        Return Success

    End Function
    ''' <summary>
    ''' Get reference tables
    ''' </summary>
    ''' <param name="xlWorkSheets"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' One of those time I needed to call the GC to force objects to release.
    ''' </remarks>
    Private Function GetReferenceTables(ByVal xlWorkSheets As Excel.Sheets) As List(Of ExcelReferenceTable)
        Dim Result As New List(Of ExcelReferenceTable)
        Dim Temp As String = ""
        Dim xlWorkSheet As Excel.Worksheet = Nothing
        Dim xlListObjects As Excel.ListObjects = Nothing
        Dim ThisItem As Excel.ListObject = Nothing

        For x As Integer = 1 To xlWorkSheets.Count
            Dim Item As New ExcelReferenceTable

            xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)
            xlListObjects = xlWorkSheet.ListObjects

            Dim TotalCount As Int32 = xlListObjects.Count - 1
            For y As Integer = 0 To TotalCount

                ThisItem = xlListObjects.Item(y + 1)
                Item.Name = ThisItem.Name
                Item.SheetName = xlWorkSheet.Name

                ' TODO: Need to tinker with this.
                Try
                    Dim QT As Excel.QueryTable = ThisItem.QueryTable
                    Item.SourceDataFile = QT.SourceDataFile
                    ReleaseComObject(QT)
                Catch ex As Exception
                    Item.SourceDataFile = ""
                End Try

                Dim ThisRange As Excel.Range = ThisItem.Range
                Temp = ThisRange.Address

                Item.Address = Temp.Replace("$", "")

                Result.Add(Item)

                Runtime.InteropServices.Marshal.FinalReleaseComObject(ThisRange)
                ThisRange = Nothing

                Runtime.InteropServices.Marshal.FinalReleaseComObject(ThisItem)
                ThisItem = Nothing

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlListObjects)
                xlListObjects = Nothing

            Next
        Next

        releaseObject(xlWorkSheet)

        mReferenceTables = Result

        Return Result

    End Function
End Class
