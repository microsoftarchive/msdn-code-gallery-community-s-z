Imports System.IO
Imports System.Text

Namespace SolidEdge.Assembly.Relations3d
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
			Dim relations3d As SolidEdgeAssembly.Relations3d = Nothing

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

				Console.WriteLine("Opening Coffee Pot.asm.")

				Dim fileName As String = Path.Combine(SolidEdgeUtils.GetTrainingPath(), "Coffee Pot.asm")

				' Create a new assembly document.
				assemblyDocument = CType(documents.Open(fileName), SolidEdgeAssembly.AssemblyDocument)

				' Always a good idea to give SE a chance to breathe.
				application.DoIdle()

				' Get a reference to the Relations3d collection.
				relations3d = assemblyDocument.Relations3d

				ReportRelations3d(relations3d)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub ReportRelations3d(ByVal relations3d As SolidEdgeAssembly.Relations3d)
			Dim groundRelation3d As SolidEdgeAssembly.GroundRelation3d = Nothing
			Dim axialRelation3d As SolidEdgeAssembly.AxialRelation3d = Nothing
			Dim planarRelation3d As SolidEdgeAssembly.PlanarRelation3d = Nothing

			For i As Integer = 1 To relations3d.Count
				Dim relation3d As Object = relations3d.Item(i)

				' GetInteropType() is a custom method extension!
                Dim t As Type = SolidEdgeUtils.GetInteropType(relation3d)

				Console.WriteLine("Relations3d[{0}] is of type '{1}'.", i, t)

				' Determine the ObjectType.
				Dim relationType As SolidEdgeFramework.ObjectType = CType(relation3d.GetType().InvokeMember("Type", System.Reflection.BindingFlags.GetProperty, Nothing, relation3d, Nothing), SolidEdgeFramework.ObjectType)

				Select Case relationType
					Case SolidEdgeFramework.ObjectType.igGroundRelation3d
						groundRelation3d = CType(relation3d, SolidEdgeAssembly.GroundRelation3d)
					Case SolidEdgeFramework.ObjectType.igAxialRelation3d
						axialRelation3d = CType(relation3d, SolidEdgeAssembly.AxialRelation3d)
					Case SolidEdgeFramework.ObjectType.igPlanarRelation3d
						planarRelation3d = CType(relation3d, SolidEdgeAssembly.PlanarRelation3d)
					Case Else
				End Select
			Next i
		End Sub
	End Class
End Namespace
