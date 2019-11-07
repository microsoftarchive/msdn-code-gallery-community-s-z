'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Generator.vb
'
'  Description: A Sudoku puzzle generator.
' 
'--------------------------------------------------------------------------

Imports System.Collections
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities
Imports System.Collections.Concurrent

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Generates Sudoku puzzles.</summary>
	Public Class Generator
		''' <summary>Puzzles generated in the background in anticipation that a user will want another one.</summary>
		Private _speculativePuzzles As New ConcurrentDictionary(Of GeneratorOptions, Task(Of PuzzleState))()

		''' <summary>Generates a random Sudoku puzzle.</summary>
		''' <returns>The generated puzzle.</returns>
		Public Function Generate(ByVal options As GeneratorOptions) As PuzzleState
			If options Is Nothing Then
				options = GeneratorOptions.Create(PuzzleDifficulty.Easy)
			End If
			If options.NumberOfPuzzles < 1 Then
				Throw New ArgumentOutOfRangeException("options")
			End If

            Dim state = Nothing

			' See if any background puzzle generations have already begun or completed
			If options.SpeculativeGeneration Then
                Dim dequeuedPuzzle As Task(Of PuzzleState) = Nothing

                If _speculativePuzzles.TryRemove(options, dequeuedPuzzle) Then
                    state = dequeuedPuzzle.Result
                End If
			End If

			' If we didn't get a state from a background generation, generate one now
			If state Is Nothing Then
				state = GenerateInternal(options)
			End If

			' And if the user wants, also kick off a background generation
			If options.SpeculativeGeneration Then
				Dim newOptions = options.Clone()
				newOptions.ParallelGeneration = False
                _speculativePuzzles.TryAdd(newOptions, Task.Factory.StartNew(Function() GenerateInternal(options)))
			End If

			' Return the generated puzzle
            Return CType(state, PuzzleState)
		End Function

		''' <summary>Generates a random Sudoku puzzle.</summary>
		''' <returns>The generated puzzle.</returns>
		Private Shared Function GenerateInternal(ByVal options As GeneratorOptions) As PuzzleState
			' Generate the number of puzzles specified in the options and sort them by difficulty
			Dim comparer As New SolverResultsComparer(options.Techniques)
			If options.ParallelGeneration Then
                Return (Enumerable.Range(0, options.NumberOfPuzzles).AsParallel().
                        Select(Function(i) GenerateOne(options)).
                        Aggregate(Function(x, y) If(comparer.Compare(x, y) > 0, x, y))).Puzzle
			Else
                Return (Enumerable.Range(0, options.NumberOfPuzzles).
                        Select(Function(i) GenerateOne(options)).
                        Aggregate(Function(x, y) If(comparer.Compare(x, y) > 0, x, y))).Puzzle
			End If
		End Function

		''' <summary>Used to compare the difficulty of two generated puzzles.</summary>
		Private NotInheritable Class SolverResultsComparer
			Implements IComparer(Of SolverResults)
			''' <summary>Techniques used to generate these puzzles.</summary>
			Private _techniques As List(Of EliminationTechnique)

			''' <summary>Initializes the comparer.</summary>
			''' <param name="techniques">Techniques used to generate these puzzles.</param>
			Public Sub New(ByVal techniques As List(Of EliminationTechnique))
				If techniques Is Nothing Then
					Throw New ArgumentNullException("techniques")
				End If
				_techniques = techniques
			End Sub

			''' <summary>Compares two SolverResults.</summary>
			''' <param name="first">The first result.</param>
			''' <param name="second">The second result.</param>
			''' <returns>-1 if first is less than second, 0 if they're equal, and 1 if first is greater than greater.</returns>
			Public Function Compare(ByVal first As SolverResults, ByVal second As SolverResults) As Integer Implements IComparer(Of SolverResults).Compare
				If first Is second Then
					Return 0
				ElseIf first Is Nothing Then
					Return 1
				ElseIf second Is Nothing Then
					Return -1
				Else
					' First compare by number of decision points
                    Dim diff = first.NumberOfDecisionPoints - second.NumberOfDecisionPoints
					If diff <> 0 Then
						Return diff
					End If

					' Then compare each by technique, starting with the most difficult.
                    For i = _techniques.Count - 1 To 0 Step -1
                        Dim firstUse, secondUse As Integer
                        Dim gotFirst = first.UseOfTechniques.TryGetValue(_techniques(i), firstUse)
                        Dim gotSecond = second.UseOfTechniques.TryGetValue(_techniques(i), secondUse)
                        If gotFirst AndAlso gotSecond Then
                            diff = firstUse - secondUse
                            If diff <> 0 Then
                                Return diff
                            End If
                        ElseIf gotFirst Then
                            Return 1
                        ElseIf gotSecond Then
                            Return -1
                        End If
                    Next i
				End If
				' They're equal if they have the exact same number of decision points
				' and usage of each technique.
				Return 0
			End Function
		End Class

		''' <summary>Generates a random Sudoku puzzle.</summary>
		''' <returns>The generated results.</returns>
		Private Shared Function GenerateOne(ByVal options As GeneratorOptions) As SolverResults
			' Generate a full solution randomly, using the solver to solve a completely empty grid.
			' For this, we'll use the elimination techniques that yield fast solving.
			Dim solvedState As New PuzzleState()
            Dim solverOptions As New SolverOptions()
            With solverOptions
                .MaximumSolutionsToFind = 1
                .EliminationTechniques = New List(Of EliminationTechnique) From {New NakedSingleTechnique()}
                .AllowBruteForce = True
            End With
            Dim newSolution = Solver.Solve(solvedState, solverOptions)

            ' Create options to use for removing filled cells from the complete solution.
            ' MaximumSolutionsToFind is set to 2 so that we look for more than 1, but there's no
            ' need in continuing once we know there's more than 1, so 2 is a find value to use.
            With solverOptions
                .MaximumSolutionsToFind = 2
                .AllowBruteForce = CBool((Not options.MaximumNumberOfDecisionPoints.HasValue) OrElse options.MaximumNumberOfDecisionPoints > 0)
                .EliminationTechniques = If(solverOptions.AllowBruteForce,
                New List(Of EliminationTechnique) From {New NakedSingleTechnique()}, options.Techniques) ' For perf: if brute force is allowed, techniques don't matter!
            End With
            ' Now that we have a full solution, we want to randomly remove values from cells
            ' until we get to a point where there is not a unique solution for the puzzle.  The
            ' last puzzle state that did have a unique solution can then be used.
            Dim newPuzzle = newSolution.Puzzle

            ' Get a random ordering of the cells in which to test their removal
            Dim filledCells() = GetRandomCellOrdering(newPuzzle)

            ' Do we want to ensure symmetry?
            Dim filledCellCount = If(options.EnsureSymmetry AndAlso (filledCells.Length Mod 2 <> 0), filledCells.Length - 1, filledCells.Length)

            ' If ensuring symmetry...
            If options.EnsureSymmetry Then
                ' Find the middle cell and put it at the end of the ordering
                For i = 0 To filledCells.Length - 2
                    Dim p = filledCells(i)
                    If p.X = newPuzzle.GridSize - p.X - 1 AndAlso p.Y = newPuzzle.GridSize - p.Y - 1 Then
                        Dim temp = filledCells(i)
                        filledCells(i) = filledCells(filledCells.Length - 1)
                        filledCells(filledCells.Length - 1) = temp
                    End If
                Next i

                ' Modify the random ordering so that paired symmetric cells are next to each other
                ' i.e. filledCells[i] and filledCells[i+1] are symmetric pairs
                For i = 0 To filledCells.Length - 2 Step 2
                    Dim p = filledCells(i)
                    Dim sp As New Point(newPuzzle.GridSize - p.X - 1, newPuzzle.GridSize - p.Y - 1)
                    For j = i + 1 To filledCells.Length - 1
                        If filledCells(j).Equals(sp) Then
                            Dim temp = filledCells(i + 1)
                            filledCells(i + 1) = filledCells(j)
                            filledCells(j) = temp
                            Exit For
                        End If
                    Next j
                Next i

                ' In the order of the array, try to remove each pair from the puzzle and see if it's
                ' still solvable and in a valid way.  If it is, greedily leave those cells out of the puzzle.
                ' Otherwise, skip them.
                Dim oldValues(1) As Byte
                Dim filledCellNum = 0
                Do While filledCellNum < filledCellCount AndAlso newPuzzle.NumberOfFilledCells > options.MinimumFilledCells
                    ' Store the old value so we can put it back if necessary,
                    ' then wipe it out of the cell
                    oldValues(0) = newPuzzle(filledCells(filledCellNum)).Value
                    oldValues(1) = newPuzzle(filledCells(filledCellNum + 1)).Value
                    newPuzzle(filledCells(filledCellNum)) = Nothing
                    newPuzzle(filledCells(filledCellNum + 1)) = Nothing

                    ' Check to see whether removing it left us in a good position (i.e. a
                    ' single-solution puzzle that doesn't violate any of the generation options)
                    Dim newResults = Solver.Solve(newPuzzle, solverOptions)
                    If Not IsValidRemoval(newPuzzle, newResults, options) Then
                        newPuzzle(filledCells(filledCellNum)) = oldValues(0)
                        newPuzzle(filledCells(filledCellNum + 1)) = oldValues(1)
                    End If
                    filledCellNum += 2
                Loop

                ' If there are an odd number of cells in the puzzle (which there will be
                ' as everything we're doing is 9x9, 81 cells), try to remove the odd
                ' cell that doesn't have a pairing.  This will be the middle cell.
                If filledCells.Length Mod 2 <> 0 Then
                    ' Store the old value so we can put it back if necessary,
                    ' then wipe it out of the cell
                    Dim filledCellNumNew = filledCells.Length - 1
                    Dim oldValue = newPuzzle(filledCells(filledCellNumNew)).Value
                    newPuzzle(filledCells(filledCellNumNew)) = Nothing

                    ' Check to see whether removing it left us in a good position (i.e. a
                    ' single-solution puzzle that doesn't violate any of the generation options)
                    Dim newResults = Solver.Solve(newPuzzle, solverOptions)
                    If Not IsValidRemoval(newPuzzle, newResults, options) Then
                        newPuzzle(filledCells(filledCellNumNew)) = oldValue
                    End If
                End If
                ' otherwise, it's much easier.
            Else
                ' Look at each cell in the random ordering.  Try to remove it.
                ' If it works to remove it, do so greedily.  Otherwise, skip it.
                Dim filledCellNum = 0
                Do While filledCellNum < filledCellCount AndAlso newPuzzle.NumberOfFilledCells > options.MinimumFilledCells
                    ' Store the old value so we can put it back if necessary,
                    ' then wipe it out of the cell
                    Dim oldValue = newPuzzle(filledCells(filledCellNum)).Value
                    newPuzzle(filledCells(filledCellNum)) = Nothing

                    ' Check to see whether removing it left us in a good position (i.e. a
                    ' single-solution puzzle that doesn't violate any of the generation options)
                    Dim newResults = Solver.Solve(newPuzzle, solverOptions)
                    If Not IsValidRemoval(newPuzzle, newResults, options) Then
                        newPuzzle(filledCells(filledCellNum)) = oldValue
                    End If
                    filledCellNum += 1
                Loop
            End If

            ' Make sure to now use the techniques specified by the user to score this thing
            solverOptions.EliminationTechniques = options.Techniques
            Dim finalResult = Solver.Solve(newPuzzle, solverOptions)

            ' Return the best puzzle we could come up with
            newPuzzle.Difficulty = options.Difficulty
            Return New SolverResults(PuzzleStatus.Solved, newPuzzle, finalResult.NumberOfDecisionPoints, finalResult.UseOfTechniques)
        End Function

		''' <summary>Returns all cells in a collection in random order.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <returns>The collection of cells.</returns>
		Private Shared Function GetRandomCellOrdering(ByVal state As PuzzleState) As Point()
			' Create the collection
			Dim points(state.GridSize*state.GridSize - 1) As Point

			' Find all cells
            Dim count = 0
            For i = 0 To state.GridSize - 1
                For j = 0 To state.GridSize - 1
                    points(count) = New Point(i, j)
                    count += 1
                Next j
            Next i

			' Randomize their order
            For i = 0 To points.Length - 2
                Dim swapPos = RandomHelper.GetRandomNumber(i, points.Length - 1)
                Dim temp = points(swapPos)
                points(swapPos) = points(i)
                points(i) = temp
            Next i

			' Return the randomized collection
			Return points
		End Function

		''' <summary>
		''' Based on the specified GeneratorOptions, determines whether the SolverResults
		''' created by solving a puzzle with a particular cell value removed represents a valid
		''' new state.
		''' </summary>
		''' <param name="state">The puzzle state being validated.</param>
		''' <param name="results">The SolverResults to be verified.</param>
		''' <returns>true if the removal that led to this call is valid; false, otherwise.</returns>
		Private Shared Function IsValidRemoval(ByVal state As PuzzleState, ByVal results As SolverResults, ByVal options As GeneratorOptions) As Boolean
			' Make sure we have a puzzle with one and only one solution
			If results.Status <> PuzzleStatus.Solved OrElse results.Puzzles.Count <> 1 Then
                Return False
			End If

			' Make sure we don't have too few cells
			If state.NumberOfFilledCells < options.MinimumFilledCells Then
				Return False
			End If

			' Now check to see if too many decision points were involved
			If options.MaximumNumberOfDecisionPoints.HasValue AndAlso results.NumberOfDecisionPoints > options.MaximumNumberOfDecisionPoints Then
				Return False
			End If

			' Otherwise, it's a valid removal.
			Return True
		End Function
	End Class
End Namespace