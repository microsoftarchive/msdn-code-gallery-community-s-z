'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainForm.vb
'
'--------------------------------------------------------------------------

Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Text

Namespace ShakespeareanMonkeys
    Partial Public Class MainForm
        Inherits Form

        Private Shared _targetText As String =
         "To be or not to be, that is the question;" & Environment.NewLine &
         "Whether 'tis nobler in the mind to suffer" & Environment.NewLine &
         "The slings and arrows of outrageous fortune," & Environment.NewLine & "Or to take arms against a sea of troubles," &
         Environment.NewLine & "And by opposing, end them."
        Private _uiTasks As TaskFactory

        Public Sub New()
            InitializeComponent()

            txtTarget.Text = _targetText
            _uiTasks = New TaskFactory(TaskScheduler.FromCurrentSynchronizationContext())
        End Sub

        Private _currentIteration As Integer
        Private _cancellation As CancellationTokenSource

        Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRun.Click
            If _cancellation Is Nothing Then
                _cancellation = New CancellationTokenSource()
                Dim settings = New GeneticAlgorithmSettings With {.PopulationSize = Int32.Parse(txtMonkeysPerGeneration.Text)}

                txtBestMatch.BackColor = SystemColors.Window
                lblGenerations.BackColor = SystemColors.Control
                lblGenerations.Text = "-"
                lblGenPerSec.Text = lblGenerations.Text
                lblElapsedTime.Text = "0"
                btnRun.Text = "Cancel"
                chkParallel.Visible = False

                _lastTime = DateTimeOffset.Now
                _startTime = _lastTime
                timerElapsedTime.Start()

                ' Run the work in the background.
                _cancellation = New CancellationTokenSource()
                Dim token = _cancellation.Token
                Dim runParallel = chkParallel.Checked

                ' When the task completes, update the UI.
                Task.Factory.StartNew(Sub()
                                          ' Create the new genetic algorithm.
                                          Dim ga = New TextMatchGeneticAlgorithm(runParallel, _targetText, settings)
                                          Dim bestGenome? As TextMatchGenome = Nothing
                                          _currentIteration = 1
                                          ' Iterate until a solution is found or until cancellation is requested.
                                          Do
                                              token.ThrowIfCancellationRequested()

                                              ' Move to the next generation.
                                              ga.MoveNext()
                                              ' If we've found the best solution thus far, update the UI.
                                              If bestGenome Is Nothing OrElse ga.CurrentBest.Fitness < bestGenome.Value.Fitness Then
                                                  bestGenome = ga.CurrentBest
                                                  _uiTasks.StartNew(Sub()
                                                                        txtBestMatch.Text = bestGenome.Value.Text
                                                                    End Sub)
                                                  ' If we've found the solution, bail.
                                                  If bestGenome.Value.Text = _targetText Then
                                                      Exit Do
                                                  End If
                                              End If
                                              _currentIteration += 1
                                          Loop
                                      End Sub, token).ContinueWith(Sub(t)
                                                                       timerElapsedTime.Stop()
                                                                       chkParallel.Visible = True
                                                                       btnRun.Text = "Start"
                                                                       _cancellation = Nothing

                                                                       Select Case t.Status
                                                                           Case TaskStatus.Faulted
                                                                               MsgBox(t.Exception.ToString(), MsgBoxStyle.Critical, "Error")
                                                                           Case TaskStatus.RanToCompletion
                                                                               txtBestMatch.BackColor = Color.LightGreen
                                                                               lblGenerations.BackColor = Color.LemonChiffon
                                                                       End Select

                                                                   End Sub, _uiTasks.Scheduler)

            Else
                _cancellation.Cancel()
            End If


        End Sub

        Private _startTime As DateTimeOffset = DateTimeOffset.MinValue
        Private _lastTime As DateTimeOffset = DateTimeOffset.MinValue

        Private Sub timerElapsedTime_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timerElapsedTime.Tick
            Dim now = DateTimeOffset.Now
            Dim elapsed = CInt(Fix((now - _startTime).TotalSeconds))

            lblElapsedTime.Text = elapsed.ToString()
            lblGenerations.Text = _currentIteration.ToString()

            If elapsed > 2 Then
                Dim diffSeconds = (now - _lastTime).TotalSeconds
                If diffSeconds > 0 Then
                    lblGenPerSec.Text = (CInt(Fix(_currentIteration / diffSeconds))).ToString()
                End If
            End If
        End Sub
    End Class
End Namespace
