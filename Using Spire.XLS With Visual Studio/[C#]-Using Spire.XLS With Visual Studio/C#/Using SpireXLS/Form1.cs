using System;
using System.Windows.Forms;
using Spire.Xls;
using Spire.Pdf;
using Spire.Xls.Converter;
using System.Text;

namespace Using_SpireXLS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // load Excel file
           Workbook workbook = new Workbook();
           workbook.LoadFromFile("D:\\MyExcel.xlsx");
           // Set PDF template
           PdfDocument pdfDocument = new PdfDocument();
           pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
           pdfDocument.PageSettings.Width = 970;
           pdfDocument.PageSettings.Height = 850;
           //Convert Excel to PDF using the template above
           PdfConverter pdfConverter = new PdfConverter(workbook);
           PdfConverterSettings settings = new PdfConverterSettings();
           settings.TemplateDocument = pdfDocument;
           pdfDocument = pdfConverter.Convert(settings);
           // Save and preview PDF
           pdfDocument.SaveToFile("MyPDF.pdf");
           System.Diagnostics.Process.Start("MyPDF.pdf");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //load Excel file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("D:\\MyExcel.xlsx");
            //convert Excel to HTML
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToHtml("MyHTML.html");
            //Preview HTML
            System.Diagnostics.Process.Start("MyHTML.html");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("D:\\MyExcel.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToImage("MyImage.jpg");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile("D:\\MyExcel.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.SaveToFile("MyCSV.csv", ",", Encoding.UTF8);

        }
    }
}
