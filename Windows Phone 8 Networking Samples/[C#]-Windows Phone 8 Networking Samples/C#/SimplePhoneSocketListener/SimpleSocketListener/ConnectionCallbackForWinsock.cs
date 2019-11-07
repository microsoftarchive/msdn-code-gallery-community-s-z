using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WinsockListener;

namespace SimpleSocketListener
{
    public class ConnectionCallbackForWinsock : IClientConnectedCallback
    {
        Dispatcher _d;
        TextBlock _txtReceived;

        public void Init(Dispatcher d, TextBlock t)
        {
            _d = d;
            _txtReceived = t;
        }

        public void ClientConnectedServer(string ipAddressOfClient)
        {
            _d.BeginInvoke(() =>
            {
                _txtReceived.Text = DateTime.Now.ToString() + "-" + ipAddressOfClient + "\n" + _txtReceived.Text;
            });

        }
    }
}
