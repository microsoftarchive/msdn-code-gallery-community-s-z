//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: GeneratorOptions.cs
//
//  Description: Configuration options for the puzzle generator.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Options used for generating puzzles.</summary>
	public sealed class GeneratorOptions : ICloneable
	{
		/// <summary>Perceived difficulty of the puzzle.</summary>
		private PuzzleDifficulty _difficulty;
		/// <summary>The minimum number of filled cells in the generated puzzle.</summary>
		private int _minimumFilledCells;
		/// <summary>The maximum number of times brute-force techniques can be used in solving the puzzle.</summary>
		private int? _maximumNumberOfDecisionPoints;
		/// <summary>The number of puzzles to generate in order to pick the best of the lot.</summary>
		private int _numberOfPuzzles;
		/// <summary>Techniques allowed to be used in the generation of puzzles.</summary>
		private List<EliminationTechnique> _eliminationTechniques;
		/// <summary>Whether only symmetrical puzzles should be generated.</summary>
		private bool _ensureSymmetry;

		/// <summary>Creates generator options that will create a puzzle of the specified difficulty level.</summary>
		/// <param name="difficultyLevel">The difficulty level.</param>
		/// <returns>Generator options appropriate for this level.</returns>
		public static GeneratorOptions Create(PuzzleDifficulty difficultyLevel)
		{
			switch(difficultyLevel)
			{
				case PuzzleDifficulty.Easy:
					return new GeneratorOptions(PuzzleDifficulty.Easy, 32, 0, 2, 
						new EliminationTechnique[]{
													  new BeginnerTechnique()
												  }, true);

				case PuzzleDifficulty.Medium:
					return new GeneratorOptions(PuzzleDifficulty.Medium, 0, 0, 15,
						new EliminationTechnique[]{
													  new BeginnerTechnique(),
													  new NakedSingleTechnique(), 
													  new HiddenSingleTechnique(), 
													  new BlockAndColumnRowInteractionTechnique(),
                                                      new NakedPairTechnique(),
													  new HiddenPairTechnique(),
												  }, true);

				case PuzzleDifficulty.Hard:
					return new GeneratorOptions(PuzzleDifficulty.Hard, 0, 0, 30, 
						new EliminationTechnique[]{
													  new BeginnerTechnique(),
													  new NakedSingleTechnique(), 
													  new HiddenSingleTechnique(), 
													  new BlockAndColumnRowInteractionTechnique(),
													  new NakedPairTechnique(),
													  new HiddenPairTechnique(),
													  new NakedTripletTechnique(), 
													  new HiddenTripletTechnique(),
													  new NakedQuadTechnique(), 
													  new HiddenQuadTechnique(), 
													  new XwingTechnique()
												  }, true);

                case PuzzleDifficulty.VeryHard: // may require "guessing" technique
                    return new GeneratorOptions(PuzzleDifficulty.VeryHard, 0, null, 45,
                        new EliminationTechnique[]{
													  new BeginnerTechnique(),
													  new NakedSingleTechnique(), 
													  new HiddenSingleTechnique(), 
													  new BlockAndColumnRowInteractionTechnique(),
													  new NakedPairTechnique(),
													  new HiddenPairTechnique(),
													  new NakedTripletTechnique(), 
													  new HiddenTripletTechnique(),
													  new NakedQuadTechnique(), 
													  new HiddenQuadTechnique(), 
													  new XwingTechnique()
												  }, true);

				default:
					throw new ArgumentOutOfRangeException("difficultyLevel");
			}
		}

		/// <summary>Initialize the GeneratorOptions</summary>
		/// <param name="size">The size of the puzzle to be generated.</param>
		/// <param name="difficulty">The difficulty of the puzzle to generate.</param>
		/// <param name="minimumFilledCells">The minimum number of filled cells in the generated puzzle.</param>
		/// <param name="maximumNumberOfDecisionPoints">The maximum number of times brute-force techniques can be used in solving the puzzle.</param>
		/// <param name="numberOfPuzzles">The number of puzzles to generate in order to pick the best of the lot.</param>
		/// <param name="techniques">The techniques to use while generating the puzzle.</param>
		/// <param name="ensureSymmetry">Whether all puzzles generated should be symmetrical.</param>
		private GeneratorOptions(
			PuzzleDifficulty difficulty, int minimumFilledCells, int? maximumNumberOfDecisionPoints, int numberOfPuzzles,
			EliminationTechnique [] techniques, bool ensureSymmetry)
		{
			if (difficulty != PuzzleDifficulty.Easy &&
				difficulty != PuzzleDifficulty.Medium &&
				difficulty != PuzzleDifficulty.Hard &&
                difficulty != PuzzleDifficulty.VeryHard) throw new ArgumentOutOfRangeException("difficulty");
			if (minimumFilledCells < 0) throw new ArgumentOutOfRangeException("minimumFilledCells");
			if (numberOfPuzzles < 1) throw new ArgumentOutOfRangeException("numberOfPuzzles");
			if (techniques == null) throw new ArgumentNullException("techniques");

			_difficulty = difficulty;
			_minimumFilledCells = minimumFilledCells;
			_maximumNumberOfDecisionPoints = maximumNumberOfDecisionPoints;
			_numberOfPuzzles = numberOfPuzzles;
			_ensureSymmetry = ensureSymmetry;
			_eliminationTechniques = new List<EliminationTechnique>(techniques);
		}

        /// <summary>Constructor used only for cloning.</summary>
        private GeneratorOptions()
        {
            _eliminationTechniques = new List<EliminationTechnique>();
        }

		/// <summary>Gets the minimum number of filled cells in the generated puzzle.</summary>
		public int MinimumFilledCells { get { return _minimumFilledCells; } }

		/// <summary>Gets the maximum number of times brute-force techniques can be used in solving the puzzle.</summary>
		public int? MaximumNumberOfDecisionPoints { get { return _maximumNumberOfDecisionPoints; } }

		/// <summary>Gets the number of puzzles to generate in order to pick the best of the lot.</summary>
		public int NumberOfPuzzles { get { return _numberOfPuzzles; } }

		/// <summary>Gets the elimination techniques to be used.</summary>
		public List<EliminationTechnique> Techniques { get { return _eliminationTechniques; } }

		/// <summary>Gets whether all puzzles generated should be symmetrical.</summary>
		public bool EnsureSymmetry { get { return _ensureSymmetry; } set { _ensureSymmetry = value; } }

		/// <summary>Gets the perceived difficulty of the puzzle to create.</summary>
		public PuzzleDifficulty Difficulty { get { return _difficulty; } }

        public  bool ParallelGeneration { get; set; }

        public  bool SpeculativeGeneration { get; set; }

        public override bool Equals(object obj)
        {
            GeneratorOptions other = obj as GeneratorOptions;
            if (!(other is GeneratorOptions)) return false;

            if (MinimumFilledCells == other.MinimumFilledCells &&
                MaximumNumberOfDecisionPoints == other.MaximumNumberOfDecisionPoints &&
                NumberOfPuzzles == other.NumberOfPuzzles &&
                EnsureSymmetry == other.EnsureSymmetry &&
                Difficulty == other.Difficulty)
            {
                foreach (var technique in Techniques)
                {
                    if (!other.Techniques.Contains(technique)) return false;
                }
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Difficulty.GetHashCode();
        }

        /// <summary>Clones the solver options.</summary>
        /// <returns>A clone of the options.</returns>
        public GeneratorOptions Clone()
        {
            GeneratorOptions options = new GeneratorOptions();
            options._difficulty = _difficulty;
            options._ensureSymmetry = _ensureSymmetry;
            options._maximumNumberOfDecisionPoints = _maximumNumberOfDecisionPoints;
            options._minimumFilledCells = _minimumFilledCells;
            options._numberOfPuzzles = _numberOfPuzzles;
            options.ParallelGeneration = ParallelGeneration;
            options.SpeculativeGeneration = SpeculativeGeneration;
            foreach (EliminationTechnique technique in _eliminationTechniques)
            {
                options._eliminationTechniques.Add(technique.Clone());
            }
            return options;
        }

        /// <summary>Clones the solver options.</summary>
        /// <returns>A clone of the options.</returns>
        object ICloneable.Clone() { return Clone(); }
	}
}