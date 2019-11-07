Imports Microsoft.Office.Interop
'to imports this library
'click menu "project" -> "your project properties" -> references -> add -> browse
'and add it, it's usually exist in this folder
'C:\Program Files\Microsoft Visual Studio 9.0\Visual Studio Tools for Office\PIA\Office12
'and select this library: Microsoft.Office.Interop.Excel.dll

Public Class Form1
    Dim Book As Excel.Workbook
    Dim Sheet As Excel.Worksheet
    Dim AppExcel As New Excel.Application
    Dim ExcelFileName As String
    Dim CellRow As Integer
    Dim DGV_import_export As DataGridView

    Private Sub TxtTotalColumns_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalColumns.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        BtnReadExcel_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnWriteExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWriteExcel.Click
        If DGV_import_export Is Nothing Then
            MsgBox("there are no data to export")
            Exit Sub
        End If

        Sheet = New Excel.Worksheet
        AppExcel = New Excel.Application

        ExportDGV_toExcel(DGV_import_export)
    End Sub
    Private Sub BtnReadExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReadExcel.Click

        If Val(TxtTotalColumns.Text.Trim) < 1 Then
            MessageBox.Show("please enter a valid number for the total of columns" & Chr(13) & _
                            "you want to read from the Excel file!")
            With TxtTotalColumns
                .SelectAll()
                .Focus()
            End With
            Exit Sub
        End If

        If Not OpenAnExistExcelFile() Then Exit Sub

        SetNewMisson()

        Book = AppExcel.Workbooks.Open(ExcelFileName)
        Sheet = Book.Sheets(1)

        ImportExcelSheetToDGV(DGV_import_export, Val(TxtTotalColumns.Text.Trim))

        AppExcel.Quit() 'close Excel application

    End Sub

    Private Sub SetNewMisson()
        'clear old data
        For Each item As Object In PnlDGV.Controls
            If TypeOf (item) Is DataGridView Then
                CType(item, DataGridView).Dispose()
            End If
        Next

        Sheet = New Excel.Worksheet
        AppExcel = New Excel.Application

    End Sub
    Private Function OpenAnExistExcelFile() As Boolean
        Dim OFD As New OpenFileDialog
        With OFD
            .Title = "Open Excel file"
            .Filter = "File (*.xlsx)|*.xlsx|(*.xls)|*.xls"
            .Multiselect = False
            .ShowDialog()

            If .FileName = "" Then GoTo r_false
            ExcelFileName = .FileName

            .RestoreDirectory = True
        End With

r_true:
        Return True : Exit Function
r_false:
        Return False
    End Function

    Private Sub ImportExcelSheetToDGV(ByVal _dgvToImportTo As DataGridView, ByVal ColTotal As Byte)
        Dim ColIdx As Byte
        Dim RowIdx, TotalLinesXls As Short

        Try
            DGV_import_export = New DataGridView

            Book = AppExcel.Workbooks.Open(ExcelFileName)
            Sheet = Book.Sheets(1)

        Catch ex As Exception

        End Try

        Try
            With Sheet 'calculate how many lines in the Excel file
                TotalLinesXls = 2
                Do While Sheet.Range("A" & Trim(TotalLinesXls.ToString)).Value.ToString <> ""
                    System.Windows.Forms.Application.DoEvents()
                    TotalLinesXls += 1
                Loop
            End With

        Catch ex As Exception
        End Try

        TotalLinesXls -= 1

StartImport:

        With DGV_import_export
            PnlDGV.Controls.Add(DGV_import_export)

            Dim ColHeader As Char

            For ColCounter As Byte = 1 To ColTotal
                ' Add columns
                ColHeader = Chr(ColCounter + 64).ToString.Trim 'A,B,C, ...

                .Columns.Add("", Sheet.Range(ColHeader & "1").Value) 'A1. B1, C1, ...
            Next

            If TotalLinesXls < 2 Then
                MsgBox("no lines found in this Excel file")
                GoTo EndMession
            Else
                .Rows.Add(TotalLinesXls - 1)
            End If


            .PerformLayout()

            Dim CellCou As Integer = 1

            For RowIdx = 2 To TotalLinesXls
                ' Read lines
                For ColIdx = 1 To ColTotal
                    System.Windows.Forms.Application.DoEvents()
                    If Not (Sheet.Range(Chr(ColIdx + 64) & RowIdx).Value) Is Nothing Then
                        .Item(ColIdx - 1, RowIdx - 2).Value = Sheet.Range(Chr(ColIdx + 64) & RowIdx).Value.ToString
                    End If
                    CellCou += 1

                Next
            Next
            .Columns(.ColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Dock = DockStyle.Fill

        End With
EndMession:
        Try
            AppExcel.Quit()
        Catch ex_error As Exception
            MsgBox(ex_error.Message)
        End Try
    End Sub
    Private Sub ExportDGV_toExcel(ByVal _dgv As DataGridView)

        Dim ColCou As Byte

        Try
            AppExcel.Visible = False
            Book = AppExcel.Workbooks.Add()
            Sheet = Book.Sheets(1)
        Catch ex As Exception

        End Try
        Try

            For _count As Short = 0 To _dgv.ColumnCount - 1
                If _dgv.Columns(_count).Visible Then
                    Sheet.Range(Chr(ColCou + 65) & "1").Value = _dgv.Columns(_count).HeaderText 'first row 
                    ColCou += 1
                End If
            Next


            Dim RowDGV As Short
            For RowXls = 2 To _dgv.RowCount + 1
                ColCou = 0
                For Col As Byte = 0 To _dgv.ColumnCount - 1
                    If _dgv.Columns(Col).Visible Then

                        System.Windows.Forms.Application.DoEvents()
                        Sheet.Range(Chr(ColCou + 65) & RowDGV + 2).Value = _dgv.Item(Col, RowXls - 2).Value

                        ColCou += 1
                    End If
                Next
                RowDGV += 1
            Next

SetupSheet:
            ColCou = 0

            Try
                Do While Not (Sheet.Range(Chr(ColCou + 65) & "1").Value Is Nothing)
                    With Sheet.Range(Chr(ColCou + 65) & "1") 'first row 
                        .Font.Size = 14
                        .Font.Bold = True
                        .Font.ColorIndex = 5 'blue --- 2: white, 3: red ... etc
                        ColCou += 1
                    End With
                Loop

                Sheet.Columns.AutoFit()
            Catch ex As Exception

            End Try

            AppExcel.Visible = True
            Exit Sub
        Catch ex As Exception
        End Try

    End Sub

    
End Class
