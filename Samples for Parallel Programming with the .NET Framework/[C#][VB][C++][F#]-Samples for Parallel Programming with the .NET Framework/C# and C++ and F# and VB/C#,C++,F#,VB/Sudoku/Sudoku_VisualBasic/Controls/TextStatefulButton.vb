'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: TextStatefulButton.vb
'
'  Description: Custom button used for all buttons in Sudoku.
' 
'--------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>A custom button rendered with multiple images and text.</summary>
	<ToolboxBitmap(GetType(Button))>
	Friend NotInheritable Class TextStatefulButton
		Inherits Control
		''' <summary>Initializes the button.</summary>
		Public Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or
                     ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.CacheText, True)
			SetStyle(ControlStyles.StandardDoubleClick Or ControlStyles.StandardClick, False)
			SetStyle(ControlStyles.Selectable, False)
			BackColor = Color.Transparent

			_centeredFormat = New StringFormat() 'StringFormatFlags.FitBlackBox);
			_centeredFormat.LineAlignment = StringAlignment.Center
			_centeredFormat.Alignment = StringAlignment.Center
		End Sub

		''' <summary>Image used as the shadow of the control.</summary>
		Private _shadowImage As Image
		''' <summary>Image used to represent the pressed/checked state of the control.</summary>
		Private _checkedImage As Image
		''' <summary>Image used to represent the unpressed/unchecked state of the control.</summary>
		Private _uncheckedImage As Image
		''' <summary>Image used to represent the highlighted state of the control.</summary>
		Private _highlightedImage As Image
		''' <summary>Image used to represent the icon/overlay for the control.</summary>
		Private _overlayImage As Image

		''' <summary>Whether the control can be checked.</summary>
		Private _allowChecking As Boolean
		''' <summary>Whether the control can be unchecked by a user.</summary>
		Private _allowNonprogrammaticUnchecking As Boolean
		''' <summary>Whether the control is checked.</summary>
		Private _checked As Boolean
		''' <summary>Whether the control is currently highlighted.</summary>
		Private _highlighted As Boolean
		''' <summary>Whether the mouse is currently down.</summary>
		Private _mouseDown As Boolean

		''' <summary>Used to center the text.</summary>
		Private _centeredFormat As StringFormat
		''' <summary>The current font for rendering.</summary>
		Private _font As Font
		''' <summary>Whether the font should autosize to fit within the button.</summary>
		Private _autosizeFont As Boolean = True
		''' <summary>Whether the placement of text should be adjusted based on whether the button is checked.</summary>
		Private _adjustTextPlacement As Boolean = True

		''' <summary>Sets the image used as the shadow of the control.</summary>
		Public WriteOnly Property ShadowImage() As Image
			Set(ByVal value As Image)
				_shadowImage = value
			End Set
		End Property
		''' <summary>Sets the image used to represent the pressed/checked state of the control.</summary>
		Public WriteOnly Property CheckedImage() As Image
			Set(ByVal value As Image)
				_checkedImage = value
			End Set
		End Property
		''' <summary>Sets the image used to represent the unpressed/unchecked state of the control.</summary>
		Public WriteOnly Property UncheckedImage() As Image
			Set(ByVal value As Image)
				_uncheckedImage = value
			End Set
		End Property
		''' <summary>Sets the image used to represent the highlighted state of the control.</summary>
		Public WriteOnly Property HighlightedImage() As Image
			Set(ByVal value As Image)
				_highlightedImage = value
			End Set
		End Property
		''' <summary>Sets the image used to represent the icon/overlay for the control.</summary>
		Public WriteOnly Property OverlayImage() As Image
			Set(ByVal value As Image)
				_overlayImage = value
			End Set
		End Property

		''' <summary>Gets whether the control can be checked.</summary>
		Public Property AllowChecking() As Boolean
			Get
				Return _allowChecking
			End Get
			Set(ByVal value As Boolean)
				_allowChecking = value
			End Set
		End Property
		''' <summary>Gets whether the control can be unchecked by a user.</summary>
		Public Property AllowNonprogrammaticUnchecking() As Boolean
			Get
				Return _allowNonprogrammaticUnchecking
			End Get
			Set(ByVal value As Boolean)
				_allowNonprogrammaticUnchecking = value
			End Set
		End Property

		''' <summary>Gets whether the control is currently highlighted.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Private ReadOnly Property Highlighted() As Boolean
			Get
				Return _highlighted
			End Get
		End Property

		''' <summary>Gets wether the mouse is currently down.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Private ReadOnly Property MouseIsDown() As Boolean
			Get
				Return _mouseDown
			End Get
		End Property

		''' <summary>Gets or sets whether the control is checked.</summary>
		Public Property Checked() As Boolean
			Get
				Return If(_allowChecking, _checked, False)
			End Get
			Set(ByVal value As Boolean)
				If _allowChecking AndAlso _checked <> value Then
					Dim e As New CancelEventArgs(False)
					OnBeforeCheckedChanged(e)
					If Not e.Cancel Then
						_checked = value
						Invalidate()
						OnCheckedChanged()
					End If
				End If
			End Set
		End Property

		''' <summary>Gets or sets whether the control is focusable.</summary>
		Public Property Focusable() As Boolean
			Get
				Return GetStyle(ControlStyles.Selectable)
			End Get
			Set(ByVal value As Boolean)
				SetStyle(ControlStyles.Selectable, value)
			End Set
		End Property

		''' <summary>Gets or sets whether the control supports auto-font resize.</summary>
		Public Property AutosizeFont() As Boolean
			Get
				Return _autosizeFont
			End Get
			Set(ByVal value As Boolean)
				_autosizeFont = value
			End Set
		End Property

		''' <summary>Gets or sets whether the font size should be adjusted based on whether the control is checked.</summary>
		Public Property AdjustTextPlacementWhenChecked() As Boolean
			Get
				Return _adjustTextPlacement
			End Get
			Set(ByVal value As Boolean)
				_adjustTextPlacement = value
			End Set
		End Property

		''' <summary>Event raised before the control's checked state changes.</summary>
		Public Event BeforeCheckedChanged As CancelEventHandler
		''' <summary>Event raised after the control's checked state changes.</summary>
		Public Event CheckedChanged As EventHandler

		''' <summary>Cleans up.</summary>
		''' <param name="disposing">Whether this is the result of a call to IDisposable.Dispose.</param>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If _centeredFormat IsNot Nothing Then
					_centeredFormat.Dispose()
					_centeredFormat = Nothing
				End If
				If _font IsNot Nothing Then
					_font.Dispose()
					_font = Nothing
				End If
			End If
			MyBase.Dispose (disposing)
		End Sub

		''' <summary>Handles the control's resize.</summary>
		Protected Overrides Sub OnResize(ByVal e As EventArgs)
			ClearFont()
			MyBase.OnResize(e)
		End Sub

		''' <summary>Handles the control's layout.</summary>
		Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
			ClearFont()
			MyBase.OnLayout (levent)
		End Sub

		''' <summary>Handles the control's font change.</summary>
		Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
			ClearFont()
			MyBase.OnFontChanged (e)
		End Sub

		''' <summary>Handles the control's checked change.</summary>
		Private Sub OnCheckedChanged()
			ClearFont()
            Dim e = CheckedChangedEvent
			If e IsNot Nothing Then
				e(Me, EventArgs.Empty)
			End If
		End Sub

		''' <summary>Raises the BeforeCheckedChanged event.</summary>
		Private Sub OnBeforeCheckedChanged(ByVal e As CancelEventArgs)
            Dim handler = BeforeCheckedChangedEvent
			If handler IsNot Nothing Then
				handler(Me, e)
			End If
		End Sub

		''' <summary>Handles the mouse enter event.</summary>
		Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
			MyBase.OnMouseEnter (e)
			_highlighted = True
			Invalidate()
		End Sub

		''' <summary>Handles the mouse leave event.</summary>
		Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
			MyBase.OnMouseLeave (e)
			_highlighted = False
			Invalidate()
		End Sub

		''' <summary>Handles the mouse down event.</summary>
		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.OnMouseDown (e)
			If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
				_highlighted = False
				_mouseDown = True
				If _allowNonprogrammaticUnchecking OrElse (Not Checked) Then
					Checked = Not Checked
				End If
				If Focusable Then                   
                    Me.[Select]()
                End If
				Invalidate()
			End If
		End Sub

		''' <summary>Handles the mouse up event.</summary>
		Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
			If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
				_mouseDown = False
				If Not AllowChecking Then
                    Dim mousePosition = Control.MousePosition
					If ClientRectangle.Contains(PointToClient(mousePosition)) Then
						_highlighted = True
					End If
				End If
				Invalidate()
				If ClientRectangle.Contains(PointToClient(MousePosition)) Then
					OnClick(e)
				End If
			End If
			MyBase.OnMouseUp (e)
		End Sub

		''' <summary>Clears the currently cached font.</summary>
		Private Sub ClearFont()
			If _font IsNot Nothing Then
                Dim f = _font
				_font = Nothing
				f.Dispose()
			End If
		End Sub

		''' <summary>Gets the font to use for rendering.</summary>
		''' <returns>The font to use for rendering.</returns>
		Private Function GetFontForText() As Font
			If Not _autosizeFont Then
				Return MyBase.Font
			End If
			If _font Is Nothing Then
                Dim baseFont = MyBase.Font
				If Text Is Nothing OrElse Text.Length = 0 Then
					Return baseFont
				End If
                Using g = CreateGraphics()
                    Dim width = Me.Width * 9 \ 10
                    Dim height = Me.Height * 9 \ 10
                    _font = New Font(baseFont.FontFamily, GraphicsHelpers.GetMaximumEMSize(Text, g, baseFont.FontFamily,
                                                            baseFont.Style, width, height), baseFont.Style)
                End Using
			End If
			Return _font
		End Function

		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
			If e.KeyCode = Keys.Enter Then
				OnClick(e)
			Else
				MyBase.OnKeyDown (e)
			End If
		End Sub

		Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
			MyBase.OnGotFocus (e)
			Invalidate()
		End Sub

		Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
			MyBase.OnLostFocus (e)
			Invalidate()
		End Sub

		''' <summary>Paints the button.</summary>
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			MyBase.OnPaint(e)

			' Setup the graphics object
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality

			' Determine the image to be drawn based on the current state
            Dim img = _uncheckedImage
			If Enabled AndAlso Visible Then
				If Checked OrElse _mouseDown Then
					img = _checkedImage
				ElseIf _highlighted OrElse Me.Focused Then
					img = _highlightedImage
				End If
			End If

			If img IsNot Nothing Then
				Using attrs As New ImageAttributes()
					' If the control is disabled, use alpha blending
					Dim m As New ColorMatrix()
					m.Matrix33 = If(Enabled AndAlso Visible, 1f, .5f)
					attrs.SetColorMatrix(m)

                    Dim width = ClientRectangle.Width
                    Dim height = ClientRectangle.Height

					' Draw the shadow if appropriate
					If Enabled AndAlso Visible AndAlso (Not Checked) AndAlso (Not MouseIsDown) AndAlso _shadowImage IsNot Nothing Then
                        e.Graphics.DrawImage(_shadowImage, New Rectangle(1, 1, width, height), 0, 0, _shadowImage.Width, _shadowImage.Height,
                                             GraphicsUnit.Pixel, attrs)
					End If
					width -= 2
					height -= 2

					' Draw the image
					e.Graphics.DrawImage(img, New Rectangle(0, 0, width, height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attrs)

					' Draw the icon if appropriate
					If _overlayImage IsNot Nothing Then
						Dim targetRect As New Rectangle(0, 0, width, height)
						targetRect.Inflate(-width\8, -height\8)
						If Enabled AndAlso Visible AndAlso (Checked OrElse _mouseDown) Then
							targetRect.Offset(CInt(Fix(Math.Ceiling(ClientRectangle.Height/20f))), CInt(Fix(Math.Ceiling(ClientRectangle.Height/20f))))
							targetRect.Inflate(CInt(Fix(Math.Ceiling(-ClientRectangle.Height/30f))), CInt(Fix(Math.Ceiling(-ClientRectangle.Height/30f))))
						End If
						e.Graphics.DrawImage(_overlayImage, targetRect, 0, 0, _overlayImage.Width, _overlayImage.Height, GraphicsUnit.Pixel, attrs)
					End If

					' If there's text to display
					If Text IsNot Nothing AndAlso Text.Length > 0 Then
						Dim bounds As New RectangleF(0, 0, width, height)

						' Update the bounds if necessary
						If Enabled AndAlso Visible AndAlso AdjustTextPlacementWhenChecked AndAlso (Checked OrElse MouseIsDown) Then
							bounds.Inflate(-ClientRectangle.Height\6, -ClientRectangle.Height\6)
							bounds.Offset(ClientRectangle.Height\15, ClientRectangle.Height\15)
						End If

						' Get the color to use for the text, alpha blended if the control is disabled
                        Dim c = ForeColor
						If (Not Enabled) OrElse (Not Visible) Then
							c = Color.FromArgb(128, c)
						End If

						' Draw it
                        Using b = New SolidBrush(c) ' Can cache this for improved performance
                            e.Graphics.DrawString(Text, GetFontForText(), b, bounds, _centeredFormat)
                        End Using
					End If
				End Using
			End If
		End Sub
	End Class
End Namespace