using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDrive.Model
{
    public class YoutubeInformation
    {
        public class PageInfo
        {
            public int totalResults { get; set; }
            public int resultsPerPage { get; set; }
        }

        public class Statistics
        {
            public string viewCount { get; set; }
            public string likeCount { get; set; }
            public string dislikeCount { get; set; }
            public string favoriteCount { get; set; }
            public string commentCount { get; set; }
        }

        public class Item
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public string id { get; set; }
            public Statistics statistics { get; set; }
        }

        public class RootObject
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public PageInfo pageInfo { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
