using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Tasks.Show.Models;

namespace Tasks.Show
{
    /// <summary>
    /// Encapsulate Tasks.Show taskbar related functionality
    /// </summary>
    public static class Taskbar
    {
        private const string NativeResourceDllName = "Tasks.Show.Native.Resources.dll";
        private const int GotoResourceId = 0;
        private const int NewTaskResourceId = 1;

        /// <summary>
        /// Inits the taskbar.
        /// </summary>
        public static void Init()
        {
            try
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    var jumpList = JumpList.CreateJumpList();

                    RefreshTaskbarTasks(jumpList);

                    ((INotifyCollectionChanged)App.Root.TaskData.AllFolders).CollectionChanged += (sender, args) => RefreshTaskbarTasks(jumpList);
                }
            }
            catch (COMException)
            {
                // catch rare COM exceptions
            }
        }

        /// <summary>
        /// Refreshes the taskbar tasks.
        /// </summary>
        private static void RefreshTaskbarTasks(JumpList jumpList)
        {
            try
            {
                jumpList.ClearAllUserTasks();

                jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Neither;

                string applicationFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string nativeResourceDll = Path.Combine(applicationFolder, NativeResourceDllName);

                jumpList.AddUserTasks(
                    new JumpListLink(Assembly.GetEntryAssembly().Location, "Create New Task")
                    {
                        Arguments = "/newtask",
                        IconReference = new IconReference(nativeResourceDll, NewTaskResourceId)
                    });

                jumpList.AddUserTasks(new JumpListSeparator());

                foreach (BaseFolder f in App.Root.TaskData.AllFolders)
                {
                    jumpList.AddUserTasks(
                        new JumpListLink(Assembly.GetEntryAssembly().Location, "Goto " + f.Name)
                        {
                            Arguments = "/goto " + "\"" + f.Name + "\"",
                            IconReference = new IconReference(nativeResourceDll, GotoResourceId)
                        });
                }

                jumpList.Refresh();
            }
            catch (COMException)
            {
                // catch rare COM exceptions
            }
        }
    }
}
