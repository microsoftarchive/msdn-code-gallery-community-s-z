Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Assembly.BOM
	Public Class InteropProxy
		Inherits MarshalByRefObject

		Public Function GetBomItems() As BomItem()
			' Dictionary to hold BomItem(s).  Key is the full path to the SolidEdgeDocument.
			Dim bomItems As New Dictionary(Of String, BomItem)()

			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing

			OleMessageFilter.Register()

			Try
				' Attempt to connect to a running instance of Solid Edge.
				application = SolidEdgeUtils.Connect()

				' Get a reference to the Documents collection.
				documents = application.Documents

				' Make sure a document is open and that it's an AssemblyDocument.
				If (documents.Count > 0) AndAlso (application.ActiveDocumentType = SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument) Then
					' Get a reference to the AssemblyDocument.
					assemblyDocument = CType(application.ActiveDocument, SolidEdgeAssembly.AssemblyDocument)

					' Start walking the assembly tree.
					ProcessAssembly(0, assemblyDocument, bomItems)
				Else
					Throw New System.Exception("No assembly open.")
				End If
			Catch ex As System.Runtime.InteropServices.COMException
				If ex.ErrorCode = -2147221021 Then ' MK_E_UNAVAILABLE
					Throw New System.Exception("Solid Edge is not running.")
				Else
					Throw
				End If
			Catch
				Throw
			Finally
			End Try

			Return bomItems.Values.ToArray()
		End Function

		Private Sub ProcessAssembly(ByVal level As Integer, ByVal assemblyDocument As SolidEdgeAssembly.AssemblyDocument, ByVal bomItems As Dictionary(Of String, BomItem))
			' Increment level (depth).
			level += 1

			' Loop through the Occurrences.
			For Each occurrence As SolidEdgeAssembly.Occurrence In assemblyDocument.Occurrences
				' Filter out certain occurrences.
				If Not occurrence.IncludeInBom Then
					Continue For
				End If
				If occurrence.IsPatternItem Then
					Continue For
				End If
				If occurrence.OccurrenceDocument Is Nothing Then
					Continue For
				End If

				' Get a reference to the SolidEdgeDocument.
				Dim document As SolidEdgeFramework.SolidEdgeDocument = CType(occurrence.OccurrenceDocument, SolidEdgeFramework.SolidEdgeDocument)

				' Add the BomItem.
				AddBomItem(level, document, bomItems)

				If occurrence.Subassembly Then
					' Sub Assembly. Recurisve call to drill down.
					ProcessAssembly(level, CType(occurrence.OccurrenceDocument, SolidEdgeAssembly.AssemblyDocument), bomItems)
				End If
			Next occurrence
		End Sub

		Private Sub AddBomItem(ByVal level As Integer, ByVal document As SolidEdgeFramework.SolidEdgeDocument, ByVal bomItems As Dictionary(Of String, BomItem))
			Dim bomItem As New BomItem(document.FullName)
			Dim summaryInfo As SolidEdgeFramework.SummaryInfo = Nothing

			If Not bomItems.ContainsKey(document.FullName) Then
				summaryInfo = CType(document.SummaryInfo, SolidEdgeFramework.SummaryInfo)
				bomItem.Level = level
				bomItem.DocumentNumber = summaryInfo.DocumentNumber
				bomItem.Title = summaryInfo.Title
				bomItem.Revision = summaryInfo.RevisionNumber
				bomItem.IsSubassembly = document.Type = SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument
				bomItems.Add(bomItem.FullName, bomItem)
			Else
				bomItems(bomItem.FullName).Quantity += 1
			End If
		End Sub
	End Class
End Namespace