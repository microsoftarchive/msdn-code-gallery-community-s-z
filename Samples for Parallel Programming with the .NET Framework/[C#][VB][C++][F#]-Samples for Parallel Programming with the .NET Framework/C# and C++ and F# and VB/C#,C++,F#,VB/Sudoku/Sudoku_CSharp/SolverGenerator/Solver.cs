//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Solver.cs
//
//  Description: Sudoku puzzle solver.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Analyzes and solves Sudoku puzzles.</summary>
	public static class Solver
	{
		/// <summary>Evaluates the difficulty level of a particular puzzle.</summary>
		/// <param name="state">The puzzle to evaluate.</param>
		/// <returns>The perceived difficulty level of the puzzle.</returns>
		public static PuzzleDifficulty EvaluateDifficulty(PuzzleState state)
		{
			if (state == null) throw new ArgumentNullException("state");

			SolverOptions options = new SolverOptions();
			foreach(PuzzleDifficulty diff in new PuzzleDifficulty[]{PuzzleDifficulty.Easy, PuzzleDifficulty.Medium, PuzzleDifficulty.Hard, PuzzleDifficulty.VeryHard})
			{
				GeneratorOptions go = GeneratorOptions.Create(diff);
				if (state.NumberOfFilledCells < go.MinimumFilledCells) continue;

				options.AllowBruteForce = !go.MaximumNumberOfDecisionPoints.HasValue;
				options.EliminationTechniques = go.Techniques;
				options.MaximumSolutionsToFind = options.AllowBruteForce ? 2u : 1u;
				SolverResults results = Solver.Solve(state, options);
				if (results.Status == PuzzleStatus.Solved &&
					results.Puzzles.Count == 1) return diff;
			}
			return PuzzleDifficulty.Invalid;
		}

		/// <summary>Attempts to solve a Sudoku puzzle.</summary>
		/// <param name="state">The state of the puzzle to be solved.</param>
		/// <param name="options">Options to use for solving.</param>
		/// <returns>The result of the solve attempt.</returns>
		/// <remarks>No changes are made to the parameter state.</remarks>
		public static SolverResults Solve(PuzzleState state, SolverOptions options)
		{
			// Validate parameters
			if (state == null) throw new ArgumentNullException("state");
			if (options == null) throw new ArgumentNullException("options");
            options = options.Clone();

			if (options.EliminationTechniques.Count == 0) options.EliminationTechniques.Add(new NakedSingleTechnique());

			// Turn off the raising of changed events while solving,
			// though it probably doesn't matter as the first thing
			// SolveInternal does is make a clone, and RaiseStateChangedEvent
			// is not cloned (on purpose).
			bool raiseChangedEvent = state.RaiseStateChangedEvent;
			state.RaiseStateChangedEvent = false;
			
			// Attempt to solve the puzzle
			SolverResults results = SolveInternal(state, options);
			
			// Reset whether changed events should be raised
			state.RaiseStateChangedEvent = raiseChangedEvent;

			// Return the solver results
			return results;
		}

		/// <summary>Attempts to solve a Sudoku puzzle.</summary>
		/// <param name="state">The state of the puzzle to be solved.</param>
		/// <param name="options">Options to use for solving.</param>
		/// <returns>The result of the solve attempt.</returns>
		/// <remarks>No changes are made to the parameter state.</remarks>
		private static SolverResults SolveInternal(PuzzleState state, SolverOptions options)
		{
			// First, make a copy of the state and work on that copy.  That way, the original
			// instance passed to us by the client remains unmodified.
			state = state.Clone();

			// Fill cells using logic and analysis techniques until no more
			// can be filled.
			var totalUseOfTechniques = new Dictionary<EliminationTechnique, int>();
			FastBitArray [][] possibleNumbers = FillCellsWithSolePossibleNumber(state, options.EliminationTechniques, ref totalUseOfTechniques);

			// Analyze the current state of the board
			switch (state.Status)
			{
					// If the puzzle is now solved, return it. If the puzzle is in an inconsistent state (such as 
					// two of the same number in the same row), return that as well as there's nothing more to be done.
				case PuzzleStatus.Solved:
				case PuzzleStatus.CannotBeSolved:
					return new SolverResults(state.Status, state, 0, totalUseOfTechniques);

					// If the puzzle is still in progress, it means no more cells
					// can be filled by elimination alone, so do a brute-force step.
					// BruteForceSolve recursively calls back to this method.
				default:
					if (options.AllowBruteForce)
					{
						SolverResults results = BruteForceSolve(state, options, possibleNumbers);
						if (results.Status == PuzzleStatus.Solved)
						{
							AddTechniqueUsageTables(results.UseOfTechniques, totalUseOfTechniques);
						}
						return results;
					} 
					else return new SolverResults(PuzzleStatus.CannotBeSolved, state, 0, null);
			}
		}

		/// <summary>Uses brute-force search techniques to solve the puzzle.</summary>
		/// <param name="state">The state to be solved.</param>
		/// <param name="options">The options to use in solving.</param>
		/// <param name="possibleNumbers">The possible numbers off of which to base the search.</param>
		/// <returns>The result of the solve attempt.</returns>
		/// <remarks>Changes may be made to the parameter state.</remarks>
		private static SolverResults BruteForceSolve(PuzzleState state, SolverOptions options, FastBitArray [][] possibleNumbers)
		{
			// A standard brute-force search would take way, way, way too long to solve a Sudoku puzzle.
			// Luckily, there are ways to significantly trim the search tree to a point where
			// brute-force is not only possible, but also very fast.  The idea is that not every number
			// can be put into every cell.  In fact, using elimination techniques, we can narrow down the list
			// of numbers for each cell, such that only those need be are tried.  Moreover, every time a new number
			// is entered into a cell, other cell's possible numbers decrease.  It's in our best interest
			// to start the search with a cell that has the least possible number of options, thereby increasing
			// our chances of "guessing" the right number sooner.  To this end, I find the cell in the grid
			// that is empty and that has the least number of possible numbers that can go in it.  If there's more
			// than one cell with the same number of possibilities, I choose randomly among them. This random
			// choice allows the solver to be used for puzzle generation.
            List<Point> bestGuessCells = new List<Point>();
			int bestNumberOfPossibilities = state.GridSize + 1;
			for (int i = 0; i < state.GridSize; i++)
			{
				for (int j = 0; j < state.GridSize; j++)
				{
					int count = possibleNumbers[i][j].CountSet;
					if (!state[i, j].HasValue)
					{
						if (count < bestNumberOfPossibilities)
						{
							bestNumberOfPossibilities = count;
							bestGuessCells.Clear();
							bestGuessCells.Add(new Point(i, j));
						}
						else if (count == bestNumberOfPossibilities)
						{
							bestGuessCells.Add(new Point(i, j));
						}
					}
				}
			}

			// If there are no cells available to fill, there's nothing we can do
			// to make forward progress.  If there are cells available, which should
			// always be the case when this method is called, go through each of the possible
			// numbers in the cell and try to solve the puzzle with that number in it.
			SolverResults results = null;
			if (bestGuessCells.Count > 0)
			{
				// Choose a random cell from amongst the possibilities found above
				Point bestGuessCell = bestGuessCells[RandomHelper.GetRandomNumber(bestGuessCells.Count)];

				// Get the possible numbers for that cell.  For each possible number,
				// fill that number into the cell and recursively call to Solve.
				FastBitArray possibleNumbersForBestCell = possibleNumbers[bestGuessCell.X][bestGuessCell.Y];
				for(byte p=0; p<possibleNumbersForBestCell.Length; p++)
				{
					if (possibleNumbersForBestCell[p])
					{
						PuzzleState newState = state;

						// Fill in the cell and solve the puzzle
						newState[bestGuessCell] = p;
						SolverOptions tempOptions = options.Clone();
						if (results != null) 
						{
							tempOptions.MaximumSolutionsToFind = 
								(uint)(tempOptions.MaximumSolutionsToFind.Value - results.Puzzles.Count);
						}
						SolverResults tempResults = SolveInternal(newState, tempOptions);

						// If it could be solved, update information about the solving process
						// and return the solution.  Only if the user wants to find multiple
						// solutions will the search continue.
						if (tempResults.Status == PuzzleStatus.Solved)
						{
							if (results != null && results.Puzzles.Count > 0)
							{
								results.Puzzles.AddRange(tempResults.Puzzles);
							}
							else
							{
								results = tempResults;
								results.NumberOfDecisionPoints++;
							}
							if (options.MaximumSolutionsToFind.HasValue &&
								results.Puzzles.Count >= options.MaximumSolutionsToFind.Value) return results;
						}

						// If we're not cloning, we need to cancel out the change
						newState[bestGuessCell] = null;
					}
				}
			}

			// We'll get here if the requested number of solutions could not be found, or if no
			// solutions at all could be found.  Either return a solution if we did get at least one,
			// or return that none could be found.
			return results != null ? results : new SolverResults(PuzzleStatus.CannotBeSolved, state, 0, null);
		}

		/// <summary>Combines an incremental usage table into the total usage table.</summary>
		/// <param name="totalTable">The total table.</param>
		/// <param name="incrementalTable">The incremental table.</param>
		private static void AddTechniqueUsageTables(
            Dictionary<EliminationTechnique, int> totalTable, Dictionary<EliminationTechnique, int> incrementalTable)
		{
			if (totalTable != null && incrementalTable != null)
			{
				foreach(var entry in incrementalTable)
				{
                    int totalValue;
                    if (totalTable.TryGetValue(entry.Key, out totalValue))
                    {
                        totalTable[entry.Key] = entry.Value + totalValue;
                    }
                    else totalTable[entry.Key] = entry.Value;
				}
			}
		}

		/// <summary>Attempts to fill one square in the Sudoku puzzle, based purely on logic and elimination techniques.</summary>
		/// <param name="state">The state to be augmented.</param>
		/// <param name="techniques">The techniques to use for number elimination.</param>
		/// <param name="totalUseOfTechniques">The total usage of each technique.</param>
		/// <returns>The current set of possible numbers for each cell.</returns>
		/// <remarks>Changes may be made to the parameter state.</remarks>
		private static FastBitArray [][] FillCellsWithSolePossibleNumber(
            PuzzleState state, List<EliminationTechnique> techniques, ref Dictionary<EliminationTechnique, int> totalUseOfTechniques)
		{
			FastBitArray [][] possibleNumbers = PuzzleState.InstantiatePossibleNumbersArray(state);
			bool moreToDo;
			do
			{
				moreToDo = false;
				byte gridSize = state.GridSize;
				state.ComputePossibleNumbers(techniques, ref totalUseOfTechniques, false, false, possibleNumbers);

				for(byte i=0; i<gridSize; i++)
				{
					for(byte j=0; j<gridSize; j++)
					{
						if (!state[i,j].HasValue && possibleNumbers[i][j].CountSet == 1)
						{
							for(byte n=0; n<gridSize; n++)
							{
								if (possibleNumbers[i][j][n])
								{
									state[i,j] = n;
									moreToDo = true;
									break;
								}
							}
						}
					}
				}
			} 
			while(moreToDo);
			return possibleNumbers;
		}
	}
}