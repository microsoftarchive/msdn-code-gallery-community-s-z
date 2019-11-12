//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: XwingTechnique.cs
//
//  Description: Implements the Sudoku x-wing technique.
// 
//--------------------------------------------------------------------------

using System;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the X-Wing elimination technique.</summary>
	[Serializable]
    public sealed class XwingTechnique : EliminationTechnique
	{
		/// <summary>Initialize the technique.</summary>
		public XwingTechnique(){}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 11; } }

        public override bool Equals(object obj)
        {
            return obj is XwingTechnique;
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
			
			// Check each row to see if it contains the start of an xwing
			for(int row=0; row<state.GridSize; row++)
			{
				int count = 0; // used to find the two first-row members of the x-wing
				int [] foundColumns = new int[2]; // used to store the two first-row members of the x-wing

				// We'll be checking all numbers to see whether they're in an x-wing
				for(int n=0; n<state.GridSize; n++)
				{
					// Now look at every column in the row, and find the occurrences of the number.
					// For it to be a valid x-wing, it must have two and only two of the given number as a possibility.
					for(int column=0; column<state.GridSize; column++)
					{
						if (possibleNumbers[row][column][n] || (state[row,column].HasValue && state[row,column].Value == n))
						{
							count++;
							if (count <= foundColumns.Length) foundColumns[count-1] = column;
							else break;
						}
					}

					// Assuming we found a row that has two and only two cells with the number as a possibility
					if (count == 2)
					{
						// Look for another row that has the same property
						for(int subRow=row+1; subRow<state.GridSize; subRow++)
						{
							bool validXwingFound = true;
							for(int subColumn=0; subColumn<state.GridSize && validXwingFound; subColumn++)
							{
								bool isMatchingColumn = (subColumn == foundColumns[0] || subColumn == foundColumns[1]);
								bool hasPossibleNumber = possibleNumbers[subRow][subColumn][n] || (state[subRow,subColumn].HasValue && state[subRow,subColumn].Value == n);
								if ((hasPossibleNumber && !isMatchingColumn) ||
									(!hasPossibleNumber && isMatchingColumn)) validXwingFound = false;
							}

							// If another row is found that has two and only two cells with the number
							// as a possibility, and if those two cells are in the same two columns
							// as the original row, woo hoo, we've got an x-wing, and we can eliminate
							// that number from every other cell in the columns containing the numbers.
							if (validXwingFound)
							{
								for(int elimRow=0; elimRow<state.GridSize; elimRow++)
								{
									if (elimRow != row && elimRow != subRow)
									{
										for(int locationNum=0; locationNum<2; locationNum++)
										{
											if (possibleNumbers[elimRow][foundColumns[locationNum]][n])
											{
												possibleNumbers[elimRow][foundColumns[locationNum]][n] = false;
												numberOfChanges++;
												if (exitEarlyWhenSoleFound && 
													possibleNumbers[elimRow][foundColumns[locationNum]].CountSet == 1)
												{
													exitedEarly = true;
													return false;
												}
											}
										}
									}
								}
								break;
							}
						}
					}
				}
			}

			return numberOfChanges != 0;
		}
	}
}