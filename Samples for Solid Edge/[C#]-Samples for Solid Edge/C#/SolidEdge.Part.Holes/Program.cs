using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Part.Holes
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgePart.PartDocument partDocument = null;

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

                Console.WriteLine("Creating a new part document.");

                // Create a new part document.
                partDocument = (SolidEdgePart.PartDocument)
                    documents.Add("SolidEdge.PartDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                Console.WriteLine("Creating geometry.");

                // Create geometry.
                CreateFiniteExtrudedProtrusion(partDocument);

                Console.WriteLine("Creating holes with user defined patterns.");

                // Create holes.
                CreateHolesWithUserDefinedPattern(partDocument);

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

        static void CreateFiniteExtrudedProtrusion(SolidEdgePart.PartDocument partDocument)
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
            System.Array aProfiles = null;

            // Get a reference to the profile sets collection.
            profileSets = partDocument.ProfileSets;

            // Add a new profile set.
            profileSet = profileSets.Add();

            // Get a reference to the profiles collection.
            profiles = profileSet.Profiles;

            // Get a reference to the ref planes collection.
            refplanes = partDocument.RefPlanes;

            // Add a new profile.
            profile = profiles.Add(refplanes.Item(3));

            // Get a reference to the lines2d collection.
            lines2d = profile.Lines2d;

            // UOM = meters.
            double[,] lineMatrix = new double[,]
				{
                    //{x1, y1, x2, y2}
                    {0, 0, 0.08, 0},
                    {0.08, 0, 0.08, 0.06},
                    {0.08, 0.06, 0.064, 0.06},
                    {0.064, 0.06, 0.064, 0.02},
                    {0.064, 0.02, 0.048, 0.02},
                    {0.048, 0.02, 0.048, 0.06},
                    {0.048, 0.06, 0.032, 0.06},
                    {0.032, 0.06, 0.032, 0.02},
                    {0.032, 0.02, 0.016, 0.02},
                    {0.016, 0.02, 0.016, 0.06},
                    {0.016, 0.06, 0, 0.06},
                    {0, 0.06, 0, 0}
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

            // Create a new array of profile objects.
            aProfiles = Array.CreateInstance(typeof(SolidEdgePart.Profile), 1);
            aProfiles.SetValue(profile, 0);

            // Get a reference to the models collection.
            models = partDocument.Models;

            Console.WriteLine("Creating finite extruded protrusion.");

            // Create the extended protrusion.
            model = models.AddFiniteExtrudedProtrusion(
              aProfiles.Length,
              ref aProfiles,
              SolidEdgePart.FeaturePropertyConstants.igRight,
              0.005);
        }

        static void CreateHolesWithUserDefinedPattern(SolidEdgePart.PartDocument partDocument)
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
            refplanes = partDocument.RefPlanes;

            // Get a reference to Right (yz) plane.
            refplane = refplanes.Item(3);

            // Get a reference to the Models collection.
            models = partDocument.Models;

            // Get a reference to Model.
            model = models.Item(1);

            // Get a reference to the ProfileSets collection.
            profileSets = partDocument.ProfileSets;

            // Add new ProfileSet.
            profileSet = profileSets.Add();

            // Get a reference to the Profiles collection.
            profiles = profileSet.Profiles;

            // Add new Profile.
            profile = profiles.Add(refplane);

            // Get a reference to the Holes2d collection.
            holes2d = profile.Holes2d;

            double[,] holeMatrix = new double[,]
				{
                    //{x, y}
                    {0.01, 0.01},
                    {0.02, 0.01},
                    {0.03, 0.01},
                    {0.04, 0.01},
                    {0.05, 0.01},
                    {0.06, 0.01},
                    {0.07, 0.01}
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
            holeDataCollection = partDocument.HoleDataCollection;

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
