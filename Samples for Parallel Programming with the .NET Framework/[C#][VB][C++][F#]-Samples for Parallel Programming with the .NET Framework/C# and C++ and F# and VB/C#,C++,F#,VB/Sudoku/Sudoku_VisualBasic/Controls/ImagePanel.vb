'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ImagePanel.vb
'
'  Description: A panel used to render a double-buffered image.
' 
'--------------------------------------------------------------------------

Imports System.ComponentModel

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>Double-buffered panel that displays a stretched image.</summary>
	Friend Class ImagePanel
		Inherits NoFlickerPanel
		''' <summary>Initializes the panel.</summary>
		Public Sub New()
		End Sub

		''' <summary>The image to be rendered.</summary>
		Private _img As Image

		''' <summary>Gets or sets the image to be rendered.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Public Property Image() As Image
			Get
				Return _img
			End Get
			Set(ByVal value As Image)
				_img = value
			End Set
		End Property

		''' <summary>Paints the image.</summary>
		''' <param name="e">Paint event args.</param>
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			If _img IsNot Nothing Then
				e.Graphics.DrawImage(_img, 0, 0, Width, Height)
			End If
			MyBase.OnPaint(e)
		End Sub
	End Class
End Namespace