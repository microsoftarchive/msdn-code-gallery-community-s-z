using System.Windows;
using System.Windows.Controls.Primitives;
namespace WPFReportTest
{
    public partial class ReportViewerUI : Window
    {
        public ReportViewerUI()
        {
            InitializeComponent();
            var sidepanel = crystalReportsViewer.FindName("btnToggleSidePanel") as ToggleButton;
            if (sidepanel != null)
            {
                crystalReportsViewer.ViewChange += (x, y) => sidepanel.IsChecked = false;
            }
        }
        public void setReportSource(CrystalDecisions.CrystalReports.Engine.ReportDocument aReport)
        {
            this.crystalReportsViewer.ViewerCore.ReportSource = aReport;
        }
    }
}
