using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SheetMetal.SaveAsFlat
{
    /// <summary>
    /// Console application that demonstrates how to save a SheetMetal document as flat.
    /// </summary>
    /// <param name="args"></param>
    /// <remarks>FanPlate.psm from training folder was used to create this example.</remarks>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgePart.SheetMetalDocument sheetMetalDocument = null;
            SolidEdgePart.FlatPatternModels flatPatternModels = null;
            SolidEdgePart.FlatPatternModel flatPatternModel = null;
            SolidEdgePart.Models models = null;
            SolidEdgePart.Model model = null;
            SolidEdgeGeometry.Face face = null;
            SolidEdgeGeometry.Edge edge = null;
            SolidEdgeGeometry.Vertex vertex = null;
            bool useFlatPattern = true;
            bool flatPatternIsUpToDate = false;
            string outFile = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to Solid Edge,
                application = SolidEdgeUtils.Connect(false);

                // Make sure user can see the GUI.
                application.Visible = true;

                // Bring Solid Edge to the foreground.
                application.Activate();

                // Get a reference to the documents collection.
                documents = application.Documents;

                // This check is necessary because application.ActiveDocument will throw an
                // exception if no documents are open...
                if (documents.Count > 0)
                {
                    // Attempt to open specified SheetMetalDocument.
                    sheetMetalDocument = application.ActiveDocument as SolidEdgePart.SheetMetalDocument;
                }

                if (sheetMetalDocument == null)
                {
                    throw new System.Exception("No active Sheet Metal document.");
                }

                // Get a reference to the Models collection,
                models = sheetMetalDocument.Models;

                // Check for geometry.
                if (models.Count == 0)
                {
                    throw new System.Exception("No geometry defined.");
                }

                // Get a reference to the one and only model.
                model = models.Item(1);

                // Get a reference to the FlatPatternModels collection,
                flatPatternModels = sheetMetalDocument.FlatPatternModels;

                // Observation: SaveAsFlatDXFEx() will fail if useFlatPattern is specified and
                // flatPatternModels.Count = 0.
                // The following code will turn off the useFlatPattern switch if flatPatternModels.Count = 0.
                if (useFlatPattern)
                {
                    if (flatPatternModels.Count > 0)
                    {
                        for (int i = 1; i <= flatPatternModels.Count; i++)
                        {
                            flatPatternModel = flatPatternModels.Item(i);
                            flatPatternIsUpToDate = flatPatternModel.IsUpToDate;

                            // If we find one that is up to date, call it good and bail.
                            if (flatPatternIsUpToDate) break;
                        }

                        if (flatPatternIsUpToDate == false)
                        {
                            // Flat patterns exist but are out of date.
                            useFlatPattern = false;
                        }
                    }
                    else
                    {
                        // Can't use flat pattern if none exist.
                        useFlatPattern = false;
                    }
                }

                Console.WriteLine("Determining desired face, edge & vertex for SaveAsFlatDXFEx().");

                // Some routine to get face, edge & vertex.
                GetFaceEdgeVertexForModel(model, out face, out edge, out vertex);

                outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".dxf");
                //outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".par");
                //outFile = Path.ChangeExtension(sheetMetalDocument.FullName, ".psm");

                // Observation: If .par or .psm is specified in outFile, SE will open the file.
                // Even if useFlatPattern = true, it's a good idea to specify defaults for face, edge & vertex.
                // I've seen where outFile of .dxf would work but .psm would fail if the defaults were null;
                Console.WriteLine("Saving '{0}'.", outFile);
                models.SaveAsFlatDXFEx(outFile, face, edge, vertex, useFlatPattern);

                if (useFlatPattern)
                {
                    Console.WriteLine("Saved '{0}' using Flat Pattern.", outFile);
                }
                else
                {
                    Console.WriteLine("Saved '{0}' without using Flat Pattern.", outFile);
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        // In a real world scenario, you would want logic (or user input) to pick the desired
        // face, edge & *vertex. Here, we just grab the 1st we can find. *Vertex can be null.
        static void GetFaceEdgeVertexForModel(
            SolidEdgePart.Model model,
            out SolidEdgeGeometry.Face face,
            out SolidEdgeGeometry.Edge edge,
            out SolidEdgeGeometry.Vertex vertex)
        {
            SolidEdgeGeometry.Body body = null;
            SolidEdgeGeometry.Faces faces;
            SolidEdgeGeometry.Edges edges = null;

            // Get a reference to the model's body.
            body = (SolidEdgeGeometry.Body)model.Body;

            // Query for all faces in the body.
            faces = (SolidEdgeGeometry.Faces)body.Faces[SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll];

            // Get a reference to the first face.
            face = (SolidEdgeGeometry.Face)faces.Item(1);

            // Get a reference to the face's Edges collection,
            edges = (SolidEdgeGeometry.Edges)face.Edges;

            // Get a reference to the first edge.
            edge = (SolidEdgeGeometry.Edge)edges.Item(1);

            // Not using vertex in this example.
            vertex = null;
        }
    }
}
