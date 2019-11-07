'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Window1.xaml.vb
'
'--------------------------------------------------------------------------

Imports System.IO
Imports System.Threading.Tasks
Imports System.Threading
Imports Microsoft.Win32

Namespace SpellChecker
	''' <summary>Spell checker application</summary>
	Partial Public Class Window1
		Inherits Window
		Private _words As List(Of String)
		Private _maxWordLength As Integer
		Private _cancellation As CancellationTokenSource

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			listBox1.ItemsSource = Nothing
			txtInput.IsEnabled = False
			chkParallel.IsEnabled = False

            ' Ask the user for a file containing a word list, one word per line.
			Dim ofd As New OpenFileDialog()
			ofd.Multiselect = False
			If ofd.ShowDialog(Me) = True Then
                ' If a file was provided, try to load it.
                ' Read in all of the words.
                ' When we're done, enable the UI.
                Task.Factory.StartNew(Sub()
                                          _words = New List(Of String)(200000)
                                          Using reader As New StreamReader(ofd.FileName)
                                              Dim line As String
                                              line = reader.ReadLine()
                                              Do While line IsNot Nothing
                                                  Dim word = line.Trim().ToLower()
                                                  If Not String.IsNullOrEmpty(word) Then
                                                      _words.Add(word)
                                                      If word.Length > _maxWordLength Then
                                                          _maxWordLength = word.Length
                                                      End If
                                                  End If
                                                  line = reader.ReadLine()
                                              Loop
                                          End Using
                                      End Sub).
                                  ContinueWith(Sub(t)
                                                   txtInput.IsEnabled = True
                                                   chkParallel.IsEnabled = True
                                                   If t.IsFaulted Then
                                                       MsgBox(t.Exception.ToString())
                                                   Else
                                                       MakeSuggestions()
                                                   End If
                                               End Sub, TaskScheduler.FromCurrentSynchronizationContext())
            
            End If

		End Sub

		''' <summary>Redo the suggestions when the text changes.</summary>
		Private Sub txtInput_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
			MakeSuggestions()
		End Sub

		''' <summary>Redo the suggestions when parallel vs non-parallel changes.</summary>
		Private Sub chkParallel_CheckedChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MakeSuggestions()
		End Sub

        '' <summary>Asynchronous make suggestions for correct spellings of the provided word.</summary>

        Private Sub MakeSuggestions()
            ' Limit the number of suggestions.
            Const NUM_SUGGESTIONS = 25

            ' Run serially or in parallel.
            Dim sequential = Not (chkParallel.IsChecked.HasValue AndAlso chkParallel.IsChecked.Value)
            Dim text = txtInput.Text

            ' If there's no text to evaluate, just bail.
            If String.IsNullOrEmpty(text) Then
                listBox1.ItemsSource = Nothing
                Return
            End If

            ' Every time the text is changed, we want to cancel the previous operation.
            If _cancellation IsNot Nothing Then
                _cancellation.Cancel()
            End If
            _cancellation = New CancellationTokenSource()
            Dim token = _cancellation.Token

            ' Time the operation and kick it off.
            Dim sw = Stopwatch.StartNew()

            Task.Factory.StartNew(Function()
                                      ' Return both the spelling suggestions and the elapsed time
                                      Dim results As List(Of String) = Nothing
                                      If sequential Then
                                          Dim distanceMatrix = New Integer(_maxWordLength, _maxWordLength) {}
                                          results = _words.
                                              Select(Function(word) New With {Key .Word = word, Key .Distance = LevenshteinDistance(word, text, distanceMatrix)}).
                                              OrderBy(Function(p) p.Distance).
                                              Take(NUM_SUGGESTIONS).
                                              Select(Function(p) p.Word).
                                              ToList()
                                      Else
                                          Using distanceMatrix = New ThreadLocal(Of Integer(,))(Function() New Integer(_maxWordLength, _maxWordLength) {})
                                              results = _words.AsParallel().WithCancellation(token).
                                                  Select(Function(word) New With {Key .Word = word, .Distance = LevenshteinDistance(word, text, distanceMatrix.Value)}).
                                                  TakeTop(Function(p) p.Distance, NUM_SUGGESTIONS).
                                                  Select(Function(p) p.Word).
                                                  ToList()
                                          End Using
                                      End If
                                      sw.Stop()
                                      Return New With {.Results = results, .Time = sw.Elapsed}
                                  End Function, token).ContinueWith(Sub(t)
                                                                        listBox1.ItemsSource =
                                                                            t.Result.Results.[Select](Function(str, i) String.Format("{0,2}. {1}", i + 1, str))
                                                                        lblTime.Content = Convert.ToString("Sec: ") & Convert.ToString(t.Result.Time)
                                                                    End Sub, CancellationToken.None, TaskContinuationOptions.NotOnCanceled,
                                                                    TaskScheduler.FromCurrentSynchronizationContext)
        End Sub

        
        ''' <summary>Computes the Levenshtein Edit Distance between two enumerables.</summary>
        ''' <param name="str1">The first string.</param>
        ''' <param name="str2">The second string.</param>
        ''' <param name="scratchDistanceMatrix">Scratch space to use for the computation.</param>
        ''' <returns>The computed edit distance.</returns>
        Private Shared Function LevenshteinDistance(ByVal str1 As String, ByVal str2 As String, ByVal scratchDistanceMatrix(,) As Integer) As Integer
            ' Distance matrix contains one extra row and column for the seed values.            
            For i = 0 To str1.Length
                scratchDistanceMatrix(i, 0) = i
            Next i
            For j = 0 To str2.Length
                scratchDistanceMatrix(0, j) = j
            Next j

            For i = 1 To str1.Length
                Dim str1Index = i - 1
                For j = 1 To str2.Length
                    Dim str2Index = j - 1
                    Dim cost = If((str1.Chars(str1Index) = str2.Chars(str2Index)), 0, 1)

                    Dim deletion = If((i = 0), 1, scratchDistanceMatrix(i - 1, j) + 1)
                    Dim insertion = If((j = 0), 1, scratchDistanceMatrix(i, j - 1) + 1)
                    Dim substitution = If((i = 0 OrElse j = 0), cost, scratchDistanceMatrix(i - 1, j - 1) + cost)

                    scratchDistanceMatrix(i, j) = Math.Min(Math.Min(deletion, insertion), substitution)

                    ' Check for Transposition.
                    If i > 1 AndAlso j > 1 AndAlso (str1.Chars(str1Index) = str2.Chars(str2Index - 1)) AndAlso (str1.Chars(str1Index - 1) = str2.Chars(str2Index)) Then
                        scratchDistanceMatrix(i, j) = Math.Min(scratchDistanceMatrix(i, j), scratchDistanceMatrix(i - 2, j - 2) + cost)
                    End If
                Next j
            Next i

            ' Levenshtein distance is the bottom right element.
            Return scratchDistanceMatrix(str1.Length, str2.Length)
        End Function
    End Class
End Namespace
