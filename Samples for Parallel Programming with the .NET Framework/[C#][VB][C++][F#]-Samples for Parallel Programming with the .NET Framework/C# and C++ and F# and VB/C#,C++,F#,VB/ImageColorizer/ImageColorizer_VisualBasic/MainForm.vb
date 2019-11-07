'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: MainForm.vb
'
'--------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.Ink

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
	''' <summary>Main form for the application.</summary>
	Partial Public Class MainForm
		Inherits Form
		''' <summary>Initializes the main form.</summary>
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>A list of all selected points from which colors will be extracted from the image.</summary>
		Private _selectedPixels As New List(Of Point)()
		''' <summary>The last hue epsilon selected by the user.</summary>
		Private _lastEpsilon As Integer = -1
		''' <summary>The last size of the image picture box before a resize.</summary>
		Private _lastPictureBoxSize As New Size(-1, -1)
		''' <summary>A list of GraphicsPaths currently translated from Strokes.</summary>
		Private _paths As List(Of GraphicsPath)
		''' <summary>The image as originally loaded.</summary>
		Private _originalImage As Bitmap
		''' <summary>The current image after all color transformations.</summary>
		Private _colorizedImage As Bitmap
		''' <summary>The InkOverlay used for accepting strokes to be translated into GraphicsPaths.</summary>
		Private _overlay As InkOverlay

		''' <summary>Loads the form.</summary>
		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Store the current size of the picture box.  When the picture box is
			' resized (due to the form being resized), we need to scale any ink
			' that may exist on the form so that it sizes in accordance with the picture box.
			_lastPictureBoxSize = pbImage.Size
			pbImage.AllowDrop = True

            ' If the current platform supports ink, initialize the InkOverlay.
			If PlatformDetection.SupportsInk Then
				InitializeInk()
			End If

            ' Setup the help text for the toolstrip.
			lblHuesSelected.Text = String.Format(My.Resources.HuesSelectedDisplay, _selectedPixels.Count)
			tbEpsilon.ToolTipText = String.Format(My.Resources.EpsilonDisplay, tbEpsilon.Value)
		End Sub

		Private _ofd As OpenFileDialog

		''' <summary>Shows an OpenFileDialog and loads the selected image into the app.</summary>
		Private Sub btnLoadImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadImage.Click
            ' Show a dialog to select JPG files.
			If _ofd Is Nothing Then
				_ofd = New OpenFileDialog()
				_ofd.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif"
				_ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
			End If
			If _ofd.ShowDialog() = DialogResult.OK Then
				LoadImage(_ofd.FileName)
			End If
		End Sub

		Private Sub LoadImage(ByVal path As String)
			Try
				_originalImage = New Bitmap(path)
				pbImage.Image = _originalImage

				' Disable saving of the image.  We only allow saving once changes have been made.
				btnSaveImage.Enabled = False

				' Change the cursor on the picture box to let the user know they
				' can click on the image to select a hue.
                pbImage.Cursor = System.Windows.Forms.Cursors.Hand


				' If ink is available on the current machine, enable the button that
				' turns on the overlay, and clear any existing ink from previous images
                ' that may have existed in the app.
				If PlatformDetection.SupportsInk Then
					btnInk.Enabled = True
					ClearInk()
				End If
			Catch e1 As ArgumentException
			End Try
		End Sub

		''' <summary>Recomputes the image based on the newly selected pixel.</summary>
		Private Sub pbImage_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pbImage.MouseClick
            ' Only run if an image has been loaded and if ink isn't being drawn.
			If _originalImage IsNot Nothing AndAlso Not(btnInk.Enabled AndAlso btnInk.Checked) Then
				' Get the point in the original image.  To get this we need
				' to scale the selected point based on how much the image
				' is being resized for display.
				Dim p As New Point(CInt(Fix(e.X * _originalImage.Width / CDbl(pbImage.Width))), CInt(Fix(e.Y * _originalImage.Height / CDbl(pbImage.Height))))

				' Add the selected point to the list or make it the only
                ' point in the list, based on whether the shift key is being held down.
				If Control.ModifierKeys <> Keys.Shift Then
					_selectedPixels.Clear()
				End If
				_selectedPixels.Add(p)

				' With our updated list of selected pixels in hand, update
                ' the toolstrip help text.
				lblHuesSelected.Text = String.Format(My.Resources.HuesSelectedDisplay, _selectedPixels.Count)

                ' Start recomputing the image based on the new parameters.
				StartColorizeImage()
			End If
		End Sub

		Private Sub StartColorizeImage()
			' Stop the timer if it's running, since the timer's purpose
            ' is to cause this method to be called when the timer expires.
			tmRefresh.Stop()
			_lastEpsilon = tbEpsilon.Value

			' If we have an image and if a pixel has been selected
			' and if we're not currently recomputing the image...
			If _originalImage IsNot Nothing AndAlso _selectedPixels.Count > 0 AndAlso (Not bwColorize.IsBusy) Then
                ' If there are any strokes, turn them into GraphicsPaths.
				If PlatformDetection.SupportsInk Then
					If _paths IsNot Nothing Then
						For Each path As GraphicsPath In _paths
							path.Dispose()
						Next path
					End If
					_paths = InkToGraphicsPaths(True)
				End If

                ' Modify the UI for progress.
				toolStripMain.Enabled = False
				pbImage.Enabled = False
				pbColorizing.Value = 0
				pbColorizing.Visible = True

                ' Recompute the image!.
				bwColorize.RunWorkerAsync()
			End If
		End Sub

		''' <summary>Colorizes the image on a background thread.</summary>
		Private Sub bwColorize_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bwColorize.DoWork
			' Create the colorizer instance.  Any progress updates
			' will in turn update the progress through the BackgroundWorker.
			Dim colorizer As New ImageManipulation()
			AddHandler colorizer.ProgressChanged, Sub(s As Object, pcea As ProgressChangedEventArgs) bwColorize.ReportProgress(pcea.ProgressPercentage)

			' Create a clone of the original image, so that we can lock its bits
            ' while still allowing the UI to refresh and resize appropriately.
            Using workImage = _originalImage.Clone(New Rectangle(0, 0, _originalImage.Width, _originalImage.Height), PixelFormat.Format24bppRgb)
                ' Colorize the image and store the resulting Bitmap.
                e.Result = colorizer.Colorize(workImage, _selectedPixels, _lastEpsilon, _paths, btnParallel.Checked)
            End Using
		End Sub

		''' <summary>Configures the MainForm after colorization is complete.</summary>
		Private Sub bwColorize_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bwColorize.RunWorkerCompleted
            ' Reenable the UI.
			pbColorizing.Visible = False
			toolStripMain.Enabled = True
			pbImage.Enabled = True
			btnLoadImage.Enabled = True
			btnSaveImage.Enabled = True
			tbEpsilon.Focus()

            ' Rethrow any exceptions.
			If e.Error IsNot Nothing Then
				Throw New TargetInvocationException(e.Error)
			End If

            ' Get the newly computed image.
			If _colorizedImage IsNot Nothing Then
				_colorizedImage.Dispose()
			End If
			_colorizedImage = CType(e.Result, Bitmap)

            ' Set the newly computed image into the PictureBox.
			If pbImage.Image IsNot Nothing AndAlso pbImage.Image IsNot _originalImage Then
				pbImage.Image.Dispose()
			End If
			pbImage.Image = _colorizedImage
		End Sub

		''' <summary>Update the progress bar when the BackgroundWorker progress changes.</summary>
		Private Sub bwColorize_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles bwColorize.ProgressChanged
			If e.ProgressPercentage > pbColorizing.Value Then
				pbColorizing.Value = e.ProgressPercentage
			End If
		End Sub

		''' <summary>Saves the colorized image to a file.</summary>
		Private Sub btnSaveImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveImage.Click
			If _colorizedImage IsNot Nothing Then
				Dim sfd As New SaveFileDialog()
				sfd.Filter = "Image files (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.bmp;*.png;*.gif|All files (*.*)|*.*"
				sfd.DefaultExt = ".jpg"
				If sfd.ShowDialog(Me) = DialogResult.OK Then
					SaveImage(_colorizedImage, sfd.FileName, 100)
				End If
			End If
		End Sub

		''' <summary>Saves an image to a specified path and with a specified quality, if appropriate to the format.</summary>
		''' <param name="bmp">The image to be saved.</param>
		''' <param name="path">The path where to save the image.</param>
		''' <param name="quality">The quality of the image to save.</param>
		Private Shared Sub SaveImage(ByVal bmp As Bitmap, ByVal path As String, ByVal quality As Long)
            ' Validate parameters.
			If bmp Is Nothing Then
				Throw New ArgumentNullException("bmp")
			End If
			If path Is Nothing Then
				Throw New ArgumentNullException("path")
			End If
			If quality < 1 OrElse quality > 100 Then
				Throw New ArgumentOutOfRangeException("quality", quality, "Quality out of range.")
			End If

            ' Save it to a file format based on the path's extension.

            Select Case System.IO.Path.GetExtension(path).ToLowerInvariant()
                Case ".bmp"
                    bmp.Save(path, ImageFormat.Bmp)
                Case ".png"
                    bmp.Save(path, ImageFormat.Png)
                Case ".gif"
                    bmp.Save(path, ImageFormat.Gif)
                Case ".tif", ".tiff"
                    bmp.Save(path, ImageFormat.Tiff)
                Case ".jpg"

                    Dim jpegCodec = Array.Find(ImageCodecInfo.GetImageEncoders(), Function(ici As ImageCodecInfo) ici.MimeType = "image/jpeg")
                    Using codecParams As New EncoderParameters(1)
                        Using ratio As New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality)
                            ' Set the JPEG quality value and save the image.
                            codecParams.Param(0) = ratio
                            bmp.Save(path, jpegCodec, codecParams)
                        End Using
                    End Using
            End Select
		End Sub

		''' <summary>Starts the colorization process when the refresh timer expires.</summary>
		Private Sub tmRefresh_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmRefresh.Tick
			StartColorizeImage()
		End Sub

		''' <summary>Starts the refresh timer when the epsilon track bar changes value.</summary>
		Private Sub tbEpsilon_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbEpsilon.ValueChanged
			tbEpsilon.ToolTipText = String.Format(My.Resources.EpsilonDisplay, tbEpsilon.Value)
			StartRefreshTimer()
		End Sub

		''' <summary>Starts/restarts the refresh timer.</summary>
		Private Sub StartRefreshTimer()
			If _originalImage IsNot Nothing AndAlso _selectedPixels.Count > 0 AndAlso _lastEpsilon >= 0 AndAlso (Not bwColorize.IsBusy) Then
				btnLoadImage.Enabled = False
				tmRefresh.Stop()
				tmRefresh.Start()
			End If
		End Sub

		''' <summary>Resizes any ink in the picture box when it resizes.</summary>
		Private Sub pbImage_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles pbImage.Resize
			If _lastPictureBoxSize.Width > 0 AndAlso _lastPictureBoxSize.Height > 0 AndAlso PlatformDetection.SupportsInk Then
				ScaleInk()
			End If
			_lastPictureBoxSize = pbImage.Size
		End Sub

		''' <summary>Initializes the InkOverlay.</summary>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Private Sub InitializeInk()
			_overlay = New InkOverlay(pbImage, True)
			_overlay.DefaultDrawingAttributes.Width = 1
			_overlay.DefaultDrawingAttributes.Color = Color.Red
			_overlay.DefaultDrawingAttributes.IgnorePressure = True

			' When a stroke is received, we start a timer that, when expiring,
			' will cause the image to be redrawn.  This timer allows the user
			' to draw multiple strokes without the image having to be redrawn
			' after each.
			AddHandler _overlay.Stroke, Sub() StartRefreshTimer()

			' We also don't want the image to be redrawn midstroke (which
			' could happen if the user drew a stroke, causing the timer
			' to start, and then took longer than a second to draw the
			' second stroke), so when new packets are received, the timer
			' is stopped; it'll be restarted by the above when the Stroke
			' is completed.
			AddHandler _overlay.NewPackets, Sub() tmRefresh.Stop()
		End Sub

		''' <summary>Clears all ink from the overlay.</summary>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Private Sub ClearInk()
			_overlay.Ink.DeleteStrokes()
		End Sub

		''' <summary>Scales the ink in the overlay.</summary>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Private Sub ScaleInk()
			If pbImage.Size.Width > 0 AndAlso pbImage.Size.Height > 0 AndAlso _lastPictureBoxSize.Width > 0 AndAlso _lastPictureBoxSize.Height > 0 AndAlso _overlay IsNot Nothing Then
                _overlay.Ink.Strokes.Scale(pbImage.Size.Width / CSng(_lastPictureBoxSize.Width), pbImage.Size.Height / CSng(_lastPictureBoxSize.Height))
			End If
		End Sub

		''' <summary>Converts all Strokes in the overlay to GraphicsPaths.</summary>
		''' <param name="scalePath">Whether to scale the GraphicsPaths based on the current image rescaling.</param>
		''' <returns>The list of converted GraphicsPath instances.</returns>
		<MethodImpl(MethodImplOptions.NoInlining)>
		Private Function InkToGraphicsPaths(ByVal scalePath As Boolean) As List(Of GraphicsPath)
            Dim renderer = _overlay.Renderer
            Dim strokes = _overlay.Ink.Strokes

            Dim scaleX = _originalImage.Width / CSng(pbImage.Width)
            Dim scaleY = _originalImage.Height / CSng(pbImage.Height)

			If strokes.Count > 0 Then
                Using g = CreateGraphics()
                    Dim paths As New List(Of GraphicsPath)(strokes.Count)
                    For Each stroke As Stroke In strokes
                        Dim points() = stroke.GetPoints()
                        If points.Length >= 3 Then
                            For i = 0 To points.Length - 1
                                renderer.InkSpaceToPixel(g, points(i))
                                If scalePath Then
                                    points(i) = New Point(CInt(Fix(scaleX * points(i).X)), CInt(Fix(scaleY * points(i).Y)))
                                End If
                            Next i
                            Dim path As New GraphicsPath()
                            path.AddPolygon(points)
                            path.CloseFigure()
                            paths.Add(path)
                        End If
                    Next stroke
                    Return paths
                End Using
			End If
			Return Nothing
		End Function

		''' <summary>Enables or disables the InkOverlay.</summary>
		Private Sub btnInk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInk.Click
			_overlay.Enabled = Not _overlay.Enabled
			btnInk.Checked = _overlay.Enabled
			btnEraser.Enabled = btnInk.Checked
		End Sub

		''' <summary>Switches back and forth between Ink and Delete editing modes on the overlay.</summary>
		Private Sub btnEraser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEraser.Click
			_overlay.EditingMode = If((_overlay.EditingMode = InkOverlayEditingMode.Delete), InkOverlayEditingMode.Ink, InkOverlayEditingMode.Delete)
			btnEraser.Checked = _overlay.EditingMode = InkOverlayEditingMode.Delete
		End Sub

		''' <summary>Resets back to the original image.</summary>
		Private Sub lblHuesSelected_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblHuesSelected.Click
			_selectedPixels.Clear()
			pbImage.Image = _originalImage
			If _colorizedImage IsNot Nothing Then
				_colorizedImage.Dispose()
				_colorizedImage = Nothing
			End If

			lblHuesSelected.Text = String.Format(My.Resources.HuesSelectedDisplay, _selectedPixels.Count)
			lblHuesSelected.ToolTipText = Nothing
		End Sub

		''' <summary>Sets up a drag & drop affect.</summary>
		Private Sub pbImage_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles pbImage.DragEnter
			If e.Data.GetDataPresent(DataFormats.FileDrop) AndAlso (CType(e.Data.GetData(DataFormats.FileDrop), String())).Length = 1 Then
				e.Effect = DragDropEffects.Copy
			End If
		End Sub

		''' <summary>Completes a drag & drop operation, loading the dropped image.</summary>
		Private Sub pbImage_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles pbImage.DragDrop
			If e.Data.GetDataPresent(DataFormats.FileDrop) AndAlso e.Effect = DragDropEffects.Copy Then
                Dim paths() = CType(e.Data.GetData(DataFormats.FileDrop), String())
				If paths.Length = 1 Then
					LoadImage(paths(0))
				End If
			End If
		End Sub

		Private Sub btnParallel_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles btnParallel.CheckedChanged
			StartColorizeImage()
		End Sub
	End Class
End Namespace