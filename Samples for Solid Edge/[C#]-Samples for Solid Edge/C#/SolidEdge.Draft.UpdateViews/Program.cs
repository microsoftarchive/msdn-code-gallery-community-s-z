using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Draft.UpdateViews
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

                // Get a reference to the documents collection.
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

                sections = draftDocument.Sections;

                // Update all views in the working section.
                UpdateAllViewsInWorkingSection(sections.WorkingSection);

                // Update all views in all sheets.
                //UpdateAllViewsInAllSheets(draftDocument.Sheets);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateAllViewsInWorkingSection(SolidEdgeDraft.Section section)
        {
            SolidEdgeDraft.SectionSheets sectionSheets = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;

            sectionSheets = section.Sheets;

            for (int i = 1; i <= sectionSheets.Count; i++)
            {
                sheet = sectionSheets.Item(i);

                drawingViews = sheet.DrawingViews;

                for (int j = 1; j < drawingViews.Count; j++)
                {
                    drawingView = drawingViews.Item(j);

                    Console.WriteLine("Updating DrawingView '{0} - {1}'.", drawingView.Name, drawingView.Caption);

                    // Updates an out-of-date drawing view.
                    drawingView.Update();

                    // Updates the drawing view even if it is not out-of-date.
                    //drawingView.ForceUpdate();
                }
            }
        }

        static void UpdateAllViewsInAllSheets(SolidEdgeDraft.Sheets sheets)
        {
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;

            for (int i = 1; i < sheets.Count; i++)
            {
                sheet = sheets.Item(i);

                Console.WriteLine("Processing Sheet '{0}'.", sheet.Name);

                drawingViews = sheet.DrawingViews;

                for (int j = 1; j < drawingViews.Count; j++)
                {
                    drawingView = drawingViews.Item(j);

                    Console.WriteLine("Updating DrawingView '{0} - {1}'.", drawingView.Name, drawingView.Caption);

                    // Updates an out-of-date drawing view.
                    drawingView.Update();

                    // Updates the drawing view even if it is not out-of-date.
                    //drawingView.ForceUpdate();
                }
            }
        }
    }
}
