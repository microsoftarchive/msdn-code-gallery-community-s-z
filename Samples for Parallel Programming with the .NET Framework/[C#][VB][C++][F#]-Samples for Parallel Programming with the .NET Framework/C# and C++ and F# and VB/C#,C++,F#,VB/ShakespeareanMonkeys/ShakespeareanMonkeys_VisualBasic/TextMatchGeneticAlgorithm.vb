'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: TextMatchGeneticAlgorithm.vb
'
'--------------------------------------------------------------------------

Imports System.Text
Imports System.Threading

Namespace ShakespeareanMonkeys
	Public Class TextMatchGeneticAlgorithm
		Private Shared _random As New ThreadSafeRandom()
		Private Shared _validChars() As Char
		Private _targetText As String
		Private _settings As GeneticAlgorithmSettings
		Private _currentPopulation() As TextMatchGenome
		Private _runParallel As Boolean

		Shared Sub New()
            ' Initialize the valid characters to newlines plus all the alphanumerics and symbols.
			_validChars = New Char(2 + (127 - 32) - 1){}
			_validChars(0) = ChrW(10)
			_validChars(1) = ChrW(13)
            Dim i = 2
            Dim pos = 32
			Do While i < _validChars.Length
				_validChars(i) = ChrW(pos)
				i += 1
				pos += 1
			Loop
		End Sub

		Public Sub New(ByVal runParallel As Boolean, ByVal targetText As String, ByVal settings As GeneticAlgorithmSettings)
			If settings Is Nothing Then
				Throw New ArgumentNullException("settings")
			End If
			If targetText Is Nothing Then
				Throw New ArgumentNullException("targetText")
			End If
			_runParallel = runParallel
			_settings = settings
			_targetText = targetText
		End Sub

		Public Sub MoveNext()
            ' If this is the first iteration, create a random population.
			If _currentPopulation Is Nothing Then
				_currentPopulation = CreateRandomPopulation()
			' Otherwise, iterate
			Else
				_currentPopulation = CreateNextGeneration()
			End If
		End Sub

		Public ReadOnly Property CurrentBest() As TextMatchGenome
			Get
				Return _currentPopulation(0)
			End Get
		End Property

		Private Function CreateRandomPopulation() As TextMatchGenome()
			Return (
			    From i In Enumerable.Range(0, _settings.PopulationSize)
			    Select CreateRandomGenome(_random)).ToArray()
		End Function

		Private Function CreateRandomGenome(ByVal rand As Random) As TextMatchGenome
			Dim sb = New StringBuilder(_targetText.Length)
            For i = 0 To _targetText.Length - 1
                sb.Append(_validChars(rand.Next(0, _validChars.Length)))
            Next i
			Return New TextMatchGenome With {.Text = sb.ToString(), .TargetText = _targetText}
		End Function

		Private Function CreateNextGeneration() As TextMatchGenome()
			Dim maxFitness = _currentPopulation.Max(Function(g) g.Fitness) + 1
			Dim sumOfMaxMinusFitness = _currentPopulation.Sum(Function(g) CLng(Fix(maxFitness - g.Fitness)))

			If _runParallel Then
                Return (
                    From i In ParallelEnumerable.Range(0, _settings.PopulationSize \ 2),
                    child In CreateChildren(FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness),
                                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness))
                    Select child).ToArray()
			Else
                Return (
                    From i In Enumerable.Range(0, _settings.PopulationSize \ 2),
                    child In CreateChildren(FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness),
                                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness))
                    Select child).ToArray()
			End If
		End Function

        Private Function CreateChildren(ByVal parent1 As TextMatchGenome, ByVal parent2 As TextMatchGenome) As TextMatchGenome()
            ' Crossover parents to create two children.
            Dim child1 As TextMatchGenome = Nothing
            Dim child2 As TextMatchGenome = Nothing
            If _random.NextDouble() < _settings.CrossoverProbability Then
                Crossover(_random, parent1, parent2, child1, child2)
            Else
                child1 = parent1
                child2 = parent2
            End If

            ' Potentially mutate one or both children.
            If _random.NextDouble() < _settings.MutationProbability Then
                Mutate(_random, child1)
            End If
            If _random.NextDouble() < _settings.MutationProbability Then
                Mutate(_random, child2)
            End If

            ' Return the young'ens.
            Return {child1, child2}
        End Function

		Private Function FindRandomHighQualityParent(ByVal sumOfMaxMinusFitness As Long, ByVal max As Integer) As TextMatchGenome
            Dim val = CLng(Fix(_random.NextDouble() * sumOfMaxMinusFitness))
            For i = 0 To _currentPopulation.Length - 1
                Dim maxMinusFitness = max - _currentPopulation(i).Fitness
                If val < maxMinusFitness Then
                    Return _currentPopulation(i)
                End If
                val -= maxMinusFitness
            Next i
			Throw New InvalidOperationException("Not to be, apparently.")
		End Function

        Private Sub Crossover(ByVal rand As Random, ByVal p1 As TextMatchGenome, ByVal p2 As TextMatchGenome,
                              <System.Runtime.InteropServices.Out()> ByRef child1 As TextMatchGenome,
                              <System.Runtime.InteropServices.Out()> ByRef child2 As TextMatchGenome)
            Dim crossoverPoint = rand.Next(1, p1.Text.Length)
            child1 = New TextMatchGenome With {.Text = p1.Text.Substring(0, crossoverPoint) & p2.Text.Substring(crossoverPoint), .TargetText = _targetText}
            child2 = New TextMatchGenome With {.Text = p2.Text.Substring(0, crossoverPoint) & p1.Text.Substring(crossoverPoint), .TargetText = _targetText}
        End Sub

		Private Sub Mutate(ByVal rand As Random, ByRef genome As TextMatchGenome)
			Dim sb = New StringBuilder(genome.Text)
			sb(rand.Next(0, genome.Text.Length)) = _validChars(rand.Next(0, _validChars.Length))
			genome.Text = sb.ToString()
		End Sub
	End Class

	Public Structure TextMatchGenome
        Private _targetText As String
		Private _text As String

		Public Property Text() As String
			Get
				Return _text
			End Get
			Set(ByVal value As String)
				_text = value
				RecomputeFitness()
			End Set
		End Property

		Public Property TargetText() As String
			Get
				Return _targetText
			End Get
			Set(ByVal value As String)
				_targetText = value
				RecomputeFitness()
			End Set
		End Property

		Private Sub RecomputeFitness()
			If _text IsNot Nothing AndAlso _targetText IsNot Nothing Then
                Dim diffs = 0
                For i = 0 To _targetText.Length - 1
                    If _targetText.Chars(i) <> _text.Chars(i) Then
                        diffs += 1
                    End If
                Next i
				Fitness = diffs
			Else
				Fitness = Int32.MaxValue
			End If
		End Sub

		Private privateFitness As Integer
		Public Property Fitness() As Integer
			Get
				Return privateFitness
			End Get
			Private Set(ByVal value As Integer)
				privateFitness = value
			End Set
		End Property
	End Structure

	Public Class GeneticAlgorithmSettings
		Public Property PopulationSize() As Integer
			Get
				Return _populationSize
			End Get
			Set(ByVal value As Integer)
				If value < 1 OrElse value Mod 2 <> 0 Then
					Throw New ArgumentOutOfRangeException("PopulationSize")
				End If
				_populationSize = value
			End Set
		End Property

		Public Property MutationProbability() As Double
			Get
				Return _mutationProbability
			End Get
			Set(ByVal value As Double)
				If value < 0 OrElse value > 1 Then
					Throw New ArgumentOutOfRangeException("MutationProbability")
				End If
				_mutationProbability = value
			End Set
		End Property

		Public Property CrossoverProbability() As Double
			Get
				Return _crossoverProbability
			End Get
			Set(ByVal value As Double)
				If value < 0 OrElse value > 1 Then
					Throw New ArgumentOutOfRangeException("CrossoverProbability")
				End If
				_crossoverProbability = value
			End Set
		End Property

        Private _populationSize As Integer = 30
        Private _mutationProbability As Double = 0.01
        Private _crossoverProbability As Double = 0.87
	End Class
End Namespace