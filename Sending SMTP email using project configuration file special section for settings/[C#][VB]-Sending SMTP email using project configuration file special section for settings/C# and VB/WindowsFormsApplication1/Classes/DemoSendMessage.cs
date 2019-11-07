using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public class DemoSendMessage
    {
        /// <summary>
        /// If specifiedPickupDirectory folder exists from app.config
        /// remove all email files.
        /// </summary>
        public void CleanPickupFolder()
        {

            MailConfiguration mc = new MailConfiguration();

            if (!string.IsNullOrWhiteSpace(mc.PickupDirectoryLocation))
            {
                if (System.IO.Directory.Exists(mc.PickupDirectoryLocation))
                {
                    try
                    {
                        Directory
                            .GetFiles(mc.PickupDirectoryLocation)
                            .ToList()
                            .ForEach(file => System.IO.File.Delete(file));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to clean pickup folder\n" + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Send a simple html or plain text mesage
        /// </summary>
        /// <param name="RecipientAddress"></param>
        /// <param name="Subject">subject line of the message</param>
        /// <param name="Message">text with html embedded</param>
        /// <param name="UsePickupFolder">true to send message to file</param>
        /// <param name="BodyIsHtml">true if has html tags</param>
        /// <returns></returns>
        public async Task SendMessage(string RecipientAddress, string Subject, string Message, bool UsePickupFolder, bool BodyIsHtml)
        {

            MailConfiguration mc = new MailConfiguration();

            MailMessage emailMessage = new MailMessage();

            emailMessage.IsBodyHtml = BodyIsHtml;

            emailMessage.From = new MailAddress(mc.From);
            emailMessage.To.Add(new MailAddress(RecipientAddress));

            emailMessage.Body = Message;
            emailMessage.Subject = Subject;

            SmtpClient smtpClient = new SmtpClient(mc.HostServer);

            smtpClient.Timeout = 2000;
            smtpClient.Port = mc.Port;

            /*
             * only use credentials if supplied in the app.config file
             * we could specify these in the config file too but not wise as anyone can see them
             * unless encrypted and that security can be hacked.
             */
            if (!string.IsNullOrWhiteSpace(mc.UserName) && (!string.IsNullOrWhiteSpace(mc.Password)))
            {
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(mc.UserName, mc.Password);
            }

            // setup event for when message has been set, cancelled or errors out.
            smtpClient.SendCompleted += smtpClient_SendCompleted;

            // redirect message to file that has a an exension of eml which if Microsoft Outlook
            // is installed by default when double clicking on the file will open in Outlook.
            if (UsePickupFolder)
            {
                if (!string.IsNullOrWhiteSpace(mc.PickupDirectoryLocation))
                {
                    if (Directory.Exists(mc.PickupDirectoryLocation))
                    {
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    }
                }
            }

            // wrap SendMailAsync to trap for exceptions e.g. bad port, bad credentials etc.
            try
            {
                await smtpClient.SendMailAsync(emailMessage);
            }
            catch (Exception generalException)
            {
                if (generalException is SmtpException)
                {
                    Console.WriteLine("handle this exception");
                }
                else if (generalException is Exception)
                {
                    Console.WriteLine("handle this exception");
                }
            }
        }

        /// <summary>
        /// Occurs when an asynchronous e-mail send operation completes.
        /// https://msdn.microsoft.com/en-us/library/system.net.mail.smtpclient.sendcompleted(v=vs.110).aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Excluded cancel check
        /// </remarks>
        private void smtpClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Encountered issues sending message\n\n" + e.Error.Message);
            }
            else
            {
                MessageBox.Show("Message sent");
            }
        }
    }
}