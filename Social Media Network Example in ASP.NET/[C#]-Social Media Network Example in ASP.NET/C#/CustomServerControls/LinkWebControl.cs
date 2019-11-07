using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CustomServerControlsLibrary
{
	public class LinkWebControl : WebControl
	{  
		public LinkWebControl() : base (HtmlTextWriterTag.A)
		{

		}

		public string Text
		{
			get
			{
				return (string)ViewState["Text"];
			}

			set
			{
				ViewState["Text"] = value;
			}
		}
    
		public string HyperLink
		{
			get
			{
				return (string)ViewState["HyperLink"];
			}
			set
			{
				if (value.IndexOf("http://") == -1)
				{  
					throw new ApplicationException("Specify HTTP as the protocol.");
				}
				else
				{
					ViewState["HyperLink"] = value;
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			Page.RegisterRequiresViewStateEncryption();
			base.OnInit(e);
			if (ViewState["HyperLink"] == null)
			{
				ViewState["HyperLink"] = "http://www.google.com";
			}

			if (ViewState["Text"] == null)
			{
				ViewState["Text"] = "Click to search";
			}
		}
	
		protected override void AddAttributesToRender(HtmlTextWriter output)
		{
			output.AddAttribute(HtmlTextWriterAttribute.Href, HyperLink);
			base.AddAttributesToRender(output);
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			output.Write(Text);
			base.RenderContents(output);  // Calls RenderChildren()
		}
	}

}
