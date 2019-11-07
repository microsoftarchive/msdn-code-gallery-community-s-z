using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Net;
using Windows.Storage.Streams;
using Windows.Media.Capture;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App32
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        StorageFile media = null;
        
        Windows.Storage.StorageFolder temporaryFolder = ApplicationData.Current.TemporaryFolder;
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            refreshListview();
        }

        private async void refreshListview()
        {

            try
            {
                await App.container.CreateIfNotExistsAsync();
                await App.container.SetPermissionsAsync(new BlobContainerPermissions()
                {

                    PublicAccess = BlobContainerPublicAccessType.Container

                });

                BlobContinuationToken token = null;
                var blobSSegmented = await App.container.ListBlobsSegmentedAsync(token);
                listview.ItemsSource = blobSSegmented.Results;

            }
            catch (Exception ex)
            {
                IbState.Text += (ex.Message + "\n");
            }

        }
        private async void savebutton(object sender, RoutedEventArgs e)
        {

            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (var fileStream = await file.OpenSequentialReadAsync())
                {
                    try
                    {
                        await App.container.CreateIfNotExistsAsync();
                        var blob = App.container.GetBlockBlobReference(file.Name);
                        await blob.DeleteIfExistsAsync();
                        await blob.UploadFromStreamAsync(fileStream);
                        IbState.Text += DateTime.Now.ToString() + ": Save picture '" + file.Name + "' successfully!\n";
                        refreshListview();
                    }
                    catch (Exception ex)
                    {
                        IbState.Text += (ex.Message + "\n");
                    }


                }
            }
        }

        private async void delete(object sender, RoutedEventArgs e)
        {
            if (listview.SelectedIndex != -1)
            {
                var item = listview.SelectedItem as CloudBlockBlob;
                var blob = App.container.GetBlockBlobReference(item.Name);
                try
                {
                    await blob.DeleteIfExistsAsync();
                    imgbox.Source = null;
                }
                catch (Exception ex)
                {
                    IbState.Text += (ex.Message + "\n");
                }

                refreshListview();
                IbState.Text += DateTime.Now.ToString() + item.Name + " has been removed from blob\n";
            }

        }

        private async void music(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mp3");


            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {

                using (var fileStream = await file.OpenSequentialReadAsync())
                {

                    try
                    {
                        await App.container.CreateIfNotExistsAsync();
                        var blob = App.container.GetBlockBlobReference(file.Name);
                        await blob.DeleteIfExistsAsync();
                        refreshListview();
                        await blob.UploadFromStreamAsync(fileStream);
                        IbState.Text += DateTime.Now.ToString() + ": Save MP3 '" + file.Name + "' successfully!\n";
                        refreshListview();
                    }
                    catch (Exception ex)
                    {
                        IbState.Text += (ex.Message + "\n");
                    }

                }
            }
        }

        private async void download(object sender, RoutedEventArgs e)
        {
            var item = listview.SelectedItem as CloudBlockBlob;


            var blob = App.container.GetBlockBlobReference(item.Name);
            StorageFile file;
            try
            {
                if (listview.SelectedIndex != -1)
                {
                    file = await temporaryFolder.CreateFileAsync(item.Name,
                       CreationCollisionOption.ReplaceExisting);




                    using (var fileStream = await file.OpenStreamForWriteAsync())
                    {
                        var outputstream = fileStream.AsOutputStream();

                        //Hither


                        InMemoryRandomAccessStream decstream = new InMemoryRandomAccessStream();



                        System.IO.Stream netstream = System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead(decstream);



                        //Hence


                        Stream saveStr = new System.IO.MemoryStream();


                        IOutputStream winStr = System.IO.WindowsRuntimeStreamExtensions.AsOutputStream(saveStr);


                        //  var bufferstream = outputstream.AsStreamForWrite(UInt16.MaxValue);
                        await blob.DownloadToStreamAsync(winStr);

                        saveStr.Position = 0;
                        saveStr.CopyTo(fileStream);

                        fileStream.Flush();
                        
                    }

                    // Make sure it's an image file. 
                    imgbox.Source = new BitmapImage(new Uri(file.Path));
                    IbState.Text = "Success\n" + file.Path;

                }
            }
            catch (Exception ex)
            {
                IbState.Text += (ex.Message + "\n");
            }

        }

        private async void picturetaker(object sender, RoutedEventArgs e)
        {
            // Capture a new photo or video from the device.
            CameraCaptureUI cameraCapture = new CameraCaptureUI();
            media = await cameraCapture
                .CaptureFileAsync(CameraCaptureUIMode.PhotoOrVideo);

            //uploads the picture to the container
            using (var fileStream = await media.OpenSequentialReadAsync())
            {
                await App.container.CreateIfNotExistsAsync();
                var blob = App.container.GetBlockBlobReference(media.Name);
                await blob.DeleteIfExistsAsync();
                await blob.UploadFromStreamAsync(fileStream);
                IbState.Text += DateTime.Now.ToString() + ": Save picture '" + media.Name + "' successfully!\n";
            }

            //adds it tot 
            refreshListview();
        }
    }
}
