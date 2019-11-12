using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Part.PhysicalProperties
{
    /// <summary>
    /// Console application that demonstrates how to work with physical properties.
    /// </summary>
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

                Console.WriteLine("Drawing part.");

                // Create geometry.
                CreateFiniteExtrudedProtrusion(partDocument);

                Console.WriteLine();

                // Physical properties have not yet been computed for this model
                // so all values will be 0 with a status of 2.
                GetPhysicalProperties(partDocument, false);

                // This time, we will compute the physical properties of the model.
                GetPhysicalProperties(partDocument, true);

                Console.WriteLine("Switching to ISO view.");

                // Switch to ISO view.
                application.StartCommand((SolidEdgeFramework.SolidEdgeCommandConstants)SolidEdgeConstants.PartCommandConstants.PartViewISOView);

                // Show physical properties window.
                application.StartCommand((SolidEdgeFramework.SolidEdgeCommandConstants)SolidEdgeConstants.PartCommandConstants.PartToolsPhysicalProperties);
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
                    x1: lineMatrix[i, 0],
                    y1: lineMatrix[i, 1],
                    x2: lineMatrix[i, 2],
                    y2: lineMatrix[i, 3]);
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
                    Object1: lines2d.Item(i),
                    Index1: (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd,
                    Object2: lines2d.Item(j),
                    Index2: (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart,
                    guaranteed_ok: true);
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
                NumberOfProfiles: aProfiles.Length,
                ProfileArray: ref aProfiles,
                ProfilePlaneSide: SolidEdgePart.FeaturePropertyConstants.igRight,
                ExtrusionDistance: 0.005);
        }

        static void GetPhysicalProperties(SolidEdgePart.PartDocument partDocument, bool compute)
        {
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;

            models = partDocument.Models;
            model = models.Item(1);

            double density = 0;
            double accuracy = 0;
            double volume = 0;
            double area = 0;
            double mass = 0;
            Array cetnerOfGravity = Array.CreateInstance(typeof(double), 3);
            Array centerOfVolumne = Array.CreateInstance(typeof(double), 3);
            Array globalMomentsOfInteria = Array.CreateInstance(typeof(double), 6);     // Ixx, Iyy, Izz, Ixy, Ixz and Iyz 
            Array principalMomentsOfInteria = Array.CreateInstance(typeof(double), 3);  // Ixx, Iyy and Izz
            Array principalAxes = Array.CreateInstance(typeof(double), 9);              // 3 axes x 3 coords
            Array radiiOfGyration = Array.CreateInstance(typeof(double), 9);            // 3 axes x 3 coords
            double relativeAccuracyAchieved = 0;
            int status = 0;

            if (compute)
            {
                density = 1;
                accuracy = 0.05;

                model.ComputePhysicalProperties(
                    Density: density,
                    Accuracy: accuracy,
                    Volume: out volume,
                    Area: out area,
                    Mass: out mass,
                    CenterOfGravity: ref cetnerOfGravity,
                    CenterOfVolume: ref centerOfVolumne,
                    GlobalMomentsOfInteria: ref globalMomentsOfInteria,
                    PrincipalMomentsOfInteria: ref principalMomentsOfInteria,
                    PrincipalAxes: ref principalAxes,
                    RadiiOfGyration: ref radiiOfGyration,
                    RelativeAccuracyAchieved: out relativeAccuracyAchieved,
                    Status: out status);

                Console.WriteLine("ComputePhysicalProperties() results:");
            }
            else
            {
                model.GetPhysicalProperties(
                    Status: out status,
                    Density: out density,
                    Accuracy: out accuracy,
                    Volume: out volume,
                    Area: out area,
                    Mass: out mass,
                    CenterOfGravity: ref cetnerOfGravity,
                    CenterOfVolume: ref centerOfVolumne,
                    GlobalMomentsOfInteria: ref globalMomentsOfInteria,
                    PrincipalMomentsOfInteria: ref principalMomentsOfInteria,
                    PrincipalAxes: ref principalAxes,
                    RadiiOfGyration: ref radiiOfGyration,
                    RelativeAccuracyAchieved: out relativeAccuracyAchieved);

                Console.WriteLine("GetPhysicalProperties() results:");
            }

            // Write results to screen.

            Console.WriteLine("Density: {0}", density);
            Console.WriteLine("Accuracy: {0}", accuracy);
            Console.WriteLine("Volume: {0}", volume);
            Console.WriteLine("Area: {0}", area);
            Console.WriteLine("Mass: {0}", mass);

            // Convert from System.Array to double[].  double[] is easier to work with.
            double[] m = cetnerOfGravity.OfType<double>().ToArray();

            Console.WriteLine("CenterOfGravity:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);

            m = centerOfVolumne.OfType<double>().ToArray();

            Console.WriteLine("CenterOfVolume:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);

            m = globalMomentsOfInteria.OfType<double>().ToArray();

            Console.WriteLine("GlobalMomentsOfInteria:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);
            Console.WriteLine("\t|{0}, {1}, {2}|", m[3], m[4], m[5]);

            m = principalMomentsOfInteria.OfType<double>().ToArray();

            Console.WriteLine("PrincipalMomentsOfInteria:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);

            m = principalAxes.OfType<double>().ToArray();

            Console.WriteLine("PrincipalAxes:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);
            Console.WriteLine("\t|{0}, {1}, {2}|", m[3], m[4], m[5]);
            Console.WriteLine("\t|{0}, {1}, {2}|", m[6], m[7], m[8]);

            m = radiiOfGyration.OfType<double>().ToArray();

            Console.WriteLine("RadiiOfGyration:");
            Console.WriteLine("\t|{0}, {1}, {2}|", m[0], m[1], m[2]);
            Console.WriteLine("\t|{0}, {1}, {2}|", m[3], m[4], m[5]);
            Console.WriteLine("\t|{0}, {1}, {2}|", m[6], m[7], m[8]);

            Console.WriteLine("RelativeAccuracyAchieved: {0}", relativeAccuracyAchieved);
            Console.WriteLine("Status: {0}", status);
            Console.WriteLine();
        }
    }
}
