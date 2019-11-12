Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Text

Namespace SolidEdge.AddIn.EdgeBar
	''' <summary>
	''' Controller class for ISolidEdgeBarEx.
	''' </summary>
	Public Class EdgeBarController
		Implements SolidEdgeFramework.ISEAddInEdgeBarEvents, IDisposable

		Private _disposed As Boolean = False
		Private _myAddIn As MyAddIn
		Private _edgeBar As SolidEdgeFramework.ISolidEdgeBarEx
		Private _connectionPointDictionary As New Dictionary(Of IConnectionPoint, Integer)()
		Private _edgeBarPageDictionary As New Dictionary(Of IntPtr, EdgeBarPage)()

'INSTANT VB NOTE: The parameter myAddIn was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Public Sub New(ByVal myAddIn_Renamed As MyAddIn)
			_myAddIn = myAddIn_Renamed
			_edgeBar = CType(_myAddIn.AddIn, SolidEdgeFramework.ISolidEdgeBarEx)

			HookEvents(_myAddIn.AddIn, GetType(SolidEdgeFramework.ISEAddInEdgeBarEvents).GUID)
		End Sub

		Protected Overrides Sub Finalize()
			Dispose(False)
		End Sub

		#Region "SolidEdgeFramework.ISEAddInEdgeBarEvents"

		''' <summary>
		''' Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.AddPage event.
		''' </summary>
		Public Sub AddPage(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEAddInEdgeBarEvents.AddPage
			AddPage(theDocument, New SelectSetEdgeBarControl())
		End Sub

		''' <summary>
		''' Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.IsPageDisplayable event.
		''' </summary>
		Public Sub IsPageDisplayable(ByVal theDocument As Object, ByVal EnvironmentCatID As String, <System.Runtime.InteropServices.Out()> ByRef vbIsPageDisplayable As Boolean) Implements SolidEdgeFramework.ISEAddInEdgeBarEvents.IsPageDisplayable
			vbIsPageDisplayable = True
		End Sub

		''' <summary>
		''' Implementation of SolidEdgeFramework.ISEAddInEdgeBarEvents.RemovePage event.
		''' </summary>
		Public Sub RemovePage(ByVal theDocument As Object) Implements SolidEdgeFramework.ISEAddInEdgeBarEvents.RemovePage
			' We use the IUnknown pointer of the document as the dictionary key.
			Dim pUnk As IntPtr = Marshal.GetIUnknownForObject(theDocument)
			Marshal.Release(pUnk)

			' If we have an EdgeBarPage for the document, remove it.
			If _edgeBarPageDictionary.ContainsKey(pUnk) Then
				RemovePage(_edgeBarPageDictionary(pUnk))
			End If
		End Sub

		#End Region

		#Region "EdgeBarController methods"

		Private Function AddPage(ByVal theDocument As Object, ByVal edgeBarControl As EdgeBarControl) As EdgeBarPage
			Dim edgeBarPage As EdgeBarPage = Nothing
			Dim hWndPage As IntPtr = IntPtr.Zero

			' We use the IUnknown pointer of the document as the dictionary key.
			Dim pUnk As IntPtr = Marshal.GetIUnknownForObject(theDocument)
			Marshal.Release(pUnk)

			' Only add a new EdgeBarPage if one hasn't already been added.
			If Not _edgeBarPageDictionary.ContainsKey(pUnk) Then
				If _myAddIn.ResourceAssembly IsNot Nothing Then
					Dim resourceAssembly As System.Reflection.Assembly = _myAddIn.ResourceAssembly

					' If ResourceAssembly is null, default to the currently executing assembly.
					If resourceAssembly Is Nothing Then
						resourceAssembly = System.Reflection.Assembly.GetExecutingAssembly()
					End If

					hWndPage = New IntPtr(_edgeBar.AddPageEx(theDocument, resourceAssembly.Location, edgeBarControl.BitmapID, edgeBarControl.ToolTip, 2))
				End If

				' ISolidEdgeBarEx.AddPage() may return null.
				If Not hWndPage.Equals(IntPtr.Zero) Then
					edgeBarPage = New EdgeBarPage(hWndPage, theDocument, edgeBarControl)
				End If

				_edgeBarPageDictionary.Add(pUnk, edgeBarPage)
			Else
				edgeBarPage = _edgeBarPageDictionary(pUnk)
			End If

			Return edgeBarPage
		End Function

		Private Sub RemovePage(ByVal edgeBarPage As EdgeBarPage)
			Dim hWndEdgeBarPage As IntPtr = edgeBarPage.Handle

			' We use the IUnknown pointer of the document as the dictionary key.
			Dim pUnk As IntPtr = Marshal.GetIUnknownForObject(edgeBarPage.Document)
			Marshal.Release(pUnk)

			If _edgeBarPageDictionary.ContainsKey(pUnk) Then
				_edgeBarPageDictionary.Remove(pUnk)
				edgeBarPage.Dispose()

				_edgeBar.RemovePage(edgeBarPage.Document, hWndEdgeBarPage.ToInt32(), 0)
			End If
		End Sub

		#End Region

		#Region "IConnectionPoint helpers"

		Private Sub HookEvents(ByVal eventSource As Object, ByVal eventGuid As Guid)
			Dim container As IConnectionPointContainer = Nothing
			Dim connectionPoint As IConnectionPoint = Nothing
			Dim cookie As Integer = 0

			container = CType(eventSource, IConnectionPointContainer)
			container.FindConnectionPoint(eventGuid, connectionPoint)

			If connectionPoint IsNot Nothing Then
				connectionPoint.Advise(Me, cookie)
				_connectionPointDictionary.Add(connectionPoint, cookie)
			End If
		End Sub

		Private Sub UnhookAllEvents()
			Dim enumerator As Dictionary(Of IConnectionPoint, Integer).Enumerator = _connectionPointDictionary.GetEnumerator()
			Do While enumerator.MoveNext()
				enumerator.Current.Key.Unadvise(enumerator.Current.Value)
			Loop

			_connectionPointDictionary.Clear()
		End Sub

		#End Region

		#Region "IDisposable"

		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)
		End Sub

		Public Sub Dispose(ByVal disposing As Boolean)
			If Not _disposed Then
				If disposing Then
					Dim enumerator As Dictionary(Of IntPtr, EdgeBarPage).Enumerator = _edgeBarPageDictionary.GetEnumerator()

					Do While enumerator.MoveNext()
						RemovePage(enumerator.Current.Value)
					Loop

					_edgeBarPageDictionary.Clear()
				End If

				_edgeBarPageDictionary = Nothing
				_edgeBar = Nothing
				_myAddIn = Nothing
				_disposed = True
			End If
		End Sub

		#End Region
	End Class
End Namespace
