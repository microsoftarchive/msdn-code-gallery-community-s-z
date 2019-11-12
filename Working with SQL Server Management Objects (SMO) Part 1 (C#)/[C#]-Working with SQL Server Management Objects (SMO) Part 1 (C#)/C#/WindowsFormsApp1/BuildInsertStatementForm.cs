using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BuildInsertStatementForm : Form
    {
        SmoOperations sOps = new SmoOperations();
        public BuildInsertStatementForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Populate ComboBox with database names.
        /// Setup events for selected index changed for database ComboBox,
        /// ListBox Table names.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// The code in regards to NorthWindAzure, I have this database
        /// and use it for testing hence automate the selection of this
        /// database followed by the Orders table. This in turn triggers
        /// the column CheckedListBox to populate.
        /// </remarks>
        private void BuildInsertStatementForm_Load(object sender, EventArgs e)
        {
            // populate with a list of strings representing database names
            cboDatabaseNames.DataSource = sOps.DatabaseNames();

            cboDatabaseNames.SelectedIndexChanged += cboDatabaseNames_SelectedIndexChanged;
            lstTableNames.SelectedIndexChanged += LstTableNames_SelectedIndexChanged;

            var Index = cboDatabaseNames.FindString("NorthWindAzure");

            if (Index > -1)
            {
                cboDatabaseNames.SelectedIndex = Index;
                Index = lstTableNames.FindString("Orders");
                if (Index > -1)
                {
                    lstTableNames.SelectedIndex = Index;
                }

            }
            else
            {
                cboDatabaseNames.SelectedIndex = -1;
            }
            
        }
        /// <summary>
        /// Populate CheckedListBox with column details for the currently
        /// selected table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbColumnNames.DataSource = null;
            var details = sOps.GetColumnDetails(cboDatabaseNames.Text, lstTableNames.Text);
            clbColumnNames.DataSource = details;
        }
        /// <summary>
        /// When the database ComboBox selection changes, populate the ListBox with
        /// table names within the selected database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDatabaseNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDatabaseNames.DataSource != null)
            {               
                lstTableNames.DataSource = sOps.TableNames(cboDatabaseNames.Text);                
            }
            else
            {
                MessageBox.Show("Please populate the first ListBox with database names");
            }
        }
        /// <summary>
        /// Produce a INSERT statement for the selected table and column names but
        /// exclude a column marked as Identity which is commonly a auto-incrementing
        /// field. Note the ending select which returns the new primary key via
        /// ExecuteScalar e.g. int id = Convert.ToInt32(cmd.ExecuteScalar());
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateInsertStatement_Click(object sender, EventArgs e)
        {
            var columnList = clbColumnNames.CheckedIColumnDetailsList();
            var fields = "";

            if (columnList.Count >0)
            {
                var fieldList = columnList.Where(col => !col.Identity).ToList();
                if (fieldList.Count >0)
                {
                    if (chkWrapColumnsWithBrackets.Checked)
                    {
                        fields = string.Join(",", fieldList.Select(col => $"[{col.Name}]").ToArray());
                    }
                    else
                    {
                        fields = string.Join(",", fieldList.Select(col => $"{col.Name}").ToArray());
                    }
                    
                    var Parms = string.Join(",", fieldList.Select(col => $"@{col.Name}").ToArray());
                    var sqlStatement = $"\"INSERT INTO {lstTableNames.Text} ({fields}) VALUES ({Parms}); SELECT CAST(scope_identity() AS int);\"";
                    txtSqlStatement.Text = sqlStatement;
                }
            }
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < clbColumnNames.Items.Count; index++)
            {
                clbColumnNames.SetItemChecked(index, chkToggleColumnsChecked.Checked);
            }
        }

        private void cmdCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (txtSqlStatement.Text.Length >0)
            {
                Clipboard.SetText(txtSqlStatement.Text);
            }
        }
    }
}
