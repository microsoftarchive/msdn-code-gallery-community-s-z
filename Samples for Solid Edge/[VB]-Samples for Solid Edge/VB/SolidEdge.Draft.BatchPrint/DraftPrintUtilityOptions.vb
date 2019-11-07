Imports System.ComponentModel
Imports System.Reflection
Imports System.Text

Namespace SolidEdge.Draft.BatchPrint
	Public Class DraftPrintUtilityOptions
		Inherits MarshalByRefObject
		Implements ICloneable

		Public Sub New(ByVal application As SolidEdgeFramework.Application)
			Me.New(CType(application.GetDraftPrintUtility(), SolidEdgeDraft.DraftPrintUtility))
		End Sub

		Public Sub New(ByVal draftPrintUtility As SolidEdgeDraft.DraftPrintUtility)
			Dim thatType As Type = GetType(SolidEdgeDraft.DraftPrintUtility)
			Dim thisType As Type = Me.GetType()
			Dim properties() As PropertyInfo = thatType.GetProperties().Where(Function(x) x.CanWrite).ToArray()

			' Copy all of the properties from DraftPrintUtility to this object.
			For Each [property] As PropertyInfo In properties
				Dim val As Object = thatType.InvokeMember([property].Name, BindingFlags.GetProperty, Nothing, draftPrintUtility, Nothing)

				Dim thisProperty As PropertyInfo = thisType.GetProperty([property].Name)
				If thisProperty IsNot Nothing Then
					thisProperty.SetValue(Me, val, Nothing)
				End If
			Next [property]
		End Sub

		Public Property AutoOrient() As Boolean
		Public Property BestFit() As Boolean
		Public Property Center() As Boolean
		Public Property Copies() As Short
		Public Property DisplayCutLine() As Boolean
		Public Property DisplaySheetBoundary() As Boolean
		Public Property Gap() As Double
		Public Property MultipleSheetScale() As Double
		Public Property Orientation() As SolidEdgeDraft.DraftPrintOrientationConstants
		Public Property PaperHeight() As Double
		Public Property PaperSize() As SolidEdgeDraft.DraftPrintPaperSizeConstants
		Public Property PaperWidth() As Double
		Public Property PrintAsBlack() As Boolean
		Public Property Printer() As String
		Public Property PrintToFile() As Boolean
		Public Property PrintToFileName() As String
		Public Property PrintToFilePath() As String
		Public Property ScaleLineTypes() As Boolean
		Public Property ScaleLineWidths() As Boolean
		Public Property ScaleTooLarge() As SolidEdgeDraft.DraftPrintScaleTooLargeActionConstants
		Public Property SheetsPerPage() As SolidEdgeDraft.DraftPrintSheetsPerPageConstants
		Public Property SingleSheetScale() As Double
		Public Property Units() As SolidEdgeDraft.DraftPrintUnitsConstants
		Public Property UsePrinterClipping() As Boolean
		Public Property UsePrinterMargins() As Boolean

		Public Function Clone() As Object Implements ICloneable.Clone
			Return Me.MemberwiseClone()
		End Function
	End Class
End Namespace
