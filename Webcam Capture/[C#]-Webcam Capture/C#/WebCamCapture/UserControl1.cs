using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WebCamCapture
{
    public partial class UserControl1 : UserControl, IDisposable
    {
        #region Referência do projeto e informações

        //http://blog.marcio-pulcinelli.com/2011/06/05/acessando-webcam-com-c/

        #endregion

        #region Variáveis

        private int m_Width = 500;
        private int m_Height = 500;
        private int m_CapHwnd;

        private bool bStopped = true;

        #endregion

        #region API Declarations

        //Abaixo tremos todas as chamadas das APIs do Sistema Operacional Windows.
        //Essas chamadas fazem a interface do nosso controle com a WebCam e com o SO.

        //Esta chamada é uma das mais importantes e é vital para o funcionamento do SO. 
        [DllImport("user32", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        //Esta API cria a instância da webcam para que possamos acessa-la.
        [DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
        public static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hwndParent, int nID);

        //Esta API abre a área de tranferência para que possamos buscar os dados da webcam.
        [DllImport("user32", EntryPoint = "OpenClipboard")]
        public static extern int OpenClipboard(int hWnd);

        //Esta API limpa a área de transferência.
        [DllImport("user32", EntryPoint = "EmptyClipboard")]
        public static extern int EmptyClipboard();

        //Esta API fecha a área de tranferência após utilização.
        [DllImport("user32", EntryPoint = "CloseClipboard")]
        public static extern int CloseClipboard();

        //Esta API recupera os dados da área de tranferência para a utilização.
        [DllImport("user32.dll")]
        extern static IntPtr GetClipboardData(uint uFormat);

        #endregion

        #region API Constants

        //Esas constantes são predefinidas pelo SO

        public const int WM_USER = 1024;

        public const int WM_CAP_CONNECT = 1034;
        public const int WM_CAP_DISCONNECT = 1035;
        public const int WM_CAP_GT_FRAME = 1084;
        public const int WM_CAP_COPY = 1054;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41;
        public const int WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42;
        public const int WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43;
        public const int WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44;
        public const int WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45;
        public const int WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46;
        public const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;

        #endregion

        public UserControl1()
        {
            InitializeComponent();
        }

        private void ImageSize()
        {
            m_Width = ImgWebCam.Size.Width;
            m_Height = ImgWebCam.Size.Height;
        }
        public void Stop()
        {
            try
            {
                bStopped = true;
                this.tmrRefrashFrame.Stop();

                Application.DoEvents();

                SendMessage(m_CapHwnd, WM_CAP_DISCONNECT, 0, 0);

                CloseClipboard();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Start()
        {
            try
            {
                ImageSize();

                this.Stop();

                m_CapHwnd = capCreateCaptureWindowA("WebCap", 0, 0, 0, m_Width, m_Height, this.Handle.ToInt32(), 0);

                Application.DoEvents();

                SendMessage(m_CapHwnd, WM_CAP_CONNECT, 0, 0);

                this.tmrRefrashFrame.Interval = 1;

                bStopped = false;
                this.tmrRefrashFrame.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Stop();
            }
        }

        private void tmrRefrashFrame_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tmrRefrashFrame.Stop();

                ImageSize();

                SendMessage(m_CapHwnd, WM_CAP_GT_FRAME, 0, 0);

                SendMessage(m_CapHwnd, WM_CAP_COPY, 0, 0);

                OpenClipboard(m_CapHwnd);

                IntPtr img = GetClipboardData(2);

                CloseClipboard();

                //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m_Width, m_Height);

                //using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                //{
                //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                //    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
                //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;

                //    g.DrawImage(Image.FromHbitmap(img), 0, 0, m_Width, m_Height);
                //}

                //ImgWebCam.Image = bmp;

                IDataObject tempObj = Clipboard.GetDataObject();
                Image tempImg = (System.Drawing.Bitmap)tempObj.GetData(DataFormats.Bitmap);

                ImgWebCam.Image = tempImg;

                ImgWebCam.Refresh();

                Application.DoEvents();

                if (!bStopped)
                {
                    this.tmrRefrashFrame.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void IDisposable.Dispose() { this.Dispose(); }
    }
}
