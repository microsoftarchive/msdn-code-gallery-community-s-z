//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ConfigurationOptions.cs
//
//  Description: User options for game play
// 
//--------------------------------------------------------------------------

using System;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Used for saving and restoring configuration options.</summary>
	[Serializable]
	internal class ConfigurationOptions
	{
		/// <summary>Whether easy cells will be suggested to the user.</summary>
		public bool SuggestEasyCells;
		/// <summary>Whether incorrect values in cells will be pointed out to the user.</summary>
		public bool ShowIncorrectCells = true;
		/// <summary>Whether new puzzles should be created with guaranteed symmetry.</summary>
		public bool CreatePuzzlesWithSymmetry = true;
		/// <summary>Whether users want to be given the option to save their puzzles when they're being overriden.</summary>
		public bool PromptOnPuzzleDelete = true;
        /// <summary>Whether to generate puzzles using parallelism.</summary>
        public bool ParallelPuzzleGeneration = false;
        /// <summary>Whether to generate puzzles using parallelism.</summary>
        public bool SpeculativePuzzleGeneration = false;
	}
}