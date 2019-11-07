using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace WPF_Interop_Excel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private System.Data.DataSet excelDataSet;

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/microsoft.win32.filedialog.filter(v=vs.110).aspx

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel documents (*.xlsx, *.xls)|*.xlsx;*.xls|All files (*.*)|*.*"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                txtBoxFileName.Text = filename;

                try { importExcelFile(filename); }
                catch (Exception ex) { ;}
            }
        }


        private DataSet importExcelFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            System.Data.DataSet ds = new System.Data.DataSet();
            Workbook wkBook = excelApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            ds.DataSetName = wkBook.Name;

            foreach (Worksheet ws in wkBook.Worksheets)
            {
                ds.Merge(importExcelSheet(ws));
                ds.AcceptChanges();
            }

            System.Windows.Forms.DataGridTableStyle tstyle = new System.Windows.Forms.DataGridTableStyle();
            tstyle.AllowSorting = true;
            tstyle.RowHeaderWidth = 0;

            DG.TableStyles.Add(tstyle);

            DG.NavigateBack();
            DG.NavigateBack();
            DG.DataSource = ds;

            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(wkBook);

            return ds;
        }


        private System.Data.DataTable importExcelSheet(Worksheet ws)
        {
            Range range = ws.UsedRange; ;

            string str = "";
            int rCnt = 0;
            int cCnt = 0;

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.TableName = ws.Name;

            //first excel row - column's name row...
            // column's name should not be empty ...
            try
            {
                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    str = (string)(range.Cells[1, cCnt] as Range).Value2;
                    if (str != null) dt.Columns.Add(str,System.Type.GetType("System.String"));
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("belongs") != 0)
                {
                    MessageBox.Show(" Duplicate Column Name in worksheet - [" + ws.Name + "]..." + Environment.NewLine + " Please fix/change column name - [" + str + "]" + Environment.NewLine + " and try again! ", "Column name MUST be unique! ");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error during reading Excel file! ");               
                }
                return null;
            }

            // next - data

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    String strSum = "";
                    DataRow dr = dt.NewRow();
                    for (cCnt = 1; cCnt <= dt.Columns.Count; cCnt++)
                    {
                        var x = (range.Cells[rCnt, cCnt] as Range).Value2;
                        if (x != null)
                        {
                            str = x.ToString();
                        }
                        else 
                        {
                            str = "";
                        }

                        dr[cCnt - 1] = str;
                        strSum += str;  // Do not insert empty row ...
                    }
                    if (strSum.Trim() != "") dt.Rows.Add(dr);
                }

            dt.AcceptChanges();
            releaseObject(ws);
            return dt;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



    }
}
