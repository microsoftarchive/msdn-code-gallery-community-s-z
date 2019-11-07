using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDrive.Model
{
    public class YoutubePlaylistItems
    {
        public class PageInfo
        {
            public int totalResults { get; set; }
            public int resultsPerPage { get; set; }
        }



        public class Default
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Medium
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class High
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Standard
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Maxres
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Thumbnails
        {
            public Default @default { get; set; }
            public Medium medium { get; set; }
            public High high { get; set; }
            public Standard standard { get; set; }
            public Maxres maxres { get; set; }
        }

        public class ResourceId
        {
            public string kind { get; set; }
            public string videoId { get; set; }
        }

        public class Snippet
        {
            public string publishedAt { get; set; }
            public string channelId { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public Thumbnails thumbnails { get; set; }
            public string channelTitle { get; set; }
            public string playlistId { get; set; }
            public int position { get; set; }
            public ResourceId resourceId { get; set; }
        }

        public class Item
        {
            public string kind { get; set; }
            public string etag { get; set; }
            public string id { get; set; }
            public Snippet snippet { get; set; }
        }

        public class RootObject
        {
            public string code { get; set; }
            public string message { get; set; }
            public string kind { get; set; }
            public string etag { get; set; }
            public string nextPageToken { get; set; }
            public string prevPageToken { get; set; }
            public PageInfo pageInfo { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
