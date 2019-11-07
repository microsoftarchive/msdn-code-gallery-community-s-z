Namespace WYSIWYG
  Public Module Editor
    Sub AddTo(TextBox As TextBox, Optional AddCenterButton As Boolean = False)
      AddTo(CType(TextBox, Control), AddCenterButton)
    End Sub
    Sub AddTo(TextArea As HtmlTextArea, Optional AddCenterButton As Boolean = False)
      AddTo(CType(TextArea, Control), AddCenterButton)
    End Sub
    Private Sub AddTo(TextArea As Control, Optional AddCenterButton As Boolean = False)
      Dim Page As Page = TextArea.Page
      Dim Tools As New Control
      AddAt(TextArea, Tools)
      AddAt(TextArea, New WebControl(HtmlTextWriterTag.Br))
      Dim Editor As New WebControl(HtmlTextWriterTag.Div)
      Editor.ID = "editor" : Editor.Attributes.Add("contenteditable", "true") : Editor.Style.Add("border-style", "dashed") : Editor.Style.Add("width", "inherit") : Editor.Style.Add("padding", "10px")
      AddAt(TextArea, Editor)
      Page.Form.Controls.Add(New LiteralControl("<script>var Editor=document.getElementById('" & Editor.ClientID & "');var TextArea=document.getElementById('" & TextArea.ClientID & "');TextArea.style.display='none';Editor.innerHTML=TextArea.value;function Save(){TextArea.value=Editor.innerHTML}</script>"))
      Page.Form.Attributes.Add("onsubmit", "Save()")
      Dim Anchor As Integer = IconName.Anchor, Bold As Integer = IconName.Bold, Italic As Integer = IconName.Italic, Neutral As Integer = &H2115, BulletedList As Integer = IconName.BulletedList, EnumeratedList As Integer = &H2419
      Dim Req = HttpContext.Current.Request
      If Req.Browser.Browser = "Chrome" Then
        'Chrome dont support this unichode chars, then change this!
        Anchor = &H21AC : Bold = &H24B7 : Italic = &H24BE
      ElseIf Req.UserAgent.Contains("Android") Then
        Anchor = &H21AC : Bold = &H24B7 : Italic = &H24BE : Neutral = &H24DD : BulletedList = &H21F6 : EnumeratedList = &H2116
      End If
      Dim ReqLink As String, ReqLinkInsideAlgoritm As Boolean
      If Req.Browser.Browser = "IE" Then
        ReqLinkInsideAlgoritm = True : ReqLink = "null"
      Else
        ReqLink = "prompt('URL:', 'http://')"
      End If
      Ico(Tools, IconName.Undo, "Undo", "undo")
      Ico(Tools, IconName.Redo, "Redo", "redo")
      Ico(Tools, Anchor, "Link", "createlink'," & ReqLinkInsideAlgoritm.ToString.ToLower & "," & ReqLink, ")")
      Ico(Tools, Bold, "Bold", "bold")
      Ico(Tools, Italic, "Italic", "italic")
      Ico(Tools, IconName.Underline, "Underline", "underline")
      Ico(Tools, &H20A6, "Strikethrough", "strikethrough")
      Ico(Tools, &HAA, "Superscript", "'superscript'")
      Ico(Tools, IconName.One, "H1", "formatBlock',false,'<h1>")
      Ico(Tools, IconName.Two, "H2", "formatBlock',false,'<h2>")
      Ico(Tools, IconName.Three, "H3", "formatBlock',false,'<h3>")
      Ico(Tools, &H24D2, "Block code", "formatBlock',false,'<pre>")
      Ico(Tools, Neutral, "Neutral", "formatBlock',false,'<div>")
      Ico(Tools, &H21E4, "Justify left", "justifyleft")
      If AddCenterButton Then Ico(Tools, &H2194, "Justify center", "justifycenter")
      Ico(Tools, &H21E5, "Justify right", "justifyright")
      Ico(Tools, BulletedList, "List", "insertunorderedlist")
      Ico(Tools, EnumeratedList, "Enumerated list", "insertorderedlist")
      Dim Link As New HyperLink : Link.NavigateUrl = "http://wysiwygnet.com/" : TextArea.Parent.Controls.AddAt(TextArea.Parent.Controls.IndexOf(TextArea) + 1, Link) : Link.Style.Add("font-size", "x-small") : Link.Text = "wysiwyg" 'The remotion of this line is a violation of Creative Common licenze
    End Sub

    Private Sub AddAt(TextArea As Control, Ctrl As Control)
      TextArea.Parent.Controls.AddAt(TextArea.Parent.Controls.IndexOf(TextArea), Ctrl)
    End Sub

    Private Sub Ico(Tools As Control, Name As IconName, ToolTip As String, Cmd As String, Optional E As String = "')")
      Dim Icon As New WebControls.HyperLink
      Icon.CssClass = "icon"
      Icon.Style.Add("font-size", "xx-large")
      Icon.Style.Add("text-decoration", "none!important")
      Icon.ToolTip = ToolTip
      Icon.NavigateUrl = "javascript:var status=document.execCommand('" & Cmd & E
      Icon.Text = Char.ConvertFromUtf32(Name)
      Tools.Controls.Add(Icon)
    End Sub

    Private Enum IconName
      Anchor = 9875 : Bold = 119809 : BulletedList = 8788 : Italic = 119868 : Underline = 95 : Undo = &H21B6 : One = 9312 : Redo = &H21B7 : Three = 9314 : Two = 9313
    End Enum
  End Module

End Namespace