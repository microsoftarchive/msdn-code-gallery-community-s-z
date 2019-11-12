using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Part.BSplineCurves
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

                Console.WriteLine("Creating b-spline curves.");
                CreateBSplineCurve2d(partDocument);

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

        static void CreateBSplineCurve2d(SolidEdgePart.PartDocument partDocument)
        {
            SolidEdgePart.RefPlanes refPlanes = null;
            SolidEdgePart.RefPlane refPlane = null;
            SolidEdgePart.Sketchs sketches = null;
            SolidEdgePart.Sketch sketch = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgeFrameworkSupport.BSplineCurves2d bsplineCurves2d = null;
            SolidEdgeFrameworkSupport.BSplineCurve2d bsplineCurve2d1 = null;
            SolidEdgeFrameworkSupport.BSplineCurve2d bsplineCurve2d2 = null;
            double startX = 0;
            double startY = 0;
            double endX = 0;
            double endY = 0;
            SolidEdgeFrameworkSupport.Arcs2d arcs2d = null;
            SolidEdgeFrameworkSupport.Arc2d arc2d = null;
            SolidEdgeFrameworkSupport.Relations2d relations2d = null;

            // Get a reference to the RefPlanes collection.
            refPlanes = partDocument.RefPlanes;

            // Front (xz).
            refPlane = refPlanes.Item(3);

            // Get a reference to the Sketches collection.
            sketches = partDocument.Sketches;

            // Create a new sketch.
            sketch = sketches.Add();

            // Get a reference to the Profiles collection.
            profiles = sketch.Profiles;

            // Create a new profile.
            profile = profiles.Add(refPlane);

            // Get a reference to the BSplineCurves2d collection.
            bsplineCurves2d = profile.BSplineCurves2d;

            List<double> points = new List<double>();
            points.Add(10.0 / 1000);
            points.Add(0.0 / 1000);
            points.Add(9.0 / 1000);
            points.Add(6.0 / 1000);
            points.Add(3.0 / 1000);
            points.Add(12.0 / 1000);

            // Create initial b-spline.
            bsplineCurve2d1 = bsplineCurves2d.AddByPoints(
                Order: 6,
                ArraySize: 3,
                Array: points.ToArray());

            // Mirror initial b-spline.
            bsplineCurve2d2 = (SolidEdgeFrameworkSupport.BSplineCurve2d)
                bsplineCurve2d1.Mirror(
                    x1: 0.0,
                    y1: 1.0,
                    x2: 0.0,
                    y2: -1.0,
                    BooleanCopyFlag: true);

            bsplineCurve2d1.GetNode(
                Index: bsplineCurve2d1.NodeCount,
                x: out startX,
                y: out startY);

            bsplineCurve2d2.GetNode(
                Index: bsplineCurve2d2.NodeCount,
                x: out endX,
                y: out endY);

            // Get a reference to the Arcs2d collection.
            arcs2d = profile.Arcs2d;

            // Draw arc to connect the two b-splines.
            arc2d = arcs2d.AddByCenterStartEnd(
                xCenter: 0.0,
                yCenter: 0.0,
                xStart: startX,
                yStart: startY,
                xEnd: endX,
                yEnd: endY);

            int endKeyPointIndex1 = GetBSplineCurves2dEndKeyPointIndex(bsplineCurve2d1);
            int endKeyPointIndex2 = GetBSplineCurves2dEndKeyPointIndex(bsplineCurve2d2);

            // Get a reference to the Relations2d collection.
            relations2d = (SolidEdgeFrameworkSupport.Relations2d)
                profile.Relations2d;

            // Connect BSplineCurve2d and arc.
            relations2d.AddKeypoint(
                Object1: bsplineCurve2d1,
                Index1: endKeyPointIndex1,
                Object2: arc2d,
                Index2: (int)SolidEdgeConstants.KeypointIndexConstants.igArcStart);

            // Connect BSplineCurve2d and arc.
            relations2d.AddKeypoint(
                Object1: bsplineCurve2d2,
                Index1: endKeyPointIndex2,
                Object2: arc2d,
                Index2: (int)SolidEdgeConstants.KeypointIndexConstants.igArcEnd);
        }

        static int GetBSplineCurves2dEndKeyPointIndex(SolidEdgeFrameworkSupport.BSplineCurve2d bsplineCurve2d)
        {
            // Keypoint indices are zero-based......
            for (int i = 0; i < bsplineCurve2d.KeyPointCount - 1; i++)
            {
                double x = 0;
                double y = 0;
                double z = 0;
                SolidEdgeFramework.KeyPointType keypointType;
                int handleType = 0;

                bsplineCurve2d.GetKeyPoint(
                    Index: i,
                    x: out x,
                    y: out y,
                    z: out z,
                    KeypointType: out keypointType,
                    HandleType: out handleType);

                if (keypointType == SolidEdgeFramework.KeyPointType.igKeyPointEnd)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
