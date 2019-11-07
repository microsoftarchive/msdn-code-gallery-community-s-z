Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Part.Holes
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

				Console.WriteLine("Creating holes with user defined patterns.")

				' Create holes.
				CreateHolesWithUserDefinedPattern(partDocument)

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

		Private Shared Sub CreateHolesWithUserDefinedPattern(ByVal partDocument As SolidEdgePart.PartDocument)
			Dim refplanes As SolidEdgePart.RefPlanes = Nothing
			Dim refplane As SolidEdgePart.RefPlane = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim holeDataCollection As SolidEdgePart.HoleDataCollection = Nothing
			Dim profileSets As SolidEdgePart.ProfileSets = Nothing
			Dim profileSet As SolidEdgePart.ProfileSet = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim holes2d As SolidEdgePart.Holes2d = Nothing
			Dim hole2d As SolidEdgePart.Hole2d = Nothing
			Dim holes As SolidEdgePart.Holes = Nothing
			Dim hole As SolidEdgePart.Hole = Nothing
			Dim profileStatus As Long = 0
			Dim profileList As New List(Of SolidEdgePart.Profile)()
			Dim userDefinedPatterns As SolidEdgePart.UserDefinedPatterns = Nothing
			Dim userDefinedPattern As SolidEdgePart.UserDefinedPattern = Nothing

			' Get a reference to the RefPlanes collection.
			refplanes = partDocument.RefPlanes

			' Get a reference to Right (yz) plane.
			refplane = refplanes.Item(3)

			' Get a reference to the Models collection.
			models = partDocument.Models

			' Get a reference to Model.
			model = models.Item(1)

			' Get a reference to the ProfileSets collection.
			profileSets = partDocument.ProfileSets

			' Add new ProfileSet.
			profileSet = profileSets.Add()

			' Get a reference to the Profiles collection.
			profiles = profileSet.Profiles

			' Add new Profile.
			profile = profiles.Add(refplane)

			' Get a reference to the Holes2d collection.
			holes2d = profile.Holes2d

			Dim holeMatrix(,) As Double = { {0.01, 0.01}, {0.02, 0.01}, {0.03, 0.01}, {0.04, 0.01}, {0.05, 0.01}, {0.06, 0.01}, {0.07, 0.01} }

			' Draw the Base Profile.
			For i As Integer = 0 To holeMatrix.GetUpperBound(0)
				' Add new Hole2d.
				hole2d = holes2d.Add(XCenter:= holeMatrix(i, 0), YCenter:= holeMatrix(i, 1))
			Next i

			' Hide the profile.
			profile.Visible = False

			' Close profile.
			profileStatus = profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed)

			' Get a reference to the ProfileSet.
			profileSet = CType(profile.Parent, SolidEdgePart.ProfileSet)

			' Get a reference to the Profiles collection.
			profiles = profileSet.Profiles

			' Add profiles to list for AddByProfiles().
			For i As Integer = 1 To profiles.Count
				profileList.Add(profiles.Item(i))
			Next i

			' Get a reference to the HoleDataCollection collection.
			holeDataCollection = partDocument.HoleDataCollection

			' Add new HoleData.
			Dim holeData As SolidEdgePart.HoleData = holeDataCollection.Add(HoleType:= SolidEdgePart.FeaturePropertyConstants.igRegularHole, HoleDiameter:= 0.005, BottomAngle:= 90)

			' Get a reference to the Holes collection.
			holes = model.Holes

			' Add hole.
			hole = holes.AddFinite(Profile:= profile, ProfilePlaneSide:= SolidEdgePart.FeaturePropertyConstants.igRight, FiniteDepth:= 0.005, Data:= holeData)

			' Get a reference to the UserDefinedPatterns collection.
			userDefinedPatterns = model.UserDefinedPatterns

			' Create the user defined pattern.
			userDefinedPattern = userDefinedPatterns.AddByProfiles(NumberOfProfiles:= profileList.Count, ProfilesArray:= profileList.ToArray(), SeedFeature:= hole)
		End Sub
	End Class
End Namespace
