using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SolidEdge.SelectSet
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.SelectSet selectSet = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to or start Solid Edge.
                application = SolidEdgeUtils.Connect();

                if (application != null)
                {
                    document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;

                    selectSet = application.ActiveSelectSet;

                    // Report anything that is already in the SelectSet.
                    ReportSelectSet(selectSet);

                    // Clear the SelectSet.
                    ClearSelectSet(selectSet);

                    // Depending on the document type, will add items to select set.
                    AddItemsToSelectSet(document);
                }
                else
                {
                    Console.WriteLine("Solid Edge is not running.");
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

        static void ReportSelectSet(SolidEdgeFramework.SelectSet selectSet)
        {
            if (selectSet.Count > 0)
            {
                // Loop through the items and report each one.
                for (int i = 1; i <= selectSet.Count; i++)
                {
                    object item = selectSet.Item(i);

                    // GetInteropType() is a custom method extension!
                    Type t = item.GetInteropType();

                    Console.WriteLine("Item[{0}] is of type '{1}'", i, t);
                }
            }
            else
            {
                Console.WriteLine("SelectSet is empty.");
            }
        }

        static void ClearSelectSet(SolidEdgeFramework.SelectSet selectSet)
        {
            // Clear the SelectSet.
            selectSet.RemoveAll();

            Console.WriteLine("Cleared the SelectSet.");
        }

        static void AddItemsToSelectSet(SolidEdgeFramework.SolidEdgeDocument document)
        {
            SolidEdgeAssembly.AssemblyDocument assemblyDocument = null;
            SolidEdgeAssembly.AsmRefPlanes asmRefPlanes = null;
            SolidEdgeDraft.DraftDocument draftDocument = null;
            SolidEdgeDraft.Sheet sheet = null;
            SolidEdgeDraft.DrawingViews drawingViews = null;
            SolidEdgePart.PartDocument partDocument = null;
            SolidEdgePart.SheetMetalDocument sheetMetalDocument = null;
            SolidEdgePart.EdgebarFeatures edgeBarFeatures = null;

            switch (document.Type)
            {
                case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument:
                    assemblyDocument = (SolidEdgeAssembly.AssemblyDocument)document;
                    asmRefPlanes = assemblyDocument.AsmRefPlanes;

                    for (int i = 1; i <= asmRefPlanes.Count; i++)
                    {
                        assemblyDocument.SelectSet.Add(asmRefPlanes.Item(i));
                    }
                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igDraftDocument:
                    draftDocument = (SolidEdgeDraft.DraftDocument)document;
                    sheet = draftDocument.ActiveSheet;
                    drawingViews = sheet.DrawingViews;

                    for (int i = 1; i <= drawingViews.Count; i++)
                    {
                        draftDocument.SelectSet.Add(drawingViews.Item(i));
                    }

                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igPartDocument:
                    partDocument = (SolidEdgePart.PartDocument)document;
                    edgeBarFeatures = partDocument.DesignEdgebarFeatures;

                    for (int i = 1; i <= edgeBarFeatures.Count; i++)
                    {
                        partDocument.SelectSet.Add(edgeBarFeatures.Item(i));
                    }

                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument:
                    sheetMetalDocument = (SolidEdgePart.SheetMetalDocument)document;
                    edgeBarFeatures = sheetMetalDocument.DesignEdgebarFeatures;

                    for (int i = 1; i <= edgeBarFeatures.Count; i++)
                    {
                        partDocument.SelectSet.Add(edgeBarFeatures.Item(i));
                    }
                    break;
            }
        }

        //static Type GetTypeForComObject(object o)
        //{
        //    if (o == null) throw new ArgumentNullException();

        //    if (Marshal.IsComObject(o))
        //    {
        //        IDispatch dispatch = o as IDispatch;
        //        if (dispatch != null)
        //        {
        //            ITypeLib typeLib = null;
        //            ITypeInfo typeInfo = dispatch.GetTypeInfo(0, 0);
        //            int index = 0;
        //            typeInfo.GetContainingTypeLib(out typeLib, out index);

        //            string typeLibName = Marshal.GetTypeLibName(typeLib);
        //            string typeInfoName = Marshal.GetTypeInfoName(typeInfo);

        //            string typeFullName = String.Format("{0}.{1}", typeLibName, typeInfoName);

        //            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        //            Assembly assembly =  assemblies.FirstOrDefault(x => x.GetType(typeFullName) != null);
        //            if (assembly != null)
        //            {
        //                return assembly.GetType(typeFullName);
        //            }
        //        }
        //    }

        //    return o.GetType();
        //}
    }
}
