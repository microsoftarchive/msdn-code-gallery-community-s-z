using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLoadDatabaseNames_Click(object sender, EventArgs e)
        {
            var ops = new SmoOperations();
            lstDatabaseNames.DataSource = ops.DatabaseNames();
        }
        /// <summary>
        /// Here for testing that all works I load all ListBoxes
        /// with know database, table and columns in one shot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSpecialLoader_Click(object sender, EventArgs e)
        {
            var ops = new SmoOperations();
            lstDatabaseNames.DataSource = ops.DatabaseNames();
            var Index = lstDatabaseNames.FindString("NorthWindAzure");

            if (Index > -1)
            {
                lstDatabaseNames.SelectedIndex = Index;
                lstTableNames.DataSource = ops.TableNames(lstDatabaseNames.Text);
                Index = lstTableNames.FindString("Orders");
                if (Index > -1)
                {
                    lstTableNames.SelectedIndex = Index;
                    lstColumnNames.DataSource = ops.TableColumnNames(lstDatabaseNames.Text, lstTableNames.Text);
                    currentTableColumDetails = ops.GetColumnDetails(lstDatabaseNames.Text, lstTableNames.Text);
                }

            }
        }
        private void cmdLoadTableNamesForSelectedDatabaseName_Click(object sender, EventArgs e)
        {
            if (lstDatabaseNames.DataSource != null)
            {
                var ops = new SmoOperations();
                lstTableNames.DataSource = ops.TableNames(lstDatabaseNames.Text);
            }
            else
            {
                MessageBox.Show("Please populate the first ListBox with database names");
            }
        }
        private List<ColumnDetails> currentTableColumDetails;
        private void cmdLoadColumnNamesForSelectedTable_Click(object sender, EventArgs e)
        {
            currentTableColumDetails = null;

            if (lstTableNames.DataSource != null)
            {
                var ops = new SmoOperations();
                lstColumnNames.DataSource = ops.TableColumnNames(lstDatabaseNames.Text, lstTableNames.Text);
                currentTableColumDetails = ops.GetColumnDetails(lstDatabaseNames.Text, lstTableNames.Text);
            }
            else
            {
                MessageBox.Show("Please populate the second ListBox with table names");
            }
        }
        private void cmdColumnDetails_Click(object sender, EventArgs e)
        {
            if (currentTableColumDetails != null)
            {
                var result = currentTableColumDetails.FirstOrDefault(item => item.Name == lstColumnNames.Text);
                if (result != null)
                {
                    propertyGrid1.SelectedObject = result;
                }
            }

        }

        private void cmdGetForeignDetails_Click(object sender, EventArgs e)
        {
            var ops = new SmoOperations();
            var keyList = ops.TableKeys(lstDatabaseNames.Text, lstTableNames.Text);
            if (keyList.Count >0)
            {
                var results = string.Join(Environment.NewLine, keyList.Select(k => k.SchemaName).ToArray());
                MessageBox.Show(results);
            }
            else
            {
                MessageBox.Show("Nothing to show");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
