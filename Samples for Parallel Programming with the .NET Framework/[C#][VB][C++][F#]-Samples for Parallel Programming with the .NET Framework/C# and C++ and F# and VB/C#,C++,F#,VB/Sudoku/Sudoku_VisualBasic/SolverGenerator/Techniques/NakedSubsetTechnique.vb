'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: NakedSubsetTecnnique.vb
'
'  Description: Implements the Sudoku naked subset technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the naked pair elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class NakedPairTechnique
		Inherits NakedSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(2)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 5
			End Get
		End Property
	End Class

	''' <summary>Implements the naked triplet elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class NakedTripletTechnique
		Inherits NakedSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(3)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 7
			End Get
		End Property
	End Class

	''' <summary>Implements the naked quad elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class NakedQuadTechnique
		Inherits NakedSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(4)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 9
			End Get
		End Property
	End Class

	''' <summary>Implements the naked subset elimination technique.</summary>
	<Serializable>
	Public MustInherit Class NakedSubsetTechnique
		Inherits EliminationTechnique
		''' <summary>The size of the subset to evaluate.</summary>
		Private _subsetSize As Integer
		Private _foundLocations() As Integer

		''' <summary>Initialize the technique.</summary>
		''' <param name="subsetSize">The size of the subset to evaluate.</param>
		Protected Sub New(ByVal subsetSize As Integer)
			If subsetSize < 2 Then
				Throw New ArgumentOutOfRangeException("subsetSize")
			End If
			_subsetSize = subsetSize
			_foundLocations = New Integer(_subsetSize - 1){} ' optimization, rather than doing it in each call to EliminateNakedSubsets
		End Sub

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
            Dim nst = TryCast(obj, NakedSubsetTechnique)
			If nst Is Nothing Then
				Return False
			End If
			Return _subsetSize = nst._subsetSize
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return Me.GetType().GetHashCode()
		End Function

		Public Overrides Function Clone() As EliminationTechnique
            Dim nst = CType(MyBase.Clone(), NakedSubsetTechnique)
			nst._foundLocations = New Integer(_subsetSize - 1){}
			Return nst
		End Function

		''' <summary>Performs naked subset elimination on one dimension of possible numbers.</summary>
		''' <param name="possibleNumbers">The row/column/box to analyze.</param>
		''' <returns>The number of changes that were made to the possible numbers.</returns>
        Private Function EliminateNakedSubsets(ByVal possibleNumbers() As FastBitArray, ByVal exitEarlyWhenSoleFound As Boolean,
            <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Integer
            Dim changesMade = 0
            exitedEarly = False
            Dim foundLocations() = _foundLocations ' optimization, rather than allocating each time

            For i = 0 To possibleNumbers.Length - 1
                If possibleNumbers(i).CountSet = _subsetSize Then
                    foundLocations(0) = i
                    Dim toMatchValues() = possibleNumbers(i).GetSetBits()
                    Dim matchesFound = 0
                    For j = i + 1 To possibleNumbers.Length - 1
                        If possibleNumbers(j).CountSet = _subsetSize Then
                            Dim foundMatch = CompareValues(toMatchValues, possibleNumbers(j).GetSetBits())
                            If foundMatch Then
                                matchesFound += 1
                                foundLocations(matchesFound) = j
                                If matchesFound = _subsetSize - 1 Then
                                    For k = 0 To possibleNumbers.Length - 1
                                        If Array.BinarySearch(foundLocations, k) < 0 Then
                                            For Each eliminatedPossible In toMatchValues
                                                If possibleNumbers(k)(eliminatedPossible) Then
                                                    changesMade += 1
                                                    possibleNumbers(k)(eliminatedPossible) = False
                                                End If
                                            Next eliminatedPossible
                                            If exitEarlyWhenSoleFound AndAlso possibleNumbers(k).CountSet = 1 Then
                                                exitedEarly = True
                                                Return changesMade
                                            End If
                                        End If
                                    Next k
                                    Exit For
                                End If
                            End If
                        End If
                    Next j
                End If
            Next i

            Return changesMade
        End Function

		''' <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="possibleNumbers">The previously computed possible numbers.</param>
		''' <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		''' <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        Friend Overrides Function Execute(ByVal state As PuzzleState, ByVal exitEarlyWhenSoleFound As Boolean,
                        ByVal possibleNumbers()() As FastBitArray, <System.Runtime.InteropServices.Out()> ByRef numberOfChanges As Integer,
                        <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Boolean
            numberOfChanges = 0
            exitedEarly = False
            Dim arrays(state.GridSize - 1) As FastBitArray

            For i = 0 To state.GridSize - 1
                GetRowPossibleNumbers(possibleNumbers, i, arrays)
                numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If

                GetColumnPossibleNumbers(possibleNumbers, i, arrays)
                numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If

                GetBoxPossibleNumbers(state, possibleNumbers, i, arrays)
                numberOfChanges += EliminateNakedSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If
            Next i

            Return numberOfChanges <> 0
        End Function
	End Class
End Namespace