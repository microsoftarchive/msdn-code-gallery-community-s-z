''' <summary>
''' Code below if for adding a new record, is not used for editing data.
''' </summary>
''' <remarks></remarks>
Public Class frmEditForm
    ''' <summary>
    ''' True indicates we are adding a new row
    ''' False indicates we are editing the current row.
    ''' </summary>
    ''' <remarks></remarks>
    Public AddingNewRecord As Boolean = False
    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged
        If AddingNewRecord Then
            cmdAccept.Enabled = (Not String.IsNullOrWhiteSpace(txtFirstName.Text)) AndAlso (Not String.IsNullOrWhiteSpace(txtLastName.Text))
        End If
    End Sub
End Class