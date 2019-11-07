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
using System.Diagnostics;

namespace TimelineLibrary
{
    /// <summary>
    /// Interaction logic for EventDetails.xaml
    /// </summary>
    public partial class EventDetailsWindow : Window
    {
        public EventDetailsWindow()
        {
            InitializeComponent();
        }

        private void OnOkClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            this.DialogResult = true;
        }

        private void OnHyperlinkButtonClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            TimelineDisplayEvent                        ev;

            ev = (TimelineDisplayEvent) this.DataContext;

            Process.Start(ev.Event.Link);
        }
    }
}
