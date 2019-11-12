#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using CustomServerControlsLibrary;

#endregion

namespace CustomServerControlsLibrary
{
    public class TitledTextBoxActionList : System.ComponentModel.Design.DesignerActionList
    {
        private TitledTextBox linkedControl;

        // The constructor associates the control to the smart tag action list. 
        public TitledTextBoxActionList(TitledTextBox ctrl) : base(ctrl)
        {
            linkedControl = ctrl;
        }


        // A helper method to retrieve control properties.
        // GetProperties ensures undo and menu updates to work properly. 

        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(linkedControl)[propName];

            if (null == prop)
            {
                throw new ArgumentException(
                "Matching property not found.", propName);
            }
            else
            {
                return prop;
            }
        }


        // Properties that are targets of DesignerActionPropertyItem 
        // entries. 
		public string Text
		{
			get { return linkedControl.Text; }
			set { GetPropertyByName("Text").SetValue(linkedControl, value);	}
		}

		public string Title
		{
			get { return linkedControl.Title; }
			set { GetPropertyByName("Title").SetValue(linkedControl, value); }
		}

		public Color BackColor
		{
			get { return linkedControl.BackColor; }
			set { GetPropertyByName("BackColor").SetValue(linkedControl, value);
			
			}
		}
				
        // Method that is target of a DesignerActionMethodItem 
        public void LaunchSite()
        {
            try
			{
				System.Diagnostics.Process.Start("http://www.prosetech.com");
			}
			catch { }
                       
        }



        // Implementation of this abstract method creates smart tag 
        // items, associates their targets, and collects into list. 
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create 8 items.
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            // Begin by creating the headers.
            items.Add(new DesignerActionHeaderItem("Appearance"));
            items.Add(new DesignerActionHeaderItem("Information"));

            // Add items that wrap the properties.
            items.Add(new DesignerActionPropertyItem("Title",
                "TextBox Title", "Appearance",
				"The heading for this control."));

            items.Add(new DesignerActionPropertyItem("Text",
              "TextBox Text", "Appearance",
			  "The content in the TextBox."));

			items.Add(new DesignerActionPropertyItem("BackColor",
	   "Background Color", "Appearance",
	   "The color shown behind the control as a background."));

            // Add an action link. 
            // This item is also added to the context menu 
            // as a designer verb. 
            items.Add(new DesignerActionMethodItem(this,
                "LaunchSite", "See website information",
                "Information",
                "Opens a web browser with the company site.",
                true));

            // Create entries for static Information section. 
            items.Add(new DesignerActionTextItem(
                "ID: " + linkedControl.ID,
              "ID"));
			
            return items;

        }


    }

}
