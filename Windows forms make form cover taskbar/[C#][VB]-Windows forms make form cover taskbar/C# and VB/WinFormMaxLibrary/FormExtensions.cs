using System;
using System.Windows.Forms;

namespace WinFormMaxLibrary
{
    public static class FormExtensions
    {
        [System.Runtime.InteropServices.DllImport("user32.dll",
            EntryPoint = "SetWindowPos",
            ExactSpelling = true,
            CharSet = System.Runtime.InteropServices.CharSet.Ansi,
            SetLastError = true)]
        private static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndIntertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            int uFlags);

        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64;

        /// <summary>
        /// Place form into full screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="TaskBar">True to hide Windows TaskBar</param>
        /// <remarks>
        /// Showing this task bar may not work fully but that is not the
        /// point here, the point is to cover the task bar with a option
        /// to expose it is secondary.
        /// </remarks>
        public static void FullScreen(this Form sender, bool TaskBar)
        {

            sender.WindowState = FormWindowState.Maximized;
            sender.FormBorderStyle = FormBorderStyle.None;
            sender.TopMost = true;

            if (TaskBar)
            {

                SetWindowPos(sender.Handle, HWND_TOP, 0, 0,
                    Screen.PrimaryScreen.Bounds.Width,
                    Screen.PrimaryScreen.Bounds.Height,
                    SWP_SHOWWINDOW);

            }

        }
        /// <summary>
        /// Restore to original size/position
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks></remarks>
        public static void NormalMode(this Form sender)
        {
            sender.WindowState = FormWindowState.Normal;
            sender.FormBorderStyle = FormBorderStyle.FixedSingle;
            sender.TopMost = true;
        }
    }
}
