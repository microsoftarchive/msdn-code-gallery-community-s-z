using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SimplePhoneSocketClient.Resources;
using WinsockClient;
using Windows.Networking.Sockets;
using Windows.Networking;

namespace SimplePhoneSocketClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdSendWithWinsock_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            var winSockclient = new CWinsockClient();
            winSockclient.ConnectThroughSocket(this.txtServer.Text, out error);
            if (error != "")
                MessageBox.Show("Error: " + error);
            else
                txtConnections.Text = DateTime.Now.ToString() + " - Winsock Connection:" + txtServer.Text;
        }

        private async void cmdSendManaged_Click(object sender, RoutedEventArgs e)
        {
                var managedSockets = new ManagedSockets();
              
                try
                {
                    await managedSockets.SendUsingManagedSocketsAsync(txtServer.Text);
                    txtConnections.Text = String.Format("{0}: Managed connection {1}{2}", DateTime.Now, txtServer.Text, Environment.NewLine);
                }
                catch (Exception ex)
                {
                    txtConnections.Text += String.Format("{0}: {1}{2}", DateTime.Now, ex.Message, Environment.NewLine);
                }  
        }

        private async void cmdSendWinRT_Click(object sender, RoutedEventArgs e)
        {

            var streamScoket = new StreamSocket();
            await streamScoket.ConnectAsync(new HostName(txtServer.Text), "4533");

            txtConnections.Text = DateTime.Now.ToString() + " - WinRT Connection:" + txtServer.Text;

        }






    }
}