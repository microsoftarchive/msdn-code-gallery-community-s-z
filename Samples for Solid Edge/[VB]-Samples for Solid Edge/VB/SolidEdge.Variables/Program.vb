Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Variables
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim variables As SolidEdgeFramework.Variables = Nothing

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

				' This check is necessary because application.ActiveDocument will throw an
				' exception if no documents are open...
				If documents.Count > 0 Then
					' Attempt to connect to ActiveDocument.
					document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)
				End If

				' Make sure we have a document.
				If document Is Nothing Then
					Throw New System.Exception("No active document.")
				End If

				variables = CType(document.Variables, SolidEdgeFramework.Variables)

				ProcessVariables(variables)
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub ProcessVariables(ByVal variables As SolidEdgeFramework.Variables)
			Dim variableList As SolidEdgeFramework.VariableList = Nothing
			Dim variable As SolidEdgeFramework.variable = Nothing
			Dim dimension As SolidEdgeFrameworkSupport.Dimension = Nothing
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
			Dim variableListItem As Object = Nothing ' In C#, the dynamic keyword is used so we don't have to call InvokeMember().

			' Get a reference to the variablelist.
			variableList = CType(variables.Query(pFindCriterium:= "*", NamedBy:= SolidEdgeConstants.VariableNameBy.seVariableNameByBoth, VarType:= SolidEdgeConstants.VariableVarType.SeVariableVarTypeBoth), SolidEdgeFramework.VariableList)

			' Process variables.
			For i As Integer = 1 To variableList.Count
				' Get a reference to variable item.
				variableListItem = variableList.Item(i)

				' Determine the variable item type.
				Dim objectType As SolidEdgeConstants.ObjectType = CType(variableListItem.Type, SolidEdgeConstants.ObjectType)

				Console.WriteLine("Variable({0}) is of type '{1}'", i, objectType)

				' Process the specific variable item type.
				Select Case objectType
					Case SolidEdgeConstants.ObjectType.igDimension
						dimension = CType(variableListItem, SolidEdgeFrameworkSupport.Dimension)
					Case SolidEdgeConstants.ObjectType.igVariable
						variable = CType(variableListItem, SolidEdgeFramework.variable)
					Case Else
						' Other SolidEdgeConstants.ObjectType's may exist.
				End Select
			Next i
		End Sub
	End Class
End Namespace
