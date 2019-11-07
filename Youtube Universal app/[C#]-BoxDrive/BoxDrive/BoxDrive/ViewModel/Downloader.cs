using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace BoxDrive.ViewModel
{
    public class Downloader: INotifyPropertyChanged
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if(value!=title)
                {
                    title = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                    }
                }
            }
        }

        private string thumbail;
        public string Thumbail
        {
            get
            {
                return thumbail;
            }
            set
            {
                if(value!=thumbail)
                {
                    thumbail = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Thumbail"));
                    }
                }
            }
        }

        private string process;
        public string Process
        {
            get
            {
                return process;
            }
            set
            {
                if(value!=process)
                {
                    process = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Process"));
                    }
                }
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if(value!=status)
                {
                    status = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                    }
                }
                
            }
        }

        private string total;
        public string Total
        {
            get
            {
                return total;
            }
            set
            {
                if(value!=total)
                {
                    total = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Total"));
                    }
                }
            }
        }

        private string downloaded;
        public string Downloaded
        {
            get
            {
                return downloaded;
            }
            set
            {
                if(value!=downloaded)
                {
                    downloaded = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Downloaded"));
                    }
                }
            }
        }

        private double percentage;
        public double Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                if(value!=percentage)
                {
                    percentage = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Percentage"));
                    }
                }

            }
        }

        public Downloader(string requestUrl, string title, string thumb, string type)
        {
            DownloadManager(requestUrl, title,thumb, type);
        }

        private async void DownloadManager(string _requestUrl, string _title,string _thumb, string _type)
        {
            Thumbail = _thumb;
            Title = _title;
            var bgDownloader = new BackgroundDownloader();
            string result_title = _title.Replace("-", " ").Replace("&", " ").Replace("/"," ").Replace("!"," ").Replace("(","").Replace(":","").Replace(")","");

            //FolderPicker fo = new FolderPicker();
            //fo.SuggestedStartLocation = PickerLocationId.Downloads;
            //fo.FileTypeFilter.Add(_type);
            // StorageFolder folder = await fo.PickSingleFolderAsync();
            StorageFolder folder = KnownFolders.VideosLibrary;
            var part = await folder.CreateFileAsync(result_title + _type, CreationCollisionOption.ReplaceExisting);
            DownloadOperation downloadOperation = bgDownloader.CreateDownload(new Uri(_requestUrl), part);
            await StartDonwloadAsync(downloadOperation);

        }

        private async Task StartDonwloadAsync(DownloadOperation obj)
        {
            var process = new Progress<DownloadOperation>(ProgressCallback);
            await obj.StartAsync().AsTask(process);
        }

        private void ProgressCallback(DownloadOperation obj)
        {
            this.Status = "Downloading";
            this.Percentage = ((double)obj.Progress.BytesReceived / obj.Progress.TotalBytesToReceive) * 100;
            this.Total = string.Format("{0:0,000}", (double)(obj.Progress.TotalBytesToReceive / 1024));
            this.Downloaded = string.Format("{0:0,000}", (double)(obj.Progress.BytesReceived / 1024));

            if(Percentage>=100)
            {
                this.Status = "Completed";
                this.Percentage = 0.0;
                this.Total = "MB";
                this.Downloaded = "MB";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
