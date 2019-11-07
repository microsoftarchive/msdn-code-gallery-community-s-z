/* Copyright 2012 Marco Minerva, marco.minerva@gmail.com

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Configuration;

namespace PhotoServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetPhotos();
        }

        private void btnNewPhoto_Click(object sender, RoutedEventArgs e)
        {
            UploadNewPhoto window = new UploadNewPhoto();
            window.Owner = this;
            var ret = window.ShowDialog();
            if (ret.GetValueOrDefault())
            {
                // Upload succedded. Refresh photo list.
                this.GetPhotos();
            }
        }

        private void btnDeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            if (dgPhotos.SelectedIndex > -1)
            {
                var ret = MessageBox.Show("Are you sure you want to delete the selected photo?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ret == MessageBoxResult.Yes)
                {
                    var photo = dgPhotos.SelectedItem as PhotoItem;
                    try
                    {
                        // Create the REST request.
                        string url = ConfigurationManager.AppSettings["serviceUrl"];
                        string requestUrl = string.Format("{0}/DeletePhoto/{1}", url, photo.PhotoID);

                        WebRequest request = WebRequest.Create(requestUrl);
                        request.Method = "DELETE";

                        // Get response  
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            Console.WriteLine("HTTP/{0} {1} {2}", response.ProtocolVersion, (int)response.StatusCode, response.StatusDescription);

                        // Update list.
                        this.GetPhotos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore while deleting the selected photo: " + ex.Message, "PhotoService", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnGetPhotos_Click(object sender, RoutedEventArgs e)
        {
            this.GetPhotos();
        }

        private void GetPhotos()
        {
            try
            {
                // Create the REST request.
                string url = ConfigurationManager.AppSettings["serviceUrl"];
                string requestUrl = string.Format("{0}/GetPhotos", url);

                WebRequest request = WebRequest.Create(requestUrl);
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        DataContractJsonSerializer dcs = new DataContractJsonSerializer(typeof(PhotoItem[]));
                        PhotoItem[] results = (PhotoItem[])dcs.ReadObject(stream);

                        // Adjust date/time zone
                        foreach (var photo in results)
                            photo.UploadedOn = new DateTime(photo.UploadedOn.Ticks, DateTimeKind.Utc).ToLocalTime();

                        dgPhotos.ItemsSource = results;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore while retrieving photos: " + ex.Message, "PhotoService", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Retrieve the selected photo.
            if (e.AddedItems.Count > 0)
            {
                try
                {
                    // Create the REST request.
                    string url = ConfigurationManager.AppSettings["serviceUrl"];
                    string requestUrl = string.Format("{0}/GetPhoto/{1}", url, (e.AddedItems[0] as PhotoItem).PhotoID);
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);

                    // Get response  
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            byte[] buffer = new byte[32768];
                            MemoryStream ms = new MemoryStream();
                            int bytesRead, totalBytesRead = 0;
                            do
                            {
                                bytesRead = stream.Read(buffer, 0, buffer.Length);
                                totalBytesRead += bytesRead;

                                ms.Write(buffer, 0, bytesRead);
                            } while (bytesRead > 0);

                            ms.Position = 0;
                            BitmapImage bmp = new BitmapImage();
                            bmp.BeginInit();
                            bmp.StreamSource = ms;
                            bmp.EndInit();

                            imgPhoto.Source = bmp;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore while retrieving image: " + ex.Message, "PhotoService", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                imgPhoto.Source = null;
            }
        }
    }
}
