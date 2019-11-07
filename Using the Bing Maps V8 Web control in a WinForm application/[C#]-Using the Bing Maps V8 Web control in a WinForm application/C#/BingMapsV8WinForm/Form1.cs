using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BingMapsV8WinForm
{
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Allow the Webpage to call methods in this form.
            MyWebBrowser.ObjectForScripting = this;

            //Get the file path to the HTML file that has the map.
            string htmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName) + "\\Html\\Map.html";

            //Navigate to the local HTML file.
            MyWebBrowser.Navigate(new Uri(htmlPath));
        }

        /// <summary>
        /// Updates the map center/zoom labels. This is exposed publically so that the HTML page can call it.
        /// </summary>
        /// <param name="latitude">Latitude value of the center of the map.</param>
        /// <param name="longitude">Longitude value of the center of the map.</param>
        /// <param name="zoom">Zoom level of the map.</param>
        public void UpdateMapViewInfo(double latitude, double longitude, double zoom)
        {
            //Update the Map center/zoom label text.
            MapCenterLabel.Text = string.Format("{0:0.#####},{1:0.#####}", latitude, longitude);
            MapZoomLabel.Text = zoom.ToString();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //Invoke the search function in the HTML page and pass in the search query value.
            MyWebBrowser.Document.InvokeScript("search", new object[] { SearchTbx.Text });
        }
    }
}
