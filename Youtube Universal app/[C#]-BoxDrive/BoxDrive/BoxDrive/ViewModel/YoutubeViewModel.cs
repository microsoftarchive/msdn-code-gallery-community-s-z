using System;
using System.Collections.Generic;
using BoxDrive.Model;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;

namespace BoxDrive.ViewModel
{
    public class YoutubeViewModel
    {

        string api_key = "AIzaSyDTCxULvKCL8sTlpE1gsL9bJfxB9Yj1Zks";
        List<MenuMain> _list;    

        public List<MenuMain> MenuResults { get; set; }
        public List<MenuMain> CategoriesResults { get; set; }
        public List<YoutubePlaylistItems.Item> YoutubeChannel { get; set; }
       

       
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="i"></param>
        /// <param name="style"></param>
        public YoutubeViewModel(int i, string style)
        {
           
            if (style=="menu")
            {
                this.MenuResults = SetMenuResults();
            }
            else if(style=="categories")
            {
                this.CategoriesResults = SetCategories(i);
            }
           
          
        }
        
        /// <summary>
        /// ///////
        /// </summary>
        /// <returns></returns>
        public List<MenuMain> SetMenuResults()
        {
            _list = new List<MenuMain>();
            _list.Add(new MenuMain() { Name = "Popular", img_url = "#BFF073" });
            _list.Add(new MenuMain() { Name = "News", img_url = "#0DC9F7" });
            _list.Add(new MenuMain() { Name = "Entertaiment", img_url = "#0087CB" });
            _list.Add(new MenuMain() { Name = "Cartoon", img_url = "#982395" });
            _list.Add(new MenuMain() { Name = "Fashion", img_url = "#83AA30" });
            _list.Add(new MenuMain() { Name = "Prank collection", img_url = "#3A0256" });


            return _list;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public List<MenuMain> SetCategories(int i)
        {
            _list = new List<MenuMain>();
            switch (i)
            {
                case 0:
                    _list.Add(new MenuMain() { Name = "Billboard Top Songs", img_url = "#BFF073", link= "PL55713C70BA91BD6E" });
                    _list.Add(new MenuMain() { Name = "Just-Released Music Videos", img_url = "#0DC9F7" , link = "PLrEnWoR732-D67iteOI6DPdJH1opjAuJt" });
                    _list.Add(new MenuMain() { Name = "Niharika Movies", img_url = "#0087CB", link = "UCnFpajlezRfiOMdw8Tt3z5A" });
                    _list.Add(new MenuMain() { Name = "Movies Coming Soon", img_url = "#982395" , link = "UCkR0GY0ue02aMyM-oxwgg9g" });
                    _list.Add(new MenuMain() { Name = "Nigahiga", img_url = "#83AA30", link = "UCSAUGyc_xA8uYzaIVG6MESQ" });
                    _list.Add(new MenuMain() { Name = "Top Gear", img_url = "#3A0256", link = "UCjOl2AUblVmg2rA_cRgZkFg" });
                    _list.Add(new MenuMain() { Name = "VeVo", img_url = "#775BA3" , link = "UC2pmfLm7iq6Ov1UwYrWYkZA" });
                    _list.Add(new MenuMain() { Name = "VeVo Italia", img_url = "#009D97", link = "UC2TdeJmXTI34g5U13mxMsLA" });
                    _list.Add(new MenuMain() { Name = "VeVo France", img_url = "#CC0063", link = "UC0t9HSnAFStdSrlHs5K7raA" });
                    _list.Add(new MenuMain() { Name = "Michelle Phan", img_url = "#3F0082" , link = "UCuYx81nzzz4OFQrhbKDzTng" });
                    _list.Add(new MenuMain() { Name = "BBC", img_url = "#00D2F1" , link = "UCCj956IF62FbT7Gouszaj9w" });
                    _list.Add(new MenuMain() { Name = "Washington Post", img_url = "#FA6900" , link = "UCHd62-u_v4DvJ8TCFtpi4GA" });

                    break;
                case 1:
                    _list.Add(new MenuMain() { Name = "New york times", img_url = "#BFF073", link = "UCqnbDFdCpuN8CMEg0VuEBqA" });
                    _list.Add(new MenuMain() { Name = "BBC", img_url = "#0DC9F7", link = "UCCj956IF62FbT7Gouszaj9w " });
                    _list.Add(new MenuMain() { Name = "BBC three", img_url = "#0087CB", link = "UCcjoLhqu3nyOFmdqF17LeBQ" });
                    _list.Add(new MenuMain() { Name = "BBC worldwide", img_url = "#982395", link = "UUC2ccm1GajfSujz7T18d7cKA" });
                    _list.Add(new MenuMain() { Name = "CBS Los Angeles", img_url = "#83AA30", link = "UCkH1uDkyuO9sVjSqdqBygOg" });
                    _list.Add(new MenuMain() { Name = "The Guardian", img_url = "#3A0256", link = "UCHpw8xwDNhU9gdohEcJu4aA" });
                    _list.Add(new MenuMain() { Name = "Washington Post", img_url = "#3A0256", link = "UCHd62-u_v4DvJ8TCFtpi4GA" });
                    _list.Add(new MenuMain() { Name = "WSJ Digital Network", img_url = "#3A0256", link = "UCK7tptUDHh-RYDsdxO1-5QQ" });
                    _list.Add(new MenuMain() { Name = "Times Of India Channel", img_url = "#3A0256", link = "UCckHqySbfy5FcPP6MD_S-Yg" });
                    break;

                case 2:
                    _list.Add(new MenuMain() { Name = "Billboard Top Songs", img_url = "#BFF073", link = "PL55713C70BA91BD6E" });
                    _list.Add(new MenuMain() { Name = "Just-Released Music Videos", img_url = "#0DC9F7", link = "PLrEnWoR732-D67iteOI6DPdJH1opjAuJt" });
                    _list.Add(new MenuMain() { Name = "VeVo", img_url = "#0087CB", link = "UC2pmfLm7iq6Ov1UwYrWYkZA" });
                    _list.Add(new MenuMain() { Name = "VeVo Italia", img_url = "#982395", link = "UC2TdeJmXTI34g5U13mxMsLA" });
                    _list.Add(new MenuMain() { Name = "VeVo France", img_url = "#83AA30", link = "UC0t9HSnAFStdSrlHs5K7raA" });

                    break;

                case 3:
                    _list.Add(new MenuMain() { Name = "Walt Disney Animation Studios", img_url = "#BFF073", link = "UC_976xMxPgzIa290Hqtk-9g" });
                    _list.Add(new MenuMain() { Name = "DisneyShorts", img_url = "#0DC9F7", link = "UC5K8SEF_7GQBedXIjtXLCRg" });
                    _list.Add(new MenuMain() { Name = "Disney Style", img_url = "#0087CB", link = "UCZSVJrC2Hnu92n2Lhez3KgA" });
                    _list.Add(new MenuMain() { Name = "Disney Insider", img_url = "#982395", link = "UCAwm8rSWCoi94powYWnhz6Q" });

                    break;

                case 4:
                    _list.Add(new MenuMain() { Name = "Marie Claire", img_url = "#BFF073", link = "UCedj6kEkWXtL61opkb0Or2Q" });
                    _list.Add(new MenuMain() { Name = "Vogue", img_url = "#0DC9F7", link = "UCRXiA3h1no_PFkb1JCP0yMA" });
                    _list.Add(new MenuMain() { Name = "Allure Magazine", img_url = "#0087CB", link = "UCb0tMboxhHE8Jx6-nhJmRPw" });
                    _list.Add(new MenuMain() { Name = "Sananas", img_url = "#982395", link = "UCVoDMXLU_UNpljm83m-Ds4w" });

                    break;



            }
            return _list;
        }
       
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="_link"></param>
        /// <param name="gridview"></param>
        public async void SetVideoChannel(string _link, GridView gridview, GridView gridviewMobile,TextBlock nextToken, TextBlock backToken)
        {
            try
            {
                MainViewModel mainViewModel = new MainViewModel();
                gridview.ItemsSource = null;
                var getSource = await mainViewModel.querybyJson(_link);
                if (getSource != null)
                {
                    YoutubeChannel = new List<YoutubePlaylistItems.Item>();
                    var items = JsonConvert.DeserializeObject<YoutubePlaylistItems.RootObject>(getSource);
                    if (items.items != null)
                    {
                        if (!string.IsNullOrEmpty(items.nextPageToken))
                        {
                            nextToken.Text = items.nextPageToken;
                        }

                        if (!string.IsNullOrEmpty(items.prevPageToken))
                        {
                            backToken.Text = items.prevPageToken;
                        }
                       
                        foreach (var video in items.items)
                        {
                            
                            
                            var getplaylistItemSource = await mainViewModel.querybyJson("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50&playlistId=" + video.id + "&key="+api_key);
                            var itemsPlaylist = JsonConvert.DeserializeObject<YoutubePlaylistItems.RootObject>(getplaylistItemSource);
                            foreach(var list in itemsPlaylist.items)
                            {
                                
                                YoutubeChannel.Add(list);
                                
                            }                           
                        }
                        gridview.ItemsSource = YoutubeChannel;
                        gridviewMobile.ItemsSource = YoutubeChannel;
                    }

                }
            }
            catch(Exception)
            {
                var dialog = new MessageDialog("The playlist from channel identified with the requests 'playlistId' parameter cannot be found");
                await dialog.ShowAsync();
                //throw new Exception("The playlist from channel identified with the requests 'playlistId' parameter cannot be found");
            }
           
           
        }



        public async void SetVideoPlaylist(string _link, GridView gridview,GridView grdviewMobile,TextBlock nextToken, TextBlock backToken)
        {
            try
            {
                MainViewModel mainViewModel = new MainViewModel();
                var getSource = await mainViewModel.querybyJson(_link);
                if (getSource!=null)
                {
                    gridview.ItemsSource = null;
                    var items = JsonConvert.DeserializeObject<YoutubePlaylistItems.RootObject>(getSource);
                    gridview.ItemsSource = items.items;
                    grdviewMobile.ItemsSource = items.items;

                    if (!string.IsNullOrEmpty(items.nextPageToken))
                    {
                        nextToken.Text = items.nextPageToken;
                    }

                    if (!string.IsNullOrEmpty(items.prevPageToken))
                    {
                        backToken.Text = items.prevPageToken;
                    }

                }
            }
            catch(Exception)
            {
                var dialog = new MessageDialog("The playlist identified with the requests 'playlistId' parameter cannot be found");
                await dialog.ShowAsync();
            }
           
        }

        public async void SetVideoSearch(string _link, GridView gridview,GridView gridviewMobile,TextBlock NextToken,TextBlock BackToken)
        {
            try
            {
                MainViewModel mainViewModel = new MainViewModel();
                var getSource = await mainViewModel.querybyJson(_link);
                if(getSource!=null)
                {
                    gridview.ItemsSource = null;
                    var items = JsonConvert.DeserializeObject<YoutubeSearch.RootObject>(getSource);
                    gridview.ItemsSource = items.items;
                    gridviewMobile.ItemsSource = items.items;
                    if (!string.IsNullOrEmpty(items.nextPageToken))
                    {
                        NextToken.Text = items.nextPageToken;
                    }

                    if (!string.IsNullOrEmpty(items.prevPageToken))
                    {
                        BackToken.Text = items.prevPageToken;
                    }

                }
            }
            catch(Exception)
            {
                var dialog = new MessageDialog("Thre is no results was found");
                await dialog.ShowAsync();
            }
        }

        public async void GetInformationOfVideo(string id, TextBlock txtLike,TextBlock txtDislike,TextBlock txtViews)
        {
            try
            {
                MainViewModel mainViewModel = new MainViewModel();
                string link = "https://www.googleapis.com/youtube/v3/videos?part=statistics&id=" + id+"&key="+api_key;
                var query = await mainViewModel.querybyJson(link);
                if (query != null)
                {
                    var item = JsonConvert.DeserializeObject<YoutubeInformation.RootObject>(query);
                    txtLike.Text = item.items[0].statistics.likeCount;
                    txtDislike.Text = item.items[0].statistics.dislikeCount;
                    txtViews.Text = item.items[0].statistics.viewCount;
                }
                else
                    return;

            }
            catch (Exception)
            {
                return;
            }
            
        }
        
    }
}
