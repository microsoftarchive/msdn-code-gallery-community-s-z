using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ComponentPro.Compression;
using ComponentPro.Diagnostics;

namespace ArchiveManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ArchiveManager());
        }
    }
}