// dll .netFramework
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

// Spazio dei nomi EmailSample
namespace EmailSample
{
    // Classe FrmEmail
    public partial class FrmEmail : Form
    {
        // Costruttore della classe FrmEmail
        public FrmEmail()
        {
            // Richiamo del metodo InitializeComponent
            InitializeComponent();
        }

        //Istanzio una variabile per la spedizione dei messaggi di posta elettronica
        MailMessage myMessage = new MailMessage();
        //Istanzio una variabile per il protocollo SMTP
        SmtpClient myClient = new SmtpClient();

        //Evento Load del Form FrmEmail
        private void FrmEmail_Load(System.Object sender, System.EventArgs e)
        {
            // Se la variabile d'impostazione address none nothing
            if (Properties.Settings.Default.address != null)
            {
                //Eseguo l'iterazione e popolo le combobox cbxTo e cbxCc con gli indirizzi di posta memorizzati
                foreach (string myAddress in Properties.Settings.Default.address)
                {
                    //Aggiungo i relativi indirizzi di posta mediante metodo Add delle combobox
                    this.cbxTo.Items.Add(myAddress);
                    this.cbxCc.Items.Add(myAddress);
                    //Iterazione successiva
                }
                //Altrimenti
            }
            else
            {
                //Creo una nuova variabile StringCollection address nelle impostazioni dell'applicazione
                Properties.Settings.Default.address = new System.Collections.Specialized.StringCollection();
                //Effettuo il salvataggio delle impostazioni dell'applicazione
                Properties.Settings.Default.Save();
            }
        }

        //Evento Click del pulsnate btnInvia
        private void btnInvia_Click(System.Object sender, System.EventArgs e)
        {
            //Prova
            try
            {
                //Se il valore di txtTo termina con ;
                if (txtTo.Text.EndsWith(";"))
                {
                    //Elimina l'ultimo carattere ; dal contenuto di txtTo
                    this.txtTo.Text = this.txtTo.Text.TrimEnd(';');
                }

                //Dichiaro un arraylist per spedizione Email a più destinatari
                string[] emailMultiple = txtTo.Text.Split(';');
                //Impoosto la porta per le transazioni SMTP
                myClient.Port = int.Parse("587");
                //Imposto il nome dell'host utilizzato per le transazioni SMTP
                myClient.Host = "smtp.live.com";
                //Disabilito le credenziali user
                myClient.UseDefaultCredentials = false;
                //Imposto le credenziali per l'autenticazione del Mittente
                myClient.Credentials = new System.Net.NetworkCredential(txtFrom.Text, txtPassword.Text);
                //Imposto l'indirizzo del Mittente
                myMessage.From = new MailAddress(txtFrom.Text);
                //Specifico l'oggetto del messaggio di posta
                myMessage.Subject = txtOggetto.Text;
                //Eseguo la codifica del contenuto del messaggio
                myMessage.BodyEncoding = System.Text.Encoding.UTF8;
                //Qui si imposta il corpo del messaggio di posta , il contenuto
                myMessage.Body = txtBody.Text;
                //Imposta la crittografia di connessione specificando che la connessione SMTP 
                //utilizza SSL
                myClient.EnableSsl = true;
                //Eseguo l'iterazione per la spedizione di messaggi di posta a più destinatari
                foreach (string destinatari in emailMultiple)
                {
                    //Aggiungo l'indirizzo di posta elettronica del o dei destinatari
                    myMessage.To.Add(destinatari);
                    //Invio il messaggio di posta al o ai destinatari
                    myClient.Send(myMessage);
                    //Effettuo la cancellazione del destinatario
                    myMessage.To.Clear();
                    //Iterazione successiva
                }
                //In caso di eccezzione
            }
            catch (Exception ex)
            {
                //Visualizza messaggio a utente
                MessageBox.Show(ex.Message);
            }
        }

        //Evento Click del pulsante btnAggiungi
        private void btnAggiungi_Click(System.Object sender, System.EventArgs e)
        {
            //Se il TextBox txtCc contiene caratteri
            if (!string.IsNullOrEmpty(this.txtCc.Text))
            {
                //Se l'utente decide di inserire un nuovo contatto
                if (MessageBox.Show("Aggiungere il contatto" + this.txtCc.Text,Application.ProductName.ToString(),MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Aggiungo alla variabile di impostazione address il contenuto di txtCc
                    Properties.Settings.Default.address.Add(this.txtCc.Text);
                    //Effettuo il salvataggio delle impostazioni dell'applicazione
                    Properties.Settings.Default.Save();
                    //Altrimrnti
                }
            }

            //Se il TextBox txtTo contiene caratteri
            if (!string.IsNullOrEmpty(this.txtTo.Text))
            {
                //Se l'utente decide di inserire un nuovo contatto
                if (MessageBox.Show("Aggiungere il contatto" + " " + this.txtTo.Text, Application.ProductName.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Aggiungo alla variabile di impostazione address il contenuto di txtTo
                    Properties.Settings.Default.address.Add(this.txtTo.Text);
                    //Effettuo il salvataggio delle impostazioni dell'applicazione
                    Properties.Settings.Default.Save();
                }
            }
        }

        //Evento Click del pulsante btnEliminaContatti
        private void btnEliminaContatti_Click(System.Object sender, System.EventArgs e)
        {
            //Se l'utente decide di rimuovere tutti i contatti di posta
            if (MessageBox.Show("Si desidera canlellare tutti i contatti?", Application.ProductName.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Rimuovo dlla variabile di impostazione address tutti i contatti memorizzati
                Properties.Settings.Default.address.Clear();
                //Effettuo il salvataggio delle impostazioni dell'applicazione
                Properties.Settings.Default.Save();
                //Rimuovo dalle combobox cbxCc e cbxTo i contatti
                cbxCc.Items.Clear();
                cbxTo.Items.Clear();
                //Avvvisa l'utente delle rimozione dei contatti
                MessageBox.Show("I contatti sono stati rimossi");
            }
        }

        //Evento Click del pulsante btnCc
        private void btnCc_Click(System.Object sender, System.EventArgs e)
        {
            //Eseguo il DroppedDwwn del combobox cbxCc
            this.cbxCc.DroppedDown = true;
        }

        //Evento Click del pulsante btnTo
        private void btnTo_Click(System.Object sender, System.EventArgs e)
        {
            //Eseguo il DroppedDwwn del combobox cbxTo
            this.cbxTo.DroppedDown = true;
        }

        //Evento Click del pulsante btnAllega
        private void btnAllega_Click(System.Object sender, System.EventArgs e)
        {
            //Se l'utente conferma la scelta dei file da allegare con pulsante ok
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Eseguo l'iterazione della variabile allegat e recupero i file selezionati dall'utente
                foreach (string allegat in ofd.FileNames)
                {
                    //Visualizzo ad utente l'elenco del o dei file selezionati come allegato
                    this.txtAllegati.Text += new System.IO.FileInfo(allegat).Name + ";";
                    //Istanzio un nuovo oggetto Attachment
                    System.Net.Mail.Attachment allegato = new System.Net.Mail.Attachment(allegat);
                    //Aggiungo l'allegato o gli allegati al messaggio di posta elettronica
                    myMessage.Attachments.Add(allegato);
                    //Iterazione successiva
                }
            }
        }

        //Evento click del pulsante btnEsci
        private void btnEsci_Click(System.Object sender, System.EventArgs e)
        {
            //Esce e chiude l'applicazione Email
            this.Close();
        }

        //Evento SelectedIndexChanged del combobox cbxCc
        private void cbxCc_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //Se il contenuto del combobox cbxCc non e vuoto
            if (!object.ReferenceEquals(this.cbxCc.Text, string.Empty))
            {
                //Visualizzo su TextBox txtCc il valore attuale di cbxCc
                this.txtCc.Text += this.cbxCc.Text + ";";
            }
        }

        //Evento SelectedIndexChanged del combobox cbxTo
        private void cbxTo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //Se il contenuto del combobox cbxTo non e vuoto
            if (!object.ReferenceEquals(this.cbxTo.Text, string.Empty))
            {
                //Visualizzo su TextBox txtTo il valore attuale di cbxTo
                this.txtTo.Text += this.cbxTo.Text + ";";
            }
        }
    }
}
