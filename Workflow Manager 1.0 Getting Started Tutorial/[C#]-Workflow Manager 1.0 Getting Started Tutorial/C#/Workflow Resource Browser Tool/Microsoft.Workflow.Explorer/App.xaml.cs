//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.Workflow.Explorer;
    using Microsoft.Workflow.Explorer.Properties;
    using Microsoft.Workflow.Explorer.ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ConnectViewModel connectViewModel = new ConnectViewModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // ignore SSL certificate errors
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;

            this.connectViewModel = new ConnectViewModel();
            Task<ServiceContext> connectTask = connectViewModel.ConnectToServiceAsync();
            connectTask.OnSuccess(this.OnConnectionSuccessful);
            connectTask.OnCanceled(this.OnConnectionCanceled);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(e);
        }

        void OnConnectionSuccessful(ServiceContext serviceContext)
        {
            this.MainWindow = new MainWindow();
            this.MainWindow.DataContext = serviceContext;
            this.MainWindow.Closed += (sender, e) => this.Shutdown();
            this.MainWindow.Show();
        }

        void OnConnectionCanceled()
        {
            this.Shutdown();
        }
    }
}
