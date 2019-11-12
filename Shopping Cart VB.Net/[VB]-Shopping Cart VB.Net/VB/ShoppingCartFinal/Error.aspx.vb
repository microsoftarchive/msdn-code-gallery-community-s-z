Public Class _Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label_ErrorFrom.Text = Request("Err").ToString()
    End Sub

End Class