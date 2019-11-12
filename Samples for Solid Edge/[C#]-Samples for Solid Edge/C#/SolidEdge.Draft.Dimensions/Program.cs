using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace SolidEdge.Draft.Dimensions
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

                // Get a reference to the documents collection.
                documents = application.Documents;

                // Create a new draft document.
                draftDocument = (SolidEdgeDraft.DraftDocument)documents.Add("SolidEdge.DraftDocument");

                // Demonstrate dimensioning a part drawving view.
                AddPartViewAndDimension(draftDocument);

                // Demonstrate dimensioning a 2D line.
                AddLineAndDimension(draftDocument);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void AddPartViewAndDimension(SolidEdgeDraft.DraftDocument draftDocument)
        {
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.ModelLinks modelLinks = null;
            SolidEdgeDraft.ModelLink modelLink = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;
            DirectoryInfo trainingDirectory = GetTrainingDirectory();
            string fileName = Path.Combine(trainingDirectory.FullName, "2holebar.par");
            SolidEdgeDraft.DVLines2d dvLines2d = null;
            SolidEdgeDraft.DVLine2d dvLine2d = null;
            SolidEdgeFrameworkSupport.Dimensions dimensions = null;
            SolidEdgeFrameworkSupport.Dimension dimension = null;
            SolidEdgeFrameworkSupport.DimStyle dimStyle = null;

            // Get a reference to the active sheet.
            sheet = draftDocument.ActiveSheet;

            // Get a reference to the ModelLinks collection.
            modelLinks = draftDocument.ModelLinks;
            
            // Add a new model link.
            modelLink = modelLinks.Add(fileName);

            // Get a reference to the DrawingViews collection.
            drawingViews = sheet.DrawingViews;

            // Add a new part drawing view.
            drawingView = drawingViews.AddPartView(
                From: modelLink,
                Orientation: SolidEdgeDraft.ViewOrientationConstants.igDimetricTopBackLeftView,
                Scale: 5.0,
                x: 0.4,
                y: 0.4,
                ViewType: SolidEdgeDraft.PartDrawingViewTypeConstants.sePartDesignedView);

            // Get a reference to the DVLines2d collection.
            dvLines2d = drawingView.DVLines2d;

            // Get the 1st drawing view 2D line.
            dvLine2d = dvLines2d.Item(1);
            
            // Get a reference to the Dimensions collection.
            dimensions = (SolidEdgeFrameworkSupport.Dimensions)sheet.Dimensions;

            // Add a dimension to the line.
            dimension = dimensions.AddLength(dvLine2d.Reference);

            // Few changes to make the dimensions look right.
            dimension.ProjectionLineDirection = true;
            dimension.TrackDistance = 0.02;

            // Get a reference to the dimension style.
            // DimStyle has a ton of options...
            dimStyle = dimension.Style;
        }

        static void AddLineAndDimension(SolidEdgeDraft.DraftDocument draftDocument)
        {
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeFrameworkSupport.Lines2d lines2d = null;
            SolidEdgeFrameworkSupport.Line2d line2d = null;
            SolidEdgeFrameworkSupport.Dimensions dimensions = null;
            SolidEdgeFrameworkSupport.Dimension dimension = null;
            SolidEdgeFrameworkSupport.DimStyle dimStyle = null;

            // Get a reference to the active sheet.
            sheet = draftDocument.ActiveSheet;

            // Get a reference to the Lines2d collection.
            lines2d = sheet.Lines2d;

            // Draw a new line.
            line2d = lines2d.AddBy2Points(
                x1: 0.2,
                y1: 0.2,
                x2: 0.3,
                y2: 0.2);

            // Get a reference to the Dimensions collection.
            dimensions = (SolidEdgeFrameworkSupport.Dimensions)sheet.Dimensions;

            // Add a dimension to the line.
            dimension = dimensions.AddLength(line2d);

            // Get a reference to the dimension style.
            // DimStyle has a ton of options...
            dimStyle = dimension.Style;
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
