Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Part.PhysicalProperties
	''' <summary>
	''' Console application that demonstrates how to work with physical properties.
	''' </summary>
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

				Console.WriteLine("Drawing part.")

				' Create geometry.
				CreateFiniteExtrudedProtrusion(partDocument)

				Console.WriteLine()

				' Physical properties have not yet been computed for this model
				' so all values will be 0 with a status of 2.
				GetPhysicalProperties(partDocument, False)

				' This time, we will compute the physical properties of the model.
				GetPhysicalProperties(partDocument, True)

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
				line2d = lines2d.AddBy2Points(x1:= lineMatrix(i, 0), y1:= lineMatrix(i, 1), x2:= lineMatrix(i, 2), y2:= lineMatrix(i, 3))
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

				relation2d = relations2d.AddKeypoint(Object1:= lines2d.Item(i), Index1:= CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), Object2:= lines2d.Item(j), Index2:= CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), guaranteed_ok:= True)
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
			model = models.AddFiniteExtrudedProtrusion(NumberOfProfiles:= aProfiles.Length, ProfileArray:= aProfiles, ProfilePlaneSide:= SolidEdgePart.FeaturePropertyConstants.igRight, ExtrusionDistance:= 0.005)
		End Sub

		Private Shared Sub GetPhysicalProperties(ByVal partDocument As SolidEdgePart.PartDocument, ByVal compute As Boolean)
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing

			models = partDocument.Models
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
