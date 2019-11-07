using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SimpleSocketListener
{
    class ManagedSockets
    {

        const int PORT = 4533;
        Dispatcher _d = null;
        TextBlock _t;
        Socket _listenSocket = null;

        public ManagedSockets(Dispatcher d, TextBlock t)
        {
            _d = d;
            _t = t;
        }


        SocketAsyncEventArgs args = new SocketAsyncEventArgs();
        public void ListenOnManagedSocket(out string ipAddressListeningOn)
        {

            args.Completed += args_Completed;
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _listenSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            ipAddressListeningOn = (_listenSocket.LocalEndPoint as IPEndPoint).Address.ToString();
            _listenSocket.Listen(10);
            if (!_listenSocket.AcceptAsync(args))
            {
                args_Completed(_listenSocket, args);
            }
        }


        void args_Completed(object sender, SocketAsyncEventArgs e)
        {
            _d.BeginInvoke(() =>
            {
                _t.Text = DateTime.Now.ToString() + "-" + (e.AcceptSocket.RemoteEndPoint as IPEndPoint).Address.ToString() + "\n" + _t.Text;
            });
            CleanUp(e);
            
        }

        private void CleanUp(SocketAsyncEventArgs e)
        {
            if (e.ConnectSocket != null)
            {
                e.ConnectSocket.Shutdown(SocketShutdown.Both);
                e.ConnectSocket.Close();
            }
        }

    }
}
