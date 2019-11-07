using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StickyNotes
{
    class Email
    {

        public void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;


            if (e.Error != null)
            {
                client.SendAsyncCancel();
                CreateDialog(e.Error.ToString());
                mailSent = false;

            }
            else
            {
                CreateDialog("Message Sent");
                mailSent = true;
                dia.Close();
            }
            message.Dispose();
            
        }

        private static void CreateDialog(string msg)
        {
            Window w = new Window();
            StackPanel sp = new StackPanel();
            sp.Background = Brushes.Transparent;
            TextBlock tb = new TextBlock();
            tb.Background = sp.Background;
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = msg;
            sp.Children.Add(tb);

            w.Content = sp;
            w.WindowStyle = WindowStyle.ToolWindow;
            w.Background = Window2.ChangeBackgroundColor(Colors.Wheat);
            w.Height = 250;
            w.Width = 600;
            w.ShowDialog();
        }

        public Email(string server, string login, int port, bool sslCheck, string toAddr, string fromAddr, string password, string bodyMessage,EmailDialog emailDia, string subject)
        {
            dia = emailDia;
            try
            {
                NetworkCredential nw = new NetworkCredential(login, password);
                // Command line argument must be the SMTP host.
                client = new SmtpClient(server);
                client.Credentials = nw;
                client.EnableSsl = (sslCheck == true) ? true : false;
                // Specify the e-mail sender.
                // Create a mailing address that includes a UTF8 character
                // in the display name.

                MailAddress from = new MailAddress(fromAddr, "", System.Text.Encoding.UTF8);
                client.Port = port;
                // Set destinations for the e-mail message.
                MailAddress to = new MailAddress(toAddr);
                // Specify the message content.
                message = new MailMessage(from, to);
                message.Body = bodyMessage;

                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                // Set the method that is called back when the send operation ends.
                client.SendCompleted += new
                SendCompletedEventHandler(SendCompletedCallback);
                // The userState can be any object that allows your callback 
                // method to identify this send operation.
                // For this example, the userToken is a string constant.
                string userState = "Sticky note message";
                client.SendAsync(message, userState);
            }
            catch (Exception e)
            {
                CreateDialog(e.Message);
            }
        }

        public bool MailSent
        {
            get
            {
                return mailSent;
            }
        }

        private SmtpClient client = null;
        private MailMessage message = null;
        private bool mailSent = false;
        private EmailDialog dia = null;
    }



}
