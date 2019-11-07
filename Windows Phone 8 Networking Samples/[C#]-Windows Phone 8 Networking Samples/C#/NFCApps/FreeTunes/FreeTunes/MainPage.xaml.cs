using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FreeTunes.Resources;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;
using System.IO;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework;

namespace FreeTunes
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const string SaveAsRingToneText = "Save as Ringtone";
        private const string DownloadNowText = "Download Now";
        private const string CancelDownloadText = "Cancel Download";
        private const string PlaySongText = "Play Song";
        private const string PauseSongText = "Pause Song";
        private WebClient _webClient;
        
        private bool _downloading;
        private bool _downloadCanceled;
        private bool _songInitialized;
        public bool _songPlaying;

        public class SongData 
        {
            public string _songFileName;
            public bool _haveSong;
            public bool _playFromURI;
        }
        private SongData songData;

        // Constructor
        public MainPage()
        {
            songData = new SongData();
            songData._playFromURI = false;  
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("artist"))
            {
                ArtistTextBox.Text = HttpUtility.UrlDecode(NavigationContext.QueryString["artist"]);
            }

            if (NavigationContext.QueryString.ContainsKey("title"))
            {
                SongTitleTextBox.Text = HttpUtility.UrlDecode(NavigationContext.QueryString["title"]);                
            }               

            if (NavigationContext.QueryString.ContainsKey("DataUri"))
            {
                var data = HttpUtility.UrlDecode(NavigationContext.QueryString["DataUri"]);
                UriTextBox.Text = data;

                // make sure we have a valid URI
                Uri dataUri = null;
                try
                {
                    dataUri = new Uri(data);
                }
                catch (Exception)
                {
                    StatusTextBlock.Text = "I'm sorry something is wrong with the URI";
                    return;
                }

                StatusTextBlock.Text = "Congratulations you found a free song!";
                MyMedia.Source = dataUri;
                _songInitialized = true;
            }
        }
        
        private void PlaySongButton_Click(object sender, RoutedEventArgs e)
        {
            if (_songPlaying)
            {
                PlaySongButton.Content = PlaySongText;
                MyMedia.Pause();
            }
            else
            {                
                // Check if background music is playing (this is an certification app requirement)
                if (!MediaPlayer.GameHasControl)
                {
                    FrameworkDispatcher.Update();

                    var result = MessageBox.Show("Background music is  playing, are you sure you want to play this song?  It will stop the music?", "Music Playing", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.Cancel)
                        return;
                }

                if (!_songInitialized)
                {

                    MyMedia.AutoPlay = true;
                    if (songData._playFromURI)
                    {
                        // make sure we have a valid URI
                        Uri dataUri = null;
                        try
                        {
                            dataUri = new Uri(UriTextBox.Text);
                        }
                        catch (Exception)
                        {
                            StatusTextBlock.Text = "I'm sorry something is wrong with the URI";
                            return;
                        }
                        // Turn auto play on
                        MyMedia.Source = dataUri;
                    }
                    else
                    {
                        using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            using (Stream isoStream = storage.OpenFile(songData._songFileName, FileMode.Open))
                            {
                                MyMedia.SetSource(isoStream);
                            }
                        }
                    }
                   _songInitialized = true;
                }

                PlaySongButton.Content = PauseSongText;
                MyMedia.Play();
            }
            _songPlaying = !_songPlaying;
        }     

        private void DownloadSongButton_Click(object sender, RoutedEventArgs e)
        {
            DownloadSong();
        }
        
        private void DownloadSong()
        {
            if (String.IsNullOrEmpty(UriTextBox.Text))
            {
                MessageBox.Show("Please provide a song URL.");
                return;
            }

            if (String.IsNullOrEmpty(ArtistTextBox.Text))
            {
                MessageBox.Show("Please add an artist name.");
                return;
            }

            if (String.IsNullOrEmpty(SongTitleTextBox.Text))
            {
                MessageBox.Show("Please add a song name.");
                return;
            }

            // Make sure we have a valid URI
            Uri dataUri = null;
            try
            {
                dataUri = new Uri(UriTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("The Song URL is invalid, please fix it.");
                return;
            }

            // If we're already downloading then it's a cancel action
            if (!_downloading)
            {
                songData._haveSong = false;
                _downloadCanceled = false;
                DownloadSongButton.Content = CancelDownloadText;
                MyProgressBar.Visibility = Visibility.Visible;
                MyProgressBar.IsIndeterminate = true;

                //setup WebClient
                _webClient = new WebClient();
                _webClient.DownloadProgressChanged += WebClientDownloadProgressChanged;
                _webClient.OpenReadCompleted += WebClientDownloadReadCompleted;
                _webClient.OpenReadAsync(dataUri);                
                DownloadProgressBar.Visibility = Visibility.Visible;
                StatusTextBlock.Text = "Downloading...";
            }
            _downloading = !_downloading;
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (_downloadCanceled)
                    return;

                if (DownloadProgressBar.Value <= DownloadProgressBar.Maximum)
                {
                    DownloadProgressBar.Value = e.ProgressPercentage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WebClientDownloadReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // This gets tripped if we cancel download
                return;
            }

            if (_downloadCanceled)
                return;

            try
            {
                songData._songFileName = String.Format("{0}{1}.mp3", ArtistTextBox.Text, SongTitleTextBox.Text);
                if (!IsSpaceAvailable(e.Result.Length))
                {
                    MessageBox.Show("There's not enough free space on your phone to store this song.");
                    return;
                }
                var sw = new SongWriter(this.Dispatcher, StatusTextBlock);
                sw.WriteFileToIsoStoreFromHTTP(songData._songFileName, e.Result);
                sw.SaveToMediaLibrary(ArtistTextBox.Text, SongTitleTextBox.Text, songData._songFileName);

                DownloadSongButton.Content = DownloadNowText;

                DownloadProgressBar.Visibility = Visibility.Collapsed;
                StatusTextBlock.Text = "The song has been added to your music library!";
                songData._haveSong = true;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error Downloading: " + ex.Message;
            }

            MyProgressBar.Visibility = Visibility.Collapsed;
            MyProgressBar.IsIndeterminate = false;

            _downloading = false;
        }


        private static bool IsSpaceAvailable(long spaceReq)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var maxAvailableSpace = store.AvailableFreeSpace;
                return spaceReq <= maxAvailableSpace || store.IncreaseQuotaTo(store.Quota + spaceReq);
            }
        }


        private void UriTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // If URI was changed mark song as not initialized so it's reloaded if play is pressed
            _songInitialized = false;
        }

        private void ConnectToPeer_Click(object sender, RoutedEventArgs e)
        {
            NFCConnection nfc = new NFCConnection(ref songData, SongTitleTextBox, ArtistTextBox, StatusTextBlock, this.Dispatcher);
            nfc.AdvertiseForPeers(songData);

        }        
    }
}