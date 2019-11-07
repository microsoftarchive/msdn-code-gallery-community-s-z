using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SimpleSocketListener.Resources;
using System.Net.Sockets;
using Windows.Networking.Sockets;
using Windows.Networking;
using Windows.Storage.Streams;
using WinsockListener;

namespace SimpleSocketListener
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        private void cmdListenWinsock_Click(object sender, RoutedEventArgs e)
        {
            string ip;
            string error;

            var callbackObject = new ConnectionCallbackForWinsock();
            callbackObject.Init(Dispatcher, txtReceived);

            var winsockListener = new CWinsockListener();

            //setup the callback object so the winsock thread can tell us when it gets connections
            winsockListener.SetClientCallBack(callbackObject);

            //start the server listening
            winsockListener.StartSocketServer(out ip, out error);
            if (error != "")
                MessageBox.Show("Error:" + error);
            else
            {
                //server ip address
                this.txtIPAddress.Text = ip;
            }
        }
        
        private void cmdListenManaged_Click(object sender, RoutedEventArgs e)
        {
            string ipAddress;
            var managedListen = new ManagedSockets(this.Dispatcher, this.txtReceived);
            managedListen.ListenOnManagedSocket(out ipAddress);
            txtIPAddress.Text = ipAddress;

        }

        private void cmdListenWinRT_Click(object sender, RoutedEventArgs e)
        {
            string ip = "";
            var winRTListen = new WinRTSockets(this.Dispatcher, this.txtReceived);
            winRTListen.ListenOnWinRTSocket(out ip);
            this.txtIPAddress.Text = ip;


        }




    }
}