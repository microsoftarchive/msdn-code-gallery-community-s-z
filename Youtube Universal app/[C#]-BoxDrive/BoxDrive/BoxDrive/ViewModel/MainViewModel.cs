using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace BoxDrive.ViewModel
{
    public class MainViewModel
    {
        YoutubeViewModel youtubeViewModel = new YoutubeViewModel(0,"");
        public async Task<string> querybyJson(string link)
        {
            HttpClient client = new HttpClient();
            string url = link;
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async void GetVideoYoutubeSource(string id, MediaElement media,TextBlock RequestUrl,TextBlock TypeVideo)
        {
            try
            {
                var videoSource = await YouTube.GetVideoUriAsync(id, YouTubeQuality.Quality720P);
                if (videoSource.Uri != null)
                {
                    media.Source = videoSource.Uri;
                    RequestUrl.Text = videoSource.Uri.ToString();
                    TypeVideo.Text = GetTypeYoutube(videoSource.Itag);
                    media.Play();
                }
                else
                {
                    var dialog = new MessageDialog("Couldn't get link from youtube");
                    await dialog.ShowAsync();
                }
            }
            catch(Exception)
            {
                var dialog = new MessageDialog("Could not play this video in your country!");
                await dialog.ShowAsync();
            }
           
        }

        private string GetTypeYoutube(int qualityVideo)
        {
            string flvOrMp4="";
            if (qualityVideo == 5 || qualityVideo == 34 || qualityVideo == 6 || qualityVideo == 35)
            {
                flvOrMp4 = ".flv";
            }
           
            else if (qualityVideo == 18 || qualityVideo == 22 || qualityVideo == 37 || qualityVideo == 38)
            {
                flvOrMp4 = ".mp4";
            }
           
            return flvOrMp4;
        }
    }
}
