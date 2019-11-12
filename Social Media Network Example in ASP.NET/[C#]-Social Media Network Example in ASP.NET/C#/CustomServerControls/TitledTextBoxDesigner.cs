#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using CustomServerControlsLibrary;

#endregion

namespace CustomServerControlsLibrary
{
    public class TitledTextBoxDesigner : System.Web.UI.Design.ControlDesigner 
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new TitledTextBoxActionList((TitledTextBox)Component));
                }
                return actionLists;
            }
        }
    }
}
