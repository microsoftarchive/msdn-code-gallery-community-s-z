using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace FreeTunes
{
    public class SongWriter
    {
        TextBlock _MessageBlock;
        Dispatcher _d;
        public string _songTitle;
        public string _artistTitle;
        public string _songFileName;
        
        public SongWriter(Dispatcher d, TextBlock mb)
        {
            _MessageBlock = mb;
            _d = d;
        }

        public async Task WriteSongFromSocketStream(StreamSocket socket)
        {
            UInt32 totalBytesRead = 0;
            UInt32 initialLength = 4; //for the int @ the front of every packet that denotes size of the packet coming
            var dr = new DataReader(socket.InputStream);
            UInt32 packetLength = 0;

            //get song title _songTitle
            if ((packetLength = await GetNextPacketSize(initialLength, dr)) > 0)
            {
                if ((await dr.LoadAsync((uint)packetLength)) != packetLength)
                {
                    //the only way this would happen is if the sender sent a song title incorrectly
                    WriteMessageText("Couldn't obtain song title.  Packet size mismatch.\n");
                    return;
                }
                else
                {
                    _songTitle = dr.ReadString(packetLength);
                }
            }
            else
            {
                WriteMessageText("Couldn't obtain song title\n");
                return;
            }

            //get _artistTitle
            if ((packetLength = await GetNextPacketSize(initialLength, dr)) > 0)
            {
                if ((await dr.LoadAsync((uint)packetLength)) != packetLength)
                {
                    WriteMessageText("Couldn't obtain artist title.  Packet size mismatch.\n");
                    return;
                } else{
                    _artistTitle = dr.ReadString(packetLength);
                }
            }
            else
            {
                WriteMessageText("Couldn't obtain artist title\n");
                return;
            }

            //generate song filename _songFilename
            _songFileName = String.Format("{0}{1}.mp3", _artistTitle, _songTitle);
            IfFileExistsInIsoStoreDeleteIt(_songFileName);

            var fileStream = new IsolatedStorageFileStream(_songFileName, FileMode.CreateNew, IsolatedStorageFile.GetUserStoreForApplication());
            while ((packetLength = await GetNextPacketSize(initialLength, dr)) > 0)
            {
                //read buffer of that size
                if (packetLength > 0)
                {
                    byte[] buffer = new byte[packetLength];
                    await dr.LoadAsync(packetLength);
                    dr.ReadBytes(buffer);

                    //write to iso store song file
                    fileStream.Write(buffer, 0, (int)packetLength);
                }

                totalBytesRead += packetLength;
                WriteMessageText("Receiving song data from socket; total bytes received:" + totalBytesRead.ToString() + "\n");
            }

            fileStream.Close();
            SaveToMediaLibrary(_artistTitle, _songTitle, _songFileName);

            WriteMessageText("Completed receiving song data from socket; total bytes received:" + totalBytesRead.ToString() + "\n\nPress 'Play Song Now' to play the song.");

        }

        private static async Task<UInt32> GetNextPacketSize(uint initialLength, DataReader dr)
        {
            //get packet length
            await dr.LoadAsync(initialLength);
            UInt32 packetLength = dr.ReadUInt32();
            return packetLength;
        }

        private static void IfFileExistsInIsoStoreDeleteIt(string songFileName)
        {
            // If file already exists delete it
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(songFileName))
                    store.DeleteFile(songFileName);
            }
        }


        public void WriteFileToIsoStoreFromHTTP(string songFileName, Stream songFileStream)
        {
            // If file already exists delete it
            IfFileExistsInIsoStoreDeleteIt(songFileName);

            // Save file to Isolated Storage from HTTP stream
            using (var fileStream = new IsolatedStorageFileStream(songFileName, FileMode.CreateNew, IsolatedStorageFile.GetUserStoreForApplication()))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                uint totalBytesRead = 0;

                while ((bytesRead = songFileStream.Read(buffer, 0, buffer.Length)) != 0)
                {

                    totalBytesRead += (uint)bytesRead;
                    
                    fileStream.Write(buffer, 0, bytesRead);

                    WriteMessageText("Receiving song data from HTTP; total bytes received:" + totalBytesRead.ToString() + "\n");
                }

                WriteMessageText("Done receiving song data from HTTP; total bytes received:" + totalBytesRead.ToString() + "\n");
            }

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

        public void SaveToMediaLibrary(string Artist,  string songTitle, string fileName)
        {

            //see if we already have the song
            var library = new MediaLibrary();
            if (library.Songs.FirstOrDefault(c => c.Name == songTitle) == null)
            {
                // Save to the music library
                SongMetadata songData = new SongMetadata();
                songData.AlbumName = "Free Tunes";
                songData.ArtistName = Artist;
                songData.Name = songTitle;
                library.SaveSong(new Uri(fileName, UriKind.Relative), songData, SaveSongOperation.CopyToLibrary);
            }
        }

    }
}
