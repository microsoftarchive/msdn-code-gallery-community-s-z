Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Part.BSplineCurves
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

				Console.WriteLine("Creating b-spline curves.")
				CreateBSplineCurve2d(partDocument)

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

		Private Shared Sub CreateBSplineCurve2d(ByVal partDocument As SolidEdgePart.PartDocument)
			Dim refPlanes As SolidEdgePart.RefPlanes = Nothing
			Dim refPlane As SolidEdgePart.RefPlane = Nothing
			Dim sketches As SolidEdgePart.Sketchs = Nothing
			Dim sketch As SolidEdgePart.Sketch = Nothing
			Dim profiles As SolidEdgePart.Profiles = Nothing
			Dim profile As SolidEdgePart.Profile = Nothing
			Dim bsplineCurves2d As SolidEdgeFrameworkSupport.BSplineCurves2d = Nothing
			Dim bsplineCurve2d1 As SolidEdgeFrameworkSupport.BSplineCurve2d = Nothing
			Dim bsplineCurve2d2 As SolidEdgeFrameworkSupport.BSplineCurve2d = Nothing
			Dim startX As Double = 0
			Dim startY As Double = 0
			Dim endX As Double = 0
			Dim endY As Double = 0
			Dim arcs2d As SolidEdgeFrameworkSupport.Arcs2d = Nothing
			Dim arc2d As SolidEdgeFrameworkSupport.Arc2d = Nothing
			Dim relations2d As SolidEdgeFrameworkSupport.Relations2d = Nothing

			' Get a reference to the RefPlanes collection.
			refPlanes = partDocument.RefPlanes

			' Front (xz).
			refPlane = refPlanes.Item(3)

			' Get a reference to the Sketches collection.
			sketches = partDocument.Sketches

			' Create a new sketch.
			sketch = sketches.Add()

			' Get a reference to the Profiles collection.
			profiles = sketch.Profiles

			' Create a new profile.
			profile = profiles.Add(refPlane)

			' Get a reference to the BSplineCurves2d collection.
			bsplineCurves2d = profile.BSplineCurves2d

			Dim points As New List(Of Double)()
			points.Add(10.0 / 1000)
			points.Add(0.0 / 1000)
			points.Add(9.0 / 1000)
			points.Add(6.0 / 1000)
			points.Add(3.0 / 1000)
			points.Add(12.0 / 1000)

			' Create initial b-spline.
			bsplineCurve2d1 = bsplineCurves2d.AddByPoints(Order:= 6, ArraySize:= 3, Array:= points.ToArray())

			' Mirror initial b-spline.
			bsplineCurve2d2 = CType(bsplineCurve2d1.Mirror(x1:= 0.0, y1:= 1.0, x2:= 0.0, y2:= -1.0, BooleanCopyFlag:= True), SolidEdgeFrameworkSupport.BSplineCurve2d)

			bsplineCurve2d1.GetNode(Index:= bsplineCurve2d1.NodeCount, x:= startX, y:= startY)

			bsplineCurve2d2.GetNode(Index:= bsplineCurve2d2.NodeCount, x:= endX, y:= endY)

			' Get a reference to the Arcs2d collection.
			arcs2d = profile.Arcs2d

			' Draw arc to connect the two b-splines.
			arc2d = arcs2d.AddByCenterStartEnd(xCenter:= 0.0, yCenter:= 0.0, xStart:= startX, yStart:= startY, xEnd:= endX, yEnd:= endY)

			Dim endKeyPointIndex1 As Integer = GetBSplineCurves2dEndKeyPointIndex(bsplineCurve2d1)
			Dim endKeyPointIndex2 As Integer = GetBSplineCurves2dEndKeyPointIndex(bsplineCurve2d2)

			' Get a reference to the Relations2d collection.
			relations2d = CType(profile.Relations2d, SolidEdgeFrameworkSupport.Relations2d)

			' Connect BSplineCurve2d and arc.
			relations2d.AddKeypoint(Object1:= bsplineCurve2d1, Index1:= endKeyPointIndex1, Object2:= arc2d, Index2:= CInt(SolidEdgeConstants.KeypointIndexConstants.igArcStart))

			' Connect BSplineCurve2d and arc.
			relations2d.AddKeypoint(Object1:= bsplineCurve2d2, Index1:= endKeyPointIndex2, Object2:= arc2d, Index2:= CInt(SolidEdgeConstants.KeypointIndexConstants.igArcEnd))
		End Sub

		Private Shared Function GetBSplineCurves2dEndKeyPointIndex(ByVal bsplineCurve2d As SolidEdgeFrameworkSupport.BSplineCurve2d) As Integer
			' Keypoint indices are zero-based......
			For i As Integer = 0 To bsplineCurve2d.KeyPointCount - 2
				Dim x As Double = 0
				Dim y As Double = 0
				Dim z As Double = 0
				Dim keypointType As SolidEdgeFramework.KeyPointType
				Dim handleType As Integer = 0

				bsplineCurve2d.GetKeyPoint(Index:= i, x:= x, y:= y, z:= z, KeypointType:= keypointType, HandleType:= handleType)

				If keypointType = SolidEdgeFramework.KeyPointType.igKeyPointEnd Then
					Return i
				End If
			Next i

			Return 0
		End Function
	End Class
End Namespace
