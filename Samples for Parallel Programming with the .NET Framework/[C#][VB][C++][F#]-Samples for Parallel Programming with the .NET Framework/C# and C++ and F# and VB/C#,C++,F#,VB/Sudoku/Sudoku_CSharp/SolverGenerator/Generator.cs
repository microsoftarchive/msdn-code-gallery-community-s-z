//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Generator.cs
//
//  Description: A Sudoku puzzle generator.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;
using System.Collections.Concurrent;
using System.Linq;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Generates Sudoku puzzles.</summary>
	public class Generator
	{
        /// <summary>Puzzles generated in the background in anticipation that a user will want another one.</summary>
        private ConcurrentDictionary<GeneratorOptions, Task<PuzzleState>> _speculativePuzzles =
            new ConcurrentDictionary<GeneratorOptions, Task<PuzzleState>>();

		/// <summary>Generates a random Sudoku puzzle.</summary>
		/// <returns>The generated puzzle.</returns>
        public PuzzleState Generate(GeneratorOptions options)
        {
            if (options == null) options = GeneratorOptions.Create(PuzzleDifficulty.Easy);
            if (options.NumberOfPuzzles < 1) throw new ArgumentOutOfRangeException("options");

            PuzzleState state = null;
            
            // See if any background puzzle generations have already begun or completed
            if (options.SpeculativeGeneration)
            {
                Task<PuzzleState> dequeuedPuzzle;
                if (_speculativePuzzles.TryRemove(options, out dequeuedPuzzle)) state = dequeuedPuzzle.Result;
            }

            // If we didn't get a state from a background generation, generate one now
            if (state == null) state = GenerateInternal(options);
            
            // And if the user wants, also kick off a background generation
            if (options.SpeculativeGeneration)
            {
                var newOptions = options.Clone();
                newOptions.ParallelGeneration = false;
                _speculativePuzzles.TryAdd(newOptions, Task.Factory.StartNew(() => GenerateInternal(options)));
            }

            // Return the generated puzzle
            return state;
        }

		/// <summary>Generates a random Sudoku puzzle.</summary>
		/// <returns>The generated puzzle.</returns>
		private static PuzzleState GenerateInternal(GeneratorOptions options)
		{
            // Generate the number of puzzles specified in the options and sort them by difficulty
            SolverResultsComparer comparer = new SolverResultsComparer(options.Techniques);
            if (options.ParallelGeneration)
            {
                return (Enumerable.Range(0, options.NumberOfPuzzles).AsParallel().
                        Select(i => GenerateOne(options)).
                        Aggregate((x, y) => comparer.Compare(x, y) > 0 ? x : y)).Puzzle;
            }
            else
            {
                return (Enumerable.Range(0, options.NumberOfPuzzles).
                        Select(i => GenerateOne(options)).
                        Aggregate((x, y) => comparer.Compare(x, y) > 0 ? x : y)).Puzzle;
            }
		}

		/// <summary>Used to compare the difficulty of two generated puzzles.</summary>
		private sealed class SolverResultsComparer : IComparer<SolverResults>
		{
			/// <summary>Techniques used to generate these puzzles.</summary>
			private List<EliminationTechnique> _techniques;

			/// <summary>Initializes the comparer.</summary>
			/// <param name="techniques">Techniques used to generate these puzzles.</param>
			public SolverResultsComparer(List<EliminationTechnique> techniques)
			{
				if (techniques == null) throw new ArgumentNullException("techniques");
				_techniques = techniques;
			}

			/// <summary>Compares two SolverResults.</summary>
			/// <param name="first">The first result.</param>
			/// <param name="second">The second result.</param>
			/// <returns>-1 if first is less than second, 0 if they're equal, and 1 if first is greater than greater.</returns>
			public int Compare(SolverResults first, SolverResults second)
			{
				if (first == second) return 0;
				else if (first == null) return 1;
				else if (second == null) return -1;
				else
				{
					// First compare by number of decision points
					int diff = first.NumberOfDecisionPoints - second.NumberOfDecisionPoints;
					if (diff != 0) return diff;

					// Then compare each by technique, starting with the most difficult.
                    for (int i = _techniques.Count - 1; i >= 0; --i)
                    {
                        int firstUse, secondUse;
                        bool gotFirst = first.UseOfTechniques.TryGetValue(_techniques[i], out firstUse);
                        bool gotSecond = second.UseOfTechniques.TryGetValue(_techniques[i], out secondUse);
                        if (gotFirst && gotSecond)
                        {
                            diff = firstUse - secondUse;
                            if (diff != 0) return diff;
                        }
                        else if (gotFirst) return 1;
                        else if (gotSecond) return -1;
                    }
				}
				// They're equal if they have the exact same number of decision points
				// and usage of each technique.
				return 0;
			}
		}

		/// <summary>Generates a random Sudoku puzzle.</summary>
		/// <returns>The generated results.</returns>
		private static SolverResults GenerateOne(GeneratorOptions options)
		{
			// Generate a full solution randomly, using the solver to solve a completely empty grid.
			// For this, we'll use the elimination techniques that yield fast solving.
            PuzzleState solvedState = new PuzzleState();
			SolverOptions solverOptions = new SolverOptions();
			solverOptions.MaximumSolutionsToFind = 1;
			solverOptions.EliminationTechniques = new List<EliminationTechnique>{new NakedSingleTechnique()};
			solverOptions.AllowBruteForce = true;
			SolverResults newSolution = Solver.Solve(solvedState, solverOptions);

			// Create options to use for removing filled cells from the complete solution.
			// MaximumSolutionsToFind is set to 2 so that we look for more than 1, but there's no
			// need in continuing once we know there's more than 1, so 2 is a find value to use.
			solverOptions.MaximumSolutionsToFind = 2;
			solverOptions.AllowBruteForce =
                !options.MaximumNumberOfDecisionPoints.HasValue || options.MaximumNumberOfDecisionPoints > 0;
			solverOptions.EliminationTechniques = solverOptions.AllowBruteForce ?
                new List<EliminationTechnique>{new NakedSingleTechnique()} : options.Techniques; // For perf: if brute force is allowed, techniques don't matter!

			// Now that we have a full solution, we want to randomly remove values from cells
			// until we get to a point where there is not a unique solution for the puzzle.  The
			// last puzzle state that did have a unique solution can then be used.
			PuzzleState newPuzzle = newSolution.Puzzle;

			// Get a random ordering of the cells in which to test their removal
			Point [] filledCells = GetRandomCellOrdering(newPuzzle);

			// Do we want to ensure symmetry?
            int filledCellCount = options.EnsureSymmetry && (filledCells.Length % 2 != 0) ? filledCells.Length - 1 : filledCells.Length;

			// If ensuring symmetry...
            if (options.EnsureSymmetry)
			{
				// Find the middle cell and put it at the end of the ordering
				for(int i=0; i<filledCells.Length-1; i++)
				{
					Point p = filledCells[i];
					if (p.X == newPuzzle.GridSize - p.X - 1 && 
						p.Y == newPuzzle.GridSize - p.Y - 1)
					{
						Point temp = filledCells[i];
						filledCells[i] = filledCells[filledCells.Length-1];
						filledCells[filledCells.Length-1] = temp;
					}
				}

				// Modify the random ordering so that paired symmetric cells are next to each other
				// i.e. filledCells[i] and filledCells[i+1] are symmetric pairs
				for(int i=0; i<filledCells.Length-1; i+=2)
				{
					Point p = filledCells[i];
					Point sp = new Point(newPuzzle.GridSize - p.X - 1, newPuzzle.GridSize - p.Y - 1);
					for(int j=i+1; j<filledCells.Length; j++)
					{
						if (filledCells[j].Equals(sp))
						{
							Point temp = filledCells[i+1];
							filledCells[i+1] = filledCells[j];
							filledCells[j] = temp;
							break;
						}
					}
				}

				// In the order of the array, try to remove each pair from the puzzle and see if it's
				// still solvable and in a valid way.  If it is, greedily leave those cells out of the puzzle.
				// Otherwise, skip them.
				byte [] oldValues = new byte[2];
				for(int filledCellNum=0;
                    filledCellNum < filledCellCount && newPuzzle.NumberOfFilledCells > options.MinimumFilledCells; 
					filledCellNum += 2)
				{
					// Store the old value so we can put it back if necessary,
					// then wipe it out of the cell
					oldValues[0] = newPuzzle[filledCells[filledCellNum]].Value;
					oldValues[1] = newPuzzle[filledCells[filledCellNum+1]].Value;
					newPuzzle[filledCells[filledCellNum]] = null;
					newPuzzle[filledCells[filledCellNum+1]] = null;

					// Check to see whether removing it left us in a good position (i.e. a
					// single-solution puzzle that doesn't violate any of the generation options)
					SolverResults newResults = Solver.Solve(newPuzzle, solverOptions);
                    if (!IsValidRemoval(newPuzzle, newResults, options))
					{
						newPuzzle[filledCells[filledCellNum]] = oldValues[0];
						newPuzzle[filledCells[filledCellNum+1]] = oldValues[1];
					}
				}

				// If there are an odd number of cells in the puzzle (which there will be
				// as everything we're doing is 9x9, 81 cells), try to remove the odd
				// cell that doesn't have a pairing.  This will be the middle cell.
				if (filledCells.Length % 2 != 0)
				{
					// Store the old value so we can put it back if necessary,
					// then wipe it out of the cell
					int filledCellNum = filledCells.Length-1;
					byte oldValue = newPuzzle[filledCells[filledCellNum]].Value;
					newPuzzle[filledCells[filledCellNum]] = null;

					// Check to see whether removing it left us in a good position (i.e. a
					// single-solution puzzle that doesn't violate any of the generation options)
					SolverResults newResults = Solver.Solve(newPuzzle, solverOptions);
					if (!IsValidRemoval(newPuzzle, newResults, options)) newPuzzle[filledCells[filledCellNum]] = oldValue;
				}
			}
				// otherwise, it's much easier.
			else
			{
				// Look at each cell in the random ordering.  Try to remove it.
				// If it works to remove it, do so greedily.  Otherwise, skip it.
				for(int filledCellNum=0;
                    filledCellNum < filledCellCount && newPuzzle.NumberOfFilledCells > options.MinimumFilledCells; 
					filledCellNum++)
				{
					// Store the old value so we can put it back if necessary,
					// then wipe it out of the cell
					byte oldValue = newPuzzle[filledCells[filledCellNum]].Value;
					newPuzzle[filledCells[filledCellNum]] = null;

					// Check to see whether removing it left us in a good position (i.e. a
					// single-solution puzzle that doesn't violate any of the generation options)
					SolverResults newResults = Solver.Solve(newPuzzle, solverOptions);
                    if (!IsValidRemoval(newPuzzle, newResults, options)) newPuzzle[filledCells[filledCellNum]] = oldValue;
				}
			}

			// Make sure to now use the techniques specified by the user to score this thing
            solverOptions.EliminationTechniques = options.Techniques;
			SolverResults finalResult = Solver.Solve(newPuzzle, solverOptions);

			// Return the best puzzle we could come up with
            newPuzzle.Difficulty = options.Difficulty;
			return new SolverResults(PuzzleStatus.Solved, newPuzzle, finalResult.NumberOfDecisionPoints, finalResult.UseOfTechniques);
		}

		/// <summary>Returns all cells in a collection in random order.</summary>
		/// <param name="state">The puzzle state.</param>
		/// <returns>The collection of cells.</returns>
		private static Point [] GetRandomCellOrdering(PuzzleState state)
		{
			// Create the collection
			Point [] points = new Point[state.GridSize*state.GridSize];

			// Find all cells
			int count=0;
			for (int i = 0; i < state.GridSize; i++)
			{
				for (int j = 0; j < state.GridSize; j++)
				{
					points[count++] = new Point(i,j);
				}
			}

			// Randomize their order
			for(int i=0; i<points.Length-1; i++)
			{
				int swapPos = RandomHelper.GetRandomNumber(i, points.Length-1);
				Point temp = points[swapPos];
				points[swapPos] = points[i];
				points[i] = temp;
			}

			// Return the randomized collection
			return points;
		}

		/// <summary>
		/// Based on the specified GeneratorOptions, determines whether the SolverResults
		/// created by solving a puzzle with a particular cell value removed represents a valid
		/// new state.
		/// </summary>
		/// <param name="state">The puzzle state being validated.</param>
		/// <param name="results">The SolverResults to be verified.</param>
		/// <returns>true if the removal that led to this call is valid; false, otherwise.</returns>
		private static bool IsValidRemoval(PuzzleState state, SolverResults results, GeneratorOptions options)
		{
			// Make sure we have a puzzle with one and only one solution
			if (results.Status != PuzzleStatus.Solved || results.Puzzles.Count != 1) return false;

			// Make sure we don't have too few cells
            if (state.NumberOfFilledCells < options.MinimumFilledCells) return false;

			// Now check to see if too many decision points were involved
            if (options.MaximumNumberOfDecisionPoints.HasValue &&
                results.NumberOfDecisionPoints > options.MaximumNumberOfDecisionPoints) return false;

			// Otherwise, it's a valid removal.
			return true;
		}
	}
}