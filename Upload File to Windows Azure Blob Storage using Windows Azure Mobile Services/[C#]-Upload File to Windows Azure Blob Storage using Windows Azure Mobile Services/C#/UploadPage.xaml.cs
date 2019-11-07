// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MobileServices.Samples.MyPictures
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MobileServices.Samples.MyPictures.Common;
    using MobileServices.Samples.MyPictures.DataModel;
    using Windows.Storage;
    using Windows.Storage.FileProperties;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UploadPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public UploadPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
        }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var albums = new List<AlbumViewModel>(AlbumDataSource.GetAlbums());
            albums.Add(new AlbumViewModel(string.Empty, "<Create New Album>"));

            var uploadForm = new UploadViewModel()
            {
                Albums = albums,
                SelectedAlbum = albums[0]
            };

            this.DefaultViewModel["Form"] = uploadForm;
        }

        private async void UploadPicture(object sender, RoutedEventArgs e)
        {
            var uploadForm = this.DefaultViewModel["Form"] as UploadViewModel;

            if (await this.IsValid(uploadForm))
            {
                progressBar.Visibility = Visibility.Visible;
                uploadPictureButton.IsEnabled = false;
                selectPictureButton.IsEnabled = false;

                await AlbumDataSource.UploadPicture(uploadForm);

                //// Navigate to home page
                this.Frame.Navigate(typeof(GroupedPicturesPage));
            }
        }

        private async Task<bool> IsValid(UploadViewModel uploadForm)
        {
            if (uploadForm.PictureFile == default(StorageFile))
            {
                var messageBox = new Windows.UI.Popups.MessageDialog("You must select a picture before uploading.", "Warning!");
                await messageBox.ShowAsync();
                return false;
            }

            if ((uploadForm.SelectedAlbum.UniqueId == string.Empty) && string.IsNullOrWhiteSpace(uploadForm.NewAlbumName))
            {
                var messageBox = new Windows.UI.Popups.MessageDialog("You must provide an album name.", "Warning!");
                await messageBox.ShowAsync();
                return false;
            }

            if (string.IsNullOrWhiteSpace(uploadForm.PictureName))
            {
                var messageBox = new Windows.UI.Popups.MessageDialog("You must provide a picture title.", "Warning!");
                await messageBox.ShowAsync();
                return false;
            }

            return true;
        }

        private async void SelectPicture(object sender, RoutedEventArgs e)
        {
            var uploadForm = this.DefaultViewModel["Form"] as UploadViewModel;

            var openPicker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };

            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            var file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                uploadForm.PictureFile = file;
                uploadForm.PictureThumbnail = await file.GetThumbnailAsync(ThumbnailMode.SingleItem, 250);
            }
        }
    }
}
