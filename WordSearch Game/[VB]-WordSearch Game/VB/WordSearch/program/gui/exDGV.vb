''' <summary>
''' Extended DataGridView 
''' DoubleBuffered. Restricts user selection of cells to facilitate seamless highlighting line drawing.
''' </summary>
''' <remarks></remarks>
Public Class exDGV
    Inherits DataGridView

    Public Event WM_LBUTTONDOWN_AT(ByVal p As Point)

    Dim WM_LBUTTONDOWN As Integer = &H201
    Dim WM_LBUTTONDBLCLK As Integer = &H203
    Dim WM_KEYDOWN As Integer = &H100

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnRowPrePaint(ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
        MyBase.OnRowPrePaint(e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_LBUTTONDOWN Then
            RaiseEvent WM_LBUTTONDOWN_AT(New Point(m.LParam.ToInt32))
            Return
        ElseIf m.Msg = WM_LBUTTONDBLCLK OrElse m.Msg = WM_KEYDOWN Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub

End Class
