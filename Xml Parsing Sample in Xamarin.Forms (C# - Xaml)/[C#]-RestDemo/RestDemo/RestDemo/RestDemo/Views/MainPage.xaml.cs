using RestDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JsonParsingPage());
        }

        private void BtnXml_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XmlParsingPage());
        }
    }
}
