using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.WindowsAPICodePack.Taskbar;
using MS.WindowsAPICodePack.Internal;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarManager taskbarManager = TaskbarManager.Instance;

        internal void CreateJumpList()
        {
            if (CoreHelpers.RunningOnWin7)
            {
                string cmdPath = Assembly.GetEntryAssembly().Location;
                JumpList jumpList = JumpList.CreateJumpList();

                JumpListCustomCategory category = new JumpListCustomCategory("Status Change");
                category.AddJumpListItems(
                    new JumpListLink(cmdPath, Status.Online.ToString()) { Arguments = Status.Online.ToString() },
                    new JumpListLink(cmdPath, Status.Away.ToString()) { Arguments = Status.Away.ToString() },
                    new JumpListLink(cmdPath, Status.Busy.ToString()) { Arguments = Status.Busy.ToString() });
                jumpList.AddCustomCategories(category);

                jumpList.Refresh();
            }
        }

        internal void ProcessCommandLineArgs(string[] args)
        {
            Color color = Colors.White;
            System.Drawing.Icon icon = null;
            string accesibilityText = null;

            try
            {
                if (args.Length >= 2)
                {
                    switch ((Status)Enum.Parse(typeof(Status), args[1]))
                    {
                        case Status.Online:
                            color = Colors.Green;
                            icon = WpfSample.Properties.Resources.Green;
                            accesibilityText = Status.Online.ToString();
                            break;
                        case Status.Away:
                            color = Colors.Yellow;
                            icon = WpfSample.Properties.Resources.Yellow;
                            accesibilityText = Status.Away.ToString();
                            break;
                        case Status.Busy:
                            color = Colors.Red;
                            icon = WpfSample.Properties.Resources.Red;
                            accesibilityText = Status.Busy.ToString();
                            break;
                        default:
                            Debug.Assert(false, "Shoult not be here");
                            break;
                    }
                }
            }
            catch (ArgumentException)
            {
                Debug.Assert(false, String.Format("Wrong command line parameter: {0}", args[1]));
            }

            if (icon != null)
            {
                if (CoreHelpers.RunningOnWin7)
                    taskbarManager.SetOverlayIcon(icon, accesibilityText);

                ((MainWindow)MainWindow).SetColor(color);
            }
            MainWindow.Activate();
        }
    }
}
