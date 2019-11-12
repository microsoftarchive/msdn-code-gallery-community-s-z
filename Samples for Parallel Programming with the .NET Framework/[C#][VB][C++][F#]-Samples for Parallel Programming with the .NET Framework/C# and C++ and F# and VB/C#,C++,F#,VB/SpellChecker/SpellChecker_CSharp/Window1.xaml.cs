//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Window1.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace SpellChecker
{
    /// <summary>Spell checker application</summary>
    public partial class Window1 : Window
    {
        private List<string> _words;
        private int _maxWordLength;
        private CancellationTokenSource _cancellation;

        public Window1() { InitializeComponent(); }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = null;
            txtInput.IsEnabled = false;
            chkParallel.IsEnabled = false;

            // Ask the user for a file containing a word list, one word per line
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog(this) == true)
            {
                // If a file was provided, try to load it
                Task.Factory.StartNew(() =>
                {
                    // Read in all of the words
                    _words = new List<string>(200000);
                    using (StreamReader reader = new StreamReader(ofd.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string word = line.Trim().ToLower();
                            if (!String.IsNullOrEmpty(word))
                            {
                                _words.Add(word);
                                if (word.Length > _maxWordLength) _maxWordLength = word.Length;
                            }
                        }
                    }

                    // When we're done, enable the UI
                }).ContinueWith(t =>
                {
                    txtInput.IsEnabled = true;
                    chkParallel.IsEnabled = true;
                    if (t.IsFaulted) MessageBox.Show(t.Exception.ToString());
                    else MakeSuggestions();
                },  TaskScheduler.FromCurrentSynchronizationContext());
            }

        }

        /// <summary>Redo the suggestions when the text changes.</summary>
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e) { MakeSuggestions(); }

        /// <summary>Redo the suggestions when parallel vs non-parallel changes.</summary>
        private void chkParallel_CheckedChanged(object sender, RoutedEventArgs e) { MakeSuggestions(); }

        /// <summary>Asynchronous make suggestions for correct spellings of the provided word.</summary>
        private void MakeSuggestions()
        {
            // Limit the number of suggestions
            const int NUM_SUGGESTIONS = 25;

            // Run serially or in parallel
            var sequential = !(chkParallel.IsChecked.HasValue && chkParallel.IsChecked.Value);
            string text = txtInput.Text;

            // If there's no text to evaluate, just bail
            if (String.IsNullOrEmpty(text))
            {
                listBox1.ItemsSource = null;
                return;
            }

            // Every time the text is changed, we want to cancel the previous operation
            if (_cancellation != null) _cancellation.Cancel();
            _cancellation = new CancellationTokenSource();
            var token = _cancellation.Token;

            // Time the operation and kick it off
            Stopwatch sw = Stopwatch.StartNew();
            Task.Factory.StartNew(() =>
            {
                List<string> results = null;
                if (sequential)
                {
                    var distanceMatrix = new int[_maxWordLength + 1, _maxWordLength + 1];
                    results = _words
                        .Select(word => new { Word = word, Distance = LevenshteinDistance(word, text, distanceMatrix) })
                        .OrderBy(p => p.Distance)
                        .Take(NUM_SUGGESTIONS)
                        .Select(p => p.Word)
                        .ToList();
                }
                else
                {
                    using (var distanceMatrix = new ThreadLocal<int[,]>(() => new int[_maxWordLength + 1, _maxWordLength + 1]))
                    {
                        results = _words
                            .AsParallel().WithCancellation(token) // parallel with cancellation
                            .Select(word => new { Word = word, Distance = LevenshteinDistance(word, text, distanceMatrix.Value) })
                            .TakeTop(p => p.Distance, NUM_SUGGESTIONS) // Or .OrderBy(p => p.Distance).Take(NUM_SUGGESTIONS)
                            .Select(p => p.Word)
                            .ToList();
                    }
                }
                sw.Stop();
                return new { Results = results, Time = sw.Elapsed }; // Return both the spelling suggestions and the elapsed time
            }, token).ContinueWith(t =>
            {
                // Display the results
                listBox1.ItemsSource = t.Result.Results.Select((str, i) => string.Format("{0,2}. {1}", i+1, str));
                lblTime.Content = "Sec: " + t.Result.Time;
            }, CancellationToken.None, TaskContinuationOptions.NotOnCanceled, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>Computes the Levenshtein Edit Distance between two enumerables.</summary>
        /// <param name="str1">The first string.</param>
        /// <param name="str2">The second string.</param>
        /// <param name="scratchDistanceMatrix">Scratch space to use for the computation.</param>
        /// <returns>The computed edit distance.</returns>
        private static int LevenshteinDistance(string str1, string str2, int[,] scratchDistanceMatrix)
        {
            // distance matrix contains one extra row and column for the seed values            
            for (int i = 0; i <= str1.Length; i++) scratchDistanceMatrix[i,0] = i;
            for (int j = 0; j <= str2.Length; j++) scratchDistanceMatrix[0,j] = j;

            for (int i = 1; i <= str1.Length; i++)
            {
                int str1Index = i - 1;
                for (int j = 1; j <= str2.Length; j++)
                {
                    int str2Index = j - 1;
                    var cost = (str1[str1Index] == str2[str2Index]) ? 0 : 1;

                    int deletion = (i == 0) ? 1 : scratchDistanceMatrix[i - 1, j] + 1;
                    int insertion = (j == 0) ? 1 : scratchDistanceMatrix[i, j - 1] + 1;
                    int substitution = (i == 0 || j == 0) ? cost : scratchDistanceMatrix[i - 1, j - 1] + cost;

                    scratchDistanceMatrix[i, j] = Math.Min(Math.Min(deletion, insertion), substitution);

                    // Check for Transposition
                    if (i > 1 && j > 1 && (str1[str1Index] == str2[str2Index - 1]) && (str1[str1Index - 1] == str2[str2Index]))
                    {
                        scratchDistanceMatrix[i, j] = Math.Min(scratchDistanceMatrix[i,j], scratchDistanceMatrix[i-2, j-2] + cost);
                    }
                }
            }         

            // Levenshtein distance is the bottom right element
            return scratchDistanceMatrix[str1.Length, str2.Length];
        }
    }
}
