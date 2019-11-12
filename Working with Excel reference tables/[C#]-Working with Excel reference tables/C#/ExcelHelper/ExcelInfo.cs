using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelHelper
{
    public class ExcelInfo
    {
        public Exception LastException { get; set; }

        private List<ExcelReferenceTable> mReferenceTables;

        /// <summary>
        /// List of reference tables
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<ExcelReferenceTable> ReferenceTables
        {
            get
            {
                return mReferenceTables;
            }
        }

        private string[] Extensions = { ".xls", ".xlsx" };
        private string mFileName;

        /// <summary>
        /// Valid/existing Excel file name to work with.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string FileName
        {
            get
            {
                return mFileName;
            }
            set
            {
                if (!(Extensions.Contains(System.IO.Path.GetExtension(value.ToLower()))))
                {
                    throw new Exception("Invalid file name");
                }
                mFileName = value;
            }
        }

        private List<string> mNameRanges = new List<string>();

        /// <summary>
        /// List of named ranges in current file
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> NameRanges
        {
            get
            {
                return mNameRanges;
            }
        }

        private List<string> mSheets = new List<string>();

        /// <summary>
        /// List of work sheets in current file
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> Sheets
        {
            get
            {
                return mSheets;
            }
        }

        private Dictionary<Int32, string> mSheetsData = new Dictionary<Int32, string>();

        public Dictionary<Int32, string> SheetsData
        {
            get
            {
                return mSheetsData;
            }
        }

        public ExcelInfo()
        {
        }

        /// <summary>
        /// File to get information from
        /// </summary>
        /// <param name="FileName"></param>
        /// <remarks>
        /// The caller is responsible to ensure the file exists.
        /// </remarks>
        public ExcelInfo(string FileName)
        {
            this.FileName = FileName;
        }

        /// <summary>
        /// Retrieve worksheet and name range names.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool GetInformation()
        {
            bool Success = true;

            if (!(System.IO.File.Exists(FileName)))
            {
                Exception ex = new Exception("Failed to locate '" + FileName + "'");
                this.LastException = ex;
                throw ex;
            }

            mSheets.Clear();
            mNameRanges.Clear();
            mSheetsData.Clear();

            if (mReferenceTables != null)
            {
                mReferenceTables.Clear();
            }

            Excel.Application xlApp = null;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Workbook xlActiveRanges = null;
            Excel.Names xlNames = null;
            Excel.Sheets xlWorkSheets = null;

            try
            {
                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;
                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(FileName);

                xlActiveRanges = xlApp.ActiveWorkbook;
                xlNames = xlActiveRanges.Names;

                for (int x = 1; x <= xlNames.Count; x++)
                {
                    Excel.Name xlName = xlNames.Item(x);
                    mNameRanges.Add(xlName.Name);
                    Marshal.FinalReleaseComObject(xlName);
                    xlName = null;
                }

                xlWorkSheets = xlWorkBook.Sheets;

                for (int x = 1; x <= xlWorkSheets.Count; x++)
                {
                    Excel.Worksheet Sheet1 = (Excel.Worksheet)xlWorkSheets[x];
                    mSheets.Add(Sheet1.Name);
                    mSheetsData.Add(x, Sheet1.Name);
                    Marshal.FinalReleaseComObject(Sheet1);
                    Sheet1 = null;
                }

                GetReferenceTables(xlWorkSheets);
                ReleaseComObject(xlWorkSheets);
                xlWorkBook.Close();

                xlApp.UserControl = true;
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                this.LastException = ex;
                Success = false;
            }
            finally
            {
                if (xlWorkSheets != null)
                {
                    Marshal.FinalReleaseComObject(xlWorkSheets);
                    xlWorkSheets = null;
                }

                if (xlNames != null)
                {
                    Marshal.FinalReleaseComObject(xlNames);
                    xlNames = null;
                }

                if (xlActiveRanges != null)
                {
                    Marshal.FinalReleaseComObject(xlActiveRanges);
                    xlActiveRanges = null;
                }
                if (xlActiveRanges != null)
                {
                    Marshal.FinalReleaseComObject(xlActiveRanges);
                    xlActiveRanges = null;
                }

                if (xlWorkBook != null)
                {
                    Marshal.FinalReleaseComObject(xlWorkBook);
                    xlWorkBook = null;
                }

                if (xlWorkBooks != null)
                {
                    Marshal.FinalReleaseComObject(xlWorkBooks);
                    xlWorkBooks = null;
                }

                if (xlApp != null)
                {
                    Marshal.FinalReleaseComObject(xlApp);
                    xlApp = null;
                }
            }

            return Success;
        }

        private List<ExcelReferenceTable> GetReferenceTables(Excel.Sheets xlWorkSheets)
        {
            List<ExcelReferenceTable> Result = new List<ExcelReferenceTable>();
            string Temp = "";
            Excel.Worksheet xlWorkSheet = null;
            Excel.ListObjects xlListObjects = null;
            Excel.ListObject ThisItem = null;

            for (int x = 1; x <= xlWorkSheets.Count; x++)
            {
                ExcelReferenceTable Item = new ExcelReferenceTable();

                xlWorkSheet = (Excel.Worksheet)xlWorkSheets[x];
                xlListObjects = xlWorkSheet.ListObjects;

                Int32 TotalCount = xlListObjects.Count - 1;
                for (int y = 0; y <= TotalCount; y++)
                {
                    ThisItem = xlListObjects.Item[y + 1];
                    Item.Name = ThisItem.Name;
                    Item.SheetName = xlWorkSheet.Name;

                    // TODO: Need to tinker with this.
                    try
                    {
                        Excel.QueryTable QT = ThisItem.QueryTable;
                        Item.SourceDataFile = QT.SourceDataFile;
                        ReleaseComObject(QT);
                    }
                    catch (Exception)
                    {
                        Item.SourceDataFile = "";
                    }

                    Excel.Range ThisRange = ThisItem.Range;
                    Temp = ThisRange.Address;

                    Item.Address = Temp.Replace("$", "");

                    Result.Add(Item);

                    Marshal.FinalReleaseComObject(ThisRange);
                    ThisRange = null;

                    Marshal.FinalReleaseComObject(ThisItem);
                    ThisItem = null;

                    Marshal.FinalReleaseComObject(xlListObjects);
                    xlListObjects = null;
                }
            }

            ReleaseComObject(xlWorkSheet);

            mReferenceTables = Result;

            return Result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// Generally speaking we should not have to call
        /// GC.Collect() but about one percent of the time
        /// Excel will refuse to release an object dependency
        /// thus no choice but to call GC.Collect(). Please
        /// make every effort to use ReleaseComObjectClean
        /// rather than this procedure unless a object refuses
        /// to release.
        /// </remarks>
        private void ReleaseComObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public void ReleaseComObjectClean(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
        }
    }
}