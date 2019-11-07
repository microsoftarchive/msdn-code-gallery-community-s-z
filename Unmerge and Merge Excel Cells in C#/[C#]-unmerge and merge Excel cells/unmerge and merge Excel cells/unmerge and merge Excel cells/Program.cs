using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unmerge_and_merge_Excel_cells
{
    class Program
    {
        static void Main(string[] args)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\Administrator\Desktop\unmerge.xlsx");
            Worksheet sheet = book.Worksheets[0];
            sheet.Range["A2"].UnMerge();
            book.SaveToFile("consequence.xlsx", ExcelVersion.Version2010);

            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"C:\Users\Administrator\Desktop\merge.xlsx");
            workbook.Worksheets[0].Range["A2:C3"].Merge();
            workbook.SaveToFile("result.xlsx");
        }
    }
}
