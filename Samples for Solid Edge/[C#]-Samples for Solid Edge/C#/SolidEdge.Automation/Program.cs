using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SolidEdge.Automation
{
    /// <summary>
    /// Console application demonstrating basic Solid Edge automation.
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to or start Solid Edge.
                application = SolidEdgeUtils.Connect(true);

                // Ensure Solid Edge GUI is visible.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the documents collection.
                documents = application.Documents;

                Console.WriteLine("Creating a new part document.  No template specified.");
                document = (SolidEdgeFramework.SolidEdgeDocument)documents.Add("SolidEdge.PartDocument");

                //string template = "your template.par";
                //Console.WriteLine("Creating a new part document.  Template '{0}' specified.", template);
                //document = (SolidEdgeFramework.SolidEdgeDocument)documents.Add("SolidEdge.PartDocument", template);

                //Console.WriteLine("Quitting Solid Edge.");

                // Quit Solid Edge.
                //application.Quit();
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
