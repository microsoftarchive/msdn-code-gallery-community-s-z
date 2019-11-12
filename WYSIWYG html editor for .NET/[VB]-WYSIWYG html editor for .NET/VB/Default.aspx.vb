Partial Class _Default
  Inherits System.Web.UI.Page
  'Online support: http://wysiwygnet.com/forum.aspx
  Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    WYSIWYG.Editor.AddTo(TextArea1) 'WYSIWYG .net editor is easy to implement in your .NET web application: You need to add only this line of code!
    If Not IsPostBack Then      
      Dim Reader As New System.IO.StreamReader(MapPath("app_data\htmlcode.txt"))
      TextArea1.Value = Reader.ReadToEnd 'Load content:
      Reader.Close()
    End If
  End Sub
  Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim Writer As New System.IO.StreamWriter(MapPath("app_data\htmlcode.txt"))
    Writer.Write(TextArea1.Value) 'Save Content
    Writer.Close()
  End Sub
End Class