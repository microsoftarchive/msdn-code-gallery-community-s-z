using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SheetMetal.PhysicalProperties
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

                Console.WriteLine("Creating a new part document.");

                // Create a new part document.
                sheetMetalDocument = (SolidEdgePart.SheetMetalDocument)
                    documents.Add("SolidEdge.SheetMetalDocument");

                // Always a good idea to give SE a chance to breathe.
                application.DoIdle();

                Console.WriteLine("Drawing part.");

                // Create geometry.
                CreateExtrudedProtrusion(sheetMetalDocument);

                Console.WriteLine();

                // Physical properties have not yet been computed for this model
                // so all values will be 0 with a status of 2.
                GetPhysicalProperties(sheetMetalDocument, false);

                // This time, we will compute the physical properties of the model.
                GetPhysicalProperties(sheetMetalDocument, true);

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

        static void GetPhysicalProperties(SolidEdgePart.SheetMetalDocument sheetMetalDocument, bool compute)
        {
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;

            models = sheetMetalDocument.Models;
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
