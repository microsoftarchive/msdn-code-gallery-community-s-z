using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class BindXMLData : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the XML document
			string fileNameString = this.MapPath(".");
			string fileNameSchema = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\data.xml";
			fileNameSchema += "..\\..\\..\\..\\data\\data.xsd";

			// Initializes a new instance of the DataSet class
			DataSet custDS = new DataSet();
		
			// Reads an XML schema into the DataSet.
			custDS.ReadXmlSchema( fileNameSchema );

			// Reads XML schema and data into the DataSet.
			custDS.ReadXml( fileNameString );
			
			// Initializes a new instance of the DataView class
			DataView firstView = new DataView(custDS.Tables[0]);

			// since the DataView implements and IEnumerable, pass the reader directly into
			// the DataBind method with the name of the Columns selected in the query	
			Chart1.Series["Default"].Points.DataBindXY(firstView, "Name",firstView, "Sales");
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		
	}
}
