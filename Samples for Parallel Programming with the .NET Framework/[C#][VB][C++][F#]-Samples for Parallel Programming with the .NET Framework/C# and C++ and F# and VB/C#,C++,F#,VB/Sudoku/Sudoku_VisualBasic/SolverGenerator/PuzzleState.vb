'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PuzzleState.vb
'
'  Description: Stores the current configuration of a puzzle.
' 
'--------------------------------------------------------------------------

Imports System.Collections
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections
Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Maintains the state for a particular instance of a Sudoku puzzle.</summary>
	<Serializable>
	Public NotInheritable Class PuzzleState
		Implements ICloneable, IEnumerable
		''' <summary>Maximum size of a puzzle state box.</summary>
		Private Const _defaultBoxSize As Byte = 3
		''' <summary>The size of each box in the puzzle.</summary>
		Private ReadOnly _boxSize As Byte
		''' <summary>The size of the entire puzzle.</summary>
		Private ReadOnly _gridSize As Byte
		''' <summary>The state of each cell in the puzzle.</summary>
		Private _grid?(,) As Byte
		''' <summary>Known difficulty level of the puzzle.</summary>
		Private _difficulty As PuzzleDifficulty
		''' <summary>The number of cells currently filled in the puzzle.</summary>
		<NonSerialized>
		Private _filledCells? As Integer
		''' <summary>The puzzle's current status.  Invalidated every time the puzzle is changed.</summary>
		<NonSerialized>
		Private _status As PuzzleStatus
		''' <summary>Event raised when a cell in the grid changes its contained value.</summary>
		<NonSerialized>
		Private _stateChanged As EventHandler
		''' <summary>Whether to raise state changed events.</summary>
		<NonSerialized>
		Private _raiseStateChangedEvent As Boolean

		''' <summary>Initializes the PuzzleState.</summary>
		Public Sub New()
			_boxSize = _defaultBoxSize
			_gridSize = CByte(_boxSize * _boxSize)
            _grid = New Byte?(_gridSize + 1, _gridSize + 1) {}
		End Sub

		''' <summary>Initializes the PuzzleState.</summary>
		''' <param name="state">The state to be cloned into this new instance.</param>
		Private Sub New(ByVal state As PuzzleState)
			' We don't use MemberwiseClone here as the new state should not share references
			_boxSize = state._boxSize ' immutable once created
			_gridSize = state._gridSize ' immutable once created
			_grid = CType(state._grid.Clone(), Byte?(,))
			_status = state._status ' immutable once created
			_filledCells = state._filledCells ' immutable once created
			_difficulty = state._difficulty ' immutable once created
		End Sub

		''' <summary>Gets the size of a box in the puzzle (the sqrt of the grid size).</summary>
		Public ReadOnly Property BoxSize() As Byte
			Get
				Return _boxSize
			End Get
		End Property

		''' <summary>Gets the size of the puzzle grid.</summary>
		Public ReadOnly Property GridSize() As Byte
			Get
				Return _gridSize
			End Get
		End Property

		''' <summary>Gets or sets the perceived difficulty level of this puzzle.</summary>
		Public Property Difficulty() As PuzzleDifficulty
			Get
				Return _difficulty
			End Get
			Set(ByVal value As PuzzleDifficulty)
				_difficulty = value
			End Set
		End Property

		''' <summary>Gets or sets the cell value.</summary>
		''' <param name="cell">The coordinates of the cell whose value is to be set or retrieved.</param>
		''' <returns>The value of the specified cell, or null if it has no value.</returns>
		Default Public Property Item(ByVal cell As Point) As Byte?
			Get
               
                Return _grid(cell.X, cell.Y)

			End Get
			Set(ByVal value? As Byte)
                Dim oldValue? = _grid(cell.X, cell.Y)

                If Not oldValue.Equals(value) Then
                    _status = PuzzleStatus.Unknown
                    _filledCells = Nothing

                    _grid(cell.X, cell.Y) = value
                    OnStateChanged() 'cell, oldValue, value);
                End If
			End Set
		End Property

		''' <summary>Gets or sets the cell value.</summary>
		''' <param name="cellX">The x-coordinate of the cell whose value is to be set or retrieved.</param>
		''' <param name="cellY">The y-coordinate of the cell whose value is to be set or retrieved.</param>
		''' <returns>The value of the specified cell, or null if it has no value.</returns>
		Default Public Property Item(ByVal cellX As Integer, ByVal cellY As Integer) As Byte?
			Get
				Return _grid(cellX, cellY)
			End Get
			Set(ByVal value? As Byte)
				Me(New Point(cellX, cellY)) = value
			End Set
		End Property

		''' <summary>Event raised when a cell in the grid changes its contained value.</summary>
		Public Custom Event StateChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler(ByVal value As EventHandler)
				_stateChanged = CType(System.Delegate.Combine(_stateChanged, value), EventHandler)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler(ByVal value As EventHandler)
				_stateChanged = CType(System.Delegate.Remove(_stateChanged, value), EventHandler)
			End RemoveHandler
			RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
			End RaiseEvent
		End Event

		''' <summary>Gets or sets whether to raise state changed events.</summary>
		Public Property RaiseStateChangedEvent() As Boolean
			Get
				Return _raiseStateChangedEvent
			End Get
			Set(ByVal value As Boolean)
				_raiseStateChangedEvent = value
			End Set
		End Property

		''' <summary>Raises the state changed event if RaiseStateChangedEvent is true.</summary>
		Private Sub OnStateChanged()
			If _raiseStateChangedEvent Then
                Dim handler = _stateChanged
				If handler IsNot Nothing Then
					handler(Me, EventArgs.Empty)
				End If
			End If
		End Sub

		''' <summary>Gets the puzzle's current status.</summary>
		Public ReadOnly Property Status() As PuzzleStatus
			Get
				If _status = PuzzleStatus.Unknown Then
					_status = AnalyzeSolutionStatus()
				End If
				Return _status
			End Get
		End Property

		''' <summary>Gets the number of filled cells in the grid.</summary>
		Public ReadOnly Property NumberOfFilledCells() As Integer
			Get
				If Not _filledCells.HasValue Then
                    Dim count = 0
					For Each cell? As Byte In _grid
						If cell.HasValue Then
							count += 1
						End If
					Next cell
					_filledCells = count
				End If
				Return _filledCells.Value
			End Get
		End Property

		''' <summary>Gets an enumerator for all of the cells in the grid.</summary>
		''' <returns>An enumerator for all of the cells in the grid.</returns>
		Private Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
			Return _grid.GetEnumerator()
		End Function

		''' <summary>Deep clones this PuzzleState.</summary>
		''' <returns>A deep clone of this PuzzleState.</returns>
		Public Function Clone() As PuzzleState
			Return New PuzzleState(Me)
		End Function

		''' <summary>Deep clones this PuzzleState.</summary>
		''' <returns>A deep clone of this PuzzleState.</returns>
		Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
			Return Clone()
		End Function

		''' <summary>Determines whether this state and the specified state represent the same filled in cells.</summary>
		''' <param name="obj">The other state to which to compare this state.</param>
		''' <returns>true if the states are equal; false, otherwise.</returns>
		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
            Dim other = TryCast(obj, PuzzleState)
			Return If((other IsNot Nothing), StatesMatch(Me, other), MyBase.Equals(obj))
		End Function

		''' <summary>Returns the hash code for this instance.</summary>
		''' <returns>The hash code for this instance.</returns>
		Public Overrides Function GetHashCode() As Integer
			Return ToString().GetHashCode()
		End Function

		''' <summary>Creates a string representation of this puzzle state.</summary>
		''' <returns>A string representation of this puzzle state.</returns>
		Public Overrides Function ToString() As String
			Dim sb As New StringBuilder(GridSize*(GridSize+2))
            For i = 0 To GridSize - 1
                For j = 0 To GridSize - 1
                    Dim cell As New Point(i, j)
                    sb.Append(If(Me(cell).HasValue, Me(cell).Value & 1, "."))
                Next j
                sb.Append(Environment.NewLine)
            Next i
			Return sb.ToString()
		End Function

		''' <summary>Compares two puzzle states to determine if they're equal.</summary>
		''' <param name="first">The first puzzle state.</param>
		''' <param name="second">The second puzzle state.</param>
		''' <returns>true if the states are equal; otherwise, false.</returns>
		Private Shared Function StatesMatch(ByVal first As PuzzleState, ByVal second As PuzzleState) As Boolean
			If first Is Nothing Then
				Throw New ArgumentNullException("first")
			End If
			If second Is Nothing Then
				Throw New ArgumentNullException("second")
			End If

			' They're equal only if the corresponding cells both contain the
			' same number or are both empty.
			If first.GridSize <> second.GridSize Then
				Return False
			End If
            For i = 0 To first.GridSize - 1
                For j = 0 To second.GridSize - 1
                    If first(i, j) <> second(i, j) Then
                        Return False
                    End If
                Next j
            Next i
			Return True
		End Function

        Public Shared Function InstantiatePossibleNumbersArray(ByVal state As PuzzleState) As FastBitArray()()
            Dim possibleNumbers(state.GridSize - 1)() As FastBitArray
            For i = 0 To possibleNumbers.Length - 1
                possibleNumbers(i) = New FastBitArray(state.GridSize - 1) {}
            Next i
            For i = 0 To state.GridSize - 1
                For j = 0 To state.GridSize - 1
                    possibleNumbers(i)(j) = New FastBitArray(state.GridSize)
                Next j
            Next i
            Return possibleNumbers
        End Function

		''' <summary>Determines what numbers are possible in each of the cells in the state.</summary>
		''' <param name="state">The puzzle state to analyze.</param>
		''' <param name="techniques">The techniques to use for this elimination process.</param>
		''' <param name="onlyOnePass">
		''' Whether only one pass should be made through each technique, or whether it should repeat all techniques
		''' as long as any technique made any changes.
		''' </param>
		''' <param name="usesOfTechnique">How much each of the techniques was used.</param>
		''' <param name="possibleNumbers">The possible numbers used for this computation.</param>
		''' <returns>The computed possible numbers.</returns>
        Public Function ComputePossibleNumbers(ByVal techniques As List(Of EliminationTechnique), ByRef usesOfTechnique As Dictionary(Of EliminationTechnique, Integer),
            ByVal onlyOnePass As Boolean, ByVal earlyExitWhenSoleFound As Boolean, ByVal possibleNumbers()() As FastBitArray) As FastBitArray()()
            ' Initialize the possible numbers grid
            For i = 0 To GridSize - 1
                For j = 0 To GridSize - 1
                    possibleNumbers(i)(j).SetAll(If(Me(i, j).HasValue, False, True))
                Next j
            Next i

            ' Perform eliminations based on the techniques available to this puzzle state.
            ' The techniques available depend on the difficulty level of the puzzle.
            Dim notDone As Boolean
            Do
                notDone = False
                For Each e In techniques
                    Dim numberOfChanges = 0
                    Dim exitedEarly = False
                    notDone = notDone Or e.Execute(Me, earlyExitWhenSoleFound, possibleNumbers, numberOfChanges, exitedEarly)
                    If usesOfTechnique IsNot Nothing Then
                        Dim uses As Integer
                        If usesOfTechnique.TryGetValue(e, uses) Then
                            usesOfTechnique(e) = numberOfChanges + uses
                        Else
                            usesOfTechnique(e) = numberOfChanges
                        End If
                    End If
                    If exitedEarly Then
                        notDone = False
                        Exit For
                    End If
                Next e
            Loop While notDone AndAlso Not onlyOnePass

            Return possibleNumbers
        End Function

		''' <summary>Analyzes the state of the puzzle to determine whether it is a solution or not.</summary>
		''' <returns>The status of the puzzle.</returns>
		Private Function AnalyzeSolutionStatus() As PuzzleStatus
			' Need a way of keeping track of what numbers have been used (in each row, column, box, etc.)
			' A bit array is a great way to do this, where each bit corresponds to a true/false value
			' as to whether a number was already used in a particular scenario.
			Dim numbersUsed As New FastBitArray(_gridSize)

			' Make sure every column contains the right numbers.  It's ok if a column has holes
			' as long as those cells have possibilities, in which case it's a puzzle in progress.
			' However, two numbers can't be used in the same column, even if there are holes.
            For i = 0 To _gridSize - 1
                numbersUsed.SetAll(False)
                For j = 0 To _gridSize - 1
                    If _grid(i, j).HasValue Then
                        Dim value = _grid(i, j).Value
                        If numbersUsed(value) Then
                            Return PuzzleStatus.CannotBeSolved
                        End If
                        numbersUsed(value) = True
                    End If
                Next j
            Next i

			' Same for rows
            For j = 0 To _gridSize - 1
                numbersUsed.SetAll(False)
                For i = 0 To _gridSize - 1
                    If _grid(i, j).HasValue Then
                        Dim value = _grid(i, j).Value
                        If numbersUsed(value) Then
                            Return PuzzleStatus.CannotBeSolved
                        End If
                        numbersUsed(value) = True
                    End If
                Next i
            Next j

			' Same for boxes
            For boxNumber = 0 To _gridSize - 1
                numbersUsed.SetAll(False)
                Dim boxStartX = (boxNumber \ _boxSize) * _boxSize
                For x = boxStartX To boxStartX + _boxSize - 1
                    Dim boxStartY = (boxNumber Mod _boxSize) * _boxSize
                    For y = boxStartY To boxStartY + _boxSize - 1
                        If _grid(x, y).HasValue Then
                            Dim value = _grid(x, y).Value
                            If numbersUsed(value) Then
                                Return PuzzleStatus.CannotBeSolved
                            End If
                            numbersUsed(value) = True
                        End If
                    Next y
                Next x
            Next boxNumber

			' Now figure out whether this is a solved puzzle or a work in progress
			' based on whether there are any holes
            For i = 0 To _gridSize - 1
                For j = 0 To _gridSize - 1
                    If Not _grid(i, j).HasValue Then
                        Return PuzzleStatus.InProgress
                    End If
                Next j
            Next i

			' If we made it this far, this state is a valid solution!  Woo hoo!
			Return PuzzleStatus.Solved
		End Function
	End Class
End Namespace