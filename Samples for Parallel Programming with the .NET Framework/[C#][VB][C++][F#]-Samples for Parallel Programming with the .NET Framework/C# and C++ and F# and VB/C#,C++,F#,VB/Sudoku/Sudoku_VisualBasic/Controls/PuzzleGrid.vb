'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PuzzleGrid.vb
'
'  Description: Core control for displaying and interacting with a puzzle.
' 
'--------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Controls
	''' <summary>Control for displaying and interacting with a PuzzleState.</summary>
	<ToolboxBitmap(GetType(DataGrid))>
	Friend NotInheritable Class PuzzleGrid
		Inherits Control
		#Region "Component Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			' 
			' PuzzleGrid
			' 
			Me.BackColor = Color.Transparent
			Me.ForeColor = Color.Black
		End Sub
		#End Region

		#Region "Member Variables"
		''' <summary>Required designer variable.</summary>
        Private components As System.ComponentModel.IContainer = Nothing
		''' <summary>Generates puzzles.</summary>
		Private _puzzleGenerator As New Generator()
		''' <summary>The state currently being displayed in the grid.</summary>
		Private _state As PuzzleState
		''' <summary>Original state of the puzzle.</summary>
		Private _originalState As PuzzleState
		''' <summary>The original state of a newly generated puzzle, used for comparison.</summary>
		Private _solvedOriginalState As PuzzleState
		''' <summary>Whether to highlight cells that can only be a specific number.</summary>
		Private _showSuggestedCells As Boolean
		''' <summary>Whether to show where incorrect numbers have been added to the grid.</summary>
		Private _showIncorrectNumbers As Boolean
		''' <summary>The puzzle difficulty level used for showing hints.</summary>
		Private _difficultyLevel As PuzzleDifficulty = PuzzleDifficulty.Easy
		''' <summary>Maintains a history of undo information.</summary>
		Private _undoStates As New Stack(Of PuzzleState)()
		''' <summary>Currently selected cell in the grid.</summary>
		Private _selectedCell? As Point
		#End Region

		#Region "Setup and Shutdown"
		''' <summary>Initialize the PuzzleGrid.</summary>
		Public Sub New()
            SetStyle(ControlStyles.UserPaint Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or
                     ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)

			InitializeComponent()

			_userValueBrush = New SolidBrush(Color.Blue)
			_incorrectValueBrush = New SolidBrush(Color.FromArgb(255,0,0))
			_originalValueBrush = New SolidBrush(Color.FromArgb(0,0,0))

			_centerNumberFormat = New StringFormat()
			_centerNumberFormat.Alignment = StringAlignment.Center
			_centerNumberFormat.LineAlignment = StringAlignment.Center
		End Sub

		''' <summary>Clean up any resources being used.</summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
				DisposeDrawingObjects()
			End If
			MyBase.Dispose(disposing)
		End Sub

		''' <summary>Disposes all objects involved with drawing the grid.</summary>
		Private Sub DisposeDrawingObjects()
			If _userValueBrush IsNot Nothing Then
				_userValueBrush.Dispose()
			End If
			If _incorrectValueBrush IsNot Nothing Then
				_incorrectValueBrush.Dispose()
			End If
			If _originalValueBrush IsNot Nothing Then
				_originalValueBrush.Dispose()
			End If
			If _centerNumberFormat IsNot Nothing Then
				_centerNumberFormat.Dispose()
			End If

			_userValueBrush = Nothing
			_originalValueBrush = Nothing
			_centerNumberFormat = Nothing
		End Sub

		''' <summary>Refocus when the control is enabled.  Nothing else should ever have focus.</summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
			MyBase.OnEnabledChanged(e)
			If Enabled Then
				Focus()
			End If
		End Sub
		#End Region

		#Region "Puzzle State"
		''' <summary>Gets or sets the current puzzle state.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Public Property State() As PuzzleState
			Get
				If _state Is Nothing Then
					_state = New PuzzleState()
					OnStateChanged()
				End If
				Return _state
			End Get
			Set(ByVal value As PuzzleState)
				If value Is Nothing Then
					value = New PuzzleState()
				End If
				If value IsNot _state Then
                    Dim oldState = _state
					If oldState IsNot Nothing Then
						RemoveHandler oldState.StateChanged, AddressOf HandlePuzzleStateChanged
						oldState.RaiseStateChangedEvent = False
					End If

					_state = value
					_state.RaiseStateChangedEvent = True
					AddHandler _state.StateChanged, AddressOf HandlePuzzleStateChanged
					OnStateChanged()
					Invalidate()
				End If
			End Set
		End Property

		''' <summary>Gets or sets the original state of the puzzle.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Friend Property OriginalState() As PuzzleState
			Get
				Return _originalState
			End Get
			Set(ByVal value As PuzzleState)
				SetOriginalPuzzleCheckpoint(value)
			End Set
		End Property

		''' <summary>Gets the collection of undo states.</summary>
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Friend Property UndoStates() As Stack(Of PuzzleState)
			Get
				Return _undoStates
			End Get
			Set(ByVal value As Stack(Of PuzzleState))
				If value Is Nothing Then
					Throw New ArgumentNullException("value")
				End If
				_undoStates = value
			End Set
		End Property

		''' <summary>Event raised when the grid's puzzle state is modified.</summary>
		Public Event StateChanged As EventHandler

		''' <summary>Raises the StateChanged event on the main UI thread.</summary>
		Private Sub OnStateChanged()
			_suggestedCell = Nothing
            Dim handler = StateChangedEvent
			If handler IsNot Nothing Then
				If InvokeRequired Then
					Invoke(handler, New Object() { Me, EventArgs.Empty })
				Else
					handler(Me, EventArgs.Empty)
				End If
			End If
		End Sub

		''' <summary>Raises the StateChanged event in response to the puzzle state's StateChanged event.</summary>
		''' <param name="sender">The modified puzzle state.</param>
		''' <param name="e">The event args.</param>
		Private Sub HandlePuzzleStateChanged(ByVal sender As Object, ByVal e As EventArgs)
			OnStateChanged()
		End Sub

		''' <summary>Gets whether the specified cell can be modified based on the original state checkpoint.</summary>
		''' <param name="cell">The cell to be verified.</param>
		''' <returns>true if the cell can be modified; otherwise, false.</returns>
		Private Function CanModifyCell(ByVal cell As Point) As Boolean
            Return (cell.X >= 0 AndAlso cell.X < State.GridSize AndAlso cell.Y >= 0 AndAlso cell.Y < State.GridSize) AndAlso
                (_originalState Is Nothing OrElse (Not _originalState(cell).HasValue))
		End Function

		''' <summary>Gets whether the specified cell can be cleared.</summary>
		''' <param name="cell">The cell to test.</param>
		''' <returns>Whether the cell can be cleared (it can be modified and it has a value).</returns>
		Private Function CanClearCell(ByVal cell As Point) As Boolean
			Return CanModifyCell(cell) AndAlso State(cell).HasValue
		End Function

		''' <summary>Gets the grid cell containing the specified point in the control.</summary>
		''' <param name="point">The point, typically a mouse location, for which to find the grid cell.</param>
		''' <returns>The location of the grid cell corresponding to the specified point.</returns>
		Public Function GetCellFromLocation(ByVal point As Point) As Point
			If point.X < 0 OrElse point.Y < 0 Then
				Return New Point(-1,-1)
			End If

            Dim rect = BoardRectangle
			If rect.Width <= 0 OrElse rect.Height <= 0 Then
				Return New Point(-1, -1)
			End If

            Dim cellWidth = rect.Width / CSng(_boardWidth) * (_cellImageWidth + 1)
            Dim gapWidth = rect.Width / CSng(_boardWidth) * (_gapImageWidth - 1)

            Dim x = 0, y = 0

            Dim pos = point.Y - rect.X
			Do While pos >= cellWidth

                pos = CInt(pos - cellWidth)
				x += 1
				If x Mod _boxSize = 0 Then

                    pos = CInt(pos - gapWidth)
				End If
			Loop

			pos = point.X - rect.Y
			Do While pos >= cellWidth

                pos = CInt(pos - cellWidth)
				y += 1
				If y Mod _boxSize = 0 Then

                    pos = CInt(pos - gapWidth)
				End If
			Loop

			Return New Point(x,y)
		End Function
		#End Region

		#Region "Hints"
		''' <summary>Gets or sets whether to highlight cells that can only be a specific number.</summary>
		Public Property ShowSuggestedCells() As Boolean
			Get
				Return _showSuggestedCells
			End Get
			Set(ByVal value As Boolean)
				If value <> _showSuggestedCells Then
					_showSuggestedCells = value
					Invalidate()
				End If
			End Set
		End Property

		''' <summary>Gets or sets whether to display the possible numbers in each cell.</summary>
		Public Property ShowIncorrectNumbers() As Boolean
			Get
				Return _showIncorrectNumbers
			End Get
			Set(ByVal value As Boolean)
				If value <> _showIncorrectNumbers Then
					_showIncorrectNumbers = value
					Invalidate()
				End If
			End Set
		End Property
		#End Region

		#Region "Puzzle Interaction"
		''' <summary>Gets whether the puzzle has been modified.</summary>
		Public ReadOnly Property PuzzleHasBeenModified() As Boolean
			Get
                Dim status = State.Status
				Return status <> PuzzleStatus.Solved AndAlso OriginalState IsNot Nothing AndAlso Not State.Equals(OriginalState)
			End Get
		End Property

		''' <summary>Generates a new puzzle and sets it to be the current puzzle in the grid.</summary>
		''' <param name="options">Options to use for the puzzle generation.</param>
		''' <remarks>Resets the undo states for the grid.</remarks>
		Public Sub GenerateNewPuzzle(ByVal options As GeneratorOptions)
			LoadNewPuzzle(_puzzleGenerator.Generate(options))
		End Sub

		''' <summary>Gets or sets the puzzle difficulty level used for showing hints.</summary>
		Public Property PossibleNumbersDifficultyLevel() As PuzzleDifficulty
			Get
				Return _difficultyLevel
			End Get
			Set(ByVal value As PuzzleDifficulty)
				If Not System.Enum.IsDefined(GetType(PuzzleDifficulty), value) Then
					Throw New ArgumentOutOfRangeException("value")
				End If
				If _difficultyLevel <> value Then
					_difficultyLevel = value
					_suggestedCell = Nothing
					Invalidate()
				End If
			End Set
		End Property

		''' <summary>Loads a new puzzle and sets it to be the current puzzle in the grid.</summary>
		''' <param name="state">The puzzle to load.</param>
		Public Sub LoadNewPuzzle(ByVal state As PuzzleState)
			ClearUndoCheckpoints()
			ClearOriginalPuzzleCheckpoint()
			SetOriginalPuzzleCheckpoint(state.Clone())
			Me.State = state
			_selectedCell = FirstEmptyCell
		End Sub

		''' <summary>Restores a puzzle based on the state from a serialized game.</summary>
		''' <param name="state">The current puzzle state.</param>
		''' <param name="originalState">The original puzzle state.</param>
		''' <param name="undoStates">The undo state stack.</param>
        Public Sub RestorePuzzle(ByVal state As PuzzleState, ByVal originalState As PuzzleState, ByVal undoStates As Stack(Of PuzzleState))
            Me.OriginalState = originalState
            Me.UndoStates = undoStates
            Me.State = state
            _selectedCell = FirstEmptyCell
        End Sub

		''' <summary>Gets the position of the first empty cell in the puzzle, or the [0,0] cell if none are empty.</summary>
		Private ReadOnly Property FirstEmptyCell() As Point
			Get
                Dim state = Me.State
				If state Is Nothing Then
					Return New Point(0,0)
				End If
                For i = 0 To state.GridSize - 1
                    For j = 0 To state.GridSize - 1
                        Dim p As New Point(i, j)
                        If Not state(p).HasValue Then
                            Return p
                        End If
                    Next j
                Next i
				Return New Point(0,0)
			End Get
		End Property

		''' <summary>Creates a checkpoint used to determine where cells are invalid in the puzzle.</summary>
		Public Sub SetOriginalPuzzleCheckpoint(ByVal original As PuzzleState)
			_originalState = original
			If original IsNot Nothing Then
				Dim options As New SolverOptions()
				options.MaximumSolutionsToFind = 2
                Dim results = Solver.Solve(original, options)
				If results.Status = PuzzleStatus.Solved AndAlso results.Puzzles.Count = 1 Then
					_solvedOriginalState = results.Puzzle
				Else
					_solvedOriginalState = Nothing
				End If
			End If
		End Sub

		''' <summary>Clears the original puzzle checkpoint.</summary>
		Public Sub ClearOriginalPuzzleCheckpoint()
			_originalState = Nothing
			_solvedOriginalState = Nothing
		End Sub

		''' <summary>Clears the undo puzzle checkpoints.</summary>
		Public Sub ClearUndoCheckpoints()
			_undoStates.Clear()
		End Sub

		''' <summary>Creates an undo checkpoint such that the current grid state can be reached through the undo mechanism.</summary>
		Public Sub SetUndoCheckpoint()
			If State IsNot Nothing Then
				_undoStates.Push(State.Clone())
			End If
		End Sub

		''' <summary>Reverts to a previously saved state.</summary>
		Public Sub Undo()
			If _undoStates.Count > 0 Then
				State = _undoStates.Pop()
				OnStateChanged()
				Invalidate()
			End If
		End Sub

		''' <summary>Attempts to solve the current puzzle, update the state in the grid, and return the results.</summary>
		''' <returns>The results from attempting to solve the puzzle.</returns>
		Private Function SolvePuzzle() As SolverResults
			' If it's already solved, nothing to do
			If State.Status = PuzzleStatus.Solved Then
				Return New SolverResults(PuzzleStatus.Solved, State, 0, Nothing)
			End If

			' Otherwise, try to solve it.
			Dim options As New SolverOptions()
			options.MaximumSolutionsToFind = 1UI ' this means that if there are multiple solutions, we'll find and use the first
			options.AllowBruteForce = True
			options.EliminationTechniques = New List(Of EliminationTechnique) From {New NakedSingleTechnique()}

            Dim results = Solver.Solve(State, options)
			If results.Status = PuzzleStatus.Solved AndAlso results.Puzzles.Count = 1 Then
				SetUndoCheckpoint()
				State = results.Puzzle
			End If
			Return results
		End Function
		#End Region

		#Region "Drawing"
		''' <summary>The width/height of a box.  This would need to become variable if differently sized puzzles were supported.</summary>
        Private Const _boxSize As Integer = 3
		''' <summary>The width of the underlying board image.</summary>
		Private Const _boardWidth As Integer = 518
		''' <summary>The height of the underlying board image.</summary>
		Private Const _boardHeight As Integer = 518
		''' <summary>The width of a cell in the underlying board image.</summary>
		Private Const _cellImageWidth As Integer = 54
		''' <summary>The height of a cell in the underlying board image.</summary>
		Private Const _cellImageHeight As Integer = 54
		''' <summary>The width of a the gap between cells in the underlying board image.</summary>
		Private Const _cellGapWidth As Integer = 1
		''' <summary>The height of a the gap between cells in the underlying board image.</summary>
		Private Const _cellGapHeight As Integer = 1
		''' <summary>The width of a the gap between boxes in the underlying board image.</summary>
		Private Const _gapImageWidth As Integer = 13
		''' <summary>The height of a the gap between boxes in the underlying board image.</summary>
		Private Const _gapImageHeight As Integer = 13

		''' <summary>Gets the bounding rectangle for a specific cell.</summary>
		''' <param name="rect">The client rectange.</param>
		''' <param name="cell">The target cell.</param>
		''' <returns>The bounding rectangle.</returns>
		Public Shared Function GetCellRectangle(ByVal rect As Rectangle, ByVal cell As Point) As RectangleF
            Dim width = (_cellImageWidth + _cellGapWidth) / CSng(_boardWidth) * rect.Width
            Dim height = (_cellImageHeight + _cellGapHeight) / CSng(_boardHeight) * rect.Height
            Dim cellRect As New RectangleF(rect.X + (cell.Y * width) + ((cell.Y \ _boxSize) * ((_gapImageWidth - 1) /
                        CSng(_boardWidth) * rect.Width)), rect.Y + (cell.X * height) + ((cell.X \ _boxSize) *
                        ((_gapImageHeight - 1) / CSng(_boardHeight) * rect.Height)), _cellImageWidth / CSng(_boardWidth) *
                        rect.Width, _cellImageHeight / CSng(_boardHeight) * rect.Height)
			Return cellRect
		End Function

		''' <summary><para>Raises the Paint event.</para></summary>
		''' <param name="e">A PaintEventArgs that contains the event data.</param>
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			MyBase.OnPaint(e)
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality
			DrawToGraphics(e.Graphics, e.ClipRectangle)
		End Sub

		''' <summary>Brush used to draw text and other objects with the font color.</summary>
		Private _userValueBrush As Brush
		''' <summary>Brush used to draw incorrect values on the grid.</summary>
		Private _incorrectValueBrush As Brush
		''' <summary>Brush used to draw text and other objects with a variation of the font color.</summary>
		Private _originalValueBrush As Brush
		''' <summary>StringFormat used to center text within a rectangle.</summary>
		Private _centerNumberFormat As StringFormat

		''' <summary>The location of the cell to suggest as a "try this one next" hint.</summary>
		Private _suggestedCell? As Point = Nothing

		''' <summary>Gets the location of the cell to suggest as a "try this one next" hint.</summary>
		Private ReadOnly Property SuggestedCell() As Point?
			Get
				If _suggestedCell Is Nothing Then
					' First, see if any cells are the only one left to be filled in their
					' row, column, or box.  Regardless of techniques in use, only one
					' cell without a value in a row, column, or box really must be the easiest.
                    Dim foundEmpty? As Point = Nothing

                    For row = 0 To State.GridSize - CType(1, Byte)
                        For col = 0 To State.GridSize - CType(1, Byte)
                            If Not State(row, col).HasValue Then
                                If Not foundEmpty.HasValue Then
                                    foundEmpty = New Point(row, col)
                                Else
                                    foundEmpty = Nothing
                                    Exit For
                                End If
                            End If
                        Next col


                        If foundEmpty.HasValue Then
                            _suggestedCell = foundEmpty
                            Return _suggestedCell
                        End If
                    Next row
					foundEmpty = Nothing
                    For col = 0 To State.GridSize - CType(1, Byte)
                        For row = 0 To State.GridSize - CType(1, Byte)
                            If Not State(row, col).HasValue Then
                                If Not foundEmpty.HasValue Then
                                    foundEmpty = New Point(row, col)
                                Else
                                    foundEmpty = Nothing
                                    Exit For
                                End If
                            End If
                        Next row
                        If foundEmpty.HasValue Then
                            _suggestedCell = foundEmpty
                            Return _suggestedCell
                        End If
                    Next col
					foundEmpty = Nothing
                    For gridNum = 0 To State.GridSize - CType(1, Byte)
                        Dim gridX = CByte(gridNum Mod State.BoxSize)
                        Dim gridY = CByte(gridNum \ State.BoxSize)
                        Dim startX = CByte(gridX * State.BoxSize)
                        Dim startY = CByte(gridY * State.BoxSize)
                        Dim done = False
                        Dim x = startX
                        Do While x < startX + State.BoxSize AndAlso Not done
                            Dim y = startY
                            Do While y < startY + State.BoxSize AndAlso Not done
                                If Not State(x, y).HasValue Then
                                    If Not foundEmpty.HasValue Then
                                        foundEmpty = New Point(x, y)
                                    Else
                                        foundEmpty = Nothing
                                        done = True
                                    End If
                                End If
                                y += CType(1, Byte)
                            Loop
                            x += CType(1, Byte)
                        Loop
                        If foundEmpty.HasValue Then
                            _suggestedCell = foundEmpty
                            Return _suggestedCell
                        End If
                    Next gridNum

					' If one could not be found doing that, move on to techniques
					Dim tc As New List(Of EliminationTechnique)()
					Dim possibleNumbers()() As FastBitArray = PuzzleState.InstantiatePossibleNumbersArray(State)
                    For Each et In EliminationTechnique.AvailableTechniques
                        tc.Add(et)
                        Dim ignored As Dictionary(Of EliminationTechnique, Integer) = Nothing
                        State.ComputePossibleNumbers(tc, ignored, True, True, possibleNumbers)
                        For row = 0 To State.GridSize - 1
                            For column As Integer = 0 To State.GridSize - 1
                                If possibleNumbers(row)(column).CountSet = 1 Then
                                    _suggestedCell = New Point(row, column)
                                    Return _suggestedCell
                                End If
                            Next column
                        Next row
                    Next et

					' If nothing with only one possible value could be found by using techniques,
					' find the cell with the fewest possible numbers and suggest it.
					If possibleNumbers IsNot Nothing Then
                        Dim bestCount = State.GridSize
                        For row = 0 To State.GridSize - 1
                            For column = 0 To State.GridSize - 1
                                Dim cell As New Point(row, column)
                                If Not State(cell).HasValue Then
                                    Dim numSet As Integer = possibleNumbers(row)(column).CountSet
                                    If numSet < bestCount Then
                                        _suggestedCell = cell
                                        bestCount = CByte(numSet)
                                    End If
                                End If
                            Next column
                        Next row
					End If

					' If there is none, just make it an invalid point
					If _suggestedCell Is Nothing Then
						_suggestedCell = New Point(-1,-1)
					End If
				End If
				Return _suggestedCell
			End Get
		End Property

		''' <summary>Gets the current rectangle for the playing board.</summary>
		Public ReadOnly Property BoardRectangle() As Rectangle
			Get
                Dim rect = ClientRectangle
                Dim amount = rect.Width \ 51
				If amount < 2 Then
					amount = 2
				End If
				rect.Inflate(-amount, -amount)
				Return rect
			End Get
		End Property

		''' <summary>The font size, in points, for numbers on the grid.</summary>
        Private _cachedEmSize As Single = -1

		''' <summary>Clears the cached font size when the font is changed.</summary>
		Protected Overrides Sub OnFontChanged(ByVal e As EventArgs)
			_cachedEmSize = -1
			MyBase.OnFontChanged (e)
		End Sub

		''' <summary>Draws the playing grid onto the specified graphics object and within the specified bounding rectangle.</summary>
		''' <param name="graphics">The graphics object onto</param>
		Public Sub DrawToGraphics(ByVal graphics As Graphics, ByVal clipRectangle As Rectangle)
			If graphics Is Nothing Then
				Throw New ArgumentNullException("graphics")
			End If
            Dim rect = BoardRectangle

			' Draw the underlying board images
            graphics.DrawImage(ResourceHelper.BoardBackgroundImage, 0, 0, Width, Height)
			graphics.DrawImage(ResourceHelper.BoardImage, rect)

			' Precompute some important sizes, such as the width and height of
			' a cell in the grid, positioning information for drawing possible numbers,
			' and the em size to use for drawing text.
            Dim genericCellRect = GetCellRectangle(rect, New Point(0, 0))
            Dim cellWidth = genericCellRect.Width
            Dim cellHeight = genericCellRect.Height

			' Get the em size for the current font based on the current board size.
			' This is cached, and the cache is only cleared when the board is resized or when the font is changed.
			Dim emSize As Single
			If _cachedEmSize < 0 Then
                _cachedEmSize = GraphicsHelpers.GetMaximumEMSize(ResourceHelper.FontSizingString, graphics, Me.Font.FontFamily,
                                                                 FontStyle.Bold, cellWidth, cellHeight)
			End If
			emSize = _cachedEmSize

            Dim showSuggestedCells = Me.ShowSuggestedCells

			' Draw cell images
			Using setNumberFont As New Font(Me.Font.FontFamily, emSize, FontStyle.Bold)
                For i = 0 To State.GridSize - 1
                    For j = 0 To State.GridSize - 1
                        Dim cellRect = GetCellRectangle(rect, New Point(i, j))
                        If clipRectangle.IntersectsWith(Rectangle.Ceiling(cellRect)) Then
                            If State.Status <> PuzzleStatus.Solved Then
                                If _selectedCell.HasValue AndAlso _selectedCell.Value.X = i AndAlso _selectedCell.Value.Y = j Then
                                    Dim selectedCellImage As Image
                                    If i = 0 AndAlso j = 0 Then
                                        selectedCellImage = ResourceHelper.CellActiveUpperLeft
                                    ElseIf i = 0 AndAlso j = State.GridSize - 1 Then
                                        selectedCellImage = ResourceHelper.CellActiveUpperRight
                                    ElseIf i = State.GridSize - 1 AndAlso j = 0 Then
                                        selectedCellImage = ResourceHelper.CellActiveLowerLeft
                                    ElseIf i = State.GridSize - 1 AndAlso j = State.GridSize - 1 Then
                                        selectedCellImage = ResourceHelper.CellActiveLowerRight
                                    Else
                                        selectedCellImage = ResourceHelper.CellActiveSquare
                                    End If
                                    graphics.DrawImage(selectedCellImage, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height)
                                ElseIf showSuggestedCells AndAlso SuggestedCell.HasValue AndAlso SuggestedCell.Value.X = i AndAlso
                                    SuggestedCell.Value.Y = j Then
                                    Dim suggestedCellImage As Image
                                    If i = 0 AndAlso j = 0 Then
                                        suggestedCellImage = ResourceHelper.CellHintUpperLeft
                                    ElseIf i = 0 AndAlso j = State.GridSize - 1 Then
                                        suggestedCellImage = ResourceHelper.CellHintUpperRight
                                    ElseIf i = State.GridSize - 1 AndAlso j = 0 Then
                                        suggestedCellImage = ResourceHelper.CellHintLowerLeft
                                    ElseIf i = State.GridSize - 1 AndAlso j = State.GridSize - 1 Then
                                        suggestedCellImage = ResourceHelper.CellHintLowerRight
                                    Else
                                        suggestedCellImage = ResourceHelper.CellHintSquare
                                    End If
                                    graphics.DrawImage(suggestedCellImage, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height)
                                End If
                            End If

                            ' If a cell has a value, then draw that value
                            If State(i, j).HasValue Then
                                Dim b As Brush
                                If ShowIncorrectNumbers AndAlso State(i, j).HasValue AndAlso _solvedOriginalState IsNot Nothing AndAlso
                                    State(i, j).Value <> _solvedOriginalState(i, j).Value Then
                                    b = _incorrectValueBrush
                                ElseIf _originalState IsNot Nothing AndAlso _originalState(i, j).HasValue Then
                                    b = _originalValueBrush
                                Else
                                    b = _userValueBrush
                                End If

                                graphics.DrawString((State(i, j) + 1).Value.ToString(CultureInfo.InvariantCulture), setNumberFont, b,
                                                    cellRect, _centerNumberFormat)
                            End If
                        End If
                    Next j
                Next i
			End Using
		End Sub

		#End Region

		#Region "Keyboard and Mouse Interaction"
		''' <summary>Determines whether the specified key is a regular input key or a special key that requires processing.</summary>
		''' <param name="keyData">A Keys value.</param>
		''' <returns>Whether the specified Keys should be treated as an input key.</returns>
		Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
			' We want to allow the control to handle up, down, left, right, so that
			' the user can move around the selected cell marker with the arrow keys
			Select Case keyData
				Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
					Return True
			End Select
			Return MyBase.IsInputKey(keyData)
		End Function

		''' <summary>Handles the KeyDown event.</summary>
		''' <param name="e">Event args</param>
		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            Dim k = e.KeyCode
            Dim handled = True
            Dim invalidateFlag = True

            Dim selectedCell = _selectedCell.Value

			' Alt+Shift+2, in homage to Windows Solitaire :-)
			If k = Keys.D2 AndAlso e.Shift AndAlso e.Alt Then
				SolvePuzzle()
			' Digits are treated as numbers and stored into the grid
			ElseIf (k >= Keys.D1 AndAlso k <= Keys.D9) OrElse (k >= Keys.NumPad1 And k <= Keys.NumPad9) Then
				If State IsNot Nothing AndAlso CanModifyCell(selectedCell) Then
					SetStateCell(selectedCell,If((k >= Keys.NumPad1 AndAlso k <= Keys.NumPad9), CByte(k - Keys.NumPad1), CByte(k - Keys.D1)))
				End If
			' Delete, space, and a variety of other keys are used to clear out the contents of a grid cell
			ElseIf k = Keys.Delete OrElse k = Keys.Space OrElse k = Keys.Back Then
				If State IsNot Nothing AndAlso CanClearCell(selectedCell) Then
					ClearStateCellWithInvalidation(selectedCell)
                    invalidateFlag = False
				End If
			' And the arrow keys are used to move around the grid
			ElseIf k = Keys.Down AndAlso selectedCell.X + 1 < State.GridSize Then
				InvalidateCell(selectedCell)
				selectedCell.X += 1
				InvalidateCell(selectedCell)
                invalidateFlag = False
			ElseIf k = Keys.Up AndAlso selectedCell.X - 1 >= 0 Then
				InvalidateCell(selectedCell)
				selectedCell.X -= 1
				InvalidateCell(selectedCell)
                invalidateFlag = False
			ElseIf k = Keys.Right AndAlso selectedCell.Y + 1 < State.GridSize Then
				InvalidateCell(selectedCell)
				selectedCell.Y += 1
				InvalidateCell(selectedCell)
                invalidateFlag = False
			ElseIf k = Keys.Left AndAlso selectedCell.Y - 1 >= 0 Then
				InvalidateCell(selectedCell)
				selectedCell.Y -= 1
				InvalidateCell(selectedCell)
                invalidateFlag = False
			' Otherwise, not handled
			Else
				handled = False
			End If

			' If it was handled, update the necessary state
			If handled Then
				_selectedCell = selectedCell
				e.Handled = True
                If invalidateFlag Then
                    Invalidate()
                End If
			End If

			If Not e.Handled Then
				MyBase.OnKeyDown(e)
			End If
		End Sub

		''' <summary>Update the selected cell when the mouse is clicked down.</summary>
		''' <param name="e">The mouse event args.</param>
		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.OnMouseDown(e)
            Dim cell = GetCellFromLocation(New Point(e.X, e.Y))
			If _selectedCell.HasValue Then
				InvalidateCell(_selectedCell.Value)
			End If
			SetSelectedCell(cell)
			InvalidateCell(cell)
		End Sub

		''' <summary>Sets the selected cell to the specified cell, if it's valid.</summary>
		''' <param name="cell">The cell to be selected.</param>
		Private Sub SetSelectedCell(ByVal cell As Point)
			If cell.X >= 0 AndAlso cell.X < State.GridSize AndAlso cell.Y >= 0 AndAlso cell.Y < State.GridSize AndAlso _selectedCell <> cell Then
				_selectedCell = cell
			End If
		End Sub
		#End Region

		''' <summary>Resizes the control.</summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnResize(ByVal e As EventArgs)
			_cachedEmSize = -1
			MyBase.OnResize(e)
		End Sub

		''' <summary>Sets the contents of a cell in the current puzzle.</summary>
		''' <param name="cell">The cell to be set.</param>
		''' <param name="number">The value to which the cell should be set.</param>
		''' <remarks>Sets an undo checkpoint and deletes any scratchpad strokes for the specified cell.</remarks>
		Private Sub SetStateCell(ByVal cell As Point, ByVal number As Byte)
            If Not State(cell).Equals(number) Then
                SetUndoCheckpoint()
                State(cell) = number
            End If
		End Sub

		''' <summary>Clears the contents of a cell in the current puzzle.</summary>
		''' <param name="cell">The cell to be cleared.</param>
		''' <remarks>Sets an undo checkpoint.</remarks>
		Private Sub ClearStateCell(ByVal cell As Point)
			If State(cell).HasValue Then
				SetUndoCheckpoint()
				State(cell) = Nothing
			End If
		End Sub

		''' <summary>Invalidates the specified cell.</summary>
		''' <param name="cell">The cell to be repainted.</param>
		Private Sub InvalidateCell(ByVal cell As Point)
			If cell.X >= 0 AndAlso cell.X < State.GridSize AndAlso cell.Y >= 0 AndAlso cell.Y < State.GridSize Then
                Const BUFFER_DIST = 2
                Dim rect = GetCellRectangle(BoardRectangle, cell)
				rect.Inflate(BUFFER_DIST,BUFFER_DIST)
				Invalidate(Rectangle.Ceiling(rect))
			End If
		End Sub

		''' <summary>Clears a cell and invalidates it.</summary>
		''' <param name="cell">The cell to be cleared and repainted.</param>
		Private Sub ClearStateCellWithInvalidation(ByVal cell As Point)
            Dim showSuggestedCells = Me.ShowSuggestedCells
			If showSuggestedCells Then
				InvalidateCell(SuggestedCell.Value)
			End If
			ClearStateCell(cell)
			InvalidateCell(cell)
			If showSuggestedCells Then
				InvalidateCell(SuggestedCell.Value)
			End If
		End Sub
	End Class
End Namespace