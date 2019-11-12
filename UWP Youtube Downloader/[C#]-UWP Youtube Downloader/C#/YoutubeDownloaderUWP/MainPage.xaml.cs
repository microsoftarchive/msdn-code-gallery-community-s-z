using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YoutubeExtractor;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YoutubeDownloaderUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void lstDownload_LayoutUpdated(object sender, object e)
        {
            lstDownload.Width = gridRoot.ActualWidth;

        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
           




        }

        ObservableCollection<DownloadViewModel> downloadList = new ObservableCollection<DownloadViewModel>();
        private async void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string link = SearchBox.Text;
            string[] id = link.Split('=');
            try
            {
                IEnumerable<VideoInfo> videosInfors = DownloadUrlResolver.GetDownloadUrls(link);

                VideoInfo video = videosInfors.First(infor => infor.VideoType == VideoType.Mp4);

                downloadList.Add(new DownloadViewModel(video.DownloadUrl, video.Title, "https://i.ytimg.com/vi/" + id[1] + "/default.jpg", video.VideoExtension));
                lstDownload.ItemsSource = downloadList;
            }
            catch(Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();
            }

           
        }





    }
}
