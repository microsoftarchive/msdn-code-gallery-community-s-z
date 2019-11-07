Imports System.IO
Imports ComponentPro.Compression
Imports ComponentPro.Diagnostics

Namespace ArchiveManager
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New ArchiveManager())
		End Sub
	End Class
End Namespace