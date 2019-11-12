using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OAuthTwitter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {       
        // REST API v1.1 https://dev.twitter.com/docs/api/1.1
        string _getHomeTimelineUrl = "https://api.twitter.com/1.1/statuses/home_timeline.json";
        string _getMentionsUrl = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
        string _getRetweetsOfMeUrl = "http://api.twitter.com/1.1/statuses/retweets_of_me.json";         

        string _consumerKey = "consumer key";
        string _consumerSecretKey = "consumer secret key";

        string _twitterRequestTokenUrl = "http://api.twitter.com/oauth/request_token";
        string _twitterAccessTokenUrl = "http://api.twitter.com/oauth/access_token";
        string _twitterAuthorizeUrl = "http://api.twitter.com/oauth/authorize";

        

        OAuthUtil oAuthUtil = new OAuthUtil();

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            consumerKey.Text = _consumerKey;
            consumerSecretKey.Text = _consumerSecretKey;
        }

        private async void getRequestToken_Click_1(object sender, RoutedEventArgs e)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            string sigBaseStringParams = "oauth_consumer_key=" + consumerKey.Text;

            sigBaseStringParams += "&" + "oauth_nonce=" + nonce;
            sigBaseStringParams += "&" + "oauth_signature_method=" + "HMAC-SHA1";
            sigBaseStringParams += "&" + "oauth_timestamp=" + timeStamp;
            sigBaseStringParams += "&" + "oauth_version=1.0";
            string sigBaseString = "POST&";
            sigBaseString += Uri.EscapeDataString(_twitterRequestTokenUrl) + "&" + Uri.EscapeDataString(sigBaseStringParams);

            string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text);

            var responseText = await oAuthUtil.PostData(_twitterRequestTokenUrl, sigBaseStringParams + "&oauth_signature=" + Uri.EscapeDataString(signature));

            if (!string.IsNullOrEmpty(responseText))
            {
                string oauth_token = null;
                string oauth_token_secret = null;
                string oauth_authorize_url = null;
                string[] keyValPairs = responseText.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            oauth_token = splits[1];
                            break;
                        case "oauth_token_secret":
                            oauth_token_secret = splits[1];
                            break;
                        case "xoauth_request_auth_url":
                            oauth_authorize_url = splits[1];
                            break;
                    }
                }

                requestToken.Text = oauth_token;
                requestTokenSecretKey.Text = oauth_token_secret;
                oAuthAuthorizeLink.Content = Uri.UnescapeDataString(_twitterAuthorizeUrl + "?oauth_token=" + oauth_token);
            }
        }

        private async void getAccessToken_Click_1(object sender, RoutedEventArgs e)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            string sigBaseStringParams = "oauth_consumer_key=" + consumerKey.Text;
            sigBaseStringParams += "&" + "oauth_nonce=" + nonce;
            sigBaseStringParams += "&" + "oauth_signature_method=" + "HMAC-SHA1";
            sigBaseStringParams += "&" + "oauth_timestamp=" + timeStamp;
            sigBaseStringParams += "&" + "oauth_token=" + requestToken.Text;
            sigBaseStringParams += "&" + "oauth_verifier=" + oAuthVerifier.Text;
            sigBaseStringParams += "&" + "oauth_version=1.0";
            string sigBaseString = "POST&";
            sigBaseString += Uri.EscapeDataString(_twitterAccessTokenUrl) + "&" + Uri.EscapeDataString(sigBaseStringParams);

            string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text, requestTokenSecretKey.Text);

            var responseText = await oAuthUtil.PostData(_twitterAccessTokenUrl, sigBaseStringParams + "&oauth_signature=" + Uri.EscapeDataString(signature));

            if (!string.IsNullOrEmpty(responseText))
            {
                string oauth_token = null;
                string oauth_token_secret = null;
                string[] keyValPairs = responseText.Split('&');

                for (int i = 0; i < keyValPairs.Length; i++)
                {
                    String[] splits = keyValPairs[i].Split('=');
                    switch (splits[0])
                    {
                        case "oauth_token":
                            oauth_token = splits[1];
                            break;
                        case "oauth_token_secret":
                            oauth_token_secret = splits[1];
                            break;
                    }
                }

                accessToken.Text = oauth_token;
                accessTokenSecretKey.Text = oauth_token_secret;
            }
        }

        private void oAuthAuthorizeLink_Click_1(object sender, RoutedEventArgs e)
        {
            WebViewHost.Visibility = Windows.UI.Xaml.Visibility.Visible;
            WebViewHost.Navigate(new Uri(oAuthAuthorizeLink.Content.ToString()));
        }

        private async void getHomeTimeline_Click_1(object sender, RoutedEventArgs e)
        {
            requestTwitterApi(_getHomeTimelineUrl);
        }

        private void getMentions_Click_1(object sender, RoutedEventArgs e)
        {
            requestTwitterApi(_getMentionsUrl);
        }

        private void getRetweetsOfMe_Click_1(object sender, RoutedEventArgs e)
        {
            requestTwitterApi(_getRetweetsOfMeUrl);
        }

        /// <summary>
        /// https://dev.twitter.com/docs/auth/creating-signature
        /// </summary>
        /// <param name="queryParameters">e.g., count=5&trim_user=true</param>
        /// <returns></returns>
        private string getParamsBaseString(string queryParamsString, string nonce, string timeStamp)
        {           
            // these parameters are required in every request api
            var baseStringParams = new Dictionary<string, string>{
                {"oauth_consumer_key", consumerKey.Text},
                {"oauth_nonce", nonce},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", timeStamp},
                {"oauth_token", accessToken.Text},
                {"oauth_verifier", oAuthVerifier.Text},
                {"oauth_version", "1.0"},                
            };

            // put each parameter into dictionary
            var queryParams = queryParamsString
                                .Split('&')                                
                                .ToDictionary(p => p.Substring(0, p.IndexOf('=')), p => p.Substring(p.IndexOf('=')+1));

            foreach (var kv in queryParams)
            {
                baseStringParams.Add(kv.Key, kv.Value);
            }

            // The OAuth spec says to sort lexigraphically, which is the default alphabetical sort for many libraries.
            var ret = baseStringParams
                .OrderBy(kv => kv.Key)
                .Select(kv => kv.Key + "=" + kv.Value)
                .Aggregate((i, j) => i + "&" + j);

            return ret;
        }

        private async void requestTwitterApi(string url)
        {
            string nonce = oAuthUtil.GetNonce();
            string timeStamp = oAuthUtil.GetTimeStamp();

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.MaxResponseContentBufferSize = int.MaxValue;
                httpClient.DefaultRequestHeaders.ExpectContinue = false;
                HttpRequestMessage requestMsg = new HttpRequestMessage();
                requestMsg.Method = new HttpMethod("GET");

                var qParams = QueryParams.Text;
                var urlWithParams = url + "?" + qParams;
                // HttpClient uses full url
                requestMsg.RequestUri = new Uri(urlWithParams);

                string paramsBaseString = getParamsBaseString(qParams, nonce, timeStamp);

                string sigBaseString = "GET&";
                // signature base string uses base url
                sigBaseString += Uri.EscapeDataString(url) + "&" + Uri.EscapeDataString(paramsBaseString);
                
                string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text, accessTokenSecretKey.Text);
                string data = "oauth_consumer_key=\"" + consumerKey.Text
                              +
                              "\", oauth_nonce=\"" + nonce +
                              "\", oauth_signature=\"" + Uri.EscapeDataString(signature) +
                              "\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"" + timeStamp +
                              "\", oauth_token=\"" + accessToken.Text +
                              "\", oauth_verifier=\"" + oAuthVerifier.Text +                                                           
                              "\", oauth_version=\"1.0\"";
                requestMsg.Headers.Authorization = new AuthenticationHeaderValue("OAuth", data);                
                var response = await httpClient.SendAsync(requestMsg);
                var text = await response.Content.ReadAsStringAsync();
                WebViewHost.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                TwitterResponse.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TwitterResponse.Text = text;
            }
            catch (Exception Err)
            {
                throw;
            }
        }
    
    }
}
