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
using System.Collections.Specialized;
using TimelineLibrary;

namespace WpfTimelineExample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, IWeakEventListener
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void timeline_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timeline.CurrentDateTime = timeline.MinDateTime + new TimeSpan(
                (int) e.NewValue, 0, 0, 0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timeline.ClearEvents();
            timeline.ResetEvents(Resource.Monet);
        }

        #region IWeakEventListener Members

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            selectedCount.GetBindingExpression(Label.ContentProperty).UpdateTarget();
            return true;
        }

        #endregion

        private void timeline_TimelineReady(object sender, EventArgs e)
        {
            timeline.ResetEvents(Resource.Monet);
            CollectionChangedEventManager.AddListener(timeline.SelectedTimelineEvents, this);
        }

		private void Button2Click(object sender, RoutedEventArgs e)
		{
			// var urlPrompt = new UrlPrompt();
			// if (urlPrompt.ShowDialog() == true)
			// {
            //  timeline.SetTeaserEventImageForSelectedEvents(urlPrompt.ImageUrl);
			// }
		}
    }
}
