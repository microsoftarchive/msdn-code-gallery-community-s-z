using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.Design;

namespace CustomServerControlsLibrary
{

	public class SuperSimpleRepeaterDesigner : ControlDesigner
	{
			
		public override string GetDesignTimeHtml()
		{
			try
			{
				SuperSimpleRepeater2 repeater = (SuperSimpleRepeater2)base.Component;
				if (repeater.ItemTemplate == null)
				{
					return GetEmptyDesignTimeHtml();
				}
				else
				{
					String designTimeHtml = String.Empty;

						((Control)this.Component).DataBind();
						return base.GetDesignTimeHtml();
				}
			}
			catch (Exception e)
			{
				return GetErrorDesignTimeHtml(e);
			}
		}
	
		protected override string GetEmptyDesignTimeHtml() 
		{
			string text = "Switch to design view to add a template to this control.";
			return CreatePlaceHolderDesignTimeHtml(text);
		}

		protected override string GetErrorDesignTimeHtml(Exception e)
		{
			string text = string.Format("{0}{1}{2}{3}", 
				"There was an error and the control can't be displayed.",
				"<BR>", "Exception: ", e.Message);
			return CreatePlaceHolderDesignTimeHtml(text);
		}

	}
}
