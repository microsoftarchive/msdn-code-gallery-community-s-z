// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office;

namespace UiManagerOutlookAddIn
{
    public class TaskPaneConnector : Office.Core.ICustomTaskPaneConsumer
    {
        private Office.Core.ICTPFactory _ctpFactory;

        internal Microsoft.Office.Core.CustomTaskPane CreateTaskPane(string id, string title, object parentWindow)
        {
            if (_ctpFactory != null)
                return _ctpFactory.CreateCTP(id, title, parentWindow);

            return null;
        }
        
        
        // This method is not CLSCompliant because of its Office parameter.
        [CLSCompliant(false)]
        public void CTPFactoryAvailable(
            Office.Core.ICTPFactory CTPFactoryInst)
        {
            // All we need do here is to cache the CTPFactory object, 
            // so that we can create custom taskpanes later on.
            _ctpFactory = CTPFactoryInst;
        }
    }
}
