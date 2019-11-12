''' <summary>
''' Used for displaying a shape preview
''' </summary>
Public Class ShapePreview
    Inherits DataGridView

    'constants used for ignoring DGV focussing
    Const WM_LBUTTONDOWN As Integer = &H201
    Const WM_LBUTTONDBLCLK As Integer = &H203
    Const WM_KEYDOWN As Integer = &H100

    'avoids focussing
    Protected Overrides Sub OnRowPrePaint(ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
        MyBase.OnRowPrePaint(e)
    End Sub

    'ignores focussing
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_LBUTTONDBLCLK OrElse m.Msg = WM_LBUTTONDOWN OrElse m.Msg = WM_KEYDOWN Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub

End Class
