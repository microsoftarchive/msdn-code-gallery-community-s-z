using SolidEdgeDraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SolidEdge.Draft.Sheets
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeDraft.DraftDocument draftDocument = null;
            SolidEdgeDraft.Sheets sheets = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.Sections sections = null;
            SolidEdgeDraft.Section section = null;

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

                    // Get a reference to the sheets collection.
                    sheets = draftDocument.Sheets;

                    // Get a reference to the active sheet.
                    sheet = draftDocument.ActiveSheet;
                    Console.WriteLine("DraftDocument.ActiveSheet: {0}", sheet.Name);

                    // Get a reference to all sections.
                    sections = draftDocument.Sections;

                    // Get a reference to the active section.
                    section = draftDocument.ActiveSection;
                    Console.WriteLine("DraftDocument.ActiveSection: {0}", section.Type);

                    Console.WriteLine();
                    ProcessSheets(draftDocument.Sheets);
                    Console.WriteLine();
                    ProcessSections(draftDocument.Sections);
                    Console.WriteLine();
                    ProcessWorkingSectionDrawingViews(sections.WorkingSection);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Draft file not open.");
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

        static void ProcessSheets(SolidEdgeDraft.Sheets sheets)
        {
            Console.WriteLine("--> {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());

            SolidEdgeDraft.Sheet sheet = null;

            for (int i = 1; i <= sheets.Count; i++)
            {
                sheet = sheets.Item(i);
                Console.WriteLine("\tSheet.Name: {0}", sheet.Name);
            }

            Console.WriteLine("<-- {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

        static void ProcessSections(SolidEdgeDraft.Sections sections)
        {
            Console.WriteLine("--> {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());

            SolidEdgeDraft.Section section = null;

            for (int i = 1; i <= sections.Count; i++)
            {
                section = sections.Item(i);
                Console.WriteLine(String.Format("\tSection.Type: {0}", section.Type));

                ProcessSectionSheets(section.Sheets);
            }

            Console.WriteLine("<-- {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

        static void ProcessSectionSheets(SolidEdgeDraft.SectionSheets sectionSheets)
        {
            SolidEdgeDraft.Sheet sheet = null;

            for (int i = 1; i <= sectionSheets.Count; i++)
            {
                sheet = sectionSheets.Item(i);
                Console.WriteLine("\tSheet.Name: {0}", sheet.Name);
            }
        }

        static void ProcessWorkingSectionDrawingViews(SolidEdgeDraft.Section section)
        {
            Console.WriteLine("--> {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());

            SolidEdgeDraft.SectionSheets sectionSheets = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgeDraft.DrawingView drawingView = null;

            if (section.Type == SolidEdgeDraft.SheetSectionTypeConstants.igWorkingSection)
            {
                sectionSheets = section.Sheets;

                for (int i = 1; i <= sectionSheets.Count; i++)
                {
                    sheet = sectionSheets.Item(i);
                    Console.WriteLine("\tSheet.Name: {0}", sheet.Name);

                    drawingViews = sheet.DrawingViews;
                    for (int j = 1; j <= sectionSheets.Count; j++)
                    {
                        drawingView = drawingViews.Item(j);
                        Console.WriteLine("\tDrawingView.Name: {0}", drawingView.Name);

                        ProcessDrawingViewModelLink(drawingView);
                        ProcessDrawingViewModelMembers(drawingView);
                    }
                }
            }
            else
            {
                Console.WriteLine("Section '{0}' is not an igWorkingSection.", section);
            }

            Console.WriteLine("<-- {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

        static void ProcessDrawingViewModelLink(SolidEdgeDraft.DrawingView drawingView)
        {
            Console.WriteLine("--> {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());

            SolidEdgeDraft.ModelLink modelLink = null;
            SolidEdgeFramework.SolidEdgeDocument solidEdgeDocument = null;

            try
            {
                // drawingView.ModelLink will throw exception if link is not found.
                modelLink = drawingView.ModelLink as SolidEdgeDraft.ModelLink;
                Console.WriteLine("\tModelLink.FileName: {0}", modelLink.FileName);

                solidEdgeDocument = modelLink.ModelDocument as SolidEdgeFramework.SolidEdgeDocument;

                if (solidEdgeDocument != null)
                {
                    Console.WriteLine("\tModelDocument.Type: {0}", solidEdgeDocument.Type);
                    switch (solidEdgeDocument.Type)
                    {
                        case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument:
                            break;
                        case SolidEdgeFramework.DocumentTypeConstants.igPartDocument:
                            break;
                        case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument:
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("\tModelLink.FileName: Not found");
            }

            Console.WriteLine("<-- {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

        static void ProcessDrawingViewModelMembers(SolidEdgeDraft.DrawingView drawingView)
        {
            Console.WriteLine("--> {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());

            ProcessModelMembers(drawingView.ModelMembers, 1);

            Console.WriteLine("<-- {0}", System.Reflection.MethodBase.GetCurrentMethod().ToString());
        }

        /// <summary>
        /// Recursive function to traverse ModelMembers.
        /// </summary>
        static void ProcessModelMembers(SolidEdgeDraft.ModelMembers modelMembers, int level)
        {
            string indent = new String('\t', level);

            SolidEdgeDraft.ModelMember modelMember = null;

            for (int i = 1; i <= modelMembers.Count; i++)
            {
                modelMember = modelMembers.Item(i);
                Console.WriteLine("{0}ModelMember: '{1}' ({2})", indent, modelMember.ComponentName, modelMember.ComponentType);

                ProcessModelMembers(modelMember.ModelMembers, level + 1);
            }
        }
    }
}
