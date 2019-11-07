Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Win32
Imports System.Data

Class MainWindow

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim FileDialog As New System.Windows.Forms.OpenFileDialog
        FileDialog.Title = "Select A File"
        FileDialog.InitialDirectory = ""
        FileDialog.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png"
        FileDialog.FilterIndex = 1

        If FileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FileDialog.FileName()
            Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim)
            Dim bmp As New BitmapImage(New Uri(TextBox1.Text.Trim))
            image1.Source = bmp
        Else
            Label1.Content = "You didn't select any image file...."
        End If
    End Sub

    Public Function GetFileNameNoExt(FilePathFileName As String) As String
        On Error Resume Next
        Dim i As Integer, J As Integer, k As Integer
        i = Len(FilePathFileName)
        J = InStrRev(FilePathFileName, "\")
        k = InStrRev(FilePathFileName, ".")
        If k = 0 Then
            GetFileNameNoExt = Mid$(FilePathFileName, J + 1, i - J)
        Else
            GetFileNameNoExt = Mid$(FilePathFileName, J + 1, k - J - 1)
        End If

    End Function

    Private Sub SaveImage_Click(sender As Object, e As RoutedEventArgs) Handles SaveImage.Click
        Dim Stream As FileStream
        Dim Reader As StreamReader
        Stream = New FileStream(TextBox1.Text, FileMode.Open, FileAccess.Read)
        Reader = New StreamReader(Stream)
        Dim ImgData(Stream.Length - 1) As Byte
        Stream.Read(ImgData, 0, Stream.Length - 1)
        
        Using db As New dbtestEntities()
            Dim o As imageinfo = db.imageinfoes.Create()
            o.Name = GetFileNameNoExt(TextBox1.Text)
            o.ImgData = ImgData
            db.imageinfoes.Add(o)
            db.SaveChanges()
        End Using

        Label1.Content = GetFileNameNoExt(TextBox1.Text.Trim) & " Stored Successfully...."
    End Sub
End Class
