using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using BoxDrive.ViewModel;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Popups;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Windows.System.Profile;
using System.Collections.Generic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BoxDrive.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Youtube : Page
    {
        private const string API_Key = "AIzaSyDTCxULvKCL8sTlpE1gsL9bJfxB9Yj1Zks";
        YoutubeViewModel youtubeViewModel = new YoutubeViewModel(0, "");
        MainViewModel mainViewModel = new MainViewModel();
        public Youtube()
        {
            this.InitializeComponent();

            lstYoutubeMenu.DataContext = new YoutubeViewModel(0, "menu");


            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Color.FromArgb(255, 242, 242, 242);
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 242, 242, 242); ;
            titleBar.ButtonForegroundColor = Colors.Black;

           
        }

       

        private void lstYoutubeMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstCategories.SelectedIndex = -1;
        
            lstCategories.DataContext = new YoutubeViewModel(lstYoutubeMenu.SelectedIndex, "categories");
            splSubcrible.IsPaneOpen = true;
            //splmenu.IsPaneOpen = false;
            

        }


        string tag;
        string style;
        private async void lstCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               
                lstChannels.SelectedIndex = -1;
                pivContent.SelectedIndex = 0;
                if (lstCategories.SelectedIndex != -1)
                {
                    var category = lstCategories.SelectedItem as Model.MenuMain;


                    txtTitleHeader.Text = category.Name;

                    if (category.Name == "Popular Recently" || category.Name == "Billboard Top Songs" || category.Name == "Just-Released Music Videos")
                    {
                        tag = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=30&playlistId=" + category.link + "&key=" + API_Key;
                        if(grdVideo.Visibility==Visibility.Visible)
                        {
                            youtubeViewModel.SetVideoPlaylist(tag, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                           
                        }
                        else if(grdVideoMobile.Visibility==Visibility.Visible)
                        {
                            youtubeViewModel.SetVideoPlaylist(tag, grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                        }
                        
                        style = "setVideoPlaylist";
                    }
                    else
                    {
                        tag = "https://www.googleapis.com/youtube/v3/playlists?part=snippet&maxResults=3&channelId=" + category.link + "&key=" + API_Key;
                        if (grdVideo.Visibility == Visibility.Visible)
                        {
                            youtubeViewModel.SetVideoChannel(tag, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                        }
                        else if(grdVideoMobile.Visibility==Visibility.Visible)
                        {
                            youtubeViewModel.SetVideoChannel(tag, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                        }
                        style = "setVideoChannel";
                    }
                }
                else
                    return;

                if(stackListMobile.Visibility==Visibility.Visible)
                {
                    splSubcrible.IsPaneOpen = false;
                    splmenu.IsPaneOpen = false;
                }
               
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message, "Error:");
                await dialog.ShowAsync();
            }

        }

        private void ForwardVideo_Click(object sender, RoutedEventArgs e)
        {
            if(grdVideo.Visibility==Visibility.Visible)
            {
                if (style == "setVideoPlaylist")
                {
                    youtubeViewModel.SetVideoPlaylist(tag + "&pageToken=" + txtNextToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else if (style == "setVideoChannel")
                {
                    youtubeViewModel.SetVideoChannel(tag + "&pageToken=" + txtNextToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else
                {
                    youtubeViewModel.SetVideoSearch(tag + "&pageToken=" + txtNextToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
            }
            else if(grdVideoMobile.Visibility==Visibility.Visible)
            {
                if (style == "setVideoPlaylist")
                {
                    youtubeViewModel.SetVideoPlaylist(tag + "&pageToken=" + txtNextToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else if (style == "setVideoChannel")
                {
                    youtubeViewModel.SetVideoChannel(tag + "&pageToken=" + txtNextToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else
                {
                    youtubeViewModel.SetVideoSearch(tag + "&pageToken=" + txtNextToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
            }
           

        }

        private void BackVideo_Click(object sender, RoutedEventArgs e)
        {
            if(grdVideo.Visibility==Visibility.Visible)
            {
                if (style == "setVideoPlaylist")
                {
                    youtubeViewModel.SetVideoPlaylist(tag + "&pageToken=" + txtPreviousToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else if (style == "setVideoChannel")
                {
                    youtubeViewModel.SetVideoChannel(tag + "&pageToken=" + txtPreviousToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else
                {
                    youtubeViewModel.SetVideoSearch(tag + "&pageToken=" + txtPreviousToken.Text, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
                }
            }
            else if(grdVideoMobile.Visibility==Visibility.Visible)
            {
                if (style == "setVideoPlaylist")
                {
                    youtubeViewModel.SetVideoPlaylist(tag + "&pageToken=" + txtPreviousToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else if (style == "setVideoChannel")
                {
                    youtubeViewModel.SetVideoChannel(tag + "&pageToken=" + txtPreviousToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
                else
                {
                    youtubeViewModel.SetVideoSearch(tag + "&pageToken=" + txtPreviousToken.Text,grdVideo, grdVideoMobile, txtNextToken, txtPreviousToken);
                }
            }
            

        }

        private void searchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            lstCategories.SelectedIndex = -1;
            lstYoutubeMenu.SelectedIndex = -1;
            lstChannels.SelectedIndex = -1;
            pivContent.SelectedIndex = 0;

            var regex_queryText = new Regex(@"\W");
            string queryText = "";
            if (searchBox.Visibility==Visibility.Visible)
            {
                queryText = regex_queryText.Replace(searchBox.Text, "");
            }
            else if(searchBoxMobile.Visibility==Visibility.Visible)
            {
                queryText = regex_queryText.Replace(searchBoxMobile.Text, "");
            }
             
            tag = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=" + queryText + "&maxResults=50&type=video&key=" + API_Key;
            youtubeViewModel.SetVideoSearch(tag, grdVideo,grdVideoMobile, txtNextToken, txtPreviousToken);
            style = "searchVideo";

        }


        string id;
        string thumb;
        private async void grdVideo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var playlistOrVideo = ((GridView)sender).SelectedItem as Model.YoutubePlaylistItems.Item;
                var VideoSearch = ((GridView)sender).SelectedItem as Model.YoutubeSearch.Item;


                if (playlistOrVideo != null)
                {
                    id = playlistOrVideo.snippet.resourceId.videoId;
                    txtTitleVideo.Text = playlistOrVideo.snippet.title;
                    txtChannel.Text = playlistOrVideo.snippet.channelTitle;
                    if (playlistOrVideo.snippet.thumbnails != null)
                    {
                        thumb = playlistOrVideo.snippet.thumbnails.@default.url;
                    }
                    else
                        thumb = "Assets/nologo.jpg";


                    mainViewModel.GetVideoYoutubeSource(playlistOrVideo.snippet.resourceId.videoId, MediaPlayer, txtRequestUrl, txtTypeVideo);

                }
                else if (VideoSearch != null)
                {
                    id = VideoSearch.id.videoId;
                    txtTitleVideo.Text = VideoSearch.snippet.title;
                    txtChannel.Text = VideoSearch.snippet.channelTitle;
                    
                    if (VideoSearch.snippet.thumbnails != null)
                    {
                        thumb = VideoSearch.snippet.thumbnails.@default.url;
                    }
                    else
                        thumb = "Assets/nologo.jpg";
                    mainViewModel.GetVideoYoutubeSource(VideoSearch.id.videoId, MediaPlayer, txtRequestUrl, txtTypeVideo);
                }
                else
                    return;

                pivContent.SelectedIndex = 1;

            }
            catch(Exception)
            {
                var dialog = new MessageDialog("Could not play this video. Please to pick up other video");
                await dialog.ShowAsync();
            }
           
        }

        private void grdMedia_LayoutUpdated(object sender, object e)
        {
            MediaPlayer.Width = grdMedia.ActualWidth;
            MediaPlayer.Height = grdMedia.ActualHeight;
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            //
            if(togAuto.IsOn==true)
            {
                MediaPlayer.IsLooping = false;
                if(grdVideo.Visibility==Visibility.Visible)
                {
                    if (grdVideo.SelectedIndex > 0 || grdVideo.SelectedIndex < grdVideo.Items.Count)
                    {
                        grdVideo.SelectedIndex++;
                        //grdVideoMobile.SelectedIndex++;
                    }
                    else
                    {
                        grdVideo.SelectedIndex = 0;
                        //grdVideoMobile.SelectedIndex = 0;
                    }
                }
                else if(grdVideoMobile.Visibility==Visibility.Visible)
                {
                    if (grdVideoMobile.SelectedIndex > 0 || grdVideoMobile.SelectedIndex < grdVideoMobile.Items.Count)
                    {
                        //grdVideo.SelectedIndex++;
                        grdVideoMobile.SelectedIndex++;
                    }
                    else
                    {
                        //grdVideo.SelectedIndex = 0;
                        grdVideoMobile.SelectedIndex = 0;
                    }
                }

               
                    
            }
            else
            {
                MediaPlayer.IsLooping = true;
            }
        }

        private async void MediaPlayer_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            //
            var dialog = new MessageDialog("Couldn't play this video. Please to next videos");
            await dialog.ShowAsync();
        }

        private void MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

            youtubeViewModel.GetInformationOfVideo(id, txtlikeCount, txtDislikeCount, txtViewAll);
        }

      
        private void grdContent_LayoutUpdated(object sender, object e)
        {
            grdVideo.Width = grdContent.ActualWidth;
            grdVideoMobile.Width = grdContent.ActualWidth;
        }
       

        private void DownloadManager_LayoutUpdated(object sender, object e)
        {
            lstDownloader.Width = grdDownloadManager.ActualWidth;
            lstDownloader.Height = grdDownloadManager.ActualHeight;
            
        }


        ObservableCollection<Downloader> downloadList = new ObservableCollection<Downloader>();
        private void btnDownload_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pivContent.SelectedIndex = 2;
            downloadList.Add(new Downloader(txtRequestUrl.Text, txtTitleVideo.Text, thumb, txtTypeVideo.Text));
            lstDownloader.ItemsSource = downloadList;

        }

        

      

        private void stackList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            splmenu.IsPaneOpen = !splmenu.IsPaneOpen;
            
        }

        private void stackHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            lstChannels.SelectedIndex = -1;
            pivContent.SelectedIndex = 0;
            splmenu.IsPaneOpen = !splmenu.IsPaneOpen;
            txtTitleHeader.Text = "Home";


        }

        private void stackDownloadManager_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pivContent.SelectedIndex = 2;
        }

        private void stackVideo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pivContent.SelectedIndex = 1;
        }
       

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            pivContent.SelectedIndex = 0;
        }

        private void SymbolIcon_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            pivContent.SelectedIndex = 3;
        }


        bool back = false;
        private void symNavigationBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (pivotIndex.Count > 0)
            {
                back = true;
                if (pivotIndex.Peek() == pivContent.SelectedIndex) pivotIndex.Pop();

                pivContent.SelectedIndex = pivotIndex.Pop();
                pivotIndex.Push(pivContent.SelectedIndex);
            }
            else
                return;
        }

        Stack<int> pivotIndex=new Stack<int>();

        private void pivContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            

            if (!back)
            {               
                
                pivotIndex.Push(pivContent.SelectedIndex);
                
            }
            else
            {
                back = false;
                
            }


            if(pivContent.SelectedIndex>0)
            {
                symNavigationBack.Visibility = Visibility.Visible;
            }
            else
                symNavigationBack.Visibility = Visibility.Collapsed;


            if(pivContent.SelectedIndex==0)
            {
                txtTitleHeader.Text = "Home";
                lstChannels.SelectedIndex = -1;
            }
            else if(pivContent.SelectedIndex==1)
            {
                lstChannels.SelectedIndex = 0;
            }
            else
            {
                lstChannels.SelectedIndex = 1;
            }
          

        }

        private void lstChannels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstChannels.SelectedIndex==0)
            {
                txtTitleHeader.Text = "Video";
            }
            else if(lstChannels.SelectedIndex==1)
            {
                txtTitleHeader.Text = "Download";
            }
        }

        
    }
}
