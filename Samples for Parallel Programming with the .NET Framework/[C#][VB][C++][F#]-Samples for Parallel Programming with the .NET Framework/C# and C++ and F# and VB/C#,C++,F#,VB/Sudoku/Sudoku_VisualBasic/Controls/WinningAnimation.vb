'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: WinningAnimation.vb
'
'  Description: A controls that displays an animation when a puzzle is solved.
' 
'--------------------------------------------------------------------------

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>End of game animation for the Puzzle Grid.</summary>
	Friend Class WinningAnimation
		Inherits Control
		''' <summary>Used for randomness in the animation.</summary>
		Private _rand As Random
		''' <summary>List of sprites to be rendered.</summary>
		Private _sprites As List(Of ImageSprite)
		''' <summary>Animation timer.</summary>
		Private _timer As Timer
		''' <summary>Used for centering text in the window.</summary>
		Private _sf As StringFormat
		''' <summary>PuzzleGrid in which we're contained.</summary>
		Private _grid As PuzzleGrid

		''' <summary>Initializes the animation.</summary>
		''' <param name="grid">The grid in which this animation should be displayed.</param>
		Public Sub New(ByVal grid As PuzzleGrid)
			MyBase.New(grid, String.Empty)
			_rand = New Random()
			_grid = grid
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or
                     ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
			BackColor = Color.Transparent
			Visible = False
		End Sub

		''' <summary>An image to render underneath the sprites.</summary>
		Private _underImage As Bitmap

		Protected Overrides Sub OnResize(ByVal e As EventArgs)
			MyBase.OnResize (e)

			' NOTE: This Bitmap and Region work is done to workaround
			' the performance issues causes by using BackColor = Color.Transparent,
			' which would allow the exact functionality we want, but which is very
			' slow when the window is big or maximized.
            Dim width = Me.Width, height = Me.Height
			If width > 0 AndAlso height > 0 Then
				' Update the boundaries of the control so we only draw within our own area
                Dim arcSize = CInt(Fix(width / 14.5))
				If Region IsNot Nothing Then
					Region.Dispose()
					Region = Nothing
				End If
                Using path = GraphicsHelpers.CreateRoundedRectangle(width, height, arcSize)
                    Region = New Region(path)
                End Using

				' Update the background underlying image to be rendered under
				' the sprites
				If _underImage IsNot Nothing Then
					_underImage.Dispose()
				End If
				_underImage = New Bitmap(width, height, PixelFormat.Format32bppPArgb)
                Using g = Graphics.FromImage(_underImage)
                    _grid.DrawToGraphics(g, _grid.ClientRectangle)
                    Using b As New SolidBrush(Color.FromArgb(128, Color.SlateGray))
                        g.FillRectangle(b, ClientRectangle)
                    End Using
                End Using
			End If
		End Sub

		''' <summary>Raises the VisibleChanged event and sets whether the animation is running based on the visibility.</summary>
		Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
			MyBase.OnVisibleChanged (e)
			AnimationEnabled = Visible
		End Sub

		''' <summary>Gets or sets whether the animation is enabled.</summary>
		Private Property AnimationEnabled() As Boolean
			Get
				Return _timer IsNot Nothing
			End Get
			Set(ByVal value As Boolean)
				If value Then
					' Reset any state from last time around
					If _timer IsNot Nothing Then
						Cleanup()
					End If
					OnResize(EventArgs.Empty)

					' Sets up string formatting so that the congratulations text is centered
					BackColor = Color.Black
					_sf = New StringFormat()
					_sf.Alignment = StringAlignment.Center
					_sf.LineAlignment = StringAlignment.Center

					' Create the list to store the sprites
					_sprites = New List(Of ImageSprite)(_grid.State.GridSize*_grid.State.GridSize)

					' Setup the animation timer
					_timer = New Timer()
					_timer.Interval = 1000\24 ' 24 fps
					AddHandler _timer.Tick, AddressOf UpdateSpritesOnTimerTick

					' Initialize all of the sprites
					Using bmp As New Bitmap(_grid.ClientRectangle.Width, _grid.ClientRectangle.Height)
						' Take a snapshot of the underlying puzzle grid
                        Using g = Graphics.FromImage(bmp)
                            _grid.DrawToGraphics(g, _grid.ClientRectangle)
                        End Using

						' Setup each individual sprite based on pulling out a section
						' of the underlying grid snapshot
                        For i = 0 To _grid.State.GridSize - 1
                            For j = 0 To _grid.State.GridSize - 1
                                Dim cellRect = PuzzleGrid.GetCellRectangle(_grid.BoardRectangle, New Point(i, j))
                                Dim smallImage As New Bitmap(CInt(Fix(cellRect.Width)), CInt(Fix(cellRect.Height)), PixelFormat.Format32bppPArgb)
                                Using g = Graphics.FromImage(smallImage)
                                    g.DrawImage(bmp, 0, 0, cellRect, GraphicsUnit.Pixel)
                                End Using
                                Dim s As New ImageSprite(smallImage)

                                ' Each sprite is setup with random velocity and angular velocity.
                                ' It's position is set to overlap with the underlying puzzle grid.
                                Const maxSpeed = 10

                                ' Set the location to the same location as on the grid
                                Dim loc = Point.Truncate(cellRect.Location)
                                s.Location = PointToClient(_grid.PointToScreen(loc))

                                ' Set a random linear velocity
                                Do
                                    s.Velocity = New Size(_rand.Next(maxSpeed * 2) - maxSpeed, _rand.Next(maxSpeed * 2) - maxSpeed)
                                Loop While s.Velocity.Width >= -2 AndAlso s.Velocity.Width <= 2 AndAlso s.Velocity.Height >= -2 AndAlso s.Velocity.Height <= 2

                                ' Set a random angular velocity
                                Do
                                    s.AngularVelocity = CSng(_rand.Next(maxSpeed * 2)) - maxSpeed
                                Loop While s.AngularVelocity = 0
                                s.RotateAroundCenter = (_rand.Next(2) = 0)

                                ' Set a random flip speed (really angular velocity but around a different axis)
                                Do
                                    s.FlipSpeed = _rand.Next(maxSpeed * 2) - (maxSpeed)
                                Loop While s.FlipSpeed = 0

                                ' Add the completed sprite to the list
                                _sprites.Add(s)
                            Next j
                        Next i
					End Using

					_timer.Start()
				Else
					Cleanup()
				End If
			End Set
		End Property

		''' <summary>Cleans up resources.</summary>
		Private Sub Cleanup()
			If _timer IsNot Nothing Then
				_timer.Stop()
				_timer.Dispose()
				_timer = Nothing
			End If
			If _underImage IsNot Nothing Then
				_underImage.Dispose()
				_underImage = Nothing
			End If
			If _sf IsNot Nothing Then
				_sf.Dispose()
				_sf = Nothing
			End If
			If _sprites IsNot Nothing Then
                For Each disposable In _sprites
                    disposable.Dispose()
                Next disposable
				_sprites = Nothing
			End If
		End Sub

		''' <summary>Releases the unmanaged resources used by the Control and optionally releases the managed resources.</summary>
		''' <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				Cleanup()
			End If
			MyBase.Dispose(disposing)
		End Sub

		''' <summary>Raises the Paint event.</summary>
		''' <param name="pe">A PaintEventArgs that contains the event data.</param>
		Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
			' Do base painting
			MyBase.OnPaint(pe)

			' Draw the base underlying image
			If _underImage IsNot Nothing Then
				pe.Graphics.DrawImage(_underImage, 0, 0)
			End If

			' Render all of the sprites
			If _sprites IsNot Nothing AndAlso _sprites.Count > 0 Then
                For i = _sprites.Count - 1 To 0 Step -1
                    Dim s = _sprites(i)
                    s.Paint(pe.Graphics)
                Next i
			End If

			' Show the congratulatory text
            Dim text = ResourceHelper.PuzzleSolvedCongratulations
			If _sf IsNot Nothing AndAlso text IsNot Nothing AndAlso text.Length > 0 Then
                Dim emSize = GraphicsHelpers.GetMaximumEMSize(text, pe.Graphics, Font.FontFamily, Font.Style, ClientRectangle.Width, ClientRectangle.Height)
				Using f As New Font(Font.FontFamily, emSize)
					pe.Graphics.DrawString(text, f, Brushes.Black, New RectangleF(2, 2, ClientRectangle.Width, ClientRectangle.Height), _sf)
					pe.Graphics.DrawString(text, f, Brushes.Gray, New RectangleF(-1, -1, ClientRectangle.Width, ClientRectangle.Height), _sf)
					pe.Graphics.DrawString(text, f, Brushes.Yellow, New RectangleF(0, 0, ClientRectangle.Width, ClientRectangle.Height), _sf)
				End Using
			End If
		End Sub

		''' <summary>Updates the position and orientation of all sprites on each timer tick.</summary>
		''' <param name="sender">The timer.</param>
		''' <param name="e">Event args.</param>
		Private Sub UpdateSpritesOnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
			If _timer IsNot Nothing Then
				If _sprites IsNot Nothing Then
					' Update each sprite
                    For i = _sprites.Count - 1 To 0 Step -1
                        ' Update the sprite
                        Dim s = _sprites(i)
                        s.Update()

                        ' If it's left the visible range, remove it from the list so we don't
                        ' need to deal with it any more
                        Dim bounds = ClientRectangle
                        If s.Location.X > bounds.Right + s.Image.Width OrElse s.Location.X < -s.Image.Width OrElse s.Location.Y >
                            bounds.Bottom + s.Image.Width OrElse s.Location.Y < -s.Image.Width Then
                            _sprites.RemoveAt(i)
                            s.Dispose()
                        End If
                    Next i

					' If there are no sprites left, stop the timer; we're done.
					If _sprites.Count = 0 Then ' stop but don't delete, as _timer is used as a marker
						_timer.Stop()
					End If

					' Refresh the window
					Invalidate()
				End If
			End If
		End Sub

		''' <summary>Represents an image sprite to be displayed as part of the animation.</summary>
		Friend Class ImageSprite
			Implements IDisposable
			''' <summary>The location of the sprite.</summary>
			Private _location As Point
			''' <summary>The rotational angle of the sprite.</summary>
			Private _angle As Single
			''' <summary>The current flipped position of the sprite (angular velocity around a different axis).</summary>
			Private _flipPosition As Single

			''' <summary>The linear velocity of the sprite.</summary>
			Private _velocity As Size
			''' <summary>The angular velocity of the sprite.</summary>
			Private _angularVelocity As Single
			''' <summary>The speed at which the sprite flips over itself.</summary>
			Private _flipSpeed As Single
			''' <summary>Whether to rotate around the center or corner.</summary>
			Private _rotateAroundCenter As Boolean

			''' <summary>The image that is the sprite.</summary>
			Private _bmp As Bitmap

			''' <summary>Initializes the sprite.</summary>
			''' <param name="bmp">The sprite's image.</param>
			Public Sub New(ByVal bmp As Bitmap)
				If bmp Is Nothing Then
					Throw New ArgumentNullException("bmp")
				End If
				_bmp = bmp
			End Sub

			''' <summary>Releases resources used by the sprite.</summary>
			Public Sub Dispose() Implements IDisposable.Dispose
				If _bmp IsNot Nothing Then
					_bmp.Dispose()
					_bmp = Nothing
				End If
			End Sub

			''' <summary>Gets the image that is the sprite.</summary>
			Public ReadOnly Property Image() As Bitmap
				Get
					Return _bmp
				End Get
			End Property
			''' <summary>Gets or sets the location of the sprite.</summary>
			Public Property Location() As Point
				Get
					Return _location
				End Get
				Set(ByVal value As Point)
					_location=value
				End Set
			End Property
			''' <summary>Gets or sets the flip speed of the sprite.</summary>
			Public Property FlipSpeed() As Single
				Get
					Return _flipSpeed
				End Get
				Set(ByVal value As Single)
					_flipSpeed=value
				End Set
			End Property
			''' <summary>Gets or sets the linear velocity of the sprite.</summary>
			Public Property Velocity() As Size
				Get
					Return _velocity
				End Get
				Set(ByVal value As Size)
					_velocity = value
				End Set
			End Property
			''' <summary>Gets or sets the angular velocity of the sprite.</summary>
			Public Property AngularVelocity() As Single
				Get
					Return _angularVelocity
				End Get
				Set(ByVal value As Single)
					_angularVelocity=value
				End Set
			End Property
			''' <summary>Sets whether to rotate around the center versus around a corner.</summary>
			Public WriteOnly Property RotateAroundCenter() As Boolean
				Set(ByVal value As Boolean)
					_rotateAroundCenter = value
				End Set
			End Property

			''' <summary>Renders the sprite.</summary>
			''' <param name="graphics">The graphics object onto which the sprite should be rendered.</param>
			Public Sub Paint(ByVal graphics As Graphics)
				' Rotate and translate the graphics object appropriately
				Using mx As New Matrix()
                    Dim gs = graphics.Save()
					If _rotateAroundCenter Then ' to rotate around the center rather than corner
						mx.Translate(-_bmp.Width\2, -_bmp.Height\2, MatrixOrder.Append)
					End If
					mx.Rotate(_angle, MatrixOrder.Append)
					If _rotateAroundCenter Then ' to rotate around the center rather than corner
						mx.Translate(_bmp.Width\2, _bmp.Height\2, MatrixOrder.Append)
					End If
					mx.Translate(_location.X, _location.Y, MatrixOrder.Append)
					graphics.Transform = mx

					' Draw the image
                    Dim flipMult = (CSng(Math.Cos(_flipPosition * Math.PI / 180.0)))
					If flipMult > 0.001 OrElse flipMult < -0.001 Then ' avoids an OOM exception from GDI+
                        graphics.DrawImage(_bmp, New RectangleF(0, 1 - Math.Abs(flipMult), _bmp.Width, _bmp.Height * flipMult),
                            New RectangleF(0, 0, _bmp.Width, _bmp.Height), GraphicsUnit.Pixel)
					End If

					' Restore the graphics object
					graphics.Restore(gs)
				End Using
			End Sub

			''' <summary>Updates the position and orientation of the sprite.</summary>
			Public Sub Update()
				' Update the location based on the lineary velocity
				_location = New Point(_location.X + _velocity.Width, _location.Y + _velocity.Height)

				' Update the flipped position based on the flip speed
				_flipPosition += _flipSpeed
				If _flipPosition >= 360 Then
					_flipPosition -= 360
				ElseIf _flipPosition < 0 Then
					_flipPosition += 360
				End If

				' Update the rotational angle based on the rotational velocity
				_angle += _angularVelocity
				If _angle >= 360 Then
					_angle -= 360
				ElseIf _angle < 0 Then
					_angle += 360
				End If
			End Sub
		End Class
	End Class
End Namespace