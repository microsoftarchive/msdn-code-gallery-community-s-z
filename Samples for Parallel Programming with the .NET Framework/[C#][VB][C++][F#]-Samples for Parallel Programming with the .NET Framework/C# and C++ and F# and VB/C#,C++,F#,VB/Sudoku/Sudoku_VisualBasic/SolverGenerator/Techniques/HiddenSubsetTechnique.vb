'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: HiddenSubsetTechnique.vb
'
'  Description: Implements the Sudoku hidden subset technique.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Collections

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques
	''' <summary>Implements the hidden pair elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class HiddenPairTechnique
		Inherits HiddenSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(2)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 6
			End Get
		End Property
	End Class

	''' <summary>Implements the hidden triplet elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class HiddenTripletTechnique
		Inherits HiddenSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(3)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 8
			End Get
		End Property
	End Class

	''' <summary>Implements the hidden quad elimination technique.</summary>
	<Serializable>
	Public NotInheritable Class HiddenQuadTechnique
		Inherits HiddenSubsetTechnique
		''' <summary>Initializes the technique.</summary>
		Public Sub New()
			MyBase.New(4)
		End Sub

		''' <summary>Gets the difficulty level of this technique.</summary>
		Friend Overrides ReadOnly Property DifficultyLevel() As UInteger
			Get
				Return 10
			End Get
		End Property
	End Class

	''' <summary>Implements the hidden subset elimination technique.</summary>
	<Serializable>
	Public MustInherit Class HiddenSubsetTechnique
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
			_foundLocations = New Integer(_subsetSize - 1){} ' optimization, rather than allocating on each call
		End Sub

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
            Dim hst = TryCast(obj, HiddenSubsetTechnique)
			If hst Is Nothing Then
				Return False
			End If
			Return _subsetSize = hst._subsetSize
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return Me.GetType().GetHashCode()
		End Function

		Public Overrides Function Clone() As EliminationTechnique
            Dim hst = CType(MyBase.Clone(), HiddenSubsetTechnique)
			hst._foundLocations = New Integer(_subsetSize - 1){}
			Return hst
		End Function

		''' <summary>Performs hidden subset elimination on one dimension of possible numbers.</summary>
		''' <param name="possibleNumbers">The row/column/box to analyze.</param>
		''' <returns>The number of changes that were made to the possible numbers.</returns>
        Private Function EliminateHiddenSubsets(ByVal possibleNumbers() As FastBitArray,
             ByVal exitEarlyWhenSoleFound As Boolean, <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Integer
            Dim changesMade = 0
            exitedEarly = False
            Dim numLocations As Integer
            Dim foundLocations() = _foundLocations ' optimization, rather than allocating on each call

            ' We'll look starting with each cell in the row/column/box
            For i = 0 To possibleNumbers.Length - 1
                ' Only look at the cell if it has at least subsetSize values set,
                ' otherwise it can't be part of a hidden subset
                Dim numPossible = possibleNumbers(i).CountSet
                If numPossible >= _subsetSize Then
                    ' For each combination
                    For Each combination In CreateCombinations(_subsetSize, possibleNumbers(i).GetSetBits())
                        ' Find other cells that contain that same combination,
                        ' but only up to the subset size
                        numLocations = 0
                        foundLocations(numLocations) = i
                        numLocations += 1
                        Dim j = i + 1
                        Do While j < possibleNumbers.Length AndAlso numLocations < foundLocations.Length
                            If AllAreSet(combination, possibleNumbers(j)) Then
                                foundLocations(numLocations) = j
                                numLocations += 1
                            End If
                            j += 1
                        Loop


                        If numLocations = foundLocations.Length Then
                            Dim isValidHidden = True

                            ' Make sure that none of the numbers appear in any other cell
                            j = 0
                            Do While j < possibleNumbers.Length AndAlso isValidHidden
                                Dim isFoundLocation = Array.BinarySearch(foundLocations, j) >= 0
                                If (Not isFoundLocation) AndAlso AnyAreSet(combination, possibleNumbers(j)) Then
                                    isValidHidden = False
                                    Exit Do
                                End If
                                j += 1
                            Loop

                            ' If this is a valid hidden subset, eliminate all other numbers
                            ' from each cell in the subset
                            If isValidHidden Then
                                For Each foundLoc In foundLocations
                                    Dim possibleNumbersForLoc = possibleNumbers(foundLoc)
                                    For Each n In possibleNumbersForLoc.GetSetBits()
                                        If Array.BinarySearch(combination, n) < 0 Then
                                            possibleNumbersForLoc(n) = False
                                            changesMade += 1
                                        End If
                                    Next n
                                    If exitEarlyWhenSoleFound AndAlso possibleNumbersForLoc.CountSet = 1 Then
                                        exitedEarly = True
                                        Return changesMade
                                    End If
                                Next foundLoc
                                Exit For
                            End If
                        End If
                    Next combination
                End If
            Next i

            Return changesMade
        End Function

		''' <summary>Allows for iteration through all combinations from an array.</summary>
		''' <param name="size">The size of the subset.</param>
		''' <param name="numbers">The numbers.</param>
		''' <returns>An enumerable for all the combinations.</returns>
        Public Shared Function CreateCombinations(ByVal size As Integer, ByVal numbers() As Integer) As IEnumerable(Of Integer())
            Dim indices(size - 1) As Integer
            Dim result(size - 1) As Integer
            Dim stringArray(size - 1) As Integer
            Dim pos As Integer = Nothing
            Dim stringvalue As New List(Of Integer())
            For i = 0 To indices.Length - 1
                indices(i) = i
                result(i) = numbers(i)
                stringArray(i) = numbers(i)
            Next i

            Dim strings As New List(Of Integer())
            strings.Add(stringArray)
            Return strings

            Do
                If indices(0) >= numbers.Length - size Then
                    Exit Do
                End If

                ' Find the next position to be incremented
                pos = indices.Length - 1
                Do While pos > 0 AndAlso indices(pos) = numbers.Length - size + pos

                    pos -= 1
                Loop
                ' Increment it
                indices(pos) += 1

                ' Increment everything else
                For j = pos To size - 2
                    indices(j + 1) = indices(j) + 1
                Next j

                ' Create the result
                For i = 0 To indices.Length - 1
                    stringArray(i) = numbers(indices(i))
                Next i
                stringvalue.Add(stringArray)
                Return stringvalue
            Loop
        End Function

		''' <summary>Runs this elimination technique over the supplied puzzle state and previously computed possible numbers.</summary>
		''' <param name="state">The puzzle state.</param>
		''' <param name="exitEarlyWhenSoleFound">Whether the method can exit early when a cell with only one possible number is found.</param>
		''' <param name="possibleNumbers">The previously computed possible numbers.</param>
		''' <param name="numberOfChanges">The number of changes made by this elimination technique.</param>
		''' <param name="exitedEarly">Whether the method exited early due to a cell with only one value being found.</param>
		''' <returns>Whether more changes may be possible based on changes made during this execution.</returns>
        Friend Overrides Function Execute(ByVal state As PuzzleState, ByVal exitEarlyWhenSoleFound As Boolean,
                    ByVal possibleNumbers()() As FastBitArray, <System.Runtime.InteropServices.Out()>
                    ByRef numberOfChanges As Integer, <System.Runtime.InteropServices.Out()> ByRef exitedEarly As Boolean) As Boolean
            numberOfChanges = 0
            exitedEarly = False
            Dim arrays(state.GridSize - 1) As FastBitArray

            For i = 0 To state.GridSize - 1
                GetRowPossibleNumbers(possibleNumbers, i, arrays)
                numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If

                GetColumnPossibleNumbers(possibleNumbers, i, arrays)
                numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If

                GetBoxPossibleNumbers(state, possibleNumbers, i, arrays)
                numberOfChanges += EliminateHiddenSubsets(arrays, exitEarlyWhenSoleFound, exitedEarly)
                If exitedEarly Then
                    Return False
                End If
            Next i

            Return numberOfChanges <> 0
        End Function
    End Class
End Namespace