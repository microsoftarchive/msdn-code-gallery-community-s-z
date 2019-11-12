'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: BeginnerTechnique.vb
'
'  Description: Implements the Sudoku beginner technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the beginner elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class BeginnerTechnique
		Inherits EliminationTechnique
		''' <summary>Initialize the technique.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 1
			End Get
		End Property

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			Return TypeOf obj Is BeginnerTechnique
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return Me.GetType().GetHashCode()
		End Function

		''' <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="exitEarlyWhenSoleFound">Whether the method can exit early when a cell with only one possible number is found.</param>
		''' <param name="possibleNumbers">The previously computed possible numbers.</param>
		''' <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		''' <param name="exitedEarly">Whether the method exited early due to a cell with only one value being found.</param>
		''' <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        Friend Overrides Function Execute(ByVal state As PuzzleState, ByVal exitEarlyWhenSoleFound As Boolean,
            ByVal possibleNumbers()() As FastBitArray, <System.Runtime.InteropServices.Out()> ByRef numberOfChanges As Integer,
            <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Boolean
            numberOfChanges = 0
            exitedEarly = False

            Dim numLocations As Integer
            Dim locations(state.GridSize - 1) As Point

            For n = 0 To state.GridSize - 1
                ' Find all occurrences of n.  If GridSize or more are found, no point in continuing
                ' on.  Obviously if more than GridSize are found, there's a mistake somewhere on the
                ' board (at least one), but that's not our problem.
                numLocations = 0
                Dim row = 0
                Do While row < state.GridSize AndAlso numLocations < state.GridSize
                    Dim column = 0
                    Do While column < state.GridSize AndAlso numLocations < state.GridSize
                        If state(row, column).HasValue AndAlso state(row, column).Value = n Then
                            locations(numLocations) = New Point(row, column)
                            numLocations += 1
                        End If

                        column += 1
                    Loop
                    row += 1
                Loop
                If numLocations >= state.GridSize Then
                    Continue For
                End If

                ' For each box
                For box = 0 To state.GridSize - 1
                    Dim done = False

                    ' If any of the cells in the box is the number, bail
                    Dim boxStartX = (box Mod state.BoxSize) * state.BoxSize
                    Dim x = boxStartX
                    Do While x < boxStartX + state.BoxSize AndAlso Not done
                        Dim boxStartY = (box \ state.BoxSize) * state.BoxSize
                        Dim y = boxStartY
                        Do While y < boxStartY + state.BoxSize AndAlso Not done
                            Dim cell As New Point(x, y)
                            If (state(cell).HasValue AndAlso state(cell).Value = n) OrElse ((Not state(cell).HasValue) AndAlso
                                                possibleNumbers(x)(y).CountSet = 1 AndAlso possibleNumbers(x)(y)(n)) Then
                                done = True
                            End If
                            y += 1
                        Loop
                        x += 1
                    Loop
                    If done Then
                        Continue For
                    End If

                    ' Look at each cell in the box
                    Dim targetCell As New Point(-1, -1)
                    boxStartX = (box Mod state.BoxSize) * state.BoxSize
                    x = boxStartX
                    Do While x < boxStartX + state.BoxSize AndAlso Not done
                        Dim boxStartY = (box \ state.BoxSize) * state.BoxSize
                        Dim y = boxStartY
                        Do While y < boxStartY + state.BoxSize AndAlso Not done
                            ' See if there's only one cell in the box that can be
                            ' this number.  If there is, it must be there.
                            Dim cell As New Point(x, y)
                            If (Not state(cell).HasValue) AndAlso possibleNumbers(x)(y)(n) Then
                                Dim invalid = False
                                For locNum = 0 To numLocations - 1
                                    If locations(locNum).X = cell.X OrElse locations(locNum).Y = cell.Y Then
                                        invalid = True
                                        Exit For
                                    End If
                                Next locNum
                                If Not invalid Then
                                    If targetCell = New Point(-1, -1) Then
                                        targetCell = cell
                                    Else
                                        targetCell = New Point(-1, -1)
                                        done = True
                                    End If
                                End If
                            End If
                            y += 1
                        Loop
                        x += 1
                    Loop

                    ' If we found a cell we can fill in, modify the possible numbers list appropriately
                    If targetCell <> New Point(-1, -1) Then
                        possibleNumbers(targetCell.X)(targetCell.Y).SetAll(False)
                        possibleNumbers(targetCell.X)(targetCell.Y)(n) = True
                        numberOfChanges += 1
                        If exitEarlyWhenSoleFound Then
                            exitedEarly = True
                            Return False
                        End If
                    End If
                Next box
            Next n

            ' If numberOfChanges > 0, we made a change to possibleNumbers, but the state
            ' itself wasn't affected.  Thus, running this again won't help.
            Return False
        End Function
	End Class
End Namespace