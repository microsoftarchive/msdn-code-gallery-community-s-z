using CreateLibrary_vb;
using ExcelLibrary_cs;
using System;
using System.IO;
using System.Windows.Forms;

namespace Demo_cs
{
    public partial class Form1 : Form
    {
        private string fileName =  
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Demo.xlsx");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateExcel demoCreate = new CreateExcel(fileName);
            demoCreate.CreateFileIfMissing();
            setRowColumnButton.Enabled = File.Exists(fileName);
        }

        private void setRowColumnButton_Click(object sender, EventArgs e)
        {
            Operations Ops = new Operations
                {
                    FileName = fileName,
                    SheetName = "Sheet1",
                    RowHeight = Convert.ToInt32(NumericUpDownRowHeight.Value),
                    ColumnHeight = Convert.ToInt32(NumericUpDownColumn.Value)
                };

            OperationReasons result = Ops.SetRowHeightColumnWidth();
            if (result == OperationReasons.Success)
            {
                MessageBox.Show("Finished");
            }
            else if (result == OperationReasons.FileNameFound)
            {
                MessageBox.Show("Failed to locate file");
            }
            else if (result == OperationReasons.SheetNotFound)
            {
                MessageBox.Show("Failed to locate sheet");
            }
        }
    }
}