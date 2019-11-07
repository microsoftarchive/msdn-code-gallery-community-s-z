// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MobileServices.Samples.MyPictures.DataModel
{
    using Newtonsoft.Json;

    public class Picture
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "albumid")]
        public string AlbumId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "thumbnailurl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "thumbnailFileName")]
        public string ThumbnailFileName { get; set; }

        [JsonProperty(PropertyName = "imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }
    }
}
