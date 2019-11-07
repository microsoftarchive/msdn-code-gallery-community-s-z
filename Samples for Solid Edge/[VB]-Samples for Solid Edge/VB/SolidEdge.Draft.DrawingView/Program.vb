Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO

Namespace SolidEdge.Draft.DrawingView
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing

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

				' Get a reference to the Documents collection.
				documents = application.Documents

				' Create a new draft document.
				draftDocument = CType(documents.Add("SolidEdge.DraftDocument"), SolidEdgeDraft.DraftDocument)

				AddPartView(draftDocument)

				AddAssemblyView(draftDocument)

			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub AddPartView(ByVal draftDocument As SolidEdgeDraft.DraftDocument)
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim modelLinks As SolidEdgeDraft.ModelLinks = Nothing
			Dim modelLink As SolidEdgeDraft.ModelLink = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing
			Dim trainingDirectory As DirectoryInfo = GetTrainingDirectory()
			Dim fileName As String = Path.Combine(trainingDirectory.FullName, "2holebar.par")

			' Get a reference to the active sheet.
			sheet = draftDocument.ActiveSheet

			' Get a reference to the ModelLinks collection.
			modelLinks = draftDocument.ModelLinks
			'2holebar.par
			modelLink = modelLinks.Add(fileName)

			drawingViews = sheet.DrawingViews

			drawingView = drawingViews.AddPartView([From]:= modelLink, Orientation:= SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView, Scale:= 5.0, x:= 0.4, y:= 0.4, ViewType:= SolidEdgeDraft.PartDrawingViewTypeConstants.sePartDesignedView)
		End Sub

		Private Shared Sub AddAssemblyView(ByVal draftDocument As SolidEdgeDraft.DraftDocument)
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim modelLinks As SolidEdgeDraft.ModelLinks = Nothing
			Dim modelLink As SolidEdgeDraft.ModelLink = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing
			Dim trainingDirectory As DirectoryInfo = GetTrainingDirectory()
			Dim fileName As String = Path.Combine(trainingDirectory.FullName, "Coffee Pot.asm")

			' Get a reference to the active sheet.
			sheet = draftDocument.ActiveSheet

			' Get a reference to the ModelLinks collection.
			modelLinks = draftDocument.ModelLinks
			'2holebar.par
			modelLink = modelLinks.Add(fileName)

			drawingViews = sheet.DrawingViews

			drawingView = drawingViews.AddAssemblyView([From]:= modelLink, Orientation:= SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView, Scale:= 1.0, x:= 0.4, y:= 0.2, ViewType:= SolidEdgeDraft.AssemblyDrawingViewTypeConstants.seAssemblyDesignedView)
		End Sub

		Private Shared Function GetTrainingDirectory() As DirectoryInfo
			' Create a new instance of SEInstallData object. 
			Dim installData As New SEInstallDataLib.SEInstallData()

			' Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. 
			Dim programDirectory As New DirectoryInfo(installData.GetInstalledPath())

			' Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'. 
			Dim trainingDirectory As New DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Training"))

			Return trainingDirectory
		End Function
	End Class
End Namespace
