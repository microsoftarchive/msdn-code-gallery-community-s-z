// Stephen Toub

using System;
using System.Windows.Forms;

namespace Microsoft.Pcp.Pfx.InteractiveFractal
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}