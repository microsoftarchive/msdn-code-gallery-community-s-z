using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Assembly.StructuralFrames
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeAssembly.AssemblyDocument assemblyDocument = null;

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

                Console.WriteLine("Creating a new assembly document.");

                // Create a new assembly document.
                assemblyDocument = (SolidEdgeAssembly.AssemblyDocument)
                    documents.Add("SolidEdge.AssemblyDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                AddStructuralFrame(assemblyDocument);

                Console.WriteLine("Switching to ISO view.");

                // Switch to ISO view.
                application.StartCommand(
                    (SolidEdgeFramework.SolidEdgeCommandConstants)
                        SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewISOView);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void AddStructuralFrame(SolidEdgeAssembly.AssemblyDocument assemblyDocument)
        {
            SolidEdgeAssembly.LineSegments lineSegments = null;
            SolidEdgeAssembly.LineSegment lineSegment = null;
            List<SolidEdgeAssembly.LineSegment> lineSegmentList = new List<SolidEdgeAssembly.LineSegment>();
            SolidEdgeAssembly.StructuralFrames structuralFrames = null;
            SolidEdgeAssembly.StructuralFrame structuralFrame = null;
            double[] startPoint = { 0.0, 0.0, 0.0 };
            double[] endPoint = { 0.0, 0.0, 0.5 };

            // Get a reference to the LineSegments collection.
            lineSegments = assemblyDocument.LineSegments;

            // Add a new line segment.
            lineSegment = lineSegments.Add(
                StartPoint: startPoint,
                EndPoint: endPoint);

            // Store line segment in array.
            lineSegmentList.Add(lineSegment);

            // Get a reference to the StructuralFrames collection.
            structuralFrames = assemblyDocument.StructuralFrames;

            // Build path to part file.  In this case, it is a .par from standard install.
            string partFilePath = Path.Combine(GetSolidEdgeInstallPath(), @"Frames\DIN\I-Beam\I-Beam 80x46.par");

            Console.WriteLine("Adding structural frame '{0}'.", partFilePath);

            // Add new structural frame.
            structuralFrame = structuralFrames.Add(
                PartFileName: partFilePath,
                NumPaths: lineSegmentList.Count,
                Path: lineSegmentList.ToArray());
        }

        static string GetSolidEdgeInstallPath()
        {
            SEInstallDataLib.SEInstallData installData = new SEInstallDataLib.SEInstallData();
            /* Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. */
            DirectoryInfo programDirectory = new DirectoryInfo(installData.GetInstalledPath());

            /* Get path to Solid Edge installation directory.  Typically, 'C:\Program Files\Solid Edge XXX'. */
            DirectoryInfo installationDirectory = programDirectory.Parent;

            return installationDirectory.FullName;
        }
    }
}
