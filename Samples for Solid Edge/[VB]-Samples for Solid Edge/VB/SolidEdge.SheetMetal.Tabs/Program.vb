Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SheetMetal.Tabs
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim sheetMetalDocument As SolidEdgePart.SheetMetalDocument = Nothing

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

				Console.WriteLine("Creating a new SheetMetal document.")

				' Create a new SheetMetal document.
				sheetMetalDocument = CType(documents.Add("SolidEdge.SheetMetalDocument"), SolidEdgePart.SheetMetalDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				Console.WriteLine("Creating base tab.")

				' Create base tab.
				CreateBaseTab(sheetMetalDocument)

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

		Private Shared Sub CreateBaseTab(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument)
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

			' Get a reference to the profile sets collection.
			profileSets = sheetMetalDocument.ProfileSets

			' Add a new profile set.
			profileSet = profileSets.Add()

			' Get a reference to the profiles collection.
			profiles = profileSet.Profiles

			' Get a reference to the ref planes collection.
			refplanes = sheetMetalDocument.RefPlanes

			' Add a new profile.
			profile = profiles.Add(refplanes.Item(1))

			' Get a reference to the lines2d collection.
			lines2d = profile.Lines2d

			' UOM = meters.
			Dim lineMatrix(,) As Double = { {0.05, 0.025, 0.05, 0.025}, {-0.05, 0.025, -0.05, -0.025}, {-0.05, -0.025, 0.05, -0.025}, {0.05, -0.025, 0.05, 0.025} }

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

			' Get a reference to the models collection.
			models = sheetMetalDocument.Models

			' Create the base tab.
			model = models.AddBaseTab(profile, SolidEdgePart.FeaturePropertyConstants.igRight)
		End Sub
	End Class
End Namespace
