'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainForm.vb
'
'--------------------------------------------------------------------------

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks

Namespace GameOfLife
	Partial Public Class MainForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>Used to cancel the current game.</summary>
		Private _cancellation As CancellationTokenSource
		''' <summary>The current game.</summary>
		Private _game As GameBoard

		Private Sub chkParallel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkParallel.CheckedChanged
			If _game IsNot Nothing Then
				_game.RunParallel = chkParallel.Checked
			End If
		End Sub


        ''' <summary>Run a game.</summary>
        Private Sub btnRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRun.Click
            ' If no game is currently running, run one.
            If _cancellation Is Nothing Then
                ' Clear the current image, get the size of the board to use, initialize cancellation,
                ' And prepare the form for game running.
                pictureBox1.Image = Nothing
                Dim width = pictureBox1.Width, height = pictureBox1.Height
                _cancellation = New CancellationTokenSource()
                Dim token = _cancellation.Token
                lblDensity.Visible = False
                tbDensity.Visible = False
                btnRun.Text = "Stop"
                Dim initialDensity = tbDensity.Value / 1000.0

                ' Initialize the object pool and the game board.
                Dim pool = New ObjectPool(Of Bitmap)(Function() New Bitmap(width, height))
                _game = New GameBoard(width, height, initialDensity, pool) With {.RunParallel = chkParallel.Checked}

                ' Run the game on a background thread.
                ' Run until cancellation is requested.
                ' Move to the next board, timing how long it takes.
                ' Update the UI with the new board image.
                ' When the game is done, reset the board.
                Task.Factory.StartNew(Sub()
                                          Dim sw = New Stopwatch()
                                          Do While Not token.IsCancellationRequested
                                              sw.Restart()
                                              Dim bmp = _game.MoveNext()
                                              Dim framesPerSecond = 1 / sw.Elapsed.TotalSeconds
                                              BeginInvoke((Sub()
                                                               lblFramesPerSecond.Text = String.Format("Frames / Sec: {0:F2}", framesPerSecond)
                                                               Dim old = CType(pictureBox1.Image, Bitmap)
                                                               pictureBox1.Image = bmp
                                                               If old IsNot Nothing Then
                                                                   pool.PutObject(old)
                                                               End If
                                                           End Sub))
                                          Loop
                                      End Sub, token).ContinueWith(Sub()
                                                                       _cancellation = Nothing
                                                                       btnRun.Text = "Start"
                                                                       lblDensity.Visible = True
                                                                       tbDensity.Visible = True
                                                                   End Sub, TaskScheduler.FromCurrentSynchronizationContext())

                ' If a game is currently running, cancel it.
            Else
                _cancellation.Cancel()
            End If
        End Sub
    End Class
End Namespace
