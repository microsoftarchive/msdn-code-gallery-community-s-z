using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// So happens the day I published this code sample there was
    /// a forum question on this topic :-)
    /// </summary>
    public partial class ForumQuestion : Form
    {
        public ForumQuestion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load database names, setup change event to populate tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForumQuestion_Load(object sender, EventArgs e)
        {
            var ops = new SmoOperations();
            cboDatabaseNames.DataSource = ops.DatabaseNames();
            cboDatabaseNames.SelectedIndexChanged += CboDatabaseNames_SelectedIndexChanged;
        }
        /// <summary>
        /// Populate tables for database when the ComboBox selection changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboDatabaseNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDatabaseNames.DataSource != null)
            {
                var ops = new SmoOperations();
                lstTableNames.DataSource = ops.TableNames(cboDatabaseNames.Text);
            }
            else
            {
                MessageBox.Show("Please populate the first ListBox with database names");
            }
        }
    }
}
