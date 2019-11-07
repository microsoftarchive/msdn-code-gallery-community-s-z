using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Part.SweptProtrusion
{
    /// <summary>
    /// Console application that demonstrates how to create a swept protrusion.
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgePart.PartDocument partDocument = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;
            SolidEdgePart.Sketchs sketches = null;
            SolidEdgePart.Sketch sketch = null;
            SolidEdgePart.RefPlanes refPlanes = null;
            SolidEdgePart.RefPlane refPlane = null;
            SolidEdgePart.ProfileSets profileSets = null;
            SolidEdgePart.ProfileSet profileSet = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile sketchProfile = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgeFrameworkSupport.Circles2d circles2d = null;

            List<SolidEdgePart.Profile> listPaths = new List<SolidEdgePart.Profile>();
            List<SolidEdgePart.FeaturePropertyConstants> listPathTypes = new List<SolidEdgePart.FeaturePropertyConstants>();
            List<SolidEdgePart.Profile> listSections = new List<SolidEdgePart.Profile>();
            List<SolidEdgePart.FeaturePropertyConstants> listSectionTypes = new List<SolidEdgePart.FeaturePropertyConstants>();
            List<int> listOrigins = new List<int>();

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

                Console.WriteLine("Creating a new part document.");

                // Create a new PartDocument.
                partDocument = (SolidEdgePart.PartDocument)
                    documents.Add("SolidEdge.PartDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                Console.WriteLine("Drawing part.");

                // Get a reference to the models collection.
                models = (SolidEdgePart.Models)partDocument.Models;

                // Get a reference to the Sketches collections.
                sketches = (SolidEdgePart.Sketchs)partDocument.Sketches;

                // Get a reference to the profile sets collection.
                profileSets = (SolidEdgePart.ProfileSets)partDocument.ProfileSets;

                // Get a reference to the ref planes collection.
                refPlanes = (SolidEdgePart.RefPlanes)partDocument.RefPlanes;

                // Front (xz).
                refPlane = (SolidEdgePart.RefPlane)refPlanes.Item(3);

                // Add a new sketch.
                sketch = (SolidEdgePart.Sketch)sketches.Add();

                // Add profile for sketch on specified refplane.
                sketchProfile = sketch.Profiles.Add(refPlane);

                // Get a reference to the Circles2d collection.
                circles2d = sketchProfile.Circles2d;

                // Draw the Base Profile.
                circles2d.AddByCenterRadius(0, 0, 0.02);

                // Close the profile.
                sketchProfile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);

                // Arrays for AddSweptProtrusion().
                listPaths.Add(sketchProfile);
                listPathTypes.Add(SolidEdgePart.FeaturePropertyConstants.igProfileBasedCrossSection);

                // NOTE: profile is the Curve.
                refPlane = refPlanes.AddNormalToCurve(
                    sketchProfile,
                    SolidEdgePart.ReferenceElementConstants.igCurveEnd,
                    refPlanes.Item(3),
                    SolidEdgePart.ReferenceElementConstants.igPivotEnd,
                    true,
                    System.Reflection.Missing.Value);

                // Add a new profile set.
                profileSet = (SolidEdgePart.ProfileSet)profileSets.Add();

                // Get a reference to the profiles collection.
                profiles = (SolidEdgePart.Profiles)profileSet.Profiles;

                // add a new profile.
                profile = (SolidEdgePart.Profile)profiles.Add(refPlane);

                // Get a reference to the Circles2d collection.
                circles2d = profile.Circles2d;

                // Draw the Base Profile.
                circles2d.AddByCenterRadius(0, 0, 0.01);

                // Close the profile.
                profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);

                // Arrays for AddSweptProtrusion().
                listSections.Add(profile);
                listSectionTypes.Add(SolidEdgePart.FeaturePropertyConstants.igProfileBasedCrossSection);
                listOrigins.Add(0); //Use 0 for closed profiles.

                Console.WriteLine("Creating swept protrusion.");

                // Create the extended protrusion.
                model = models.AddSweptProtrusion(
                                           listPaths.Count,
                                           listPaths.ToArray(),
                                           listPathTypes.ToArray(),
                                           listSections.Count,
                                           listSections.ToArray(),
                                           listSectionTypes.ToArray(),
                                           listOrigins.ToArray(),
                                           0,
                                           SolidEdgePart.FeaturePropertyConstants.igLeft,
                                           SolidEdgePart.FeaturePropertyConstants.igNone,
                                           0.0,
                                           null,
                                           SolidEdgePart.FeaturePropertyConstants.igNone,
                                           0.0,
                                           null);

                // Hide profiles.
                sketchProfile.Visible = false;
                profile.Visible = false;

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
    }
}
