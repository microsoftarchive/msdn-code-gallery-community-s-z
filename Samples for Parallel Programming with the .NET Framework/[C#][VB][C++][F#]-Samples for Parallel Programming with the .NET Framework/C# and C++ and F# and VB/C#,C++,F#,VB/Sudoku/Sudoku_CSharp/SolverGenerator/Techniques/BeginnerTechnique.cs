//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: BeginnerTechnique.cs
//
//  Description: Implements the Sudoku beginner technique.
// 
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the beginner elimination technique.</summary>
	[Serializable]
    public sealed class BeginnerTechnique : EliminationTechnique
	{
		/// <summary>Initialize the technique.</summary>
		public BeginnerTechnique(){}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 1; } }

        public override bool Equals(object obj)
        {
            return obj is BeginnerTechnique;
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

			int numLocations;
			Point [] locations = new Point[state.GridSize];

			for(int n=0; n<state.GridSize; n++)
			{
				// Find all occurrences of n.  If GridSize or more are found, no point in continuing
				// on.  Obviously if more than GridSize are found, there's a mistake somewhere on the
				// board (at least one), but that's not our problem.
				numLocations = 0;
				for(int row=0; row<state.GridSize && numLocations < state.GridSize; row++)
				{
					for(int column=0; column<state.GridSize && numLocations < state.GridSize; column++)
					{
						if (state[row,column].HasValue &&
							state[row,column].Value == n) locations[numLocations++] = new Point(row, column);
					}
				}
				if (numLocations >= state.GridSize) continue;

				// For each box
				for(int box=0; box<state.GridSize; box++)
				{
					bool done = false;

					// If any of the cells in the box is the number, bail
					int boxStartX = (box % state.BoxSize) * state.BoxSize;
					for (int x = boxStartX; x < boxStartX + state.BoxSize && !done; x++)
					{
						int boxStartY = (box / state.BoxSize) * state.BoxSize;
						for (int y = boxStartY; y < boxStartY + state.BoxSize && !done; y++)
						{
							Point cell = new Point(x,y);
							if ((state[cell].HasValue && state[cell].Value == n) ||
								(!state[cell].HasValue && possibleNumbers[x][y].CountSet == 1 && 
								possibleNumbers[x][y][n])) done = true;
						}
					}
					if (done) continue;

					// Look at each cell in the box
					Point targetCell = new Point(-1,-1);
					boxStartX = (box % state.BoxSize) * state.BoxSize;
					for (int x = boxStartX; x < boxStartX + state.BoxSize && !done; x++)
					{
						int boxStartY = (box / state.BoxSize) * state.BoxSize;
						for (int y = boxStartY; y < boxStartY + state.BoxSize && !done; y++)
						{
                            // See if there's only one cell in the box that can be
                            // this number.  If there is, it must be there.
							Point cell = new Point(x,y);
							if (!state[cell].HasValue && possibleNumbers[x][y][n])
							{
								bool invalid = false;
								for(int locNum=0; locNum<numLocations; locNum++)
								{
									if (locations[locNum].X == cell.X || locations[locNum].Y == cell.Y) 
									{ 
										invalid = true;
										break;
									}
								}
								if (!invalid)
								{
									if (targetCell == new Point(-1,-1)) targetCell = cell;
									else
									{
										targetCell = new Point(-1,-1);
										done = true;
									}
								}
							}
						}
					}

                    // If we found a cell we can fill in, modify the possible numbers list appropriately
					if (targetCell != new Point(-1,-1))
					{
						possibleNumbers[targetCell.X][targetCell.Y].SetAll(false);
						possibleNumbers[targetCell.X][targetCell.Y][n] = true;
						numberOfChanges++;
						if (exitEarlyWhenSoleFound)
						{
							exitedEarly = true;
							return false;
						}
					}
				}
			}

            // If numberOfChanges > 0, we made a change to possibleNumbers, but the state
            // itself wasn't affected.  Thus, running this again won't help.
			return false;
		}
	}
}