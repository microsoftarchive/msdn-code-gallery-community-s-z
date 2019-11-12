using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Runtime.Serialization;
using System.IO.IsolatedStorage;
using System.IO;
using LoginApp.Model;

namespace LoginApp.Views
{
    public partial class LinkInfo : PhoneApplicationPage
    {
        public LinkInfo()
        {
            InitializeComponent();
            this.Loaded += LinkInfo_Loaded;
        }

        void LinkInfo_Loaded(object sender, RoutedEventArgs e)
        {
            ListData ObjListData = new ListData();
            IsolatedStorageFile Settings1 = IsolatedStorageFile.GetUserStoreForApplication();
            if (Settings1.FileExists("CurrentPageInfo"))//loaded previous items into list
            {
                using (IsolatedStorageFileStream fileStream = Settings1.OpenFile("CurrentPageInfo", FileMode.Open))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ListData));
                    ObjListData = (ListData)serializer.ReadObject(fileStream);

                }
                LayoutRoot.DataContext = ObjListData;
            }
        }
    }
}