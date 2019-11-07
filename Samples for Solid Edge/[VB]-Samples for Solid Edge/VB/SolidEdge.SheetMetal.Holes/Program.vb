Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SheetMetal.Holes
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
				application = SolidEdgeUtils.Connect(False)

				' Make sure user can see the GUI.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the documents collection.
				documents = application.Documents

				Console.WriteLine("Creating a new sheetmetal document.")

				' Create a new sheetmetal document.
				sheetMetalDocument = CType(documents.Add("SolidEdge.SheetMetalDocument"), SolidEdgePart.SheetMetalDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				' Create geometry.
				CreateExtrudedProtrusion(sheetMetalDocument)

				' Create holes.
				CreateHolesWithUserDefinedPattern(sheetMetalDocument)

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

		Private Shared Sub CreateExtrudedProtrusion(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument)
			Dim refPlanes As SolidEdgePart.RefPlanes = Nothing
			Dim refPlane As SolidEdgePart.RefPlane = Nothing
			Dim sketchs As SolidEdgePart.Sketchs = Nothing
			Dim sketch As SolidEdgePart.Sketch = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim circles2d As SolidEdgeFrameworkSupport.Circles2d = Nothing
			Dim circle2d As SolidEdgeFrameworkSupport.Circle2d = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing

			' Get refplane.
			refPlanes = sheetMetalDocument.RefPlanes

			' Get a reference to Right (yz) plane.
			refPlane = refPlanes.Item(3)

			' Create sketch.
			sketchs = sheetMetalDocument.Sketches
			sketch = sketchs.Add()

			' Create profile.
			profiles = sketch.Profiles
			profile = profiles.Add(refPlane)

			' Create 2D circle.
			circles2d = profile.Circles2d
			circle2d = circles2d.AddByCenterRadius(0, 0, 0.05)

			profile.Visible = False

			' Create extruded protrusion.
			models = sheetMetalDocument.Models
			model = models.AddBaseTab(profile, SolidEdgePart.FeaturePropertyConstants.igRight)
		End Sub

		Private Shared Sub CreateHolesWithUserDefinedPattern(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument)
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
			refplanes = sheetMetalDocument.RefPlanes

			' Get a reference to Right (yz) plane.
			refplane = refplanes.Item(3)

			' Get a reference to the Models collection.
			models = sheetMetalDocument.Models

			' Get a reference to Model.
			model = models.Item(1)

			' Get a reference to the ProfileSets collection.
			profileSets = sheetMetalDocument.ProfileSets

			' Add new ProfileSet.
			profileSet = profileSets.Add()

			' Get a reference to the Profiles collection.
			profiles = profileSet.Profiles

			' Add new Profile.
			profile = profiles.Add(refplane)

			' Get a reference to the Holes2d collection.
			holes2d = profile.Holes2d

			' This creates a cross pattern of holes.
			Dim holeMatrix(,) As Double = { {0.00, 0.00}, {-0.01, 0.00}, {-0.02, 0.00}, {-0.03, 0.00}, {-0.04, 0.00}, {0.01, 0.00}, {0.02, 0.00}, {0.03, 0.00}, {0.04, 0.00}, {0.00, -0.01}, {0.00, -0.02}, {0.00, -0.03}, {0.00, -0.04}, {0.00, 0.01}, {0.00, 0.02}, {0.00, 0.03}, {0.00, 0.04} }

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
			holeDataCollection = sheetMetalDocument.HoleDataCollection

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
