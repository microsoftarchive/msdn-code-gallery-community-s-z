Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net.Mail
Imports System.Net


Partial Public Class ContactUs
    Inherits System.Web.UI.Page
    Protected Sub ImageButton_Submit_Click(sender As Object, e As ImageClickEventArgs)
        'Try
        '    Dim mMailMessage As New MailMessage()
        '    Dim mSmtpClient As New SmtpClient()
        '    mSmtpClient.Host = "smtp.gmail.com"
        '    mSmtpClient.Port = 587

        '    Dim SmtpUser As New System.Net.NetworkCredential("exactaplctest@gmail.com", "exactaplctest2015")

        '    mMailMessage.From = New MailAddress(HttpUtility.HtmlEncode(TextBoxEmail.Text))
        '    mMailMessage.[To].Add(New MailAddress("muhammadsaliqadri@gmail.com"))

        '    ' mMailMessage.Bcc.Add(new MailAddress(bcc));
        '    ' mMailMessage.CC.Add(new MailAddress(cc));

        '    mMailMessage.Subject = "From:" & HttpUtility.HtmlEncode(TextBoxYourName.Text) & "-" & HttpUtility.HtmlEncode(TextBoxSubject.Text)
        '    mMailMessage.Body = HttpUtility.HtmlEncode(EditorEmailMessageBody.Content)
        '    mMailMessage.IsBodyHtml = True
        '    mMailMessage.Priority = MailPriority.Normal


        '    mSmtpClient.Credentials = SmtpUser
        '    'mSmtpClient.EnableSsl = True
        '    'mSmtpClient.UseDefaultCredentials = False

        '    mSmtSmtp.DeliveryMethod = SmtpDeliveryMethod.NetworkpClient.Send(mMailMessage)


        '    LabelMessage.Text = "Thank You - Your Message was sent."
        'Catch exp As Exception
        '    Throw New Exception("ERROR: Unable to Send Contact - " & exp.Message.ToString(), exp)
        'End Try

        Dim correo = New MailMessage
        Dim telefonoSiNo As String


        With correo
            .From = New MailAddress("exactaplctest@gmail.com", EditorEmailMessageBody.ToString)
            .To.Add(New MailAddress("exactaplctest@gmail.com", "exactaplctest2015"))
            .IsBodyHtml = True
            .Subject = TextBoxSubject.Text
            '.Body = EditorEmailMessageBody.ToString
            .Body = "hello world" 'String.Format("{0}-{1}-{2}-{3}-{4}-{5}", "Subject" & Me.Nombre.Text, "Telefono, " & Me.Telefono.Text, "Correo " & Me.Correo.Text, "Asunto " & Me.Asunto.Text, "Mensaje " & Me.Mensaje.Text, "Llamar por teléfono-" & telefonoSiNo.ToString)
        End With



        Dim enviador = New SmtpClient
        With enviador

            .Host = "smtp.gmail.com"
            .Credentials = New NetworkCredential("exactaplctest@gmail.com", "exactaplctest2015")
            'Exisgidos por GMAIL
            .EnableSsl = True
            .Port = 587
        End With

        Try
            enviador.Send(correo)

        Catch ex As Exception
            

        End Try




    End Sub
End Class
