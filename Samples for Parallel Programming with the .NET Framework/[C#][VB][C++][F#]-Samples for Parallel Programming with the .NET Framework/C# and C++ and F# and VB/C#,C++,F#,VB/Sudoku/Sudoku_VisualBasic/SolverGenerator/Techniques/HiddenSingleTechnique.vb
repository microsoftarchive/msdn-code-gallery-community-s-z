'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: HiddenSingleTechnique.vb
'
'  Description: Implements the Sudoku hidden single technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the hidden single elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class HiddenSingleTechnique
		Inherits EliminationTechnique
		''' <summary>Initialize the technique.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 3
			End Get
		End Property

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			Return TypeOf obj Is HiddenSingleTechnique
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
            Dim gridSize = state.GridSize
            Dim boxSize = state.BoxSize

            ' For each number that can exist in the puzzle (0-8, etc.)
            For n = 0 To CType((gridSize - 1), Byte)
                ' For each row, if number only exists as a possibility in one cell, set it.
                For x = 0 To CType((gridSize - 1), Byte)
                    Dim seenIndex? As Integer = Nothing
                    For y = 0 To CType((gridSize - 1), Byte)
                        If possibleNumbers(x)(y)(n) Then
                            ' If this is the first time we're seeing the number, remember
                            ' where we're seeing it
                            If Not seenIndex.HasValue Then
                                seenIndex = y
                                ' We've seen this number before, so move on
                            Else
                                seenIndex = Nothing
                                Exit For
                            End If
                        End If
                    Next y
                    If seenIndex.HasValue AndAlso possibleNumbers(x)(seenIndex.Value).CountSet > 1 Then
                        possibleNumbers(x)(seenIndex.Value).SetAll(False)
                        possibleNumbers(x)(seenIndex.Value)(n) = True
                        numberOfChanges += 1
                        If exitEarlyWhenSoleFound Then
                            exitedEarly = True
                            Return False
                        End If
                    End If
                Next x

                ' For each column, if number only exists as a possibility in one cell, set it.
                ' Same basic logic as above.
                For y = 0 To CType((gridSize - 1), Byte)
                    Dim seenIndex? As Integer = Nothing
                    For x = 0 To CType((gridSize - 1), Byte)
                        If possibleNumbers(x)(y)(n) Then
                            If Not seenIndex.HasValue Then
                                seenIndex = x
                            Else
                                seenIndex = Nothing
                                Exit For
                            End If
                        End If
                    Next x
                    If seenIndex.HasValue AndAlso possibleNumbers(seenIndex.Value)(y).CountSet > 1 Then
                        possibleNumbers(seenIndex.Value)(y).SetAll(False)
                        possibleNumbers(seenIndex.Value)(y)(n) = True
                        numberOfChanges += 1
                        If exitEarlyWhenSoleFound Then
                            exitedEarly = True
                            Return False
                        End If
                    End If
                Next y

                ' For each grid, if number only exists as a possibility in one cell, set it.
                ' Same basic logic as above.
                For gridNum = 0 To CType((gridSize - 1), Byte)
                    Dim gridX = CByte(gridNum Mod boxSize)
                    Dim gridY = CByte(gridNum \ boxSize)

                    Dim startX = CByte(gridX * boxSize)
                    Dim startY = CByte(gridY * boxSize)

                    Dim canEliminate = True
                    Dim seenIndex? As Point = Nothing
                    Dim x = startX
                    Do While x < startX + boxSize AndAlso canEliminate
                        For y = startY To CType((startY + boxSize - 1), Byte)
                            If possibleNumbers(x)(y)(n) Then
                                If Not seenIndex.HasValue Then
                                    seenIndex = New Point(x, y)
                                Else
                                    canEliminate = False
                                    seenIndex = Nothing
                                    Exit For
                                End If
                            End If
                        Next y
                        x += CType(1, Byte)
                    Loop

                    If seenIndex.HasValue AndAlso canEliminate AndAlso possibleNumbers(seenIndex.Value.X)(seenIndex.Value.Y).CountSet > 1 Then
                        possibleNumbers(seenIndex.Value.X)(seenIndex.Value.Y).SetAll(False)
                        possibleNumbers(seenIndex.Value.X)(seenIndex.Value.Y)(n) = True
                        numberOfChanges += 1
                        If exitEarlyWhenSoleFound Then
                            exitedEarly = True
                            Return False
                        End If
                    End If
                Next gridNum
            Next n

            Return numberOfChanges <> 0
        End Function
	End Class
End Namespace