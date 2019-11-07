using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.UnitsOfMeasure
{
    public class InternalExample
    {
        private SolidEdgeFramework.UnitTypeConstants _unitType;
        private SolidEdgeConstants.PrecisionConstants _precision;
        private object _externalValue;
        private double _internalValue = 0.0254;

        public InternalExample()
        {
            _unitType = SolidEdgeFramework.UnitTypeConstants.igUnitDistance;
            _precision = SolidEdgeConstants.PrecisionConstants.igPrecisionThousandths;
            UpdateExternalValue();
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
                UpdateExternalValue();
            }
        }

        public SolidEdgeConstants.PrecisionConstants Precision
        {
            get
            {
                return _precision;
            }
            set
            {
                _precision = value;
                UpdateExternalValue();
            }
        }

        [DescriptionAttribute("Value in user display units.")]
        public object ExternalValue
        {
            get
            {
                return _externalValue;
            }
        }

        [DescriptionAttribute("Value in internal (database) units.")]
        public double InternalValue
        {
            get
            {
                return _internalValue;
            }
            set
            {
                _internalValue = value;
                UpdateExternalValue();
            }
        }

        private void UpdateExternalValue()
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.SolidEdgeDocument document = null;
            SolidEdgeFramework.UnitsOfMeasure unitsOfMeasure = null;

            try
            {
                application = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");
                document = (SolidEdgeFramework.SolidEdgeDocument)application.ActiveDocument;
                unitsOfMeasure = document.UnitsOfMeasure;
                _externalValue = unitsOfMeasure.FormatUnit((int)_unitType, _internalValue, _precision);
            }
            catch (System.Exception ex)
            {
                _externalValue = ex.Message;
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
