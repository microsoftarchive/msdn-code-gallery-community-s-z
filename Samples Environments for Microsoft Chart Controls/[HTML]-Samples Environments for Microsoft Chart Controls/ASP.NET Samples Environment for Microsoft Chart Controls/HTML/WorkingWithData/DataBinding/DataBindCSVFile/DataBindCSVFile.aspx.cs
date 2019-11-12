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
using System.Data.OleDb;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapCustom.
	/// </summary>
	public partial class DataBindCSVFile : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			string file = "DataFile.csv";

			string path = this.MapPath(".");
			path += "..\\..\\..\\..\\data\\";

			try
			{

				if(System.IO.File.Exists(path + file))
				{

					// Create a select statement and a connection string.
					string mySelectQuery = "Select * from "+ file;
					string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ 
						path+ ";Extended Properties=\"Text;HDR=No;FMT=Delimited\"";
					
					OleDbConnection myConnection = new OleDbConnection(ConStr);

					// create a database command on the connection using query
					OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);

					// open the connection
					myCommand.Connection.Open();
					// create a database reader
					OleDbDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

					try
					{
						// column 1 is a time value, column 2 is a double
						// databind the reader to the chart using the DataBindXY method
						Chart1.Series[0].Points.DataBindXY(myReader, myReader.GetName(1), myReader, myReader.GetName(2));
							
					}
					catch(Exception  )
					{
					}

					myReader.Close();
					myConnection.Close();

				}

			}
			catch (Exception )
			{
			}

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
