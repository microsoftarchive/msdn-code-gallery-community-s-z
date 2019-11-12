Option Strict On
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices
''' <summary>
''' Provides a method to set all row height and column width for an entire sheet.
''' </summary>
''' <remarks></remarks>
Public Class Operations
    ''' <summary>
    ''' File name to work with
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName As String
    ''' <summary>
    ''' Sheet name to work with
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SheetName As String
    ''' <summary>
    ''' Value to set all row's heights
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RowHeight As Integer
    ''' <summary>
    ''' Value to set all column widths
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ColumnHeight As Integer

    Public Sub New()

    End Sub
    Public Sub New(ByVal FileName As String, ByVal SheetName As String, ByVal RowHeight As Integer, ByVal ColumnHeight As Integer)
        Me.FileName = FileName
        Me.SheetName = SheetName
        Me.RowHeight = RowHeight
        Me.ColumnHeight = ColumnHeight
    End Sub
    Public Function SetRowHeightColumnWidth() As OperationReasons
        If IO.File.Exists(FileName) Then
            Dim SheetNotLocated As Boolean = False

            Dim Proceed As Boolean = False

            Dim xlApp As Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim xlWorkSheets As Excel.Sheets = Nothing
            Dim xlCells As Excel.Range = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False


            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Open(FileName)

            xlApp.Visible = False

            xlWorkSheets = xlWorkBook.Sheets

            For x As Integer = 1 To xlWorkSheets.Count
                xlWorkSheet = CType(xlWorkSheets(x), Excel.Worksheet)

                If xlWorkSheet.Name = SheetName Then
                    Proceed = True
                    Exit For
                End If

                Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet)
                xlWorkSheet = Nothing

            Next

            If Proceed Then
                xlCells = xlWorkSheet.Cells
                Dim EntireRow As Excel.Range = xlCells.EntireRow
                EntireRow.RowHeight = RowHeight
                EntireRow.ColumnWidth = ColumnHeight

                ReleaseComObject(xlCells)
                ReleaseComObject(EntireRow)
            Else
                SheetNotLocated = True
            End If

            xlWorkSheet.SaveAs(FileName)

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

            ReleaseComObject(xlWorkSheets)
            ReleaseComObject(xlWorkSheet)
            ReleaseComObject(xlWorkBook)
            ReleaseComObject(xlWorkBooks)
            ReleaseComObject(xlApp)
            If SheetNotLocated Then
                Return OperationReasons.SheetNotFound
            Else
                Return OperationReasons.Success
            End If
        Else
            Return OperationReasons.FileNameFound
        End If

    End Function
    ''' <summary>
    ''' Clean up objects
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Private Sub ReleaseComObject(ByVal obj As Object)
        Try
            If obj IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            End If
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
End Class
Public Enum OperationReasons
    ''' <summary>
    ''' Operation was sucessful
    ''' </summary>
    ''' <remarks></remarks>
    Success
    ''' <summary>
    ''' File does not exists
    ''' </summary>
    ''' <remarks></remarks>
    FileNameFound
    ''' <summary>
    ''' Sheet does not exists
    ''' </summary>
    ''' <remarks></remarks>
    SheetNotFound
End Enum
