Option Strict On
Option Infer On

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports System.Runtime.InteropServices

Public Class CreateExcel
    Public Property FileName As String
    Public Sub New(ByVal fileName As String)
        Me.FileName = fileName
    End Sub
    Public Sub CreateFileIfMissing()

        If Not IO.File.Exists(FileName) Then

            Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
            Dim xlWorkBooks As Excel.Workbooks = Nothing
            Dim xlWorkBook As Excel.Workbook = Nothing

            xlApp = New Excel.Application
            xlApp.DisplayAlerts = False

            xlWorkBooks = xlApp.Workbooks
            xlWorkBook = xlWorkBooks.Add()

            xlWorkBook.SaveAs(FileName)

            xlWorkBook.Close()
            xlApp.UserControl = True
            xlApp.Quit()

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
        End If
    End Sub
End Class
