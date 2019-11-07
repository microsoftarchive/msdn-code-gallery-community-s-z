using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SheetMetal.Tabs
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgePart.SheetMetalDocument sheetMetalDocument = null;

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

                Console.WriteLine("Creating a new SheetMetal document.");

                // Create a new SheetMetal document.
                sheetMetalDocument = (SolidEdgePart.SheetMetalDocument)
                    documents.Add("SolidEdge.SheetMetalDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                Console.WriteLine("Creating base tab.");

                // Create base tab.
                CreateBaseTab(sheetMetalDocument);

                Console.WriteLine("Switching to ISO view.");

                // Switch to ISO view.
                application.StartCommand((SolidEdgeFramework.SolidEdgeCommandConstants)SolidEdgeConstants.PartCommandConstants.PartViewISOView);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void CreateBaseTab(SolidEdgePart.SheetMetalDocument sheetMetalDocument)
        {
            SolidEdgePart.ProfileSets profileSets = null;
            SolidEdgePart.ProfileSet profileSet = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgePart.RefPlanes refplanes = null;
            SolidEdgeFrameworkSupport.Relations2d relations2d = null;
            SolidEdgeFrameworkSupport.Relation2d relation2d = null;
            SolidEdgeFrameworkSupport.Lines2d lines2d = null;
            SolidEdgeFrameworkSupport.Line2d line2d = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;

            // Get a reference to the profile sets collection.
            profileSets = sheetMetalDocument.ProfileSets;

            // Add a new profile set.
            profileSet = profileSets.Add();

            // Get a reference to the profiles collection.
            profiles = profileSet.Profiles;

            // Get a reference to the ref planes collection.
            refplanes = sheetMetalDocument.RefPlanes;

            // Add a new profile.
            profile = profiles.Add(refplanes.Item(1));

            // Get a reference to the lines2d collection.
            lines2d = profile.Lines2d;

            // UOM = meters.
            double[,] lineMatrix = new double[,]
				{
                    //{x1, y1, x2, y2}
                    {0.05, 0.025, 0.05, 0.025},
                    {-0.05, 0.025, -0.05, -0.025},
                    {-0.05, -0.025, 0.05, -0.025},
                    {0.05, -0.025, 0.05, 0.025}
				};

            // Draw the Base Profile.
            for (int i = 0; i <= lineMatrix.GetUpperBound(0); i++)
            {
                line2d = lines2d.AddBy2Points(
                                                lineMatrix[i, 0],
                                                lineMatrix[i, 1],
                                                lineMatrix[i, 2],
                                                lineMatrix[i, 3]);
            }

            // Define Relations among the Line objects to make the Profile closed.
            relations2d = (SolidEdgeFrameworkSupport.Relations2d)profile.Relations2d;

            // Connect all of the lines.
            for (int i = 1; i <= lines2d.Count; i++)
            {
                int j = i + 1;

                // When we reach the last line, wrap around and connect it to the first line.
                if (j > lines2d.Count)
                {
                    j = 1;
                }

                relation2d = relations2d.AddKeypoint(
                  lines2d.Item(i),
                  (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd,
                  lines2d.Item(j),
                  (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart,
                  true);
            }

            // Close the profile.
            profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);

            // Hide the profile.
            profile.Visible = false;

            // Get a reference to the models collection.
            models = sheetMetalDocument.Models;

            // Create the base tab.
            model = models.AddBaseTab(profile, SolidEdgePart.FeaturePropertyConstants.igRight);
        }
    }
}
