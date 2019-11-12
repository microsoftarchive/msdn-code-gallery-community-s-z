Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Documents
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim progIds() As String = { "SolidEdge.AssemblyDocument", "SolidEdge.DraftDocument", "SolidEdge.PartDocument", "SolidEdge.SheetMetalDocument" }
			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect(True)

				' Ensure Solid Edge GUI is visible.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the documents collection.
				documents = application.Documents

				' Create a new document for each ProgId.
				For Each progId As String In progIds
					Console.WriteLine("Creating a new '{0}'.  No template specified.", progId)

					' Create the new document.
					document = CType(documents.Add(progId), SolidEdgeFramework.SolidEdgeDocument)
				Next progId
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
