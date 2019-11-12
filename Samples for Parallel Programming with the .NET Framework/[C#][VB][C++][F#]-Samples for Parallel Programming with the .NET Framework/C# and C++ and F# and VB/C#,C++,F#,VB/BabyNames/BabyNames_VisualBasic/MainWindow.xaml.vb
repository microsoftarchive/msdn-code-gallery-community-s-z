'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainWindow.xaml.vb
'
'--------------------------------------------------------------------------

Imports System.Threading.Tasks
Imports System.Windows.Threading

Namespace BabyNames
	''' <summary>Baby Names</summary>
	Partial Public Class Window1
		Inherits Window
        Private Const YEAR_START As Integer = 1960, YEAR_END As Integer = 2005
		Private Const Y_SCALE_MAX As Integer = 1000
		Private Const RUN_MULTIPLIER As Integer = 10
		Private Const DATA_TO_USE_FORMAT As String = "Data To Use: {0} records"
		Private Const PROCESSORS_TO_USE_FORMAT As String = "Processors To Use: {0}"

		Private _userQuery As New QueryData()
		Private _babies As New List(Of BabyInfo)()
		Private _parallelQuery As ParallelQuery(Of BabyInfo)
		Private _sequentialQuery As IEnumerable(Of BabyInfo)
		Private _lastSeqRun As Long = 0, _lastParRun As Long = 0
		Private _sizeChangedTimer As DispatcherTimer
		Private _uiTasks As TaskFactory

		Public Sub New()
			' Initialize controls
			InitializeComponent()

			' Setup a timer for the slider control so that we don't load for every single tick change
			_sizeChangedTimer = New DispatcherTimer With {.Interval = TimeSpan.FromSeconds(.5)}
			AddHandler _sizeChangedTimer.Tick, Sub(sender, e)
				CType(sender, DispatcherTimer).Stop()
				LoadAsync(CInt(Fix(slNumRecords.Value)))
			End Sub
		End Sub

		Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Create a UI task factory
			_uiTasks = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext())

			' Set up the processors slider
			slProcessorsToUse.Minimum = 1
			slProcessorsToUse.Value = Environment.ProcessorCount
			slProcessorsToUse.Maximum = slProcessorsToUse.Value

			' Setup the label controls for the sliders
			lblProcessorsToUse.Content = String.Format(PROCESSORS_TO_USE_FORMAT, CInt(Fix(slProcessorsToUse.Value)))
			lblSize.Content = String.Format(DATA_TO_USE_FORMAT, CInt(Fix(slNumRecords.Value)))

			' Load the data for the app
			LoadAsync(CInt(Fix(slNumRecords.Value)))
		End Sub

		Private Sub btnRunLinq_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Run sequentially
			RunQuery(Function() _sequentialQuery.ToList(), graphLinq, lblLinqTime)
		End Sub

		Private Sub btnRunPlinq_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Run in parallel
			RunQuery(Function() _parallelQuery.ToList(), graphPlinq, lblPlinqTime)
		End Sub

		Friend Class QueryData
			Public Name, State As String
		End Class

		Private Sub RunQuery(ByVal query As Func(Of List(Of BabyInfo)), ByVal targetGraph As Graph, ByVal targetLabel As Label)
			' Get query info values from the text box.
			_userQuery.Name = txtQueryName.Text.Trim()
			_userQuery.State = txtQueryState.Text.Trim()
			If _userQuery.Name.Length = 0 OrElse _userQuery.State.Length = 0 Then
				Return
			End If

			' Disable UI interaction
			lblSpeedup.Visibility = Visibility.Hidden
			targetLabel.Visibility = Visibility.Hidden
			targetGraph.Visibility = Visibility.Hidden
			ConfigureUiControls(False)

			' Do query asynchronously
				
            Task.Factory.StartNew(Sub()
                                      'Execute and time the query:
                                      Dim results As List(Of BabyInfo) = Nothing
                                      Dim sw = Stopwatch.StartNew()

                                      For i = 0 To RUN_MULTIPLIER - 1
                                          results = query()
                                      Next i
                                      sw.Stop()

                                      'Update the UI
                                      _uiTasks.StartNew(Sub()
                                                            'Update the run time
                                                            If targetLabel.Equals(lblLinqTime) Then
                                                                _lastSeqRun = sw.ElapsedTicks
                                                            End If

                                                            'Update the graph
                                                            targetGraph.Configure(results)
                                                            targetGraph.Visibility = Windows.Visibility.Visible
                                                            targetGraph.InvalidateVisual()

                                                            'Display the execution time
                                                            targetLabel.Content = String.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0))
                                                            targetLabel.Visibility = Windows.Visibility.Visible

                                                            'Show any speedup
                                                            If _lastSeqRun <> 0 AndAlso _lastParRun <> 0 Then
                                                                lblSpeedup.Content = String.Format("{0:F2}x speedup", CSng(_lastSeqRun) / _lastParRun)
                                                                lblSpeedup.Visibility = Visibility.Visible
                                                            End If

                                                            'Allow the user to interact again
                                                            ConfigureUiControls(True)

                                                        End Sub)
                                  End Sub)

		End Sub

		Private Sub LoadAsync(ByVal numRecords As Integer)
			' Loading new data, so hide and reset old timings
			lblSpeedup.Visibility = Visibility.Hidden
			lblPlinqTime.Visibility = lblSpeedup.Visibility
			lblLinqTime.Visibility = lblPlinqTime.Visibility
			_lastParRun = 0
			_lastSeqRun = _lastParRun

			' Clear the screen
			graphPlinq.Visibility = Visibility.Hidden
			graphLinq.Visibility = graphPlinq.Visibility
			ConfigureUiControls(False)

			' Load all of the names asynchronously; when done, update the UI
			Task.Factory.StartNew(Sub()
				_babies = DataLoader.GenerateRandom(numRecords, YEAR_START, YEAR_END)
				_uiTasks.StartNew(Sub()
					InitializeQueries()
					ConfigureUiControls(True)
				End Sub)
			End Sub)
		End Sub

		Private Sub ConfigureUiControls(ByVal allowUserInteraction As Boolean)
			' Controls that the user can interact with
			slNumRecords.IsEnabled = allowUserInteraction
			slProcessorsToUse.IsEnabled = slNumRecords.IsEnabled
			btnRunPlinq.IsEnabled = slProcessorsToUse.IsEnabled
			btnRunLinq.IsEnabled = btnRunPlinq.IsEnabled
			txtQueryState.IsEnabled = btnRunLinq.IsEnabled
			txtQueryName.IsEnabled = txtQueryState.IsEnabled
		End Sub


		Private Sub slSize_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
			' Handle data size slider updates
			If slNumRecords.IsVisible Then
				lblSize.Content = String.Format(DATA_TO_USE_FORMAT, CInt(Fix(slNumRecords.Value)))
				_sizeChangedTimer.Stop()
				_sizeChangedTimer.Start()
			End If
		End Sub

		Private Sub slProcessorsToUse_ValueChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))
			' Handle processors to use updates
			If slProcessorsToUse.IsVisible Then
				lblProcessorsToUse.Content = String.Format(PROCESSORS_TO_USE_FORMAT, CInt(Fix(slProcessorsToUse.Value)))
				InitializeQueries()
			End If
		End Sub
	End Class
End Namespace
