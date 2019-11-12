Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private printFont As Font
    Private totalLineCount As Integer

    Public Sub New()
        ' The Windows Forms Designer requires the following call.
        InitializeComponent()
    End Sub

    Private Sub CloseButton_Click(sender As System.Object, e As System.EventArgs) Handles CloseButton.Click
        End
    End Sub

    Private Sub PrintButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrintButton.Click
        Try
            Try
                If RichTextBox1.Lines.Length < 1 Then
                    MessageBox.Show("No Data to Print", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                totalLineCount = 0
                printFont = New Font("Arial", 10)
                Dim printDoc As New PrintDocument()
                AddHandler printDoc.PrintPage, AddressOf Me.printDoc_PrintPage
                printDoc.Print()
            Finally
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim curLineCount As Integer = 0
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)

        ' Print each line of the file. 
        While curLineCount < linesPerPage
            If (RichTextBox1.Lines.Length - 1) < totalLineCount Then
                line = Nothing
                Exit While
            End If
            line = RichTextBox1.Lines(totalLineCount)
            yPos = topMargin + curLineCount * printFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())
            curLineCount += 1
            totalLineCount += 1
        End While

        ' If more lines exist, print another page. 
        If (line IsNot Nothing) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

End Class