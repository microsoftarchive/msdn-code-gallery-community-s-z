using System;
using System.Collections.ObjectModel;
using System.IO;
using Windows.ApplicationModel.Background;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp;
using Windows.UI.Core;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SocketClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StreamSocket _clientSocket;

        private string BgTaskName = "BGSocket";
        private string BgEntryPoint = "BGSocket.BgSocket";
        private BackgroundTaskRegistration _bgSocketask;
        private int _count = 0;
        private string socketId = "mainSocket";
        private bool send = true;

        readonly ObservableCollection<string> dataInfo = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();
            CreateBgTask();
            CreateSocket();
            lstBox.ItemsSource = dataInfo;
            App.mainPage = this;


        }

        private void CreateBgTask()
        {
            IBackgroundTrigger socketTrigger = new SocketActivityTrigger();
            _bgSocketask = BackgroundTaskHelper.Register(BgTaskName, BgEntryPoint, socketTrigger);
        }

        public async void TransferCall()
        {
            if (_clientSocket == null) return;
            await _clientSocket.CancelIOAsync();

            var contextWrite = new DataWriter();
            contextWrite.WriteInt32(_count);
            var socketContext = new SocketActivityContext(contextWrite.DetachBuffer());
            _clientSocket.TransferOwnership(socketId, socketContext);
        }

        private async void CreateSocket()
        {
            try
            {
                HostName hostName = new HostName("192.168.2.116");
                _clientSocket = new StreamSocket();

                _clientSocket.Control.NoDelay = false;

                if (_bgSocketask != null)
                {
                    //EnableTransferOwnership
                    _clientSocket.EnableTransferOwnership(_bgSocketask.TaskId, SocketActivityConnectedStandbyAction.Wake);
                }

                //Connect the Server socket
                await _clientSocket.ConnectAsync(hostName, "6000");

                Stream streamOut = _clientSocket.OutputStream.AsStreamForWrite();
                StreamWriter writer = new StreamWriter(streamOut);
                string request = "test";
                await writer.WriteLineAsync(request);
                await writer.FlushAsync();

                while (send)
                {
                    var reader = new DataReader(_clientSocket.InputStream)
                    {
                        InputStreamOptions = InputStreamOptions.Partial
                    };
                    //Read the packet information
                    await reader.LoadAsync(256);
                    var response = reader.ReadString(reader.UnconsumedBufferLength);
                    reader.DetachStream();

                    //Display in GUI
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        dataInfo.Add(response);
                    });
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnTransfer_OnClick(object sender, RoutedEventArgs e)
        {
            TransferCall();
        }
    }
}
