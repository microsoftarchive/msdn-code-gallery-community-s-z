using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Tasks.Show.Utils
{
    // TODO: at some point, add support for Unhook
    // for now, this is only used once in an app, so letting shut-down clean-up is fine
    public static class HotKeyHelper
    {
		#region Fields 

        private const int MOD_ALT = 0x1, MOD_CONTROL = 0x2, MOD_SHIFT = 0x4, MOD_WIN = 0x8, WM_HOTKEY = 0x312;

		#endregion Fields 

		#region Public Methods 

        public static void HookHotKey(Window window, Key key,
            ModifierKeys modifiers, int keyId, EventHandler hookHandler)
        {

            HwndSourceHook hook = delegate(IntPtr hwnd, int msg, IntPtr wParam,
                IntPtr lParam, ref bool handled)
            {

                if (msg == HotKeyHelper.WM_HOTKEY)
                {
                    // TODO: parse out the lParam to see if it is actually the one registered
                    // see http://msdn.microsoft.com/en-us/library/ms646279(VS.85).aspx

                    hookHandler(window, EventArgs.Empty);
                    handled = true;
                }
                return IntPtr.Zero;
            };

            HwndSource source = PresentationSource.FromVisual(window) as HwndSource;
            if (source == null)
            {
                throw new ApplicationException("window doesn't have a source yet. Did you wait till after the SourceInitialized event?");
            }
            source.AddHook(hook);

            RegisterHotKey(window, key, modifiers, keyId);
        }

        public static void RegisterHotKey(Window window, Key key, ModifierKeys modifiers, int keyId)
        {
            window.VerifyAccess();

            int winMods = 0;
            if ((modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
                winMods = winMods | MOD_ALT;

            if ((modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                winMods = winMods | MOD_CONTROL;

            if ((modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                winMods = winMods | MOD_SHIFT;

            if ((modifiers & ModifierKeys.Windows) == ModifierKeys.Windows)
                winMods = winMods | MOD_WIN;

            var helper = new WindowInteropHelper(window);
            RegisterHotKey(helper.Handle, keyId, winMods, KeyInterop.VirtualKeyFromKey(key));
        }

        public static void UnregisterHotKey(Window window, int keyId)
        {
            window.VerifyAccess();
            var helper = new WindowInteropHelper(window);
            UnregisterHotKey(helper.Handle, keyId);
        }

		#endregion Public Methods 

		#region Private Methods 

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		#endregion Private Methods 
    }
}
