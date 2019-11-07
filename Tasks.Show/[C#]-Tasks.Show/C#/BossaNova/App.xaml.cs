using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Microsoft.Shell;
using Tasks.Show.Helpers;
using Tasks.Show.ViewModels;

namespace Tasks.Show 
{
    public partial class App : Application, ISingleInstanceApp
    {
        [STAThread]
        public static void Main()
        {
            if (SingleInstance<App>.InitializeAsFirstInstance("Tasks.Show"))
            {
                var application = new App();

                application.Init();
                application.Run();

                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }

        public static Root Root { get { return ((App)App.Current).m_root; } }
    
        public void Init()
        {
            this.InitializeComponent();

            m_root = new Root(Storage.Load(), FindResource("FolderColors") as IEnumerable<Color>);
        }

        #region ISingleInstanceApp Members

        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            // handle command line arguments from external execution
            return ((MainWindow)MainWindow).ProcessCommandLineArgs(args, false);
        }

        #endregion

        private Root m_root;
    }
}
