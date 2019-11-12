using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DesktopCreateEmlFiles
{
    public class MailOperations
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public List<string> ToList { get; set; }
        public List<string> ccList { get; set; }

        readonly string Folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MailDrop");


        public MailOperations()
        {
            From = "WEBDEV.webdev@somewhere.com";
            ToList = new List<string>();
            ccList = new List<string>();
            IsBodyHtml = true;
        }
        public async Task Send()
        {
            MailMessage Mail = new MailMessage();
            Mail.From = new MailAddress(From);

            foreach (var toAddress in ToList)
            {
                Mail.To.Add(new MailAddress(toAddress));
            }

            foreach (var ccAddress in  ccList)
            {
                Mail.CC.Add(new MailAddress(ccAddress));
            }

            Mail.Subject = Subject;
            Mail.Body = Body;
            Mail.IsBodyHtml = true;

            SmtpClient MailClient = new SmtpClient("smtp.someplace.or.us");
            MailClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            MailClient.PickupDirectoryLocation = Folder;
            MailClient.EnableSsl = false;

            
            MailClient.Port = 25;
            MailClient.UseDefaultCredentials = true;

            try
            {
                await MailClient.SendMailAsync(Mail);
            }
            catch (Exception generalException)
            {
                Console.WriteLine(generalException.Message);
            }
        }
        public void CleanEml()
        {
            if (Directory.Exists(Folder))
            {
                try
                {
                    Directory.GetFiles(Folder, "*.eml").ToList().ForEach(File.Delete);
                }
                catch (Exception)
                {

                }
            }
            else
            {
            }
        }
    }
}
