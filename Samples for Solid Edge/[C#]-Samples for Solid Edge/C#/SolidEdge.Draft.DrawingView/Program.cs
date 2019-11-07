using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace SolidEdge.Draft.DrawingView
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draftDocument = null;

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

                // Get a reference to the Documents collection.
                documents = application.Documents;

                // Create a new draft document.
                draftDocument = (SolidEdgeDraft.DraftDocument)documents.Add("SolidEdge.DraftDocument");

                AddPartView(draftDocument);

                AddAssemblyView(draftDocument);

            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void AddPartView(SolidEdgeDraft.DraftDocument draftDocument)
        {
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.ModelLinks modelLinks = null;
            SolidEdgeDraft.ModelLink modelLink = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;
            DirectoryInfo trainingDirectory = GetTrainingDirectory();
            string fileName = Path.Combine(trainingDirectory.FullName, "2holebar.par");

            // Get a reference to the active sheet.
            sheet = draftDocument.ActiveSheet;

            // Get a reference to the ModelLinks collection.
            modelLinks = draftDocument.ModelLinks;
            //2holebar.par
            modelLink = modelLinks.Add(fileName);

            drawingViews = sheet.DrawingViews;

            drawingView = drawingViews.AddPartView(
                From: modelLink,
                Orientation: SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView,
                Scale: 5.0,
                x: 0.4,
                y: 0.4,
                ViewType: SolidEdgeDraft.PartDrawingViewTypeConstants.sePartDesignedView);
        }

        static void AddAssemblyView(SolidEdgeDraft.DraftDocument draftDocument)
        {
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.ModelLinks modelLinks = null;
            SolidEdgeDraft.ModelLink modelLink = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;
            DirectoryInfo trainingDirectory = GetTrainingDirectory();
            string fileName = Path.Combine(trainingDirectory.FullName, "Coffee Pot.asm");

            // Get a reference to the active sheet.
            sheet = draftDocument.ActiveSheet;

            // Get a reference to the ModelLinks collection.
            modelLinks = draftDocument.ModelLinks;
            //2holebar.par
            modelLink = modelLinks.Add(fileName);

            drawingViews = sheet.DrawingViews;

            drawingView = drawingViews.AddAssemblyView(
                From: modelLink,
                Orientation: SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView,
                Scale: 1.0,
                x: 0.4,
                y: 0.2,
                ViewType: SolidEdgeDraft.AssemblyDrawingViewTypeConstants.seAssemblyDesignedView);
        }

        static DirectoryInfo GetTrainingDirectory()
        {
            /* Create a new instance of SEInstallData object. */
            SEInstallDataLib.SEInstallData installData = new SEInstallDataLib.SEInstallData();

            /* Get path to Solid Edge program directory.  Typically, 'C:\Program Files\Solid Edge XXX\Program'. */
            DirectoryInfo programDirectory = new DirectoryInfo(installData.GetInstalledPath());

            /* Get path to Solid Edge training directory.  Typically, 'C:\Program Files\Solid Edge XXX\Training'. */
            DirectoryInfo trainingDirectory = new DirectoryInfo(Path.Combine(programDirectory.Parent.FullName, "Training"));

            return trainingDirectory;
        }
    }
}
