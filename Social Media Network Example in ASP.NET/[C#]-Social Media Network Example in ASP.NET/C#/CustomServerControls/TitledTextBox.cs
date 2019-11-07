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
	[Designer(typeof(TitledTextBoxDesigner))]
	public class TitledTextBox : CompositeControl
	{
		public TitledTextBox() : base()
		{
			Title = "";
			Text = "";
		}

		// Track the constituent controls with member variables
		// so they are accessible in all methods.
		protected Label label;
		protected TextBox textBox;
		
		public string Title
		{
			get {return (string)ViewState["Title"];}
			set {ViewState["Title"] = value;
                if (this.ChildControlsCreated) this.RecreateChildControls();
            }
		}

		public string Text
		{
			get {return (string)ViewState["Text"];}
			set {ViewState["Text"] = value;
                if (this.ChildControlsCreated) this.RecreateChildControls();
            }
		}

		protected override void CreateChildControls()
		{
			// Add the label.
			label = new Label();
			label.EnableViewState = false;
			label.Text = Title;
			Controls.Add(label);

			// Add a space.
			Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

			// Add the text box.
			textBox = new TextBox();
			textBox.EnableViewState = false;
			textBox.Text = Text;
			textBox.TextChanged += new EventHandler(OnTextChanged);
			Controls.Add(textBox);
		}

		public event EventHandler TextChanged;
		
		protected virtual void OnTextChanged(object sender, EventArgs e)
		{
			if (TextChanged != null)
				TextChanged(this, e);
		}
	}
}
