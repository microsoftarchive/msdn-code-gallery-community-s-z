'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: GeneratorOptions.vb
'
'  Description: Configuration options for the puzzle generator.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Options used for generating puzzles.</summary>
	Public NotInheritable Class GeneratorOptions
		Implements ICloneable
		''' <summary>Perceived difficulty of the puzzle.</summary>
		Private _difficulty As PuzzleDifficulty
		''' <summary>The minimum number of filled cells in the generated puzzle.</summary>
		Private _minimumFilledCells As Integer
		''' <summary>The maximum number of times brute-force techniques can be used in solving the puzzle.</summary>
		Private _maximumNumberOfDecisionPoints? As Integer
		''' <summary>The number of puzzles to generate in order to pick the best of the lot.</summary>
		Private _numberOfPuzzles As Integer
		''' <summary>Techniques allowed to be used in the generation of puzzles.</summary>
		Private _eliminationTechniques As List(Of EliminationTechnique)
		''' <summary>Whether only symmetrical puzzles should be generated.</summary>
		Private _ensureSymmetry As Boolean

		''' <summary>Creates generator options that will create a puzzle of the specified difficulty level.</summary>
		''' <param name="difficultyLevel">The difficulty level.</param>
		''' <returns>Generator options appropriate for this level.</returns>
		Public Shared Function Create(ByVal difficultyLevel As PuzzleDifficulty) As GeneratorOptions
			Select Case difficultyLevel
				Case PuzzleDifficulty.Easy
                    Return New GeneratorOptions(PuzzleDifficulty.Easy, 32, 0, 2, New EliminationTechnique() {New BeginnerTechnique()}, True)

				Case PuzzleDifficulty.Medium
                    Return New GeneratorOptions(PuzzleDifficulty.Medium, 0, 0, 15, New EliminationTechnique() {New BeginnerTechnique(),
                           New NakedSingleTechnique(), New HiddenSingleTechnique(), New BlockAndColumnRowInteractionTechnique(),
                           New NakedPairTechnique(), New HiddenPairTechnique()}, True)

				Case PuzzleDifficulty.Hard
                    Return New GeneratorOptions(PuzzleDifficulty.Hard, 0, 0, 30, New EliminationTechnique() {New BeginnerTechnique(),
                           New NakedSingleTechnique(), New HiddenSingleTechnique(), New BlockAndColumnRowInteractionTechnique(),
                           New NakedPairTechnique(), New HiddenPairTechnique(), New NakedTripletTechnique(), New HiddenTripletTechnique(),
                           New NakedQuadTechnique(), New HiddenQuadTechnique(), New XwingTechnique()}, True)

				Case PuzzleDifficulty.VeryHard ' may require "guessing" technique
                    Return New GeneratorOptions(PuzzleDifficulty.VeryHard, 0, Nothing, 45, New EliminationTechnique() {New BeginnerTechnique(),
                           New NakedSingleTechnique(), New HiddenSingleTechnique(), New BlockAndColumnRowInteractionTechnique(),
                           New NakedPairTechnique(), New HiddenPairTechnique(), New NakedTripletTechnique(),
                           New HiddenTripletTechnique(), New NakedQuadTechnique(), New HiddenQuadTechnique(),
                           New XwingTechnique()}, True)

				Case Else
					Throw New ArgumentOutOfRangeException("difficultyLevel")
			End Select
		End Function

		''' <summary>Initialize the GeneratorOptions</summary>
		''' <param name="size">The size of the puzzle to be generated.</param>
		''' <param name="difficulty">The difficulty of the puzzle to generate.</param>
		''' <param name="minimumFilledCells">The minimum number of filled cells in the generated puzzle.</param>
		''' <param name="maximumNumberOfDecisionPoints">The maximum number of times brute-force techniques can be used in solving the puzzle.</param>
		''' <param name="numberOfPuzzles">The number of puzzles to generate in order to pick the best of the lot.</param>
		''' <param name="techniques">The techniques to use while generating the puzzle.</param>
		''' <param name="ensureSymmetry">Whether all puzzles generated should be symmetrical.</param>
        Private Sub New(ByVal difficulty As PuzzleDifficulty, ByVal minimumFilledCells As Integer,
                        ByVal maximumNumberOfDecisionPoints? As Integer, ByVal numberOfPuzzles As Integer,
                        ByVal techniques() As EliminationTechnique, ByVal ensureSymmetry As Boolean)
            If difficulty <> PuzzleDifficulty.Easy AndAlso difficulty <> PuzzleDifficulty.Medium AndAlso difficulty <>
                        PuzzleDifficulty.Hard AndAlso difficulty <> PuzzleDifficulty.VeryHard Then
                Throw New ArgumentOutOfRangeException("difficulty")
            End If
            If minimumFilledCells < 0 Then
                Throw New ArgumentOutOfRangeException("minimumFilledCells")
            End If
            If numberOfPuzzles < 1 Then
                Throw New ArgumentOutOfRangeException("numberOfPuzzles")
            End If
            If techniques Is Nothing Then
                Throw New ArgumentNullException("techniques")
            End If

            _difficulty = difficulty
            _minimumFilledCells = minimumFilledCells
            _maximumNumberOfDecisionPoints = maximumNumberOfDecisionPoints
            _numberOfPuzzles = numberOfPuzzles
            _ensureSymmetry = ensureSymmetry
            _eliminationTechniques = New List(Of EliminationTechnique)(techniques)
        End Sub

		''' <summary>Constructor used only for cloning.</summary>
		Private Sub New()
			_eliminationTechniques = New List(Of EliminationTechnique)()
		End Sub

		''' <summary>Gets the minimum number of filled cells in the generated puzzle.</summary>
		Public ReadOnly Property MinimumFilledCells() As Integer
			Get
				Return _minimumFilledCells
			End Get
		End Property

		''' <summary>Gets the maximum number of times brute-force techniques can be used in solving the puzzle.</summary>
		Public ReadOnly Property MaximumNumberOfDecisionPoints() As Integer?
			Get
				Return _maximumNumberOfDecisionPoints
			End Get
		End Property

		''' <summary>Gets the number of puzzles to generate in order to pick the best of the lot.</summary>
		Public ReadOnly Property NumberOfPuzzles() As Integer
			Get
				Return _numberOfPuzzles
			End Get
		End Property

		''' <summary>Gets the elimination techniques to be used.</summary>
		Public ReadOnly Property Techniques() As List(Of EliminationTechnique)
			Get
				Return _eliminationTechniques
			End Get
		End Property

		''' <summary>Gets whether all puzzles generated should be symmetrical.</summary>
		Public Property EnsureSymmetry() As Boolean
			Get
				Return _ensureSymmetry
			End Get
			Set(ByVal value As Boolean)
				_ensureSymmetry = value
			End Set
		End Property

		''' <summary>Gets the perceived difficulty of the puzzle to create.</summary>
		Public ReadOnly Property Difficulty() As PuzzleDifficulty
			Get
				Return _difficulty
			End Get
		End Property

		Public Property ParallelGeneration() As Boolean

		Public Property SpeculativeGeneration() As Boolean

		Public Overrides Overloads Function Equals(ByVal obj As Object) As Boolean
            Dim other = TryCast(obj, GeneratorOptions)
			If Not(TypeOf other Is GeneratorOptions) Then
				Return False
			End If

            If MinimumFilledCells = other.MinimumFilledCells AndAlso MaximumNumberOfDecisionPoints =
                other.MaximumNumberOfDecisionPoints AndAlso NumberOfPuzzles = other.NumberOfPuzzles AndAlso
                EnsureSymmetry = other.EnsureSymmetry AndAlso Difficulty = other.Difficulty Then
                For Each technique In Techniques
                    If Not other.Techniques.Contains(technique) Then
                        Return False
                    End If
                Next technique
                Return True
            End If

			Return False
		End Function

		Public Overrides Function GetHashCode() As Integer
			Return Difficulty.GetHashCode()
		End Function

		''' <summary>Clones the solver options.</summary>
		''' <returns>A clone of the options.</returns>
		Public Function Clone() As GeneratorOptions
            Dim options As New GeneratorOptions()

            With options
                ._difficulty = _difficulty
                ._ensureSymmetry = _ensureSymmetry
                ._maximumNumberOfDecisionPoints = _maximumNumberOfDecisionPoints
                ._minimumFilledCells = _minimumFilledCells
                ._numberOfPuzzles = _numberOfPuzzles
                .ParallelGeneration = ParallelGeneration
                .SpeculativeGeneration = SpeculativeGeneration
            End With
            For Each technique In _eliminationTechniques
                options._eliminationTechniques.Add(technique.Clone())
            Next technique
            Return options
        End Function

		''' <summary>Clones the solver options.</summary>
		''' <returns>A clone of the options.</returns>
		Private Function ICloneable_Clone() As Object Implements ICloneable.Clone
			Return Clone()
		End Function
	End Class
End Namespace