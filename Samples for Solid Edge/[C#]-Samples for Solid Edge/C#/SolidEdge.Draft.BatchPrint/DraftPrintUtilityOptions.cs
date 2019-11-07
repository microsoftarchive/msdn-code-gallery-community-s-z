using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SolidEdge.Draft.BatchPrint
{
    public class DraftPrintUtilityOptions : MarshalByRefObject, ICloneable
    {
        public DraftPrintUtilityOptions(SolidEdgeFramework.Application application)
            : this((SolidEdgeDraft.DraftPrintUtility)application.GetDraftPrintUtility())
        {
        }

        public DraftPrintUtilityOptions(SolidEdgeDraft.DraftPrintUtility draftPrintUtility)
        {
            Type thatType = typeof(SolidEdgeDraft.DraftPrintUtility);
            Type thisType = this.GetType();
            PropertyInfo[] properties = thatType.GetProperties().Where(x => x.CanWrite).ToArray();

            // Copy all of the properties from DraftPrintUtility to this object.
            foreach (PropertyInfo property in properties)
            {
                object val = thatType.InvokeMember(property.Name, BindingFlags.GetProperty, null, draftPrintUtility, null);

                PropertyInfo thisProperty = thisType.GetProperty(property.Name);
                if (thisProperty != null)
                {
                    thisProperty.SetValue(this, val, null);
                }
            }
        }

        public bool AutoOrient { get; set; }
        public bool BestFit { get; set; }
        public bool Center { get; set; }
        public short Copies { get; set; }
        public bool DisplayCutLine { get; set; }
        public bool DisplaySheetBoundary { get; set; }
        public double Gap { get; set; }
        public double MultipleSheetScale { get; set; }
        public SolidEdgeDraft.DraftPrintOrientationConstants Orientation { get; set; }
        public double PaperHeight { get; set; }
        public SolidEdgeDraft.DraftPrintPaperSizeConstants PaperSize { get; set; }
        public double PaperWidth { get; set; }
        public bool PrintAsBlack { get; set; }
        public string Printer { get; set; }
        public bool PrintToFile { get; set; }
        public string PrintToFileName { get; set; }
        public string PrintToFilePath { get; set; }
        public bool ScaleLineTypes { get; set; }
        public bool ScaleLineWidths { get; set; }
        public SolidEdgeDraft.DraftPrintScaleTooLargeActionConstants ScaleTooLarge { get; set; }
        public SolidEdgeDraft.DraftPrintSheetsPerPageConstants SheetsPerPage { get; set; }
        public double SingleSheetScale { get; set; }
        public SolidEdgeDraft.DraftPrintUnitsConstants Units { get; set; }
        public bool UsePrinterClipping { get; set; }
        public bool UsePrinterMargins { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
