Imports System.Text

Namespace SolidEdge.Assembly.BOM
	Public Class BomItem
		Inherits MarshalByRefObject

		Public Sub New(ByVal fullName As String)
			Me.FullName = fullName
			FileName = System.IO.Path.GetFileName(fullName)
			Quantity = 1
		End Sub

		Public Level As Integer
		Public DocumentNumber As String
		Public Revision As String
		Public Title As String
		Public Quantity As Integer
		Public FullName As String
		Public FileName As String
		Public IsSubassembly As Boolean
	End Class
End Namespace
