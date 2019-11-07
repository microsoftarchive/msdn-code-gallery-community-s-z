using System;
using System.Linq;
using System.Windows.Forms;
using ChatApp1._2.Forms;



namespace ChatApp1._2
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
            Application.Run(new FrmServer());
        }
    }
}
