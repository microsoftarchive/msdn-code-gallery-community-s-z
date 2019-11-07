using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace SolidEdge.InstallData
{
    /// <summary>
    /// This program demonstrates how to use the Solid Edge Install Data API (SEInstallDataLib.dll).
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                /* Create a new instance of SEInstallData object. */
                SEInstallDataLib.SEInstallData installData = new SEInstallDataLib.SEInstallData();

                /* Beware: installData.GetVersion() appends 'x64' to end of string if x64 installation! */
                /* This comes from HKEY_LOCAL_MACHINE\SOFTWARE\Unigraphics Solutions\Solid Edge\Version XXX\CurrentVersion\Build */

                /* Solid Edge version */
                Version version = new Version(
                    installData.GetMajorVersion(),
                    installData.GetMinorVersion(),
                    installData.GetServicePackVersion(),
                    installData.GetBuildNumber());

                /* Parasolid version */
                Version parasolidVersion = new Version(
                    installData.GetParasolidMajorVersion(),
                    installData.GetParasolidMinorVersion());

                /* Solid Edge language.  i.e. 'English', 'German', etc. */
                CultureInfo cultureInfo = new CultureInfo(installData.GetLanguageID());

                /* Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. */
                DirectoryInfo programDirectory = new DirectoryInfo(installData.GetInstalledPath());

                /* Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'. */
                DirectoryInfo installationDirectory = programDirectory.Parent;

                /* Get path to Solid Edge template directory.  Typically, 'C:\Program Files\Solid Edge XXX\Template'. */
                DirectoryInfo templateDirectory = new DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Template"));

                /* Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'. */
                DirectoryInfo trainingDirectory = new DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Training"));

                // Output info to screen.
                Console.WriteLine("Language: '{0}'", cultureInfo);
                Console.WriteLine("Version: '{0}'", version);
                Console.WriteLine("VersionString: '{0}'", installData.GetVersion());
                Console.WriteLine("ParasolidVersion: '{0}'", parasolidVersion);
                Console.WriteLine("InstallFolderPath: '{0}'", installationDirectory.FullName);
                Console.WriteLine("ProgramFolderPath: '{0}'", programDirectory.FullName);
                Console.WriteLine("TemplateFolderPath: '{0}'", templateDirectory.FullName);
                Console.WriteLine("TrainingFolderPath: '{0}'", trainingDirectory.FullName);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }
    }
}
