//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: SolverResults.cs
//
//  Description: Represents the results from the Sudoku solver.
// 
//--------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Represents the results from attempting to solve a Sudoku puzzle.</summary>
	public sealed class SolverResults
	{
		/// <summary>The status of the result.</summary>
		private PuzzleStatus _status;
		/// <summary>The puzzle states returned from the solver, containing at least one valid solution if status is PuzzleStatus.Solved.</summary>
		private List<PuzzleState> _puzzles = new List<PuzzleState>();
		/// <summary>
		/// The number of decision points involved in finding the solution.  This is the number
		/// of times that the solver had to use brute-force methods to make progress.
		/// </summary>
		private int _numberOfDecisionPoints;
		/// <summary>The use of each elimination technique.</summary>
        private Dictionary<EliminationTechnique, int> _useOfTechniques;

		/// <summary>Initializes the SolveResults.</summary>
		/// <param name="status">The status of the result.</param>
		/// <param name="state">The puzzle state returned from the solver, a valid solution if status is PuzzleStatus.Solved.</param>
		/// <param name="numberOfDecisionPoints">
		/// The number of decision points involved in finding the solution.  This is the number
		/// of times that the solver had to use brute-force methods to make progress.
		/// </param>
		/// <param name="useOfTechniques">The use of each elimination technique.</param>
        public SolverResults(PuzzleStatus status, PuzzleState state, int numberOfDecisionPoints, Dictionary<EliminationTechnique, int> useOfTechniques)
		{
			_status = status;
			_puzzles.Add(state);
			_numberOfDecisionPoints = numberOfDecisionPoints;
			_useOfTechniques = useOfTechniques;
		}

		/// <summary>Gets the status of the result.</summary>
		public PuzzleStatus Status { get { return _status; } }

		/// <summary>Gets the first solution found by the solver.</summary>
		public PuzzleState Puzzle
		{
			get { return _puzzles.Count > 0 ? _puzzles[0] : null; }
		}

		/// <summary>Gets all of the solutions found by the solver.</summary>
		public List<PuzzleState> Puzzles { get { return _puzzles; } }

		/// <summary>
		/// Gets or sets the number of decision points involved in finding the solution.  This is the number
		/// of times that the solver had to use brute-force methods to make progress.
		/// </summary>
		public int NumberOfDecisionPoints
		{
			get { return _numberOfDecisionPoints; }
			set { _numberOfDecisionPoints = value; }
		}

		/// <summary>Gets the use of each elimination technique.</summary>
		internal Dictionary<EliminationTechnique,int> UseOfTechniques
		{
			get { return _useOfTechniques; }
		}
	}
}