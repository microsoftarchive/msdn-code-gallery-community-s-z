Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SheetMetal.SaveAsFlat
	''' <summary>
	''' Console application that demonstrates how to save a SheetMetal document as flat.
	''' </summary>
	''' <param name="args"></param>
	''' <remarks>FanPlate.psm from training folder was used to create this example.</remarks>
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim sheetMetalDocument As SolidEdgePart.SheetMetalDocument = Nothing
			Dim flatPatternModels As SolidEdgePart.FlatPatternModels = Nothing
			Dim flatPatternModel As SolidEdgePart.FlatPatternModel = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim face As SolidEdgeGeometry.Face = Nothing
			Dim edge As SolidEdgeGeometry.Edge = Nothing
			Dim vertex As SolidEdgeGeometry.Vertex = Nothing
			Dim useFlatPattern As Boolean = True
			Dim flatPatternIsUpToDate As Boolean = False
			Dim outFile As String = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to Solid Edge,
				application = SolidEdgeUtils.Connect(False)

				' Make sure user can see the GUI.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the documents collection.
				documents = application.Documents

				' This check is necessary because application.ActiveDocument will throw an
				' exception if no documents are open...
				If documents.Count > 0 Then
					' Attempt to open specified SheetMetalDocument.
					sheetMetalDocument = TryCast(application.ActiveDocument, SolidEdgePart.SheetMetalDocument)
				End If

				If sheetMetalDocument Is Nothing Then
					Throw New System.Exception("No active Sheet Metal document.")
				End If

				' Get a reference to the Models collection,
				models = sheetMetalDocument.Models

				' Check for geometry.
				If models.Count = 0 Then
					Throw New System.Exception("No geometry defined.")
				End If

				' Get a reference to the one and only model.
				model = models.Item(1)

				' Get a reference to the FlatPatternModels collection,
				flatPatternModels = sheetMetalDocument.FlatPatternModels

				' Observation: SaveAsFlatDXFEx() will fail if useFlatPattern is specified and
				' flatPatternModels.Count = 0.
				' The following code will turn off the useFlatPattern switch if flatPatternModels.Count = 0.
				If useFlatPattern Then
					If flatPatternModels.Count > 0 Then
						For i As Integer = 1 To flatPatternModels.Count
							flatPatternModel = flatPatternModels.Item(i)
							flatPatternIsUpToDate = flatPatternModel.IsUpToDate

							' If we find one that is up to date, call it good and bail.
							If flatPatternIsUpToDate Then
								Exit For
							End If
						Next i

						If flatPatternIsUpToDate = False Then
							' Flat patterns exist but are out of date.
							useFlatPattern = False
						End If
					Else
						' Can't use flat pattern if none exist.
						useFlatPattern = False
					End If
				End If

				Console.WriteLine("Determining desired face, edge & vertex for SaveAsFlatDXFEx().")

				' Some routine to get face, edge & vertex.
				GetFaceEdgeVertexForModel(model, face, edge, vertex)

				outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".dxf")
				'outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".par");
				'outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".psm");

				' Observation: If .par or .psm is specified in outFile, SE will open the file.
				' Even if useFlatPattern = true, it's a good idea to specify defaults for face, edge & vertex.
				' I've seen where outFile of .dxf would work but .psm would fail if the defaults were null;
				Console.WriteLine("Saving '{0}'.", outFile)
				models.SaveAsFlatDXFEx(outFile, face, edge, vertex, useFlatPattern)

				If useFlatPattern Then
					Console.WriteLine("Saved '{0}' using Flat Pattern.", outFile)
				Else
					Console.WriteLine("Saved '{0}' without using Flat Pattern.", outFile)
				End If
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		' In a real world scenario, you would want logic (or user input) to pick the desired
		' face, edge & *vertex. Here, we just grab the 1st we can find. *Vertex can be null.
		Private Shared Sub GetFaceEdgeVertexForModel(ByVal model As SolidEdgePart.Model, ByRef face As SolidEdgeGeometry.Face, ByRef edge As SolidEdgeGeometry.Edge, ByRef vertex As SolidEdgeGeometry.Vertex)
			Dim body As SolidEdgeGeometry.Body = Nothing
			Dim faces As SolidEdgeGeometry.Faces
			Dim edges As SolidEdgeGeometry.Edges = Nothing

			' Get a reference to the model's body.
			body = CType(model.Body, SolidEdgeGeometry.Body)

			' Query for all faces in the body.
			faces = CType(body.Faces(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll), SolidEdgeGeometry.Faces)

			' Get a reference to the first face.
			face = CType(faces.Item(1), SolidEdgeGeometry.Face)

			' Get a reference to the face's Edges collection,
			edges = CType(face.Edges, SolidEdgeGeometry.Edges)

			' Get a reference to the first edge.
			edge = CType(edges.Item(1), SolidEdgeGeometry.Edge)

			' Not using vertex in this example.
			vertex = Nothing
		End Sub
	End Class
End Namespace
