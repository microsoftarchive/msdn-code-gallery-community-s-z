using System.Windows.Forms;
using ComponentPro.IO;

namespace ArchiveManager
{
    public partial class SynchronizeFolders : Form
    {
        public SynchronizeFolders()
        {
            InitializeComponent();
        }

        public SynchronizeFolders(RecursionMode recursive, bool syncDateTime, bool syncAttributes, int comparisonMethod, bool checkForResumability, string searchPattern, string sourceDir)
        {
            InitializeComponent();

            chkRecursive.Checked = recursive == RecursionMode.RecurseIntoAllSubFolders;
            chkUpdateTime.Checked = syncDateTime;
            chkUpdateAttributes.Checked = syncAttributes;
            cbxComparisonType.SelectedIndex = comparisonMethod;
            chkResumability.Checked = checkForResumability;
            txtSearchPattern.Text = searchPattern;
            txtSourceDir.Text = sourceDir;
        }

        public RecursionMode Recursive
        {
            get { return chkRecursive.Checked ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None; }
        }

        public bool SyncDateTime
        {
            get { return chkUpdateTime.Checked; }
        }

        public bool SyncAttributes
        {
            get { return chkUpdateAttributes.Checked; }
        }

        public int ComparisonMethod
        {
            get { return cbxComparisonType.SelectedIndex; }
        }

        public string SearchPattern
        {
            get { return txtSearchPattern.Text; }
        }

        public string SourceDir
        {
            get { return txtSourceDir.Text; }
        }

        public bool CheckForResumability
        {
            get { return chkResumability.Checked; }
        }

        public bool DeleteFiles
        {
            get { return chkDeleteFiles.Checked; }
        }

        private void cbxComparisonType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            chkResumability.Visible = cbxComparisonType.SelectedIndex == 1;
        }

        private void btnSourceDir_Click(object sender, System.EventArgs e)
        {
            try
            {
                FolderBrowserDialog dlg = new FolderBrowserDialog();
                dlg.Description = "Select local folder";
                dlg.SelectedPath = txtSourceDir.Text;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSourceDir.Text = dlg.SelectedPath;
                }
            }
            catch (System.Exception exc)
            {
                Util.ShowError(exc);
            }
        }
    }
}