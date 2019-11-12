using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;

namespace PrintingStuff
{
    public partial class MainWindow : Window
    {
        public List<string> Images { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                DrawingVisual dv = new DrawingVisual();

                var dc = dv.RenderOpen();

                var rect = new Rect(new System.Windows.Point(20, 20), new System.Windows.Size(350, 240));
                dc.DrawRoundedRectangle(System.Windows.Media.Brushes.Yellow, new Pen(Brushes.Purple, 2), rect, 20, 20);

                dc.DrawImage(new BitmapImage(new Uri("pack://application:,,,/Media/XAMLguy.png", UriKind.Absolute)), new Rect(50, 50, 100, 100));

                dc.DrawText(new FormattedText("WPF Printing", CultureInfo.CurrentCulture, FlowDirection,
                      new Typeface(new System.Windows.Media.FontFamily("Courier New"), FontStyles.Normal, FontWeights.Bold,
                          FontStretches.Normal), 13, System.Windows.Media.Brushes.Black), new System.Windows.Point(50, 180));

                dc.DrawGeometry(Brushes.Green, new Pen(Brushes.Gray, 2), new RectangleGeometry(new Rect(270, 110, 40, 100)));

                dc.DrawEllipse(Brushes.Red, (System.Windows.Media.Pen)null, new Point(290, 90), 50, 50);
                dc.DrawEllipse(Brushes.Blue, (System.Windows.Media.Pen)null, new Point(280, 85), 14, 18);
                dc.DrawEllipse(Brushes.Blue, (System.Windows.Media.Pen)null, new Point(320, 85), 14, 18);

                rect = new Rect(new System.Windows.Point(240, 50), new System.Windows.Size(100, 30));
                dc.DrawRectangle(System.Windows.Media.Brushes.Black, (System.Windows.Media.Pen)null, rect);

                dc.DrawLine(new Pen(Brushes.Black, 2), new Point(230, 140), new Point(350, 200));

                dc.DrawDrawing(CreateGeometryDrawing());

                dc.DrawGlyphRun(Brushes.Red, CreateGlyphRun());

                dc.Close();

                printDialog.PrintVisual(dv, "Print");

                RenderTargetBitmap bmp = new RenderTargetBitmap(600, 350, 120, 96, PixelFormats.Pbgra32);
                bmp.Render(dv);
                Image img = new Image { Width=100, Height=100, Source = bmp, Stretch=Stretch.Fill };

                Width = 500;
                Height = 400;

                var r = new Rectangle { Fill = new ImageBrush(bmp) };
                r.SetValue(Grid.RowProperty, 1);
                r.SetValue(Grid.ZIndexProperty, -1);
                grid1.Children.Add(r);
            }
        }

        GeometryDrawing CreateGeometryDrawing()
        {
            //http://msdn.microsoft.com/en-us/library/system.windows.media.geometrydrawing.aspx

            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(
                new EllipseGeometry(new Point(200, 200), 45, 20)
                );
            ellipses.Children.Add(
                new EllipseGeometry(new Point(200, 200), 20, 45)
                );

            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = ellipses;

            // Paint the drawing with a gradient.
            aGeometryDrawing.Brush =
                new LinearGradientBrush(
                    Colors.Blue,
                    Color.FromRgb(204, 204, 255),
                    new Point(0, 0),
                    new Point(1, 1));

            return aGeometryDrawing;
        }

        GlyphRun CreateGlyphRun()
        {
            //http://msdn.microsoft.com/en-us/library/system.windows.media.glyphrundrawing.glyphrun.aspx
            GlyphRun gr = new GlyphRun(
                new GlyphTypeface(new Uri(@"C:\WINDOWS\Fonts\TIMES.TTF")),      // Font
                0,
                false,
                13,
                new ushort[] { 43, 72, 79, 79, 82, 3, 58, 82, 85, 79, 71 },     // glyphIndices (Hello World)
                new Point(50, 220),                                             // baseline (position)
                new double[]{ 9.62666666666667, 7.41333333333333, 2.96,         // advanceWidths (width of each character)
                    2.96, 7.41333333333333, 3.70666666666667, 
                    12.5866666666667, 7.41333333333333, 
                    4.44, 2.96, 7.41333333333333},
                null,
                null,
                null,
                null,
                null,
                null
                );

           return gr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window1();
            win.Show();
            this.Close();
        }

    }
}
