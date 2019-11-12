using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace SimpleSocketListener
{
    class WinRTSockets
    {
        private StreamSocketListener _listener = new StreamSocketListener();
        const string PORT = "4533";
        
        Dispatcher _d = null;
        TextBlock _t;

        public WinRTSockets(Dispatcher d, TextBlock t)
        {
            _d = d;
            _t = t;
        }

        async private void Listen()
        {
            _listener.ConnectionReceived += listenerConnectionReceived;
            await _listener.BindServiceNameAsync(PORT);
        }

        private void listenerConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            //connected to socket.
            _d.BeginInvoke(() =>
            {
                _t.Text = DateTime.Now.ToString() + "-" + args.Socket.Information.RemoteHostName.DisplayName.ToString() + "\n" + _t.Text;
            });

        }

        public void ListenOnWinRTSocket(out string ipAddressListeningOn)
        {
            ipAddressListeningOn = "";
            foreach (var item in Windows.Networking.Connectivity.NetworkInformation.GetHostNames())
            {
                if (item.IPInformation != null)
                {
                    ipAddressListeningOn = item.DisplayName;
                    break;
                }
            }
            if (ipAddressListeningOn != "")
                Listen();
            else
            {
                _d.BeginInvoke(() => MessageBox.Show("Couldn't find an ip address to bind to. "));
            }


        }
    }
}
