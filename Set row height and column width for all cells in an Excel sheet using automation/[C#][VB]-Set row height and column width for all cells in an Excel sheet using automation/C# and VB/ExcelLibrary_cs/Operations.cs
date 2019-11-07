using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelLibrary_cs
{
    public class Operations
    {
        /// <summary>
        /// File name to work with
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string FileName { get; set; }

        /// <summary>
        /// Sheet name to work with
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SheetName { get; set; }

        /// <summary>
        /// Value to set all row's heights
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int RowHeight { get; set; }

        /// <summary>
        /// Value to set all column widths
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int ColumnHeight { get; set; }

        public Operations()
        {
        }

        public Operations(string FileName, string SheetName, int RowHeight, int ColumnHeight)
        {
            this.FileName = FileName;
            this.SheetName = SheetName;
            this.RowHeight = RowHeight;
            this.ColumnHeight = ColumnHeight;
        }

        public OperationReasons SetRowHeightColumnWidth()
        {
            if (System.IO.File.Exists(FileName))
            {
                bool SheetNotLocated = false;

                bool Proceed = false;

                Excel.Application xlApp = null;
                Excel.Workbooks xlWorkBooks = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                Excel.Sheets xlWorkSheets = null;
                Excel.Range xlCells = null;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(FileName);

                xlApp.Visible = false;

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];

                    if (xlWorkSheet.Name == SheetName)
                    {
                        Proceed = true;
                        break;
                    }

                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlWorkSheet);
                    xlWorkSheet = null;
                }

                if (Proceed)
                {
                    xlCells = xlWorkSheet.Cells;
                    Excel.Range EntireRow = xlCells.EntireRow;
                    EntireRow.RowHeight = RowHeight;
                    EntireRow.ColumnWidth = ColumnHeight;

                    ReleaseComObject(xlCells);
                    ReleaseComObject(EntireRow);
                }
                else
                {
                    SheetNotLocated = true;
                }

                xlWorkSheet.SaveAs(FileName);

                xlWorkBook.Close();
                xlApp.UserControl = true;
                xlApp.Quit();

                ReleaseComObject(xlWorkSheets);
                ReleaseComObject(xlWorkSheet);
                ReleaseComObject(xlWorkBook);
                ReleaseComObject(xlWorkBooks);
                ReleaseComObject(xlApp);
                if (SheetNotLocated)
                {
                    return OperationReasons.SheetNotFound;
                }
                else
                {
                    return OperationReasons.Success;
                }
            }
            else
            {
                return OperationReasons.FileNameFound;
            }
        }

        /// <summary>
        /// Clean up objects
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks></remarks>
        private void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
            }
        }
    }

    public enum OperationReasons
    {
        /// <summary>
        /// Operation was sucessful
        /// </summary>
        /// <remarks></remarks>
        Success,

        /// <summary>
        /// File does not exists
        /// </summary>
        /// <remarks></remarks>
        FileNameFound,

        /// <summary>
        /// Sheet does not exists
        /// </summary>
        /// <remarks></remarks>
        SheetNotFound
    }
}