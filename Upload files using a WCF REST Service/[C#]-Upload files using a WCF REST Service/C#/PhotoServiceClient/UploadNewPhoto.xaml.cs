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
using System.Windows.Shapes;
using System.IO;
using System.Configuration;
using System.Net;

namespace PhotoServiceClient
{
    /// <summary>
    /// Interaction logic for UploadNewPhoto.xaml
    /// </summary>
    public partial class UploadNewPhoto : Window
    {
        public UploadNewPhoto()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var fd = new Microsoft.Win32.OpenFileDialog();
            fd.Filter = "All image formats (*.jpg; *.jpeg; *.bmp; *.png; *.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif";
            var ret = fd.ShowDialog();

            if (ret.GetValueOrDefault())
            {
                txtFileName.Text = fd.FileName;

                try
                {
                    BitmapImage bmp = new BitmapImage(new Uri(fd.FileName, UriKind.Absolute));
                    imgPhoto.Source = bmp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid image file.", "Browse", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void btnStartUpload_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Specifiy a file to upload.", "Upload", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtFileName.Focus();
            }
            else if (!File.Exists(txtFileName.Text))
            {
                string message = string.Format("Unable to find '{0}'. Please check the file name and try again.", txtFileName.Text);
                MessageBox.Show(message, "Upload", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtFileName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Specify the description of the file to upload.", "Upload", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtDescription.Focus();
            }
            else
            {
                try
                {
                    // Create the REST request.
                    string url = ConfigurationManager.AppSettings["serviceUrl"];
                    string requestUrl = string.Format("{0}/UploadPhoto/{1}/{2}", url, System.IO.Path.GetFileName(txtFileName.Text), txtDescription.Text);

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
                    request.Method = "POST";
                    request.ContentType = "text/plain";

                    byte[] fileToSend = File.ReadAllBytes(txtFileName.Text);
                    request.ContentLength = fileToSend.Length;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        // Send the file as body request.
                        requestStream.Write(fileToSend, 0, fileToSend.Length);
                        requestStream.Close();
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        Console.WriteLine("HTTP/{0} {1} {2}", response.ProtocolVersion, (int)response.StatusCode, response.StatusDescription);

                    MessageBox.Show("File sucessfully uploaded.", "Upload", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during file upload: " + ex.Message, "Upload", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
