using System;
using System.Windows.Forms;
using WindowsRecipes.TaskbarSingleInstance;
using WindowsRecipes.TaskbarSingleInstance.WindowsForms;

namespace WinFormSample
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
            MainForm mainForm = new MainForm();

            using (SingleInstanceManager manager = SingleInstanceManager.Initialize(GetSingleInstanceManagerSetup(mainForm)))
            {
                Application.Run(mainForm);
            }
        }

        private static SingleInstanceManagerSetup GetSingleInstanceManagerSetup(MainForm mainForm)
        {
            return new SingleInstanceManagerSetup("WinFormSample")
            {
                ArgumentsHandler = mainForm.ProcessCommandLineArgs,
                ArgumentsHandlerInvoker = new WindowsFormsInvoker(mainForm),
                DelivaryFailureNotification = ex => MessageBox.Show(ex.Message, "An error occured"),
            };
        }
    }
}
