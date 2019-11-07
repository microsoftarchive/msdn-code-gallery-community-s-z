Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Friend NotInheritable Class ShareUtils
	Private Sub New()
	End Sub
	Friend Enum SoundType
		NewClientEntered
		NewMessageReceived
		NewMessageWithPow
		ClientExit
	End Enum
	Friend Shared Sub SaveAsHTML(fileName As String, lines As String(), titleString As String)
		Dim htmlString As String = "<HTML>" & Environment.NewLine
		Dim dateTime__1 As String = "( " & DateTime.Now.ToLongTimeString() & " )"
		htmlString += "<meta charset=utf-8/>" & Environment.NewLine
		htmlString += "<Title>" & titleString & "</Title>" & Environment.NewLine
		htmlString += "<link rel='stylesheet' href='Files/Styles.css' type='Text/Css'" & Environment.NewLine
		htmlString += "<Body>" & Environment.NewLine
		htmlString += "<Table align='center'><TR><TD class='Header'>" & titleString & "</TD><TD class='Header'>" & dateTime__1 & "</TD><TD><IMG src='Files/face.gif'/></TD></TR></Table><HR width='60%'>"
		htmlString += Environment.NewLine & "<Table>"
		For Each line As String In lines
			If line.Trim() <> "" Then
				htmlString += "<TR><TD><IMG src='Files/arrow.gif'/></TD><TD>" & line & "</TD></TR>" & Environment.NewLine
			End If
		Next
		htmlString += "</Table>"
		htmlString += Environment.NewLine & "</Body></HTML>"
		Dim dirName As String = fileName.Substring(0, fileName.LastIndexOf("\"C))
		System.IO.Directory.CreateDirectory(dirName & "\Files")
		Dim rc As New Proshot.ResourceManager.Resourcer(Proshot.ResourceManager.LoadMethod.FromCallingCode)
		rc.ExtractAndSaveToFile("face.gif", dirName & "\Files\face.gif")
		rc.ExtractAndSaveToFile("arrow.gif", dirName & "\Files\arrow.gif")
		rc.ExtractAndSaveToFile("Styles.css", dirName & "\Files\Styles.css")
		Dim fs As New System.IO.FileStream(fileName, System.IO.FileMode.Create)
		Dim sw As New System.IO.StreamWriter(fs)
		sw.Write(htmlString)
		sw.Flush()
		sw.Close()
	End Sub
	Friend Shared Sub PlaySound(soundType As ShareUtils.SoundType)
		Dim rcMngr As New Proshot.ResourceManager.Resourcer(Proshot.ResourceManager.LoadMethod.FromCallingCode)
		Dim player As New System.Media.SoundPlayer()
		Select Case soundType
			Case (ShareUtils.SoundType.NewClientEntered)
				player.Stream = rcMngr.GetResourceStream("Knock.wav")
				player.Play()
				Exit Select
			Case (ShareUtils.SoundType.ClientExit)
				player.Stream = rcMngr.GetResourceStream("Door.wav")
				player.Play()
				Exit Select
			Case (ShareUtils.SoundType.NewMessageReceived)
				player.Stream = rcMngr.GetResourceStream("Message.wav")
				player.Play()
				Exit Select
			Case (ShareUtils.SoundType.NewMessageWithPow)
				player.Stream = rcMngr.GetResourceStream("Pow.wav")
				player.Play()
				Exit Select
		End Select
	End Sub
	Friend Shared Function IsValidKeyForReadOnlyFields(key As Keys) As Boolean
		Select Case key
			Case (Keys.Up), (Keys.Down), (Keys.Left), (Keys.Right), (Keys.PageUp), (Keys.PageDown), _
				(Keys.F1), (Keys.F2), (Keys.F3), (Keys.F4), (Keys.F5), (Keys.F6), _
				(Keys.F7), (Keys.F8), (Keys.F9), (Keys.F10), (Keys.F11), (Keys.F12), _
				(Keys.F13), (Keys.F14), (Keys.F15), (Keys.F16), (Keys.F17), (Keys.F18), _
				(Keys.F19), (Keys.F20), (Keys.F21), (Keys.F22), (Keys.F23), (Keys.F24), _
				(Keys.Shift), (Keys.ShiftKey), (Keys.Control), (Keys.ControlKey), (Keys.CapsLock), (Keys.Scroll), _
				(Keys.Alt), (Keys.Apps), (Keys.[End]), (Keys.Escape), (Keys.Help), (Keys.Home), _
				(Keys.Insert), (Keys.LButton), (Keys.LControlKey), (Keys.LMenu), (Keys.MButton), (Keys.Menu), _
				(Keys.VolumeDown), (Keys.VolumeMute), (Keys.VolumeUp), (Keys.XButton1), (Keys.XButton2), (Keys.Zoom)
				Return True
			Case Else
				Return False
		End Select
	End Function

End Class

