//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PuzzleDifficulty.cs
//
//  Description: Puzzle difficulty enumeration.
// 
//--------------------------------------------------------------------------

using System;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>The level of difficulty for a puzzle.</summary>
	[Serializable]
	public enum PuzzleDifficulty
	{
		/// <summary>An easy puzzle.</summary>
		Easy,
		/// <summary>A medium puzzle.</summary>
		Medium,
		/// <summary>A hard puzzle.</summary>
		Hard,
        /// <summary>A very puzzle.</summary>
        VeryHard,
		/// <summary>An unsolvable puzzle, either because it has multiple solutions or no solutions.</summary>
		Invalid
	}
}