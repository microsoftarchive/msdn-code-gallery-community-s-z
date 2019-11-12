using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsRecipes.TaskbarSingleInstance.WindowsForms
{
    /// <summary>
    /// A base class for forms which need to recieve notifications when the taskbar button is created on Windows 7 machines.
    /// </summary>
    public abstract class TaskbarEnabledForm : Form
    {
        [DllImport("user32.dll")]
        private static extern uint RegisterWindowMessage(string message);

        private uint wmTBC;

        /// <summary>
        /// Registers the window message for notification when the taskbar button is created.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            wmTBC = RegisterWindowMessage("TaskbarButtonCreated");
        }

        /// <summary>
        /// Handles the window message for notification of the taskbar button creation.
        /// </summary>
        /// <param name="m">The window message.</param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == wmTBC)
            {
                OnTaskbarButtonCreated();
            }
        }

        /// <summary>
        /// Override this method to recieve notification when the taskbar button is created on Windows 7 machines and above.
        /// </summary>
        protected abstract void OnTaskbarButtonCreated();
    }
}
