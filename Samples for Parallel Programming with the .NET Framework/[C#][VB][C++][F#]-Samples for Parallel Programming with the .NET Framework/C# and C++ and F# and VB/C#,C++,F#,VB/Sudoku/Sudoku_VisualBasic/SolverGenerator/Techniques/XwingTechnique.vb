'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: XwingTechnique.vb
'
'  Description: Implements the Sudoku x-wing technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the X-Wing elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class XwingTechnique
		Inherits EliminationTechnique
		''' <summary>Initialize the technique.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 11
			End Get
		End Property

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
			Return TypeOf obj Is XwingTechnique
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

            ' Check each row to see if it contains the start of an xwing
            For row = 0 To state.GridSize - 1
                Dim count = 0 ' used to find the two first-row members of the x-wing
                Dim foundColumns(1) As Integer ' used to store the two first-row members of the x-wing

                ' We'll be checking all numbers to see whether they're in an x-wing
                For n = 0 To state.GridSize - 1
                    ' Now look at every column in the row, and find the occurrences of the number.
                    ' For it to be a valid x-wing, it must have two and only two of the given number as a possibility.
                    For column = 0 To state.GridSize - 1
                        If possibleNumbers(row)(column)(n) OrElse (state(row, column).HasValue AndAlso state(row, column).Value = n) Then
                            count += 1
                            If count <= foundColumns.Length Then
                                foundColumns(count - 1) = column
                            Else
                                Exit For
                            End If
                        End If
                    Next column

                    ' Assuming we found a row that has two and only two cells with the number as a possibility
                    If count = 2 Then
                        ' Look for another row that has the same property
                        For subRow = row + 1 To state.GridSize - 1
                            Dim validXwingFound = True
                            Dim subColumn = 0
                            Do While subColumn < state.GridSize AndAlso validXwingFound
                                Dim isMatchingColumn = (subColumn = foundColumns(0) OrElse subColumn = foundColumns(1))
                                Dim hasPossibleNumber = possibleNumbers(subRow)(subColumn)(n) OrElse (state(subRow, subColumn).HasValue AndAlso state(subRow, subColumn).Value = n)
                                If (hasPossibleNumber AndAlso (Not isMatchingColumn)) OrElse ((Not hasPossibleNumber) AndAlso isMatchingColumn) Then
                                    validXwingFound = False
                                End If
                                subColumn += 1
                            Loop

                            ' If another row is found that has two and only two cells with the number
                            ' as a possibility, and if those two cells are in the same two columns
                            ' as the original row, woo hoo, we've got an x-wing, and we can eliminate
                            ' that number from every other cell in the columns containing the numbers.
                            If validXwingFound Then
                                For elimRow = 0 To state.GridSize - 1
                                    If elimRow <> row AndAlso elimRow <> subRow Then
                                        For locationNum = 0 To 1
                                            If possibleNumbers(elimRow)(foundColumns(locationNum))(n) Then
                                                possibleNumbers(elimRow)(foundColumns(locationNum))(n) = False
                                                numberOfChanges += 1
                                                If exitEarlyWhenSoleFound AndAlso possibleNumbers(elimRow)(foundColumns(locationNum)).CountSet = 1 Then
                                                    exitedEarly = True
                                                    Return False
                                                End If
                                            End If
                                        Next locationNum
                                    End If
                                Next elimRow
                                Exit For
                            End If
                        Next subRow
                    End If
                Next n
            Next row

            Return numberOfChanges <> 0
        End Function
    End Class
End Namespace