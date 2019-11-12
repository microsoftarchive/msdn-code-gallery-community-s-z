Imports System.IO

Namespace ArchiveManager
	Partial Public Class Preview
		Inherits Form
		Private ReadOnly _soundPlayer As New System.Media.SoundPlayer()
		Private _supportedFormat As Boolean = True

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Initializes a new instance of the Preview class.
		''' </summary>
		''' <param name="fileName">The name of the file to view.</param>
		''' <param name="stream">The file stream object.</param>
		Public Sub New(ByVal fileName As String, ByVal stream As Stream)
			Me.New()
			' Make sure the file it not empty and valid.
			If stream.Length = 0 Then
				MessageBox.Show("File is empty or invalid password", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				_supportedFormat = False
				Return
			End If

			' Reset the stream's possition.
			stream.Position = 0
			' Get file name extension.
			Dim extension As String = Path.GetExtension(fileName).ToLower()
			Select Case extension
				' Image?
				Case ".jpeg", ".jpg", ".gif", ".bmp", ".png", ".ico"
					' Then show the picture control.
					ShowImage(stream)

				' Text file?
				Case ".txt"
					' Then show the textbox control.
					ShowText(stream, False)
				' Rich text file?
				Case ".rtf"
					' Then show the rich textbox control.
					ShowText(stream, True)

				' Sound file?
				Case ".wav"
					' Then play the sound file.
					PlaySound(stream)

				Case Else 'if we don't know then tell the user and  show as text
					If MessageBox.Show("This file is an unknown format" & vbLf & "and may not preview properly" & vbLf & "Would you like to preview?", "Warning: Unknown file format", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
						ShowText(stream, False)
					Else
						Me._supportedFormat = False
					End If
			End Select
		End Sub

		''' <summary>
		''' Gets the boolean flag indicating whether the provided file is supported.
		''' </summary>
		Public ReadOnly Property SupportedFormat() As Boolean
			Get
				Return _supportedFormat
			End Get
		End Property

		''' <summary>
		''' Loads data from the specified stream and show the picture control.
		''' </summary>
		''' <param name="stream">The file stream object.</param>
		Private Sub ShowImage(ByVal stream As Stream)
			Try
				' Load image from the stream.
				Dim img As Image = Image.FromStream(stream)
				pbPreview.Visible = True
				' Adjust width and height.
				If img.Width < 200 Then
					Me.Width = 200
				Else
					Me.Width = img.Width + 4
				End If

				If img.Height < 200 Then
					Me.Height = 200
				Else
					Me.Height = img.Height + 70
				End If
				pbPreview.Image = Image.FromStream(stream)
				pbPreview.SizeMode = PictureBoxSizeMode.CenterImage
			Catch ex As Exception
				_supportedFormat = False
				Util.ShowError(ex, "Error: Unable to Display the Image.")
				Me.Close()
			End Try
		End Sub

		''' <summary>
		''' Loads data from the specified stream and show the text box control.
		''' </summary>
		''' <param name="stream">The file stream object.</param>
		''' <param name="richContent">The boolean flag indicating whether to show the rich textbox.</param>
		Private Sub ShowText(ByVal stream As Stream, ByVal richContent As Boolean)
			If richContent Then
				' Load text from the stream.
				txtPreview.LoadFile(stream, RichTextBoxStreamType.RichText)
				txtPreview.Visible = True
			Else
				' Load text from the stream.
				txtPreview.LoadFile(stream, RichTextBoxStreamType.PlainText)
				txtPreview.Visible = True
			End If
		End Sub

		''' <summary>
		''' Loads data from the specified stream and play the sound data.
		''' </summary>
		''' <param name="stream">The file stream object.</param>
		Private Sub PlaySound(ByVal stream As Stream)
			Try
				lblPlaying.Visible = True
				Me.Height = lblPlaying.Height + 74
				btnClose.Text = "Stop"

				' Load sound data from the stream.
				_soundPlayer.LoadAsync()
				_soundPlayer.Stream = stream
				' Play it.
				_soundPlayer.Play()
			Catch ex As Exception
				_supportedFormat = False
				Util.ShowError(ex, "Error: Unable to play the Sound File.")
				Me.Close()
			End Try
		End Sub

		''' <summary>
		''' Handles the form's Closing event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
			MyBase.OnClosing(e)

			' Stop the sound before leaving.
			_soundPlayer.Stop()
		End Sub
	End Class
End Namespace