using System;
using System.IO;

// If you haven't already please visit the following link in order to get GemBox.Document Free version:
// http://www.gemboxsoftware.com/document/free-version
using GemBox.Document;

namespace HtmlEditorSampleCs
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // GemBox.Document can work in three different modes: Free, Trial and Professional.
                // http://www.gemboxsoftware.com/support-center/kb/articles/3-gembox-document-free-trial-and-professional
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                ComponentInfo.FreeLimitReached += (s1, e1) => e1.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;

                this.htmlEditor.config.toolbar = new object[]
                {
                    new object[] { "Source", "-", "NewPage", "Preview", "-", "Templates" },
                    new object[] { "Cut", "Copy", "Paste", "PasteText", "PasteFromWord", "-", "Print", "SpellChecker", "Scayt" },
                    new object[] { "Undo", "Redo", "-", "Find", "Replace", "-", "SelectAll", "RemoveFormat" },
                    "/",
                    new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },
                    new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent" },
                    new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
                    new object[] { "Link", "Unlink" },
                    new object[] { "Image", "Table", "SpecialChar", "PageBreak" },
                    "/",
                    new object[] { "Styles", "Format", "Font", "FontSize" },
                    new object[] { "TextColor", "BGColor" },
                    new object[] { "Maximize", "ShowBlocks" }
                };
            }
        }

        protected void OnExportButtonClicked(object sender, EventArgs e)
        {
            var templatePath = Path.Combine((string)AppDomain.CurrentDomain.GetData("DataDirectory"), "TemplateDocument.docx");

            DocumentModel document;
            using (var stream = File.OpenRead(templatePath))
                document = DocumentModel.Load(stream, LoadOptions.DocxDefault);

            document.Bookmarks["HtmlContent"].GetContent(true).LoadText(this.htmlEditor.Text, LoadOptions.HtmlDefault);

            var fileName = Path.ChangeExtension("Document", this.outputFormatList.SelectedValue);

            document.Save(this.Response, fileName);
        }
    }
}