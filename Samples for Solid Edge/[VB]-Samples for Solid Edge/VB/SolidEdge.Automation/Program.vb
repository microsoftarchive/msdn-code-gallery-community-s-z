Imports System.Text
Imports System.Runtime.InteropServices

Namespace SolidEdge.Automation
	''' <summary>
	''' Console application demonstrating basic Solid Edge automation.
	''' </summary>
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing

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

				Console.WriteLine("Creating a new part document.  No template specified.")
				document = CType(documents.Add("SolidEdge.PartDocument"), SolidEdgeFramework.SolidEdgeDocument)

				'string template = "your template.par";
				'Console.WriteLine("Creating a new part document.  Template '{0}' specified.", template);
				'document = (SolidEdgeFramework.SolidEdgeDocument)documents.Add("SolidEdge.PartDocument", template);

				'Console.WriteLine("Quitting Solid Edge.");

				' Quit Solid Edge.
				'application.Quit();
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
