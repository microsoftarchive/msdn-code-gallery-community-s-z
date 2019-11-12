'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: SolverResults.vb
'
'  Description: Represents the results from the Sudoku solver.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Represents the results from attempting to solve a Sudoku puzzle.</summary>
	Public NotInheritable Class SolverResults
		''' <summary>The status of the result.</summary>
		Private _status As PuzzleStatus
		''' <summary>The puzzle states returned from the solver, containing at least one valid solution if status is PuzzleStatus.Solved.</summary>
		Private _puzzles As New List(Of PuzzleState)()
		''' <summary>
		''' The number of decision points involved in finding the solution.  This is the number
		''' of times that the solver had to use brute-force methods to make progress.
		''' </summary>
		Private _numberOfDecisionPoints As Integer
		''' <summary>The use of each elimination technique.</summary>
		Private _useOfTechniques As Dictionary(Of EliminationTechnique, Integer)

		''' <summary>Initializes the SolveResults.</summary>
		''' <param name="status">The status of the result.</param>
		''' <param name="state">The puzzle state returned from the solver, a valid solution if status is PuzzleStatus.Solved.</param>
		''' <param name="numberOfDecisionPoints">
		''' The number of decision points involved in finding the solution.  This is the number
		''' of times that the solver had to use brute-force methods to make progress.
		''' </param>
		''' <param name="useOfTechniques">The use of each elimination technique.</param>
        Public Sub New(ByVal status As PuzzleStatus, ByVal state As PuzzleState, ByVal numberOfDecisionPoints As Integer,
                       ByVal useOfTechniques As Dictionary(Of EliminationTechnique, Integer))
            _status = status
            _puzzles.Add(state)
            _numberOfDecisionPoints = numberOfDecisionPoints
            _useOfTechniques = useOfTechniques
        End Sub

		''' <summary>Gets the status of the result.</summary>
		Public ReadOnly Property Status() As PuzzleStatus
			Get
				Return _status
			End Get
		End Property

		''' <summary>Gets the first solution found by the solver.</summary>
		Public ReadOnly Property Puzzle() As PuzzleState
			Get
				Return If(_puzzles.Count > 0, _puzzles(0), Nothing)
			End Get
		End Property

		''' <summary>Gets all of the solutions found by the solver.</summary>
		Public ReadOnly Property Puzzles() As List(Of PuzzleState)
			Get
				Return _puzzles
			End Get
		End Property

		''' <summary>
		''' Gets or sets the number of decision points involved in finding the solution.  This is the number
		''' of times that the solver had to use brute-force methods to make progress.
		''' </summary>
		Public Property NumberOfDecisionPoints() As Integer
			Get
				Return _numberOfDecisionPoints
			End Get
			Set(ByVal value As Integer)
				_numberOfDecisionPoints = value
			End Set
		End Property

		''' <summary>Gets the use of each elimination technique.</summary>
		Friend ReadOnly Property UseOfTechniques() As Dictionary(Of EliminationTechnique,Integer)
			Get
				Return _useOfTechniques
			End Get
		End Property
	End Class
End Namespace