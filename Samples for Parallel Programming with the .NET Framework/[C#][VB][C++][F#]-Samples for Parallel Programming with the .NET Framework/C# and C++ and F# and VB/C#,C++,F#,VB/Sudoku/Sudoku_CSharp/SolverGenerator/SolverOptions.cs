//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: SolverOptions.cs
//
//  Description: Options for the Sudoku solver.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Options for configuring how the solver does its processing.</summary>
	public sealed class SolverOptions : ICloneable
	{
		/// <summary>The maximum number of solutions the solver should find.</summary>
		private uint? _maximumSolutionsToFind = 1;

		/// <summary>Whether to allow brute-force techniques in the solver.</summary>
		private bool _allowBruteForce = true;

		/// <summary>The techniques to use while solving.</summary>
		private List<EliminationTechnique> _techniques;

		/// <summary>Initializes the SolverOptions.</summary>
		public SolverOptions() {}

		/// <summary>Gets or sets the maximum number of solutions the solver should find.</summary>
		public uint? MaximumSolutionsToFind
		{
			get { return _maximumSolutionsToFind; }
			set 
			{
				if (value <= 0u) throw new ArgumentOutOfRangeException("value");
				_maximumSolutionsToFind = value; 
			}
		}

		/// <summary>Gets or sets the techniques used for solving.</summary>
		public List<EliminationTechnique> EliminationTechniques 
		{ 
			get 
			{
				if (_techniques == null) _techniques = new List<EliminationTechnique>();
				return _techniques; 
			} 
			set { _techniques = value; }
		}

		/// <summary>Gets or sets whether to allow brute-force techniques in the solver.</summary>
		public bool AllowBruteForce { get { return _allowBruteForce; } set { _allowBruteForce = value; } }

		/// <summary>Clones the solver options.</summary>
		/// <returns>A clone of the options.</returns>
		public SolverOptions Clone()
		{
            SolverOptions options = new SolverOptions();
            options.AllowBruteForce = AllowBruteForce;
            options.MaximumSolutionsToFind = MaximumSolutionsToFind;
            options.EliminationTechniques = new List<EliminationTechnique>();
            foreach (EliminationTechnique technique in EliminationTechniques)
            {
                options.EliminationTechniques.Add(technique.Clone());
            }
            return options;
		}

		/// <summary>Clones the solver options.</summary>
		/// <returns>A clone of the options.</returns>
		object ICloneable.Clone() { return Clone(); }
	}
}