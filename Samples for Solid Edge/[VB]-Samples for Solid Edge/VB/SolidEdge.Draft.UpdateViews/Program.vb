Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.UpdateViews
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

				' Get a reference to the documents collection.
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

				sections = draftDocument.Sections

				' Update all views in the working section.
				UpdateAllViewsInWorkingSection(sections.WorkingSection)

				' Update all views in all sheets.
				'UpdateAllViewsInAllSheets(draftDocument.Sheets);
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub UpdateAllViewsInWorkingSection(ByVal section As SolidEdgeDraft.Section)
			Dim sectionSheets As SolidEdgeDraft.SectionSheets = Nothing
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing

			sectionSheets = section.Sheets

			For i As Integer = 1 To sectionSheets.Count
				sheet = sectionSheets.Item(i)

				drawingViews = sheet.DrawingViews

				For j As Integer = 1 To drawingViews.Count - 1
					drawingView = drawingViews.Item(j)

					Console.WriteLine("Updating DrawingView '{0} - {1}'.", drawingView.Name, drawingView.Caption)

					' Updates an out-of-date drawing view.
					drawingView.Update()

					' Updates the drawing view even if it is not out-of-date.
					'drawingView.ForceUpdate();
				Next j
			Next i
		End Sub

		Private Shared Sub UpdateAllViewsInAllSheets(ByVal sheets As SolidEdgeDraft.Sheets)
			Dim sheet As SolidEdgeDraft.Sheet = Nothing
			Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
			Dim drawingView As SolidEdgeDraft.DrawingView = Nothing

			For i As Integer = 1 To sheets.Count - 1
				sheet = sheets.Item(i)

				Console.WriteLine("Processing Sheet '{0}'.", sheet.Name)

				drawingViews = sheet.DrawingViews

				For j As Integer = 1 To drawingViews.Count - 1
					drawingView = drawingViews.Item(j)

					Console.WriteLine("Updating DrawingView '{0} - {1}'.", drawingView.Name, drawingView.Caption)

					' Updates an out-of-date drawing view.
					drawingView.Update()

					' Updates the drawing view even if it is not out-of-date.
					'drawingView.ForceUpdate();
				Next j
			Next i
		End Sub
	End Class
End Namespace
