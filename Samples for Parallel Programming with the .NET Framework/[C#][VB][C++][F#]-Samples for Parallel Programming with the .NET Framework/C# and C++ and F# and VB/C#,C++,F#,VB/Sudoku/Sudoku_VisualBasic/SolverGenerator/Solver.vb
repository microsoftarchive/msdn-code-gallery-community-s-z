'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Solver.vb
'
'  Description: Sudoku puzzle solver.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Analyzes and solves Sudoku puzzles.</summary>
	Public NotInheritable Class Solver
		''' <summary>Evaluates the difficulty level of a particular puzzle.</summary>
		''' <param name="state">The puzzle to evaluate.</param>
		''' <returns>The perceived difficulty level of the puzzle.</returns>
		Private Sub New()
		End Sub
		Public Shared Function EvaluateDifficulty(ByVal state As PuzzleState) As PuzzleDifficulty
			If state Is Nothing Then
				Throw New ArgumentNullException("state")
			End If

			Dim options As New SolverOptions()
            For Each diff In New PuzzleDifficulty() {PuzzleDifficulty.Easy, PuzzleDifficulty.Medium,
                                                     PuzzleDifficulty.Hard, PuzzleDifficulty.VeryHard}
                Dim go = GeneratorOptions.Create(diff)
                If state.NumberOfFilledCells < go.MinimumFilledCells Then
                    Continue For
                End If
                With options
                    .AllowBruteForce = Not go.MaximumNumberOfDecisionPoints.HasValue
                    .EliminationTechniques = go.Techniques
                    .MaximumSolutionsToFind = If(options.AllowBruteForce, 2UI, 1UI)
                End With

                Dim results = Solver.Solve(state, options)
                If results.Status = PuzzleStatus.Solved AndAlso results.Puzzles.Count = 1 Then
                    Return diff
                End If
            Next diff
			Return PuzzleDifficulty.Invalid
		End Function

		''' <summary>Attempts to solve a Sudoku puzzle.</summary>
		''' <param name="state">The state of the puzzle to be solved.</param>
		''' <param name="options">Options to use for solving.</param>
		''' <returns>The result of the solve attempt.</returns>
		''' <remarks>No changes are made to the parameter state.</remarks>
		Public Shared Function Solve(ByVal state As PuzzleState, ByVal options As SolverOptions) As SolverResults
			' Validate parameters
			If state Is Nothing Then
				Throw New ArgumentNullException("state")
			End If
			If options Is Nothing Then
				Throw New ArgumentNullException("options")
			End If
			options = options.Clone()

			If options.EliminationTechniques.Count = 0 Then
				options.EliminationTechniques.Add(New NakedSingleTechnique())
			End If

			' Turn off the raising of changed events while solving,
			' though it probably doesn't matter as the first thing
			' SolveInternal does is make a clone, and RaiseStateChangedEvent
			' is not cloned (on purpose).
            Dim raiseChangedEvent = state.RaiseStateChangedEvent
			state.RaiseStateChangedEvent = False

			' Attempt to solve the puzzle
            Dim results = SolveInternal(state, options)

			' Reset whether changed events should be raised
			state.RaiseStateChangedEvent = raiseChangedEvent

			' Return the solver results
			Return results
		End Function

		''' <summary>Attempts to solve a Sudoku puzzle.</summary>
		''' <param name="state">The state of the puzzle to be solved.</param>
		''' <param name="options">Options to use for solving.</param>
		''' <returns>The result of the solve attempt.</returns>
		''' <remarks>No changes are made to the parameter state.</remarks>
		Private Shared Function SolveInternal(ByVal state As PuzzleState, ByVal options As SolverOptions) As SolverResults
			' First, make a copy of the state and work on that copy.  That way, the original
			' instance passed to us by the client remains unmodified.
			state = state.Clone()

			' Fill cells using logic and analysis techniques until no more
			' can be filled.
			Dim totalUseOfTechniques = New Dictionary(Of EliminationTechnique, Integer)()
            Dim possibleNumbers()() = FillCellsWithSolePossibleNumber(state, options.EliminationTechniques, totalUseOfTechniques)

			' Analyze the current state of the board
			Select Case state.Status
					' If the puzzle is now solved, return it. If the puzzle is in an inconsistent state (such as 
					' two of the same number in the same row), return that as well as there's nothing more to be done.
				Case PuzzleStatus.Solved, PuzzleStatus.CannotBeSolved
					Return New SolverResults(state.Status, state, 0, totalUseOfTechniques)

					' If the puzzle is still in progress, it means no more cells
					' can be filled by elimination alone, so do a brute-force step.
					' BruteForceSolve recursively calls back to this method.
				Case Else
					If options.AllowBruteForce Then
                        Dim results = BruteForceSolve(state, options, possibleNumbers)
						If results.Status = PuzzleStatus.Solved Then
							AddTechniqueUsageTables(results.UseOfTechniques, totalUseOfTechniques)
						End If
						Return results
					Else
						Return New SolverResults(PuzzleStatus.CannotBeSolved, state, 0, Nothing)
					End If
			End Select
		End Function

		''' <summary>Uses brute-force search techniques to solve the puzzle.</summary>
		''' <param name="state">The state to be solved.</param>
		''' <param name="options">The options to use in solving.</param>
		''' <param name="possibleNumbers">The possible numbers off of which to base the search.</param>
		''' <returns>The result of the solve attempt.</returns>
		''' <remarks>Changes may be made to the parameter state.</remarks>
        Private Shared Function BruteForceSolve(ByVal state As PuzzleState, ByVal options As SolverOptions,
                ByVal possibleNumbers()() As FastBitArray) As SolverResults
            ' A standard brute-force search would take way, way, way too long to solve a Sudoku puzzle.
            ' Luckily, there are ways to significantly trim the search tree to a point where
            ' brute-force is not only possible, but also very fast.  The idea is that not every number
            ' can be put into every cell.  In fact, using elimination techniques, we can narrow down the list
            ' of numbers for each cell, such that only those need be are tried.  Moreover, every time a new number
            ' is entered into a cell, other cell's possible numbers decrease.  It's in our best interest
            ' to start the search with a cell that has the least possible number of options, thereby increasing
            ' our chances of "guessing" the right number sooner.  To this end, I find the cell in the grid
            ' that is empty and that has the least number of possible numbers that can go in it.  If there's more
            ' than one cell with the same number of possibilities, I choose randomly among them. This random
            ' choice allows the solver to be used for puzzle generation.
            Dim bestGuessCells As New List(Of Point)()
            Dim bestNumberOfPossibilities = state.GridSize + 1
            For i = 0 To state.GridSize - 1
                For j = 0 To state.GridSize - 1
                    Dim count = possibleNumbers(i)(j).CountSet
                    If Not state(i, j).HasValue Then
                        If count < bestNumberOfPossibilities Then
                            bestNumberOfPossibilities = count
                            bestGuessCells.Clear()
                            bestGuessCells.Add(New Point(i, j))
                        ElseIf count = bestNumberOfPossibilities Then
                            bestGuessCells.Add(New Point(i, j))
                        End If
                    End If
                Next j
            Next i

            ' If there are no cells available to fill, there's nothing we can do
            ' to make forward progress.  If there are cells available, which should
            ' always be the case when this method is called, go through each of the possible
            ' numbers in the cell and try to solve the puzzle with that number in it.
            Dim results As SolverResults = Nothing
            If bestGuessCells.Count > 0 Then
                ' Choose a random cell from amongst the possibilities found above
                Dim bestGuessCell = bestGuessCells(RandomHelper.GetRandomNumber(bestGuessCells.Count))

                ' Get the possible numbers for that cell.  For each possible number,
                ' fill that number into the cell and recursively call to Solve.
                Dim possibleNumbersForBestCell = possibleNumbers(bestGuessCell.X)(bestGuessCell.Y)
                For p = 0 To CType((possibleNumbersForBestCell.Length - 1), Byte)
                    If possibleNumbersForBestCell(p) Then

                        Dim newState = state
                        ' Fill in the cell and solve the puzzle
                        newState(bestGuessCell) = CType(p, Byte?)
                        Dim tempOptions = options.Clone()
                        If results IsNot Nothing Then
                            tempOptions.MaximumSolutionsToFind = CUInt(tempOptions.MaximumSolutionsToFind.Value - results.Puzzles.Count)
                        End If
                        Dim tempResults = SolveInternal(newState, tempOptions)

                        ' If it could be solved, update information about the solving process
                        ' and return the solution.  Only if the user wants to find multiple
                        ' solutions will the search continue.
                        If tempResults.Status = PuzzleStatus.Solved Then
                            If results IsNot Nothing AndAlso results.Puzzles.Count > 0 Then
                                results.Puzzles.AddRange(tempResults.Puzzles)
                            Else
                                results = tempResults
                                results.NumberOfDecisionPoints += 1
                            End If
                            If options.MaximumSolutionsToFind.HasValue AndAlso results.Puzzles.Count >= options.MaximumSolutionsToFind.Value Then
                                Return results
                            End If
                        End If

                        ' If we're not cloning, we need to cancel out the change
                        newState(bestGuessCell) = Nothing
                    End If
                Next p
            End If

            ' We'll get here if the requested number of solutions could not be found, or if no
            ' solutions at all could be found.  Either return a solution if we did get at least one,
            ' or return that none could be found.
            Return If(results IsNot Nothing, results, New SolverResults(PuzzleStatus.CannotBeSolved, state, 0, Nothing))
        End Function

        ''' <summary>Combines an incremental usage table into the total usage table.</summary>
        ''' <param name="totalTable">The total table.</param>
        ''' <param name="incrementalTable">The incremental table.</param>
        Private Shared Sub AddTechniqueUsageTables(ByVal totalTable As Dictionary(Of EliminationTechnique, Integer),
            ByVal incrementalTable As Dictionary(Of EliminationTechnique, Integer))
            If totalTable IsNot Nothing AndAlso incrementalTable IsNot Nothing Then
                For Each entry In incrementalTable
                    Dim totalValue As Integer
                    If totalTable.TryGetValue(entry.Key, totalValue) Then
                        totalTable(entry.Key) = entry.Value + totalValue
                    Else
                        totalTable(entry.Key) = entry.Value
                    End If
                Next entry
            End If
        End Sub

        ''' <summary>Attempts to fill one square in the Sudoku puzzle, based purely on logic and elimination techniques.</summary>
        ''' <param name="state">The state to be augmented.</param>
        ''' <param name="techniques">The techniques to use for number elimination.</param>
        ''' <param name="totalUseOfTechniques">The total usage of each technique.</param>
        ''' <returns>The current set of possible numbers for each cell.</returns>
        ''' <remarks>Changes may be made to the parameter state.</remarks>
        Private Shared Function FillCellsWithSolePossibleNumber(ByVal state As PuzzleState,
            ByVal techniques As List(Of EliminationTechnique), ByRef totalUseOfTechniques As Dictionary(Of EliminationTechnique, Integer)) As FastBitArray()()
            Dim possibleNumbers()() = PuzzleState.InstantiatePossibleNumbersArray(state)
            Dim moreToDo As Boolean
            Do
                moreToDo = False
                Dim gridSize = state.GridSize
                state.ComputePossibleNumbers(techniques, totalUseOfTechniques, False, False, possibleNumbers)

                For i = 0 To CType((gridSize - 1), Byte)
                    For j = 0 To CType((gridSize - 1), Byte)
                        If (Not state(i, j).HasValue) AndAlso possibleNumbers(i)(j).CountSet = 1 Then
                            For n = 0 To CType((gridSize - 1), Byte)
                                If possibleNumbers(i)(j)(n) Then
                                    state(i, j) = CType(n, Byte?)
                                    moreToDo = True
                                    Exit For
                                End If
                            Next n
                        End If
                    Next j
                Next i
            Loop While moreToDo
            Return possibleNumbers
        End Function
    End Class
End Namespace