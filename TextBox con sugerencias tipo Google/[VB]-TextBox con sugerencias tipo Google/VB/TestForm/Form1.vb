Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtProductos As DataTable = New DataTable("Products")
        dtProductos.ReadXml(Path.Combine(Application.StartupPath, "Datos\Products.xml"))
        TextSuggestion1.SuggestDataSource = dtProductos.Rows.Cast(Of DataRow)()
        TextSuggestion1.MatchElement = AddressOf SuggestionMatch
        TextSuggestion1.TextFromElement = AddressOf TextForSuggestion
    End Sub

    Private Function SuggestionMatch(row As Object, userText As String)
        If String.IsNullOrEmpty(userText) Then Return False

        Dim match As Boolean = True
        Dim words As String() = userText.Split(" "c)
        Dim datarow As DataRow = CType(row, DataRow)
        For Each word As String In words
            If Not datarow("Name").ToString().ToUpper().Contains(word.ToUpper()) _
                AndAlso (datarow("Color") Is DBNull.Value _
                OrElse Not datarow("Color").ToString().ToUpper().Contains(word.ToUpper())) Then
                match = False
                Exit For
            End If
        Next
        Return match
    End Function

    Function TextForSuggestion(row As Object)
        Dim datarow As DataRow = CType(row, DataRow)
        Dim color As String = ""
        If (datarow("Color") IsNot DBNull.Value) Then
            color = String.Format(" ({0})", datarow("Color").ToString())
        End If
        Return String.Format("{0}{1}", datarow("Name").ToString(), color)
    End Function

End Class
