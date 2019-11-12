Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices

''' <summary>
''' Used to obtain both worksheet and named range names from a valid Excel file.
''' </summary>
''' <remarks></remarks>
Public Class ExcelInfo
    Public Property LastException As Exception
    ''' <summary>
    ''' If True return only visible sheets, False all sheets
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OnlyVisibleSheets As Boolean
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
    Private mSheetsData As New Dictionary(Of Int32, String)
    Public ReadOnly Property SheetsData As Dictionary(Of Int32, String)
        Get
            Return mSheetsData
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
    ''' Retrieve worksheet and name range names.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetInformation() As Boolean
        Dim Success As Boolean = True

        If Not IO.File.Exists(FileName) Then
            Dim ex As New Exception("Failed to locate '" & FileName & "'")
            _LastException = ex
            Throw ex
        End If

        mSheets.Clear()
        mNameRanges.Clear()
        mSheetsData.Clear()


        Dim xlApp As Excel.Application = Nothing
        Dim xlWorkBooks As Excel.Workbooks = Nothing
        Dim xlWorkBook As Excel.Workbook = Nothing
        Dim xlActiveRanges As Excel.Workbook = Nothing
        Dim xlNames As Excel.Names = Nothing
        Dim xlWorkSheets As Excel.Sheets = Nothing

        Try
            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False
            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlActiveRanges = xlApp.ActiveWorkbook
            xlNames = xlActiveRanges.Names

            For x As Integer = 1 To xlNames.Count
                Dim xlName As Excel.Name = xlNames.Item(x)


                mNameRanges.Add(xlName.Name)
                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlName)
                xlName = Nothing
            Next

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                Dim Sheet1 As Excel.Worksheet = CType(xlWorkSheets(x), Excel.Worksheet)
                If OnlyVisibleSheets Then
                    If CBool(Sheet1.Visible) Then
                        mSheets.Add(Sheet1.Name)
                    Else
                        Console.WriteLine(Sheet1.Name)
                    End If
                Else
                    mSheets.Add(Sheet1.Name)
                End If
                mSheetsData.Add(x, Sheet1.Name)
                Runtime.InteropServices.Marshal.FinalReleaseComObject(Sheet1)
                Sheet1 = Nothing
            Next

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

        Catch ex As Exception
            _LastException = ex
            Success = False
        Finally

            If Not xlWorkSheets Is Nothing Then
                Marshal.FinalReleaseComObject(xlWorkSheets)
                xlWorkSheets = Nothing
            End If

            If Not xlNames Is Nothing Then
                Marshal.FinalReleaseComObject(xlNames)
                xlNames = Nothing
            End If

            If Not xlActiveRanges Is Nothing Then
                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlActiveRanges)
                xlActiveRanges = Nothing
            End If
            If Not xlActiveRanges Is Nothing Then
                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlActiveRanges)
                xlActiveRanges = Nothing
            End If

            If Not xlWorkBook Is Nothing Then
                Marshal.FinalReleaseComObject(xlWorkBook)
                xlWorkBook = Nothing
            End If

            If Not xlWorkBooks Is Nothing Then
                Marshal.FinalReleaseComObject(xlWorkBooks)
                xlWorkBooks = Nothing
            End If

            If Not xlApp Is Nothing Then
                Marshal.FinalReleaseComObject(xlApp)
                xlApp = Nothing
            End If
        End Try

        Return Success

    End Function
End Class
