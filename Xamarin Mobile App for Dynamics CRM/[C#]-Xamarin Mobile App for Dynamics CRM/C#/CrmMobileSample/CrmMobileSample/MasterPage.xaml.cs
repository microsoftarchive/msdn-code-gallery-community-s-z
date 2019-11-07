using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CrmMobileSample
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Tasks",
                IconSource = "task.png",
                TargetType = typeof(TasksPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
