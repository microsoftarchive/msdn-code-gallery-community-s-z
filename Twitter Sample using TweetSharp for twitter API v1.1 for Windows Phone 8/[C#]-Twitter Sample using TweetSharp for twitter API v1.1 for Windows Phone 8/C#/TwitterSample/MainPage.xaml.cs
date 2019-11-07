using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell;
using TweetSharp;
using TwitterSample.Resources;

namespace TwitterSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string API_key = "API key";
        private string API_secret = "API secret";
        private string Access_token_secret = "Access token";
        private string Access_token = "Access token";

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        //Use ListTweetsOnUserTimeline to get all tweets from user
        private void GetUser_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string searhScreenName = "@dvlup";

            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                var service = new TwitterService(API_key, API_secret);
                service.AuthenticateWith(Access_token, Access_token_secret);
                llsSearchTwitterResults.ItemsSource = null;

                //ScreenName - twitter user.
                service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = searhScreenName }, (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        this.Dispatcher.BeginInvoke(() => 
                        {
                            Header.Text = searhScreenName;
                            llsSearchTwitterResults.ItemsSource = tweets.ToList(); 
                        });
                    }
                });     
            }
        }

        //Use Searh option to get specific hash tag rom twitter
        private void GetHashTag_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string searhHasTag = "#wpdev";

            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                var service = new TwitterService(API_key, API_secret);
                service.AuthenticateWith(Access_token, Access_token_secret);
                llsSearchTwitterResults.ItemsSource = null;

                var options = new SearchOptions { Q = searhHasTag, Count = 100 };
                service.Search(options, (tweets, response) =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            Header.Text = searhHasTag;
                            llsSearchTwitterResults.ItemsSource = tweets.Statuses.ToList();
                        });
                    }
                });
            }
        }

    }
}