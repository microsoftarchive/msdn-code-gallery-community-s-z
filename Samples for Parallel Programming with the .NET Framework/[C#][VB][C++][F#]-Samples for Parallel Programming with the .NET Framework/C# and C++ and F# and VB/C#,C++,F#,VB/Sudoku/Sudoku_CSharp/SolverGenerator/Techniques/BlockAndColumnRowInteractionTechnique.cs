//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: BlockAndColumnRowInteractionTechnique.cs
//
//  Description: Implements the Sudoku block and column/row interaction technique.
// 
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the coloring elimination technique.</summary>
	[Serializable]
    public sealed class BlockAndColumnRowInteractionTechnique : EliminationTechnique
	{
		/// <summary>Initialize the technique.</summary>
		public BlockAndColumnRowInteractionTechnique(){}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 4; } }

        public override bool Equals(object obj)
        {
            return obj is BlockAndColumnRowInteractionTechnique;
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

			// Find the open cells in this block
			int numLocations;
			Point [] foundLocations = new Point[state.GridSize];

			// Analyze each box
			for(int box=0; box<state.GridSize; box++)
			{
				for(int n=0; n<state.GridSize; n++)
				{
					numLocations = 0;

					// Find all locations that n is possible within the box
					int boxStartX = (box / state.BoxSize) * state.BoxSize;
					for (int x = boxStartX; x < boxStartX + state.BoxSize && numLocations <= state.BoxSize; x++)
					{
						int boxStartY = (box % state.BoxSize) * state.BoxSize;
						for (int y = boxStartY; y < boxStartY + state.BoxSize && numLocations <= state.BoxSize; y++)
						{
							if (possibleNumbers[x][y][n])
							{
								foundLocations[numLocations++] = new Point(x,y);
							}
						}
					}

					// We only care if two or three are open in the grid and if they're
					// in the same row or column
					if (numLocations > 1 && numLocations <= state.BoxSize)
					{
						bool matchesRow = true, matchesColumn = true;
						int row = foundLocations[0].X;
						int column = foundLocations[0].Y;
						for(int i=1; i<numLocations; i++)
						{
							if (foundLocations[i].X != row) matchesRow = false;
							if (foundLocations[i].Y != column) matchesColumn = false;
						}

						// If they're all in the same row
						if (matchesRow)
						{
							for(int j=0; j<state.GridSize; j++)
							{
								if (possibleNumbers[row][j][n] && 
									j != foundLocations[0].Y && 
									j != foundLocations[1].Y && 
									(numLocations == 2 || j != foundLocations[2].Y)) // only works if BoxSize == 3
								{
									possibleNumbers[row][j][n] = false;
									numberOfChanges++;
									if (exitEarlyWhenSoleFound &&
										possibleNumbers[row][j].CountSet == 1)
									{
										exitedEarly = true;
										return false;
									}
								}
							}
						}
							// If they're all in the same column
						else if (matchesColumn)
						{
							for(int j=0; j<state.GridSize; j++)
							{
								if (possibleNumbers[j][column][n] &&
									j != foundLocations[0].X && 
									j != foundLocations[1].X && 
									(numLocations == 2 || j != foundLocations[2].X)) // only works if BoxSize == 3
								{
									possibleNumbers[j][column][n] = false;
									numberOfChanges++;
									if (exitEarlyWhenSoleFound &&
										possibleNumbers[j][column].CountSet == 1)
									{
										exitedEarly = true;
										return false;
									}
								}
							}
						}
					}
				}
			}

			return numberOfChanges != 0;
		}
	}
}