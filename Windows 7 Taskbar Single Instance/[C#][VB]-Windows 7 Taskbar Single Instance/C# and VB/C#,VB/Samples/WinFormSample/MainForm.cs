using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using MS.WindowsAPICodePack.Internal;
using System.Reflection;
using System.Drawing;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsRecipes.TaskbarSingleInstance.WindowsForms;

namespace WinFormSample
{
    public partial class MainForm : TaskbarEnabledForm
    {
        private TaskbarManager taskbarManager = TaskbarManager.Instance;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnTaskbarButtonCreated()
        {
            CreateJumpList();
        }

        private void CreateJumpList()
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
            Color color = Color.White;
            System.Drawing.Icon icon = null;
            string accesibilityText = null;

            try
            {
                ParseArguments(args, ref color, ref icon, ref accesibilityText);
            }
            catch (ArgumentException)
            {
                Debug.Assert(false, String.Format("Wrong command line parameter: {0}", args[1]));
            }

            if (icon != null)
            {
                if (CoreHelpers.RunningOnWin7)
                    taskbarManager.SetOverlayIcon(icon, accesibilityText);

                textBox.BackColor = color;
            }
            Activate();
        }

        private void ParseArguments(string[] args, ref Color color, ref System.Drawing.Icon icon, ref string accesibilityText)
        {
            if (args.Length >= 2)
            {
                switch ((Status)Enum.Parse(typeof(Status), args[1]))
                {
                    case Status.Online:
                        color = Color.Green;
                        icon = WinFormSample.Properties.Resources.Green;
                        accesibilityText = Status.Online.ToString();
                        break;
                    case Status.Away:
                        color = Color.Yellow;
                        icon = WinFormSample.Properties.Resources.Yellow;
                        accesibilityText = Status.Away.ToString();
                        break;
                    case Status.Busy:
                        color = Color.Red;
                        icon = WinFormSample.Properties.Resources.Red;
                        accesibilityText = Status.Busy.ToString();
                        break;
                    default:
                        Debug.Assert(false, "Shoult not be here");
                        break;
                }
            }
        }
    }
}
