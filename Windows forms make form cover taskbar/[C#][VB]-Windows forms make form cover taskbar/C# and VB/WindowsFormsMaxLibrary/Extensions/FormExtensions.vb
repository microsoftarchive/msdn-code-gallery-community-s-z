Imports System.Windows.Forms
Public Module FormExtensions
    Private Declare Function SetWindowPos Lib "user32.dll" _
        Alias "SetWindowPos" (ByVal hWnd As IntPtr,
                              ByVal hWndIntertAfter As IntPtr,
                              ByVal X As Integer,
                              ByVal Y As Integer,
                              ByVal cx As Integer,
                              ByVal cy As Integer,
                              ByVal uFlags As Integer) As Boolean

    Private HWND_TOP As IntPtr = IntPtr.Zero
    Private Const SWP_SHOWWINDOW As Integer = 64

    ''' <summary>
    ''' Place form into full screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="TaskBar">True to hide Windows TaskBar</param>
    ''' <remarks>
    ''' Showing this task bar may not work fully but that is not the
    ''' point here, the point is to cover the task bar with a option
    ''' to expose it is secondary.
    ''' </remarks>
    <Runtime.CompilerServices.Extension()>
    Public Sub FullScreen(ByVal sender As Form, ByVal TaskBar As Boolean)

        sender.WindowState = FormWindowState.Maximized
        sender.FormBorderStyle = FormBorderStyle.None
        sender.TopMost = True

        If TaskBar Then

            SetWindowPos(sender.Handle, HWND_TOP, 0, 0,
                         Screen.PrimaryScreen.Bounds.Width,
                         Screen.PrimaryScreen.Bounds.Height,
                         SWP_SHOWWINDOW
            )

        End If

    End Sub
    ''' <summary>
    ''' Restore to original size/position
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    <Runtime.CompilerServices.Extension()>
    Public Sub NormalMode(ByVal sender As Form)
        sender.WindowState = FormWindowState.Normal
        sender.FormBorderStyle = FormBorderStyle.FixedSingle
        sender.TopMost = True
    End Sub
End Module
