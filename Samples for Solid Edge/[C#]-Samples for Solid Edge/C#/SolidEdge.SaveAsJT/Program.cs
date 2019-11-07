using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.SaveAsJT
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.SolidEdgeDocument solidEdgeDocument = null;

            try
            {
                Console.WriteLine("Registering OleMessageFilter.");

                // Register with OLE to handle concurrency issues on the current thread.
                OleMessageFilter.Register();

                Console.WriteLine("Connecting to Solid Edge.");

                // Connect to Solid Edge.
                application = SolidEdgeUtils.Connect();

                if (application != null)
                {
                    // Get a reference to the documents collection.
                    solidEdgeDocument = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;

                    Console.WriteLine("Determining document type.");

                    switch (solidEdgeDocument.Type)
                    {
                        case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument:
                        case SolidEdgeFramework.DocumentTypeConstants.igPartDocument:
                        case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument:
                        case SolidEdgeFramework.DocumentTypeConstants.igWeldmentAssemblyDocument:
                        case SolidEdgeFramework.DocumentTypeConstants.igWeldmentDocument:
                            SaveAsJT(solidEdgeDocument);
                            break;
                        default:
                            Console.WriteLine("'{0}' cannot be converted to JT.", solidEdgeDocument.Type);
                            break;
                    }
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


        static void SaveAsJT(SolidEdgeFramework.SolidEdgeDocument solidEdgeDocument)
        {
            // Note: Some of the parameters are obvious by their name but we need to work on getting better descriptions for some.
            var NewName = Path.ChangeExtension(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), solidEdgeDocument.Name), ".jt");
            var Include_PreciseGeom = 0;
            var Prod_Structure_Option = 1;
            var Export_PMI = 0;
            var Export_CoordinateSystem = 0;
            var Export_3DBodies = 0;
            var NumberofLODs = 1;
            var JTFileUnit = 0;
            var Write_Which_Files = 1;
            var Use_Simplified_TopAsm = 0;
            var Use_Simplified_SubAsm = 0;
            var Use_Simplified_Part = 0;
            var EnableDefaultOutputPath = 0;
            var IncludeSEProperties = 0;
            var Export_VisiblePartsOnly = 0;
            var Export_VisibleConstructionsOnly = 0;
            var RemoveUnsafeCharacters = 0;
            var ExportSEPartFileAsSingleJTFile = 0;

            Console.WriteLine("Saving '{0}'", NewName);

            solidEdgeDocument.SaveAsJT(
                NewName,
                Include_PreciseGeom,
                Prod_Structure_Option,
                Export_PMI,
                Export_CoordinateSystem,
                Export_3DBodies,
                NumberofLODs,
                JTFileUnit,
                Write_Which_Files,
                Use_Simplified_TopAsm,
                Use_Simplified_SubAsm,
                Use_Simplified_Part,
                EnableDefaultOutputPath,
                IncludeSEProperties,
                Export_VisiblePartsOnly,
                Export_VisibleConstructionsOnly,
                RemoveUnsafeCharacters,
                ExportSEPartFileAsSingleJTFile);
        }
    }
}
