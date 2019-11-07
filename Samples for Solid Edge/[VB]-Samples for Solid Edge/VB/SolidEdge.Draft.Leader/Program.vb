Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.Leader
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim textBoxes As SolidEdgeFrameworkSupport.TextBoxes = Nothing
			Dim textBox As SolidEdgeFrameworkSupport.TextBox = Nothing
			Dim leaders As SolidEdgeFrameworkSupport.Leaders = Nothing
			Dim leader As SolidEdgeFrameworkSupport.Leader = Nothing
			Dim dimStyle As SolidEdgeFrameworkSupport.DimStyle = Nothing

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

				' Create a new draft document.
				draftDocument = CType(documents.Add("SolidEdge.DraftDocument"), SolidEdgeDraft.DraftDocument)

				' Get a reference to the active sheet.
				sheet = draftDocument.ActiveSheet

				' Get a reference to the TextBoxes collection.
				textBoxes = CType(sheet.TextBoxes, SolidEdgeFrameworkSupport.TextBoxes)

				Console.WriteLine("Creating a new textbox. ")

				' Add a new text box.
				textBox = textBoxes.Add(0.25, 0.25, 0)
				textBox.TextScale = 1
				textBox.VerticalAlignment = SolidEdgeFrameworkSupport.TextVerticalAlignmentConstants.igTextHzAlignVCenter
				textBox.Text = "Leader"

				' Get a reference to the Leaders collection.
				leaders = CType(sheet.Leaders, SolidEdgeFrameworkSupport.Leaders)

				Console.WriteLine("Creating a new leader. ")

				' Add a new leader.
				leader = leaders.Add(0.225, 0.225, 0, 0.25, 0.25, 0)
				dimStyle = leader.Style
				dimStyle.FreeSpaceTerminatorType = SolidEdgeFrameworkSupport.DimTermTypeConstants.igDimStyleTermFilled
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub
	End Class
End Namespace
