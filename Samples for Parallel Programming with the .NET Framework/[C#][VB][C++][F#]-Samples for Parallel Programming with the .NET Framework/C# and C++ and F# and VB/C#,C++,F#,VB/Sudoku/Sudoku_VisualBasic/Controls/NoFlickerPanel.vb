'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: NoFlickerPanel.vb
'
'  Description: A double-buffering and redraw-on-resizing panel.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>A derived panel that uses double buffering to prevent flicker.</summary>
	<ToolboxBitmap(GetType(Panel))>
	Friend Class NoFlickerPanel
		Inherits Panel
		''' <summary>Initializes the panel.</summary>
		Public Sub New()
            SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)
		End Sub
	End Class
End Namespace