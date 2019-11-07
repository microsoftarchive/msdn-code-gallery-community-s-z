//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Views
{
    using System.ComponentModel;
    using System.Windows;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = new MainWindowViewModel(this.DockManager, this.HorizontalResizingPanel, this.VerticalResizingPanel, this.TabsPane);
            this.DataContext = this.viewModel;
            Status.DataContext = StatusViewModel.GetInstance;
            DispatcherService.DispatchObject = this.Dispatcher;
            this.Closing += new CancelEventHandler(this.viewModel.Closing);
        }
    }
}