Imports System
Imports System.Windows
Imports WindowsRecipes.TaskbarSingleInstance
Imports WindowsRecipes.TaskbarSingleInstance.Wpf

Namespace WpfSampleVB
    Module Program
        <STAThread()> _
        Sub Main()
            Using manager As SingleInstanceManager = SingleInstanceManager.Initialize(GetSingleInstanceManagerSetup())
                Dim app As New App()
                app.InitializeComponent()
                app.Run()
            End Using
        End Sub

        Private Function GetSingleInstanceManagerSetup() As SingleInstanceManagerSetup
            Return New SingleInstanceManagerSetup("WpfSampleVB") With _
            { _
                .ArgumentsHandler = Function(args As String()) DirectCast(Application.Current, App).ProcessCommandLineArgs(args), _
                .ArgumentsHandlerInvoker = New ApplicationDispatcherInvoker(), _
                .DelivaryFailureNotification = Function(ex) MessageBox.Show(ex.Message, "An error occured") _
            }
        End Function
    End Module
End Namespace
