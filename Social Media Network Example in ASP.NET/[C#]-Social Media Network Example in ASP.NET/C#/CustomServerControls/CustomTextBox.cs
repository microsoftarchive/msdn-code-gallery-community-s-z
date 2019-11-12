using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;

namespace CustomServerControlsLibrary
{
    [ToolboxBitmap(typeof(CustomTextBox), "CustomTextBox1.bmp")]
    //[ToolboxBitmap(typeof(System.Web.UI.WebControls.TextBox))]
    [ToolboxData("<{0}:CustomTextBox ID=CustomTextBox1 Text=\"[Empty]\" runat=server />")]
	public class CustomTextBox : WebControl, IPostBackDataHandler
	{
		protected override void OnInit(EventArgs e)
		{
			Page.RegisterRequiresPostBack(this);
		}
		public CustomTextBox() : base(HtmlTextWriterTag.Input)
		{
			Text = "";
		}

		public string Text
		{
			get {return (string)ViewState["Text"];}
			set {ViewState["Text"] = value;}
		}
  
		protected override void AddAttributesToRender(HtmlTextWriter output)
		{
			output.AddAttribute("name", this.UniqueID);
			output.AddAttribute(HtmlTextWriterAttribute.Type, "text");
			output.AddAttribute(HtmlTextWriterAttribute.Value, Text);
			base.AddAttributesToRender(output);
		}

		// The method of IPostBackDataHandler that gets called to allow you 
		// to review the data posted to the page.
		public bool LoadPostData(string postDataKey, NameValueCollection postData)
		{
			// Get the value posted and the past value.
			string postedValue = postData[postDataKey];
			string val = Text;

			// If the value changed, then reset the value of the text property
			// and return true so the RaisePostDataChangedEvent will be fired.
			if (val != postedValue)
			{
				Text = postedValue;
				return true;
			}
			else
			{
				return false;
			}
		}

		// Called if the LoadPostData() method returns true.
		public void RaisePostDataChangedEvent()
		{
			// Call the method to raise the change event.
			OnTextChanged(new EventArgs());
		}
 
		public event EventHandler TextChanged;

		protected virtual void OnTextChanged(EventArgs e)
		{
			// Check for at least one listener and then raise the event.
			if (TextChanged != null)
				TextChanged(this, e);
		}

	}
}

