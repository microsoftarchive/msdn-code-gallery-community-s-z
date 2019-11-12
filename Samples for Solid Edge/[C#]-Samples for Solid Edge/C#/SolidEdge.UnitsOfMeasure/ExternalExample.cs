using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.UnitsOfMeasure
{
    public class ExternalExample
    {
        private SolidEdgeFramework.UnitTypeConstants _unitType;
        private string _externalValue = "1 in";
        private object _internalValue;

        public ExternalExample()
        {
            _unitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance;
            UpdateInternalValue();
        }

        public SolidEdgeFramework.UnitTypeConstants UnitType
        {
            get
            {
                return _unitType;
            }
            set
            {
                _unitType = value;
                UpdateInternalValue();
            }
        }

        [DescriptionAttribute("Value in user display units.")]
        public string ExternalValue
        {
            get
            {
                return _externalValue;
            }
            set
            {
                _externalValue = value;
                UpdateInternalValue();
            }
        }

        [DescriptionAttribute("Value in internal (database) units.")]
        public object InternalValue
        {
            get
            {
                return _internalValue;
            }
        }

        private void UpdateInternalValue()
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.UnitsOfMeasure unitsOfMeasure = null;

            try
            {
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;
                unitsOfMeasure = document.UnitsOfMeasure;
                _internalValue = unitsOfMeasure.ParseUnit((int)_unitType, _externalValue);
            }
            catch (System.Exception ex)
            {
                _internalValue = ex.Message;
            }
            finally
            {
                if (unitsOfMeasure != null) Marshal.ReleaseComObject(unitsOfMeasure);
                if (document != null) Marshal.ReleaseComObject(document);
                if (application != null) Marshal.ReleaseComObject(application);
            }
        }
    }
}
