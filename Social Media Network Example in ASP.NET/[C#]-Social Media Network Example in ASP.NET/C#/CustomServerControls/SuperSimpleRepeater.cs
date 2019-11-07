using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.Design;
using System.ComponentModel.Design;

namespace CustomServerControlsLibrary
{
	public class SuperSimpleRepeater : WebControl, INamingContainer
	{
		public SuperSimpleRepeater() : base()
		{
			RepeatCount = 1;
		}

		public int RepeatCount
		{
			get {return (int)ViewState["RepeatCount"];}
			set {ViewState["RepeatCount"] = value;}
		}

		private ITemplate itemTemplate;

		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ITemplate ItemTemplate
		{
			get {return itemTemplate;}
			set {itemTemplate=value;}
		}

		protected override void CreateChildControls() 
		{
			//clear out the control colletion if there
			//are any children we want to wipe them out 
			//before starting
			Controls.Clear();
				
			//as long as we are repeating at least once
			//and the template is defined, then loop and 
			//instantiate the template in a panel
			if ((RepeatCount > 0) && (itemTemplate!=null))
			{
				for(int i = 0; i<RepeatCount;i++)
				{
					Panel container = new Panel();
					itemTemplate.InstantiateIn(container);
					Controls.Add(container);
				}
			}
			else		//otherwise we output a message
			{
				Controls.Add(new LiteralControl("Specify the record count and an item template"));
			}
		}


	}

}
