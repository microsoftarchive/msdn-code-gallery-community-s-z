using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Net;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Security;
using System.Xml;
using System.Globalization;

namespace Sample.ReportingServices.Security {
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class UILogon : System.Web.UI.Page {

		private void Page_Load(object sender, System.EventArgs e) {

			ValidationManager mgr = new ValidationManager();
			if ( mgr.ValidateUserInfo( Request.Headers ) ) {
				ReportServerProxy server = new ReportServerProxy();

				string reportServer = ConfigurationManager.AppSettings["ReportServer"];
				string instanceName = ConfigurationManager.AppSettings["ReportServerInstance"];

				// Get the server URL from the report server using WMI
				server.Url = ValidationManager.GetReportServerUrl( reportServer, instanceName );

				server.LogonUser( mgr.ValidatedUserToken, Request.Headers["AuthToken"], null );
				string redirectUrl = Request.QueryString["ReturnUrl"];
				if ( redirectUrl != null ) {
					HttpContext.Current.Response.Redirect( redirectUrl, false );
				} else {
					HttpContext.Current.Response.Redirect( "./Folder.aspx", false );
				}

			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e) {
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit( e );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			//this.BtnLogon.Click += new System.EventHandler(this.BtnLogon_Click);
			//this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
			this.Load += new System.EventHandler( this.Page_Load );

		}
		#endregion
	}
}