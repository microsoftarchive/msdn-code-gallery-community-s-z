Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.UnitsOfMeasure
	Public Class InternalExample
		Private _unitType As SolidEdgeFramework.UnitTypeConstants
		Private _precision As SolidEdgeConstants.PrecisionConstants
		Private _externalValue As Object
		Private _internalValue As Double = 0.0254

		Public Sub New()
			_unitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance
			_precision = SolidEdgeConstants.PrecisionConstants.igPrecisionThousandths
			UpdateExternalValue()
		End Sub

		Public Property UnitType() As SolidEdgeFramework.UnitTypeConstants
			Get
				Return _unitType
			End Get
			Set(ByVal value As SolidEdgeFramework.UnitTypeConstants)
				_unitType = value
				UpdateExternalValue()
			End Set
		End Property

		Public Property Precision() As SolidEdgeConstants.PrecisionConstants
			Get
				Return _precision
			End Get
			Set(ByVal value As SolidEdgeConstants.PrecisionConstants)
				_precision = value
				UpdateExternalValue()
			End Set
		End Property

		<DescriptionAttribute("Value in user display units.")> _
		Public ReadOnly Property ExternalValue() As Object
			Get
				Return _externalValue
			End Get
		End Property

		<DescriptionAttribute("Value in internal (database) units.")> _
		Public Property InternalValue() As Double
			Get
				Return _internalValue
			End Get
			Set(ByVal value As Double)
				_internalValue = value
				UpdateExternalValue()
			End Set
		End Property

		Private Sub UpdateExternalValue()
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim unitsOfMeasure As SolidEdgeFramework.UnitsOfMeasure = Nothing

			Try
				application = CType(Marshal.GetActiveObject("SolidEdge.Application"), SolidEdgeFramework.Application)
				document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)
				unitsOfMeasure = document.UnitsOfMeasure
				_externalValue = unitsOfMeasure.FormatUnit(CInt(_unitType), _internalValue, _precision)
			Catch ex As System.Exception
				_externalValue = ex.Message
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
