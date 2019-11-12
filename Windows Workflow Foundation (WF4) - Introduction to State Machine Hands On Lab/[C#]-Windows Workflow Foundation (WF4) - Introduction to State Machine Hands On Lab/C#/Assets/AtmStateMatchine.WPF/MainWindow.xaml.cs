// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMatchine.WPF
{
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using AtmStateMachine.Activities;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants and Fields

        /// <summary>
        ///   The view model.
        /// </summary>
        private readonly AtmViewModel viewModel;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.viewModel = new AtmViewModel();
            this.DataContext = this.viewModel;
            this.Closing += this.viewModel.ViewClosing;
            this.Closed += this.viewModel.ViewClosed;

            //// Handle this event to scroll the list to the bottom
            ((INotifyCollectionChanged)this.ListBoxEvents.Items).CollectionChanged += (o, e) =>
                {
                    var scrollViewer = this.GetScrollViewer(this.ListBoxEvents);

                    if (scrollViewer != null)
                    {
                        scrollViewer.ScrollToBottom();
                    }
                };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a scroll viewer
        /// </summary>
        /// <param name="obj">
        /// The control to search.
        /// </param>
        /// <returns>
        /// A ScrollViewer if found
        /// </returns>
        private ScrollViewer GetScrollViewer(DependencyObject obj)
        {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ScrollViewer)
                {
                    return child as ScrollViewer;
                }

                var grandChild = this.GetScrollViewer(child);
                if (grandChild != null)
                {
                    return grandChild;
                }
            }

            return null;
        }

        #endregion
    }
}