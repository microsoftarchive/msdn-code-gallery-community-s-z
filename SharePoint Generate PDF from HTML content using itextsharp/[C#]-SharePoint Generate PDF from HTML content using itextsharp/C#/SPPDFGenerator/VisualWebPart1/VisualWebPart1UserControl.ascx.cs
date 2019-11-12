using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.SharePoint;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SPPDFGenerator.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //image should have the absolute server url so that the api can reference it
            ltExporttoPDF.Text = @"<div >
                                       This the the content which will be exported to pdf and it contains an image too<br />
                                      <img  src='"+ SPContext.Current.Web.Url +@"/_layouts/15/images/SPPDFGenerator/testImage.jpg' />
                                    </div>";
           btnExportPDF.Click+=btnExportPDF_Click;

        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

            try
            {
                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);

                //Open PDF Document to write data
                pdfDoc.Open();

                //Assign Html content in a string to write in PDF
                string strContent = ltExporttoPDF.Text;



                //Read string contents using stream reader and convert html to parsed conent
                var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(strContent), null);

                //Get each array values from parsed elements and add to the PDF document
                foreach (var htmlElement in parsedHtmlElements)
                    pdfDoc.Add(htmlElement as IElement);

                //Close your PDF
                pdfDoc.Close();

                Response.ContentType = "application/pdf";

                //Set default file Name as current datetime
                Response.AddHeader("content-disposition", "attachment; filename=Test.pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);

                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

    }
}