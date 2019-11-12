using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

//
// Create by E-Troy 2017/08/14
// Copyright © 2017 E-Troy corporation. all rights reserved
//
namespace SuperFaceDetection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Capture capture;
        private HaarCascade haarCascade;
        DispatcherTimer timer;
        String org_img = "org_img.jpg";
        String match_img = "match_img.jpg";

        Boolean isPlay = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            capture = new Capture();
            haarCascade = new HaarCascade(@"haarcascade_frontalface_alt_tree.xml");
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Image<Bgr,Byte> currentFrame = capture.QueryFrame();

            if (currentFrame != null)
            {
                Image<Gray, Byte> grayFrame = currentFrame.Convert<Gray, Byte>();
                    
                var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0];
                    
                foreach (var face in detectedFaces)
                    currentFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);

                camera.Source = ToBitmapSource(currentFrame);

                Bitmap img1 = new Bitmap("me.jpg");
                Bitmap img2  = currentFrame.ToBitmap(); //Convert the emgu Image to BitmapImage 
                img1 = BitmapResize(img1, org_img);
                img2 = BitmapResize(img2, match_img);
                Console.Error.WriteLine("Images are of different sizes" + FloatGetResult(GetHisogram(img1,org_img), GetHisogram(img2,org_img)));
            }
            
        }

        //The image is converted to the same size, we temporarily converted into 256 X 256 it. 
        public Bitmap BitmapResize(Bitmap orgImage, string newImageFile)
        {
            //System.Drawing.Image img = System.Drawing.Image.FromFile(imageFile);
            System.Drawing.Image img = (System.Drawing.Image)orgImage;
            Bitmap imgOutput = new Bitmap(img, 256, 256);
            imgOutput.Save(newImageFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgOutput.Dispose();
            return (Bitmap)System.Drawing.Image.FromFile(newImageFile);
        }

        //To calculate the histogram of the image, in fact, this side of the algorithm is not the best use, on the calculus we can study
        public int[] GetHisogram(Bitmap img,String name)
        {
            BitmapData data = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int[] histogram = new int[256];
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int remain = data.Stride - data.Width * 3;
                for (int i = 0; i < histogram.Length; i++)
                    histogram[i] = 0;
                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        int mean = ptr[0] + ptr[1] + ptr[2];
                        mean /= 3;
                        histogram[mean]++;
                        ptr += 3;
                    }
                    ptr += remain;
                }
            }
            img.UnlockBits(data);
            img.Dispose();
            File.Delete(name);
            return histogram;
        }

        // Calculate the absolute value after subtraction
        private float GetAbs(int firstNum, int secondNum)
        {
            float abs = Math.Abs((float)firstNum - (float)secondNum);
            float result = Math.Max(firstNum, secondNum);
            if (result == 0)
                result = 1;
            return abs / result;
        }

        // Final calculation results
        public float FloatGetResult(int[] firstNum, int[] scondNum)
        {
            if (firstNum.Length != scondNum.Length)
            {
                return 0;
            }
            else
            {
                float result = 0;
                float result2 = 0;
                int j = firstNum.Length;
                for (int i = 0; i < j; i++)
                {
                    result = GetAbs(firstNum[i], scondNum[i]);
                    result2 += 1 - result;

                    if (result > 0.99) Console.WriteLine("相似度：" + i + "----" + result + "%");

                    //check
                    if (result > 0.99)
                    {
                        //do something

                    }

                }
                return result / j;
            }
        }

        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        public static BitmapSource ToBitmapSource(IImage image)
        {
            using (System.Drawing.Bitmap source = image.Bitmap)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }
    }
}
