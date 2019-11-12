using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SheetMetal.Holes
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

                // Create holes.
                CreateHolesWithUserDefinedPattern(sheetMetalDocument);

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

            // Get a reference to Right (yz) plane.
            refPlane = refPlanes.Item(3);

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

        static void CreateHolesWithUserDefinedPattern(SolidEdgePart.SheetMetalDocument sheetMetalDocument)
        {
            SolidEdgePart.RefPlanes refplanes = null;
            SolidEdgePart.RefPlane refplane = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;
            SolidEdgePart.HoleDataCollection holeDataCollection = null;
            SolidEdgePart.ProfileSets profileSets = null;
            SolidEdgePart.ProfileSet profileSet = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgePart.Holes2d holes2d = null;
            SolidEdgePart.Hole2d hole2d = null;
            SolidEdgePart.Holes holes = null;
            SolidEdgePart.Hole hole = null;
            long profileStatus = 0;
            List<SolidEdgePart.Profile> profileList = new List<SolidEdgePart.Profile>();
            SolidEdgePart.UserDefinedPatterns userDefinedPatterns = null;
            SolidEdgePart.UserDefinedPattern userDefinedPattern = null;

            // Get a reference to the RefPlanes collection.
            refplanes = sheetMetalDocument.RefPlanes;

            // Get a reference to Right (yz) plane.
            refplane = refplanes.Item(3);

            // Get a reference to the Models collection.
            models = sheetMetalDocument.Models;

            // Get a reference to Model.
            model = models.Item(1);

            // Get a reference to the ProfileSets collection.
            profileSets = sheetMetalDocument.ProfileSets;

            // Add new ProfileSet.
            profileSet = profileSets.Add();

            // Get a reference to the Profiles collection.
            profiles = profileSet.Profiles;

            // Add new Profile.
            profile = profiles.Add(refplane);

            // Get a reference to the Holes2d collection.
            holes2d = profile.Holes2d;

            // This creates a cross pattern of holes.
            double[,] holeMatrix = new double[,]
				{
                    //{x, y}
                    {0.00, 0.00},
                    {-0.01, 0.00},
                    {-0.02, 0.00},
                    {-0.03, 0.00},
                    {-0.04, 0.00},
                    {0.01, 0.00},
                    {0.02, 0.00},
                    {0.03, 0.00},
                    {0.04, 0.00},
                    {0.00, -0.01},
                    {0.00, -0.02},
                    {0.00, -0.03},
                    {0.00, -0.04},
                    {0.00, 0.01},
                    {0.00, 0.02},
                    {0.00, 0.03},
                    {0.00, 0.04}
				};

            // Draw the Base Profile.
            for (int i = 0; i <= holeMatrix.GetUpperBound(0); i++)
            {
                // Add new Hole2d.
                hole2d = holes2d.Add(
                    XCenter: holeMatrix[i, 0],
                    YCenter: holeMatrix[i, 1]);
            }

            // Hide the profile.
            profile.Visible = false;

            // Close profile.
            profileStatus = profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);

            // Get a reference to the ProfileSet.
            profileSet = (SolidEdgePart.ProfileSet)profile.Parent;

            // Get a reference to the Profiles collection.
            profiles = profileSet.Profiles;

            // Add profiles to list for AddByProfiles().
            for (int i = 1; i <= profiles.Count; i++)
            {
                profileList.Add(profiles.Item(i));
            }

            // Get a reference to the HoleDataCollection collection.
            holeDataCollection = sheetMetalDocument.HoleDataCollection;

            // Add new HoleData.
            SolidEdgePart.HoleData holeData = holeDataCollection.Add(
                HoleType: SolidEdgePart.FeaturePropertyConstants.igRegularHole,
                HoleDiameter: 0.005,
                BottomAngle: 90);

            // Get a reference to the Holes collection.
            holes = model.Holes;

            // Add hole.
            hole = holes.AddFinite(
                Profile: profile,
                ProfilePlaneSide: SolidEdgePart.FeaturePropertyConstants.igRight,
                FiniteDepth: 0.005,
                Data: holeData);

            // Get a reference to the UserDefinedPatterns collection.
            userDefinedPatterns = model.UserDefinedPatterns;

            // Create the user defined pattern.
            userDefinedPattern = userDefinedPatterns.AddByProfiles(
                NumberOfProfiles: profileList.Count,
                ProfilesArray: profileList.ToArray(),
                SeedFeature: hole);
        }
    }
}
