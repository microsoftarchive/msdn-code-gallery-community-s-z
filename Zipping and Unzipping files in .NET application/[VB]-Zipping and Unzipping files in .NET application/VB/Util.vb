Imports ComponentPro.IO
Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Namespace ArchiveManager
	Public NotInheritable Class Util

		Private Sub New()
		End Sub

		Private Shared _dataDir As String
		''' <summary>
		''' Gets the default samples folder.
		''' </summary>
		Public Shared ReadOnly Property DataDir() As String
			Get
				If _dataDir Is Nothing Then
					_dataDir = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory & "..\..\ArchiveManagerData")
					If Not System.IO.Directory.Exists(_dataDir) Then
						_dataDir = AppDomain.CurrentDomain.BaseDirectory & "ArchiveManagerData"
					End If
				End If

				Return _dataDir
			End Get
		End Property

		Private Shared _outputDir As String
		''' <summary>
		''' Gets the default output folder.
		''' </summary>
		Public Shared ReadOnly Property OutputDir() As String
			Get
				If _outputDir Is Nothing Then
					_outputDir = System.IO.Path.GetDirectoryName(DataDir) & "\Output"
				End If

				Return _outputDir
			End Get
		End Property

		''' <summary>
		''' Saves a key value pair to the registry.
		''' </summary>
		''' <param name="keyName">The key name.</param>
		''' <param name="value">The value.</param>
		Public Shared Sub SaveProperty(ByVal keyName As String, ByVal value As Object)
			Try
				Dim Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ComponentPro\Samples\ArchiveManagerDemo")
				Key.SetValue(keyName, value)
			Catch
				Return
			End Try
		End Sub

		''' <summary>
		''' Gets the value for the given key name from the registry.
		''' </summary>
		''' <param name="keyName">The key name.</param>
		''' <param name="defaultValue">The default value that is used when the key is not found.</param>
		Public Shared Function GetProperty(ByVal keyName As String, ByVal defaultValue As Object) As Object
			Try
				Dim Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ComponentPro\Samples\ArchiveManagerDemo")
				Return Key.GetValue(keyName, defaultValue)
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Function GetProperty(ByVal keyName As String) As Object
			Return GetProperty(keyName, Nothing)
		End Function

		Public Shared Function GetIntProperty(ByVal keyName As String, ByVal defaultValue As Integer) As Integer
			Try
				Dim Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ComponentPro\Samples\ArchiveManagerDemo")
				Return Integer.Parse(Key.GetValue(keyName, defaultValue).ToString())
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Function GetLongProperty(ByVal keyName As String, ByVal defaultValue As Long) As Long
			Try
				Dim Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\ComponentPro\Samples\ArchiveManagerDemo")
				Return Long.Parse(Key.GetValue(keyName, defaultValue).ToString())
			Catch
				Return defaultValue
			End Try
		End Function

		Public Shared Sub ShowError(ByVal exc As Exception)
			Dim fexc As FileSystemException = TryCast(exc, FileSystemException)
			If fexc IsNot Nothing AndAlso fexc.Status = FileSystemExceptionStatus.OperationCancelled Then
				Return
			End If

#If DEBUG AndAlso false Then
			Throw exc
#Else
			Dim str As String

			If exc.InnerException IsNot Nothing Then
				str = String.Format(Nothing, "An error occurred: {0}", exc.InnerException.Message)
			Else
				str = String.Format(Nothing, "An error occurred: {0}", exc.Message)
			End If


			MessageBox.Show(str, "Error")
#End If
		End Sub

		Public Shared Sub ShowError(ByVal exc As Exception, ByVal msg As String)
#If DEBUG AndAlso false Then
			Throw exc
#Else
			Dim str As String

			If exc.InnerException IsNot Nothing Then
				str = String.Format(Nothing, "{0}. An error occurred: {1}", msg, exc.InnerException.Message)
			Else
				str = String.Format(Nothing, "{0}. An error occurred: {1}", msg, exc.Message)
			End If

			MessageBox.Show(str, "Error")
#End If
		End Sub

		Private Const MF_BYCOMMAND As Integer = 0
		Private Const MF_ENABLED As Integer = &H0
		Private Const MF_GRAYED As Integer = &H1

		<DllImport("User32")> _
		Private Shared Function RemoveMenu(ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
		End Function

		<DllImport("User32")> _
		Private Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
		End Function

		<DllImport("User32")> _
		Private Shared Function EnableMenuItem(ByVal hMenu As IntPtr, ByVal hMenuItem As IntPtr, ByVal nEnable As Integer) As Boolean
		End Function

		<DllImport("User32")> _
		Private Shared Function GetMenuItemID(ByVal hMenu As IntPtr, ByVal nPos As Integer) As IntPtr
		End Function

		<DllImport("User32")> _
		Private Shared Function GetMenuItemCount(ByVal hWnd As IntPtr) As Integer
		End Function

		Private Shared ReadOnly _map As New Dictionary(Of String, Boolean)()

		''' <summary>
		''' Disables Close(X) button.
		''' </summary>
		''' <param name="form">Form object.</param>
		''' <param name="enable">Indicates whether the close button is enabled.</param>
		Private Shared Sub EnableCloseButtonInt(ByVal form As Form, ByVal enable As Boolean)
			Dim hMenu As IntPtr = GetSystemMenu(form.Handle, False)
			Dim menuItemCount As Integer = GetMenuItemCount(hMenu)
			Dim hItem As IntPtr = GetMenuItemID(hMenu, menuItemCount - 1)
			If enable Then
				EnableMenuItem(hMenu, hItem, MF_BYCOMMAND Or (MF_ENABLED))
			Else
				EnableMenuItem(hMenu, hItem, MF_BYCOMMAND Or (MF_GRAYED))
			End If
		End Sub

		''' <summary>
		''' Disables Close(X) button.
		''' </summary>
		''' <param name="form">Form object.</param>
		''' <param name="enable">Indicates whether the close button is enabled.</param>
		Public Shared Sub EnableCloseButton(ByVal form As Form, ByVal enable As Boolean)
			EnableCloseButtonInt(form, enable)

			If Not _map.ContainsKey(form.Name) Then
				SyncLock _map
					_map.Add(form.Name, enable)
					AddHandler form.Resize, AddressOf form_Resize
				End SyncLock
			Else
				_map(form.Name) = enable
			End If
		End Sub

		Private Shared Sub form_Resize(ByVal sender As Object, ByVal e As EventArgs)
			Dim form As Form = CType(sender, Form)

			If Not _map(form.Name) Then
				EnableCloseButtonInt(form, False)
			End If
		End Sub

		''' <summary>
		''' Returns a formatted file size in bytes, kbytes, or mbytes.
		''' </summary>
		''' <param name="size">The input file size.</param>
		''' <returns>The formatted file size.</returns>
		Public Shared Function FormatSize(ByVal size As Long) As String
			If size < 1024 Then
				Return size & " B"
			End If
			If size < 1024 * 1024 Then
				Return String.Format("{0:#.#} KB", size / 1024.0F)
			End If
			If size < 1024 * 1024 * 1024 Then
				Return String.Format("{0:#.#} MB", size / 1024.0F / 1024.0F)
			Else
				Return String.Format("{0:#.#} GB", size / 1024.0F / 1024.0F / 1024.0F)
			End If
		End Function
	End Class
End Namespace