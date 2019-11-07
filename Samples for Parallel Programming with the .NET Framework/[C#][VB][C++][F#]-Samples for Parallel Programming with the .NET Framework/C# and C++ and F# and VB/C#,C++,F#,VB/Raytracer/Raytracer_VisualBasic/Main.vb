'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Main.vb
'
'--------------------------------------------------------------------------

Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Public Class Main

    Private _showThreads As Boolean
    Private _parallel As Boolean
    Private _degreeOfParallelism As Int32 = Environment.ProcessorCount
    Private _cancellation As CancellationTokenSource

    Private _width, _height As Int32
    Private _bitmap As Bitmap
    Private _rect As Rectangle
    Private _freeBuffers As ObjectPool(Of Int32())

    Private Sub btnStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStop.Click
        ' If we already have the rendering task created, then we're currently running.
        ' In that case, stop the renderer.
        If _cancellation IsNot Nothing Then
            btnStartStop.Enabled = False
            _cancellation.Cancel()
        Else
            ' Set up the image in the picture box and start the rendering loop with a new rendering task
            ConfigureImage()
            _showThreads = chkShowThreads.Checked
            _cancellation = New CancellationTokenSource()
            Dim token = _cancellation.Token
            Task.Factory.StartNew(AddressOf RenderLoop, token, token).
                ContinueWith(Sub(c)
                                 chkParallel.Enabled = True
                                 chkShowThreads.Enabled = chkParallel.Checked
                                 btnStartStop.Enabled = True
                                 btnStartStop.Text = "Start"
                                 _cancellation = Nothing
                             End Sub, TaskScheduler.FromCurrentSynchronizationContext())
            chkShowThreads.Enabled = False
            chkParallel.Enabled = False
            btnStartStop.Text = "Stop"
        End If
    End Sub

    Private Function FixUpFormAfterRendering() As Boolean
        btnStartStop.Enabled = True
        chkParallel.Enabled = True
        btnStartStop.Text = "Start"
        Return True
    End Function

    Private Sub ConfigureImage()
        ' If we need to create a new bitmap, do so
        If _bitmap Is Nothing OrElse _bitmap.Width <> pbRenderedImage.Width OrElse _bitmap.Height <> pbRenderedImage.Height Then
            ' Dispose of the old one if one exists
            If _bitmap IsNot Nothing Then
                pbRenderedImage.Image = Nothing
                _bitmap.Dispose()
            End If

            ' We always render a square even if the window isn't square
            Dim min = Math.Min(pbRenderedImage.Width, pbRenderedImage.Height)
            _width = min
            _height = min

            ' Resize the rendering arrays accordingly
            _freeBuffers = New ObjectPool(Of Int32())(Function() New Int32(_width * _height - 1) {})

            ' Create a new Bitmap and set it into the picture box
            _bitmap = New Bitmap(_width, _height, PixelFormat.Format32bppRgb)
            _rect = New Rectangle(0, 0, _width, _height)
            pbRenderedImage.Image = _bitmap
        End If
    End Sub

    Private Sub RenderLoop(ByVal boxedToken As Object)

        Dim token = DirectCast(boxedToken, CancellationToken)

        ' Create a ray tracer, and create a reference to "sphere2" that we are going to bounce
        Dim rayTracer = New RayTracer(_width, _height)
        Dim scene = rayTracer.DefaultScene
        Dim sphere2 = DirectCast(scene.Things(0), Sphere) ' The first item is assumed to be our sphere
        Dim baseY = sphere2.Radius
        sphere2.Center.Y = sphere2.Radius

        ' Timing determines how fast the ball bounces as well as diagnostics frames/second info
        Dim renderingTime = New Stopwatch()
        Dim totalTime = Stopwatch.StartNew()

        ' Keep rendering until the rendering task has been canceled
        While True
            token.ThrowIfCancellationRequested()

            ' Get the next buffer
            Dim rgb = _freeBuffers.GetObject()

            ' Determine the new position of the sphere based on the current time elapsed
            Dim dy2 = 0.8 * Math.Abs(Math.Sin(totalTime.ElapsedMilliseconds * Math.PI / 3000))
            sphere2.Center.Y = baseY + dy2

            ' Render the scene
            renderingTime.Reset()
            renderingTime.Start()
            Try
                Dim options = New ParallelOptions() With {.MaxDegreeOfParallelism = _degreeOfParallelism, .CancellationToken = _cancellation.Token}
                If Not _parallel Then
                    rayTracer.RenderSequential(scene, rgb)
                ElseIf _showThreads Then
                    rayTracer.RenderParallelShowingThreads(scene, rgb, options)
                Else
                    rayTracer.RenderParallel(scene, rgb, options)
                End If
            Catch ex As OperationCanceledException
            End Try
            renderingTime.Stop()

            ' Update the bitmap in the UI thread
            Dim framesPerSecond = (1000.0 / renderingTime.ElapsedMilliseconds)
            Dim a = Sub()
                        ' Copy the pixel array into the bitmap
                        Dim bmpData = _bitmap.LockBits(_rect, ImageLockMode.WriteOnly, _bitmap.PixelFormat)
                        Marshal.Copy(rgb, 0, bmpData.Scan0, rgb.Length)
                        _bitmap.UnlockBits(bmpData)
                        _freeBuffers.PutObject(rgb)

                        ' Refresh the UI
                        pbRenderedImage.Invalidate()
                        Text = "Ray Tracer - FPS: " + framesPerSecond.ToString("F1")
                    End Sub
            BeginInvoke(a)
        End While
    End Sub

    Private Sub chkParallel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkParallel.CheckedChanged
        _parallel = chkParallel.Checked
        lblNumProcs.Enabled = chkParallel.Checked
        tbNumProcs.Enabled = chkParallel.Checked
        chkShowThreads.Enabled = chkParallel.Checked
    End Sub

    Private Sub tbNumProcs_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbNumProcs.ValueChanged
        lblNumProcs.Text = tbNumProcs.Value.ToString()
        _degreeOfParallelism = tbNumProcs.Value
    End Sub

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        tbNumProcs.Minimum = 1
        tbNumProcs.Maximum = Environment.ProcessorCount
        tbNumProcs.Value = tbNumProcs.Maximum
        lblNumProcs.Text = tbNumProcs.Value.ToString()
    End Sub
End Class