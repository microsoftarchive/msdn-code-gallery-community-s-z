using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Draft.DrawingViewTo2D
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draftDocument = null;
            SolidEdgeDraft.Sections sections = null;

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

                // Note: these two will throw exceptions if no document is open.
                //application.ActiveDocument
                //application.ActiveDocumentType;

                if ((documents.Count > 0) && (application.ActiveDocumentType == SolidEdgeFramework.DocumentTypeConstants.igDraftDocument))
                {
                    // Get a reference to the documents collection.
                    draftDocument = (SolidEdgeDraft.DraftDocument)application.ActiveDocument;
                }
                else
                {
                    throw new System.Exception("Draft file not open.");
                }

                // Get a reference to the Sections collection.
                sections = draftDocument.Sections;

                // Convert all drawing views to 2D.
                ConvertAllDrawingViewsTo2D(sections.WorkingSection);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void ConvertAllDrawingViewsTo2D(SolidEdgeDraft.Section section)
        {
            SolidEdgeDraft.SectionSheets sectionSheets = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;
            
            sectionSheets = section.Sheets;

            for (int i = 1; i <= sectionSheets.Count; i++)
            {
                // Get a reference to the sheet.
                sheet = sectionSheets.Item(i);

                // Get a reference to the DrawingViews collection.
                drawingViews = sheet.DrawingViews;

                for (int j = 1; j < drawingViews.Count; j++)
                {
                    drawingView = drawingViews.Item(j);

                    Console.WriteLine("Dropping (convert to 2D) DrawingView '{0} - {1}'.  ", drawingView.Name, drawingView.Caption);

                    // DrawingView's of type igUserView cannot be converted.
                    if (drawingView.DrawingViewType != SolidEdgeDraft.DrawingViewTypeConstants.igUserView)
                    {
                        // Converts the current DrawingView to an igUserView type containing simple geometry
                        // and disassociates the drawing view from the source 3d Model.
                        drawingView.Drop();
                    }
                }
            }
        }
    }
}
