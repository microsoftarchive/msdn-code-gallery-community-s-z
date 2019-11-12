''' <summary>
''' Custom form used to show graphical progress when creating a new WordSearch.
''' </summary>
''' <remarks></remarks>
Public Class frmProgress

    Dim label As String
    Dim labelPosition As Point
    Private WithEvents tmr As New Timer With {.Interval = 750}

    Public Sub New(ByVal owner As Form, ByVal max As Integer, ByVal caption As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.Location = New Point(owner.Left + CInt((owner.Width - Me.Width) / 2), owner.Top + CInt((owner.Height - Me.Height) / 2))

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = caption
        ProgressBar1.Maximum = max
    End Sub

    Public Sub performStep()
        ProgressBar1.PerformStep()
        label = (ProgressBar1.Value * (100 / ProgressBar1.Maximum)).ToString & "% complete"
        labelPosition = New Point(ProgressBar1.Left + CInt((ProgressBar1.Width - TextRenderer.MeasureText(label, Me.Font).Width) / 2), ProgressBar1.Top - 15)
        ProgressBar1.Refresh()
        Me.Refresh()
        Application.DoEvents()
        If ProgressBar1.Value = ProgressBar1.Maximum Then tmr.Enabled = True
    End Sub

    Private Sub frmProgress_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawString(label, Me.Font, Brushes.Black, labelPosition)
    End Sub

    Private Sub tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmr.Tick
        tmr.Enabled = False
        Me.Close()
    End Sub

End Class