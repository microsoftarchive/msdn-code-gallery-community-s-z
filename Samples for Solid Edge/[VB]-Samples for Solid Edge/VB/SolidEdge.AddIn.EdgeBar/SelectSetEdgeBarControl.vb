Imports System.ComponentModel
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes

Namespace SolidEdge.AddIn.EdgeBar
	''' <summary>
	''' SelectSet EdgeBar control. 
	''' </summary>
	''' <remarks>
	''' Set BitmapID and Tooltip properties!
	''' Warning: The PropertyGrid frequently causes Solid Edge to terminate. Bad example control...
	''' </remarks>
	Partial Public Class SelectSetEdgeBarControl
		Inherits EdgeBarControl

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MyEdgeBarControl_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Initialize ComboBox
			SelectSetChanged(Application.ActiveSelectSet)
		End Sub

		#Region "EdgeBarControl (SolidEdgeFramework.ISEDocumentEvents) overrides"

		Public Overrides Sub AfterSave()
			' Important to call base method!
			MyBase.AfterSave()
		End Sub

		Public Overrides Sub BeforeClose()
			' Important to call base method!
			MyBase.BeforeClose()

			comboBox.Items.Clear()
			propertyGrid.SelectedObject = Nothing
		End Sub

		Public Overrides Sub BeforeSave()
			' Important to call base method!
			MyBase.BeforeSave()
		End Sub

		Public Overrides Sub SelectSetChanged(ByVal SelectSet As Object)
			MyBase.SelectSetChanged(SelectSet)

			comboBox.Items.Clear()
			propertyGrid.SelectedObject = Nothing

			Try
'INSTANT VB NOTE: The variable selectSet was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
				Dim selectSet_Renamed As SolidEdgeFramework.SelectSet = CType(SelectSet, SolidEdgeFramework.SelectSet)
				Dim list As New List(Of Object)()

				If selectSet_Renamed.Count = 0 Then
					list.Add(Document)
				Else
					Dim items = selectSet_Renamed.Cast(Of Object)().ToArray()
					For Each item In items
						list.Add(item)
					Next item
				End If

				For i As Integer = 0 To list.Count - 1
					Dim item = list(i)

					Dim caption As String = GetComObjectFullyQualifiedName(item)
					caption = String.Format("SelectSet[{0}] - {1}", i + 1, caption)
					comboBox.Items.Add(New SelectSetComboBoxItem(caption, item))
				Next i

				comboBox.SelectedIndex = 0
			Catch ex As System.Exception
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		#End Region

		#Region "EdgeBarControl methods"

		Private Sub comboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox.SelectedIndexChanged
			propertyGrid.SelectedObject = Nothing

			Dim item As SelectSetComboBoxItem = TryCast(comboBox.SelectedItem, SelectSetComboBoxItem)

			If item IsNot Nothing Then
				' PropertyGrid may cause Solid Edge to terminate!
				' Training\Ziptie.par
				' Double click Protrusion2
				' Select 40 degree line
				propertyGrid.SelectedObject = item.SelectedObject
			End If
		End Sub

		Private Function GetComObjectFullyQualifiedName(ByVal o As Object) As String
			If o Is Nothing Then
				Throw New ArgumentNullException()
			End If

			If Marshal.IsComObject(o) Then
				Dim dispatch As IDispatch = TryCast(o, IDispatch)
				If dispatch IsNot Nothing Then
					Dim typeLib As ITypeLib = Nothing
					Dim typeInfo As ITypeInfo = dispatch.GetTypeInfo(0, 0)
					Dim index As Integer = 0
					typeInfo.GetContainingTypeLib(typeLib, index)

					Dim typeLibName As String = Marshal.GetTypeLibName(typeLib)
					Dim typeInfoName As String = Marshal.GetTypeInfoName(typeInfo)

					Return String.Format("{0}.{1}", typeLibName, typeInfoName)
				End If
			End If

			Return o.GetType().FullName
		End Function

		#End Region
	End Class

	Friend Class SelectSetComboBoxItem
		Private _caption As String
		Private _selectedObject As Object

		Public Sub New(ByVal caption As String, ByVal selectedObject As Object)
			_caption = caption
			_selectedObject = selectedObject
		End Sub

		Public ReadOnly Property Caption() As String
			Get
				Return _caption
			End Get
		End Property
		Public ReadOnly Property SelectedObject() As Object
			Get
				Return _selectedObject
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return _caption
		End Function
	End Class
End Namespace
