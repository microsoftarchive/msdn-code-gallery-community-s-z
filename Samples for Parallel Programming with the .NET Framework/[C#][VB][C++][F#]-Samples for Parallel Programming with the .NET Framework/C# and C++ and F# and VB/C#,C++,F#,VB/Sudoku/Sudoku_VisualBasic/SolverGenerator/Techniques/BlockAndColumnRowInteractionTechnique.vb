'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: BlockAndColumnRowInteractionTechnique.vb
'
'  Description: Implements the Sudoku block and column/row interaction technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the coloring elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class BlockAndColumnRowInteractionTechnique
		Inherits EliminationTechnique
		''' <summary>Initialize the technique.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 4
			End Get
		End Property

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			Return TypeOf obj Is BlockAndColumnRowInteractionTechnique
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

            ' Find the open cells in this block
            Dim numLocations As Integer
            Dim foundLocations(state.GridSize - 1) As Point

            ' Analyze each box
            For box = 0 To state.GridSize - 1
                For n = 0 To state.GridSize - 1
                    numLocations = 0

                    ' Find all locations that n is possible within the box
                    Dim boxStartX = (box \ state.BoxSize) * state.BoxSize
                    Dim x = boxStartX
                    Do While x < boxStartX + state.BoxSize AndAlso numLocations <= state.BoxSize
                        Dim boxStartY = (box Mod state.BoxSize) * state.BoxSize
                        Dim y = boxStartY
                        Do While y < boxStartY + state.BoxSize AndAlso numLocations <= state.BoxSize
                            If possibleNumbers(x)(y)(n) Then
                                foundLocations(numLocations) = New Point(x, y)
                                numLocations += 1
                            End If
                            y += 1
                        Loop
                        x += 1
                    Loop

                    ' We only care if two or three are open in the grid and if they're
                    ' in the same row or column
                    If numLocations > 1 AndAlso numLocations <= state.BoxSize Then
                        Dim matchesRow = True, matchesColumn = True
                        Dim row = foundLocations(0).X
                        Dim column = foundLocations(0).Y
                        For i = 1 To numLocations - 1
                            If foundLocations(i).X <> row Then
                                matchesRow = False
                            End If
                            If foundLocations(i).Y <> column Then
                                matchesColumn = False
                            End If
                        Next i

                        ' If they're all in the same row
                        If matchesRow Then
                            For j = 0 To state.GridSize - 1
                                If possibleNumbers(row)(j)(n) AndAlso j <> foundLocations(0).Y AndAlso j <>
                                    foundLocations(1).Y AndAlso (numLocations = 2 OrElse j <> foundLocations(2).Y) Then ' only works if BoxSize == 3
                                    possibleNumbers(row)(j)(n) = False
                                    numberOfChanges += 1
                                    If exitEarlyWhenSoleFound AndAlso possibleNumbers(row)(j).CountSet = 1 Then
                                        exitedEarly = True
                                        Return False
                                    End If
                                End If
                            Next j
                            ' If they're all in the same column
                        ElseIf matchesColumn Then
                            For j = 0 To state.GridSize - 1
                                If possibleNumbers(j)(column)(n) AndAlso j <> foundLocations(0).X AndAlso j <>
                                    foundLocations(1).X AndAlso (numLocations = 2 OrElse j <> foundLocations(2).X) Then ' only works if BoxSize == 3
                                    possibleNumbers(j)(column)(n) = False
                                    numberOfChanges += 1
                                    If exitEarlyWhenSoleFound AndAlso possibleNumbers(j)(column).CountSet = 1 Then
                                        exitedEarly = True
                                        Return False
                                    End If
                                End If
                            Next j
                        End If
                    End If
                Next n
            Next box

            Return numberOfChanges <> 0
        End Function
	End Class
End Namespace