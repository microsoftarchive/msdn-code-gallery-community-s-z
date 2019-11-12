// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using UiManagerOutlookAddIn.AddinUtilities;

namespace UiManagerOutlookAddIn
{
    [ComVisible(true)]
    [ProgId("UiManager.SimpleControl")]
    [Guid("E2F1F0E8-254A-4ddc-A500-273D6EFB172B")]
    public partial class SimpleControl : UserControl
    {
        public SimpleControl()
        {
            InitializeComponent();
        }

        private const String _mailServiceGroup = "mailServiceGroup";

        private void closeCoffeeList_Click(object sender, EventArgs e)
        {
            // Clear and hide the listbox.
            this._coffeeList.Items.Clear();
            this._coffeeGroup.Visible = false;

            // Make the add-in service ribbon buttons invisible again.
            UserInterfaceContainer uiContainer =
                Globals.ThisAddIn._uiElements.GetUIContainerForUserControl(
                this);
            uiContainer.HideRibbonControl(_mailServiceGroup);
        }
    }
}
