using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;
using System.Drawing;

namespace SetExcelFont
{
    class Program
    {
        static void Main(string[] args)
        {
             //Create Workbook and Worksheet
            Workbook workbook = new Workbook();
            Worksheet sheet = workbook.Worksheets[0];

            //Set Font Type as Calibri
            sheet.Range["B1"].Text = "Calibri";
            sheet.Range["B1"].Style.Font.FontName = "Calibri";

            //Set Font Size as 22
            sheet.Range["B2"].Text = "Large size";
            sheet.Range["B2"].Style.Font.Size = 22;

            //Set Font as Bold
            sheet.Range["B3"].Text = "Bold";
            sheet.Range["B3"].Style.Font.IsBold = true;

            //Set Font as Italic
            sheet.Range["B4"].Text = "Italic";
            sheet.Range["B4"].Style.Font.IsItalic = true;

            //Set Font as Superscript
            sheet.Range["B5"].Text = "Superscript";
            sheet.Range["B5"].Style.Font.IsSuperscript = true;

            //Set Font as Colored
            sheet.Range["B6"].Text = "Colored";
            sheet.Range["B6"].Style.Font.Color = Color.FromArgb(255, 125, 125);

            //Set Font as Underlined
            sheet.Range["B7"].Text = "Underline";
            sheet.Range["B7"].Style.Font.Underline = FontUnderlineType.Single;

            //Save File
            workbook.SaveToFile("FontStyle.xls");

            //Launch File
            System.Diagnostics.Process.Start("FontStyle.xls");
        }
    }
}
