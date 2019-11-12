using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Tools;

namespace TablesAndCharts
{
    public partial class ThisAddIn
    {
        TableAndChartPane _tableAndChartPane;
        CustomTaskPane _taskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _tableAndChartPane = new TableAndChartPane();
            _taskPane = this.CustomTaskPanes.Add(_tableAndChartPane, "Tables and Charts");
            _taskPane.Visible = true;
            _taskPane.Width = 250;
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
