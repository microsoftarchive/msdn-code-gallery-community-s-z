Imports System
Imports System.Diagnostics
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports MS.WindowsAPICodePack.Internal

Namespace WpfSampleVB
    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>
    Partial Public Class App
        Inherits Application
        Private taskbarManager As TaskbarManager = taskbarManager.Instance

        Friend Sub CreateJumpList()
            If CoreHelpers.RunningOnWin7 Then
                Dim cmdPath As String = Assembly.GetEntryAssembly().Location
                Dim jumpList As JumpList = jumpList.CreateJumpList()

                Dim category As New JumpListCustomCategory("Status Change")
                category.AddJumpListItems( _
                    New JumpListLink(cmdPath, Status.Online.ToString()) With {.Arguments = Status.Online.ToString()}, _
                    New JumpListLink(cmdPath, Status.Away.ToString()) With {.Arguments = Status.Away.ToString()}, _
                    New JumpListLink(cmdPath, Status.Busy.ToString()) With {.Arguments = Status.Busy.ToString()})
                jumpList.AddCustomCategories(category)

                jumpList.Refresh()
            End If
        End Sub

        Friend Function ProcessCommandLineArgs(ByVal args As String())
            Dim color As Color = Colors.White
            Dim icon As System.Drawing.Icon = Nothing
            Dim accesibilityText As String = Nothing

            Try
                If args.Length >= 2 Then
                    Select Case DirectCast([Enum].Parse(GetType(Status), args(1)), Status)
                        Case Status.Online
                            color = Colors.Green
                            icon = My.Resources.Green
                            accesibilityText = Status.Online.ToString()
                            Exit Select
                        Case Status.Away
                            color = Colors.Yellow
                            icon = My.Resources.Yellow
                            accesibilityText = Status.Away.ToString()
                            Exit Select
                        Case Status.Busy
                            color = Colors.Red
                            icon = My.Resources.Red
                            accesibilityText = Status.Busy.ToString()
                            Exit Select
                        Case Else
                            Debug.Assert(False, "Shoult not be here")
                            Exit Select
                    End Select
                End If
            Catch generatedExceptionName As ArgumentException
                Debug.Assert(False, [String].Format("Wrong command line parameter: {0}", args(1)))
            End Try

            If icon IsNot Nothing Then
                If CoreHelpers.RunningOnWin7 Then
                    taskbarManager.SetOverlayIcon(icon, accesibilityText)
                End If

                DirectCast(MainWindow, MainWindow).SetColor(color)
            End If
            MainWindow.Activate()

            Return Nothing
        End Function
    End Class
End Namespace
