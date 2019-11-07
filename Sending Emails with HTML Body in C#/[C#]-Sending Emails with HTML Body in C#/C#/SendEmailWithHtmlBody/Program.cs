using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Email;
using Spire.Email.Smtp;
using Spire.Email.IMap;
using System.Globalization;

namespace SendEmailWithHtmlBody
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of MailMessage and specify From, To
            MailAddress addressFrom = new MailAddress("sender@outlook.com", "Sender Name");
            MailAddress addressTo = new MailAddress("recipient@outlook.com");
            MailMessage message = new MailMessage(addressFrom, addressTo);

            //set data, subject, html body of message
            message.Date = DateTime.Now;
            message.Subject = "Sending Email with HTML Body";
            string htmlString = @"<html>
                                  <body>
                                  <p>Dear xxxx,</p>
                                  <p>It has been long since we...</p>
                                  <p>Sincerely,<br>Scott</br></p>
                                  </body>
                                  </html>
                                 ";   
            message.BodyHtml = htmlString;

            //create a SmtpClient instance with host, port, username and password, and send the email using SendOne medthod
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.outlook.com";
            client.Port = 587;
            client.Username = addressFrom.Address;
            client.Password = "password";
            client.ConnectionProtocols = ConnectionProtocols.Ssl;
            client.SendOne(message);
            Console.WriteLine("Sent Successfully!");
            Console.Read();
        }
    }
}
