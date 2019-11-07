using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolidEdge.Assembly.Relations3d
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeAssembly.AssemblyDocument assemblyDocument = null;
            SolidEdgeAssembly.Relations3d relations3d = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to or start Solid Edge.
                application = SolidEdgeUtils.Connect(true);

                // Make sure user can see the GUI.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the documents collection.
                documents = application.Documents;

                Console.WriteLine("Opening Coffee Pot.asm.");

                string fileName = Path.Combine(SolidEdgeUtils.GetTrainingPath(), "Coffee Pot.asm");

                // Create a new assembly document.
                assemblyDocument = (SolidEdgeAssembly.AssemblyDocument)
                    documents.Open(fileName);

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                // Get a reference to the Relations3d collection.
                relations3d = assemblyDocument.Relations3d;

                ReportRelations3d(relations3d);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void ReportRelations3d(SolidEdgeAssembly.Relations3d relations3d)
        {
            SolidEdgeAssembly.GroundRelation3d groundRelation3d = null;
            SolidEdgeAssembly.AxialRelation3d axialRelation3d = null;
            SolidEdgeAssembly.PlanarRelation3d planarRelation3d = null;

            for (int i = 1; i <= relations3d.Count; i++)
            {
                object relation3d = relations3d.Item(i);

                // GetInteropType() is a custom method extension!
                Type t = relation3d.GetInteropType();

                Console.WriteLine("Relations3d[{0}] is of type '{1}'.", i, t);

                // Determine the ObjectType.
                SolidEdgeFramework.ObjectType relationType =
                    (SolidEdgeFramework.ObjectType)relation3d.GetType().InvokeMember("Type", System.Reflection.BindingFlags.GetProperty, null, relation3d, null);

                switch (relationType)
                {
                    case SolidEdgeFramework.ObjectType.igGroundRelation3d:
                        groundRelation3d = (SolidEdgeAssembly.GroundRelation3d)relation3d;
                        break;
                    case SolidEdgeFramework.ObjectType.igAxialRelation3d:
                        axialRelation3d = (SolidEdgeAssembly.AxialRelation3d)relation3d;
                        break;
                    case SolidEdgeFramework.ObjectType.igPlanarRelation3d:
                        planarRelation3d = (SolidEdgeAssembly.PlanarRelation3d)relation3d;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
