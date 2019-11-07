''' <summary>
''' Printer Utilities Class
''' Prints scaled dgv and listbox.
''' </summary>
''' <remarks></remarks>
Public Class Printer

    Private Shared WithEvents pd As New Printing.PrintDocument
    Private Shared ppd As New PrintPreviewDialog
    Private Shared gameImage As Bitmap

    Public Shared Sub print(ByVal dgv As DataGridView, ByVal lb As ListBox)
        gameImage = New Bitmap(36 + CInt(dgv.Width * 1.5) + CInt(lb.Width * 1.5), 24 + CInt(lb.Height * 1.5))
        Dim gr As Graphics = Graphics.FromImage(gameImage)
        gr.Clear(Color.White)

        Dim tempImage As New Bitmap(24 + dgv.Width + lb.Width, 16 + lb.Height)
        gr = Graphics.FromImage(tempImage)
        gr.Clear(Color.White)

        dgv.DrawToBitmap(tempImage, New Rectangle(8, 8, dgv.Width, dgv.Height))
        lb.DrawToBitmap(tempImage, New Rectangle(16 + dgv.Width, 8, lb.Width, lb.Height))

        gr = Graphics.FromImage(gameImage)
        gr.DrawImage(tempImage, New Rectangle(Point.Empty, gameImage.Size), New Rectangle(Point.Empty, tempImage.Size), GraphicsUnit.Pixel)

        ppd.WindowState = FormWindowState.Maximized
        ppd.Document = pd
        ppd.ShowDialog()
    End Sub

    Private Shared Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        e.Graphics.DrawImage(gameImage, pd.DefaultPageSettings.PrintableArea.Location)
    End Sub

End Class
