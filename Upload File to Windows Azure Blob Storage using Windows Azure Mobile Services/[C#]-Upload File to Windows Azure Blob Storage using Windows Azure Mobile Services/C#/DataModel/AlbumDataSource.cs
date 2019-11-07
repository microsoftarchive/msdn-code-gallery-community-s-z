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
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;
    using Windows.ApplicationModel;

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// AlbumDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class AlbumDataSource
    {
        private static AlbumDataSource albumDataSource = new AlbumDataSource();

        private IMobileServiceTable<Album> albumTable = App.MobileService.GetTable<Album>();
        private IMobileServiceTable<Picture> imageTable = App.MobileService.GetTable<Picture>();

        private ObservableCollection<AlbumViewModel> allAlbums = new ObservableCollection<AlbumViewModel>();

        public AlbumDataSource()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.LoadSampleData();
            }
            else
            {
                this.LoadAlbumData();
            }
        }

        public ObservableCollection<AlbumViewModel> AllAlbums
        {
            get { return this.allAlbums; }
        }

        public static IEnumerable<AlbumViewModel> GetAlbums()
        {
            return albumDataSource.AllAlbums;
        }

        public static AlbumViewModel GetAlbum(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = albumDataSource.AllAlbums.Where((album) => album.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }

        public static void AddAlbum(AlbumViewModel album)
        {
            albumDataSource.AllAlbums.Add(album);
        }

        public static PictureViewModel GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = albumDataSource.AllAlbums.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }

        public static async Task UploadPicture(UploadViewModel uploadForm)
        {
            var albumId = (uploadForm.SelectedAlbum.UniqueId == string.Empty) ? await AlbumDataSource.CreateAlbum(uploadForm.NewAlbumName) : uploadForm.SelectedAlbum.UniqueId;

            //// Add picture item to trigger insert operation which returns the SAS for the blob images
            var pictureItem = CreatePictureInstance(uploadForm, albumId);

            var pictureTable = App.MobileService.GetTable<Picture>();
            await pictureTable.InsertAsync(pictureItem);

            //// TODO: Upload picture directly to blob storage using SAS and the Storage Client library for Windows

            //// Add item to view model
            var group = AlbumDataSource.GetAlbum(albumId);
            group.Items.Add(new PictureViewModel(pictureItem.Id, pictureItem.Name, new Uri(pictureItem.ThumbnailUrl), new Uri(pictureItem.ImageUrl), pictureItem.Description, group));
        }

        private static Picture CreatePictureInstance(UploadViewModel uploadForm, string albumId)
        {
            var guid = Guid.NewGuid();

            var pictureItem = new Picture
            {
                Name = uploadForm.PictureName,
                Description = uploadForm.PictureDescription,
                AlbumId = albumId,
                FileName = string.Format("{0}{1}", guid, uploadForm.PictureFile.FileType),
                ThumbnailFileName = string.Format("{0}_thumbnail{1}", guid, uploadForm.PictureFile.FileType)
            };

            return pictureItem;
        }

        private static async Task<string> CreateAlbum(string albumName)
        {
            //// Create new album
            var albumItem = new Album { Name = albumName };

            await albumDataSource.albumTable.InsertAsync(albumItem);

            //// Add group item to view model
            AlbumDataSource.AddAlbum(new AlbumViewModel(albumItem.Id, albumItem.Name));

            return albumItem.Id;
        }

        private async void LoadAlbumData()
        {
            var albums = await this.albumTable.ToListAsync();

            foreach (var album in albums)
            {
                var group = this.GetImageGroupAsync(album);
                this.AllAlbums.Add(await group);
            }
        }

        private async Task<AlbumViewModel> GetImageGroupAsync(Album album)
        {
            var images = await this.imageTable.Where(i => i.AlbumId == album.Id).ToListAsync();
            var group = new AlbumViewModel(album.Id, album.Name);

            foreach (var image in images)
            {
                group.Items.Add(new PictureViewModel(image.Id, image.Name, new Uri(image.ThumbnailUrl), new Uri(image.ImageUrl), image.Description, group));
            }

            return group;
        }

        private void LoadSampleData()
        {
            string itemContent = string.Format(
                "Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
                "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

            var group1 = new AlbumViewModel(Guid.NewGuid().ToString(), "Group Title: 1");
            group1.Items.Add(new PictureViewModel(
                    Guid.NewGuid().ToString(),
                    "Item Title: 1",
                    new Uri("ms-appx:///Assets/LightGray.png"),
                    new Uri("ms-appx:///Assets/LightGray.png"),
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    group1));
            group1.Items.Add(new PictureViewModel(
                    Guid.NewGuid().ToString(),
                    "Item Title: 2",
                    new Uri("ms-appx:///Assets/DarkGray.png"),
                    new Uri("ms-appx:///Assets/DarkGray.png"),
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    group1));
            this.AllAlbums.Add(group1);

            var group2 = new AlbumViewModel(Guid.NewGuid().ToString(), "Group Title: 2");
            group2.Items.Add(new PictureViewModel(
                    Guid.NewGuid().ToString(),
                    "Item Title: 1",
                    new Uri("ms-appx:///Assets/DarkGray.png"),
                    new Uri("ms-appx:///Assets/DarkGray.png"),
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    group2));
            group2.Items.Add(new PictureViewModel(
                    Guid.NewGuid().ToString(),
                    "Item Title: 2",
                    new Uri("ms-appx:///Assets/MediumGray.png"),
                    new Uri("ms-appx:///Assets/MediumGray.png"),
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    group2));
            this.AllAlbums.Add(group2);
        }
    }
}
