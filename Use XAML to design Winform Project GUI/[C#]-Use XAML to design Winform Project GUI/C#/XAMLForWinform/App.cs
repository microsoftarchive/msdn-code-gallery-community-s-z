using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Markup;

namespace XAMLForWinform
{
    static class App
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Winform form = new Winform();

            Application.Run(form);
        }
    }
}
