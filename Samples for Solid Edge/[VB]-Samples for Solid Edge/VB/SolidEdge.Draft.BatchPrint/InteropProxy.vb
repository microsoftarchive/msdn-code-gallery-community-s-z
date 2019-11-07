Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Namespace SolidEdge.Draft.BatchPrint
	Public Class InteropProxy
		Inherits MarshalByRefObject

		Public Sub DoPrint(ByVal filename As String, ByVal options As DraftPrintUtilityOptions)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing
			Dim draftPrintUtility As SolidEdgeDraft.DraftPrintUtility = Nothing

			' Copy all of the settings from DraftPrintUtilityOptions to the DraftPrintUtility object.
			CopyOptions(draftPrintUtility, options)

			OleMessageFilter.Register()

			Try
				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect(True)

				' Get a reference to the Documents collection.
				documents = application.Documents

				' Get a reference to the DraftPrintUtility.
				draftPrintUtility = CType(application.GetDraftPrintUtility(), SolidEdgeDraft.DraftPrintUtility)

				' Open the document.
				draftDocument = CType(documents.Open(filename), SolidEdgeDraft.DraftDocument)

				' Give Solid Edge time to process.
				application.DoIdle()

				' Add the draft document to the queue.
				draftPrintUtility.AddDocument(draftDocument)

				' Print out.
				draftPrintUtility.PrintOut()

				' Cleanup queue.
				draftPrintUtility.RemoveAllDocuments()
			Catch
				Throw
			Finally
				' Make sure we close the document.
				If draftDocument IsNot Nothing Then
					draftDocument.Close()
				End If
			End Try
		End Sub

		Private Sub CopyOptions(ByVal draftPrintUtility As SolidEdgeDraft.DraftPrintUtility, ByVal options As DraftPrintUtilityOptions)
			Dim fromType As Type = GetType(DraftPrintUtilityOptions)
			Dim toType As Type = GetType(SolidEdgeDraft.DraftPrintUtility)
			Dim properties() As PropertyInfo = toType.GetProperties().Where(Function(x) x.CanWrite).ToArray()

			' Copy all of the properties from DraftPrintUtility to this object.
			For Each toProperty As PropertyInfo In properties
				' Some properties may throw an exception if options are incompatible.
				' For instance, if PrintToFile = false, setting PrintToFileName = "" will cause an exception.
				' Mostly irrelevant but handle it as you see fit.
				Try
					Dim fromProperty As PropertyInfo = fromType.GetProperty(toProperty.Name)
					If fromProperty IsNot Nothing Then
						Dim val As Object = fromProperty.GetValue(options, Nothing) 'fromType.InvokeMember(toProperty.Name, BindingFlags.GetProperty, null, options, null);
						toProperty.SetValue(draftPrintUtility, val, Nothing)
					End If
				Catch
				End Try
			Next toProperty
		End Sub
	End Class
End Namespace
