'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: SolverOptions.vb
'
'  Description: Options for the Sudoku solver.
' 
'--------------------------------------------------------------------------

Imports Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Techniques

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Options for configuring how the solver does its processing.</summary>
	Public NotInheritable Class SolverOptions
		Implements ICloneable
		''' <summary>The maximum number of solutions the solver should find.</summary>
		Private _maximumSolutionsToFind? As UInteger = 1

		''' <summary>Whether to allow brute-force techniques in the solver.</summary>
		Private _allowBruteForce As Boolean = True

		''' <summary>The techniques to use while solving.</summary>
		Private _techniques As List(Of EliminationTechnique)

		''' <summary>Initializes the SolverOptions.</summary>
		Public Sub New()
		End Sub

		''' <summary>Gets or sets the maximum number of solutions the solver should find.</summary>
		Public Property MaximumSolutionsToFind() As UInteger?
			Get
				Return _maximumSolutionsToFind
			End Get
			Set(ByVal value? As UInteger)
				If value <= 0UI Then
					Throw New ArgumentOutOfRangeException("value")
				End If
				_maximumSolutionsToFind = value
			End Set
		End Property

		''' <summary>Gets or sets the techniques used for solving.</summary>
		Public Property EliminationTechniques() As List(Of EliminationTechnique)
			Get
				If _techniques Is Nothing Then
					_techniques = New List(Of EliminationTechnique)()
				End If
				Return _techniques
			End Get
			Set(ByVal value As List(Of EliminationTechnique))
				_techniques = value
			End Set
		End Property

		''' <summary>Gets or sets whether to allow brute-force techniques in the solver.</summary>
		Public Property AllowBruteForce() As Boolean
			Get
				Return _allowBruteForce
			End Get
			Set(ByVal value As Boolean)
				_allowBruteForce = value
			End Set
		End Property

		''' <summary>Clones the solver options.</summary>
		''' <returns>A clone of the options.</returns>
		Public Function Clone() As SolverOptions
            Dim options As New SolverOptions()
            With options
                .AllowBruteForce = AllowBruteForce
                .MaximumSolutionsToFind = MaximumSolutionsToFind
                .EliminationTechniques = New List(Of EliminationTechnique)()

            End With
            For Each technique In EliminationTechniques
                options.EliminationTechniques.Add(technique.Clone())
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