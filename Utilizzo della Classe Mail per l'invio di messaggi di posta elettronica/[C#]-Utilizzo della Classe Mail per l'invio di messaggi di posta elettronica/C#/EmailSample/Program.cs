using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmailSample
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmEmail());
        }
    }
}
