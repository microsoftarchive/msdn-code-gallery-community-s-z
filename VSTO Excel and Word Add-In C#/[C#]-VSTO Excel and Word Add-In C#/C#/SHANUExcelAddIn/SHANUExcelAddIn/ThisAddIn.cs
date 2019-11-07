using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Data.SqlClient;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-02-23
/// Description :Excel AddIn Control
/// Latest
/// Modifier    :Shanu
/// Modify date :  2015-02-23
/// </summary>
namespace SHANUExcelAddIn
{
    public partial class ThisAddIn
    {
        private Microsoft.Office.Tools.CustomTaskPane customPane;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ShowShanuControl();
        }
        public void ShowShanuControl()
        {
            var txtObject = new ShanuExcelADDIn();
            customPane = this.CustomTaskPanes.Add(txtObject, "Enter Text");
            customPane.Width = txtObject.Width;
            customPane.Visible = true;
        }

     
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
