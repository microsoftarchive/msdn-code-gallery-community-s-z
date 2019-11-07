Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.SaveAsImage
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Dim application As SolidEdgeFramework.Application = Nothing
			Dim documents As SolidEdgeFramework.Documents = Nothing
			Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing
			Dim window As SolidEdgeFramework.Window = Nothing
			Dim sheetWindow As SolidEdgeDraft.SheetWindow = Nothing

			Try
				Console.WriteLine("Registering OleMessageFilter.")

				' Register with OLE to handle concurrency issues on the current thread.
				OleMessageFilter.Register()

				Console.WriteLine("Connecting to Solid Edge.")

				' Connect to or start Solid Edge.
				application = SolidEdgeUtils.Connect(True)

				' Make sure user can see the GUI.
				application.Visible = True

				' Bring Solid Edge to the foreground.
				application.Activate()

				' Get a reference to the Documents collection.
				documents = application.Documents

				' This check is necessary because application.ActiveDocument will throw an
				' exception if no documents are open...
				If documents.Count > 0 Then
					' Attempt to connect to ActiveDocument.
					document = CType(application.ActiveDocument, SolidEdgeFramework.SolidEdgeDocument)
				End If

				' Make sure we have a document.
				If document Is Nothing Then
					Throw New System.Exception("No active document.")
				End If

				' 3D windows are of type SolidEdgeFramework.Window.
				window = TryCast(application.ActiveWindow, SolidEdgeFramework.Window)

				' 2D windows are of type SolidEdgeDraft.SheetWindow.
				sheetWindow = TryCast(application.ActiveWindow, SolidEdgeDraft.SheetWindow)

				If window IsNot Nothing Then
					SaveAsImage(window)
				ElseIf sheetWindow IsNot Nothing Then
					SaveAsImage(sheetWindow)
				End If
			Catch ex As System.Exception
#If DEBUG Then
				System.Diagnostics.Debugger.Break()
#End If
				Console.WriteLine(ex.Message)
			End Try
		End Sub

		Private Shared Sub SaveAsImage(ByVal window As SolidEdgeFramework.Window)
			Dim extensions() As String = { ".jpg", ".bmp", ".tif" }
			Dim view As SolidEdgeFramework.View = Nothing
			Dim guid As Guid = System.Guid.NewGuid()
			Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)

			Dim resolution As Double = 1 ' DPI - Larger values have better quality but also lead to larger file.
			Dim colorDepth As Integer = 24
			Dim width As Integer = window.UsableWidth
			Dim height As Integer = window.UsableHeight

			' Get a reference to the 3D view.
			view = window.View

			' Save each extension.
			For Each extension As String In extensions
				' File saved to desktop.
				Dim filename As String = Path.ChangeExtension(guid.ToString(), extension)
				filename = Path.Combine(folder, filename)

				' You can specify .bmp (Windows Bitmap), .tif (TIFF), or .jpg (JPEG).
				view.SaveAsImage(Filename:= filename, Width:= width, Height:= height, AltViewStyle:= Nothing, Resolution:= resolution, ColorDepth:= colorDepth, ImageQuality:= SolidEdgeFramework.SeImageQualityType.seImageQualityHigh, Invert:= False)

				Console.WriteLine("Saved '{0}'.", filename)
			Next extension
		End Sub

		Private Shared Sub SaveAsImage(ByVal sheetWidow As SolidEdgeDraft.SheetWindow)
			Dim extensions() As String = { ".jpg", ".bmp", ".tif" }
			Dim guid As Guid = System.Guid.NewGuid()
			Dim folder As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)

			Dim resolution As Double = 1 ' DPI - Larger values have better quality but also lead to larger file.
			Dim colorDepth As Integer = 24
			Dim width As Integer = sheetWidow.UsableWidth
			Dim height As Integer = sheetWidow.UsableHeight

			' Save each extension.
			For Each extension As String In extensions
				' File saved to desktop.
				Dim filename As String = Path.ChangeExtension(guid.ToString(), extension)
				filename = Path.Combine(folder, filename)

				' You can specify .bmp (Windows Bitmap), .tif (TIFF), or .jpg (JPEG).
				sheetWidow.SaveAsImage(FileName:= filename, Width:= width, Height:= height, Resolution:= resolution, ColorDepth:= colorDepth, ImageQuality:= SolidEdgeFramework.SeImageQualityType.seImageQualityHigh, Invert:= False)

				Console.WriteLine("Saved '{0}'.", filename)
			Next extension
		End Sub
	End Class
End Namespace
