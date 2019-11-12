Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Part.FaceRotates
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim partDocument As SolidEdgePart.PartDocument = Nothing

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

				Console.WriteLine("Creating a new part document.")

				' Create a new part document.
				partDocument = CType(documents.Add("SolidEdge.PartDocument"), SolidEdgePart.PartDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				Console.WriteLine("Creating geometry.")

				' Create geometry.
				CreateFiniteExtrudedProtrusion(partDocument)

				Console.WriteLine("Creating face rotate by points.")

				' Create face rotate by points.
				CreateFaceRotateByPoints(partDocument)

				Console.WriteLine("Creating face rotate by geometry.")

				' Create face rotate by geometry.
				CreateFaceRotateByGeometry(partDocument)

				Console.WriteLine("Switching to ISO view.")

				' Switch to ISO view.
				application.StartCommand(CType(SolidEdgeConstants.PartCommandConstants.PartViewISOView, SolidEdgeFramework.SolidEdgeCommandConstants))
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub CreateFiniteExtrudedProtrusion(ByVal partDocument As SolidEdgePart.PartDocument)
			Dim profileSets As SolidEdgePart.ProfileSets = Nothing
			Dim profileSet As SolidEdgePart.ProfileSet = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim refplanes As SolidEdgePart.RefPlanes = Nothing
			Dim relations2d As SolidEdgeFrameworkSupport.Relations2d = Nothing
			Dim relation2d As SolidEdgeFrameworkSupport.Relation2d = Nothing
			Dim lines2d As SolidEdgeFrameworkSupport.Lines2d = Nothing
			Dim line2d As SolidEdgeFrameworkSupport.Line2d = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim aProfiles As System.Array = Nothing

			' Get a reference to the profile sets collection.
			profileSets = partDocument.ProfileSets

			' Add a new profile set.
			profileSet = profileSets.Add()

			' Get a reference to the profiles collection.
			profiles = profileSet.Profiles

			' Get a reference to the ref planes collection.
			refplanes = partDocument.RefPlanes

			' Add a new profile.
			profile = profiles.Add(refplanes.Item(3))

			' Get a reference to the lines2d collection.
			lines2d = profile.Lines2d

			' UOM = meters.
			Dim lineMatrix(,) As Double = { {0, 0, 0.08, 0}, {0.08, 0, 0.08, 0.06}, {0.08, 0.06, 0.064, 0.06}, {0.064, 0.06, 0.064, 0.02}, {0.064, 0.02, 0.048, 0.02}, {0.048, 0.02, 0.048, 0.06}, {0.048, 0.06, 0.032, 0.06}, {0.032, 0.06, 0.032, 0.02}, {0.032, 0.02, 0.016, 0.02}, {0.016, 0.02, 0.016, 0.06}, {0.016, 0.06, 0, 0.06}, {0, 0.06, 0, 0} }

			' Draw the Base Profile.
			For i As Integer = 0 To lineMatrix.GetUpperBound(0)
				line2d = lines2d.AddBy2Points(lineMatrix(i, 0), lineMatrix(i, 1), lineMatrix(i, 2), lineMatrix(i, 3))
			Next i

			' Define Relations among the Line objects to make the Profile closed.
			relations2d = CType(profile.Relations2d, SolidEdgeFrameworkSupport.Relations2d)

			' Connect all of the lines.
			For i As Integer = 1 To lines2d.Count
				Dim j As Integer = i + 1

				' When we reach the last line, wrap around and connect it to the first line.
				If j > lines2d.Count Then
					j = 1
				End If

				relation2d = relations2d.AddKeypoint(lines2d.Item(i), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(j), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
			Next i

			' Close the profile.
			profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed)

			' Hide the profile.
			profile.Visible = False

			' Create a new array of profile objects.
			aProfiles = Array.CreateInstance(GetType(SolidEdgePart.Profile), 1)
			aProfiles.SetValue(profile, 0)

			' Get a reference to the models collection.
			models = partDocument.Models

			Console.WriteLine("Creating finite extruded protrusion.")

			' Create the extended protrusion.
			model = models.AddFiniteExtrudedProtrusion(aProfiles.Length, aProfiles, SolidEdgePart.FeaturePropertyConstants.igRight, 0.005)
		End Sub

		Private Shared Sub CreateFaceRotateByPoints(ByVal partDocument As SolidEdgePart.PartDocument)
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim body As SolidEdgeGeometry.Body = Nothing
			Dim faceRotates As SolidEdgePart.FaceRotates = Nothing
			Dim faceRotate As SolidEdgePart.FaceRotate = Nothing
			Dim faces As SolidEdgeGeometry.Faces = Nothing
			Dim face As SolidEdgeGeometry.Face = Nothing
			Dim vertices As SolidEdgeGeometry.Vertices = Nothing
			Dim point1 As SolidEdgeGeometry.Vertex = Nothing
			Dim point2 As SolidEdgeGeometry.Vertex = Nothing
			Dim angle As Double = 0.0872664625997165

			' Get a reference to the models collection.
			models = partDocument.Models
			model = models.Item(1)
			body = CType(model.Body, SolidEdgeGeometry.Body)
			faces = CType(body.Faces(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll), SolidEdgeGeometry.Faces)
			face = CType(faces.Item(1), SolidEdgeGeometry.Face)

			vertices = CType(face.Vertices, SolidEdgeGeometry.Vertices)
			point1 = CType(vertices.Item(1), SolidEdgeGeometry.Vertex)
			point2 = CType(vertices.Item(2), SolidEdgeGeometry.Vertex)

			faceRotates = model.FaceRotates

			' Add face rotate.
			faceRotate = faceRotates.Add(face, SolidEdgePart.FaceRotateConstants.igFaceRotateByPoints, SolidEdgePart.FaceRotateConstants.igFaceRotateRecreateBlends, point1, point2, Nothing, SolidEdgePart.FaceRotateConstants.igFaceRotateNone, angle)
		End Sub

		Private Shared Sub CreateFaceRotateByGeometry(ByVal partDocument As SolidEdgePart.PartDocument)
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim body As SolidEdgeGeometry.Body = Nothing
			Dim faceRotates As SolidEdgePart.FaceRotates = Nothing
			Dim faceRotate As SolidEdgePart.FaceRotate = Nothing
			Dim faces As SolidEdgeGeometry.Faces = Nothing
			Dim face As SolidEdgeGeometry.Face = Nothing
			Dim edges As SolidEdgeGeometry.Edges = Nothing
			Dim edge As SolidEdgeGeometry.Edge = Nothing
			Dim angle As Double = 0.5

			' Get a reference to the models collection.
			models = partDocument.Models
			model = models.Item(1)
			body = CType(model.Body, SolidEdgeGeometry.Body)
			faces = CType(body.Faces(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll), SolidEdgeGeometry.Faces)
			face = CType(faces.Item(2), SolidEdgeGeometry.Face)
			edges = CType(body.Edges(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll), SolidEdgeGeometry.Edges)
			edge = CType(edges.Item(5), SolidEdgeGeometry.Edge)

			faceRotates = model.FaceRotates

			' Add face rotate.
			faceRotate = faceRotates.Add(face, SolidEdgePart.FaceRotateConstants.igFaceRotateByGeometry, SolidEdgePart.FaceRotateConstants.igFaceRotateRecreateBlends, Nothing, Nothing, edge, SolidEdgePart.FaceRotateConstants.igFaceRotateAxisEnd, angle)
		End Sub
	End Class
End Namespace
