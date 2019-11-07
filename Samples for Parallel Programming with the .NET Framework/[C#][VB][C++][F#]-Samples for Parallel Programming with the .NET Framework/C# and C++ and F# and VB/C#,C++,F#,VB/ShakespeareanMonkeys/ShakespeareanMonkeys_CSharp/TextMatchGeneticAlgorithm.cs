//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: TextMatchGeneticAlgorithm.cs
//
//--------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace ShakespeareanMonkeys
{
    public class TextMatchGeneticAlgorithm
    {
        private static ThreadSafeRandom _random = new ThreadSafeRandom();
        private static char[] _validChars;
        private string _targetText;
        private GeneticAlgorithmSettings _settings;
        private TextMatchGenome[] _currentPopulation;
        private bool _runParallel;

        static TextMatchGeneticAlgorithm()
        {
            // Initialize the valid characters to newlines plus all the alphanumerics and symbols
            _validChars = new char[2 + (127 - 32)];
            _validChars[0] = (char)10;
            _validChars[1] = (char)13;
            for (int i = 2, pos = 32; i < _validChars.Length; i++, pos++)
            {
                _validChars[i] = (char)pos;
            }
        }

        public TextMatchGeneticAlgorithm(bool runParallel, string targetText, GeneticAlgorithmSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            if (targetText == null) throw new ArgumentNullException("targetText");
            _runParallel = runParallel;
            _settings = settings;
            _targetText = targetText;
        }

        public void MoveNext()
        {
            // If this is the first iteration, create a random population
            if (_currentPopulation == null)
            {
                _currentPopulation = CreateRandomPopulation();
            }
            // Otherwise, iterate
            else _currentPopulation = CreateNextGeneration();
        }

        public TextMatchGenome CurrentBest { get { return _currentPopulation[0]; } }

        private TextMatchGenome[] CreateRandomPopulation()
        {
            return (from i in Enumerable.Range(0, _settings.PopulationSize)
                    select CreateRandomGenome(_random)).ToArray();
        }

        private TextMatchGenome CreateRandomGenome(Random rand)
        {
            var sb = new StringBuilder(_targetText.Length);
            for (int i = 0; i < _targetText.Length; i++)
            {
                sb.Append(_validChars[rand.Next(0, _validChars.Length)]);
            }
            return new TextMatchGenome { Text = sb.ToString(), TargetText = _targetText };
        }

        private TextMatchGenome[] CreateNextGeneration()
        {
            var maxFitness = _currentPopulation.Max(g => g.Fitness) + 1;
            var sumOfMaxMinusFitness = _currentPopulation.Sum(g => (long)(maxFitness - g.Fitness));

            if (_runParallel)
            {
                return (from i in ParallelEnumerable.Range(0, _settings.PopulationSize / 2)
                        from child in CreateChildren(
                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness),
                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness))
                        select child).
                        ToArray();
            }
            else
            {
                return (from i in Enumerable.Range(0, _settings.PopulationSize / 2)
                        from child in CreateChildren(
                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness),
                            FindRandomHighQualityParent(sumOfMaxMinusFitness, maxFitness))
                        select child).
                        ToArray();
            }
        }

        private TextMatchGenome[] CreateChildren(
            TextMatchGenome parent1, TextMatchGenome parent2)
        {
            // Crossover parents to create two children
            TextMatchGenome child1, child2;
            if (_random.NextDouble() < _settings.CrossoverProbability)
            {
                Crossover(_random, parent1, parent2, out child1, out child2);
            }
            else
            {
                child1 = parent1;
                child2 = parent2;
            }

            // Potentially mutate one or both children
            if (_random.NextDouble() < _settings.MutationProbability) Mutate(_random, ref child1);
            if (_random.NextDouble() < _settings.MutationProbability) Mutate(_random, ref child2);

            // Return the young'ens
            return new[] { child1, child2 };
        }

        private TextMatchGenome FindRandomHighQualityParent(long sumOfMaxMinusFitness, int max)
        {
            long val = (long)(_random.NextDouble() * sumOfMaxMinusFitness);
            for (int i = 0; i < _currentPopulation.Length; i++)
            {
                int maxMinusFitness = max - _currentPopulation[i].Fitness;
                if (val < maxMinusFitness) return _currentPopulation[i];
                val -= maxMinusFitness;
            }
            throw new InvalidOperationException("Not to be, apparently.");
        }

        private void Crossover(Random rand, TextMatchGenome p1, TextMatchGenome p2, out TextMatchGenome child1, out TextMatchGenome child2)
        {
            int crossoverPoint = rand.Next(1, p1.Text.Length);
            child1 = new TextMatchGenome { Text = p1.Text.Substring(0, crossoverPoint) + p2.Text.Substring(crossoverPoint), TargetText = _targetText };
            child2 = new TextMatchGenome { Text = p2.Text.Substring(0, crossoverPoint) + p1.Text.Substring(crossoverPoint), TargetText = _targetText };
        }

        private void Mutate(Random rand, ref TextMatchGenome genome)
        {
            var sb = new StringBuilder(genome.Text);
            sb[rand.Next(0, genome.Text.Length)] = _validChars[rand.Next(0, _validChars.Length)];
            genome.Text = sb.ToString();
        }
    }

    public struct TextMatchGenome
    {
        private string _targetText;
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RecomputeFitness();
            }
        }

        public string TargetText
        {
            get { return _targetText; }
            set
            {
                _targetText = value;
                RecomputeFitness();
            }
        }

        private void RecomputeFitness()
        {
            if (_text != null && _targetText != null)
            {
                int diffs = 0;
                for (int i = 0; i < _targetText.Length; i++)
                {
                    if (_targetText[i] != _text[i]) diffs++;
                }
                Fitness = diffs;
            }
            else Fitness = Int32.MaxValue;
        }

        public int Fitness { get; private set; }
    }

    public class GeneticAlgorithmSettings
    {
        public int PopulationSize
        {
            get { return _populationSize; }
            set
            {
                if (value < 1 ||
                    value % 2 != 0) throw new ArgumentOutOfRangeException("PopulationSize");
                _populationSize = value;
            }
        }

        public double MutationProbability
        {
            get { return _mutationProbability; }
            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("MutationProbability");
                _mutationProbability = value;
            }
        }

        public double CrossoverProbability
        {
            get { return _crossoverProbability; }
            set
            {
                if (value < 0 || value > 1) throw new ArgumentOutOfRangeException("CrossoverProbability");
                _crossoverProbability = value;
            }
        }

        private int _populationSize = 30;
        private double _mutationProbability = .01;
        private double _crossoverProbability = .87;
    }
}