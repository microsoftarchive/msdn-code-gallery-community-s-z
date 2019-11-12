using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
using System.Xml;
using System.ServiceModel.Syndication;
using TimelineLibrary;
using System.Text.RegularExpressions;

namespace SilverlightNews
{
    public class RSSFeed
    {
      public string Title { get; set; }
      public string NavURL { get; set; }
      public string Description {get; set; }
      public DateTime PublishDate { get; set; }
    };


    public partial class MainPage : UserControl
    {
        private const string        DEFAULT_IMAGE = "http://beyondtheonewayweb.files.wordpress.com/2008/04/yahoo-pipes-edit-by-robin-good-4651.jpg";

        public string[]             m_resources = new string[] 
        {
            "http://feeds2.feedburner.com/ShineDraw",
            "http://feeds2.feedburner.com/SilverlightBuzz",
            "http://feeds2.feedburner.com/85turns",
            "http://feeds.timheuer.com/timheuer",
            "http://feeds2.feedburner.com/TheSilverlightBlog",
            "http://feeds2.feedburner.com/silverlightshow",
            "http://feeds2.feedburner.com/JesseLiberty-SilverlightGeek",
            "http://feeds.feedburner.com/Kodierer",
            "http://feeds.feedburner.com/MikeSnowBlog",
            "http://pipes.yahooapis.com/pipes/pipe.run?_id=d134221eb598fed2336e40649be968de&_render=rss",
            "http://feeds.feedburner.com/MarkMonster",
            "http://feeds.feedburner.com/UXPassion"
        };

        private string[]            m_images = new string[] {
            "http://www.shinedraw.com/wordpress/wp-content/themes/itheme/logo-black.png",
            "http://www.silverlightbuzz.com/images/gavinwignall.jpg",
            "http://www.85turns.com/blog/wp-content/uploads/2009/02/logo.png",
            "",
            "http://www.microsoft.com/web/media/msweb-logo.png",
            "http://www.silverlightshow.net/Storage/SilverlightShowEcoContest_whitebg.png",
            "http://www.smartypantscoding.com/sites/default/files/logo.png",
            "http://1.bp.blogspot.com/_EtiC5s1ztXY/SgLxDjl6yUI/AAAAAAAAAAM/GzTXzXZuoJA/S220/avatar3_bw.jpg",
            "http://www.feedburner.com/fb/feed-styles/images/footer_logo.gif",
            "",
            "http://mark.mymonster.nl/wp-content/themes/blue-mozaik/images/blog-photo.jpg",
            "http://www.uxpassion.com/wp-content/themes/ColdStone/img/logo-Stone.png"
        };

        public int                        m_currFeedId = 0;
        public List<TimelineEvent>        m_news = new List<TimelineEvent>();
        public Dictionary<string, string> m_extImages = new Dictionary<string,string>() 
        {
            {"charlespetzold", "http://www.charlespetzold.com/PetzoldTattoo.jpg"},
            {"sys-con.com", "http://res.sys-con.com/section/111/logo_silverlight.png"},
            {"expression.microsoft.com", "http://expression.microsoft.com/platform/masterpages/expressionv3page/Images/logo.gif"},
            {"jesseliberty", "http://blogs.silverlight.net/blogs/jesseliberty/MiniTutorialLogo_thumb_241FC865.jpg"},
            {"smartypantscoding","http://a3.twimg.com/profile_images/642128385/twitterProfilePhoto_bigger.jpg"},
            {"blogs.msdn.com/expression", "http://expression.microsoft.com/platform/masterpages/expressionv3page/Images/logo.gif"},
            {"www.silverlight.net", "http://i2.silverlight.net/resources/images/people/blogger-default-54x54.jpg"}
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            ReadNextFeed();
        }

        private string GetImage(int index, string url)
        {
            if (m_images[index].Length > 0)
            {
                return m_images[index];
            }
            else
            {
                foreach (string key in m_extImages.Keys)
                {
                    if (url.IndexOf(key) > -1)
                    {
                        return m_extImages[key];
                    }
                }
            }
            return DEFAULT_IMAGE;
        }

        private void DisplayResults()
        {
            timeline.ClearEvents();
            timeline.ResetEvents(m_news);
        }

        private void ReadNextFeed()
        {
            WebClient                                   request;
            string                                      feed;

            request = new WebClient();
            request.OpenReadCompleted += OnOpenReadCompleted;
            feed = m_resources[m_currFeedId];

            if (!feed.Contains(".yahooapis."))
            {
                feed += "?format=xml";
            }

            request.OpenReadAsync(new Uri(feed, UriKind.Absolute));
            m_currFeedId++;
        }

        private string DelMarkup(string from)
        {
            String text = Regex.Replace(from.ToString(), "<.*?>", "");
            text = Regex.Replace(text, @"\n+\s+", "\n\n");
            text = text.TrimStart(' ');
            
            return HttpUtility.HtmlDecode(text);
        }

        void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            XmlReader                                   reader;
            SyndicationFeed                             newFeed;
            string                                      feed = String.Empty;

            if (e.Error == null)
            {
                try
                {
                    feed = m_resources[m_currFeedId - 1];

                    reader = XmlReader.Create(e.Result, new XmlReaderSettings()
                    {
                        DtdProcessing = DtdProcessing.Ignore,
                        IgnoreProcessingInstructions = true,
                        ConformanceLevel = ConformanceLevel.Auto
                    });

                    newFeed = SyndicationFeed.Load(reader);

                    var posts = from item in newFeed.Items
                        select new TimelineEvent() 
                        {
                            TeaserEventImage = newFeed.ImageUrl == null ?
                                GetImage(m_currFeedId - 1, item.Links.Count() > 0 ? item.Links[0].Uri.AbsoluteUri : "") :
                                newFeed.ImageUrl.ToString(),
                            Title = DelMarkup(item.Title.Text),
                            Link = item.Links.Count() > 0 ? item.Links[0].Uri.AbsoluteUri : "",
                            Description = item.Summary == null ? "" : DelMarkup(item.Summary.Text),
                            StartDate = item.PublishDate.DateTime,
                            EndDate = item.PublishDate.DateTime,
                            IsDuration = false
                        };

                    m_news.AddRange(posts);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Could load feed: " + feed + ". Error: " + err.Message, "Error", MessageBoxButton.OK);
                }
            }
            else 
            {
                MessageBox.Show(m_resources[m_currFeedId - 1] + "- FAILED");
            }

            if (m_currFeedId < m_resources.Count())
            {
                ReadNextFeed();
            }
            else 
            {
                DisplayResults();
            }
        }
    }
}
