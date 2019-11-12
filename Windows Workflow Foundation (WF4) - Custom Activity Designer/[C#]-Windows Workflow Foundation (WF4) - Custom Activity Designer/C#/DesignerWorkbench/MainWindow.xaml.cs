// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DesignerWorkbench
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constants and Fields

        /// <summary>
        /// The main view model.
        /// </summary>
        private readonly MainViewModel mainViewModel;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.mainViewModel = new MainViewModel();
            this.DataContext = this.mainViewModel;
            this.Closing += this.mainViewModel.ViewClosing;
            this.Closed += this.mainViewModel.ViewClosed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The tab item got focus refresh xaml box.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TabItemGotFocusRefreshXamlBox(object sender, RoutedEventArgs e)
        {
            this.mainViewModel.NotifyChanged("XAML");
        }

        #endregion
    }
}