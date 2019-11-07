using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace SolidEdge.Part.FiniteRevolvedProtrusion
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
            SolidEdgePart.RefPlanes refPlanes = null;
            SolidEdgePart.RefPlane refPlane = null;
            SolidEdgePart.ProfileSets profileSets = null;
            SolidEdgePart.ProfileSet profileSet = null;
            SolidEdgePart.Profiles profiles = null;
            SolidEdgePart.Profile profile = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;
            SolidEdgeFrameworkSupport.Lines2d lines2d = null;
            SolidEdgeFrameworkSupport.Line2d axis = null;
            SolidEdgeFrameworkSupport.Arcs2d arcs2d = null;
            SolidEdgeFrameworkSupport.Relations2d relations2d = null;
            SolidEdgePart.RefAxis refaxis = null;
            Array aProfiles = null;
            SolidEdgeGeometry.Edges edges = null;
            SolidEdgeGeometry.Circle circle = null;
            SolidEdgePart.RevolvedProtrusions revolvedProtrusions = null;
            SolidEdgePart.RevolvedProtrusion revolvedProtrusion = null;
            Array center = null;

            SolidEdgePart.Rounds rounds = null;

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


                // D1 to FA are parameters in a form, introduced by the user.
                double D1 = 0.020;
                double D2 = 0.026;
                double D3 = 0.003;
                double D4 = 0.014;
                double L1 = 0.040;
                double L2 = 0.030;
                double L3 = 0.005;
                double FA = 0.0005; // round

                // Get a reference to the ref planes collection.
                refPlanes = partDocument.RefPlanes;

                // Front (xz).
                refPlane = refPlanes.Item(3);

                // Get a reference to the profile sets collection.
                profileSets = (SolidEdgePart.ProfileSets)partDocument.ProfileSets;

                // Create a new profile set.
                profileSet = profileSets.Add();

                // Get a reference to the profiles collection.
                profiles = profileSet.Profiles;

                // Create a new profile.
                profile = profiles.Add(refPlane);

                // Get a reference to the profile lines2d collection.
                lines2d = profile.Lines2d;

                // Get a reference to the profile arcs2d collection.
                arcs2d = profile.Arcs2d;

                double H = L1 - L2;
                double y = L1 - L3 - (D4 - D3) / (2 * Math.Tan((118 / 2) * (Math.PI / 180)));

                lines2d.AddBy2Points(D3 / 2, 0, D2 / 2, 0);		// Line1
                lines2d.AddBy2Points(D2 / 2, 0, D2 / 2, H);		// Line2
                lines2d.AddBy2Points(D2 / 2, H, D1 / 2, H);		// Line3
                lines2d.AddBy2Points(D1 / 2, H, D1 / 2, L1);	// Line4
                lines2d.AddBy2Points(D1 / 2, L1, D4 / 2, L1);	// Line5
                lines2d.AddBy2Points(D4 / 2, L1, D4 / 2, L1 - L3);	// Line6
                lines2d.AddBy2Points(D4 / 2, L1 - L3, D3 / 2, y);	// Line7
                lines2d.AddBy2Points(D3 / 2, y, D3 / 2, 0);		// Line8

                axis = lines2d.AddBy2Points(0, 0, 0, L1);
                profile.ToggleConstruction(axis);

                // relations
                relations2d = (SolidEdgeFrameworkSupport.Relations2d)profile.Relations2d;
                relations2d.AddKeypoint(lines2d.Item(1), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(2), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(2), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(3), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(3), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(4), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(4), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(5), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(5), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(6), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(6), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(7), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(7), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(8), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);
                relations2d.AddKeypoint(lines2d.Item(8), (int)SolidEdgeConstants.KeypointIndexConstants.igLineEnd, lines2d.Item(1), (int)SolidEdgeConstants.KeypointIndexConstants.igLineStart, true);

                refaxis = (SolidEdgePart.RefAxis)profile.SetAxisOfRevolution(axis);

                // Close the profile.
                int status = profile.End(SolidEdgePart.ProfileValidationType.igProfileRefAxisRequired);
                profile.Visible = false;

                // Create a new array of profile objects.
                aProfiles = Array.CreateInstance(typeof(SolidEdgePart.Profile), 1);
                aProfiles.SetValue(profile, 0);

                Console.WriteLine("Creating finite revolved protrusion.");

                // add Finite Revolved Protrusion.
                model = models.AddFiniteRevolvedProtrusion(1, ref aProfiles, refaxis, SolidEdgePart.FeaturePropertyConstants.igRight, 2 * Math.PI, null, null);

                Console.WriteLine("Creating adding rounds.");

                SolidEdgeGeometry.Edge[] arrEdges = { null };
                double[] arrRadii = { FA };

                revolvedProtrusions = model.RevolvedProtrusions;
                revolvedProtrusion = revolvedProtrusions.Item(1);
                edges = (SolidEdgeGeometry.Edges)revolvedProtrusion.Edges[SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll];

                foreach (SolidEdgeGeometry.Edge edge in edges)
                {
                    circle = (SolidEdgeGeometry.Circle)edge.Geometry;
                    if (circle.Radius == D2 / 2)
                    {
                        center = Array.CreateInstance(typeof(double), 3);
                        circle.GetCenterPoint(ref center);
                        if ((double)center.GetValue(0) == 0 && (double)center.GetValue(1) == 0 && (double)center.GetValue(2) == H)
                        {
                            arrEdges[0] = edge;
                            break;
                        }
                    }
                }

                rounds = model.Rounds;
                object optArg = Type.Missing;
                rounds.Add(1, arrEdges, arrRadii, optArg, optArg, optArg, optArg);

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
    }

}
