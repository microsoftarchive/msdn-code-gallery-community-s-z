Imports System.Text
Imports System.Globalization
Imports System.IO

Namespace SolidEdge.InstallData
	''' <summary>
	''' This program demonstrates how to use the Solid Edge Install Data API (SEInstallDataLib.dll).
	''' </summary>
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Try
				' Create a new instance of SEInstallData object. 
				Dim installData As New SEInstallDataLib.SEInstallData()

				' Beware: installData.GetVersion() appends 'x64' to end of string if x64 installation! 
				' This comes from HKEY_LOCAL_MACHINE\SOFTWARE\Unigraphics Solutions\Solid Edge\Version XXX\CurrentVersion\Build 

				' Solid Edge version 
				Dim version As New Version(installData.GetMajorVersion(), installData.GetMinorVersion(), installData.GetServicePackVersion(), installData.GetBuildNumber())

				' Parasolid version 
				Dim parasolidVersion As New Version(installData.GetParasolidMajorVersion(), installData.GetParasolidMinorVersion())

				' Solid Edge language.  i.e. 'English', 'German', etc. 
				Dim cultureInfo As New CultureInfo(installData.GetLanguageID())

				' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. 
				Dim programDirectory As New DirectoryInfo(installData.GetInstalledPath())

				' Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'. 
				Dim installationDirectory As DirectoryInfo = programDirectory.Parent

				' Get path to Solid Edge template directory.  Typically, 'C:\Program Files\Solid Edge XXX\Template'. 
				Dim templateDirectory As New DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Template"))

				' Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'. 
				Dim trainingDirectory As New DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Training"))

				' Output info to screen.
				Console.WriteLine("Language: '{0}'", cultureInfo)
				Console.WriteLine("Version: '{0}'", version)
				Console.WriteLine("VersionString: '{0}'", installData.GetVersion())
				Console.WriteLine("ParasolidVersion: '{0}'", parasolidVersion)
				Console.WriteLine("InstallFolderPath: '{0}'", installationDirectory.FullName)
				Console.WriteLine("ProgramFolderPath: '{0}'", programDirectory.FullName)
				Console.WriteLine("TemplateFolderPath: '{0}'", templateDirectory.FullName)
				Console.WriteLine("TrainingFolderPath: '{0}'", trainingDirectory.FullName)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
