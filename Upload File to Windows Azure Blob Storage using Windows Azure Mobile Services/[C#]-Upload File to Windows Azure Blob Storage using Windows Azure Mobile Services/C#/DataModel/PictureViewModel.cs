// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MobileServices.Samples.MyPictures.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class PictureViewModel : BaseViewModel
    {
        private string description = string.Empty;
        private ImageSource thumbnail = null;
        private Uri thumbnailUrl = null;
        private ImageSource image = null;
        private Uri imageUrl = null;
        private AlbumViewModel group;

        public PictureViewModel(string uniqueId, string title, Uri thumbnailUrl, Uri imageUrl, string description, AlbumViewModel group)
            : base(uniqueId, title)
        {
            this.group = group;
            this.description = description;
            this.thumbnailUrl = thumbnailUrl;
            this.imageUrl = imageUrl;
        }

        public string Description
        {
            get { return this.description; }
            set { this.SetProperty(ref this.description, value); }
        }

        public AlbumViewModel Group
        {
            get { return this.group; }
            set { this.SetProperty(ref this.group, value); }
        }

        public ImageSource Thumbnail
        {
            get
            {
                if (this.thumbnail == null && this.thumbnailUrl != null)
                {
                    this.thumbnail = new BitmapImage(this.thumbnailUrl);
                }

                return this.thumbnail;
            }

            set
            {
                this.thumbnailUrl = null;
                this.SetProperty(ref this.thumbnail, value);
            }
        }

        public ImageSource Image
        {
            get
            {
                if (this.image == null && this.imageUrl != null)
                {
                    this.image = new BitmapImage(this.imageUrl);
                }

                return this.image;
            }

            set
            {
                this.imageUrl = null;
                this.SetProperty(ref this.image, value);
            }
        }

        public void SetThumbnail(Uri url)
        {
            this.thumbnail = null;
            this.thumbnailUrl = url;
            this.OnPropertyChanged("Thumbnail");
        }

        public void SetImage(Uri url)
        {
            this.image = null;
            this.imageUrl = url;
            this.OnPropertyChanged("Image");
        }
    }
}
