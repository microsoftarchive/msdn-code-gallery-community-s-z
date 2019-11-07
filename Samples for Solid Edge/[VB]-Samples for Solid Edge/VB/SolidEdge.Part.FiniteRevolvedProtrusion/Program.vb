Imports System.Text
Imports System.Runtime.InteropServices


Namespace SolidEdge.Part.FiniteRevolvedProtrusion
	''' <summary>
	''' Console application that demonstrates how to create a swept protrusion.
	''' </summary>
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim partDocument As SolidEdgePart.PartDocument = Nothing
			Dim refPlanes As SolidEdgePart.RefPlanes = Nothing
			Dim refPlane As SolidEdgePart.RefPlane = Nothing
			Dim profileSets As SolidEdgePart.ProfileSets = Nothing
			Dim profileSet As SolidEdgePart.ProfileSet = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim models As SolidEdgePart.Models = Nothing
			Dim model As SolidEdgePart.Model = Nothing
			Dim lines2d As SolidEdgeFrameworkSupport.Lines2d = Nothing
			Dim axis As SolidEdgeFrameworkSupport.Line2d = Nothing
			Dim arcs2d As SolidEdgeFrameworkSupport.Arcs2d = Nothing
			Dim relations2d As SolidEdgeFrameworkSupport.Relations2d = Nothing
			Dim refaxis As SolidEdgePart.RefAxis = Nothing
			Dim aProfiles As Array = Nothing
			Dim edges As SolidEdgeGeometry.Edges = Nothing
			Dim circle As SolidEdgeGeometry.Circle = Nothing
			Dim revolvedProtrusions As SolidEdgePart.RevolvedProtrusions = Nothing
			Dim revolvedProtrusion As SolidEdgePart.RevolvedProtrusion = Nothing
			Dim center As Array = Nothing

			Dim rounds As SolidEdgePart.Rounds = Nothing

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

				Console.WriteLine("Creating a new part document.")

				' Create a new PartDocument.
				partDocument = CType(documents.Add("SolidEdge.PartDocument"), SolidEdgePart.PartDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				Console.WriteLine("Drawing part.")

				' Get a reference to the models collection.
				models = CType(partDocument.Models, SolidEdgePart.Models)


				' D1 to FA are parameters in a form, introduced by the user.
				Dim D1 As Double = 0.020
				Dim D2 As Double = 0.026
				Dim D3 As Double = 0.003
				Dim D4 As Double = 0.014
				Dim L1 As Double = 0.040
				Dim L2 As Double = 0.030
				Dim L3 As Double = 0.005
				Dim FA As Double = 0.0005 ' round

				' Get a reference to the ref planes collection.
				refPlanes = partDocument.RefPlanes

				' Front (xz).
				refPlane = refPlanes.Item(3)

				' Get a reference to the profile sets collection.
				profileSets = CType(partDocument.ProfileSets, SolidEdgePart.ProfileSets)

				' Create a new profile set.
				profileSet = profileSets.Add()

				' Get a reference to the profiles collection.
				profiles = profileSet.Profiles

				' Create a new profile.
				profile = profiles.Add(refPlane)

				' Get a reference to the profile lines2d collection.
				lines2d = profile.Lines2d

				' Get a reference to the profile arcs2d collection.
				arcs2d = profile.Arcs2d

				Dim H As Double = L1 - L2
				Dim y As Double = L1 - L3 - (D4 - D3) / (2 * Math.Tan((118 \ 2) * (Math.PI / 180)))

				lines2d.AddBy2Points(D3 / 2, 0, D2 / 2, 0) ' Line1
				lines2d.AddBy2Points(D2 / 2, 0, D2 / 2, H) ' Line2
				lines2d.AddBy2Points(D2 / 2, H, D1 / 2, H) ' Line3
				lines2d.AddBy2Points(D1 / 2, H, D1 / 2, L1) ' Line4
				lines2d.AddBy2Points(D1 / 2, L1, D4 / 2, L1) ' Line5
				lines2d.AddBy2Points(D4 / 2, L1, D4 / 2, L1 - L3) ' Line6
				lines2d.AddBy2Points(D4 / 2, L1 - L3, D3 / 2, y) ' Line7
				lines2d.AddBy2Points(D3 / 2, y, D3 / 2, 0) ' Line8

				axis = lines2d.AddBy2Points(0, 0, 0, L1)
				profile.ToggleConstruction(axis)

				' relations
				relations2d = CType(profile.Relations2d, SolidEdgeFrameworkSupport.Relations2d)
				relations2d.AddKeypoint(lines2d.Item(1), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(2), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(2), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(3), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(3), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(4), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(4), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(5), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(5), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(6), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(6), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(7), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(7), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(8), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)
				relations2d.AddKeypoint(lines2d.Item(8), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineEnd), lines2d.Item(1), CInt(SolidEdgeConstants.KeypointIndexConstants.igLineStart), True)

				refaxis = CType(profile.SetAxisOfRevolution(axis), SolidEdgePart.RefAxis)

				' Close the profile.
				Dim status As Integer = profile.End(SolidEdgePart.ProfileValidationType.igProfileRefAxisRequired)
				profile.Visible = False

				' Create a new array of profile objects.
				aProfiles = Array.CreateInstance(GetType(SolidEdgePart.Profile), 1)
				aProfiles.SetValue(profile, 0)

				Console.WriteLine("Creating finite revolved protrusion.")

				' add Finite Revolved Protrusion.
				model = models.AddFiniteRevolvedProtrusion(1, aProfiles, refaxis, SolidEdgePart.FeaturePropertyConstants.igRight, 2 * Math.PI, Nothing, Nothing)

				Console.WriteLine("Creating adding rounds.")

				Dim arrEdges() As SolidEdgeGeometry.Edge = { Nothing }
				Dim arrRadii() As Double = { FA }

				revolvedProtrusions = model.RevolvedProtrusions
				revolvedProtrusion = revolvedProtrusions.Item(1)
				edges = CType(revolvedProtrusion.Edges(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll), SolidEdgeGeometry.Edges)

				For Each edge As SolidEdgeGeometry.Edge In edges
					circle = CType(edge.Geometry, SolidEdgeGeometry.Circle)
					If circle.Radius = D2 / 2 Then
						center = Array.CreateInstance(GetType(Double), 3)
						circle.GetCenterPoint(center)
						If CDbl(center.GetValue(0)) = 0 AndAlso CDbl(center.GetValue(1)) = 0 AndAlso CDbl(center.GetValue(2)) = H Then
							arrEdges(0) = edge
							Exit For
						End If
					End If
				Next edge

				rounds = model.Rounds
				Dim optArg As Object = Type.Missing
				rounds.Add(1, arrEdges, arrRadii, optArg, optArg, optArg, optArg)

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
	End Class

End Namespace
