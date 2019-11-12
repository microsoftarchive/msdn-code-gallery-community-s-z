using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
using System.IO;

namespace PrintingStuff
{
    public partial class Window3 : Window
    {
        const double PaperWidth = 8.5;
        const double PaperHeight = 11;
        const double Dpi = 96;

        public Window3()
        {
            InitializeComponent();
        }

        private void Xps_Click(object sender, RoutedEventArgs e)
        {
            FixedPage page = new FixedPage() { Background = Brushes.White, Width = Dpi * PaperWidth, Height = Dpi * PaperHeight };

            TextBlock tbTitle = new TextBlock { Text = "My InkCanvas Sketch", FontSize = 24, FontFamily = new FontFamily("Arial") };
            FixedPage.SetLeft(tbTitle, Dpi * 0.75);
            FixedPage.SetTop(tbTitle, Dpi * 0.75);
            page.Children.Add((UIElement)tbTitle);

            var toPrint = myInkCanvasBorder;
            myGrid.Children.Remove(myInkCanvasBorder);

            FixedPage.SetLeft(toPrint, Dpi * 2);
            FixedPage.SetTop(toPrint, Dpi * 2);
            page.Children.Add(toPrint);

            Size sz = new Size(Dpi * PaperWidth, Dpi * PaperHeight);
            page.Measure(sz);
            page.Arrange(new Rect(new Point(), sz));
            page.UpdateLayout();

            var filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PrintingTest");
            if (!File.Exists(filepath))
                Directory.CreateDirectory(filepath);
            var filename = System.IO.Path.Combine(filepath, "myXpsFile.xps");

            FixedDocument doc = new FixedDocument();

            PageContent pageContent = new PageContent();
            ((System.Windows.Markup.IAddChild)pageContent).AddChild(page); 
            doc.Pages.Add(pageContent);  

            XpsDocument xpsd = new XpsDocument(filename, FileAccess.Write);
            XpsDocument.CreateXpsDocumentWriter(xpsd).Write(doc);               //requires System.Printing namespace
            
            xpsd.Close();

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintQueue.AddJob("MyInkCanvas print job", filename, true);

            page.Children.Remove(toPrint);
            myGrid.Children.Add(toPrint);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window4();
            win.Show();
            this.Close();
        }
    }
}
