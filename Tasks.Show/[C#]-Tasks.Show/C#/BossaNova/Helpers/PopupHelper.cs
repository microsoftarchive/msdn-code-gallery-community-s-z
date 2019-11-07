using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace Tasks.Show.Helpers
{
    public class PopupHelper
    {
        public static CustomPopupPlacementCallback SimplePlacementCallback
        {
            get { return GetSimplePlacement; }
        }

        public static CustomPopupPlacement[] GetSimplePlacement(Size popupSize, Size targetSize, Point offset)
        {
            return new CustomPopupPlacement[] 
            { 
                new CustomPopupPlacement(){ Point=new Point(0,0), PrimaryAxis = PopupPrimaryAxis.None } 
            };
        }
    }
}
