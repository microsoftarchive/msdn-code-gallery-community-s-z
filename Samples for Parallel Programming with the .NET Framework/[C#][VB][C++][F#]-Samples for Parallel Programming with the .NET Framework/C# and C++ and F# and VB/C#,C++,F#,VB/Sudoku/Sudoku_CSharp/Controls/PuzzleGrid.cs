//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: PuzzleGrid.cs
//
//  Description: Core control for displaying and interacting with a puzzle.
// 
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques;
using Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
{
	/// <summary>Control for displaying and interacting with a PuzzleState.</summary>
	[ToolboxBitmap(typeof(DataGrid))]
	internal sealed class PuzzleGrid : Control
	{
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			// 
			// PuzzleGrid
			// 
			this.BackColor = System.Drawing.Color.Transparent;
			this.ForeColor = System.Drawing.Color.Black;
		}
		#endregion

		#region Member Variables
		/// <summary>Required designer variable.</summary>
		private System.ComponentModel.IContainer components = null;
        /// <summary>Generates puzzles.</summary>
        private Generator _puzzleGenerator = new Generator();
		/// <summary>The state currently being displayed in the grid.</summary>
		private PuzzleState _state;
		/// <summary>Original state of the puzzle.</summary>
		private PuzzleState _originalState;
		/// <summary>The original state of a newly generated puzzle, used for comparison.</summary>
		private PuzzleState _solvedOriginalState;
		/// <summary>Whether to highlight cells that can only be a specific number.</summary>
		private bool _showSuggestedCells;
		/// <summary>Whether to show where incorrect numbers have been added to the grid.</summary>
		private bool _showIncorrectNumbers;
		/// <summary>The puzzle difficulty level used for showing hints.</summary>
		private PuzzleDifficulty _difficultyLevel = PuzzleDifficulty.Easy;
		/// <summary>Maintains a history of undo information.</summary>
		private Stack<PuzzleState> _undoStates = new Stack<PuzzleState>();
		/// <summary>Currently selected cell in the grid.</summary>
		private Point? _selectedCell;
		#endregion
		
		#region Setup and Shutdown
		/// <summary>Initialize the PuzzleGrid.</summary>
		public PuzzleGrid()
		{
			SetStyle(
				ControlStyles.UserPaint | ControlStyles.DoubleBuffer | 
				ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw |
				ControlStyles.SupportsTransparentBackColor, true);

			InitializeComponent();

			_userValueBrush = new SolidBrush(Color.Blue);
			_incorrectValueBrush = new SolidBrush(Color.FromArgb(255,0,0));
			_originalValueBrush = new SolidBrush(Color.FromArgb(0,0,0));

			_centerNumberFormat = new StringFormat();
			_centerNumberFormat.Alignment = StringAlignment.Center;
			_centerNumberFormat.LineAlignment = StringAlignment.Center;
		}

		/// <summary>Clean up any resources being used.</summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) components.Dispose();
				DisposeDrawingObjects();
			}
			base.Dispose(disposing);
		}

		/// <summary>Disposes all objects involved with drawing the grid.</summary>
		private void DisposeDrawingObjects()
		{
			if (_userValueBrush != null) _userValueBrush.Dispose();
			if (_incorrectValueBrush != null) _incorrectValueBrush.Dispose();
			if (_originalValueBrush != null) _originalValueBrush.Dispose();
			if (_centerNumberFormat != null) _centerNumberFormat.Dispose();

			_userValueBrush = null;
			_originalValueBrush = null;
			_centerNumberFormat = null;
		}

		/// <summary>Refocus when the control is enabled.  Nothing else should ever have focus.</summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if (Enabled) Focus();
		}
		#endregion

		#region Puzzle State
		/// <summary>Gets or sets the current puzzle state.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PuzzleState State
		{
			get
			{
				if (_state == null) 
				{
					_state = new PuzzleState();
					OnStateChanged();
				}
				return _state;
			}
			set
			{
				if (value == null) value = new PuzzleState();
				if (value != _state)
				{
					PuzzleState oldState = _state;
					if (oldState != null)
					{
						oldState.StateChanged -= new EventHandler(HandlePuzzleStateChanged);
						oldState.RaiseStateChangedEvent = false;
					}

					_state = value;
					_state.RaiseStateChangedEvent = true;
					_state.StateChanged += new EventHandler(HandlePuzzleStateChanged);
					OnStateChanged();
					Invalidate();
				}
			}
		}

		/// <summary>Gets or sets the original state of the puzzle.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal PuzzleState OriginalState 
		{
			get { return _originalState; }
			set { SetOriginalPuzzleCheckpoint(value); }
		}

		/// <summary>Gets the collection of undo states.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		internal Stack<PuzzleState> UndoStates
		{
			get { return _undoStates; }
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				_undoStates = value;
			}
		}

		/// <summary>Event raised when the grid's puzzle state is modified.</summary>
		public event EventHandler StateChanged;

		/// <summary>Raises the StateChanged event on the main UI thread.</summary>
		private void OnStateChanged()
		{
			_suggestedCell = null;
			EventHandler handler = StateChanged;
			if (handler != null)
			{
				if (InvokeRequired) Invoke(handler, new object[] { this, EventArgs.Empty });
				else handler(this, EventArgs.Empty);
			}
		}

		/// <summary>Raises the StateChanged event in response to the puzzle state's StateChanged event.</summary>
		/// <param name="sender">The modified puzzle state.</param>
		/// <param name="e">The event args.</param>
		private void HandlePuzzleStateChanged(object sender, EventArgs e)
		{
			OnStateChanged();
		}
		
		/// <summary>Gets whether the specified cell can be modified based on the original state checkpoint.</summary>
		/// <param name="cell">The cell to be verified.</param>
		/// <returns>true if the cell can be modified; otherwise, false.</returns>
		private bool CanModifyCell(Point cell)
		{
			return (cell.X >= 0 && cell.X < State.GridSize && cell.Y >= 0 && cell.Y < State.GridSize) && 
				(_originalState == null || !_originalState[cell].HasValue);
		}		

		/// <summary>Gets whether the specified cell can be cleared.</summary>
		/// <param name="cell">The cell to test.</param>
		/// <returns>Whether the cell can be cleared (it can be modified and it has a value).</returns>
		private bool CanClearCell(Point cell)
		{
			return CanModifyCell(cell) && State[cell].HasValue;
		}
		
		/// <summary>Gets the grid cell containing the specified point in the control.</summary>
		/// <param name="point">The point, typically a mouse location, for which to find the grid cell.</param>
		/// <returns>The location of the grid cell corresponding to the specified point.</returns>
		public Point GetCellFromLocation(Point point)
		{
			if (point.X < 0 || point.Y < 0) return new Point(-1,-1);

			Rectangle rect = BoardRectangle;
			if (rect.Width <= 0 || rect.Height <= 0) return new Point(-1, -1);

			float cellWidth = rect.Width / (float)_boardWidth * (_cellImageWidth+1);
			float gapWidth = rect.Width / (float)_boardWidth * (_gapImageWidth-1);

			int x = 0, y = 0;

			float pos = point.Y - rect.X;
			while(pos >= cellWidth) 
			{
				pos -= cellWidth;
				++x;
				if (x % _boxSize == 0) pos -= gapWidth;
			}

			pos = point.X - rect.Y;
			while(pos >= cellWidth) 
			{
				pos -= cellWidth;
				++y;
				if (y % _boxSize == 0) pos -= gapWidth;
			}

			return new Point(x,y);
		}
		#endregion

		#region Hints
		/// <summary>Gets or sets whether to highlight cells that can only be a specific number.</summary>
		public bool ShowSuggestedCells
		{
			get { return _showSuggestedCells; }
			set
			{
				if (value != _showSuggestedCells)
				{
					_showSuggestedCells = value;
					Invalidate();
				}
			}
		}

		/// <summary>Gets or sets whether to display the possible numbers in each cell.</summary>
		public bool ShowIncorrectNumbers
		{
			get { return _showIncorrectNumbers; }
			set
			{
				if (value != _showIncorrectNumbers)
				{
					_showIncorrectNumbers = value;
					Invalidate();
				}
			}
		}
		#endregion

		#region Puzzle Interaction
		/// <summary>Gets whether the puzzle has been modified.</summary>
		public bool PuzzleHasBeenModified
		{
			get
			{
				PuzzleStatus status = State.Status;
				return status != PuzzleStatus.Solved && OriginalState != null && !State.Equals(OriginalState);
			}
		}

		/// <summary>Generates a new puzzle and sets it to be the current puzzle in the grid.</summary>
		/// <param name="options">Options to use for the puzzle generation.</param>
		/// <remarks>Resets the undo states for the grid.</remarks>
		public void GenerateNewPuzzle(GeneratorOptions options)
		{
			LoadNewPuzzle(_puzzleGenerator.Generate(options));
		}

		/// <summary>Gets or sets the puzzle difficulty level used for showing hints.</summary>
		public PuzzleDifficulty PossibleNumbersDifficultyLevel
		{
			get { return _difficultyLevel; }
			set 
			{ 
				if (!Enum.IsDefined(typeof(PuzzleDifficulty), value)) throw new ArgumentOutOfRangeException("value");
				if (_difficultyLevel != value)
				{
					_difficultyLevel = value; 
					_suggestedCell = null;
					Invalidate();
				}
			}
		}

		/// <summary>Loads a new puzzle and sets it to be the current puzzle in the grid.</summary>
		/// <param name="state">The puzzle to load.</param>
		public void LoadNewPuzzle(PuzzleState state)
		{
			ClearUndoCheckpoints();
			ClearOriginalPuzzleCheckpoint();
			SetOriginalPuzzleCheckpoint(state.Clone());
			State = state;
			_selectedCell = FirstEmptyCell;
		}

		/// <summary>Restores a puzzle based on the state from a serialized game.</summary>
		/// <param name="state">The current puzzle state.</param>
		/// <param name="originalState">The original puzzle state.</param>
		/// <param name="undoStates">The undo state stack.</param>
		public void RestorePuzzle(
			PuzzleState state, PuzzleState originalState, Stack<PuzzleState> undoStates)
		{
			OriginalState = originalState;
			UndoStates = undoStates;
			State = state;
			_selectedCell = FirstEmptyCell;
		}

		/// <summary>Gets the position of the first empty cell in the puzzle, or the [0,0] cell if none are empty.</summary>
		private Point FirstEmptyCell
		{
			get
			{
				PuzzleState state = State;
				if (state == null) return new Point(0,0);
				for(int i=0; i<state.GridSize; i++)
				{
					for(int j=0; j<state.GridSize; j++)
					{
						Point p = new Point(i,j);
						if (!state[p].HasValue) return p;
					}
				}
				return new Point(0,0);
			}
		}

		/// <summary>Creates a checkpoint used to determine where cells are invalid in the puzzle.</summary>
		public void SetOriginalPuzzleCheckpoint(PuzzleState original)
		{
			_originalState = original;
			if (original != null)
			{
				SolverOptions options = new SolverOptions();
				options.MaximumSolutionsToFind = 2;
				SolverResults results = Solver.Solve(original, options);
				if (results.Status == PuzzleStatus.Solved && results.Puzzles.Count == 1)
				{
					_solvedOriginalState = results.Puzzle; 
				}
				else _solvedOriginalState = null;
			}
		}

		/// <summary>Clears the original puzzle checkpoint.</summary>
		public void ClearOriginalPuzzleCheckpoint()
		{
			_originalState = null;
			_solvedOriginalState = null;
		}

		/// <summary>Clears the undo puzzle checkpoints.</summary>
		public void ClearUndoCheckpoints()
		{
			_undoStates.Clear();
		}

		/// <summary>Creates an undo checkpoint such that the current grid state can be reached through the undo mechanism.</summary>
		public void SetUndoCheckpoint()
		{
			if (State != null) _undoStates.Push(State.Clone());
		}

		/// <summary>Reverts to a previously saved state.</summary>
		public void Undo()
		{
			if (_undoStates.Count > 0)
			{
				State = _undoStates.Pop();
				OnStateChanged();
				Invalidate();
			}
		}

		/// <summary>Attempts to solve the current puzzle, update the state in the grid, and return the results.</summary>
		/// <returns>The results from attempting to solve the puzzle.</returns>
		private SolverResults SolvePuzzle()
		{
			// If it's already solved, nothing to do
			if (State.Status == PuzzleStatus.Solved) return new SolverResults(PuzzleStatus.Solved, State, 0, null);
	
			// Otherwise, try to solve it.
			SolverOptions options = new SolverOptions();
			options.MaximumSolutionsToFind = 1u; // this means that if there are multiple solutions, we'll find and use the first
			options.AllowBruteForce = true;
			options.EliminationTechniques = new List<EliminationTechnique>{new NakedSingleTechnique()};
	
			SolverResults results = Solver.Solve(State, options);
			if (results.Status == PuzzleStatus.Solved && results.Puzzles.Count == 1)
			{
				SetUndoCheckpoint();
				State = results.Puzzle;
			}
			return results;
		}
		#endregion

		#region Drawing
		/// <summary>The width/height of a box.  This would need to become variable if differently sized puzzles were supported.</summary>
		private const int _boxSize = 3;
		/// <summary>The width of the underlying board image.</summary>
		private const int _boardWidth = 518;
		/// <summary>The height of the underlying board image.</summary>
		private const int _boardHeight = 518;
		/// <summary>The width of a cell in the underlying board image.</summary>
		private const int _cellImageWidth = 54;
		/// <summary>The height of a cell in the underlying board image.</summary>
		private const int _cellImageHeight = 54;
		/// <summary>The width of a the gap between cells in the underlying board image.</summary>
		private const int _cellGapWidth = 1;
		/// <summary>The height of a the gap between cells in the underlying board image.</summary>
		private const int _cellGapHeight = 1;
		/// <summary>The width of a the gap between boxes in the underlying board image.</summary>
		private const int _gapImageWidth = 13;
		/// <summary>The height of a the gap between boxes in the underlying board image.</summary>
		private const int _gapImageHeight = 13;

		/// <summary>Gets the bounding rectangle for a specific cell.</summary>
		/// <param name="rect">The client rectange.</param>
		/// <param name="cell">The target cell.</param>
		/// <returns>The bounding rectangle.</returns>
		public static RectangleF GetCellRectangle(Rectangle rect, Point cell)
		{
			float width = (_cellImageWidth + _cellGapWidth) / (float)_boardWidth * rect.Width;
			float height = (_cellImageHeight + _cellGapHeight) / (float)_boardHeight * rect.Height;
			RectangleF cellRect = new RectangleF(
				rect.X + (cell.Y*width) + ((cell.Y/_boxSize)*((_gapImageWidth-1)/(float)_boardWidth*rect.Width)), 
				rect.Y + (cell.X*height) + ((cell.X/_boxSize)*((_gapImageHeight-1)/(float)_boardHeight*rect.Height)), 
				_cellImageWidth / (float)_boardWidth * rect.Width,
				_cellImageHeight / (float)_boardHeight * rect.Height);
			return cellRect;
		}

		/// <summary><para>Raises the Paint event.</para></summary>
		/// <param name="e">A PaintEventArgs that contains the event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			DrawToGraphics(e.Graphics, e.ClipRectangle);
		}

		/// <summary>Brush used to draw text and other objects with the font color.</summary>
		private Brush _userValueBrush;
		/// <summary>Brush used to draw incorrect values on the grid.</summary>
		private Brush _incorrectValueBrush;
		/// <summary>Brush used to draw text and other objects with a variation of the font color.</summary>
		private Brush _originalValueBrush;
		/// <summary>StringFormat used to center text within a rectangle.</summary>
		private StringFormat _centerNumberFormat;

		/// <summary>The location of the cell to suggest as a "try this one next" hint.</summary>
		private Point? _suggestedCell = null;

		/// <summary>Gets the location of the cell to suggest as a "try this one next" hint.</summary>
		private Point? SuggestedCell
		{
			get
			{
				if (_suggestedCell == null)
				{
					// First, see if any cells are the only one left to be filled in their
					// row, column, or box.  Regardless of techniques in use, only one
					// cell without a value in a row, column, or box really must be the easiest.
					Point? foundEmpty = null;
					for(byte row=0; row<State.GridSize; row++)
					{
						for(byte col=0; col<State.GridSize; col++)
						{
							if (!State[row,col].HasValue)
							{
								if (!foundEmpty.HasValue) foundEmpty = new Point(row,col);
								else
								{
									foundEmpty = null;
									break;
								}
							}
						}
						if (foundEmpty.HasValue) return _suggestedCell = foundEmpty;
					}
					foundEmpty = null;
					for(byte col=0; col<State.GridSize; col++)
					{
						for(byte row=0; row<State.GridSize; row++)
						{
							if (!State[row,col].HasValue)
							{
								if (!foundEmpty.HasValue) foundEmpty = new Point(row,col);
								else
								{
									foundEmpty = null;
									break;
								}
							}
						}
						if (foundEmpty.HasValue) return _suggestedCell = foundEmpty;
					}
					foundEmpty = null;
					for (byte gridNum = 0; gridNum < State.GridSize; gridNum++)
					{
						byte gridX = (byte)(gridNum % State.BoxSize);
						byte gridY = (byte)(gridNum / State.BoxSize);
						byte startX = (byte)(gridX * State.BoxSize);
						byte startY = (byte)(gridY * State.BoxSize);
						bool done = false;
						for (byte x = startX; x < startX + State.BoxSize && !done; x++)
						{
							for (byte y = startY; y < startY + State.BoxSize && !done; y++)
							{
								if (!State[x,y].HasValue)
								{
									if (!foundEmpty.HasValue) foundEmpty = new Point(x,y);
									else
									{
										foundEmpty = null;
										done = true;
									}
								}
							}
						}
						if (foundEmpty.HasValue) return _suggestedCell = foundEmpty;
					}

					// If one could not be found doing that, move on to techniques
					List<EliminationTechnique> tc = new List<EliminationTechnique>();
					FastBitArray [][] possibleNumbers = PuzzleState.InstantiatePossibleNumbersArray(State);
					foreach(EliminationTechnique et in EliminationTechnique.AvailableTechniques)
					{
						tc.Add(et);
                        Dictionary<EliminationTechnique, int> ignored = null;
						State.ComputePossibleNumbers(tc, ref ignored, true, true, possibleNumbers);
						for(int row=0; row<State.GridSize; row++)
						{
							for(int column=0; column<State.GridSize; column++)
							{
								if (possibleNumbers[row][column].CountSet == 1)
								{
									return _suggestedCell = new Point(row, column);
								}
							}
						}
					}

					// If nothing with only one possible value could be found by using techniques,
					// find the cell with the fewest possible numbers and suggest it.
					if (possibleNumbers != null)
					{
						int bestCount = State.GridSize;
						for(int row=0; row<State.GridSize; row++)
						{
							for(int column=0; column<State.GridSize; column++)
							{
								Point cell = new Point(row, column);
								if (!State[cell].HasValue)
								{
									int numSet = possibleNumbers[row][column].CountSet;
									if (numSet < bestCount)
									{
										_suggestedCell = cell;
										bestCount = numSet;
									}
								}
							}
						}
					}

					// If there is none, just make it an invalid point
					if (_suggestedCell == null) _suggestedCell = new Point(-1,-1);
				}
				return _suggestedCell;
			}
		}

		/// <summary>Gets the current rectangle for the playing board.</summary>
		public Rectangle BoardRectangle 
		{
			get
			{
				Rectangle rect = ClientRectangle;
				int amount = rect.Width / 51;
				if (amount < 2) amount = 2;
				rect.Inflate(-amount, -amount);
				return rect;
			}
		}

		/// <summary>The font size, in points, for numbers on the grid.</summary>
		private float _cachedEmSize = -1;

		/// <summary>Clears the cached font size when the font is changed.</summary>
		protected override void OnFontChanged(EventArgs e)
		{
			_cachedEmSize = -1;
			base.OnFontChanged (e);
		}

		/// <summary>Draws the playing grid onto the specified graphics object and within the specified bounding rectangle.</summary>
		/// <param name="graphics">The graphics object onto</param>
		public void DrawToGraphics(Graphics graphics, Rectangle clipRectangle)
		{
			if (graphics == null) throw new ArgumentNullException("graphics");
			Rectangle rect = BoardRectangle;

			// Draw the underlying board images
			graphics.DrawImage(ResourceHelper.BoardBackgroundImage, 0, 0, Width, Height);
			graphics.DrawImage(ResourceHelper.BoardImage, rect); 

			// Precompute some important sizes, such as the width and height of
			// a cell in the grid, positioning information for drawing possible numbers,
			// and the em size to use for drawing text.
			RectangleF genericCellRect = GetCellRectangle(rect, new Point(0,0));
			float cellWidth = genericCellRect.Width;
			float cellHeight = genericCellRect.Height;

			// Get the em size for the current font based on the current board size.
			// This is cached, and the cache is only cleared when the board is resized or when the font is changed.
			float emSize;
			if (_cachedEmSize < 0) _cachedEmSize = GraphicsHelpers.GetMaximumEMSize(ResourceHelper.FontSizingString, graphics, this.Font.FontFamily, FontStyle.Bold, cellWidth, cellHeight);
			emSize = _cachedEmSize;

			bool showSuggestedCells = ShowSuggestedCells;
			
			// Draw cell images
			using (Font setNumberFont = new Font(this.Font.FontFamily, emSize, FontStyle.Bold))
			{
				for (int i = 0; i < State.GridSize; i++)
				{
					for (int j = 0; j < State.GridSize; j++)
					{
						RectangleF cellRect = GetCellRectangle(rect, new Point(i,j));
						if (clipRectangle.IntersectsWith(Rectangle.Ceiling(cellRect)))
						{
							if (State.Status != PuzzleStatus.Solved)
							{
								if (_selectedCell.HasValue && _selectedCell.Value.X == i && _selectedCell.Value.Y == j)
								{
									Image selectedCellImage;
									if (i == 0 && j == 0) selectedCellImage = ResourceHelper.CellActiveUpperLeft;
									else if (i == 0 && j == State.GridSize-1) selectedCellImage = ResourceHelper.CellActiveUpperRight;
									else if (i == State.GridSize-1 && j == 0) selectedCellImage = ResourceHelper.CellActiveLowerLeft;
									else if (i == State.GridSize-1 && j == State.GridSize-1) selectedCellImage = ResourceHelper.CellActiveLowerRight;
									else selectedCellImage = ResourceHelper.CellActiveSquare;
									graphics.DrawImage(selectedCellImage, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
								}
								else if (showSuggestedCells && SuggestedCell.HasValue && 
									SuggestedCell.Value.X == i && SuggestedCell.Value.Y == j)
								{
									Image suggestedCellImage;
									if (i == 0 && j == 0) suggestedCellImage = ResourceHelper.CellHintUpperLeft;
									else if (i == 0 && j == State.GridSize-1) suggestedCellImage = ResourceHelper.CellHintUpperRight;
									else if (i == State.GridSize-1 && j == 0) suggestedCellImage = ResourceHelper.CellHintLowerLeft;
									else if (i == State.GridSize-1 && j == State.GridSize-1) suggestedCellImage = ResourceHelper.CellHintLowerRight;
									else suggestedCellImage = ResourceHelper.CellHintSquare;
									graphics.DrawImage(suggestedCellImage, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
								}
							}

							// If a cell has a value, then draw that value
							if (State[i, j].HasValue)
							{
								Brush b;
								if (ShowIncorrectNumbers &&
									State[i, j].HasValue && _solvedOriginalState != null && 
									State[i, j].Value != _solvedOriginalState[i, j].Value)
								{
									b = _incorrectValueBrush;
								}
								else if (_originalState != null && _originalState[i,j].HasValue)
								{
									b = _originalValueBrush;
								} 
								else b = _userValueBrush;
                                
								graphics.DrawString((State[i, j] + 1).Value.ToString(CultureInfo.InvariantCulture), setNumberFont, b,
									cellRect, _centerNumberFormat);
							}
						}
					}
				}
			}
		}

		#endregion

		#region Keyboard and Mouse Interaction
		/// <summary>Determines whether the specified key is a regular input key or a special key that requires processing.</summary>
		/// <param name="keyData">A Keys value.</param>
		/// <returns>Whether the specified Keys should be treated as an input key.</returns>
		protected override bool IsInputKey(Keys keyData)
		{
			// We want to allow the control to handle up, down, left, right, so that
			// the user can move around the selected cell marker with the arrow keys
			switch (keyData)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					return true;
			}
			return base.IsInputKey(keyData);
		}

		/// <summary>Handles the KeyDown event.</summary>
		/// <param name="e">Event args</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            bool handled = true;
            bool invalidate = true;

            Point selectedCell = _selectedCell.Value;

            // Alt+Shift+2, in homage to Windows Solitaire :-)
            if (k == Keys.D2 && e.Shift && e.Alt)
            {
                SolvePuzzle();
            }
            // Digits are treated as numbers and stored into the grid
            else if ((k >= Keys.D1 && k <= Keys.D9) || (k >= Keys.NumPad1 & k <= Keys.NumPad9))
            {
                if (State != null && CanModifyCell(selectedCell))
                {
                    SetStateCell(selectedCell, (k >= Keys.NumPad1 && k <= Keys.NumPad9) ?
                        (byte)(k - Keys.NumPad1) : (byte)(k - Keys.D1));
                }
            }
            // Delete, space, and a variety of other keys are used to clear out the contents of a grid cell
            else if (k == Keys.Delete || k == Keys.Space || k == Keys.Back)
            {
                if (State != null && CanClearCell(selectedCell))
                {
                    ClearStateCellWithInvalidation(selectedCell);
                    invalidate = false;
                }
            }
            // And the arrow keys are used to move around the grid
            else if (k == Keys.Down && selectedCell.X + 1 < State.GridSize)
            {
                InvalidateCell(selectedCell);
                selectedCell.X++;
                InvalidateCell(selectedCell);
                invalidate = false;
            }
            else if (k == Keys.Up && selectedCell.X - 1 >= 0)
            {
                InvalidateCell(selectedCell);
                selectedCell.X--;
                InvalidateCell(selectedCell);
                invalidate = false;
            }
            else if (k == Keys.Right && selectedCell.Y + 1 < State.GridSize)
            {
                InvalidateCell(selectedCell);
                selectedCell.Y++;
                InvalidateCell(selectedCell);
                invalidate = false;
            }
            else if (k == Keys.Left && selectedCell.Y - 1 >= 0)
            {
                InvalidateCell(selectedCell);
                selectedCell.Y--;
                InvalidateCell(selectedCell);
                invalidate = false;
            }
            // Otherwise, not handled
            else handled = false;

            // If it was handled, update the necessary state
            if (handled)
            {
                _selectedCell = selectedCell;
                e.Handled = true;
                if (invalidate) Invalidate();
            }

            if (!e.Handled) base.OnKeyDown(e);
        }

		/// <summary>Update the selected cell when the mouse is clicked down.</summary>
		/// <param name="e">The mouse event args.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point cell = GetCellFromLocation(new Point(e.X, e.Y));
            if (_selectedCell.HasValue) InvalidateCell(_selectedCell.Value);
            SetSelectedCell(cell);
            InvalidateCell(cell);
        }

		/// <summary>Sets the selected cell to the specified cell, if it's valid.</summary>
		/// <param name="cell">The cell to be selected.</param>
		private void SetSelectedCell(Point cell)
		{
			if (cell.X >= 0 && cell.X < State.GridSize &&
				cell.Y >= 0 && cell.Y < State.GridSize &&
				_selectedCell != cell) 
			{
				_selectedCell = cell;
			}
		}
		#endregion

		/// <summary>Resizes the control.</summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnResize(EventArgs e)
		{
			_cachedEmSize = -1;
			base.OnResize(e);
		}

		/// <summary>Sets the contents of a cell in the current puzzle.</summary>
		/// <param name="cell">The cell to be set.</param>
		/// <param name="number">The value to which the cell should be set.</param>
		/// <remarks>Sets an undo checkpoint and deletes any scratchpad strokes for the specified cell.</remarks>
		private void SetStateCell(Point cell, byte number)
		{
			if (State[cell] != number)
			{
				SetUndoCheckpoint();
				State[cell] = number;
			}
		}

		/// <summary>Clears the contents of a cell in the current puzzle.</summary>
		/// <param name="cell">The cell to be cleared.</param>
		/// <remarks>Sets an undo checkpoint.</remarks>
		private void ClearStateCell(Point cell)
		{
			if (State[cell].HasValue)
			{
				SetUndoCheckpoint();
				State[cell] = null;
			}
		}

		/// <summary>Invalidates the specified cell.</summary>
		/// <param name="cell">The cell to be repainted.</param>
		private void InvalidateCell(Point cell)
		{
			if (cell.X >= 0 && cell.X < State.GridSize &&
				cell.Y >= 0 && cell.Y < State.GridSize)
			{
				const int BUFFER_DIST = 2;
				RectangleF rect = GetCellRectangle(BoardRectangle, cell);
				rect.Inflate(BUFFER_DIST,BUFFER_DIST);
				Invalidate(Rectangle.Ceiling(rect));
			}
		}

		/// <summary>Clears a cell and invalidates it.</summary>
		/// <param name="cell">The cell to be cleared and repainted.</param>
		private void ClearStateCellWithInvalidation(Point cell)
		{
			bool showSuggestedCells = ShowSuggestedCells;
			if (showSuggestedCells) InvalidateCell(SuggestedCell.Value);
			ClearStateCell(cell);
			InvalidateCell(cell);
			if (showSuggestedCells) InvalidateCell(SuggestedCell.Value);
		}
	}
}