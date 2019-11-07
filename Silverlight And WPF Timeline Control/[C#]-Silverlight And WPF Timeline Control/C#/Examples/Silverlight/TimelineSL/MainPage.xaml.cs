using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace TimelineSL
{
    public partial class MainPage : UserControl
    {
        public MainPage(
        )
        {
            InitializeComponent();
        }

        private void OnResetEventsClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            timeline.ResetEvents(XDocument.Parse(Resource.Monet));
        }
        
        private void OnClearEventsClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            timeline.ClearEvents();
        }
    }
}
