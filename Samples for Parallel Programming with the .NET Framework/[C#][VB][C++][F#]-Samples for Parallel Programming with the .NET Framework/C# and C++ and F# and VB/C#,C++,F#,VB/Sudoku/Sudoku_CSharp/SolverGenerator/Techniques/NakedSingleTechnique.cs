//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: NakedSingleTechnique.cs
//
//  Description: Implements the Sudoku naked single technique.
// 
//--------------------------------------------------------------------------

using System;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the naked single elimination technique.</summary>
	[Serializable]
	public sealed class NakedSingleTechnique : EliminationTechnique
	{
		/// <summary>Initialize the technique.</summary>
		public NakedSingleTechnique(){}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 2; } }

        public override bool Equals(object obj)
        {
            return obj is NakedSingleTechnique;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

		/// <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		/// <param name="state">The puzzle state.</param>
		/// <param name="possibleNumbers">The previously computed possible numbers.</param>
		/// <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		/// <returns>Whether more changes may be possible based on changes made during this execution.</returns>
		internal override bool Execute(
			PuzzleState state, bool exitEarlyWhenSoleFound, 
			FastBitArray[][] possibleNumbers, out int numberOfChanges, out bool exitedEarly)
		{
			numberOfChanges = 0;
			exitedEarly = false;

			// Eliminate impossible numbers based on numbers already set in the grid
			for (int i = 0; i < state.GridSize; i++)
			{
				for (int j = 0; j < state.GridSize; j++)
				{
					// If this cell has a value, we use it to eliminate numbers in other cells
					if (state[i, j].HasValue)
					{
						byte valueToEliminate = state[i, j].Value;

						// eliminate numbers in same row
						for (int y = 0; y < state.GridSize; y++)
						{
							if (possibleNumbers[i][y][valueToEliminate])
							{
								numberOfChanges++;
								possibleNumbers[i][y][valueToEliminate] = false;
							}
						}

						// eliminate numbers in same column
						for (int x = 0; x < state.GridSize; x++)
						{
							if (possibleNumbers[x][j][valueToEliminate])
							{
								numberOfChanges++;
								possibleNumbers[x][j][valueToEliminate] = false;
							}
						}

						// eliminate numbers in same box
						int boxStartX = (i / state.BoxSize) * state.BoxSize;
						for (int x = boxStartX; x < boxStartX + state.BoxSize; x++)
						{
							int boxStartY = (j / state.BoxSize) * state.BoxSize;
							for (int y = boxStartY; y < boxStartY + state.BoxSize; y++)
							{
								if (possibleNumbers[x][y][valueToEliminate])
								{
									numberOfChanges++;
									possibleNumbers[x][y][valueToEliminate] = false;
								}
							}
						}
					}
				}
			}

			return false;
		}
	}
}