//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: NakedSubsetTecnnique.cs
//
//  Description: Implements the Sudoku naked subset technique.
// 
//--------------------------------------------------------------------------

using System;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Implements the naked pair elimination technique.</summary>
	[Serializable]
    public sealed class NakedPairTechnique : NakedSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public NakedPairTechnique() : base(2) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 5; } }
	}

	/// <summary>Implements the naked triplet elimination technique.</summary>
	[Serializable]
    public sealed class NakedTripletTechnique : NakedSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public NakedTripletTechnique() : base(3) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 7; } }
	}

	/// <summary>Implements the naked quad elimination technique.</summary>
	[Serializable]
    public sealed class NakedQuadTechnique : NakedSubsetTechnique
	{
		/// <summary>Initializes the technique.</summary>
		public NakedQuadTechnique() : base(4) {}

		/// <summary>Gets the difficulty level of this technique.</summary>
		internal override uint DifficultyLevel { get { return 9; } }
	}

	/// <summary>Implements the naked subset elimination technique.</summary>
	[Serializable]
    public abstract class NakedSubsetTechnique : EliminationTechnique
	{
		/// <summary>The size of the subset to evaluate.</summary>
		private int _subsetSize;
		private int [] _foundLocations;

		/// <summary>Initialize the technique.</summary>
		/// <param name="subsetSize">The size of the subset to evaluate.</param>
		protected NakedSubsetTechnique(int subsetSize)
		{
			if (subsetSize < 2) throw new ArgumentOutOfRangeException("subsetSize");
			_subsetSize = subsetSize;
			_foundLocations = new int[_subsetSize]; // optimization, rather than doing it in each call to EliminateNakedSubsets
		}

        public override bool Equals(object obj)
        {
            NakedSubsetTechnique nst = obj as NakedSubsetTechnique;
            if (nst == null) return false;
            return _subsetSize == nst._subsetSize;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public override EliminationTechnique Clone()
        {
            NakedSubsetTechnique nst = (NakedSubsetTechnique)base.Clone();
            nst._foundLocations = new int[_subsetSize];
            return nst;
        }

		/// <summary>Performs naked subset elimination on one dimension of possible numbers.</summary>
		/// <param name="possibleNumbers">The row/column/box to analyze.</param>
		/// <returns>The number of changes that were made to the possible numbers.</returns>
		private int EliminateNakedSubsets(FastBitArray [] possibleNumbers,
			bool exitEarlyWhenSoleFound, out bool exitedEarly)
		{
			int changesMade = 0;
			exitedEarly = false;
			int [] foundLocations = _foundLocations; // optimization, rather than allocating each time

			for(int i=0; i<possibleNumbers.Length; i++)
			{
				if (possibleNumbers[i].CountSet == _subsetSize)
				{
					foundLocations[0] = i;
					int [] toMatchValues = possibleNumbers[i].GetSetBits();
					int matchesFound = 0;
					for(int j=i+1; j<possibleNumbers.Length; j++)
					{
						if (possibleNumbers[j].CountSet == _subsetSize)
						{
							bool foundMatch = CompareValues(toMatchValues, possibleNumbers[j].GetSetBits());
							if (foundMatch)
							{
								foundLocations[++matchesFound] = j;
								if (matchesFound == _subsetSize-1)
								{
									for(int k=0; k<possibleNumbers.Length; k++)
									{
										if (Array.BinarySearch(foundLocations, k) < 0)
										{
											foreach(int eliminatedPossible in toMatchValues)
											{
												if (possibleNumbers[k][eliminatedPossible])
												{
													changesMade++;
													possibleNumbers[k][eliminatedPossible] = false;
												}
											}
											if (exitEarlyWhenSoleFound &&
												possibleNumbers[k].CountSet == 1)
											{
												exitedEarly = true;
												return changesMade;
											}
										}
									}
									break;
								}
							}
						}
					}
				}
			}

			return changesMade;
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
			FastBitArray [] arrays = new FastBitArray[state.GridSize];

			for(int i=0; i<state.GridSize; i++)
			{
				GetRowPossibleNumbers(possibleNumbers, i, arrays);
				numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;

				GetColumnPossibleNumbers(possibleNumbers, i, arrays);
				numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;

				GetBoxPossibleNumbers(state, possibleNumbers, i, arrays);
				numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, out exitedEarly);
				if (exitedEarly) return false;
			}

			return numberOfChanges != 0;
		}
	}
}