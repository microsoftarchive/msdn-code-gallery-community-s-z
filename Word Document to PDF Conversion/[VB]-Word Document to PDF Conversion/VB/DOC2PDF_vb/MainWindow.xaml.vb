
Imports System.Windows
Imports Microsoft.Office.Interop.Word
Imports System.Windows.Forms

Partial Public Class MainWindow
    Inherits System.Windows.Window
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As RoutedEventArgs)
        Dim dlg As New Microsoft.Win32.OpenFileDialog()

        ' Set filter for file extension and default file extension
        dlg.DefaultExt = ".doc"
        dlg.Filter = "Word documents (.doc)|*.docx;*.doc"

        ' Display OpenFileDialog by calling ShowDialog method
        Dim result As Nullable(Of Boolean) = dlg.ShowDialog()

        ' Get the selected file name and display in a TextBox
        If result = True Then
            ' Open document
            Dim filename As String = dlg.FileName
            FileNameTextBox.Text = filename
        End If
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As RoutedEventArgs)
        Dim appWord As New Microsoft.Office.Interop.Word.Application()
        wordDocument = appWord.Documents.Open(FileNameTextBox.Text)
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "PDF Documents|*.pdf"
        Try
            If sfd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim ext As String = System.IO.Path.GetExtension(sfd.FileName)
                Select Case ext
                    Case ".pdf"
                        wordDocument.ExportAsFixedFormat(sfd.FileName, WdExportFormat.wdExportFormatPDF)
                        pdfFileName.Text = sfd.FileName
                        Exit Select
                        'case ".docx":
                        '    wordDocument.ExportAsFixedFormat(sfd.FileName, WdExportFormat.wdExportFormatPDF);
                        '    break;
                End Select
            End If
            System.Windows.Forms.MessageBox.Show("File Converted Successfully..")
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        System.Diagnostics.Process.Start(sfd.FileName)
    End Sub

    Public Property wordDocument() As Microsoft.Office.Interop.Word.Document
        Get
            Return m_wordDocument
        End Get
        Set(value As Microsoft.Office.Interop.Word.Document)
            m_wordDocument = value
        End Set
    End Property
    Private m_wordDocument As Microsoft.Office.Interop.Word.Document
End Class

