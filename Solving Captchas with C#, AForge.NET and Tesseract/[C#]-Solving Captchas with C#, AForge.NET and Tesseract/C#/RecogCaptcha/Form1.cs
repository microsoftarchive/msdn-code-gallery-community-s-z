using AForge.Imaging.Filters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;

namespace RecogCaptcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Bitmap image = new Bitmap(openFileDialog.FileName);
            if (image != null)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(openFileDialog.FileName);
                resultLabel.Text = reconhecerCaptcha(image);
            }
            image.Dispose();
        }

        private string reconhecerCaptcha(Image img)
        {
            Bitmap imagem = new Bitmap(img);
            imagem = imagem.Clone(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Erosion erosion = new Erosion();
            Dilatation dilatation = new Dilatation();
            Invert inverter = new Invert();
            ColorFiltering cor = new ColorFiltering();
            cor.Blue = new AForge.IntRange(200, 255);
            cor.Red = new AForge.IntRange(200, 255);
            cor.Green = new AForge.IntRange(200, 255);
            Opening open = new Opening();
            BlobsFiltering bc = new BlobsFiltering();
            Closing close = new Closing();
            GaussianSharpen gs = new GaussianSharpen();
            ContrastCorrection cc = new ContrastCorrection();
            bc.MinHeight = 10;
            FiltersSequence seq = new FiltersSequence(gs, inverter, open, inverter, bc, inverter, open, cc, cor, bc, inverter);
            pictureBox.Image = seq.Apply(imagem);
            string reconhecido = OCR((Bitmap)pictureBox.Image);
            return reconhecido;
        }

        private string OCR(Bitmap b)
        {
            string res = "";
            using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
            {
                engine.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                engine.SetVariable("tessedit_unrej_any_wd", true);
                
                using (var page = engine.Process(b, PageSegMode.SingleLine))
                    res = page.GetText();
            }
            return res;
        }
    }
}
