Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Assembly.StructuralFrames
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect(True)

				' Make sure user can see the GUI.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the documents collection.
				documents = application.Documents

				Console.WriteLine("Creating a new assembly document.")

				' Create a new assembly document.
				assemblyDocument = CType(documents.Add("SolidEdge.AssemblyDocument"), SolidEdgeAssembly.AssemblyDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				AddStructuralFrame(assemblyDocument)

				Console.WriteLine("Switching to ISO view.")

				' Switch to ISO view.
				application.StartCommand(CType(SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewISOView, SolidEdgeFramework.SolidEdgeCommandConstants))
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub AddStructuralFrame(ByVal assemblyDocument As SolidEdgeAssembly.AssemblyDocument)
			Dim lineSegments As SolidEdgeAssembly.LineSegments = Nothing
			Dim lineSegment As SolidEdgeAssembly.LineSegment = Nothing
			Dim lineSegmentList As New List(Of SolidEdgeAssembly.LineSegment)()
			Dim structuralFrames As SolidEdgeAssembly.StructuralFrames = Nothing
			Dim structuralFrame As SolidEdgeAssembly.StructuralFrame = Nothing
			Dim startPoint() As Double = { 0.0, 0.0, 0.0 }
			Dim endPoint() As Double = { 0.0, 0.0, 0.5 }

			' Get a reference to the LineSegments collection.
			lineSegments = assemblyDocument.LineSegments

			' Add a new line segment.
			lineSegment = lineSegments.Add(StartPoint:= startPoint, EndPoint:= endPoint)

			' Store line segment in array.
			lineSegmentList.Add(lineSegment)

			' Get a reference to the StructuralFrames collection.
			structuralFrames = assemblyDocument.StructuralFrames

			' Build path to part file.  In this case, it is a .par from standard install.
			Dim partFilePath As String = Path.Combine(GetSolidEdgeInstallPath(), "Frames\DIN\I-Beam\I-Beam 80x46.par")

			Console.WriteLine("Adding structural frame '{0}'.", partFilePath)

			' Add new structural frame.
			structuralFrame = structuralFrames.Add(PartFileName:= partFilePath, NumPaths:= lineSegmentList.Count, Path:= lineSegmentList.ToArray())
		End Sub

		Private Shared Function GetSolidEdgeInstallPath() As String
			Dim installData As New SEInstallDataLib.SEInstallData()
			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. 
			Dim programDirectory As New DirectoryInfo(installData.GetInstalledPath())

			' Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'. 
			Dim installationDirectory As DirectoryInfo = programDirectory.Parent

			Return installationDirectory.FullName
		End Function
	End Class
End Namespace
