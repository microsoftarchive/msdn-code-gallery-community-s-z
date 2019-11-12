using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-02-23
/// Description :Excel AddIn Control
/// Latest
/// Modifier    :Shanu
/// Modify date :  2015-02-23
/// </summary>

namespace SHANUExcelAddIn
{
    public partial class ShanuExcelADDIn : UserControl
    {
      
        public ShanuExcelADDIn()
        {
            InitializeComponent();
        }

       
       
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                String ConnectionString = "Data Source=YOURDATASOURCE;Initial Catalog=YOURDATABASENAME;User id = UID;password=password";
                SqlConnection con = new SqlConnection(ConnectionString);
                String Query = " Select Item_Code,Item_Name FROM ItemMasters Where Item_Name LIKE '" + txtItemName.Text.Trim() + "%'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = System.Data.CommandType.Text;
                System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd);
                sda.Fill(dt);

                if (dt.Rows.Count <= 0)
                {
                    return;
                }

                Globals.ThisAddIn.Application.ActiveSheet.Cells.ClearContents();

                Globals.ThisAddIn.Application.ActiveSheet.Cells[1, 1].Value2 = "Item Code";

                Globals.ThisAddIn.Application.ActiveSheet.Cells[1, 2].Value2 = "Item Name";

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    Globals.ThisAddIn.Application.ActiveSheet.Cells[i + 2, 1].Value2 = dt.Rows[i][0].ToString();


                    Globals.ThisAddIn.Application.ActiveSheet.Cells[i + 2, 2].Value2 = dt.Rows[i][1].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            Excel.Range objRange = Globals.ThisAddIn.Application.ActiveCell;
            objRange.Interior.Color = Color.Pink; //Active Cell back Color
            objRange.Borders.Color = Color.Red;// Active Cell border Color
            objRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            objRange.Value = txtActiveCellText.Text; //Active Cell Text Add

            objRange.Columns.AutoFit(); 
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "*";
            dlg.DefaultExt = "bmp";
            dlg.ValidateNames = true;

            dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Bitmap dImg = new Bitmap(dlg.FileName);

                Excel.Shape IamgeAdd = Globals.ThisAddIn.Application.ActiveSheet.Shapes.AddPicture(dlg.FileName,

        Microsoft.Office.Core.MsoTriState.msoFalse,

        Microsoft.Office.Core.MsoTriState.msoCTrue,

        20, 30, dImg.Width, dImg.Height);
            }

            //we should also clear the clip board

            System.Windows.Forms.Clipboard.Clear();
        }

       

      
       
    }
}
