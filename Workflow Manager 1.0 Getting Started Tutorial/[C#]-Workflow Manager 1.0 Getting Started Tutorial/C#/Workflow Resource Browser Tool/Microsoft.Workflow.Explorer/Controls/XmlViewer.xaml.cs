//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.Controls
{
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;  
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Xml;

    /// <summary>
    /// Custom control for displaying formatted XML content.
    /// </summary>
    /// <remarks>
    /// Rich text was chosen because it allows the user to copy/paste the content and retain the formatting characteristics.
    /// Note that if there is too much text, this control will revert back to plain text in order to maintain reasonable performance.
    /// </remarks>
    public partial class XmlViewer : UserControl
    {
        public static readonly DependencyProperty XmlString = DependencyProperty.RegisterAttached(
            "XmlString",
            typeof(string),
            typeof(XmlViewer),
            new PropertyMetadata(string.Empty, OnXmlStringChanged));

        public XmlViewer()
        {
            this.InitializeComponent();
        }

        public static void SetXmlString(DependencyObject obj, string value)
        {
            obj.SetValue(XmlString, value);
        }

        public static bool GetXmlString(DependencyObject obj)
        {
            return (bool)obj.GetValue(XmlString);
        }

        static void OnXmlStringChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            XmlViewer self = (XmlViewer)obj;
            string xml = (string)e.NewValue;

            if (xml.Length > 1024 * 1024)
            {
                // there is too much text which kills RichTextBox performance, so use a regular textbox instead
                System.Diagnostics.Trace.WriteLine("XML formatting has been disabled due to the large amount of text.");
                self.plainTextBox.Text = xml;
                self.richTextBox.Visibility = Visibility.Collapsed;
                self.plainTextBox.Visibility = Visibility.Visible;
                return;
            }
            else if (xml.Length == 0)
            {
                return;
            }

            FlowDocument document = new FlowDocument();
            Paragraph paragraph = new Paragraph();
            document.Blocks.Add(paragraph);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            using (XmlTextReader reader = new XmlTextReader(stream))
            {
                const int indentLength = 2;
                bool previousElementHadText = false;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Depth > 0)
                            {
                                if (!reader.HasValue)
                                {
                                    paragraph.Inlines.Add(new LineBreak());
                                }

                                paragraph.Inlines.Add(new string(' ', reader.Depth * indentLength));
                            }

                            paragraph.Inlines.Add(new Run("<") { Foreground = Brushes.Blue });
                            paragraph.Inlines.Add(new Run(reader.Name) { Foreground = Brushes.Brown });

                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    paragraph.Inlines.Add(" ");
                                    paragraph.Inlines.Add(new Run(reader.Name) { Foreground = Brushes.Red });
                                    paragraph.Inlines.Add(new Run("=") { Foreground = Brushes.Blue });
                                    paragraph.Inlines.Add("\"");
                                    paragraph.Inlines.Add(new Run(reader.Value) { Foreground = Brushes.Blue });
                                    paragraph.Inlines.Add("\"");
                                }

                                reader.MoveToElement();
                            }

                            paragraph.Inlines.Add(new Run(reader.IsEmptyElement ? "/>" : ">") { Foreground = Brushes.Blue });
                            previousElementHadText = false;
                            break;
                        case XmlNodeType.Text:
                            paragraph.Inlines.Add(reader.Value);
                            previousElementHadText = true;
                            break;
                        case XmlNodeType.EndElement:
                            if (!previousElementHadText)
                            {
                                paragraph.Inlines.Add(new LineBreak());
                                if (reader.Depth > 0)
                                {
                                    paragraph.Inlines.Add(new string(' ', reader.Depth * indentLength));
                                }
                            }

                            paragraph.Inlines.Add(new Run("</") { Foreground = Brushes.Blue });
                            paragraph.Inlines.Add(new Run(reader.Name) { Foreground = Brushes.Brown });
                            paragraph.Inlines.Add(new Run(">") { Foreground = Brushes.Blue });
                            previousElementHadText = false;
                            break;
                    }
                }
            }

            self.richTextBox.Document = document;
        }
    }
}
