Imports System.Text

Namespace SolidEdge.GlobalParameters
	'http://msdn.microsoft.com/en-us/library/ms404304.aspx
	Public Class ToolStripSpringTextBox
		Inherits ToolStripTextBox

		Private _inputType As Type = GetType(String)

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
			MyBase.OnLostFocus(e)
		End Sub

		Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
			If _inputType.Equals(GetType(Integer)) Then
				If Not e.KeyChar.Equals(ControlChars.Back) Then
					If Not Char.IsNumber(e.KeyChar) Then
						e.Handled = True
					End If
				End If
			End If

			If Not e.Handled Then
				MyBase.OnKeyPress(e)
			End If
		End Sub

		Public Overrides Function GetPreferredSize(ByVal constrainingSize As Size) As Size
			' Use the default size if the text box is on the overflow menu 
			' or is on a vertical ToolStrip. 
			If IsOnOverflow OrElse Owner.Orientation = Orientation.Vertical Then
				Return DefaultSize
			End If

			' Declare a variable to store the total available width as  
			' it is calculated, starting with the display width of the  
			' owning ToolStrip.
'INSTANT VB NOTE: The variable width was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim width_Renamed As Int32 = Owner.DisplayRectangle.Width

			' Subtract the width of the overflow button if it is displayed.  
			If Owner.OverflowButton.Visible Then
				width_Renamed = width_Renamed - Owner.OverflowButton.Width - Owner.OverflowButton.Margin.Horizontal
			End If

			' Declare a variable to maintain a count of ToolStripSpringTextBox  
			' items currently displayed in the owning ToolStrip. 
			Dim springBoxCount As Int32 = 0

			For Each item As ToolStripItem In Owner.Items
				' Ignore items on the overflow menu. 
				If item.IsOnOverflow Then
					Continue For
				End If

				If TypeOf item Is ToolStripSpringTextBox Then
					' For ToolStripSpringTextBox items, increment the count and  
					' subtract the margin width from the total available width.
					springBoxCount += 1
					width_Renamed -= item.Margin.Horizontal
				Else
					' For all other items, subtract the full width from the total 
					' available width.
					width_Renamed = width_Renamed - item.Width - item.Margin.Horizontal
				End If
			Next item

			' If there are multiple ToolStripSpringTextBox items in the owning 
			' ToolStrip, divide the total available width between them.  
			If springBoxCount > 1 Then
				width_Renamed \= springBoxCount
			End If

			' If the available width is less than the default width, use the 
			' default width, forcing one or more items onto the overflow menu. 
			If width_Renamed < DefaultSize.Width Then
				width_Renamed = DefaultSize.Width
			End If

			' Retrieve the preferred size from the base class, but change the 
			' width to the calculated width. 
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Size = MyBase.GetPreferredSize(constrainingSize)
			size_Renamed.Width = width_Renamed

			' Added as a nice hack to size the control to the text.
			Dim textSize As Size = TextRenderer.MeasureText(Text, Font)

			If String.IsNullOrEmpty(Text) Then
				textSize = TextRenderer.MeasureText("     ", Font)
			End If

			If textSize.Width < size_Renamed.Width Then
				Return New Size(textSize.Width, size_Renamed.Height)
			Else
				Return size_Renamed
			End If
		End Function

		Public Property InputType() As Type
			Get
				Return _inputType
			End Get
			Set(ByVal value As Type)
				_inputType = value
			End Set
		End Property
	End Class
End Namespace
