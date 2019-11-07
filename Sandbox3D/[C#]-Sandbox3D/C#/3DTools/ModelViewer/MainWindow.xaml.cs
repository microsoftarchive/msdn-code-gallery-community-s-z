//------------------------------------------------------------------
//
//  For licensing information and to get the latest version go to:
//  http://workspaces.gotdotnet.com/3dtools
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
//  FITNESS FOR A PARTICULAR PURPOSE.
//
//------------------------------------------------------------------

using _3DTools;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace ModelViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnOpen(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Xaml files (*.xaml)|*.xaml";

            if (openFileDialog.ShowDialog().Value)
            {
                Load(openFileDialog.FileName);
            }
        }

        private void OnHeadlightChecked(object sender, RoutedEventArgs e)
        {
            if (_trackport != null)
            {
                _trackport.HeadlightColor = Colors.White;
            }
        }

        private void OnHeadlightUnchecked(object sender, RoutedEventArgs e)
        {
            _trackport.HeadlightColor = Colors.Black;
        }

        private void OnAmbientLightChecked(object sender, RoutedEventArgs e)
        {
            _trackport.AmbientLightColor = Colors.White;
        }

        private void OnAmbientLightUnchecked(object sender, RoutedEventArgs e)
        {
            _trackport.AmbientLightColor = Colors.Black;
        }

        private void OnWireframeChecked(object sender, RoutedEventArgs e)
        {
            _trackport.ViewMode = ViewMode.Wireframe;
        }

        private void OnWireframeUnchecked(object sender, RoutedEventArgs e)
        {
            _trackport.ViewMode = ViewMode.Solid;
        }

        internal void Load(string path)
        {
            if (path != null && File.Exists(path))
            {
                LoadCore(path);

                _watcher.BeginInit();
                _watcher.Path = Path.GetDirectoryName(path);
                _watcher.Filter = Path.GetFileName(path);
                _watcher.Changed += FileChanged;
                _watcher.EnableRaisingEvents = true;
                _watcher.EndInit();
            }
        }

        private void LoadCore(string path)
        {
            if (path != null)
            {
                try
                {
                    using (FileStream file = File.OpenRead(path))
                    {
                        _trackport.LoadModel(file);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(
                        String.Format("Unable to parse file:\r\n\r\n{0}",
                        e.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private delegate void DispatcherCallback();

        private void FileChanged(object sender, FileSystemEventArgs e)
        {

            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Normal, new DispatcherCallback(delegate() { this.LoadCore(e.FullPath); }));
            }
        }

        private readonly FileSystemWatcher _watcher = new FileSystemWatcher();
    }
}