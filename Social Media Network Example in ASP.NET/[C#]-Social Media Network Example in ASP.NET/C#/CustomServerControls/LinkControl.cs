using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CustomServerControlsLibrary
{
	public class LinkControl : Control
	{
		protected override void Render(HtmlTextWriter output)
		{
			// Specify the URL for the upcoming anchor tag.
			output.AddAttribute(HtmlTextWriterAttribute.Href,
			  "http://www.apress.com");

			// Add the style attributes.
			output.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "20");
			output.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue");

			// Create the anchor tag.
			output.RenderBeginTag(HtmlTextWriterTag.A);

			// Write the text inside the tag.
			output.Write("Click to visit Apress");

			// Close the tag.
			output.RenderEndTag();

			// (At this point, you could continue writing more tags and attributes.)
		}
	}
}

