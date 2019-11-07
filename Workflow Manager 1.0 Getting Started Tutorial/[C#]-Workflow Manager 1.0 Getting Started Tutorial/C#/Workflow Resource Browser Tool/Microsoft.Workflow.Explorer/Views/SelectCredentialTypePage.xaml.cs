//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Workflow.Explorer.Controllers;

    /// <summary>
    /// Interaction logic for SelectCredentialTypePage.xaml
    /// </summary>
    public partial class SelectCredentialTypePage : Page
    {
        public SelectCredentialTypePage()
        {
            this.InitializeComponent();
            this.DataContext = CredentialSelectionController.Default;
            this.Loaded += this.OnPageLoaded;
        }

        void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            CredentialSelectionController.Default.SetNavigationService(this.NavigationService);
        }
    }
}
