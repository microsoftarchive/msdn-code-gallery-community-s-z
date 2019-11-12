'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ScalingPanel.vb
'
'  Description: A panel that maintains the relative size and position of its children.
' 
'--------------------------------------------------------------------------


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>Resizes contained controls based on maintaining original aspect ratios.</summary>
	Friend Class ScalingPanel
		Inherits NoFlickerPanel
		''' <summary>Initializes the panel.</summary>
		Public Sub New()
		End Sub

		''' <summary>The initial bounds of the panel.</summary>
		Private _initialBounds As Rectangle

		''' <summary>Table of controls and their respective original bounds.</summary>
		Private _controlBounds As Dictionary(Of Control, Rectangle)

		''' <summary>Whether the panel has been initialized.</summary>
		Private _initialized As Boolean

		''' <summary>Initializes the panel based on the current controls in it.</summary>
		Public Sub ConfigureByContainedControls()
			_initialBounds = Bounds
			_controlBounds = New Dictionary(Of Control,Rectangle)()
            For Each c As Control In Me.Controls
                _controlBounds.Add(c, c.Bounds)
            Next c
			_initialized = True
		End Sub

		''' <summary>Rescales all contained controls.</summary>
		''' <param name="levent">Event arguments.</param>
		Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
			If _initialized AndAlso Width > 0 AndAlso Height > 0 AndAlso levent.AffectedControl Is Me Then
				' Maintain original aspect ratio
                Dim newWidth = Width
                Dim tmp = CInt(Fix(_initialBounds.Width / CDbl(_initialBounds.Height) * Height))
				If tmp < newWidth Then
					newWidth = tmp
				End If

                Dim newHeight = Height
				tmp = CInt(Fix(_initialBounds.Height / CDbl(_initialBounds.Width) * newWidth))
				If tmp < newHeight Then
					newHeight = tmp
				End If

				' Keep track of max and min boundaries
                Dim minX = Integer.MaxValue, minY = Integer.MaxValue, maxX = -1, maxY = -1

				' Move and resize all controls
                For Each c As Control In Me.Controls
                    Dim rect = CType(_controlBounds(CType(c, Control)), Rectangle)

                    ' Determine initial best guess at size
                    Dim x = CInt(Fix(rect.X / CDbl(_initialBounds.Width) * newWidth))
                    Dim y = CInt(Fix(rect.Y / CDbl(_initialBounds.Height) * newHeight))
                    Dim width = CInt(Fix(rect.Width / CDbl(_initialBounds.Width) * newWidth))
                    Dim height = CInt(Fix(rect.Height / CDbl(_initialBounds.Height) * newHeight))

                    ' Set the new bounds
                    Dim newBounds As New Rectangle(x, y, width, height)
                    If newBounds <> c.Bounds Then
                        c.Bounds = newBounds
                    End If

                    ' Keep track of max and min boundaries
                    If c.Left < minX Then
                        minX = c.Left
                    End If
                    If c.Top < minY Then
                        minY = c.Top
                    End If
                    If c.Right > maxX Then
                        maxX = c.Right
                    End If
                    If c.Bottom > maxY Then
                        maxY = c.Bottom
                    End If
                Next c

				' Center all controls
                Dim moveX = CType(((Width - (maxX - minX + 1)) / 2), Integer)
                Dim moveY = CType(((Height - (maxY - minY + 1)) / 2), Integer)

				If moveX > 0 OrElse moveY > 0 Then
                    For Each c As Control In Me.Controls
                        c.Location = c.Location + New Size(moveX - minX, moveY - minY)
                    Next c
				End If
			End If

			' Do base layout
			MyBase.OnLayout (levent)
		End Sub
	End Class
End Namespace