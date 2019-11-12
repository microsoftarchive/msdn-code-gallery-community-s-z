//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: EliminationTechnique.cs
//
//  Description: Base class for all Sudoku techniques.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
{
	/// <summary>Base type used for eliminating possible numbers from cells in a puzzle state.</summary>
    [Serializable]
    public abstract class EliminationTechnique : ICloneable
    {
        /// <summary>Stores an instance of each available technique.</summary>
        private static List<EliminationTechnique> _allAvailableTechniques;
        /// <summary>Locking mechanism for static members.</summary>
        private static object _lock = new object();

        /// <summary>Gets a collection containing an instance of each available technique.</summary>
        public static List<EliminationTechnique> AvailableTechniques
        {
            get
            {
                if (_allAvailableTechniques == null)
                {
                    lock (_lock)
                    {
                        if (_allAvailableTechniques == null)
                        {
                            _allAvailableTechniques = new List<EliminationTechnique>();
                            foreach (Type t in typeof(EliminationTechnique).Assembly.GetTypes())
                            {
                                if (t.IsSubclassOf(typeof(EliminationTechnique)) &&
                                    !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
                                {
                                    _allAvailableTechniques.Add((EliminationTechnique)Activator.CreateInstance(t));
                                }
                            }
                            _allAvailableTechniques.Sort(new TechniqueDifficultyComparer());
                        }
                    }
                }
                return _allAvailableTechniques;
            }
        }

        /// <summary>Allows for the sorting of EliminationTechniques by difficulty level.</summary>
        private class TechniqueDifficultyComparer : IComparer<EliminationTechnique>
        {
            /// <summary>Compares two EliminationTechniques.</summary>
            /// <param name="x">The first technique.</param>
            /// <param name="y">The second technique.</param>
            /// <returns>The result of comparing the first technique's difficulty level to that of the second.</returns>
            public int Compare(EliminationTechnique x, EliminationTechnique y)
            {
                if (x == null && y == null) return 0;
                else if (x == null) return 1;
                else if (y == null) return -1;
                else return x.DifficultyLevel.CompareTo(y.DifficultyLevel);
            }
        }

        internal EliminationTechnique() { }

        /// <summary>Gets the difficulty level of this technique.</summary>
        internal abstract uint DifficultyLevel { get; }

        /// <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
        /// <param name="state">The puzzle state.</param>
        /// <param name="exitEarlyWhenSoleFound">Whether the method can exit early when a cell with only one possible number is found.</param>
        /// <param name="possibleNumbers">The previously computed possible numbers.</param>
        /// <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
        /// <param name="exitedEarly">Whether the method exited early due to a cell with only one value being found.</param>
        /// <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        internal abstract bool Execute(
            PuzzleState state, bool exitEarlyWhenSoleFound,
            FastBitArray[][] possibleNumbers, out int numberOfChanges, out bool exitedEarly);

        /// <summary>Compares two integer arrays.</summary>
        /// <param name="values1">The first array.</param>
        /// <param name="values2">The second array.</param>
        /// <returns>true if arrays contain the same integers in the same order; otherwise, false.</returns>
        internal static bool CompareValues(int[] values1, int[] values2)
        {
            if (values1.Length != values2.Length) return false;
            for (int i = 0; i < values1.Length; i++)
            {
                if (values1[i] != values2[i]) return false;
            }
            return true;
        }

        /// <summary>Gets an array of the possible number bit arrays for a given row in the puzzle state.</summary>
        /// <param name="possibleNumbers">The possible numbers.</param>
        /// <param name="row">The row.</param>
        /// <param name="target">The array to store the output.</param>
        internal static void GetRowPossibleNumbers(FastBitArray[][] possibleNumbers, int row, FastBitArray[] target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = possibleNumbers[row][i];
            }
        }

        /// <summary>Gets an array of the possible number bit arrays for a given column in the puzzle state.</summary>
        /// <param name="possibleNumbers">The possible numbers.</param>
        /// <param name="column">The column.</param>
        /// <param name="target">The array to store the output.</param>
        internal static void GetColumnPossibleNumbers(FastBitArray[][] possibleNumbers, int column, FastBitArray[] target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = possibleNumbers[i][column];
            }
        }

        /// <summary>Gets an array of the possible number bit arrays for a given box in the puzzle state.</summary>
        /// <param name="state">The puzzle state.</param>
        /// <param name="possibleNumbers">The possible numbers.</param>
        /// <param name="box">The box.</param>
        /// <param name="target">The array to store the output.</param>
        internal static void GetBoxPossibleNumbers(PuzzleState state, FastBitArray[][] possibleNumbers, int box, FastBitArray[] target)
        {
            int count = 0;
            int boxStartX = (box % state.BoxSize) * state.BoxSize;
            for (int x = boxStartX; x < boxStartX + state.BoxSize; x++)
            {
                int boxStartY = (box / state.BoxSize) * state.BoxSize;
                for (int y = boxStartY; y < boxStartY + state.BoxSize; y++)
                {
                    target[count++] = possibleNumbers[x][y];
                }
            }
        }

        /// <summary>Gets the number of the box containing a particular cell.</summary>
        /// <param name="boxSize">The size of a box.</param>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns>The number of the box.</returns>
        internal static int GetBoxNumber(int boxSize, int row, int column)
        {
            return ((row / boxSize) * 3) + (column / boxSize);
        }

        /// <summary>Determines whether all of the specified numbers are set in the bit array.</summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="array">The bit array.</param>
        /// <returns>Whether all of the specified numbers in the bit array are set.</returns>
        internal static bool AllAreSet(int[] numbers, FastBitArray array)
        {
            foreach (int n in numbers)
            {
                if (!array[n]) return false;
            }
            return true;
        }

        /// <summary>Determines whether any of the specified numbers are set in the bit array.</summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="array">The bit array.</param>
        /// <returns>Whether any of the specified numbers in the bit array are set.</returns>
        internal static bool AnyAreSet(int[] numbers, FastBitArray array)
        {
            foreach (int n in numbers)
            {
                if (array[n]) return true;
            }
            return false;
        }

        public virtual EliminationTechnique Clone()
        {
            return (EliminationTechnique)MemberwiseClone();
        }

        object ICloneable.Clone() { return Clone(); }
    }
}