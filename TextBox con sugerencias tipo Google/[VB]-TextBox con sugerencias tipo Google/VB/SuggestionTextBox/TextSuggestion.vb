Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class TextSuggestion
    Inherits TextBox

#Region "Variables privadas"

    Private _listBox As ListBox
    Private _listBoxAddedToForm As Boolean = False

    Private _matchElement As Func(Of Object, String, Boolean)
    Private _textFromElement As Func(Of Object, String)

#End Region

#Region "Constructor"

    Public Sub New()
        MaxNumOfSuggestions = 10
        _listBox = New ListBox()
        AddHandler KeyDown, AddressOf this_KeyDown
        AddHandler KeyUp, AddressOf this_KeyUp
        AddHandler LostFocus, AddressOf this_LostFocus
        AddHandler _listBox.Click, AddressOf listBox_Click
    End Sub

#End Region

#Region "Propiedades públicas"

    <DefaultValue(10)> _
    Public Property MaxNumOfSuggestions As Integer

    Public Property SuggestDataSource As IEnumerable(Of Object)

    Public Property MatchElement() As Func(Of Object, String, Boolean)
        Get
            If _matchElement Is Nothing Then
                If SuggestDataSource.GetType().GetGenericArguments()(0).IsAssignableFrom(GetType(String)) Then
                    Return Function(element As Object, text As String)
                               Return CType(element, String).StartsWith(text, StringComparison.OrdinalIgnoreCase)
                           End Function
                Else
                    Return Function(element As Object, text As String)
                               Return element.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)
                           End Function
                End If
            Else
                Return _matchElement
            End If
        End Get
        Set(ByVal value As Func(Of Object, String, Boolean))
            _matchElement = value
        End Set
    End Property

    Public Property TextFromElement() As Func(Of Object, String)
        Get
            If _textFromElement Is Nothing Then
                If SuggestDataSource.GetType().GetGenericArguments()(0).IsAssignableFrom(GetType(String)) Then
                    Return Function(element As Object)
                               Return CType(element, String)
                           End Function
                Else
                    Return Function(element As Object)
                               Return element.ToString()
                           End Function
                End If
            Else
                Return _textFromElement
            End If
        End Get
        Set(ByVal value As Func(Of Object, String))
            _textFromElement = value
        End Set
    End Property

#End Region

#Region "ListBox"

    Private Sub ShowListBox()
        If Not _listBoxAddedToForm Then
            Me.TopLevelControl.Controls.Add(_listBox)
            Dim controlLocation As Point _
                = Me.TopLevelControl.PointToClient(Me.Parent.PointToScreen(Me.Location))
            _listBox.Left = controlLocation.X
            _listBox.Top = controlLocation.Y + Me.Height
            _listBox.Font = Me.Font
            _listBox.Width = Me.Width
            _listBox.MinimumSize = New Size(Me.Width, _listBox.MinimumSize.Height)
            _listBox.Height = _listBox.ItemHeight * (MaxNumOfSuggestions + 1)
            _listBoxAddedToForm = True
        End If
        _listBox.Visible = True
        _listBox.BringToFront()
    End Sub

    Private Sub HideListBox()
        _listBox.Visible = False
    End Sub

    Private Sub UpdateListBox()
        If SuggestDataSource IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.Text) Then
            Dim result As IEnumerable(Of String) = SuggestDataSource _
                .Where(Function(item) MatchElement(item, Me.Text) _
                    AndAlso Not TextFromElement(item).Equals(Me.Text, StringComparison.OrdinalIgnoreCase)) _
                .Select(Function(item) TextFromElement(item)) _
                .OrderBy(Function(s) s) _
                .Take(MaxNumOfSuggestions)
            If result.Count() > 0 Then
                _listBox.DataSource = result.ToList()
                ShowListBox()
            Else
                HideListBox()
            End If
        Else
            HideListBox()
        End If
    End Sub

    Private Sub listBox_Click(sender As Object, e As EventArgs)
        If _listBox.SelectedIndex >= 0 Then
            Text = _listBox.SelectedItem.ToString()
        End If
        HideListBox()
    End Sub

#End Region

#Region "LostFocus"

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        If Not _listBox.ContainsFocus Then
            MyBase.OnLostFocus(e)
        End If
    End Sub

    Private Sub this_LostFocus(sender As Object, e As EventArgs)
        HideListBox()
    End Sub

#End Region

#Region "Entrada de teclado"

    Private Sub this_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Down
                If _listBox.Visible AndAlso _listBox.SelectedIndex < _listBox.Items.Count - 1 Then
                    _listBox.SelectedIndex += 1
                End If
                e.SuppressKeyPress = True
            Case Keys.Up
                If _listBox.Visible AndAlso _listBox.SelectedIndex >= 0 Then
                    _listBox.SelectedIndex -= 1
                End If
                e.SuppressKeyPress = True
            Case Keys.Enter
                If _listBox.Visible Then
                    If _listBox.SelectedIndex >= 0 Then
                        Text = _listBox.SelectedItem.ToString()
                        SelectAll()
                    End If
                    HideListBox()
                    e.SuppressKeyPress = True
                End If
        End Select
    End Sub

    Dim _lastText As String
    Private Sub this_KeyUp(sender As Object, e As KeyEventArgs)
        If Me.Text <> _lastText Then
            UpdateListBox()
            _lastText = Me.Text
        End If
    End Sub

#End Region

End Class
