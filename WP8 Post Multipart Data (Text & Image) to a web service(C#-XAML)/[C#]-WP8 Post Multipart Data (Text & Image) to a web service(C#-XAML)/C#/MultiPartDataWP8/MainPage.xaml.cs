using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MultiPartDataWP8.Resources;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;

namespace MultiPartDataWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        public bool isImageUpload = false;
        BitmapImage ObjBmpImage = new BitmapImage();
        public byte[] bytesImg;
        private static readonly Encoding encoding = Encoding.UTF8;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }
        #region GalleryImage
        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask;
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Show();
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                //Code to display the photo on the page in an image control named myImage.
                isImageUpload = true;
                ObjBmpImage.SetSource(e.ChosenPhoto);
                imgProfile.Source = ObjBmpImage;
            }
        }
        #endregion
        #region FileUpload

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text != "" && tbxWebsite.Text != "")
            {
                DataUpload(ObjBmpImage);
            }
            else
            {
                MessageBox.Show("Please fill all txt fields");
            }
        }
        public void DataUpload(BitmapImage image)
        {
            // Generate post objects
            Dictionary<string, object> postParameters = new Dictionary<string, object>();

            //String parameters
            postParameters.Add("Name", tbxName);
            postParameters.Add("Website", tbxWebsite);

            //Image parameter
            if (isImageUpload)
            {
                bytesImg = ImageToArray(image);
                byte[] data = bytesImg;
                postParameters.Add("imgProfile", new FileParameter(data, "leak_image.png", "image/png"));
            }

            MultipartFormDataPost("WEBSERVICE URL", postParameters);// You sould be replace your webservice url here.
           
        }
        public byte[] ImageToArray(BitmapImage image)
        {
            WriteableBitmap wbmp = new WriteableBitmap(image);
            MemoryStream ms = new MemoryStream();

            wbmp.SaveJpeg(ms, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
            return ms.ToArray();

        }               
        public void MultipartFormDataPost(string postUrl, Dictionary<string, object> postParameters)
        {
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;

            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

            PostForm(postUrl, contentType, formData);
        }
        private void PostForm(string postUrl, string contentType, byte[] formData)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;

            if (httpWebRequest == null)
            {
                throw new NullReferenceException("request is not a http request");
            }

            // Set up the request properties.
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = contentType;
            httpWebRequest.CookieContainer = new CookieContainer();
            httpWebRequest.ContentLength = formData.Length;
            httpWebRequest.BeginGetRequestStream((result) =>
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                    using (Stream requestStream = request.EndGetRequestStream(result))
                    {
                        requestStream.Write(formData, 0, formData.Length);
                        requestStream.Close();
                    }
                    request.BeginGetResponse(a =>
                    {
                        try
                        {
                            var response = request.EndGetResponse(a);
                            var responseStream = response.GetResponseStream();
                            using (var sr = new StreamReader(responseStream))
                            {
                                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                                {
                                    string responseString = streamReader.ReadToEnd();

                                    if (!string.IsNullOrEmpty(responseString))
                                    {
                                        Dispatcher.BeginInvoke(() =>
                                        {
                                            MessageBox.Show("Your data is successfully submitted!");
                                        });
                                    }
                                    else
                                    {
                                        Dispatcher.BeginInvoke(() => MessageBox.Show("Error in data submission!"));
                                    }
                                    
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Dispatcher.BeginInvoke(() =>
                            {
                                MessageBox.Show("Error in data submission!");
                            });
                        }
                    }, null);
                }
                catch (Exception)
                {
                   
                    MessageBox.Show("Error in data submission!");
                }
            }, httpWebRequest);

            isImageUpload = false;
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {

            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;
            try
            {
                foreach (var param in postParameters)
                {
                    // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                    // Skip it on the first parameter, add it to subsequent parameters.
                    if (needsCLRF)
                        formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                    needsCLRF = true;

                    if (param.Value is FileParameter)
                    {
                        FileParameter fileToUpload = (FileParameter)param.Value;

                        // Add just the first part of this param, since we will write the file data directly to the Stream
                        string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                            boundary,
                            param.Key,
                            fileToUpload.FileName ?? param.Key,
                            fileToUpload.ContentType ?? "application/octet-stream");

                        formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                    }
                    else
                    {
                        string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                            boundary,
                            param.Key,
                            param.Value);
                        formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                    }
                }

                // Add the end of the request.  Start with a newline
                string footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));
            }
            catch (Exception)
            {
                throw new Exception("Network Issue");
            }
            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();
            return formData;
        }
        #endregion

    }
    #region Helper Class
    public class FileParameter
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public FileParameter(byte[] file) : this(file, null) { }
        public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
        public FileParameter(byte[] file, string filename, string contenttype)
        {
            File = file;
            FileName = filename;
            ContentType = contenttype;
        }
    }
    #endregion
}