using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SimplePhoneSocketClient
{
    class ManagedSockets
    {
        static readonly int PORT = 4533;
        TaskCompletionSource<object> completionSource;
        public Task SendUsingManagedSocketsAsync(string strServerIP)
        {
            // enable asynchronous task completion
            completionSource = new TaskCompletionSource<object>();
            // create a new socket 
            var socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            // create endpoint 
            var ipAddress = IPAddress.Parse(strServerIP);
            var endpoint = new IPEndPoint(ipAddress, PORT);

            // create event args 
            var args = new SocketAsyncEventArgs();
            args.RemoteEndPoint = endpoint;
            args.Completed += SocketConnectCompleted;

            // check if the completed event will be raised. If not, invoke the handler manually. 
            if (!socket.ConnectAsync(args))
                SocketConnectCompleted(args.ConnectSocket, args);

            return completionSource.Task;
        }

        private void SocketConnectCompleted(object sender, SocketAsyncEventArgs e)
        {
            // check for errors 
            if (e.SocketError != System.Net.Sockets.SocketError.Success)
            {
                completionSource.SetException(new Exception("Failed with " + e.SocketError));

                // do some resource cleanup 
                CleanUp(e);
                return;
            } else
            {
                completionSource.SetResult(null);
            }

            // check what has been executed 
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    HandleConnect(e);
                    break;
                case SocketAsyncOperation.Send:
                    HandleSend(e);
                    break;
            }
        }

        private void HandleConnect(SocketAsyncEventArgs e)
        {
            if (e.ConnectSocket != null)
            {
                //Sending data would happen here...
                CleanUp(e);
            }
        }

        private void HandleSend(SocketAsyncEventArgs e)
        {
            //Successful connection; process any data received here...
            // free resources 
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
