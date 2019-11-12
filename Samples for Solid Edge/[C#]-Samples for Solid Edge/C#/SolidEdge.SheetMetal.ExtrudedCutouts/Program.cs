using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SheetMetal.ExtrudedCutouts
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
                application = SolidEdgeUtils.Connect(false);

                // Make sure user can see the GUI.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the documents collection.
                documents = application.Documents;

                Console.WriteLine("Creating a new sheetmetal document.");

                // Create a new sheetmetal document.
                sheetMetalDocument = (SolidEdgePart.SheetMetalDocument)
                    documents.Add("SolidEdge.SheetMetalDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                // Create geometry.
                CreateExtrudedProtrusion(sheetMetalDocument);

                // Create cutout.
                CreateExtrudedCutout(sheetMetalDocument);

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

        static void CreateExtrudedProtrusion(SolidEdgePart.SheetMetalDocument sheetMetalDocument)
        {
            SolidEdgePart.RefPlanes refPlanes = null;
            SolidEdgePart.RefPlane refPlane = null;
            SolidEdgePart.Sketchs sketchs = null;
            SolidEdgePart.Sketch sketch = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgeFrameworkSupport.Circles2d circles2d = null;
            SolidEdgeFrameworkSupport.Circle2d circle2d = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;

            // Get refplane.
            refPlanes = sheetMetalDocument.RefPlanes;
            refPlane = refPlanes.Item(2);

            // Create sketch.
            sketchs = sheetMetalDocument.Sketches;
            sketch = sketchs.Add();

            // Create profile.
            profiles = sketch.Profiles;
            profile = profiles.Add(refPlane);

            // Create 2D circle.
            circles2d = profile.Circles2d;
            circle2d = circles2d.AddByCenterRadius(0, 0, 0.05);

            profile.Visible = false;

            // Create extruded protrusion.
            models = sheetMetalDocument.Models;
            model = models.AddBaseTab(profile, SolidEdgePart.FeaturePropertyConstants.igRight);
        }

        static void CreateExtrudedCutout(SolidEdgePart.SheetMetalDocument sheetMetalDocument)
        {
            SolidEdgePart.RefPlanes refPlanes = null;
            SolidEdgePart.RefPlane refPlane = null;
            SolidEdgePart.Sketchs sketchs = null;
            SolidEdgePart.Sketch sketch = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgeFrameworkSupport.Circles2d circles2d = null;
            SolidEdgeFrameworkSupport.Circle2d circle2d = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;
            SolidEdgePart.ExtrudedCutouts extrudedCutouts = null;
            SolidEdgePart.ExtrudedCutout extrudedCutout = null;
            List<SolidEdgePart.Profile> profileList = new List<SolidEdgePart.Profile>();
            double finiteDepth1 = 0.5;

            // Get refplane.
            refPlanes = sheetMetalDocument.RefPlanes;
            refPlane = refPlanes.Item(2);

            // Create 2nd sketch.
            sketchs = sheetMetalDocument.Sketches;
            sketch = sketchs.Add();

            // Create profile.
            profiles = sketch.Profiles;
            profile = profiles.Add(refPlane);

            // Create 2D circle.
            circles2d = profile.Circles2d;
            circle2d = circles2d.AddByCenterRadius(0, 0, 0.025);

            profile.Visible = false;
            profileList.Add(profile);

            models = sheetMetalDocument.Models;
            model = models.Item(1);

            extrudedCutouts = model.ExtrudedCutouts;
            extrudedCutout = extrudedCutouts.Add(
                profileList.Count, 
                profileList.ToArray(), 
                SolidEdgePart.FeaturePropertyConstants.igLeft,
                SolidEdgePart.FeaturePropertyConstants.igFinite,
                SolidEdgePart.FeaturePropertyConstants.igSymmetric,
                finiteDepth1,
                null,
                SolidEdgePart.KeyPointExtentConstants.igTangentNormal,
                null,
                SolidEdgePart.OffsetSideConstants.seOffsetNone,
                0,
                SolidEdgePart.TreatmentTypeConstants.seTreatmentNone,
                SolidEdgePart.DraftSideConstants.seDraftNone,
                0,
                SolidEdgePart.TreatmentCrownTypeConstants.seTreatmentCrownNone,
                SolidEdgePart.TreatmentCrownSideConstants.seTreatmentCrownSideNone,
                SolidEdgePart.TreatmentCrownCurvatureSideConstants.seTreatmentCrownCurvatureNone,
                0,
                0,
                SolidEdgePart.FeaturePropertyConstants.igNone,
                SolidEdgePart.FeaturePropertyConstants.igNone,
                0,
                null,
                SolidEdgePart.KeyPointExtentConstants.igTangentNormal,
                null,
                SolidEdgePart.OffsetSideConstants.seOffsetNone,
                0,
                SolidEdgePart.TreatmentTypeConstants.seTreatmentNone,
                SolidEdgePart.DraftSideConstants.seDraftNone,
                0,
                SolidEdgePart.TreatmentCrownTypeConstants.seTreatmentCrownNone,
                SolidEdgePart.TreatmentCrownSideConstants.seTreatmentCrownSideNone,
                SolidEdgePart.TreatmentCrownCurvatureSideConstants.seTreatmentCrownCurvatureNone,
                0,
                0);
        }
    }
}
