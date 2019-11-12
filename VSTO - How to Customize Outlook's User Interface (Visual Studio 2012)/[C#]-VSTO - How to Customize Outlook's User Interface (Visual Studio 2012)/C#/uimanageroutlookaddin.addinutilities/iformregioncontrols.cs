// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace UiManagerOutlookAddIn.AddinUtilities
{
    // This interface is not CLS compliant because of its Office property.
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("53ED8FA5-DBAD-40c4-8068-F20E7858DEB6")]
    [CLSCompliant(false)]
    public interface IFormRegionControls
    {
        Outlook.Inspector Inspector
        {
            get;
            set;
        }

        void SetControlText(String controlName, String text);
    }
}
