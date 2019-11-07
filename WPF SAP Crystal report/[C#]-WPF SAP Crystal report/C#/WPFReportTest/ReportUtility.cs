using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using CrystalDecisions.CrystalReports.Engine;
namespace WPFReportTest
{
   public class ReportUtility
    {
        public static void Display_report(ReportClass rc, object objDataSource, Window parentWindow)
        {
            try
            {
                rc.SetDataSource(objDataSource);
                ReportViewerUI Viewer = new ReportViewerUI();
                Viewer.setReportSource(rc);
                Viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
