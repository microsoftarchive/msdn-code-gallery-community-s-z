using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SoundCloudAndroid.Resources.Model
{
    public class TrackModel
    {
        public class PublisherMetadata
        {
            public string urn { get; set; }
            public string artist { get; set; }
            public string album_title { get; set; }
            public bool contains_music { get; set; }
            public string upc_or_ean { get; set; }
            public string isrc { get; set; }
            public bool @explicit { get; set; }
            public string p_line { get; set; }
            public string p_line_for_display { get; set; }
            public string c_line { get; set; }
            public string c_line_for_display { get; set; }
            public string release_title { get; set; }
            public string publisher { get; set; }
            public string writer_composer { get; set; }
            public string iswc { get; set; }
        }

        public class Visual
        {
            public string urn { get; set; }
            public int entry_time { get; set; }
            public string visual_url { get; set; }
        }

        public class Visuals
        {
            public string urn { get; set; }
            public bool enabled { get; set; }
            public List<Visual> visuals { get; set; }
        }

        public class User
        {
            public string avatar_url { get; set; }
            public string first_name { get; set; }
            public string full_name { get; set; }
            public int id { get; set; }
            public string kind { get; set; }
            public string last_modified { get; set; }
            public string last_name { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public string uri { get; set; }
            public string urn { get; set; }
            public string username { get; set; }
            public bool verified { get; set; }
            public string city { get; set; }
            public string country_code { get; set; }
        }

        public class Track
        {
            public string artwork_url { get; set; }
            public bool commentable { get; set; }
            public int? comment_count { get; set; }
            public string created_at { get; set; }
            public string description { get; set; }
            public bool downloadable { get; set; }
            public int? download_count { get; set; }
            public string download_url { get; set; }
            public int duration { get; set; }
            public int full_duration { get; set; }
            public string embeddable_by { get; set; }
            public string genre { get; set; }
            public bool has_downloads_left { get; set; }
            public int id { get; set; }
            public string kind { get; set; }
            public string label_name { get; set; }
            public string last_modified { get; set; }
            public string license { get; set; }
            public int? likes_count { get; set; }
            public string permalink { get; set; }
            public string permalink_url { get; set; }
            public int? playback_count { get; set; }
            public bool @public { get; set; }
            public PublisherMetadata publisher_metadata { get; set; }
            public string purchase_title { get; set; }
            public string purchase_url { get; set; }
            public string release_date { get; set; }
            public int? reposts_count { get; set; }
            public object secret_token { get; set; }
            public string sharing { get; set; }
            public string state { get; set; }
            public bool streamable { get; set; }
            public string tag_list { get; set; }
            public string title { get; set; }
            public string uri { get; set; }
            public string urn { get; set; }
            public int user_id { get; set; }
            public Visuals visuals { get; set; }
            public string waveform_url { get; set; }
            public string monetization_model { get; set; }
            public string policy { get; set; }
            public User user { get; set; }
        }

        public class Collection
        {
            public Track track { get; set; }
            public double score { get; set; }
        }

        public class RootObject
        {
            public string genre { get; set; }
            public string kind { get; set; }
            public string last_updated { get; set; }
            public List<Collection> collection { get; set; }
            public string query_urn { get; set; }
        }
    }
}