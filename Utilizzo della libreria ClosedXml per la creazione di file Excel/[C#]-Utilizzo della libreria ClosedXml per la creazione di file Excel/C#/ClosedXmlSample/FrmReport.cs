//dll net framework
using System;
using System.Globalization;
using System.Windows.Forms;
using ClosedXmlSample.Properties;

//This and instead the reference that must be included in the project to use the library ClosedXml
using ClosedXML.Excel;

//NameSpace ClosedXlmSample
namespace ClosedXmlSample
{
    //FrmReport Class
    public partial class FrmReport : Form
    {
        // Constructor of the class FrmReport
        public FrmReport()
        {
            //InitializeComponent Method
            InitializeComponent();
        }

        //This property is value in the main form with the values ​​in the DataGrid, which then in turn enhances the Forms DataGrid control FrmReport
        public DataGridView DataReport { get; set; }

        //FrmReportLoad Event
        private void FrmReportLoad(object sender, EventArgs e)
        {
            /*Enhanced the value control DataGrid using the property DataReport*/
            dgvReport.DataSource = DataReport.DataSource;
        }

        //BtnExportToExcelClick Event
        private void BtnExportToExcelClick(object sender, EventArgs e)
        {
            /*If the DataGrid control does not contain any column*/
            if (dgvReport.Columns.Count.Equals(0))
            {
                /*I get a message to the user*/
                MessageBox.Show(Resources.FrmReport_BtnSalvaInExcelClick_Nessuna_riga_da_salvare, Application.ProductName.ToString(CultureInfo.InvariantCulture));
                return;
            }

            /*Imposed on the size of the file to be saved for the SaveFileDialog component, 
             * the format and saved in the application's resources.*/
            sfDialog.Filter = Resources.FileXlsx;

            /*Given the name of the excel file that will be generated.*/
            sfDialog.FileName = "USER DATA";

            /*Here, however, we create a new worksheet excel*/
            var workbook = new XLWorkbook();

            /*On the worksheet, create the worksheet in another sheet named user reports, 
             * this leaflet will be included in the excel file which will then be generated.*/
            var worksheet = workbook.Worksheets.Add("USER DATA REPORT");

            /*I create variables as there are columns of excel file to be created, 
             * in this case 6 and the imposed with a default value*/
            var cellA = "A";
            var cellB = "B";
            var cellC = "C";
            var cellD = "D";
            var cellE = "E";
            var cellF = "F";

            /*This variable is used for the process of writing the various sections of the paper, the header, 
             * the name of the columns to end up with the values ​​of the DataGrid control*/
            var indexcell = 0;

            /*In this loop we perform the control of the variable index and it will create the header of the sheet, 
             * a title and the formatting of cells on the alignment of the title text*/
            for (var riga = 0; riga < 4; riga++)
            {
                /*In this loop are enclosed in stages to the header in the title, the cell formatting and the column headings*/
                indexcell += 1;

                /*If index equals 1*/
                if (indexcell.Equals(1))
                {
                    /*Allowance for cells and and the numerical value given by the variable i and indexcell*/
                    cellA += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellF += indexcell.ToString(CultureInfo.InvariantCulture);

                    /*The Merge method allows to combine two or more cells, in this case we combine the cells from a to f*/
                    worksheet.Range(cellA + ":" + cellF).Merge();

                    /*Assign a value to the cell, so that it can fill the contents of the cells to f*/
                    worksheet.Cell(cellA).Value = "USER DATA";

                    /*Check by enumeration XLAlignmentHorizontalValues​​, the alignment of text within the cell to be shown at the center*/
                    worksheet.Cell(cellA).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellA).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;

                    /*default value for cell a and f*/
                    cellA = "A";
                    cellF = "F";
                }

                /*If index equals 2*/
                if (indexcell.Equals(2))
                {
                    /*Allowance for cells and and the numerical value given by the variable i and indexcell*/
                    cellA += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellB += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellC += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellD += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellE += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellF += indexcell.ToString(CultureInfo.InvariantCulture);

                    /*Here, however, we assign the cell to the cell f the name of the columns of the DataGrid control by property Value*/
                    worksheet.Cell(cellA).Value = dgvReport.Columns[1].Name;
                    worksheet.Cell(cellB).Value = dgvReport.Columns[2].Name;
                    worksheet.Cell(cellC).Value = dgvReport.Columns[3].Name;
                    worksheet.Cell(cellD).Value = dgvReport.Columns[4].Name;
                    worksheet.Cell(cellE).Value = dgvReport.Columns[5].Name;
                    worksheet.Cell(cellF).Value = dgvReport.Columns[6].Name;

                    /*Check by enumeration XLAlignmentHorizontalValues​​, the alignment of text within the cell to be shown at the center*/
                    worksheet.Cell(cellA).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellB).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellC).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellD).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellE).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellF).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    /*default value for cell from a to f*/
                    cellA = "A";
                    cellB = "B";
                    cellC = "C";
                    cellD = "D";
                    cellE = "E";
                    cellF = "F";
                }
            }

            /*In this loop will perform the control of the variable index and prodcederà to the writing of the values ​​contained in 
             * the DataGrid on the variables from cell to celfl, so pore actually write on the cells of the sheet excel*/
            for (var riga = 0; riga < dgvReport.Rows.Count; riga++)
            {
                /*If index equals 3*/
                if (indexcell > 3)
                {
                    /*Allowance for cells and and the numerical value given by the variable i and indexcell*/
                    cellA += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellB += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellC += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellD += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellE += indexcell.ToString(CultureInfo.InvariantCulture);
                    cellF += indexcell.ToString(CultureInfo.InvariantCulture);

                    /*Here instead we assign from cell to cell f the value of each row in the DataGrid control and always through their Value property*/
                    worksheet.Cell(cellA).Value = dgvReport.Rows[riga].Cells[1].Value;
                    worksheet.Cell(cellB).Value = dgvReport.Rows[riga].Cells[2].Value;
                    worksheet.Cell(cellC).Value = dgvReport.Rows[riga].Cells[3].Value;
                    worksheet.Cell(cellD).Value = dgvReport.Rows[riga].Cells[4].Value;
                    worksheet.Cell(cellE).Value = dgvReport.Rows[riga].Cells[5].Value;
                    worksheet.Cell(cellF).Value = dgvReport.Rows[riga].Cells[6].Value;

                    /*Check by enumeration XLAlignmentHorizontalValues​​, the alignment of text within the cell to be shown at the center*/
                    worksheet.Cell(cellA).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellB).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellC).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellD).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellE).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(cellF).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    /*This method allows to adapt the text within the cells so that it is well centered and adapted to their inner*/
                    worksheet.Columns().AdjustToContents();

                    /*default value for cell from a to f*/
                    cellA = "A";
                    cellB = "B";
                    cellC = "C";
                    cellD = "D";
                    cellE = "E";
                    cellF = "F";
                }

                /*increase the value of the variable indexcell*/
                indexcell += 1;
            }

            /*Here we give the user the possibility scegiere where to save the file which will then be generated using the SaveFileDialog*/
            if (sfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                /*This method will save the file in xlsx excel where the user decide this 
                 * by the argument required by that method where we spend the path of destination*/
                workbook.SaveAs(sfDialog.FileName);
            }
        }

        //BtnExitClick Event
        private void BtnExitClick(object sender, EventArgs e)
        {
            /*Close actual Form*/
            Close();
        }
    }
}
