'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: NakedSingleTechnique.vb
'
'  Description: Implements the Sudoku naked single technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the naked single elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class NakedSingleTechnique
		Inherits EliminationTechnique
		''' <summary>Initialize the technique.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 2
			End Get
		End Property

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			Return TypeOf obj Is NakedSingleTechnique
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return Me.GetType().GetHashCode()
		End Function

		''' <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="possibleNumbers">The previously computed possible numbers.</param>
		''' <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		''' <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        Friend Overrides Function Execute(ByVal state As PuzzleState, ByVal exitEarlyWhenSoleFound As Boolean,
                    ByVal possibleNumbers()() As FastBitArray, <System.Runtime.InteropServices.Out()> ByRef numberOfChanges As Integer,
                    <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Boolean
            numberOfChanges = 0
            exitedEarly = False

            ' Eliminate impossible numbers based on numbers already set in the grid
            For i = 0 To state.GridSize - 1
                For j = 0 To state.GridSize - 1
                    ' If this cell has a value, we use it to eliminate numbers in other cells
                    If state(i, j).HasValue Then
                        Dim valueToEliminate = state(i, j).Value

                        ' eliminate numbers in same row
                        For y = 0 To state.GridSize - 1
                            If possibleNumbers(i)(y)(valueToEliminate) Then
                                numberOfChanges += 1
                                possibleNumbers(i)(y)(valueToEliminate) = False
                            End If
                        Next y

                        ' eliminate numbers in same column
                        For x = 0 To state.GridSize - 1
                            If possibleNumbers(x)(j)(valueToEliminate) Then
                                numberOfChanges += 1
                                possibleNumbers(x)(j)(valueToEliminate) = False
                            End If
                        Next x

                        ' eliminate numbers in same box
                        Dim boxStartX = (i \ state.BoxSize) * state.BoxSize
                        For x = boxStartX To boxStartX + state.BoxSize - 1
                            Dim boxStartY = (j \ state.BoxSize) * state.BoxSize
                            For y = boxStartY To boxStartY + state.BoxSize - 1
                                If possibleNumbers(x)(y)(valueToEliminate) Then
                                    numberOfChanges += 1
                                    possibleNumbers(x)(y)(valueToEliminate) = False
                                End If
                            Next y
                        Next x
                    End If
                Next j
            Next i

            Return False
        End Function
	End Class
End Namespace