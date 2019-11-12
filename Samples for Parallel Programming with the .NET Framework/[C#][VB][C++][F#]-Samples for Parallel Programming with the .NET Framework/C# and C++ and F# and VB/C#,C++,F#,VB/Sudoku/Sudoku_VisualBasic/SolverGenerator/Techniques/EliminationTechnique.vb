'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: EliminationTechnique.vb
'
'  Description: Base class for all Sudoku techniques.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Base type used for eliminating possible numbers from cells in a puzzle state.</summary>
	<Serializable>
	Public MustInherit Class EliminationTechnique
		Implements ICloneable
		''' <summary>Stores an instance of each available technique.</summary>
		Private Shared _allAvailableTechniques As List(Of EliminationTechnique)
		''' <summary>Locking mechanism for static members.</summary>
		Private Shared _lock As New Object()

		''' <summary>Gets a collection containing an instance of each available technique.</summary>
		Public Shared ReadOnly Property AvailableTechniques() As List(Of EliminationTechnique)
			Get
				If _allAvailableTechniques Is Nothing Then
					SyncLock _lock
						If _allAvailableTechniques Is Nothing Then
                            _allAvailableTechniques = New List(Of EliminationTechnique)()
                            For Each t In GetType(EliminationTechnique).Assembly.GetTypes()
                                If t.IsSubclassOf(GetType(EliminationTechnique)) AndAlso (Not t.IsAbstract) AndAlso
                                    t.GetConstructor(Type.EmptyTypes) IsNot Nothing Then
                                    _allAvailableTechniques.Add(CType(Activator.CreateInstance(t), EliminationTechnique))
                                End If
                            Next t
							_allAvailableTechniques.Sort(New TechniqueDifficultyComparer())
						End If
					End SyncLock
				End If
				Return _allAvailableTechniques
			End Get
		End Property

		''' <summary>Allows for the sorting of EliminationTechniques by difficulty level.</summary>
		Private Class TechniqueDifficultyComparer
			Implements IComparer(Of EliminationTechnique)
			''' <summary>Compares two EliminationTechniques.</summary>
			''' <param name="x">The first technique.</param>
			''' <param name="y">The second technique.</param>
			''' <returns>The result of comparing the first technique's difficulty level to that of the second.</returns>
            Public Function Compare(ByVal x As EliminationTechnique, ByVal y As EliminationTechnique) As Integer Implements IComparer(Of EliminationTechnique).Compare
                If x Is Nothing AndAlso y Is Nothing Then
                    Return 0
                ElseIf x Is Nothing Then
                    Return 1
                ElseIf y Is Nothing Then
                    Return -1
                Else
                    Return x.DifficultyLevel.CompareTo(y.DifficultyLevel)
                End If
            End Function
        End Class

		Friend Sub New()
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend MustOverride ReadOnly Property DifficultyLevel() As UInteger

		''' <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="exitEarlyWhenSoleFound">Whether the method can exit early when a cell with only one possible number is found.</param>
		''' <param name="possibleNumbers">The previously computed possible numbers.</param>
		''' <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		''' <param name="exitedEarly">Whether the method exited early due to a cell with only one value being found.</param>
		''' <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        Friend MustOverride Function Execute(ByVal state As PuzzleState, ByVal exitEarlyWhenSoleFound As Boolean,
                              ByVal possibleNumbers()() As FastBitArray, <System.Runtime.InteropServices.Out()> ByRef numberOfChanges As Integer,
                              <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Boolean

		''' <summary>Compares two integer arrays.</summary>
		''' <param name="values1">The first array.</param>
		''' <param name="values2">The second array.</param>
		''' <returns>true if arrays contain the same integers in the same order; otherwise, false.</returns>
		Friend Shared Function CompareValues(ByVal values1() As Integer, ByVal values2() As Integer) As Boolean
			If values1.Length <> values2.Length Then
				Return False
			End If
            For i = 0 To values1.Length - 1
                If values1(i) <> values2(i) Then
                    Return False
                End If
            Next i
			Return True
		End Function

		''' <summary>Gets an array of the possible number bit arrays for a given row in the puzzle state.</summary>
		''' <param name="possibleNumbers">The possible numbers.</param>
		''' <param name="row">The row.</param>
		''' <param name="target">The array to store the output.</param>
        Friend Shared Sub GetRowPossibleNumbers(ByVal possibleNumbers()() As FastBitArray, ByVal row As Integer,
            ByVal target() As FastBitArray)
            For i = 0 To target.Length - 1
                target(i) = possibleNumbers(row)(i)
            Next i
        End Sub

		''' <summary>Gets an array of the possible number bit arrays for a given column in the puzzle state.</summary>
		''' <param name="possibleNumbers">The possible numbers.</param>
		''' <param name="column">The column.</param>
		''' <param name="target">The array to store the output.</param>
        Friend Shared Sub GetColumnPossibleNumbers(ByVal possibleNumbers()() As FastBitArray, ByVal column As Integer,
            ByVal target() As FastBitArray)
            For i = 0 To target.Length - 1
                target(i) = possibleNumbers(i)(column)
            Next i
        End Sub

		''' <summary>Gets an array of the possible number bit arrays for a given box in the puzzle state.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="possibleNumbers">The possible numbers.</param>
		''' <param name="box">The box.</param>
		''' <param name="target">The array to store the output.</param>
        Friend Shared Sub GetBoxPossibleNumbers(ByVal state As PuzzleState, ByVal possibleNumbers()() As FastBitArray,
            ByVal box As Integer, ByVal target() As FastBitArray)
            Dim count = 0
            Dim boxStartX = (box Mod state.BoxSize) * state.BoxSize
            For x = boxStartX To boxStartX + state.BoxSize - 1
                Dim boxStartY = (box \ state.BoxSize) * state.BoxSize
                For y = boxStartY To boxStartY + state.BoxSize - 1
                    target(count) = possibleNumbers(x)(y)
                    count += 1
                Next y
            Next x
        End Sub

		''' <summary>Gets the number of the box containing a particular cell.</summary>
		''' <param name="boxSize">The size of a box.</param>
		''' <param name="row">The row.</param>
		''' <param name="column">The column.</param>
		''' <returns>The number of the box.</returns>
		Friend Shared Function GetBoxNumber(ByVal boxSize As Integer, ByVal row As Integer, ByVal column As Integer) As Integer
			Return ((row \ boxSize) * 3) + (column \ boxSize)
		End Function

		''' <summary>Determines whether all of the specified numbers are set in the bit array.</summary>
		''' <param name="numbers">The numbers.</param>
		''' <param name="array">The bit array.</param>
		''' <returns>Whether all of the specified numbers in the bit array are set.</returns>
		Friend Shared Function AllAreSet(ByVal numbers() As Integer, ByVal array As FastBitArray) As Boolean
            For Each n In numbers
                If Not array(n) Then
                    Return False
                End If
            Next n
			Return True
		End Function

		''' <summary>Determines whether any of the specified numbers are set in the bit array.</summary>
		''' <param name="numbers">The numbers.</param>
		''' <param name="array">The bit array.</param>
		''' <returns>Whether any of the specified numbers in the bit array are set.</returns>
		Friend Shared Function AnyAreSet(ByVal numbers() As Integer, ByVal array As FastBitArray) As Boolean
            For Each n In numbers
                If array(n) Then
                    Return True
                End If
            Next n
			Return False
		End Function

		Public Overridable Function Clone() As EliminationTechnique
			Return CType(MemberwiseClone(), EliminationTechnique)
		End Function

		Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
			Return Clone()
		End Function
	End Class
End Namespace