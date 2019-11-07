using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Documents
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            string[] progIds = {
                                   "SolidEdge.AssemblyDocument",
                                   "SolidEdge.DraftDocument",
                                   "SolidEdge.PartDocument",
                                   "SolidEdge.SheetMetalDocument"
                               };
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

                // Create a new document for each ProgId.
                foreach (string progId in progIds)
                {
                    Console.WriteLine("Creating a new '{0}'.  No template specified.", progId);

                    // Create the new document.
                    document = (SolidEdgeFramework.SolidEdgeDocument)documents.Add(progId);
                }
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
