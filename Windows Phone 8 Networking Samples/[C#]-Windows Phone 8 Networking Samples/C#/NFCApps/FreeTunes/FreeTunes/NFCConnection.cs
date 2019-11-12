using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace FreeTunes
{
    public class NFCConnection
    {
        TextBlock _MessageBlock;
        StreamSocket _proximitySocket;
        DataWriter _dataWriter;
        Dispatcher _d;
        MainPage.SongData _sd;
        TextBox _SongTitleTextBox, _ArtistTitleTextBox;
        string _SongTitleText, _ArtistTitleText;

        public NFCConnection(ref MainPage.SongData sd, TextBox SongTitleTextBox, TextBox ArtistTitleTextBox, TextBlock mb, Dispatcher d)
        {
            //setup so we can communicate back to the main form
            _SongTitleTextBox = SongTitleTextBox;
            _ArtistTitleTextBox = ArtistTitleTextBox;
            _SongTitleText = SongTitleTextBox.Text;
            _ArtistTitleText = ArtistTitleTextBox.Text;

            _sd = sd;
            _MessageBlock = mb;
            _d = d;
        }


        public void AdvertiseForPeers(MainPage.SongData songData)
        {
            //Init PeerFinder to make a connection from phone->phone
            PeerFinder.TriggeredConnectionStateChanged += TriggeredConnectionStateChanged;
            PeerFinder.Start();

            WriteMessageText("You can now tap to connect a peer device that is also advertising for a connection.\n", true);

        }

        private void TriggeredConnectionStateChanged(object sender, Windows.Networking.Proximity.TriggeredConnectionStateChangedEventArgs e)
        {
            if (e.State == Windows.Networking.Proximity.TriggeredConnectState.PeerFound)
            {
                WriteMessageText("Peer found. Keep your devices together until the connection is established.\n");
            }
            
            if (e.State == Windows.Networking.Proximity.TriggeredConnectState.Completed)
            {
                WriteMessageText("Connected!\n");
                //Note you could cache the socket information for reconnection (making it so you don't have to tap again).
                SendOrReceiveSong(e.Socket);
            }

            //failure to connect
            if (e.State == Windows.Networking.Proximity.TriggeredConnectState.Failed && e.State == Windows.Networking.Proximity.TriggeredConnectState.Canceled)
            {
                WriteMessageText("Failed to connect!  Please try to pair the devices again\n");
            }
        }

        // Reference socket streams for writing and reading messages.
        private void SendOrReceiveSong(Windows.Networking.Sockets.StreamSocket socket)
        {
            _proximitySocket = socket;

            if (!_sd._haveSong)
            {
                ReceiveSongFromSocket();
            }
            else
            {
                SendSongOverSocket();
            }
        }

        private async void ReceiveSongFromSocket()
        {
            WriteMessageText("Receiving song data...\n");
            try
            {
                SongWriter sw = new SongWriter(_d, _MessageBlock);
                await sw.WriteSongFromSocketStream(_proximitySocket);
                
                //udpate GUI w/ song written
                _d.BeginInvoke(() =>
                {
                    _sd._haveSong = true;
                    _sd._songFileName = sw._songFileName;
                    _sd._playFromURI = false;  

                    _SongTitleTextBox.Text = sw._songTitle;
                    _ArtistTitleTextBox.Text = sw._artistTitle;
                });


            }
            catch (Exception e)
            {
                WriteMessageText("Error: " + e.Message + "\n");
                _proximitySocket.Dispose();
            }
        }


        //send song data over the socket
        //this uses an app specific socket protocol: send title, artist, then song data
        private async void SendSongOverSocket()
        {

            // Create DataWriter for writing to peer.
            _dataWriter = new DataWriter(_proximitySocket.OutputStream);
                         
            //send song title _songTitle
            await SendStringOverSocket(_SongTitleText);
            //send _artistTitle
            await SendStringOverSocket(_ArtistTitleText );

            // read song from Isolated Storage and send it
            using (var fileStream = new IsolatedStorageFileStream(_sd._songFileName, FileMode.Open, FileAccess.Read, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                WriteMessageText("Sending song data.\n");
                byte[] buffer = new byte[1024];
                int bytesRead;
                int readCount = 0;
                Int64 length = fileStream.Length;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    readCount += bytesRead;
                    //size of the packet
                    _dataWriter.WriteInt32(bytesRead);
                    //packet data sent
                    _dataWriter.WriteBytes(buffer);
                    try
                    {
                        await _dataWriter.StoreAsync();
                        WriteMessageText("Sending song data; total bytes sent:" + readCount.ToString() + "\n");
                    }
                    catch (Exception e)
                    {
                        WriteMessageText("Send error: " + e.Message + "\n");
                    }
                }
                WriteMessageText("Completed sending song data; total bytes sent:" + readCount.ToString() + "\n");

            }
        }

        private async Task SendStringOverSocket(string stringToSend)
        {
            UInt32 length = (UInt32)stringToSend.Length;
            //size of the packet/string
            _dataWriter.WriteUInt32(length);
            _dataWriter.WriteString(stringToSend);
            await _dataWriter.StoreAsync();
        }


        private void StopFindingPeers()
        {
            Windows.Networking.Proximity.PeerFinder.Stop();
            if (_proximitySocket != null) { _proximitySocket.Dispose(); _proximitySocket = null; }
        }

        async private void WriteMessageText(string message, bool overwrite = true)
        {
            _d.BeginInvoke(() =>
            {
                if (overwrite)
                    _MessageBlock.Text = message;
                else
                    _MessageBlock.Text += message;
            });
        }

    }
}
