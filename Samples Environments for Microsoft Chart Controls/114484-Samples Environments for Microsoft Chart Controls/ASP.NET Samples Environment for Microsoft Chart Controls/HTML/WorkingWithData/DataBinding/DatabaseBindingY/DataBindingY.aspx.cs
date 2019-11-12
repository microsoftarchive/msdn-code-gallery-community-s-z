using System;
using System.Data.OleDb;
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
	public partial class DataBindingY : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += "..\\..\\..\\..\\data\\chartdata.mdb";

			// initialize a connection string	
			string myConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			
			// define the database query	
			string mySelectQuery="SELECT GrossSales FROM SALES WHERE QuarterEnding < #01/01/2002#;";

			// create a database connection object using the connection string	
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			
			// create a database command on the connection using query	
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
			
			// open the connection	
			myCommand.Connection.Open();
			
			// create a database reader	
			OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
			// since the reader implements and IEnumerable, pass the reader directly into
			// the DataBind method with the name of the Column selected in the query	
			Chart1.Series["Default"].Points.DataBindY(myReader, "GrossSales");

			// close the reader and the connection
			myReader.Close();
			myConnection.Close();

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
