//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Workflow.Explorer.Controllers;

    /// <summary>
    /// Interaction logic for ScopeDetailsPage.xaml
    /// </summary>
    public partial class ScopeDetailsPage : Page
    {
        public ScopeDetailsPage()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoaded;
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            ScopeNavigationController.Default.SetNavigationService(this.NavigationService);
        }
    }
}
