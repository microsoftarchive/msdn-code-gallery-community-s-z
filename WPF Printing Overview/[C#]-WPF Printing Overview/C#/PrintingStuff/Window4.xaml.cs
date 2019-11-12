using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.IO;
using System.Drawing.Printing;

namespace PrintingStuff
{
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();

            var tl = new MediaTimeline(new Uri(@"Media/Movie1.wmv", UriKind.Relative));
            player.Clock = tl.CreateClock(true) as MediaClock;
            player.MediaOpened += (o, e) => 
            {
                slider.Maximum = player.NaturalDuration.TimeSpan.Seconds;
                player.Clock.Controller.Pause(); 
            }; 
            slider.ValueChanged += (o, e) => 
            {
                player.Clock.Controller.Seek(TimeSpan.FromSeconds(slider.Value), TimeSeekOrigin.BeginTime); 
            }; 

        }

        private void player_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            //Put a breakpoint here if you get errors.
            MessageBox.Show("Error opening video file: " + e.ErrorException.Message);
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            var filepath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PrintingTest");
            if (!File.Exists(filepath))
                Directory.CreateDirectory(filepath);
            var filename = System.IO.Path.Combine(filepath, "myVideoFrame.jpg");

            byte[] screenshot = GetScreenShot(player, 1, 90);
            FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(screenshot);
            binaryWriter.Close();

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (object printSender, PrintPageEventArgs args) =>
            {
                var img = System.Drawing.Image.FromFile(filename);
                args.Graphics.DrawImageUnscaled(img, new System.Drawing.Point(0, 0));
            };

            PrintDialog dialog = new PrintDialog();
            dialog.ShowDialog();
            pd.Print(); 
        }

        public byte[] GetScreenShot(UIElement source, double scale, int quality)
        {
            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;
            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth,
                (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(source);

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0),
                    new Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);

            JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
            jpgEncoder.QualityLevel = quality;
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            Byte[] imageArray;

            using (MemoryStream outputStream = new MemoryStream())
            {
                jpgEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }
            return imageArray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window5();
            win.Show();
            Close();
        }

    }
}
