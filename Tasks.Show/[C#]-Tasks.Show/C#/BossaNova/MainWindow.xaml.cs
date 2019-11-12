using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Shell;
using Microsoft.WindowsAPICodePack.ApplicationServices;
using MS.WindowsAPICodePack.Internal;
using PixelLab.Common;
using Tasks.Show.Helpers;
using Tasks.Show.Models;
using Tasks.Show.Utils;
using Tasks.Show.ViewModels;

namespace Tasks.Show
{
    public partial class MainWindow : Window
    {
        #region Fields

        private Thickness c_glassMargins = new Thickness(-1);
        private const int c_hotKeyId = 68;
        private const int c_keepAliveInterval = 5000;
        private readonly Root m_rootViewModel;

        #endregion Fields

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            m_rootViewModel = App.Root;
            this.DataContext = m_rootViewModel;

            Commands.MapCommand(m_rootViewModel.Tasks.NewTaskCommand, ApplicationCommands.New, this);
            Commands.MapCommand(m_rootViewModel.Tasks.CancelNewCommand, Commands.Cancel, this);

            this.CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Close, (sender, args) => Close()));

            this.SourceInitialized += (sender, args) =>
            HotKeyHelper.HookHotKey(this, Key.T, ModifierKeys.Control | ModifierKeys.Alt, c_hotKeyId, this_hotkey);

            this.Closing += new CancelEventHandler(MainWindow_Closing);

            this.Loaded += (sender, e) =>
            {
                CreateWindowGlass();
                Taskbar.Init();
                ProcessCommandLineArgs(SingleInstance<App>.CommandLineArgs, true);
            };

            RegisterApplicationRecoveryAndRestart();
        }

        #endregion Constructors

        #region Event Handlers

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutBox.Visibility = Visibility.Visible;
        }

        private void About_CloseRequested(object sender, RoutedEventArgs e)
        {
            AboutBox.Visibility = Visibility.Collapsed;
        }

        private void DeleteCompleted_Click(object sender, RoutedEventArgs e)
        {
            var items = m_rootViewModel.Tasks.AllTasks.Where(t => t.Task.IsComplete).ToArray();

            if (items.Length > 0)
            {
                if (MessageBox.Show(String.Format("Are you sure you want to delete {0} completed task{1}? There is no way to restore {2} once {3} deleted.", items.Length, (items.Length > 1 ? "s" : ""), (items.Length > 1 ? "them" : "it"), (items.Length > 1 ? "they are" : "it is")), "Delete completed tasks?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    items.ForEach(tvm => m_rootViewModel.Tasks.DeleteTask(tvm.Task));
                    }
                }
            else
            {
                MessageBox.Show("Sorry, there aren't any completed tasks to delete.");
            }
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Storage.Save(m_rootViewModel.TaskData);
            HotKeyHelper.UnregisterHotKey(this, c_hotKeyId);

            UnregisterApplicationRecoveryAndRestart();
        }

        private void ShowWelcome_Click(object sender, RoutedEventArgs e)
        {
            WelcomeTour.Show();
        }

        private void TasksView_HideScrollSlider(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.Resources["HideScrollColumn"] as Storyboard;
            this.BeginStoryboard(sb);
        }

        private void TasksView_ShowScrollSlider(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.Resources["ShowScrollColumn"] as Storyboard;
            this.BeginStoryboard(sb);
        }

        private void this_hotkey(object sender, EventArgs args)
        {
            this.Activate();
            m_rootViewModel.Tasks.ShowNewTask();
        }

        #endregion Event Handlers

        #region Public Methods

        /// <summary>
        /// Processes the command line args.
        /// </summary>
        /// <param name="commandLineArgs">The command line args.</param>
        /// <param name="isFirstInstance"><c>True</c> if called by is first instance.</param>
        /// <returns>True</returns>
        public bool ProcessCommandLineArgs(IList<string> commandLineArgs, bool isFirstInstance)
        {
            if (commandLineArgs == null || commandLineArgs.Count == 0)
            {
                return true;
            }

            // if no arguments and first instance
            if ((commandLineArgs.Count == 1) && isFirstInstance)
            {
                // Do nothing
            }
            // if no arguments and not first instance
            else if ((commandLineArgs.Count == 1) && !isFirstInstance)
            {
                // Do nothing
            }
            // if second argument is /newtask
            else if ((commandLineArgs.Count > 1) && (commandLineArgs[1].ToLowerInvariant() == "/newtask"))
            {
                this_hotkey(null, EventArgs.Empty);
            }
            // otherwise, second argument is /goto and third argument is folder to select
            else if ((commandLineArgs.Count > 1) && (commandLineArgs[1].ToLowerInvariant() == "/goto"))
            {
                // find requested folder
                var theFolder = m_rootViewModel.TaskData.AllFolders
                    .Where(folder => folder.Name.EasyEquals(commandLineArgs[2]))
                    .FirstOrDefault();

                if (theFolder != null)
                {
                    m_rootViewModel.TaskData.CurrentFolder = theFolder;
                }
            }

            return true;
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateWindowGlass()
        {
            // create window glass
            try
            {
                // obtain the window handle for the window
                IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
                HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
                mainWindowSrc.CompositionTarget.BackgroundColor = Color.FromArgb(0, 0, 0, 0);

                // get system dpi
                double x = 0;
                double y = 0;
                GlassHelper.GetCurrentDPI(out x, out y);
                double dpiScaler = x / 96.0;

                // set margins
                GlassHelper.Margins margins = new GlassHelper.Margins();

                // extend glass frame into client area
                margins.cxLeftWidth = Convert.ToInt32(c_glassMargins.Left * dpiScaler);
                margins.cxRightWidth = Convert.ToInt32(c_glassMargins.Right * dpiScaler);
                margins.cyTopHeight = Convert.ToInt32(c_glassMargins.Top * dpiScaler);
                margins.cyBottomHeight = Convert.ToInt32(c_glassMargins.Bottom * dpiScaler);

                int hr = GlassHelper.DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);

                if (hr < 0)
                {
                    // glass failed
                    FakeGlass.Visibility = Visibility.Visible;
                }
            }

            // if not able to extend glass, paint the default background color
            catch (DllNotFoundException)
            {
                FakeGlass.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Performs recovery by saving the state 
        /// </summary>
        /// <param name="parameter">Unused.</param>
        /// <returns>Unused.</returns>
        private int PerformRecovery(object parameter)
        {
            try
            {
                ApplicationRestartRecoveryManager.ApplicationRecoveryInProgress();
                Storage.Save(m_rootViewModel.TaskData);
                ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(true);
            }
            catch
            {
                ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(false);
            }

            return 0;
        }

        private void RegisterApplicationRecoveryAndRestart()
        {
            if (CoreHelpers.RunningOnVista)
            {
                // register for Application Restart and Recovery
                RestartSettings restartSettings = new RestartSettings(string.Empty, RestartRestrictions.None);
                ApplicationRestartRecoveryManager.RegisterForApplicationRestart(restartSettings);

                RecoverySettings recoverySettings = new RecoverySettings(new RecoveryData(PerformRecovery, null), c_keepAliveInterval);
                ApplicationRestartRecoveryManager.RegisterForApplicationRecovery(recoverySettings);
            }
        }

        private void UnregisterApplicationRecoveryAndRestart()
        {
            if (CoreHelpers.RunningOnVista)
            {
                ApplicationRestartRecoveryManager.UnregisterApplicationRestart();
                ApplicationRestartRecoveryManager.UnregisterApplicationRecovery();
            }
        }

        #endregion Private Methods

        private void DeleteFolders_Click(object sender, RoutedEventArgs e)
        {
            m_rootViewModel.TaskData.UserFolders
                .Where(f => !m_rootViewModel.TaskData.Tasks.Any(t => t.Folder == f))
                .ToArray()
                .ForEach(f => m_rootViewModel.TaskData.RemoveFolder(f));
    }
}
}
