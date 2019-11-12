Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SheetMetal.PhysicalProperties
	''' <summary>
	''' Console application that demonstrates how to work with physical properties.
	''' </summary>
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

				Console.WriteLine("Creating a new part document.")

				' Create a new part document.
				sheetMetalDocument = CType(documents.Add("SolidEdge.SheetMetalDocument"), SolidEdgePart.SheetMetalDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				Console.WriteLine("Drawing part.")

				' Create geometry.
				CreateExtrudedProtrusion(sheetMetalDocument)

				Console.WriteLine()

				' Physical properties have not yet been computed for this model
				' so all values will be 0 with a status of 2.
				GetPhysicalProperties(sheetMetalDocument, False)

				' This time, we will compute the physical properties of the model.
				GetPhysicalProperties(sheetMetalDocument, True)

				Console.WriteLine("Switching to ISO view.")

				' Switch to ISO view.
				application.StartCommand(CType(SolidEdgeConstants.PartCommandConstants.PartViewISOView, SolidEdgeFramework.SolidEdgeCommandConstants))

				' Show physical properties window.
				application.StartCommand(CType(SolidEdgeConstants.PartCommandConstants.PartToolsPhysicalProperties, SolidEdgeFramework.SolidEdgeCommandConstants))
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
			refPlane = refPlanes.Item(2)

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

		Private Shared Sub GetPhysicalProperties(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument, ByVal compute As Boolean)
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing

			models = sheetMetalDocument.Models
			model = models.Item(1)

			Dim density As Double = 0
			Dim accuracy As Double = 0
			Dim volume As Double = 0
			Dim area As Double = 0
			Dim mass As Double = 0
			Dim cetnerOfGravity As Array = Array.CreateInstance(GetType(Double), 3)
			Dim centerOfVolumne As Array = Array.CreateInstance(GetType(Double), 3)
			Dim globalMomentsOfInteria As Array = Array.CreateInstance(GetType(Double), 6) ' Ixx, Iyy, Izz, Ixy, Ixz and Iyz
			Dim principalMomentsOfInteria As Array = Array.CreateInstance(GetType(Double), 3) ' Ixx, Iyy and Izz
			Dim principalAxes As Array = Array.CreateInstance(GetType(Double), 9) ' 3 axes x 3 coords
			Dim radiiOfGyration As Array = Array.CreateInstance(GetType(Double), 9) ' 3 axes x 3 coords
			Dim relativeAccuracyAchieved As Double = 0
			Dim status As Integer = 0

			If compute Then
				density = 1
				accuracy = 0.05

				model.ComputePhysicalProperties(Density:= density, Accuracy:= accuracy, Volume:= volume, Area:= area, Mass:= mass, CenterOfGravity:= cetnerOfGravity, CenterOfVolume:= centerOfVolumne, GlobalMomentsOfInteria:= globalMomentsOfInteria, PrincipalMomentsOfInteria:= principalMomentsOfInteria, PrincipalAxes:= principalAxes, RadiiOfGyration:= radiiOfGyration, RelativeAccuracyAchieved:= relativeAccuracyAchieved, Status:= status)

				Console.WriteLine("ComputePhysicalProperties() results:")
			Else
				model.GetPhysicalProperties(Status:= status, Density:= density, Accuracy:= accuracy, Volume:= volume, Area:= area, Mass:= mass, CenterOfGravity:= cetnerOfGravity, CenterOfVolume:= centerOfVolumne, GlobalMomentsOfInteria:= globalMomentsOfInteria, PrincipalMomentsOfInteria:= principalMomentsOfInteria, PrincipalAxes:= principalAxes, RadiiOfGyration:= radiiOfGyration, RelativeAccuracyAchieved:= relativeAccuracyAchieved)

				Console.WriteLine("GetPhysicalProperties() results:")
			End If

			' Write results to screen.

			Console.WriteLine("Density: {0}", density)
			Console.WriteLine("Accuracy: {0}", accuracy)
			Console.WriteLine("Volume: {0}", volume)
			Console.WriteLine("Area: {0}", area)
			Console.WriteLine("Mass: {0}", mass)

			' Convert from System.Array to double[].  double[] is easier to work with.
			Dim m() As Double = cetnerOfGravity.OfType(Of Double)().ToArray()

			Console.WriteLine("CenterOfGravity:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))

			m = centerOfVolumne.OfType(Of Double)().ToArray()

			Console.WriteLine("CenterOfVolume:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))

			m = globalMomentsOfInteria.OfType(Of Double)().ToArray()

			Console.WriteLine("GlobalMomentsOfInteria:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(3), m(4), m(5))

			m = principalMomentsOfInteria.OfType(Of Double)().ToArray()

			Console.WriteLine("PrincipalMomentsOfInteria:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))

			m = principalAxes.OfType(Of Double)().ToArray()

			Console.WriteLine("PrincipalAxes:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(3), m(4), m(5))
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(6), m(7), m(8))

			m = radiiOfGyration.OfType(Of Double)().ToArray()

			Console.WriteLine("RadiiOfGyration:")
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(0), m(1), m(2))
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(3), m(4), m(5))
			Console.WriteLine(vbTab & "|{0}, {1}, {2}|", m(6), m(7), m(8))

			Console.WriteLine("RelativeAccuracyAchieved: {0}", relativeAccuracyAchieved)
			Console.WriteLine("Status: {0}", status)
			Console.WriteLine()
		End Sub
	End Class
End Namespace
