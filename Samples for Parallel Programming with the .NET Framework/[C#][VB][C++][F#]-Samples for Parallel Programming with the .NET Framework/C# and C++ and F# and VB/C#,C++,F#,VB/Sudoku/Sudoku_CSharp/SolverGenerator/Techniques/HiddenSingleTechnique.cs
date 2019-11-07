//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: HiddenSingleTechnique.cs
//
//  Description: Implements the Sudoku hidden single technique.
// 
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the hidden single elimination technique.</summary>
	[Serializable]
    public sealed class HiddenSingleTechnique : EliminationTechnique
	{
		/// <summary>Initialize the technique.</summary>
		public HiddenSingleTechnique(){}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 3; } }

        public override bool Equals(object obj)
        {
            return obj is HiddenSingleTechnique;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

		/// <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		/// <param name="state">The puzzle state.</param>
		/// <param name="exitEarlyWhenSoleFound">Whether the method can exit early when a cell with only one possible number is found.</param>
		/// <param name="possibleNumbers">The previously computed possible numbers.</param>
		/// <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		/// <param name="exitedEarly">Whether the method exited early due to a cell with only one value being found.</param>
		/// <returns>Whether more changes may be possible based on changes made during this execution.</returns>
		internal override bool Execute(
			PuzzleState state, bool exitEarlyWhenSoleFound, 
			FastBitArray[][] possibleNumbers, out int numberOfChanges, out bool exitedEarly)
		{
			numberOfChanges = 0;
			exitedEarly = false;
			byte gridSize = state.GridSize;
			byte boxSize = state.BoxSize;
			
			// For each number that can exist in the puzzle (0-8, etc.)
			for (byte n = 0; n < gridSize; n++)
			{
				// For each row, if number only exists as a possibility in one cell, set it.
				for (byte x = 0; x < gridSize; x++)
				{
					int? seenIndex = null;
					for (byte y = 0; y < gridSize; y++)
					{
						if (possibleNumbers[x][y][n])
						{
							// If this is the first time we're seeing the number, remember
							// where we're seeing it
							if (!seenIndex.HasValue) seenIndex = y;
								// We've seen this number before, so move on
							else
							{
								seenIndex = null;
								break;
							}
						}
					}
					if (seenIndex.HasValue && possibleNumbers[x][seenIndex.Value].CountSet > 1)
					{
						possibleNumbers[x][seenIndex.Value].SetAll(false);
						possibleNumbers[x][seenIndex.Value][n] = true;
						numberOfChanges++;
						if (exitEarlyWhenSoleFound)
						{
							exitedEarly = true;
							return false;
						}
					}
				}
			
				// For each column, if number only exists as a possibility in one cell, set it.
				// Same basic logic as above.
				for (byte y = 0; y < gridSize; y++)
				{
					int? seenIndex = null;
					for (byte x = 0; x < gridSize; x++)
					{
						if (possibleNumbers[x][y][n])
						{
							if (!seenIndex.HasValue) seenIndex = x;
							else
							{
								seenIndex = null;
								break;
							}
						}
					}
					if (seenIndex.HasValue && possibleNumbers[seenIndex.Value][y].CountSet > 1)
					{
						possibleNumbers[seenIndex.Value][y].SetAll(false);
						possibleNumbers[seenIndex.Value][y][n] = true;
						numberOfChanges++;
						if (exitEarlyWhenSoleFound)
						{
							exitedEarly = true;
							return false;
						}
					}
				}
			
				// For each grid, if number only exists as a possibility in one cell, set it.
				// Same basic logic as above.
				for (byte gridNum = 0; gridNum < gridSize; gridNum++)
				{
					byte gridX = (byte)(gridNum % boxSize);
					byte gridY = (byte)(gridNum / boxSize);
			
					byte startX = (byte)(gridX * boxSize);
					byte startY = (byte)(gridY * boxSize);
			
					bool canEliminate = true;
					Point? seenIndex = null;
					for (byte x = startX; x < startX + boxSize && canEliminate; x++)
					{
						for (byte y = startY; y < startY + boxSize; y++)
						{
							if (possibleNumbers[x][y][n])
							{
								if (!seenIndex.HasValue) seenIndex = new Point(x, y);
								else
								{
									canEliminate = false;
									seenIndex = null;
									break;
								}
							}
						}
					}
			
					if (seenIndex.HasValue && canEliminate && 
						possibleNumbers[seenIndex.Value.X][seenIndex.Value.Y].CountSet > 1)
					{
						possibleNumbers[seenIndex.Value.X][seenIndex.Value.Y].SetAll(false);
						possibleNumbers[seenIndex.Value.X][seenIndex.Value.Y][n] = true;
						numberOfChanges++;
						if (exitEarlyWhenSoleFound)
						{
							exitedEarly = true;
							return false;
						}
					}
				}
			}

			return numberOfChanges != 0;
		}
	}
}