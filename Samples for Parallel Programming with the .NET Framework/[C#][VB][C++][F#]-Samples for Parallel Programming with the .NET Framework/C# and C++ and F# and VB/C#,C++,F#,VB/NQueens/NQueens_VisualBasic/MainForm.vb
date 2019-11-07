'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainForm.vb
'
'--------------------------------------------------------------------------

Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainForm

    Private _uiScheduler As TaskScheduler
    Private _serial As DataPoint
    Private _parallel As DataPoint
    Private _max As Double = 0

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext()
        SetupPoints()
    End Sub

    Private Sub SetupPoints()
        _serial = chart1.Series(0).Points(chart1.Series(0).Points.AddXY("Serial", 0.0))
        _parallel = chart1.Series(0).Points(chart1.Series(0).Points.AddXY("Parallel", 0.0))
        chart1.ChartAreas(0).AxisY.Minimum = 0.0
        chart1.ChartAreas(0).AxisY.Maximum = 10.0
        ClearPointValues()
        Invalidate()
    End Sub

    Private Sub ClearPointValues()
        For Each Point In New DataPoint() {_serial, _parallel}
            With Point
                .SetValueY(0)
                .ToolTip = ""
                .Label = ""
                .Font = New System.Drawing.Font(Point.Font, System.Drawing.FontStyle.Bold)
            End With

        Next
        chart1.Invalidate()
    End Sub


    Private Sub btnSolve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolve.Click
        Dim numQueens = 0
        If Int32.TryParse(cbNumQueens.Text, numQueens) = False Then Return

        btnSolve.Enabled = False
        progressBar1.Visible = True

        ClearPointValues()
        _max = 0

        Task.Factory.StartNew(Sub()
                                  Dim elapsed As TimeSpan

                                  elapsed = Time(Sub()
                                                     NQueensSolver.Sequential(numQueens)
                                                 End Sub)
                                  SetPoint(_serial, elapsed.TotalSeconds)

                                  elapsed = Time(Sub()
                                                     NQueensSolver.Parallel(numQueens)
                                                 End Sub)
                                  SetPoint(_parallel, elapsed.TotalSeconds)
                              End Sub
        ).ContinueWith(Sub(t)
                           progressBar1.Visible = False
                           btnSolve.Enabled = True
                           If t.IsFaulted Then  MessageBox.Show(t.Exception.ToString())
                       End Sub, _uiScheduler)
    End Sub


    Private Sub SetPoint(ByVal point As DataPoint, ByVal seconds As Double)
        Task.Factory.StartNew(Sub()
                                  If seconds > _max Then
                                      _max = seconds
                                      chart1.ChartAreas(0).AxisY.Maximum = _max * 1.1
                                  End If
                                  point.SetValueY(seconds)
                                  point.ToolTip = seconds.ToString("F3")
                                  point.Label = String.Format("{0:F3} secs  ({1:F2}x)", seconds, (_max / seconds))
                                  chart1.Invalidate()
                              End Sub, CancellationToken.None, TaskCreationOptions.None, _uiScheduler)
    End Sub

    Private Shared Function Time(ByVal action As Action) As TimeSpan
        Dim sw = Stopwatch.StartNew()
        action()
        Return sw.Elapsed
    End Function
End Class
