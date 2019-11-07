

Public Class _Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Response.Redirect("~/Rdls/Report.aspx")
    End Sub


End Class