'dll .netFramework
Imports System.Net.Mail
Imports System.IO

'Classe FrmEmail
Public Class FrmEmail

    'Istanzio una variabile per la spedizione dei messaggi di posta elettronica
    Dim myMessage As New MailMessage
    'Istanzio una variabile per il protocollo SMTP
    Dim myClient As New SmtpClient()

    'Evento Load del Form FrmEmail
    Private Sub FrmEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Se la variabile d'impostazione address none nothing
        If My.MySettings.Default.address IsNot Nothing Then
            'Eseguo l'iterazione e popolo le combobox cbxTo e cbxCc con gli indirizzi di posta memorizzati
            For Each myAddress As String In My.MySettings.Default.address
                'Aggiungo i relativi indirizzi di posta mediante metodo Add delle combobox
                Me.cbxTo.Items.Add(myAddress)
                Me.cbxCc.Items.Add(myAddress)
                'Iterazione successiva
            Next
            'Altrimenti
        Else
            'Creo una nuova variabile StringCollection address nelle impostazioni dell'applicazione
            My.MySettings.Default.address = New System.Collections.Specialized.StringCollection
            'Effettuo il salvataggio delle impostazioni dell'applicazione
            My.MySettings.Default.Save()
        End If
    End Sub

    'Evento Click del pulsnate btnInvia
    Private Sub btnInvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvia.Click
        'Prova
        Try
            'Se il valore di txtTo termina con ;
            If txtTo.Text.EndsWith(";") Then
                'Elimina l'ultimo carattere ; dal contenuto di txtTo
                Me.txtTo.Text = Me.txtTo.Text.TrimEnd(";")
            End If

            'Dichiaro un arraylist per spedizione Email a più destinatari
            Dim emailMultiple As String() = txtTo.Text.Split(";")
            'Impoosto la porta per le transazioni SMTP
            myClient.Port = "587"
            'Imposto il nome dell'host utilizzato per le transazioni SMTP
            myClient.Host = "smtp.live.com"
            'Disabilito le credenziali user
            myClient.UseDefaultCredentials = False
            'Imposto le credenziali per l'autenticazione del Mittente
            myClient.Credentials = New System.Net.NetworkCredential(txtFrom.Text, txtPassword.Text)
            'Imposto l'indirizzo del Mittente
            myMessage.From = New MailAddress(txtFrom.Text)
            'Specifico l'oggetto del messaggio di posta
            myMessage.Subject = txtOggetto.Text
            'Eseguo la codifica del contenuto del messaggio
            myMessage.BodyEncoding = System.Text.Encoding.UTF8
            'Qui si imposta il corpo del messaggio di posta , il contenuto
            myMessage.Body = txtBody.Text
            'Imposta la crittografia di connessione specificando che la connessione SMTP 
            'utilizza SSL
            myClient.EnableSsl = True
            'Eseguo l'iterazione per la spedizione di messaggi di posta a più destinatari
            For Each destinatari As String In emailMultiple
                'Aggiungo l'indirizzo di posta elettronica del o dei destinatari
                myMessage.To.Add(destinatari)
                'Invio il messaggio di posta al o ai destinatari
                myClient.Send(myMessage)
                'Effettuo la cancellazione del destinatario
                myMessage.To.Clear()
                'Iterazione successiva
            Next
            'In caso di eccezzione
        Catch ex As Exception
            'Visualizza messaggio a utente
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Evento Click del pulsante btnAggiungi
    Private Sub btnAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click
        'Se il TextBox txtCc contiene caratteri
        If Not Me.txtCc.Text = "" Then
            'Se l'utente decide di inserire un nuovo contatto
            If MessageBox.Show("Aggiungere il contatto" & " " & Me.txtCc.Text, Application.ProductName.ToString, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                'Aggiungo alla variabile di impostazione address il contenuto di txtCc
                My.MySettings.Default.address.Add(Me.txtCc.Text)
                'Effettuo il salvataggio delle impostazioni dell'applicazione
                My.MySettings.Default.Save()
                'Altrimrnti
            End If
        End If

        'Se il TextBox txtTo contiene caratteri
        If Not Me.txtTo.Text = "" Then
            'Se l'utente decide di inserire un nuovo contatto
            If MessageBox.Show("Aggiungere il contatto" & " " & Me.txtTo.Text, Application.ProductName.ToString, MessageBoxButtons.YesNo) = DialogResult.Yes Then
                'Aggiungo alla variabile di impostazione address il contenuto di txtTo
                My.MySettings.Default.address.Add(Me.txtTo.Text)
                'Effettuo il salvataggio delle impostazioni dell'applicazione
                My.MySettings.Default.Save()
            End If
        End If
    End Sub

    'Evento Click del pulsante btnEliminaContatti
    Private Sub btnEliminaContatti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaContatti.Click
        'Se l'utente decide di rimuovere tutti i contatti di posta
        If MessageBox.Show("Si desidera canlellare tutti i contatti?", Application.ProductName.ToString, MessageBoxButtons.YesNo) Then
            'Rimuovo dlla variabile di impostazione address tutti i contatti memorizzati
            My.MySettings.Default.address.Clear()
            'Effettuo il salvataggio delle impostazioni dell'applicazione
            My.MySettings.Default.Save()
            'Rimuovo dalle combobox cbxCc e cbxTo i contatti
            cbxCc.Items.Clear()
            cbxTo.Items.Clear()
            'Avvvisa l'utente delle rimozione dei contatti
            MessageBox.Show("I contatti sono stati rimossi")
        End If
    End Sub

    'Evento Click del pulsante btnCc
    Private Sub btnCc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCc.Click
        'Eseguo il DroppedDwwn del combobox cbxCc
        Me.cbxCc.DroppedDown = True
    End Sub

    'Evento Click del pulsante btnTo
    Private Sub btnTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTo.Click
        'Eseguo il DroppedDwwn del combobox cbxTo
        Me.cbxTo.DroppedDown = True
    End Sub

    'Evento Click del pulsante btnAllega
    Private Sub btnAllega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllega.Click
        'Se l'utente conferma la scelta dei file da allegare con pulsante ok
        If ofd.ShowDialog() = DialogResult.OK Then
            'Eseguo l'iterazione della variabile allegat e recupero i file selezionati dall'utente
            For Each allegat As String In ofd.FileNames
                'Visualizzo ad utente l'elenco del o dei file selezionati come allegato
                Me.txtAllegati.Text += New System.IO.FileInfo(allegat).Name & ";"
                'Istanzio un nuovo oggetto Attachment
                Dim allegato As New Net.Mail.Attachment(allegat)
                'Aggiungo l'allegato o gli allegati al messaggio di posta elettronica
                myMessage.Attachments.Add(allegato)
                'Iterazione successiva
            Next
        End If
    End Sub

    'Evento click del pulsante btnEsci
    Private Sub btnEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsci.Click
        'Esce e chiude l'applicazione Email
        Me.Close()
    End Sub

    'Evento SelectedIndexChanged del combobox cbxCc
    Private Sub cbxCc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCc.SelectedIndexChanged
        'Se il contenuto del combobox cbxCc non e vuoto
        If Me.cbxCc.Text IsNot String.Empty Then
            'Visualizzo su TextBox txtCc il valore attuale di cbxCc
            Me.txtCc.Text += Me.cbxCc.Text & ";"
        End If
    End Sub

    'Evento SelectedIndexChanged del combobox cbxTo
    Private Sub cbxTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTo.SelectedIndexChanged
        'Se il contenuto del combobox cbxTo non e vuoto
        If Me.cbxTo.Text IsNot String.Empty Then
            'Visualizzo su TextBox txtTo il valore attuale di cbxTo
            Me.txtTo.Text += Me.cbxTo.Text & ";"
        End If
    End Sub
End Class
