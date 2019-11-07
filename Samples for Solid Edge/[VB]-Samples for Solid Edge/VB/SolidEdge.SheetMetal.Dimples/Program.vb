Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SheetMetal.Dimples
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

				' Create dimples.
				CreateDimples(sheetMetalDocument)

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

		Private Shared Sub CreateDimples(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument)
			Dim refplanes As SolidEdgePart.RefPlanes = Nothing
			Dim refplane As SolidEdgePart.RefPlane = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim profileSets As SolidEdgePart.ProfileSets = Nothing
			Dim profileSet As SolidEdgePart.ProfileSet = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim lines2d As SolidEdgeFrameworkSupport.Lines2d = Nothing
			Dim line2d As SolidEdgeFrameworkSupport.Line2d = Nothing

			'List<SolidEdgePart.Profile> profileList = new List<SolidEdgePart.Profile>();

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

			' Draw a line to define the dimple point.
			lines2d = profile.Lines2d
			line2d = lines2d.AddBy2Points(0, 0, 0.01, 0)

			' Hide the profile.
			profile.Visible = False

			Dim depth As Double = 0.01

			' Add new dimple.
			model.Dimples.Add(Profile:= profile, Depth:= depth, ProfileSide:= SolidEdgePart.DimpleFeatureConstants.seDimpleDepthLeft, DepthSide:= SolidEdgePart.DimpleFeatureConstants.seDimpleDepthRight)
		End Sub
	End Class
End Namespace
