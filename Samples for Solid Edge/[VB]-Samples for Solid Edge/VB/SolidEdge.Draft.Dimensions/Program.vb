Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO

Namespace SolidEdge.Draft.Dimensions
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

				' Get a reference to the documents collection.
				documents = application.Documents

				' Create a new draft document.
				draftDocument = CType(documents.Add("SolidEdge.DraftDocument"), SolidEdgeDraft.DraftDocument)

				' Demonstrate dimensioning a part drawving view.
				AddPartViewAndDimension(draftDocument)

				' Demonstrate dimensioning a 2D line.
				AddLineAndDimension(draftDocument)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub AddPartViewAndDimension(ByVal draftDocument As SolidEdgeDraft.DraftDocument)
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim modelLinks As SolidEdgeDraft.ModelLinks = Nothing
			Dim modelLink As SolidEdgeDraft.ModelLink = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing
			Dim trainingDirectory As DirectoryInfo = GetTrainingDirectory()
			Dim fileName As String = Path.Combine(trainingDirectory.FullName, "2holebar.par")
			Dim dvLines2d As SolidEdgeDraft.DVLines2d = Nothing
			Dim dvLine2d As SolidEdgeDraft.DVLine2d = Nothing
			Dim dimensions As SolidEdgeFrameworkSupport.Dimensions = Nothing
			Dim dimension As SolidEdgeFrameworkSupport.Dimension = Nothing
			Dim dimStyle As SolidEdgeFrameworkSupport.DimStyle = Nothing

			' Get a reference to the active sheet.
			sheet = draftDocument.ActiveSheet

			' Get a reference to the ModelLinks collection.
			modelLinks = draftDocument.ModelLinks

			' Add a new model link.
			modelLink = modelLinks.Add(fileName)

			' Get a reference to the DrawingViews collection.
			drawingViews = sheet.DrawingViews

			' Add a new part drawing view.
			drawingView = drawingViews.AddPartView([From]:= modelLink, Orientation:= SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView, Scale:= 5.0, x:= 0.4, y:= 0.4, ViewType:= SolidEdgeDraft.PartDrawingViewTypeConstants.sePartDesignedView)

			' Get a reference to the DVLines2d collection.
			dvLines2d = drawingView.DVLines2d

			' Get the 1st drawing view 2D line.
			dvLine2d = dvLines2d.Item(1)

			' Get a reference to the Dimensions collection.
			dimensions = CType(sheet.Dimensions, SolidEdgeFrameworkSupport.Dimensions)

			' Add a dimension to the line.
			dimension = dimensions.AddLength(dvLine2d.Reference)

			' Few changes to make the dimensions look right.
			dimension.ProjectionLineDirection = True
			dimension.TrackDistance = 0.02

			' Get a reference to the dimension style.
			' DimStyle has a ton of options...
			dimStyle = dimension.Style
		End Sub

		Private Shared Sub AddLineAndDimension(ByVal draftDocument As SolidEdgeDraft.DraftDocument)
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim lines2d As SolidEdgeFrameworkSupport.Lines2d = Nothing
			Dim line2d As SolidEdgeFrameworkSupport.Line2d = Nothing
			Dim dimensions As SolidEdgeFrameworkSupport.Dimensions = Nothing
			Dim dimension As SolidEdgeFrameworkSupport.Dimension = Nothing
			Dim dimStyle As SolidEdgeFrameworkSupport.DimStyle = Nothing

			' Get a reference to the active sheet.
			sheet = draftDocument.ActiveSheet

			' Get a reference to the Lines2d collection.
			lines2d = sheet.Lines2d

			' Draw a new line.
			line2d = lines2d.AddBy2Points(x1:= 0.2, y1:= 0.2, x2:= 0.3, y2:= 0.2)

			' Get a reference to the Dimensions collection.
			dimensions = CType(sheet.Dimensions, SolidEdgeFrameworkSupport.Dimensions)

			' Add a dimension to the line.
			dimension = dimensions.AddLength(line2d)

			' Get a reference to the dimension style.
			' DimStyle has a ton of options...
			dimStyle = dimension.Style
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
