Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Diagnostics

NotInheritable Class Program
	Private Sub New()
	End Sub
	''' <summary>
	''' The main entry point for the application.
	''' </summary>
    <STAThread()> _
    Friend Shared Sub Main()
        Process.Start("C:\ChatPackage\CommandServer\CommandServer\ConsoleServer.ConvertedToVBNET\bin\debug\ConsoleServer.exe")
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New frmMain())
    End Sub
End Class
