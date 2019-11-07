Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.UnitsOfMeasure
	Public Class ExternalExample
		Private _unitType As SolidEdgeFramework.UnitTypeConstants
		Private _externalValue As String = "1 in"
		Private _internalValue As Object

		Public Sub New()
			_unitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance
			UpdateInternalValue()
		End Sub

		Public Property UnitType() As SolidEdgeFramework.UnitTypeConstants
			Get
				Return _unitType
			End Get
			Set(ByVal value As SolidEdgeFramework.UnitTypeConstants)
				_unitType = value
				UpdateInternalValue()
			End Set
		End Property

		<DescriptionAttribute("Value in user display units.")> _
		Public Property ExternalValue() As String
			Get
				Return _externalValue
			End Get
			Set(ByVal value As String)
				_externalValue = value
				UpdateInternalValue()
			End Set
		End Property

		<DescriptionAttribute("Value in internal (database) units.")> _
		Public ReadOnly Property InternalValue() As Object
			Get
				Return _internalValue
			End Get
		End Property

		Private Sub UpdateInternalValue()
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim unitsOfMeasure As SolidEdgeFramework.UnitsOfMeasure = Nothing

			Try
				application = CType(Marshal.GetActiveObject("SolidEdge.Application"), SolidEdgeFramework.Application)
				document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)
				unitsOfMeasure = document.UnitsOfMeasure
				_internalValue = unitsOfMeasure.ParseUnit(CInt(_unitType), _externalValue)
			Catch ex As System.Exception
				_internalValue = ex.Message
			Finally
				If unitsOfMeasure IsNot Nothing Then
					Marshal.ReleaseComObject(unitsOfMeasure)
				End If
				If document IsNot Nothing Then
					Marshal.ReleaseComObject(document)
				End If
				If application IsNot Nothing Then
					Marshal.ReleaseComObject(application)
				End If
			End Try
		End Sub
	End Class
End Namespace
