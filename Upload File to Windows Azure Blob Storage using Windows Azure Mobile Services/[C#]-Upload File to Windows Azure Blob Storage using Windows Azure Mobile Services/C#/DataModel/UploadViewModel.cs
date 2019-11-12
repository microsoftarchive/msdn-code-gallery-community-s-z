// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MobileServices.Samples.MyPictures.DataModel
{
    using System.Collections.Generic;
    using MobileServices.Samples.MyPictures.Common;
    using Windows.Storage;
    using Windows.Storage.FileProperties;

    public class UploadViewModel : BindableBase
    {
        private string pictureName;
        private string pictureDescription;
        private IEnumerable<AlbumViewModel> albums;
        private AlbumViewModel selectedAlbum;
        private string newAlbumName;
        private StorageFile pictureFile;
        private StorageItemThumbnail pictureThumbnail;

        public string PictureName
        {
            get { return this.pictureName; }
            set { this.SetProperty(ref this.pictureName, value); }
        }
        
        public string PictureDescription
        {
            get { return this.pictureDescription; }
            set { this.SetProperty(ref this.pictureDescription, value); }
        }
        
        public IEnumerable<AlbumViewModel> Albums
        {
            get { return this.albums; }
            set { this.SetProperty(ref this.albums, value); }
        }
        
        public AlbumViewModel SelectedAlbum
        {
            get { return this.selectedAlbum; }
            set { this.SetProperty(ref this.selectedAlbum, value); }
        }
        
        public string NewAlbumName
        {
            get { return this.newAlbumName; }
            set { this.SetProperty(ref this.newAlbumName, value); }
        }
        
        public StorageFile PictureFile
        {
            get { return this.pictureFile; }
            set { this.SetProperty(ref this.pictureFile, value); }
        }

        public StorageItemThumbnail PictureThumbnail
        {
            get { return this.pictureThumbnail; }
            set { this.SetProperty(ref this.pictureThumbnail, value); }
        }
    }
}
