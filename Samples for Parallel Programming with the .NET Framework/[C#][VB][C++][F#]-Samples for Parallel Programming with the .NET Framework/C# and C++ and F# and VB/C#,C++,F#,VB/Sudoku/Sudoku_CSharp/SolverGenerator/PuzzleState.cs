//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PuzzleState.cs
//
//  Description: Stores the current configuration of a puzzle.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
{
	/// <summary>Maintains the state for a particular instance of a Sudoku puzzle.</summary>
	[Serializable]
	public sealed class PuzzleState : ICloneable, IEnumerable
	{
		/// <summary>Maximum size of a puzzle state box.</summary>
		private const byte _defaultBoxSize = 3;
		/// <summary>The size of each box in the puzzle.</summary>
		private readonly byte _boxSize;
		/// <summary>The size of the entire puzzle.</summary>
		private readonly byte _gridSize;
		/// <summary>The state of each cell in the puzzle.</summary>
		private byte?[,] _grid;
		/// <summary>Known difficulty level of the puzzle.</summary>
		private PuzzleDifficulty _difficulty;
		/// <summary>The number of cells currently filled in the puzzle.</summary>
		[NonSerialized]
		private int? _filledCells;
		/// <summary>The puzzle's current status.  Invalidated every time the puzzle is changed.</summary>
		[NonSerialized]
		private PuzzleStatus _status;
		/// <summary>Event raised when a cell in the grid changes its contained value.</summary>
		[NonSerialized]
		private EventHandler _stateChanged;		
		/// <summary>Whether to raise state changed events.</summary>
		[NonSerialized]
		private bool _raiseStateChangedEvent;

		/// <summary>Initializes the PuzzleState.</summary>
		public PuzzleState()
		{
			_boxSize = _defaultBoxSize;
            _gridSize = (byte)(_boxSize * _boxSize);
			_grid = new byte?[_gridSize, _gridSize];
		}

		/// <summary>Initializes the PuzzleState.</summary>
		/// <param name="state">The state to be cloned into this new instance.</param>
		private PuzzleState(PuzzleState state)
		{
			// We don't use MemberwiseClone here as the new state should not share references
			_boxSize = state._boxSize; // immutable once created
			_gridSize = state._gridSize; // immutable once created
			_grid = (byte?[,])state._grid.Clone();
			_status = state._status; // immutable once created
			_filledCells = state._filledCells; // immutable once created
			_difficulty = state._difficulty; // immutable once created
		}

		/// <summary>Gets the size of a box in the puzzle (the sqrt of the grid size).</summary>
		public byte BoxSize { get { return _boxSize; } }

		/// <summary>Gets the size of the puzzle grid.</summary>
		public byte GridSize { get { return _gridSize; } }

		/// <summary>Gets or sets the perceived difficulty level of this puzzle.</summary>
		public PuzzleDifficulty Difficulty { get { return _difficulty; } set { _difficulty = value; } }

		/// <summary>Gets or sets the cell value.</summary>
		/// <param name="cell">The coordinates of the cell whose value is to be set or retrieved.</param>
		/// <returns>The value of the specified cell, or null if it has no value.</returns>
		public byte? this[Point cell]
		{
			get { return _grid[cell.X, cell.Y]; }
			set 
			{ 
				byte? oldValue = _grid[cell.X, cell.Y];
				if (oldValue != value)
				{
					_status = PuzzleStatus.Unknown;
					_filledCells = null;

					_grid[cell.X, cell.Y] = value;
					OnStateChanged(); //cell, oldValue, value);
				}
			}
		}

		/// <summary>Gets or sets the cell value.</summary>
		/// <param name="cellX">The x-coordinate of the cell whose value is to be set or retrieved.</param>
		/// <param name="cellY">The y-coordinate of the cell whose value is to be set or retrieved.</param>
		/// <returns>The value of the specified cell, or null if it has no value.</returns>
		public byte? this[int cellX, int cellY]
		{
			get { return _grid[cellX, cellY]; }
			set { this[new Point(cellX, cellY)] = value; }
		}

		/// <summary>Event raised when a cell in the grid changes its contained value.</summary>
		public event EventHandler StateChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add { _stateChanged = (EventHandler)Delegate.Combine(_stateChanged, value); }
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove { _stateChanged = (EventHandler)Delegate.Remove(_stateChanged, value); }
		}

		/// <summary>Gets or sets whether to raise state changed events.</summary>
        public bool RaiseStateChangedEvent { get { return _raiseStateChangedEvent; } set { _raiseStateChangedEvent = value; } }

		/// <summary>Raises the state changed event if RaiseStateChangedEvent is true.</summary>
		private void OnStateChanged()
		{
			if (_raiseStateChangedEvent)
			{
				EventHandler handler = _stateChanged;
				if (handler != null) handler(this, EventArgs.Empty);
			}
		}

		/// <summary>Gets the puzzle's current status.</summary>
		public PuzzleStatus Status
		{
			get
			{
				if (_status == PuzzleStatus.Unknown) _status = AnalyzeSolutionStatus();
				return _status;
			}
		}

		/// <summary>Gets the number of filled cells in the grid.</summary>
		public int NumberOfFilledCells
		{
			get
			{
				if (!_filledCells.HasValue)
				{
					int count = 0;
					foreach (byte? cell in _grid) if (cell.HasValue) count++;
					_filledCells = count;
				}
				return _filledCells.Value;
			}
		}

		/// <summary>Gets an enumerator for all of the cells in the grid.</summary>
		/// <returns>An enumerator for all of the cells in the grid.</returns>
        IEnumerator IEnumerable.GetEnumerator() { return _grid.GetEnumerator(); }

		/// <summary>Deep clones this PuzzleState.</summary>
		/// <returns>A deep clone of this PuzzleState.</returns>
		public PuzzleState Clone() { return new PuzzleState(this); }

		/// <summary>Deep clones this PuzzleState.</summary>
		/// <returns>A deep clone of this PuzzleState.</returns>
		object ICloneable.Clone() { return Clone(); }

		/// <summary>Determines whether this state and the specified state represent the same filled in cells.</summary>
		/// <param name="obj">The other state to which to compare this state.</param>
		/// <returns>true if the states are equal; false, otherwise.</returns>
		public override bool Equals(object obj)
		{
			PuzzleState other = obj as PuzzleState;
			return (other != null) ? StatesMatch(this, other) : base.Equals(obj);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>The hash code for this instance.</returns>
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		/// <summary>Creates a string representation of this puzzle state.</summary>
		/// <returns>A string representation of this puzzle state.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GridSize*(GridSize+2));
			for(int i=0; i<GridSize; i++)
			{
				for(int j=0; j<GridSize; j++)
				{
					Point cell = new Point(i,j);
					sb.Append(this[cell].HasValue ? (char)(this[cell].Value + '1') : '.');
				}
				sb.Append(Environment.NewLine);
			}
			return sb.ToString();
		}

		/// <summary>Compares two puzzle states to determine if they're equal.</summary>
		/// <param name="first">The first puzzle state.</param>
		/// <param name="second">The second puzzle state.</param>
		/// <returns>true if the states are equal; otherwise, false.</returns>
		private static bool StatesMatch(PuzzleState first, PuzzleState second)
		{
			if (first == null) throw new ArgumentNullException("first");
			if (second == null) throw new ArgumentNullException("second");

			// They're equal only if the corresponding cells both contain the
			// same number or are both empty.
			if (first.GridSize != second.GridSize) return false;
			for(int i=0; i<first.GridSize; i++)
			{
				for(int j=0; j<second.GridSize; j++)
				{
					if (first[i,j] != second[i,j]) return false;
				}
			}
			return true;
		}

        public static FastBitArray[][] InstantiatePossibleNumbersArray(PuzzleState state)
		{
			FastBitArray[][] possibleNumbers = new FastBitArray[state.GridSize][];
			for(int i=0; i<possibleNumbers.Length; i++) possibleNumbers[i] = new FastBitArray[state.GridSize];
			for (int i = 0; i < state.GridSize; i++)
			{
				for (int j = 0; j < state.GridSize; j++)
				{
					possibleNumbers[i][j] = new FastBitArray(state.GridSize);
				}
			}
			return possibleNumbers;
		}

		/// <summary>Determines what numbers are possible in each of the cells in the state.</summary>
		/// <param name="state">The puzzle state to analyze.</param>
		/// <param name="techniques">The techniques to use for this elimination process.</param>
		/// <param name="onlyOnePass">
		/// Whether only one pass should be made through each technique, or whether it should repeat all techniques
		/// as long as any technique made any changes.
		/// </param>
		/// <param name="usesOfTechnique">How much each of the techniques was used.</param>
		/// <param name="possibleNumbers">The possible numbers used for this computation.</param>
		/// <returns>The computed possible numbers.</returns>
        public FastBitArray[][] ComputePossibleNumbers(
            List<EliminationTechnique> techniques, ref Dictionary<EliminationTechnique, int> usesOfTechnique, 
			bool onlyOnePass, bool earlyExitWhenSoleFound,
			FastBitArray[][] possibleNumbers)
		{
			// Initialize the possible numbers grid
			for (int i = 0; i < GridSize; i++)
			{
				for (int j = 0; j < GridSize; j++)
				{
					possibleNumbers[i][j].SetAll(this[i, j].HasValue ? false : true);
				}
			}

			// Perform eliminations based on the techniques available to this puzzle state.
			// The techniques available depend on the difficulty level of the puzzle.
			bool notDone;
			do
			{
				notDone = false;
				foreach(EliminationTechnique e in techniques)
				{ 
					int numberOfChanges = 0;
					bool exitedEarly = false;
					notDone |= e.Execute(this, earlyExitWhenSoleFound, possibleNumbers, out numberOfChanges, out exitedEarly);
					if (usesOfTechnique != null)
					{
                        int uses;
                        if (usesOfTechnique.TryGetValue(e, out uses))
                        {
                            usesOfTechnique[e] = numberOfChanges + uses;
                        }
                        else usesOfTechnique[e] = numberOfChanges;
					}
					if (exitedEarly)
					{
						notDone = false;
						break;
					}
				}
			}
			while(notDone && !onlyOnePass);

			return possibleNumbers;
		}
		
		/// <summary>Analyzes the state of the puzzle to determine whether it is a solution or not.</summary>
		/// <returns>The status of the puzzle.</returns>
		private PuzzleStatus AnalyzeSolutionStatus()
		{
			// Need a way of keeping track of what numbers have been used (in each row, column, box, etc.)
			// A bit array is a great way to do this, where each bit corresponds to a true/false value
			// as to whether a number was already used in a particular scenario.
			FastBitArray numbersUsed = new FastBitArray(_gridSize);

			// Make sure every column contains the right numbers.  It's ok if a column has holes
			// as long as those cells have possibilities, in which case it's a puzzle in progress.
			// However, two numbers can't be used in the same column, even if there are holes.
			for (int i = 0; i < _gridSize; i++)
			{
				numbersUsed.SetAll(false);
				for (int j = 0; j < _gridSize; j++)
				{
					if (_grid[i, j].HasValue)
					{
						int value = _grid[i, j].Value;
						if (numbersUsed[value]) return PuzzleStatus.CannotBeSolved;
						numbersUsed[value] = true;
					}
				}
			}

			// Same for rows
			for (int j = 0; j < _gridSize; j++)
			{
				numbersUsed.SetAll(false);
				for (int i = 0; i < _gridSize; i++)
				{
					if (_grid[i, j].HasValue)
					{
						int value = _grid[i, j].Value;
						if (numbersUsed[value]) return PuzzleStatus.CannotBeSolved;
						numbersUsed[value] = true;
					}
				}
			}

			// Same for boxes
			for (int boxNumber = 0; boxNumber < _gridSize; boxNumber++)
			{
				numbersUsed.SetAll(false);
				int boxStartX = (boxNumber / _boxSize) * _boxSize;
				for (int x = boxStartX; x < boxStartX + _boxSize; x++)
				{
					int boxStartY = (boxNumber % _boxSize) * _boxSize;
					for (int y = boxStartY; y < boxStartY + _boxSize; y++)
					{
						if (_grid[x, y].HasValue)
						{
							int value = _grid[x, y].Value;
							if (numbersUsed[value]) return PuzzleStatus.CannotBeSolved;
							numbersUsed[value] = true;
						}
					}
				}
			}

			// Now figure out whether this is a solved puzzle or a work in progress
			// based on whether there are any holes
			for (int i = 0; i < _gridSize; i++)
			{
				for (int j = 0; j < _gridSize; j++)
				{
					if (!_grid[i, j].HasValue) return PuzzleStatus.InProgress;
				}
			}

			// If we made it this far, this state is a valid solution!  Woo hoo!
			return PuzzleStatus.Solved;
		}
	}
}