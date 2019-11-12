using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Exchange.WebServices;
using Microsoft.Exchange.WebServices.Data;

namespace EWSSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            ExchangeService service = new ExchangeService();
            service.AutodiscoverUrl("youremailaddress@yourdomain.com");

            EmailMessage message = new EmailMessage(service);
            message.Subject = subjectTextbox.Text;
            message.Body = bodyTextbox.Text;
            message.ToRecipients.Add(recipientTextbox.Text);
            message.Save();

            message.SendAndSaveCopy();

            System.Windows.MessageBox.Show("Message sent!");

            recipientTextbox.Text = "";
            subjectTextbox.Text = "";
            bodyTextbox.Text = "";
        }
    }
}
