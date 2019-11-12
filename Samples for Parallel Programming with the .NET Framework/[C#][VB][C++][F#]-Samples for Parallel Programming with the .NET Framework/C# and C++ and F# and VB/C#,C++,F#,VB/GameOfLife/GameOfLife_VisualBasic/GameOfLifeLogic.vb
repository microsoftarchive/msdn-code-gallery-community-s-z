'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: GameOfLifeLogic.vb
'
'--------------------------------------------------------------------------

Imports System.Threading.Tasks
Imports System.Collections.Concurrent
Imports Microsoft.Drawing

Namespace GameOfLife
	''' <summary>Represents the game of life board.</summary>
	Friend Class GameBoard
		''' <summary>Arrays used to store the current and next state of the game.</summary>
		Private _scratch?()(,) As Color
		''' <summary>Index into the scratch arrays that represents the current stage of the game.</summary>
		Private _currentIndex As Integer
		''' <summary>A pool of Bitmaps used for rendering.</summary>
		Private _pool As ObjectPool(Of Bitmap)

		''' <summary>Initializes the game board.</summary>
		''' <param name="width">The width of the board.</param>
		''' <param name="height">The height of the board.</param>
		''' <param name="initialDensity">The initial population density to use to populate the board.</param>
		''' <param name="pool">The pool of Bitmaps to use.</param>
		Public Sub New(ByVal width As Integer, ByVal height As Integer, ByVal initialDensity As Double, ByVal pool As ObjectPool(Of Bitmap))
            ' Validate parameters.
			If width < 1 Then
				Throw New ArgumentOutOfRangeException("width")
			End If
			If height < 1 Then
				Throw New ArgumentOutOfRangeException("height")
			End If
			If pool Is Nothing Then
				Throw New ArgumentNullException("pool")
			End If
			If initialDensity < 0 OrElse initialDensity > 1 Then
				Throw New ArgumentOutOfRangeException("initialDensity")
			End If

            ' Store parameters.
			_pool = pool
			Me.Width = width
			Me.Height = height

            ' Create the storage arrays.
			_scratch = New Color?(1)(,) { New Color?(width - 1, height - 1){}, New Color?(width - 1, height - 1){} }

            ' Populate the board randomly based on the provided initial density.
			Dim rand As New Random()
            For i = 0 To width - 1
                For j = 0 To height - 1
                    _scratch(_currentIndex)(i, j) = If((rand.NextDouble() < initialDensity), Color.FromArgb(rand.Next()), CType(Nothing, Color?))
                Next j
            Next i
		End Sub

		''' <summary>Moves to the next stage of the game, returning a Bitmap that represents the state of the board.</summary>
		''' <returns>A bitmap that represents the state of the board.</returns>
		''' <remarks>The returned Bitmap should be added back to the pool supplied to the constructor when usage of it is complete.</remarks>
		Public Function MoveNext() As Bitmap
            ' Get the current and next stage board arrays.
            Dim nextIndex = (_currentIndex + 1) Mod 2
            Dim current?(,) = _scratch(_currentIndex)
            Dim [next]?(,) = _scratch(nextIndex)
			Dim rand As New Random()

            ' Get a Bitmap from the pool to use.
			Dim bmp = _pool.GetObject()
			Using fastBmp As New FastBitmap(bmp)
                ' For every row.
                Dim body As Action(Of Integer) = Sub(i)
                                                     ' For every column.
                                                     For j = 0 To Height - 1
                                                         Dim count = 0
                                                         Dim r = 0, g = 0, b = 0

                                                         ' Count neighbors.
                                                         For x = i - 1 To i + 1
                                                             For y = j - 1 To j + 1
                                                                 If (x = i AndAlso j = y) OrElse x < 0 OrElse x >= Width OrElse y < 0 OrElse y >= Height Then
                                                                     Continue For
                                                                 End If
                                                                 Dim c? = current(x, y)
                                                                 If c.HasValue Then
                                                                     count += 1
                                                                     r += c.Value.R
                                                                     g += c.Value.G
                                                                     b += c.Value.B
                                                                 End If
                                                             Next y
                                                         Next x

                                                         ' Heuristic for alive or dead based on neighbor count and current state.
                                                         If count < 1 OrElse count >= 4 Then
                                                             [next](i, j) = Nothing
                                                         ElseIf current(i, j).HasValue AndAlso (count = 2 OrElse count = 3) Then
                                                             [next](i, j) = current(i, j)
                                                         ElseIf (Not current(i, j).HasValue) AndAlso count = 3 Then
                                                             [next](i, j) = Color.FromArgb(r \ count, g \ count, b \ count)
                                                         Else
                                                             [next](i, j) = Nothing
                                                         End If

                                                         ' Render the cell.
                                                         fastBmp.SetColor(i, j, If(current(i, j), Color.White))
                                                     Next j
                                                 End Sub

                ' Process the rows serially or in parallel based on the RunParallel property setting.
				If RunParallel Then
					Parallel.For(0, Width, body)
				Else
                    For i = 0 To Width - 1
                        body(i)
                    Next i
				End If
			End Using

			' Update and return
			_currentIndex = nextIndex
			Return bmp
		End Function

		''' <summary>Gets the width of the board.</summary>
		Private privateWidth As Integer
		Public Property Width() As Integer
			Get
				Return privateWidth
			End Get
			Private Set(ByVal value As Integer)
				privateWidth = value
			End Set
		End Property
		''' <summary>Gets the height of the board.</summary>
		Private privateHeight As Integer
		Public Property Height() As Integer
			Get
				Return privateHeight
			End Get
			Private Set(ByVal value As Integer)
				privateHeight = value
			End Set
		End Property
		''' <summary>Gets or sets whether to run in parallel.</summary>
		Public Property RunParallel() As Boolean
	End Class
End Namespace