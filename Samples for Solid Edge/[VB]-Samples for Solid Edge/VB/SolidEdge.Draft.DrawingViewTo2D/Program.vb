Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.DrawingViewTo2D
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing
			Dim sections As SolidEdgeDraft.Sections = Nothing

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

				' Note: these two will throw exceptions if no document is open.
				'application.ActiveDocument
				'application.ActiveDocumentType;

				If (documents.Count > 0) AndAlso (application.ActiveDocumentType = SolidEdgeFramework.DocumentTypeConstants.igDraftDocument) Then
					' Get a reference to the documents collection.
					draftDocument = CType(application.ActiveDocument, SolidEdgeDraft.DraftDocument)
				Else
					Throw New System.Exception("Draft file not open.")
				End If

				' Get a reference to the Sections collection.
				sections = draftDocument.Sections

				' Convert all drawing views to 2D.
				ConvertAllDrawingViewsTo2D(sections.WorkingSection)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub ConvertAllDrawingViewsTo2D(ByVal section As SolidEdgeDraft.Section)
			Dim sectionSheets As SolidEdgeDraft.SectionSheets = Nothing
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing

			sectionSheets = section.Sheets

			For i As Integer = 1 To sectionSheets.Count
				' Get a reference to the sheet.
				sheet = sectionSheets.Item(i)

				' Get a reference to the DrawingViews collection.
				drawingViews = sheet.DrawingViews

				For j As Integer = 1 To drawingViews.Count - 1
					drawingView = drawingViews.Item(j)

					Console.WriteLine("Dropping (convert to 2D) DrawingView '{0} - {1}'.  ", drawingView.Name, drawingView.Caption)

					' DrawingView's of type igUserView cannot be converted.
					If drawingView.DrawingViewType <> SolidEdgeDraft.DrawingViewTypeConstants.igUserView Then
						' Converts the current DrawingView to an igUserView type containing simple geometry
						' and disassociates the drawing view from the source 3d Model.
						drawingView.Drop()
					End If
				Next j
			Next i
		End Sub
	End Class
End Namespace
