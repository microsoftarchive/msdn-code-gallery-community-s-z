//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        // By default in WPF, data context cannot be passed from a frame to its content because a frame
        // acts like a sandbox. We work around this manually using the following methods, which were 
        // borrowed from http://stackoverflow.com/questions/3621424/page-datacontext-not-inherited-from-parent-frame
        void OnFrameLoadCompleted(object sender, NavigationEventArgs e)
        {
            this.UpdateFrameDataContext(sender);
        }

        void OnFrameDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateFrameDataContext(sender);
        }

        void UpdateFrameDataContext(object sender)
        {
            Frame frame = sender as Frame;
            if (frame != null)
            {
                FrameworkElement content = frame.Content as FrameworkElement;
                if (content != null)
                {
                    content.DataContext = frame.DataContext;
                }
            }
        }
    }
}
