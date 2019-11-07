using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SolidEdge.Assembly.BOM
{
    public class InteropProxy : MarshalByRefObject
    {
        public BomItem[] GetBomItems()
        {
            // Dictionary to hold BomItem(s).  Key is the full path to the SolidEdgeDocument.
            Dictionary<string, BomItem> bomItems = new Dictionary<string, BomItem>();

            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;
            SolidEdgeAssembly.AssemblyDocument assemblyDocument = null;

            OleMessageFilter.Register();

            try
            {
                // Attempt to connect to a running instance of Solid Edge.
                application = SolidEdgeUtils.Connect();
                
                // Get a reference to the Documents collection.
                documents = application.Documents;

                // Make sure a document is open and that it's an AssemblyDocument.
                if ((documents.Count > 0) && (application.ActiveDocumentType == SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument))
                {
                    // Get a reference to the AssemblyDocument.
                    assemblyDocument = (SolidEdgeAssembly.AssemblyDocument)application.ActiveDocument;

                    // Start walking the assembly tree.
                    ProcessAssembly(0, assemblyDocument, bomItems);
                }
                else
                {
                    throw new System.Exception("No assembly open.");
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.ErrorCode == -2147221021 /* MK_E_UNAVAILABLE */)
                {
                    throw new System.Exception("Solid Edge is not running.");
                }
                else
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return bomItems.Values.ToArray();
        }

        private void ProcessAssembly(int level, SolidEdgeAssembly.AssemblyDocument assemblyDocument, Dictionary<string, BomItem> bomItems)
        {
            // Increment level (depth).
            level++;

            // Loop through the Occurrences.
            foreach (SolidEdgeAssembly.Occurrence occurrence in assemblyDocument.Occurrences)
            {
                // Filter out certain occurrences.
                if (!occurrence.IncludeInBom) { continue; }
                if (occurrence.IsPatternItem) { continue; }
                if (occurrence.OccurrenceDocument == null) { continue; }

                // Get a reference to the SolidEdgeDocument.
                SolidEdgeFramework.SolidEdgeDocument document = (SolidEdgeFramework.SolidEdgeDocument)occurrence.OccurrenceDocument;

                // Add the BomItem.
                AddBomItem(level, document, bomItems);

                if (occurrence.Subassembly)
                {
                    // Sub Assembly. Recurisve call to drill down.
                    ProcessAssembly(level, (SolidEdgeAssembly.AssemblyDocument)occurrence.OccurrenceDocument, bomItems);
                }
            }
        }

        private void AddBomItem(int level, SolidEdgeFramework.SolidEdgeDocument document, Dictionary<string, BomItem> bomItems)
        {
            BomItem bomItem = new BomItem(document.FullName);
            SolidEdgeFramework.SummaryInfo summaryInfo = null;

            if (!bomItems.ContainsKey(document.FullName))
            {
                summaryInfo = (SolidEdgeFramework.SummaryInfo)document.SummaryInfo;
                bomItem.Level = level;
                bomItem.DocumentNumber = summaryInfo.DocumentNumber;
                bomItem.Title = summaryInfo.Title;
                bomItem.Revision = summaryInfo.RevisionNumber;
                bomItem.IsSubassembly = document.Type == SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument;
                bomItems.Add(bomItem.FullName, bomItem);
            }
            else
            {
                bomItems[bomItem.FullName].Quantity++;
            }
        }
    }
}