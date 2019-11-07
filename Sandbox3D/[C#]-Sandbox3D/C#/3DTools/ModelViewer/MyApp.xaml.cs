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

using CommandLine;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ModelViewer
{
    /// <summary>
    /// Interaction logic for MyApp.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        class Arguments
        {
            [DefaultArgument(ArgumentType.AtMostOnce, HelpText = "")]
            public string Filename = null;
        }


        void OnStartup(object sender, StartupEventArgs e)
        {
            Arguments parsedArgs = new Arguments();

            if (Parser.ParseArgumentsWithUsage(e.Args, parsedArgs))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                if (parsedArgs.Filename != null)
                {
                    mainWindow.Load(parsedArgs.Filename);
                }
            }
        }

        internal static void StartupError(string errorMsg)
        {
            MessageBox.Show(errorMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            Application.Current.Shutdown();
        }
    }
}