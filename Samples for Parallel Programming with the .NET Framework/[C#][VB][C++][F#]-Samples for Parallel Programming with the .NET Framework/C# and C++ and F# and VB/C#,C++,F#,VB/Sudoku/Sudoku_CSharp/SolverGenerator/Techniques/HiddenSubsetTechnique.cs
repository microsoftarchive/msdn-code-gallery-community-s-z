//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: HiddenSubsetTechnique.cs
//
//  Description: Implements the Sudoku hidden subset technique.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the hidden pair elimination technique.</summary>
	[Serializable]
    public sealed class HiddenPairTechnique : HiddenSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public HiddenPairTechnique() : base(2) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 6; } }
	}

	/// <summary>Implements the hidden triplet elimination technique.</summary>
	[Serializable]
    public sealed class HiddenTripletTechnique : HiddenSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public HiddenTripletTechnique() : base(3) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 8; } }
	}

	/// <summary>Implements the hidden quad elimination technique.</summary>
	[Serializable]
    public sealed class HiddenQuadTechnique : HiddenSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public HiddenQuadTechnique() : base(4) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 10; } }
	}

	/// <summary>Implements the hidden subset elimination technique.</summary>
	[Serializable]
    public abstract class HiddenSubsetTechnique : EliminationTechnique
	{
		/// <summary>The size of the subset to evaluate.</summary>
		private int _subsetSize;
		private int [] _foundLocations;

		/// <summary>Initialize the technique.</summary>
		/// <param name="subsetSize">The size of the subset to evaluate.</param>
		protected HiddenSubsetTechnique(int subsetSize)
		{
			if (subsetSize < 2) throw new ArgumentOutOfRangeException("subsetSize");
			_subsetSize = subsetSize;
			_foundLocations = new int[_subsetSize]; // optimization, rather than allocating on each call
		}

        public override bool Equals(object obj)
        {
            HiddenSubsetTechnique hst = obj as HiddenSubsetTechnique;
            if (hst == null) return false;
            return _subsetSize == hst._subsetSize;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public override EliminationTechnique Clone()
        {
            HiddenSubsetTechnique hst = (HiddenSubsetTechnique)base.Clone();
            hst._foundLocations = new int[_subsetSize];
            return hst;
        }

		/// <summary>Performs hidden subset elimination on one dimension of possible numbers.</summary>
		/// <param name="possibleNumbers">The row/column/box to analyze.</param>
		/// <returns>The number of changes that were made to the possible numbers.</returns>
		private int EliminateHiddenSubsets(FastBitArray [] possibleNumbers,
			bool exitEarlyWhenSoleFound, out bool exitedEarly)
		{
			int changesMade = 0;
			exitedEarly = false;
			int numLocations;
			int [] foundLocations = _foundLocations; // optimization, rather than allocating on each call

			// We'll look starting with each cell in the row/column/box
			for(int i=0; i<possibleNumbers.Length; i++)
			{
				// Only look at the cell if it has at least subsetSize values set,
				// otherwise it can't be part of a hidden subset
				int numPossible = possibleNumbers[i].CountSet;
				if (numPossible >= _subsetSize)
				{
					// For each combination
					foreach(int [] combination in CreateCombinations(_subsetSize, possibleNumbers[i].GetSetBits()))
					{
						// Find other cells that contain that same combination,
						// but only up to the subset size
						numLocations = 0;
						foundLocations[numLocations++] = i;
						for(int j=i+1; j<possibleNumbers.Length && numLocations < foundLocations.Length; j++)
						{
							if (AllAreSet(combination, possibleNumbers[j]))
							{
								foundLocations[numLocations++] = j;
							}
						}

						if (numLocations == foundLocations.Length)
						{
							bool isValidHidden = true;

							// Make sure that none of the numbers appear in any other cell
							for(int j=0; j<possibleNumbers.Length && isValidHidden; j++)
							{
								bool isFoundLocation = Array.BinarySearch(foundLocations, j) >= 0;
								if (!isFoundLocation && AnyAreSet(combination, possibleNumbers[j]))
								{
									isValidHidden = false;
									break;
								}
							}

							// If this is a valid hidden subset, eliminate all other numbers
							// from each cell in the subset
							if (isValidHidden)
							{
								foreach(int foundLoc in foundLocations)
								{
									FastBitArray possibleNumbersForLoc = possibleNumbers[foundLoc];
									foreach(int n in possibleNumbersForLoc.GetSetBits())
									{
										if (Array.BinarySearch(combination, n) < 0)
										{
											possibleNumbersForLoc[n] = false;
											changesMade++;
										}
									}
									if (exitEarlyWhenSoleFound &&
										possibleNumbersForLoc.CountSet == 1)
									{
										exitedEarly = true;
										return changesMade;
									}
								}
								break;
							}
						}
					}
				}
			}

			return changesMade;
		}

        /// <summary>Allows for iteration through all combinations from an array.</summary>
        /// <param name="size">The size of the subset.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>An enumerable for all the combinations.</returns>
        public static IEnumerable<int[]> CreateCombinations(int size, int[] numbers)
        {
            int[] indices = new int[size];
            int[] result = new int[size];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
                result[i] = numbers[i];
            }
            yield return result;

            while (true)
            {
                if (indices[0] >= numbers.Length - size) yield break;

                // Find the next position to be incremented
                int pos;
                for (pos = indices.Length - 1;
                    pos > 0 && indices[pos] == numbers.Length - size + pos;
                    pos--) ;

                // Increment it
                indices[pos]++;

                // Increment everything else
                for (int j = pos; j < size - 1; j++) indices[j + 1] = indices[j] + 1;

                // Create the result
                for (int i = 0; i < indices.Length; i++) result[i] = numbers[indices[i]];
                yield return result;
            }
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
			FastBitArray [] arrays = new FastBitArray[state.GridSize];

			for(int i=0; i<state.GridSize; i++)
			{
				GetRowPossibleNumbers(possibleNumbers, i, arrays);
				numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;

				GetColumnPossibleNumbers(possibleNumbers, i, arrays);
				numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;

				GetBoxPossibleNumbers(state, possibleNumbers, i, arrays);
				numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;
			}

			return numberOfChanges != 0;
		}
	}
}